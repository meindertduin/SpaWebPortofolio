<template>
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
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    
    @Component({
        name: 'Profile',
    })
    export default class Profile extends Vue{
        
    }
</script>

<style scoped>

</style>