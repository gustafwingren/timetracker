import { Inject, Injectable } from '@angular/core';
import {
  MSAL_GUARD_CONFIG,
  MsalBroadcastService,
  MsalGuardConfiguration,
  MsalService,
} from '@azure/msal-angular';
import { Router } from '@angular/router';
import { RedirectRequest } from '@azure/msal-browser';
import { Observable } from 'rxjs';
import { UserInfoDto } from '../models/user-info-dto';
import { ApiService } from './api.service';
import { protectedResources } from '../../auth-config';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url = protectedResources.apiUsers.endpoint;

  constructor(
    private msalService: MsalService,
    private router: Router,
    private msalBroadcastService: MsalBroadcastService,
    private apiService: ApiService,
    @Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration
  ) {}

  isLoggedIn(): boolean {
    return this.msalService.instance.getAllAccounts().length > 0;
  }

  login(): void {
    if (this.msalGuardConfig.authRequest) {
      this.msalService.loginRedirect({
        ...this.msalGuardConfig.authRequest,
      } as RedirectRequest);
    } else {
      this.msalService.loginRedirect();
    }
  }

  logout(): void {
    const activeAccount =
      this.msalService.instance.getActiveAccount() ||
      this.msalService.instance.getAllAccounts()[0];

    this.msalService.logoutRedirect({
      account: activeAccount,
    });
  }

  getUserInfo(): Observable<UserInfoDto> {
    return this.apiService.get(this.url + 'me');
  }
}
