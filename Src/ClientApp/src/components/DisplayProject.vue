<template>
    <v-card dark>
        <v-carousel>
            <v-carousel-item
                    v-for="(item,i) in project.images"
                    :key="i"
                    :src="`data:image/png;base64,${item.image}`"
                    reverse-transition="fade-transition"
                    transition="fade-transition"
                    contain
            ></v-carousel-item>
        </v-carousel>
        <v-card-title>{{project.title}}</v-card-title>
        <v-card-text>
            <div class="project-feature-wrapper">
                <div class="mb-2 project-feature orange--text">{{getFeaturesString(project.features)}}</div>
            </div>
            <div class="project-text" :style="`height:${project.displaySize === 0? 150: 200}px;`">
              {{project.description}}
            </div>
        </v-card-text>
        <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn text color="green" v-if="project.demoLink.length > 0" :href="project.demoLink" target="_blank">
                Demo
            </v-btn>
            <v-btn icon v-if="project.githubLink.length > 0" :href="project.githubLink" target="_blank">
                <v-icon>mdi-github</v-icon>
            </v-btn>
        </v-card-actions>
    </v-card>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import {projectModel} from "@/common/types";
    import {Prop} from "vue-property-decorator";
    import {concatFeaturesString} from "@/common/functions";

    @Component({
        name: 'DisplayProject',
    })
    export default class DisplayProject extends Vue{
        @Prop({type: Object, required: true}) readonly project !: projectModel;
      
        private getFeaturesString(features: string[]){
            return concatFeaturesString(features);
        }
    }
</script>

<style scoped>
    .project-text{
      overflow-y: auto;
      white-space: pre-wrap;
      border-radius: 20px;
      box-shadow: -1px -2px 33px -6px rgba(0,0,0,1) inset;
      -webkit-box-shadow: -1px -2px 33px -6px rgba(0,0,0,1) inset;
      -moz-box-shadow: -1px -2px 33px -6px rgba(0,0,0,1) inset;
      padding: 8px;
    }
</style>