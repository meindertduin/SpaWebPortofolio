import {VuexOidcClientSettings} from "vuex-oidc";

export const oidcSettings:VuexOidcClientSettings = {
    authority: 'https://localhost:5001',
    client_secret: process.env.VUE_APP_CLIENT_SECRET,
    clientId: 'SpaPortofolioWebClient',
    redirectUri: 'https://localhost:5001/oidc-callback',
    responseType: 'code',
    scope: 'openid profile IdentityServerApi Role',
    postLogoutRedirectUri: 'https://localhost:5001',
    silentRedirectUri: "https://localhost:5001/oidc-client-silent-renew.html",
    automaticSilentRenew: true,
}