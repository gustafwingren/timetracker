import { Routes } from '@angular/router';
import { MsalGuard, MsalRedirectComponent } from '@azure/msal-angular';
import { authGuard } from './core/guards/auth.guard';
import { redirectGuard } from './core/guards/redirect.guard';

export const AppRoutes: Routes = [
  {
    path: 'home',
    title: 'Home',
    canActivate: [authGuard, MsalGuard],
    data: { breadcrumb: 'Home' },
    loadComponent: () =>
      import('./home/pages/home/home.component').then(m => m.HomeComponent),
  },
  {
    path: 'customers',
    title: 'Customers',
    canActivate: [authGuard, MsalGuard],
    data: { breadcrumb: 'Customers' },
    loadChildren: () =>
      import('./customers/customers.routes').then(m => m.CustomerRoutes),
  },
  {
    path: 'track',
    title: 'Track',
    canActivate: [authGuard, MsalGuard],
    data: { breadcrumb: 'Track' },
    loadComponent: () =>
      import('./track/pages/track/track.component').then(m => m.TrackComponent),
  },
  {
    path: 'auth',
    component: MsalRedirectComponent,
  },
  {
    path: 'login',
    canActivate: [redirectGuard],
    loadComponent: () =>
      import('./login/login.component').then(m => m.LoginComponent),
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
];
