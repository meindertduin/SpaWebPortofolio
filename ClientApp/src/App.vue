<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title>
        Meindert van Duin
      </v-toolbar-title>
      <template v-slot:extension>
        <v-tabs align-with-title>
          <v-tab @click="scrollToElement(0)">Profiel</v-tab>
          <v-tab @click="scrollToElement(1)">Evaringen</v-tab>
          <v-tab @click="scrollToElement(2)">Projecten</v-tab>
          <v-tab @click="scrollToElement(3)">Contact</v-tab>
        </v-tabs>
      </template>
      <v-spacer></v-spacer>
    </v-app-bar>

    <v-main>
      <RouterView />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component'

  @Component({
    name: 'App',
  })
  export default class App extends Vue{
    scrollToElement(index:number) {
      const yOffset = -80;
      const element = document.getElementsByClassName('page-section')[index];
      const y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;
      
      
      
      if (element) {
        window.scrollTo({top: y, behavior: 'smooth'});
      }
    }
  }
</script>
