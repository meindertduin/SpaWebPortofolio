<template>
    <v-img src="/misty-waters.jpg" :max-height="`${welcomeImageSize}px`" >
        <v-row class="fill-height ma-6" justify="center" align-content="center">
            <div class="text-center">
                <div class="welcome-text">Web-Portfolio</div>
                <div class="welcome-text" id="name-text">Meindert van Duin</div>
                <v-btn icon class="ma-5" fab dark x-large @click="scrollToProfile">
                    <v-icon dark x-large> 
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
        get displaySize(){
            return this.$store.getters.getDisplaySize;
        }
        
        get welcomeImageSize(){
            if (this.displaySize <= 500) return 920;
            if (this.displaySize <= 400) return 800;
            if (this.displaySize <= 220) return 500;
        }
        
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
    .welcome-text{
        font-family: 'Teko', sans-serif;
        color: #65d0db;
        grid-column: 1;
        grid-row: 1;
        align-self: end;
        justify-self: center;

        margin: 0;
        z-index: 1;
        font-size: 2rem;
        text-transform: uppercase;
        animation: glow 6s ease-in-out infinite alternate;
        text-align: center;
    }

    #name-text{
        font-size: 4rem;
        font-weight: bolder;
        margin-bottom: 4rem;
    }
    
    @keyframes glow {
        from {
            text-shadow: 0 0 20px #2d9da9;
        }
        to {
            text-shadow: 0 0 30px #34b3c1, 0 0 10px #4dbbc7;
        }
    }
</style>