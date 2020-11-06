<template>
    <v-row>
        <v-col v-for="project in projects" :key="project.title" :class="`col-lg-${project.flex}`">
            <v-card dark>
                <v-carousel>
                    <v-carousel-item
                            v-for="(link,i) in links"
                            :key="i"
                            :src="link.src"
                            reverse-transition="fade-transition"
                            transition="fade-transition"
                    ></v-carousel-item>
                </v-carousel>
                <v-card-title>{{project.title}}</v-card-title>
                <v-card-text>
                    <div class="project-feature-wrapper">
                        <div class="project-feature" v-for="x in 5">JAVASCRIPT</div>
                    </div>
                    <div class="project-text" :style="`height:${project.flex === 12? 100: 150}px;`">
                        <div>
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam, consequatur consequuntur corporis cumque delectus in laudantium non quaerat repellat sapiente sequi soluta sunt, suscipit ut veritatis, voluptates! Ad culpa ea earum est eveniet exercitationem explicabo, fugiat maxime minima nesciunt obcaecati quas quis quos, tempore, vel. Accusamus aliquid animi atque aut beatae cum dignissimos earum facere incidunt itaque laborum libero minus modi molestias non officiis omnis optio perferendis possimus provident quidem, recusandae temporibus totam ut veniam, vero voluptas. Beatae consequatur distinctio ducimus error explicabo nam nulla obcaecati quidem rerum, sapiente tenetur, ullam unde. Aliquid aut illo magnam magni nesciunt vel.
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
        
        private links = [
            {
                src: 'https://cdn.vuetifyjs.com/images/carousel/squirrel.jpg',
            },
            {
                src: 'https://cdn.vuetifyjs.com/images/carousel/sky.jpg',
            },
            {
                src: 'https://cdn.vuetifyjs.com/images/carousel/bird.jpg',
            },
            {
                src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg',
            },
        ]
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