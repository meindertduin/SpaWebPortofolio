<template>
    <v-row dense>
        <v-col v-for="project in projects" :key="project.title" :cols="project.flex">
            <v-card dark>
                <v-img :src="project.src" class="white--text align-end" gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)" height="500px">
                    <v-card-title v-text="project.title"></v-card-title>
                </v-img>
                <v-card-text>
                    <div class="project-text" :style="`height:${600 / project.flex}px;`">
                        <div class="project-feature-wrapper">
                            <div class="project-feature" v-for="x in 5">JAVASCRIPT</div>
                        </div>
                        <div>
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ducimus ipsum neque nobis ratione reprehenderit! A dicta ipsam maiores neque porro, quam sapiente. Accusantium amet aperiam culpa cupiditate debitis delectus deserunt dolore eaque eveniet in magnam magni molestiae nesciunt nisi obcaecati, optio perferendis placeat quae quibusdam quod repellat reprehenderit, velit veniam.
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
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'

    @Component({
        name: 'Projects',
    })
    export default class Projects extends Vue{
        private projects = [
            { title: 'Pre-fab homes', src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg', flex: 12 },
            { title: 'Favorite road trips', src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg', flex: 6 },
            { title: 'Best airlines', src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg', flex: 6 },
        ];
    }
</script>

<style scoped>
    .project-text{
        
    }
    
    .project-feature-wrapper{
        display: flex;
    }
    
    .project-feature{
        margin: 5px;
        color: grey;
    }
</style>