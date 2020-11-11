<template>
    <v-row>
        <v-col class="col-md-11 col-12">
            <div>
                <div class="text--white display-2">Meindert van Duin</div>
                <div class="my-4 text-h6">Fullstack programmeur</div>
                <div class="my-4 text-body-2">Ik hoop doormiddel van mijn portofolio mijn vaardigheden heb kunnen laten zien en kom graag in contact.</div>
            </div>
            <div class="contact-items-container">
                <div class="contact-item">
                    <div class="contact-item-icon">
                        <div class="pa-4">
                            <v-btn icon text color="white" href="mailto:meindertvanduin99@gmail.com">
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
                            <v-btn icon text color="white" href="tel:0636399630">
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
                            <v-btn icon color="white" href="https://github.com/meindertduin" target="_blank">
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
    </v-row>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    
    @Component({
        name: "ContactItemFields"
    })
    export default class ContactItemFields extends Vue{
        
    }
</script>

<style scoped>
    .contact-items-container{
        margin-top: 4em;
    }

    .contact-item{
        display: flex;
    }
</style>