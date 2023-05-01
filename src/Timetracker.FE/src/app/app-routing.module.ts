import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/pages/customers/customers.component';
import { HomeComponent } from './home/pages/home/home.component';
import { TrackComponent } from './track/pages/track/track.component';
import { RedirectHandler } from '@azure/msal-browser/dist/interaction_handler/RedirectHandler';
import { MsalGuard, MsalRedirectComponent } from '@azure/msal-angular';
import { authGuard } from './core/guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { redirectGuard } from './core/guards/redirect.guard';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [authGuard, MsalGuard],
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'customers',
    canActivate: [authGuard, MsalGuard],
    loadChildren: () =>
      import('./customers/customers.module').then(m => m.CustomersModule),
  },
  {
    path: 'track',
    component: TrackComponent,
    canActivate: [authGuard, MsalGuard],
    loadChildren: () => import('./track/track.module').then(m => m.TrackModule),
  },
  {
    path: 'auth',
    component: MsalRedirectComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [redirectGuard],
    loadChildren: () => import('./login/login.module').then(m => m.LoginModule),
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
