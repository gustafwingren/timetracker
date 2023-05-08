import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './pages/customers/customers.component';
import { MsalGuard } from '@azure/msal-angular';
import { CustomerDetailComponent } from './pages/customer-detail/customer-detail.component';
import { CustomerNewComponent } from './pages/customer-new/customer-new.component';
import { customerDetailResolver } from './pages/customer-detail/customer-detail.resolver';
import { ActivityDetailComponent } from './pages/activity-detail/activity-detail.component';
import { activityDetailResolver } from './pages/activity-detail/activity-detail.resolver';
import { ActivityNewComponent } from './pages/activity-new/activity-new.component';

const customersRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    title: 'Customers',
    component: CustomersComponent,
    data: { breadcrumb: 'Customers' },
  },
  {
    path: 'new',
    title: 'New Customer',
    component: CustomerNewComponent,
    canActivate: [MsalGuard],
    data: { breadcrumb: 'New' },
  },
  {
    path: ':id/edit',
    title: 'Edit Customer',
    component: CustomerDetailComponent,
    canActivate: [MsalGuard],
    data: { breadcrumb: 'Edit' },
    resolve: {
      customer: customerDetailResolver,
    },
  },
  {
    path: ':id/activity/new',
    title: 'New Activity',
    component: ActivityNewComponent,
    canActivate: [MsalGuard],
    data: { breadcrumb: 'New' },
  },
  {
    path: ':id/activity/:activityId/edit',
    title: 'Edit Activity',
    component: ActivityDetailComponent,
    canActivate: [MsalGuard],
    data: { breadcrumb: 'Edit' },
    resolve: {
      activity: activityDetailResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(customersRoutes)],
  exports: [RouterModule],
})
export class CustomersRoutingModule {}
