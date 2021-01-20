import {VuexOidcClientSettings} from "vuex-oidc";

export const oidcSettings:VuexOidcClientSettings = {
    authority: process.env.VUE_APP_API_URL,
    clientId: 'SpaPortofolioWebClient',
    redirectUri: `${process.env.VUE_APP_BASE_URL}/oidc-callback`,
    responseType: 'code',
    scope: 'openid profile IdentityServerApi Role',
    postLogoutRedirectUri: `${process.env.VUE_APP_BASE_URL}`,
    silentRedirectUri: `${process.env.VUE_APP_BASE_URL}/oidc-client-silent-renew.html`,
    automaticSilentRenew: true,
}