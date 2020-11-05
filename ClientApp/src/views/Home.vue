<template>
  <div class="home">
    <v-img src="misty-waters.jpg" min-height="500">
      <v-row class="fill-height ma-6" justify="center" align-content="center">
        <div class="text-center">
          <div class="display-2 font-weight-bold white--text">Welkom bij mijn</div>
          <div class="display-3 font-weight-bold white--text">Portofolio</div>
          <v-btn class="ma-5" fab dark large>
            <v-icon dark>
              mdi-chevron-double-down
            </v-icon>
          </v-btn>
        </div>
      </v-row>
    </v-img>
    <div class="profile-container">
      <v-container>
        <v-row justify="center">
          <v-col class="ma-5 col-10 col-md-6">
            <div class="text-center">
              <v-avatar class="ma-5"  size="200">
                <v-img src="profileavatar.jpeg"></v-img>
              </v-avatar>
              <div class="display-1 font-weight-bold mt-5">Ikke in het kort</div>
              <div style="margin-top: 2em; margin-bottom: 4em">
                Vuetify is the #1 component library for Vue.js and has been in active development since 2016. The goal of the project is to provide users with everything that is needed to build rich and engaging web applications using the Material Design specification. It accomplishes that with a consistent update cycle, Long-term Support (LTS) for previous versions,
                responsive community engagement, a vast ecosystem of resources and a dedication to quality components.
              </div>
            </div>
          </v-col>
        </v-row>
      </v-container>
    </div>
    <v-parallax src="misty-forest.jpg">
      <v-container>
        <v-row justify="center">
          <div class="my-5 display-2 font-weight-bold text-center">
            Ervaringen
          </div>
        </v-row>
        <ExperienceCards class="my-5" />
      </v-container>
    </v-parallax>
    <div class="secondary page-container">
      <v-container>
        <div class="text-center display-2 font-weight-bold text--white">Projecten</div>
        <v-row justify="center" class="ma-5">
          <v-card v-for="x in 4"
                  class="mx-auto"
                  max-width="344"
          >
            <v-img
                    src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                    height="200px"
            ></v-img>

            <v-card-title>
              Top western road trips
            </v-card-title>

            <v-card-subtitle>
              1,000 miles of wonder
            </v-card-subtitle>

            <v-card-actions>
              <v-btn
                      color="orange lighten-2"
                      text
              >
                Explore
              </v-btn>

              <v-spacer></v-spacer>

              <v-btn
                      icon
                      @click="show = !show"
              >
                <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
              </v-btn>
            </v-card-actions>

            <v-expand-transition>
              <div v-show="show">
                <v-divider></v-divider>

                <v-card-text>
                  I'm a thing. But, like most politicians, he promised more than he could deliver. You won't have time for sleeping, soldier, not with all the bed making you'll be doing. Then we'll go with that data file! Hey, you add a one and two zeros to that or we walk! You're going to do his laundry? I've got to find a way to escape.
                </v-card-text>
              </div>
            </v-expand-transition>
          </v-card>
        </v-row>
      </v-container>
    </div>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue'
  import Component from 'vue-class-component'
  import ExperienceCards from "@/components/ExperienceCards";

  @Component({
    name: 'Home',
    components: {
      ExperienceCards,
    }
  })
  export default class Home extends Vue{
  
  }
</script>

<style scoped>
  .page-container{
    padding-bottom: 4em;
    padding-top: 3em;
  }
</style>