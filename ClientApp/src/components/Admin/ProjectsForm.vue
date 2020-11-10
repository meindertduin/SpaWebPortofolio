<template>
    <div>
        <v-card color="secondary">
            <v-img class="text--white" src="laptop.jpg" max-height="200px">
                <v-card-title class="white--text">
                    <div class="display-2 align-center">Voeg een project toe</div>
                </v-card-title>
            </v-img>
            <v-card-text>
                <v-row>
                    <v-col cols="6">
                        <v-text-field dark outlined label="Project titel" v-model="titleFormField"
                                      :rules="[formRules.required]"></v-text-field>
                        <v-text-field dark outlined label="Github link" v-model="githubLinkFormField"></v-text-field>
                        <v-text-field dark outlined label="Demo link" v-model="demoLinkFormField"></v-text-field>
                        
                        <v-file-input dark outlined label="screenshots" multiple counter accept=".png" v-model="screenShots"></v-file-input>
                    </v-col>
                    <v-col cols="6" class="text-center">
                        <v-text-field dark outlined label="Features" v-model="featuresFormField" :rules="[formRules.required]"></v-text-field>
                        <v-select dark label="Display grootte" outlined :items="displaySizes"  v-model="selectedDisplaySize"
                                  :rules="[formRules.required]"></v-select>
                        <v-textarea dark outlined counter="2000" label="Beschrijving" v-model="descriptionFormField" 
                                    :rules="[formRules.required, formRules.counterMax2000]"></v-textarea>
                        <v-btn dark outlined large @click="handleProjectUpload">Versturen</v-btn>
                    </v-col>
                </v-row>
            </v-card-text>
        </v-card>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import {formRules} from "@/common/objects";
    import axios from 'axios';

    @Component({
        name: 'ProjectsForm',
    })
    export default class ProjectsForm extends Vue{
        private displaySizes = ["normaal", "groot"]
        
        private titleFormField : string = "";
        private githubLinkFormField : string = "";
        private demoLinkFormField : string = "";
        private featuresFormField : string = "";
        private descriptionFormField : string = "";
        private selectedDisplaySize = "";
        
        private screenShots:any = {};

        get formRules(){
            return formRules;
        }
        
        handleProjectUpload():void{
            if(Object.keys(this.screenShots).length === 0 && this.screenShots.constructor === Object) return;

            let screenShots:FormData = new FormData();
            let count:number = 0;
            for (let files in this.screenShots){
                screenShots.append('screenShots', this.screenShots[count]);
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
                title: this.titleFormField,
                displaySize: displaySize,
                features: this.featuresFormField.split(','),
                description: this.descriptionFormField,
                githubLink: this.githubLinkFormField,
                demoLink: this.demoLinkFormField,
            };
            
            axios.post('/api/projects/upload', projectForm)
                .then((response) => {
                    if (response.status == 200){
                        axios.post(`api/projects/upload/screenshot/${response.data.id}`, screenShots, {
                            headers: {
                                'Content-Type': 'multipart/form-data'
                            }
                        }).then((response) => {
                            this.$store.dispatch('projectsModule/loadProjects');
                        });
                    }
                })
            .catch((err) => console.log(err))
            
        }
        
    }
</script>

<style scoped>

</style>