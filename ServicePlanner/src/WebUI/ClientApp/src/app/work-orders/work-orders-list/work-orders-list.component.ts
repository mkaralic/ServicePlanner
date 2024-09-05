import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WorkOrdersClient, WorkOrderBriefDto, IWorkOrderBriefDto, PaginatedListOfWorkOrderBriefDto } from 'src/app/web-api-client'; // Pretpostavljeni servis za radne naloge

@Component({
  selector: 'app-work-orders-list',
  templateUrl: './work-orders-list.component.html',
  styleUrls: ['./work-orders-list.component.css']
})
export class WorkOrdersListComponent implements OnInit {

  workOrders: IWorkOrderBriefDto[];
  totalItems = 0;
  currentPage = 1;
  itemsPerPage = 2;

  constructor(
    private workOrdersClient: WorkOrdersClient,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(queryParams => {
      this.currentPage = queryParams['page'] ? +queryParams['page'] : 1;
      this.loadWorkOrders();
    });

  }

  loadWorkOrders(): void {
    this.workOrdersClient.getWorkOrdersWithPagination("", this.currentPage, this.itemsPerPage).subscribe({
      next: (data: PaginatedListOfWorkOrderBriefDto) => {
        this.workOrders = data.items;
        this.totalItems = data.totalCount;
      },
      error: (error: any) => {
        console.error('Error loading work orders', error);
      }
    });
  }

  onPageChange(event: any): void {
    this.router.navigate(['/work-orders'], {queryParams: {page: event.page}});
  }

}
