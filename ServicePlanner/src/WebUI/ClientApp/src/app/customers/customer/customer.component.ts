import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomersClient, EmployeesClient, IEmployeeBriefDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customerForm: FormGroup;
  customerId: number;
  isEditMode: boolean;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private customersClient: CustomersClient
  ) {
    this.customerForm = this.fb.group({
      id: [''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phone: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      notes: ['']
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.customerId = +params['id'];
      this.customerForm['id'] = this.customerId;
      this.isEditMode = !!this.customerId;
      if (this.isEditMode) {
        this.loadEmployee();
      }
    });
  }

  loadEmployee(): void {
    this.customersClient.getCustomer(this.customerId).subscribe(customer => {
      this.customerForm.patchValue(customer);
    });
  }

  onSubmit(): void {
    if (this.customerForm.valid) {
      if (this.isEditMode) {
        this.customersClient.updateCustomer(this.customerId, this.customerForm.value).subscribe(() => {
          this.router.navigate(['/customers']);
        });
      } else {
        this.customersClient.createCustomer(this.customerForm.value).subscribe(() => {
          this.router.navigate(['/customers']);
        });
      }
    }
  }

}
