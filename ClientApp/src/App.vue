<template>
  <Component v-bind:is="'default-layout'" />
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component'
import DefaultLayout from "@/Layouts/DefaultLayout.vue";

  @Component({
    name: 'App',
    components: {
      'default-layout': DefaultLayout,
      'admin-layout': DefaultLayout,
    },
  })
  export default class App extends Vue{
    
  }
</script>
