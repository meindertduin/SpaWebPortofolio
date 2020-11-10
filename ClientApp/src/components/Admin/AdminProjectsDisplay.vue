<template>
    <div>
        <v-row>
            <v-col v-for="project in loadedProjects" :key="project.title" :class="`col-lg-${project.displaySize === 0? '6' : '12'}`">
                <v-card dark>
                    <v-carousel>
                        <v-carousel-item
                                v-for="(image,i) in project.images"
                                :key="i"
                                :src="`data:image/png;base64,${image.image}`"
                                reverse-transition="fade-transition"
                                transition="fade-transition"
                        ></v-carousel-item>
                    </v-carousel>
                    <v-card-title>{{project.title}}</v-card-title>
                    <v-card-text>
                        <div class="project-feature-wrapper">
                            <div class="project-feature">{{getFeaturesString(project.features)}}</div>
                        </div>
                        <div class="project-text" :style="`height:${project.flex === 12? 100: 150}px;`">
                            <div>
                                {{project.description}}
                            </div>
                        </div>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>

                        <v-btn icon>
                            <v-icon>mdi-heart</v-icon>
                        </v-btn>

                        <v-btn icon>
                            <v-icon>mdi-bookmark</v-icon>
                        </v-btn>

                        <v-btn icon>
                            <v-icon>mdi-share-variant</v-icon>
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import axios from 'axios';
    import {projectModel, projectImage} from "@/common/types";


    @Component({
        name: 'AdminProjectsDisplay',
    })
    export default class AdminProjectsDisplay extends Vue{
        private loadedProjects: Array<projectModel> | null = null; 
        
        created(){
            axios.get('api/projects')
                .then((response) => {
                     this.loadedProjects = response.data;
                })
            .catch((err) => console.log(err));
        }
        
        private getFeaturesString(features: string[]):string{
            let featuresString = "";

            for (let i = 0; i < features.length; i++){
                console.log("this")
                if (i + 1 !== features.length){
                    featuresString += features[i] + ', ';
                }
                else{
                    featuresString += features[i]
                }
            }
            return featuresString;
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