import { Component, OnInit } from '@angular/core';
// import { EmployeeService } from '../employee.service';

import { ActivatedRoute, Router } from '@angular/router';
import { CustomerBriefDto, CustomersClient, ICustomerBriefDto, PaginatedListOfCustomerBriefDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: ICustomerBriefDto[] = [{ id: 1, fullName: "Milorad Karalic" }];
  totalItems = 0;
  currentPage = 1;
  itemsPerPage = 2;

  constructor(
    private customersClient: CustomersClient,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(queryParams => {
      this.currentPage = queryParams['page'] ? +queryParams['page'] : 1;
      this.loadCustomers();
    });

  }

  loadCustomers(): void {
    this.customersClient.getCustomersWithPagination("", this.currentPage, this.itemsPerPage).subscribe({
      next: (data: PaginatedListOfCustomerBriefDto) => {
        this.customers = data.items;
        this.totalItems = data.totalCount;
      },
      error: (error: any) => {
        console.error('Error loading customers', error);
      }
    });
  }

  onPageChange(event: any): void {
    this.router.navigate(['/customers'], {queryParams: {page: event.page}});
  }
}
