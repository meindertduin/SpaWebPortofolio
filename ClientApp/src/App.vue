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
      <v-menu top :close-on-click="true">
        <template v-slot:activator="{ on, attrs }">
          <v-btn color="primary" dark v-bind="attrs" v-on="on" depressed> 
            CV
            <v-icon>
              mdi-paperclip
            </v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item>
            <v-list-item-action>
              <v-btn @click="openPdf">Open pdf</v-btn>
            </v-list-item-action>
          </v-list-item>
        </v-list>
      </v-menu>
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
    scrollToElement(index:number):void {
      const yOffset = -80;
      const element = document.getElementsByClassName('page-section')[index];
      const y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;
      
      if (element) {
        window.scrollTo({top: y, behavior: 'smooth'});
      }
    }
    
    openPdf():void{
      console.log("opening pdf")
      
    }
  }
</script>
