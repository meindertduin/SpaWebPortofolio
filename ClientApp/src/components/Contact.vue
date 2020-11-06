<template>
    <v-container class="text--white contact-wrapper">
        <v-row  justify="center" dense>
            <v-col class="col-sm-8 col-md-6 col-lg-4 col-10">
                <ContactItemFields />
            </v-col>
            <v-col class="col-sm-8 col-md-6 col-10">
                <ContactMessageForm />
            </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'
    import ContactMessageForm from "@/components/ContactMessageForm.vue";
    import ContactItemFields from "@/components/ContactItemFields.vue";

    @Component({
        name: 'Contact',
        components: {
            ContactMessageForm,
            ContactItemFields,
        }
    })
    export default class Contact extends Vue{
        
    }
</script>

<style scoped>
    .contact-wrapper{
        color: whitesmoke;
    }
</style>