<template>
    <v-row justify="center">
        <v-col class="col-md-10 col-lg-8 col-sm-11 col-12">
            <v-card>
                <v-img src="/admin-logo.png" max-height="500px">
                    <v-card-title>
                        <div class="text-center display-2">Wekom op de admin pagina</div>
                    </v-card-title>
                </v-img>
            </v-card>
        </v-col>
    </v-row>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";

    @Component({
        name: 'AdminHomePage',
    })
    export default class AdminHomePage extends Vue{

    }
</script>

<style scoped>

</style>