<template>
  <div class="home">
    <v-img 
            src="https://picsum.photos/350/165?random"
            min-height="500"
    >
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
    <v-row>
      <v-btn>Hello wolrd</v-btn>
    </v-row>
  </div>
</template>

<script>
  import Vue from 'vue'
  import Component from 'vue-class-component'

  @Component({
    name: 'Home',
  })
  export default class Home extends Vue{
  
  }
</script>

