import Vue from 'vue';
import Vuex from 'vuex';
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

export const store = new Vuex.Store({
    plugins: [createPersistedState()],
    state: {
        isLoggedIn: !!localStorage.getItem('token'),
        userId: 'unknown'
    },
    mutations: {
        login(state, id) {
            state.isLoggedIn = true;
            state.userId = id;
        },
        logout(state) {
            state.isLoggedIn = false;
            state.userId = 'unknown';
        }
    },
    actions: {
        logout({ commit }) {
            localStorage.removeItem('token');
            commit('logout');
        }
    },
    getters: {
        isLoggedIn: state => state.isLoggedIn,
        userId: state => state.userId
    }
})