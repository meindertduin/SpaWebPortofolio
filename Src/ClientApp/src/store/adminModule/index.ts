import { GetterTree, MutationTree, ActionTree } from "vuex"
import {projectModel} from "@/common/types";

class State {
    public pageNumber : number = 0;
    public projectsEditOverlay: boolean = false;
    public loadedEditProject : projectModel | null = null
}

const getters = <GetterTree<State, any>>{
    pageNumber: state => state.pageNumber,
    projectsEditOverlay: state => state.projectsEditOverlay,
    loadedEditProject: state => state.loadedEditProject,
}

const mutations = <MutationTree<State>>{
    SET_PAGE_NUMBER: (state, num:number) => state.pageNumber = num,
    TOGGLE_PROJECTS_EDIT_OVERLAY: state => state.projectsEditOverlay = ! state.projectsEditOverlay,
    SET_LOADED_EDIT_PROJECT: (state, project: projectModel) => state.loadedEditProject = project,
}

const actions = <ActionTree<State, any>>{
    
}

const AdminModule = {
    namespaced: true,
    state: new State(),
    mutations: mutations,
    getters: getters,
    actions: actions
}

export default AdminModule;