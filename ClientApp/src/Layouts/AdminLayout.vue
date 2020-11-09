<template>
    <v-app>
        <v-app-bar app color="primary" dark>
            <v-toolbar-title>
                Admin page
            </v-toolbar-title>
            <template v-slot:extension>
                <v-tabs align-with-title>
                    <v-tab>Home</v-tab>
                    <v-tab>Projecten</v-tab>
                    <v-tab>Berichten</v-tab>
                </v-tabs>
            </template>
        </v-app-bar>
        <v-main>
            <RouterView />
        </v-main>
    </v-app>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";

    @Component({
        name: 'AdminLayout',
    })
    export default class DefaultLayout extends Vue {
    
    }
</script>

<style scoped>

</style>