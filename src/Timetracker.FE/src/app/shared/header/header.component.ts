import {
  Component,
  ElementRef,
  OnInit,
  Renderer2,
  ViewChild,
} from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { AuthService } from '../../core/services/auth.service';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { UserInfoDto } from '../../core/models/user-info-dto';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  profileMenuOpen = false;

  @ViewChild('toggleButton') toggleButton!: ElementRef;
  @ViewChild('profileMenu') profileMenu!: ElementRef;

  userInfo$: Subject<UserInfoDto> = new Subject<UserInfoDto>();

  constructor(private renderer: Renderer2, private authService: AuthService) {
    this.renderer.listen('window', 'click', (e: Event) => {
      if (
        !this.toggleButton.nativeElement.contains(e.target) &&
        !this.profileMenu.nativeElement.contains(e.target)
      ) {
        this.profileMenuOpen = false;
      }
    });
  }

  ngOnInit() {
    this.getUserInfo();
  }

  toggleProfileMenu() {
    this.profileMenuOpen = !this.profileMenuOpen;
  }

  logout() {
    this.authService.logout();
  }

  getUserInfo() {
    this.authService.getUserInfo().subscribe(data => {
      this.userInfo$.next(data);
    });
  }
}
