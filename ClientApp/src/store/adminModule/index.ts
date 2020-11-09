import { GetterTree, MutationTree, ActionTree } from "vuex"

class State {
    public pageNumber : number = 0;
}

const getters = <GetterTree<State, any>>{
    pageNumber: state => state.pageNumber,
}

const mutations = <MutationTree<State>>{
    SET_PAGE_NUMBER: (state, num:number) => state.pageNumber = num,
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