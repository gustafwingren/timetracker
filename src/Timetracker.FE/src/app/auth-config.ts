import { BrowserCacheLocation, Configuration } from '@azure/msal-browser';

const isIE =
  window.navigator.userAgent.indexOf('MSIE ') > -1 ||
  window.navigator.userAgent.indexOf('Trident/') > -1;

/**
 * Configuration object to be passed to MSAL instance on creation.
 * For a full list of MSAL.js configuration parameters, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/configuration.md
 */
export const msalConfiguration: Configuration = {
  auth: {
    clientId: 'a7c9672e-5357-494a-ba92-88f28cda925e',
    authority:
      'https://login.microsoftonline.com/02b6749b-5ce0-4853-bd5c-a05f9bd9dd3a',
    redirectUri: '/auth',
    postLogoutRedirectUri: '/',
    clientCapabilities: ['CP1'],
  },
  cache: {
    cacheLocation: BrowserCacheLocation.SessionStorage,
    storeAuthStateInCookie: isIE,
  },
  system: {},
};

/**
 * Add here the endpoints and scopes when obtaining an access token for protected web APIs. For more information, see:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/resources-and-scopes.md
 */
export const protectedResources = {
  apiCustomers: {
    endpoint: 'https://localhost:7160/customers/',
    scopes: {
      read: ['api://a7c9672e-5357-494a-ba92-88f28cda925e/Customers.Read'],
      write: ['api://a7c9672e-5357-494a-ba92-88f28cda925e/Customers.ReadWrite'],
    },
  },
};

/**
 * Scopes you add here will be prompted for user consent during sign-in.
 * By default, MSAL.js will add OIDC scopes (openid, profile, email) to any login request.
 * For more information about OIDC scopes, visit:
 * https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent#openid-connect-scopes
 */
export const loginRequest = {
  scopes: [],
};
