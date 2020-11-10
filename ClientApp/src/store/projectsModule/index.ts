import { GetterTree, MutationTree, ActionTree } from "vuex"
import {projectModel} from "@/common/types";
import axios from 'axios';

class State {
  public loadedProjects: Array<projectModel> = [];
}

const getters = <GetterTree<State, any>>{
  loadedProjects: state => state.loadedProjects,
}

const mutations = <MutationTree<State>>{
  SET_LOADED_PROJECTS: (state, projects: Array<projectModel>) => state.loadedProjects = projects,
}

const actions = <ActionTree<State, any>>{
  loadProjects({commit}):void{
    axios.get('api/projects')
        .then((response) => {
          commit('SET_LOADED_PROJECTS', response.data);
        })
        .catch((err) => console.log(err));
  },
}

const ProjectsModule = {
  namespaced: true,
  state: new State(),
  mutations: mutations,
  getters: getters,
  actions: actions
}

export default ProjectsModule;