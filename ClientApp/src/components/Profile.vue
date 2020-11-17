<template>
    <v-container>
        <v-row justify="center">
            <v-col class="ma-5 col-10 col-md-6">
                <div class="text-center">
                    <v-avatar class="ma-5"  size="200">
                        <v-img src="profileavatar.jpeg"></v-img>
                    </v-avatar>
                    <div class="display-1 font-weight-bold mt-5">Ikke in het kort</div>
                    <div style="margin-top: 2em; margin-bottom: 1em">
                        <div class="ma-2">
                            Mijn naam is Meindert, ben 21 jaar en programmeer al een tijdje graag websites en andere projecten.
                            In de afgelopen maanden heb ik al een aantal projecten achter de kiezen die ik van begin af aan tot aan hosten toe uitgevoerd heb 
                            en heb ik hier veel evaring mee opgedaan. Ik voel me vrij zeker over mijn vaardigheden en ben daarom dus opzoek naar een baan
                            waarmee ik verder kan groeien.
                        </div>
                        <div class="ma-2">
                            Zo ben ik opzoek naar een baan waarmee ik mijn voet in de wereld van profesioneel fullstack development kan zetten.
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