<template>
    <v-parallax src="/misty-forest.jpg" :height="paralexHeight">
        <v-container>
            <v-row justify="center" v-if="paralexHeight < 1000">
                <div class="my-5 display-2 font-weight-bold text-center">
                    Ervaringen
                </div>
            </v-row>
            <v-row justify="center" class="my-5">
                <v-col class="col-8 col-md-3 col-xl-2 col-sm-6" v-for="(category, categoryIndex) in experiences" :key="categoryIndex">
                    <v-hover v-slot="{ hover }">
                        <v-card height="300px" width="250px" :elevation="hover ? 12 : 2" :class="{ 'on-hover': hover }">
                            <v-card-text>
                                <v-row justify="center">
                                    <v-icon x-large color="primary" class="ma-5">
                                        {{category.icon}}
                                    </v-icon>
                                </v-row>
                                <v-row justify="center">
                                    <div class="font-weight-bold text-center text-h4 ma-3" style="color: black">
                                        {{category.title}}
                                    </div>
                                </v-row>
                                <v-row justify="center">
                                    <div class="font-weight-bold">
                                        <ul>
                                            <li v-for="(item, index) in category.items" :key="index">
                                                {{item}}
                                            </li>
                                        </ul>
                                    </div>
                                </v-row>
                            </v-card-text>
                        </v-card>
                    </v-hover>
                </v-col>
            </v-row>
        </v-container>
    </v-parallax>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'

    @Component({
        name: 'ExperienceCards',
    })
    export default class ExperienceCards extends Vue{
        private experiences =  {
            frontend: {
                title: "Frontend",
                icon: "mdi-laptop-chromebook",
                items: ["Javascript","Typescript" ,"HTML5", "CSS", "Vue js"]
            },
            backend: {
                title: "Backend",
                icon: "mdi-server",
                items: ["(ASP) .Net Core", "(ASP) .Net 5", "SQL", "Entity framework"]
            },
            misc: {
                title: "Overig",
                icon: "mdi-web",
                items: ["Git", "Docker", "Nginx", "Visual studio"]
            }
        };
        
        get paralexHeight(){
            // @ts-ignore
            switch (this.$vuetify.breakpoint.name) {
                case 'xs': return '1000'
                case 'sm': return '900'
                case 'md': return '600'
                case 'lg': return '500'
                case 'xl': return '500'
            }
            
        }
    }
</script>

<style scoped>
    .v-card {
        transition: opacity .2s ease-in-out;
    }

    .v-card:not(.on-hover) {
        opacity: 0.8;
    }

    .show-btns {
        color: rgba(255, 255, 255, 1) !important;
    }
</style>