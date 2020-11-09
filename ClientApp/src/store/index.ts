import Vue from 'vue'
import Vuex from 'vuex'
import AdminModule from "@/store/adminModule";

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    adminModule: AdminModule,
  }
})
