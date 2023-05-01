import { Component, OnDestroy, OnInit } from '@angular/core';
import { ButtonColor } from '../shared/button/button-color';
import { AuthService } from '../core/services/auth.service';
import { MsalBroadcastService } from '@azure/msal-angular';
import { filter, Subject, takeUntil } from 'rxjs';
import { InteractionStatus } from '@azure/msal-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {
  protected readonly ButtonColor = ButtonColor;
  private readonly _destroying$ = new Subject<void>();

  loading = false;

  constructor(
    private authService: AuthService,
    private msalBroadcastService: MsalBroadcastService,
    private router: Router
  ) {}

  ngOnInit() {
    this.msalBroadcastService.inProgress$
      .pipe(
        filter((status: InteractionStatus) => status === InteractionStatus.None)
      )
      .subscribe(async () => {
        if (this.authService.isLoggedIn()) {
          await this.router.navigate(['/home']);
        }
      });
  }

  ngOnDestroy() {
    this._destroying$.next(undefined);
    this._destroying$.complete();
  }

  login(): void {
    this.loading = true;
    this.authService.login();
  }
}
