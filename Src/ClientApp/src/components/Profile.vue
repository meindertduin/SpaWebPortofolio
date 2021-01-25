<template>
    <v-container>
        <v-row justify="center">
            <v-col class="ma-5 col-10 col-md-6">
                <div class="text-center">
                    <v-avatar class="ma-5"  size="200">
                        <v-img src="/profileavatar.jpeg"></v-img>
                    </v-avatar>
                    <div class="display-1 font-weight-bold mt-5">Ikke in 't kort</div>
                    <div style="margin-top: 2em; margin-bottom: 1em">
                        <div class="ma-2">
                          Ik ben Meindert, 21 jaar en programmeer al een tijdje met veel plezier websites en andere projecten. Zo heb ik al bij een aantal projecten weten creëren waarbij ik van begin tot eind alle touwtjes in handen had. Op deze manier heb ik ervaring opgedaan in de frontend, backend en ook bij het hosten van applicaties. Ik voel me vrij zeker over mijn vaardigheden en ben daarom opzoek naar een baan waarmee ik mijzelf verder kan ontwikkelen. Natuurlijk wil ik doorgroeien in dit vakgebied!
                        </div>
                        <div class="ma-2">
                          Mijn interesses liggen vooral bij de backend, maar ben ook zeker niet vies van werken aan de frontend van een applicatie en hoop een mooi balans te vinden tussen de twee.
                        </div>      
                        <div class="ma-2">
                          Ik ben dus opzoek naar een baan waarmee ik mijn voetafdruk in de wereld van software ontwikkeling kan zetten.
                        </div>
                    </div>
                </div>
            </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";
    
    @Component({
        name: 'Profile',
    })
    export default class Profile extends Vue{
        
    }
</script>

<style scoped>

</style>