<template>
    <v-row justify="center">
        <v-col class="col-8 col-md-3 col-xl-2 col-sm-6" v-for="(category, categoryIndex) in experiences" :key="categoryIndex">
            <v-card height="300px" width="250px">
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
        </v-col>
    </v-row>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'

    @Component({
        name: 'Home',
    })
    export default class ExperienceCards extends Vue{
        private experiences =  {
            frontend: {
                title: "Frontend",
                icon: "mdi-laptop-chromebook",
                items: ["Javascript (es5 / es6)", "HTML5", "CSS3", "Vue js", "Nuxt js"]
            },
            backend: {
                title: "Backend",
                icon: "mdi-server",
                items: [".Net Core", "Asp .Net Core", "Entity framework", "MSSQL"]
            },
            misc: {
                title: "Overig",
                icon: "mdi-web",
                items: ["Docker", "Git", "Visual studio"]
            }
        }
    }
</script>

<style scoped>

</style>