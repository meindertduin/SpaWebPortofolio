<template>
    <v-container>
        <v-row justify="center">
            <v-col class="col-11 col-md-10 col-lg-9">
                <EditProject />
            </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    import EditProject from "@/components/Admin/EditProject.vue";
    
    @Component({
        name: 'EditProjectPage',
        components: {
            EditProject,
        }
    })
    export default class EditProjectPage extends Vue{

    }
</script>

<style scoped>

</style>