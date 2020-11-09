<template>
    <v-container>
        <ProjectsPage />
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import ProjectsPage from "@/components/Admin/ProjectsPage.vue";
    
    @Component({
        name: 'Admin',
        components: {
            ProjectsPage
        }
    })
    export default class Admin extends Vue{

    }
</script>

<style scoped>

</style>