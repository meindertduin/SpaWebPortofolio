import {VuexOidcClientSettings} from "vuex-oidc";

export const oidcSettings:VuexOidcClientSettings = {
    authority: `${process.env.VUE_APP_API_URL}`,
    client_secret: process.env.VUE_APP_CLIENT_SECRET,
    clientId: 'SpaPortofolioWebClient',
    redirectUri: `${process.env.VUE_APP_API_URL}/oidc-callback`,
    responseType: 'code',
    scope: 'openid profile IdentityServerApi Role',
    postLogoutRedirectUri: `${process.env.VUE_APP_API_URL}`,
    silentRedirectUri: `${process.env.VUE_APP_API_URL}/oidc-client-silent-renew.html`,
    automaticSilentRenew: true,
}