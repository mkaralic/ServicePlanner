﻿using AutoMapper;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.Employees.Queries.GetEmployeesWithPagination;
public class EmployeeBriefDto : IMapFrom<Employee>
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public void Mapping(Profile profile)
    {
        var c = profile.CreateMap<Employee, EmployeeBriefDto>()
            //.ForMember(d => d.RegistrationDate, opt => opt.Ignore())
            //.ForMember(d => d.Title, opt => opt.NullSubstitute("N/A"))
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
    }
}
