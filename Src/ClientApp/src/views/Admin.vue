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
    import EditProjectPage from "@/components/Admin/EditProjectPage.vue";
    
    @Component({
        name: 'Admin',
        components: {
            'home-page': AdminHomePage,
            'project-page': ProjectsPage,
            'edit-project': EditProjectPage
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
                    return 'edit-project';
                default:
                    return 'home-page';
            }
            
        }
    }
</script>

<style scoped>

</style>