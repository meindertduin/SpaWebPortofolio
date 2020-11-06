<template>
    <div>
        <div class="message-box-text text-h5">
            Of laat een berichtje achter
        </div>
        <div class="message-box-fields">
            <v-text-field dark outlined counter="25" label="Naam"></v-text-field>
            <v-text-field dark outlined counter="25" label="Email"></v-text-field>
            <v-text-field dark outlined counter="25" label="Onderwerp"></v-text-field>
            <v-textarea dark outlined label="Bericht"></v-textarea>
        </div>
        <div class="text-center">
            <v-btn dark>
                Verstuur
            </v-btn>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'
    
    @Component({
        name: "ContactMessageForm",
    })
    export default class ContactMessageForm extends Vue{
        
    }
</script>

<style scoped>
    .message-box-fields{
        margin-top: 3em;
        color: white;
    }
</style>