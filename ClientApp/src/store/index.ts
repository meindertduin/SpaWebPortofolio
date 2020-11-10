import Vue from 'vue'
import Vuex from 'vuex'
import AdminModule from "@/store/adminModule";
import ProjectsModule from "@/store/projectsModule";

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
        projectsModule: ProjectsModule,
    }
})