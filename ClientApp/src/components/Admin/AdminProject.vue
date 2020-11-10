<template>
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
            <div class="project-text" :style="`height:${project.displaySize === 0? 100: 150}px;`">
                <div>
                    {{project.description}}
                </div>
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
            <v-btn icon>
                <v-icon>mdi-cog</v-icon>
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
        name: 'AdminProject',
    })
    export default class AdminProject extends Vue{
        @Prop({type: Object, required: true}) readonly project !: projectModel;

        private getFeaturesString(features: string[]){
            return concatFeaturesString(features);
        }
    }
</script>

<style scoped>

</style>