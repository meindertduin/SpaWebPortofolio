<template>
    <v-img src="misty-waters.jpg" min-height="900px" >
        <v-row class="fill-height ma-6" justify="center" align-content="center">
            <div class="text-center">
                <div class="display-2 font-weight-bold white--text">Welkom bij mijn</div>
                <div class="display-3 font-weight-bold white--text">Web-Portofolio</div>
                <v-btn class="ma-5" fab dark large @click="scrollToProfile">
                    <v-icon dark>
                        mdi-chevron-double-down
                    </v-icon>
                </v-btn>
            </div>
        </v-row>
    </v-img>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from "vue-class-component";

    @Component({
        name: 'Welcome',
    })
    export default class Welcome extends Vue{
        scrollToProfile(){
            const yOffset = -80;
            const element = document.getElementsByClassName('page-section')[0];
            const y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;

            if (element) {
                window.scrollTo({top: y, behavior: 'smooth'});
            }
        }
    }
</script>

<style scoped>

</style>