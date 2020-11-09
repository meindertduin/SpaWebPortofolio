<template>
    <v-row justify="center">
        <v-col class="col-md-11 col-lg-8 col-12">
            <ProjectsForm />
            <AdminProjectsDisplay />
        </v-col>
    </v-row>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import ProjectsForm from "@/components/Admin/ProjectsForm.vue";
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