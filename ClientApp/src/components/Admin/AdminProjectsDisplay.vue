<template>
    <div>
        <v-row>
            <v-col v-for="project in loadedProjects" :key="project.title" :class="`col-lg-${project.displaySize === 0? '6' : '12'}`">
                <AdminProject :project="project" />
            </v-col>
        </v-row>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import axios from 'axios';
    import {projectModel} from "@/common/types";
    import AdminProject from "@/components/Admin/AdminProject.vue";
    import EditProject from "@/components/Admin/EditProject.vue";

    @Component({
        name: 'AdminProjectsDisplay',
        components: {
            AdminProject,
            EditProject,
        }
    })
    export default class AdminProjectsDisplay extends Vue{
        get loadedProjects():Array<projectModel>{
            return this.$store.getters['projectsModule/loadedProjects'];
        }
        
        get projectsEditOverlay(){
            return this.$store.getters['adminModule/projectsEditOverlay'];    
        }
        
        created(){
            if (this.loadedProjects.length <= 0){
                this.$store.dispatch('projectsModule/loadProjects');
            }
        }
    }
</script>

<style scoped>
    .project-text{
        overflow-y: auto;
    }

    .project-feature-wrapper{
        display: flex;
        flex-wrap: wrap;
        height: 40px;
    }

    .project-feature{
        color: grey;
    }
</style>