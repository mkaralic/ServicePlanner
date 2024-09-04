import { Component, OnInit } from '@angular/core';
// import { EmployeeService } from '../employee.service';

import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeBriefDto, EmployeesClient, IEmployeeBriefDto, PaginatedListOfCustomerBriefDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  employees: IEmployeeBriefDto[] = [{ id: 1, fullName: "Milorad Karalic" }];
  totalItems = 0;
  currentPage = 1;
  itemsPerPage = 2;

  constructor(
    private employeesClient: EmployeesClient,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(queryParams => {
      this.currentPage = queryParams['page'] ? +queryParams['page'] : 1;
      this.loadEmployees();
    });

  }

  loadEmployees(): void {
    this.employeesClient.getEmployeesWithPagination("", this.currentPage, this.itemsPerPage).subscribe({
      next: (data: PaginatedListOfCustomerBriefDto) => {
        this.employees = data.items;
        this.totalItems = data.totalCount;
      },
      error: (error: any) => {
        console.error('Error loading employees', error);
      }
    });
  }

  onPageChange(event: any): void {
    this.router.navigate(['/employees'], {queryParams: {page: event.page}});
  }
}
