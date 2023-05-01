import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { MsalService } from '@azure/msal-angular';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  profileMenuOpen = false;

  @ViewChild('toggleButton') toggleButton!: ElementRef;
  @ViewChild('profileMenu') profileMenu!: ElementRef;

  constructor(private renderer: Renderer2, private authService: MsalService) {
    this.renderer.listen('window', 'click', (e: Event) => {
      if (
        !this.toggleButton.nativeElement.contains(e.target) &&
        !this.profileMenu.nativeElement.contains(e.target)
      ) {
        this.profileMenuOpen = false;
      }
    });
  }

  toggleProfileMenu() {
    this.profileMenuOpen = !this.profileMenuOpen;
  }

  logout() {
    const activeAccount =
      this.authService.instance.getActiveAccount() ||
      this.authService.instance.getAllAccounts()[0];

    this.authService.logoutRedirect({
      account: activeAccount,
    });
  }
}
