<template>
    <v-row justify="center">
        <v-col cols="8">
            <ProjectsForm />
            <AdminProjectsDisplay />
        </v-col>
    </v-row>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import ProjectsForm from "./ProjectsForm";
    import AdminProjectsDisplay from "./AdminProjectsDisplay";

    @Component({
        name: 'ProjectsPage',
        components: {
            ProjectsForm,
            AdminProjectsDisplay,
        }
    })
    export default class ProjectsPage extends Vue{
        
    }
</script>

<style scoped>

</style>