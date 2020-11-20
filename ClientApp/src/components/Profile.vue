<template>
    <v-container>
        <v-row justify="center">
            <v-col class="ma-5 col-10 col-md-6">
                <div class="text-center">
                    <v-avatar class="ma-5"  size="200">
                        <v-img src="files/profileavatar.jpeg"></v-img>
                    </v-avatar>
                    <div class="display-1 font-weight-bold mt-5">Ikke in 't kort</div>
                    <div style="margin-top: 2em; margin-bottom: 1em">
                        <div class="ma-2">
                            Ik ben Meindert, 21 jaar en programmeer al een tijdje met veel plezier websites en andere projecten/
                            In de afgelopen maanden heb ik al een aantal projecten uitgevoerd waarbij ik vanaf het begin tot aan het hosten aan toe alle touwtjes in handen mee had.
                            Hiermee heb ik dan ook zeker veel ervaring mee opgedaan. Ik voel me vrij zeker over mijn vaardigheden en daarom ben ik dus opzoek naar een baan waamee
                            ik mezelf nog verder kan ontwikkelen. Natuurlijk wil ik doorgroeien in dit vakgebied! 
                        </div>
                        <div class="ma-2">
                            Ik ben dus opzoek naar een baan waarmee ik mijn
                            voetdruk in de wereld van proffesioneel fullstack development kan zetten.
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