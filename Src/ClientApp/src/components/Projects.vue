<template>
    <v-container fluid>
        <div class="text-center display-2 font-weight-bold" style="color: whitesmoke">Projecten</div>
        <v-row justify="center" class="ma-5">
            <v-col class="col-md-8">
                <v-row>
                    <v-divider dark class="ma-5"></v-divider>
                </v-row>
                <v-row justify="center">
                    <v-col v-for="project in loadedProjects" :key="project.title" :class="`col-lg-${project.displaySize === 0? '6' : '12'}`">
                        <DisplayProject :project="project" />
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'
    import {projectModel} from "@/common/types";
    import DisplayProject from "@/components/DisplayProject.vue";

    @Component({
        name: 'Projects',
        components: {
            DisplayProject
        }
    })
    export default class Projects extends Vue{
        get loadedProjects():Array<projectModel>{
            return this.$store.getters['projectsModule/loadedProjects']
        }
    }
</script>

<style scoped>
    .project-text{
        overflow-y: auto;
    }
    
    .project-feature-wraer{
        display: flex;
        flex-wrap: wrap;
        height: 40px;
    }
    
    .project-feature{
        color: grey;
    }
</style>