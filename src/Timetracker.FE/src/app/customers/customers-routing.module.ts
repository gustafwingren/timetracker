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
    component: CustomersComponent,
  },
  {
    path: 'new',
    component: CustomerNewComponent,
    canActivate: [MsalGuard],
  },
  {
    path: ':id/edit',
    component: CustomerDetailComponent,
    canActivate: [MsalGuard],
    resolve: {
      customer: customerDetailResolver,
    },
  },
  {
    path: ':id/activity/new',
    component: ActivityNewComponent,
    canActivate: [MsalGuard],
  },
  {
    path: ':id/activity/:activityId/edit',
    component: ActivityDetailComponent,
    canActivate: [MsalGuard],
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
