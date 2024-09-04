import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../api-authorization/authorize.guard';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TodoComponent } from './todo/todo.component';
import { TokenComponent } from './token/token.component';
import { EmployeesComponent } from './employees/employees/employees.component';
import { CustomersComponent } from './customers/customers/customers.component';
import { WorkOrdersComponent } from './work-orders/work-orders/work-orders.component';
import { EmployeeEditComponent } from './employees/employee-edit/employee-edit.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'todo', component: TodoComponent, canActivate: [AuthorizeGuard] },
  { path: 'employees', component: EmployeesComponent, canActivate: [AuthorizeGuard] },
  { path: 'employees/edit/:id', component: EmployeeEditComponent },
  { path: 'employees/add', component: EmployeeEditComponent },
  { path: 'customers', component: CustomersComponent, canActivate: [AuthorizeGuard] },
  { path: 'work-orders', component: WorkOrdersComponent, canActivate: [AuthorizeGuard] },
  { path: 'token', component: TokenComponent, canActivate: [AuthorizeGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
