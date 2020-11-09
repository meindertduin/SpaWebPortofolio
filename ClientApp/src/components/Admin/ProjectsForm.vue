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
                        <v-text-field dark outlined label="Project titel"></v-text-field>
                        <v-text-field dark outlined label="Github link"></v-text-field>
                        <v-text-field dark outlined label="Demo link"></v-text-field>
                        <v-select dark label="Display grootte" :items="displaySizes"  v-model="selectedDisplaySize"></v-select>
                    </v-col>
                    <v-col cols="6" class="text-center">
                        <v-text-field dark outlined label="Features"></v-text-field>
                        <v-textarea dark outlined counter="2000" label="Beschrijving" :rules="[formRules.required, formRules.counterMax2000]"></v-textarea>
                        <v-btn dark outlined large>Versturen</v-btn>
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

    @Component({
        name: 'ProjectsForm',
    })
    export default class ProjectsForm extends Vue{
        private displaySizes = ["normaal", "groot"]
        
        private selectedDisplaySize = "";

        get formRules(){
            return formRules;
        }
        
        
        
    }
</script>

<style scoped>

</style>