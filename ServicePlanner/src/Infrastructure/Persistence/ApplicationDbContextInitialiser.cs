using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Entities.ServicePlanner;
using ServicePlanner.Infrastructure.Identity;

namespace ServicePlanner.Infrastructure.Persistence;
public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }

        // Default data
        // Seed, if necessary
        if (!_context.WorkOrderStatuses.Any())
        {
            _context.WorkOrderStatuses.AddRange(
                new WorkOrderStatus { Id = 0, Name = "Open", Description = "The work order has been created and is awaiting assignment to a technician." },
                new WorkOrderStatus { Id = 1, Name = "Assigned", Description = "The work order has been assigned to a specific technician or crew for execution." },
                new WorkOrderStatus { Id = 2, Name = "In Progress", Description = "The technician or crew has started working on the terrain service and is actively completing the assigned tasks." },
                new WorkOrderStatus { Id = 3, Name = "On Hold", Description = "The work order is temporarily paused or delayed due to various reasons, such as awaiting additional equipment, materials, or approvals." },
                new WorkOrderStatus { Id = 4, Name = "Waiting for Customer Response", Description = "The technician or crew has completed their tasks, but they are waiting for a response or feedback from the customer before closing the work order." },
                new WorkOrderStatus { Id = 5, Name = "Completed", Description = "The terrain service work order has been successfully finished, and all necessary tasks have been completed." },
                new WorkOrderStatus { Id = 6, Name = "Closed", Description = "The work order has been reviewed, verified, and officially closed. It signifies that the terrain service work has been satisfactorily completed and documented." },
                new WorkOrderStatus { Id = 7, Name = "Reopened", Description = "The work order was previously closed but has been reopened due to additional work or issues that need to be addressed." },
                new WorkOrderStatus { Id = 8, Name = "Cancelled", Description = "The work order has been cancelled before any work could be started or completed, often due to changes in requirements or priorities." },
                new WorkOrderStatus { Id = 9, Name = "In Review", Description = "The work order is currently under review by supervisors or managers to ensure compliance, quality, or other standards." }
            );

            await _context.SaveChangesAsync();
        }
    }
}
