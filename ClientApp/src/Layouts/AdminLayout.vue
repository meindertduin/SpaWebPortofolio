<template>
    <v-app>
        <v-app-bar app color="primary" dark>
            <v-toolbar-title>
                Admin page
            </v-toolbar-title>
            <template v-slot:extension>
                <v-tabs align-with-title>
                    <v-tab @click="setPage(0)">Home</v-tab>
                    <v-tab @click="setPage(1)">Projecten</v-tab>
                    <v-tab @click="setPage(2)">Berichten</v-tab>
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
        setPage(pageNumber: number):void{
            this.$store.commit('adminModule/SET_PAGE_NUMBER', pageNumber)
        }
    }
</script>

<style scoped>

</style>