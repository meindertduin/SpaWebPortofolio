<template>
    <v-row justify="center">
        <v-col class="col-lg-8 col-md-10 col-sm-11 col-12">
            <v-card color="secondary" max-width="100%">
                <v-img class="text--white" src="laptop.jpg" max-height="200px">
                    <v-card-title class="white--text">
                        <div class="display-2 align-center">Voeg een project toe</div>
                    </v-card-title>
                </v-img>
                <v-card-text>
                    <v-row>
                        <v-col cols="6">
                            <v-text-field dark outlined label="Project titel" v-model="loadedEditProject.title"
                                          :rules="[formRules.required]"></v-text-field>
                            <v-text-field dark outlined label="Github link" v-model="loadedEditProject.githubLink"></v-text-field>
                            <v-text-field dark outlined label="Demo link" v-model="loadedEditProject.demoLink"></v-text-field>

                            <!--                    <v-file-input dark outlined label="screenshots" multiple counter accept=".png" v-model="screenShots"></v-file-input>-->
                        </v-col>
                        <v-col cols="6" class="text-center">
                            <v-text-field dark outlined label="Features" v-model="loadedEditProject.features" :rules="[formRules.required]"></v-text-field>
                            <v-select dark label="Display groote" outlined :items="displaySizes"  v-model="selectedDisplaySize"
                                      :rules="[formRules.required]"></v-select>
                            <v-textarea dark outlined counter="2000" label="Beschrijving" v-model="loadedEditProject.description"
                                        :rules="[formRules.required, formRules.counterMax2000]"></v-textarea>
                            <v-btn dark outlined large @click="handleProjectsEdit">Versturen</v-btn>
                        </v-col>
                    </v-row>
                </v-card-text>
            </v-card>
        </v-col>
    </v-row>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import {formRules} from "@/common/objects";
    import axios from 'axios';
    import {projectModel} from "@/common/types";

    @Component({
        name: 'ProjectsForm',
    })
    export default class ProjectsForm extends Vue{
        private loadedEditProject: projectModel | null = null

        private displaySizes = ["normaal", "groot"]
        private selectedDisplaySize = "";
        
        get formRules(){
            return formRules;
        }
        
        created(){
            this.loadedEditProject = this.$store.getters['adminModule/loadedEditProject'];
            
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

        handleProjectsEdit(){
            
        }
    }
</script>

<style scoped>

</style>