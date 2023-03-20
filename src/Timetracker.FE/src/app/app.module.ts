import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import {
  MSAL_GUARD_CONFIG,
  MSAL_INSTANCE,
  MSAL_INTERCEPTOR_CONFIG,
  MsalGuardConfiguration,
  MsalInterceptor,
  MsalInterceptorConfiguration,
  MsalModule,
  MsalRedirectComponent,
  MsalService,
  ProtectedResourceScopes,
} from '@azure/msal-angular';
import {
  InteractionType,
  IPublicClientApplication,
  PublicClientApplication,
} from '@azure/msal-browser';
import {
  loginRequest,
  msalConfiguration,
  protectedResources,
} from './auth-config';
import { ApiService } from './core/services/api.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

export function MSALInstanceFactory(): IPublicClientApplication {
  return new PublicClientApplication(msalConfiguration);
}

/**
 * MSAL Angular will automatically retrieve tokens for resources
 * added to protectedResourceMap. For more info, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-angular/docs/v2-docs/initialization.md#get-tokens-for-web-api-calls
 */
export function MSALInterceptorConfigFactory(): MsalInterceptorConfiguration {
  const protectedResourceMap = new Map<
    string,
    Array<string | ProtectedResourceScopes> | null
  >();

  protectedResourceMap.set(protectedResources.apiCustomers.endpoint, [
    {
      httpMethod: 'GET',
      scopes: [...protectedResources.apiCustomers.scopes.read],
    },
    {
      httpMethod: 'POST',
      scopes: [...protectedResources.apiCustomers.scopes.write],
    },
    {
      httpMethod: 'PUT',
      scopes: [...protectedResources.apiCustomers.scopes.write],
    },
    {
      httpMethod: 'DELETE',
      scopes: [...protectedResources.apiCustomers.scopes.write],
    },
  ]);

  return {
    interactionType: InteractionType.Popup,
    protectedResourceMap,
  };
}

/**
 * Set your default interaction type for MSALGuard here. If you have any
 * additional scopes you want the user to consent upon login, add them here as well.
 */
export function MSALGuardConfigFactory(): MsalGuardConfiguration {
  return {
    interactionType: InteractionType.Redirect,
    authRequest: loginRequest,
  };
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    MsalModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true,
    },
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory,
    },
    {
      provide: MSAL_GUARD_CONFIG,
      useFactory: MSALGuardConfigFactory,
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: MSALInterceptorConfigFactory,
    },
    MsalService,
    ApiService,
  ],
  bootstrap: [AppComponent, MsalRedirectComponent],
})
export class AppModule {}
