<template>
    <v-app>
        <v-app-bar app color="primary" dark>
            <v-row v-if="displaySize < 500" align-content="center">
                <v-menu offset-y>
                    <template v-slot:activator="{ on, attrs }">
                        <v-btn
                                color="primary"
                                v-bind="attrs"
                                v-on="on"
                                icon
                        >
                            <v-icon color="white">mdi-menu</v-icon>
                        </v-btn>
                    </template>
                    <v-list>
                        <v-list-item>
                            <v-list-item-action>
                                <v-btn class="mx-1" text @click="scrollToElement(0)">Profiel</v-btn>
                            </v-list-item-action>
                        </v-list-item>
                        <v-list-item>
                            <v-list-item-action>
                                <v-btn class="mx-1" text @click="scrollToElement(1)">Evaringen</v-btn>
                            </v-list-item-action>
                        </v-list-item>
                        <v-list-item>
                            <v-list-item-action>
                                <v-btn class="mx-1" text @click="scrollToElement(2)">Projecten</v-btn>
                            </v-list-item-action>
                        </v-list-item>
                        <v-list-item>
                            <v-list-item-action>
                                <v-btn class="mx-1" text @click="scrollToElement(3)">Contact</v-btn>
                            </v-list-item-action>
                        </v-list-item>
                        <v-list-item>
                            <v-list-item-action>
                                <v-btn text @click="openPdf">CV pdf</v-btn>
                            </v-list-item-action>
                        </v-list-item>
                    </v-list>
                </v-menu>
                <v-toolbar-title class="ma-2">
                    Meindert van Duin
                </v-toolbar-title>

                <v-spacer></v-spacer>

                <v-menu top :close-on-click="true" class="ma-2">
                    <template v-slot:activator="{ on, attrs }">
                        <v-btn color="primary" dark v-bind="attrs" v-on="on" depressed>
                            CV
                            <v-icon>
                                mdi-paperclip
                            </v-icon>
                        </v-btn>
                    </template>
                    <v-list>
                        <v-list-item>
                            <v-list-item-action>
                                <v-row justify="center">
                                    <v-btn text @click="openPdf">Open pdf</v-btn>
                                </v-row>
                            </v-list-item-action>
                        </v-list-item>
                    </v-list>
                </v-menu>
            </v-row>
            <v-row v-else>
                <v-toolbar-title>
                    Meindert van Duin
                </v-toolbar-title>
                <v-btn class="ml-4 mr-1" text @click="scrollToElement(0)">Profiel</v-btn>
                <v-btn class="mx-1" text @click="scrollToElement(1)">Evaringen</v-btn>
                <v-btn class="mx-1" text @click="scrollToElement(2)">Projecten</v-btn>
                <v-btn class="mx-1" text @click="scrollToElement(3)">Contact</v-btn>

                <v-spacer></v-spacer>

                <v-menu top :close-on-click="true">
                    <template v-slot:activator="{ on, attrs }">
                        <v-btn color="primary" dark v-bind="attrs" v-on="on" depressed>
                            CV
                            <v-icon>
                                mdi-paperclip
                            </v-icon>
                        </v-btn>
                    </template>
                    <v-list>
                        <v-list-item>
                            <v-list-item-action>
                                <v-row justify="center">
                                    <v-btn text @click="openPdf">Open pdf</v-btn>
                                </v-row>
                            </v-list-item-action>
                        </v-list-item>
                    </v-list>
                </v-menu>
            </v-row>
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
        name: 'DefaultLayout',
    })
    export default class DefaultLayout extends Vue{
        get displaySize(){
            return this.$store.getters.getDisplaySize;
        }
        
        scrollToElement(index:number):void {
            const yOffset = -80;
            const element = document.getElementsByClassName('page-section')[index];
            const y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;

            if (element) {
                window.scrollTo({top: y, behavior: 'smooth'});
            }
        }

        openPdf():void{
            const fileUrl= '/files/Meindert van Duin CV 2020.pdf'
            window.open(fileUrl);
        }   
    }
</script>

<style scoped>

</style>