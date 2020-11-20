<template>
  <Component v-bind:is="layout" />
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component'
import DefaultLayout from "@/Layouts/DefaultLayout.vue";
import AdminLayout from "@/Layouts/AdminLayout.vue";
import {Watch} from "vue-property-decorator";

  @Component({
    name: 'App',
    components: {
      'default-layout': DefaultLayout,
      'admin-layout': AdminLayout,
    },
  })
  export default class App extends Vue{
      get layout(){
        return this.$route.meta.layout
      }
  
      get displaySize():number{
          return this.getDisplaySizeFromVuetify();
      }
      
      getDisplaySizeFromVuetify():number{
        switch (this.$vuetify.breakpoint.name) {
          case 'xs': return 220
          case 'sm': return 400
          case 'md': return 500
          case 'lg': return 600
          case 'xl': return 800
        }
      }
  
      @Watch("displaySize")
      onAspectChange(newValue:number, oldValue:number):void{
        this.$store.commit('SET_DISPLAY_SIZE', newValue);
      }
    
      created(){
        this.$store.commit('SET_DISPLAY_SIZE', this.getDisplaySizeFromVuetify());
      }
  }
</script>
