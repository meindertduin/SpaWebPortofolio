<template>
    <div>
        <div class="message-box-text text-h5">
            Of laat een berichtje achter
        </div>
        <div class="message-box-fields">
            <v-text-field dark outlined label="Naam" v-model="nameField" :rules="[rules.required, rules.counterMax200]"></v-text-field>
            <v-text-field dark outlined label="Email" v-model="emailField" :rules="[rules.required, rules.email]"></v-text-field>
            <v-text-field dark outlined label="Onderwerp" v-model="subjectField" :rules="[rules.required, rules.counterMax200]"></v-text-field>
            <v-textarea dark outlined counter="2000" label="Bericht" v-model="messageField" :rules="[rules.required, rules.counterMax2000]"></v-textarea>
        </div>
        <div class="text-center">
            <v-btn dark outlined large>
                Verstuur
            </v-btn>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'
    import axios from "axios";
    
    @Component({
        name: "ContactMessageForm",
    })
    export default class ContactMessageForm extends Vue{
        private nameField : string = "";
        private emailField : string = "";
        private subjectField : string = "";
        private messageField : string = "";
        
        private emailPattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        
        
        private rules = {
            required: value => !!value || 'verplicht veld',
            counterMax200: value => value.length <= 200 || 'Maximaal 200 tekens',
            counterMax2000: value => value.length <= 2000 || 'Maximaal 2000 tekens',
            email: value => {
                return this.emailPattern.test(value) || 'Ongeldig email'
            },
        }

        sendMessage():void {
            if (this.nameField.length <= 0 || this.nameField.length > 200) return;
            if (this.emailField.length <= 0 || this.emailField.length > 200) return;
            if (this.subjectField.length <= 0 || this.subjectField.length > 200) return;
            if (this.messageField.length <= 0 || this.messageField.length > 2000) return;
            if (!this.emailPattern.test(this.emailField)) return;
            
            axios.post("api/contactMessage", {
                name: this.nameField,
                email: this.emailField,
                subject: this.subjectField,
                message: this.messageField,
            })
                .then((response) => {
                    // Tell if sending was succesfull
                })
                .catch((err) => {
                    console.log(err);
                    // Tell user
                })
        }
    }
</script>

<style scoped>
    .message-box-fields{
        margin-top: 3em;
        color: white;
    }
</style>