using AutoMapper;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;
public class WorkOrderBriefDto : IMapFrom<WorkOrder>
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string Customer { get; set; }
    public string ServiceDescription { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; }

    public void Mapping(Profile profile)
    {
        var c = profile.CreateMap<WorkOrder, WorkOrderBriefDto>()
            //.ForMember(d => d.RegistrationDate, opt => opt.Ignore())
            //.ForMember(d => d.Title, opt => opt.NullSubstitute("N/A"))
            .ForMember(d => d.Customer, opt => opt.MapFrom(s => s.Customer.FirstName + " " + s.Customer.LastName))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.WorkOrderStatus.Name));

    }
}
