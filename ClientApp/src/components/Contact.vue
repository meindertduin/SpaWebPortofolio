<template>
    <v-container class="text--white contact-wrapper">
        <v-row  justify="center" dense>
            <v-col class="col-sm-6 col-md-4 col-10">
                <div class="contact-text">
                    <div class="text--white display-2">Meindert van Duin</div>
                    <div class="my-4 text-h6">Fullstack programmeur</div>
                    <div class="my-4 text-body-2">Ik hoop doormiddel van mijn portofolio mijn vaardigheden heb kunnen laten zien en kom graag in contact.</div>
                </div>
                <div class="contact-items-container">
                    <div class="contact-item">
                        <div class="contact-item-icon">
                            <div class="pa-4">
                                <v-btn text color="white">
                                    <v-icon x-large>
                                        mdi-email
                                    </v-icon>
                                </v-btn>
                            </div>
                        </div>
                        <div class="contact-item-content pa-4">
                            <div class="text-h6">
                                Email:
                            </div>
                            <div class="text-body-2">
                                meindertvanduin99@gmail.com
                            </div>
                        </div>
                    </div>
                    <v-divider class="white"></v-divider>
                    <div class="contact-item">
                        <div class="contact-item-icon">
                            <div class="pa-4">
                                <v-btn text color="white">
                                    <v-icon x-large>
                                        mdi-phone
                                    </v-icon>
                                </v-btn>
                            </div>
                        </div>
                        <div class="contact-item-content pa-4">
                            <div class="text-h6">
                                Telefoon:
                            </div>
                            <div class="text-body-2">
                                06 36 39 96 30
                            </div>
                        </div>
                    </div>
                    <v-divider class="white"></v-divider>
                    <div class="contact-item">
                        <div class="contact-item-icon">
                            <div class="pa-4">
                                <v-btn text color="white">
                                    <v-icon x-large>
                                        mdi-github
                                    </v-icon>
                                </v-btn>
                            </div>
                        </div>
                        <div class="contact-item-content pa-4">
                            <div class="text-h6">
                                Github:
                            </div>
                            <div class="text-body-2">
                                https://github.com/meindertduin
                            </div>
                        </div>
                    </div>
                    <v-divider class="white"></v-divider>
                </div>
            </v-col>
            <v-col class="col-md-4 col-8 pa-4">
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
            </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'

    @Component({
        name: 'Contact',
    })
    export default class Contact extends Vue{
        
    }
</script>

<style scoped>
    .contact-wrapper{
        color: whitesmoke;
    }
    .contact-text{
        width: 80%;
    }
    
    .contact-items-container{
        margin-top: 4em;
        width: 80%;
    }
    
    .contact-item{
        display: flex;
    }
    
    .message-box-text{
        width: 80%;
    }
    
    .message-box-fields{
        margin-top: 3em;
        color: white;
    }
</style>