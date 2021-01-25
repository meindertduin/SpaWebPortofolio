<template>
    <v-card color="secondary">
        <v-card-title class="white--text">
            <div class="display-2 align-center">Pas een project aan</div>
        </v-card-title>
        <v-card-text>
            <v-row>
                <div class="image-container" v-for="(image, index) in loadedImages" :key="index">
                    <v-card dark class="ma-3">
                        <v-img class="removable-image" height="100px" width="120px" :src="`data:image/png;base64,${image.image}`"></v-img>
                        <v-card-actions>
                            <v-row justify="center">
                                <v-btn text color="red" @click="handleDeleteImage(image.id)">Delete</v-btn>
                            </v-row>
                        </v-card-actions>
                    </v-card>
                </div>
            </v-row>
            <v-row>
                <v-col class="col-11 col-md-6">
                    <v-text-field dark outlined label="Project titel" v-model="loadedEditProject.title"
                                  :rules="[formRules.required]"></v-text-field>
                    <v-text-field dark outlined label="Github link" v-model="loadedEditProject.githubLink"></v-text-field>
                    <v-text-field dark outlined label="Demo link" v-model="loadedEditProject.demoLink"></v-text-field>

                    <v-file-input dark outlined label="screenshots" multiple counter accept=".png" v-model="newScreenShots"></v-file-input>
                </v-col>
                <v-col class="col-11 col-md-6 text-center">
                    <v-text-field dark outlined label="Features" v-model="featuresString" :rules="[formRules.required]"></v-text-field>
                    <v-select dark label="Display groote" outlined :items="displaySizes"  v-model="selectedDisplaySize"
                              :rules="[formRules.required]"></v-select>
                    <v-textarea dark outlined counter="2000" label="Beschrijving" v-model="loadedEditProject.description"
                                :rules="[formRules.required, formRules.counterMax2000]"></v-textarea>
                    <v-row justify="center">
                        <v-btn class="ma-3" color="red" outlined large @click="handleDeleteProject">verwijder</v-btn>
                        <v-btn class="ma-3" color="orange" outlined large @click="handleCancelProject">Annuleren</v-btn>
                        <v-btn class="ma-3" color="green" outlined large @click="handleProjectsEdit">Opslaan</v-btn>
                    </v-row>
                </v-col>
            </v-row>
        </v-card-text>
    </v-card>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import {formRules} from "@/common/objects";
    import axios from 'axios';
    import {projectImage, projectModel} from "@/common/types";

    @Component({
        name: 'ProjectsForm',
    })
    export default class ProjectsForm extends Vue{
        private loadedEditProject: projectModel | null = null
        
        private loadedImages : Array<projectImage> | undefined = [];

        private displaySizes = ["normaal", "groot"]
        private selectedDisplaySize = "";
        private newScreenShots:any = {};
        
        private featuresString = "";
        
        get formRules(){
            return formRules;
        }
        
        created(){
            this.loadedEditProject = this.$store.getters['adminModule/loadedEditProject'];
            this.loadedImages = this.loadedEditProject?.images;
            this.featuresString = this.loadedEditProject? this.loadedEditProject.features.join(','): "";

          console.log(this.featuresString);
            
            switch (this.loadedEditProject?.displaySize) {
                case 0:
                    this.selectedDisplaySize = 'normaal';
                    break;
                case 1:
                    this.selectedDisplaySize = 'groot';
                    break;
                default:
                    this.selectedDisplaySize = 'normaal';
                    break;
            }
        }

        handleDeleteImage(imageId: number){
            axios.delete(`api/projects/delete/projectImage/${imageId}`, {
              withCredentials: true,
              headers: {
                "Authorization": `Bearer ${this.$store.state.oidcStore.access_token}`
              }
            })
                .then((response) => {
                    if (this.loadedEditProject){
                        this.loadedImages = this.loadedImages?.filter(i => i.id !== imageId);
                    }
                })
                .catch((err) => console.log(err))
                .finally(() => this.$store.dispatch('projectsModule/loadProjects'));
        }

        handleDeleteProject(){
            axios.delete(`api/projects/delete/project/${this.loadedEditProject?.id}`, {
              withCredentials: true,
              headers: {
                "Authorization": `Bearer ${this.$store.state.oidcStore.access_token}`
              }
            });
            this.$store.commit('adminModule/SET_PAGE_NUMBER', 1);
            this.$store.dispatch('projectsModule/loadProjects');
        }
        
        handleCancelProject(){
            this.$store.commit('adminModule/SET_PAGE_NUMBER', 1);
        }

        handleProjectsEdit(){
            let screenShots:FormData = new FormData();
            let count:number = 0;
            for (let files in this.newScreenShots){
                screenShots.append('screenShots', this.newScreenShots[count]);
                count++;
            }
            
            let displaySize;

            switch (this.selectedDisplaySize) {
                case 'normaal':
                    displaySize = 0;
                    break;
                case 'groot':
                    displaySize = 1;
                    break;
                default:
                    displaySize = 0;
                    break;
            }

            const projectForm:any = {
                title: this.loadedEditProject?.title,
                displaySize: displaySize,
                features: this.featuresString.split(','),
                description: this.loadedEditProject?.description,
                githubLink: this.loadedEditProject?.githubLink,
                demoLink: this.loadedEditProject?.demoLink,
            };
            
            
            axios.put(`api/projects/edit/project/${this.loadedEditProject?.id}`, projectForm, {
              withCredentials: true,
              headers: {
                "Authorization": `Bearer ${this.$store.state.oidcStore.access_token}`
              }
            })
                .then((response) => {
                    if (response.status === 202){
                        if (Object.keys(this.newScreenShots).length > 0 && this.newScreenShots.constructor !== Object){
                            axios.post(`api/projects/upload/screenshot/${response.data.id}`, screenShots, {
                              withCredentials: true,
                                headers: {
                                    'Content-Type': 'multipart/form-data',
                                    "Authorization": `Bearer ${this.$store.state.oidcStore.access_token}`

                                }
                            }).then((response) => {
                                this.$store.dispatch('projectsModule/loadProjects').then(() => {
                                    this.$store.commit('adminModule/SET_PAGE_NUMBER', 1);
                                });
                            });
                        }
                        else{
                            this.$store.dispatch('projectsModule/loadProjects');
                            this.$store.dispatch('projectsModule/loadProjects').then(() => {
                                this.$store.commit('adminModule/SET_PAGE_NUMBER', 1);
                            });
                        }
                    }
                })
                .catch((err) => {
                    console.log(err);
                    this.$store.dispatch('projectsModule/loadProjects').then(() => {
                        this.$store.commit('adminModule/SET_PAGE_NUMBER', 1);
                    });
                })
        }
    }
</script>

<style scoped>
    .image-container{
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
    }
    
</style>