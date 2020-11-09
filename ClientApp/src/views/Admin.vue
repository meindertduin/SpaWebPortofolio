<template>
    <v-container>
        <v-expand-transition>
            <Component v-bind:is="pageComponent" />
        </v-expand-transition>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import ProjectsPage from "@/components/Admin/ProjectsPage.vue";
    import AdminHomePage from "@/components/Admin/AdminHomePage.vue";
    import MessagePage from "@/components/Admin/MessagePage.vue"; 
    
    @Component({
        name: 'Admin',
        components: {
            'home-page': AdminHomePage,
            'project-page': ProjectsPage,
            'message-page': MessagePage
        }
    })
    export default class Admin extends Vue{
        get pageComponent():string{
            switch (this.$store.getters['adminModule/pageNumber']) {
                case 0:
                    return 'home-page'
                case 1:
                    return 'project-page';
                case 2:
                    return 'message-page';
                default:
                    return 'home-page';
            }
            
        }
    }
</script>

<style scoped>

</style>