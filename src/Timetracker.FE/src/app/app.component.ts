import { Component, inject } from '@angular/core';
import { AuthService } from './core/services/auth.service';
import { RouterOutlet } from '@angular/router';
import { NgIf } from '@angular/common';
import { SideMenuComponent } from './shared/side-menu/side-menu.component';
import { HeaderComponent } from './shared/header/header.component';
import { PageTitleComponent } from './shared/page-title/page-title.component';
import { BreadcrumbsComponent } from './shared/breadcrumbs/breadcrumbs.component';
import { MsalRedirectComponent, MsalService } from '@azure/msal-angular';
import { ModalComponent } from './shared/modal/modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    RouterOutlet,
    SideMenuComponent,
    HeaderComponent,
    PageTitleComponent,
    BreadcrumbsComponent,
    ModalComponent,
  ],
})
export class AppComponent extends MsalRedirectComponent {
  title = 'Timetracker.FE';

  constructor(private myAuthService: AuthService) {
    super(inject(MsalService));
  }

  isLoggedIn(): boolean {
    return this.myAuthService.isLoggedIn();
  }
}
