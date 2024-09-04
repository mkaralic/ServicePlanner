import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesClient, IEmployeeBriefDto } from 'src/app/web-api-client';
@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  employeeForm: FormGroup;
  employeeId: number;
  isEditMode: boolean;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private employeesClient: EmployeesClient
  ) {
    this.employeeForm = this.fb.group({
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
      this.employeeId = +params['id'];
      this.employeeForm['id'] = this.employeeId;
      this.isEditMode = !!this.employeeId;
      if (this.isEditMode) {
        this.loadEmployee();
      }
    });
  }

  loadEmployee(): void {
    this.employeesClient.getEmployee(this.employeeId).subscribe(employee => {
      this.employeeForm.patchValue(employee);
    });
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      if (this.isEditMode) {
        this.employeesClient.updateEmployee(this.employeeId, this.employeeForm.value).subscribe(() => {
          this.router.navigate(['/employees']);
        });
      } else {
        this.employeesClient.createEmployee(this.employeeForm.value).subscribe(() => {
          this.router.navigate(['/employees']);
        });
      }
    }
  }
}