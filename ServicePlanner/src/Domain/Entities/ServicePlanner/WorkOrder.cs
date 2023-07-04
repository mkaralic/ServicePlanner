﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("WorkOrders", Schema = "ServicePlanner")]
public class WorkOrder : BaseAuditableEntity
{
    public int WorkOrderStatusId { get; set; }
    public WorkOrderStatus WorkOrderStatus { get; set; }
    public IEnumerable<WorkOrderStatusHistory> WorkOrderStatusHistoryItems { get; set; } = new List<WorkOrderStatusHistory>();
    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int? EmployeeId { get; set; }
    public Employee Employee { get; set; }

    [MaxLength(50)]
    public string ServiceDescription { get; set; }

    [Column(TypeName = "decimal(18, 2)")] 
    public decimal Total { get; set; }

    [Column(TypeName = "Text")]
    public string? Notes { get; set; }

}
