import { MsalGuard } from '@azure/msal-angular';
import { customerDetailResolver } from './pages/customer-detail/customer-detail.resolver';
import { activityDetailResolver } from './pages/activity-detail/activity-detail.resolver';
import { Routes } from '@angular/router';

export const CustomerRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    title: 'Customers',
    data: { breadcrumb: 'Customers' },
    loadComponent: () =>
      import('./pages/customers/customers.component').then(
        m => m.CustomersComponent
      ),
    z,
  },
  {
    path: 'new',
    title: 'New Customer',
    canActivate: [MsalGuard],
    data: { breadcrumb: 'New' },
    loadComponent: () =>
      import('./pages/customer-new/customer-new.component').then(
        m => m.CustomerNewComponent
      ),
  },
  {
    path: ':id/edit',
    title: 'Edit Customer',
    canActivate: [MsalGuard],
    data: { breadcrumb: 'Edit' },
    resolve: {
      customer: customerDetailResolver,
    },
    loadComponent: () =>
      import('./pages/customer-detail/customer-detail.component').then(
        m => m.CustomerDetailComponent
      ),
  },
  {
    path: ':id/activity/new',
    title: 'New Activity',
    canActivate: [MsalGuard],
    data: { breadcrumb: 'New' },
    loadComponent: () =>
      import('./pages/activity-new/activity-new.component').then(
        m => m.ActivityNewComponent
      ),
  },
  {
    path: ':id/activity/:activityId/edit',
    title: 'Edit Activity',
    canActivate: [MsalGuard],
    data: { breadcrumb: 'Edit' },
    resolve: {
      activity: activityDetailResolver,
    },
    loadComponent: () =>
      import('./pages/activity-detail/activity-detail.component').then(
        m => m.ActivityDetailComponent
      ),
  },
];
