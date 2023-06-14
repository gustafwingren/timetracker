import {
  MsalGuardConfiguration,
  MsalInterceptorConfiguration,
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
  protectedResourceMap.set(protectedResources.apiUsers.endpoint, [
    {
      httpMethod: 'GET',
      scopes: [...protectedResources.apiUsers.scopes.userread],
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
