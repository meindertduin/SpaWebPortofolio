<template>
    <div>
        <div class="message-box-text text-h5">
            Of laat een berichtje achter
        </div>
        <div class="message-box-fields">
            <v-text-field dark outlined label="Naam" v-model="nameField" :rules="[formRules.required, formRules.counterMax200]"></v-text-field>
            <v-text-field dark outlined label="Email" v-model="emailField" :rules="[formRules.required, formRules.email]"></v-text-field>
            <v-text-field dark outlined label="Onderwerp" v-model="subjectField" :rules="[formRules.required, formRules.counterMax200]"></v-text-field>
            <v-textarea dark outlined counter="2000" label="Bericht" v-model="messageField" :rules="[formRules.required, formRules.counterMax2000]"></v-textarea>
        </div>
        <div class="text-center">
            <v-btn v-if="confirmMessage.length <= 0" dark outlined large @click="sendMessage">
                Verstuur
            </v-btn>
            <div v-else>
                {{confirmMessage}}
            </div>    
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'
    import axios from "axios";
    import {formRules, emailPattern} from '@/common/objects'
    
    @Component({
        name: "ContactMessageForm",
    })
    export default class ContactMessageForm extends Vue{
        private nameField : string = "";
        private emailField : string = "";
        private subjectField : string = "";
        private messageField : string = "";
        
        
        private confirmMessage :string = "";
        
        get formRules(){
            return formRules;
        }

        sendMessage():void {
            if (this.nameField.length <= 0 || this.nameField.length > 200) return;
            if (this.emailField.length <= 0 || this.emailField.length > 200) return;
            if (this.subjectField.length <= 0 || this.subjectField.length > 200) return;
            if (this.messageField.length <= 0 || this.messageField.length > 2000) return;
            if (!emailPattern.test(this.emailField)) return;
            
            axios.post("api/contactMessage", {
                name: this.nameField,   
                email: this.emailField,
                subject: this.subjectField,
                message: this.messageField,
            })
                .then((response) => {
                    if (response.status == 200){
                        this.confirmMessage = "Bericht succesvol verstuurd"
                    }
                    else{
                        this.confirmMessage = "Er ging iets mis tijdens het versturen van het bericht..."
                    }
                })
                .catch((err) => {
                    console.log(err);
                    this.confirmMessage = "Er ging iets mis tijdens het versturen van het bericht..."
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