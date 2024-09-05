import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { 
  WorkOrdersClient, WorkOrder, 
  EmployeesClient, EmployeeBriefDto, IEmployeeBriefDto, 
  CustomersClient, CustomerBriefDto, ICustomerBriefDto,
  WorkOrderStatusesClient, WorkOrderStatus
} from 'src/app/web-api-client'; // Pretpostavljeni servis za radne naloge

@Component({
  selector: 'app-work-order',
  templateUrl: './work-order.component.html',
  styleUrls: ['./work-order.component.css']
})
export class WorkOrderComponent implements OnInit {
  workOrderForm: FormGroup;
  workOrderId: number | null = null;
  workOrderStatuses: any[] = [];
  customers: any[] = [];
  employees: any[] = [];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private workOrdersClient: WorkOrdersClient,
    private employeesClient: EmployeesClient,
    private customersClient: CustomersClient,
    private workOrderStatusesClient: WorkOrderStatusesClient,
  ) { 
    this.workOrderForm = this.fb.group({
      id: [''],
      serviceDescription: ['', [Validators.required, Validators.maxLength(250)]],
      total: [null, [Validators.required, Validators.min(0)]],
      workOrderStatusId: [null, Validators.required],
      customerId: [null, Validators.required],
      employeeId: [null, Validators.required],
      notes: ['']
    });

  }

  ngOnInit(): void {
       // Load lookup data
       this.loadLookupData();

       // Check if we are editing an existing work order
       this.workOrderId = this.route.snapshot.params['id'];
       if (this.workOrderId) {
         this.loadWorkOrder();
       }
   
  }

  loadLookupData(): void {
    this.workOrderStatusesClient.getWorkOrderStatuses("").subscribe(data => this.workOrderStatuses = data);
    this.customersClient.getCustomersWithPagination("", 1, 999).subscribe(data => this.customers = data.items);
    this.employeesClient.getEmployeesWithPagination("", 1, 999).subscribe(data => this.employees = data.items);
  }

  loadWorkOrder(): void {
    this.workOrdersClient.getWorkOrder(this.workOrderId).subscribe(workOrder => {
      this.workOrderForm.patchValue(workOrder);
    });
  }

  saveWorkOrder(): void {
    if (this.workOrderForm.valid) {
      if (this.workOrderId) {
        this.workOrdersClient.updateWorkOrder(this.workOrderId, this.workOrderForm.value).subscribe(() => {
          this.router.navigate(['/work-orders']);
        });
      } else {
        this.workOrdersClient.createWorkOrder(this.workOrderForm.value).subscribe(() => {
          this.router.navigate(['/work-orders']);
        });
      }
    }
  }
}
