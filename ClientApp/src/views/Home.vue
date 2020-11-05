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
      <v-container fluid>
        <div class="text-center display-2 font-weight-bold text--white">Projecten</div>
        <v-row justify="center" class="ma-5">
          <v-col cols="8">
            <Projects />
          </v-col>
        </v-row>
      </v-container>
    </div>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue'
  import Component from 'vue-class-component'
  import Projects from "@/components/Projects.vue";
  import ExperienceCards from "@/components/Experiences.vue";
  
  @Component({
    name: 'Home',
    components: {
      ExperienceCards,
      Projects,    
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