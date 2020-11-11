import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import Admin from "@/views/Admin.vue";
import OidcCallback from "@/views/OidcCallback.vue";
import OidcCallbackError from "@/views/OidcCallbackError.vue";

import store from '@/store'
import {vuexOidcCreateRouterMiddleware} from "vuex-oidc";

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    meta: {
      layout: 'default-layout',
      isPublic: true,
    }
  },
  {
    path: '/admin',
    name: 'Admin',
    component: Admin,
    meta: {
      layout: 'admin-layout',
      isPublic: false,
    }
  },
  {
    path: '/oidc-callback',
    name: 'OidcCallback',
    component: OidcCallback,
    meta: {
      isPublic: true,
    }
  },
  {
    path: '/signin-oidc-error',
    name: 'oidcCallbackError',
    component: OidcCallbackError,
    meta: {
      isPublic: true,
    }
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})
router.beforeEach(vuexOidcCreateRouterMiddleware(store, 'oidcStore'))

export default router
