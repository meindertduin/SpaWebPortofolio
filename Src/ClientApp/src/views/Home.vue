<template>
  <div class="home">
    <Welcome />
    <div class="page-container page-section">
      <Profile />
    </div >
      <div>
          <ExperienceCards class="experiences page-container page-section" />
      </div>
    <div class="secondary page-container page-section">
      <Projects />
    </div>
    <div class="secondary darken-2 page-container page-section">
      <Contact />
    </div>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue'
  import Component from 'vue-class-component'
  import Projects from "@/components/Projects.vue";
  import ExperienceCards from "@/components/Experiences.vue";
  import Contact from "@/components/Contact.vue";
  import Profile from "@/components/Profile.vue";
  import Welcome from "@/components/Welcome.vue";
  import {projectModel} from "@/common/types";
  
  @Component({
    name: 'Home',
    components: {
      ExperienceCards,
      Projects, 
      Contact,
      Profile,
      Welcome,
    }
  })
  export default class Home extends Vue{
    get loadedProjects():Array<projectModel>{
      return this.$store.getters['projectsModule/loadedProjects']
    }
    
    created(){
      if (this.loadedProjects.length <= 0){
        this.$store.dispatch('projectsModule/loadProjects');
      }
    }
  }
</script>

<style scoped>
  .page-container{
    padding-bottom: 4em;
    padding-top: 3em;
  }
</style>