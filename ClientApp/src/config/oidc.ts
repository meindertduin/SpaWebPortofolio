import {VuexOidcClientSettings} from "vuex-oidc";

export const oidcSettings:VuexOidcClientSettings = {
    authority: 'https://localhotst:5001',
    clientId: 'SpaPortofolioWebClient',
    redirectUri: 'https://localhost:5001/oidc-callback',
    responseType: 'code',
    scope: 'openid profile IdentityServerApi Role',
    postLogoutRedirectUri: 'https://localhost:5001',
    silentRedirectUri: "https://localhost:5001/oidc-client-silent-renew.html",
    automaticSilentRenew: true,
}