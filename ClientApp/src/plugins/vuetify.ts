import Vue from 'vue';
import Vuetify from 'vuetify/lib';

Vue.use(Vuetify);

import colors, {Color} from 'vuetify/lib/util/colors'

const secondary : Color = {
    base: '#294C60',
    darken1: '#1f3947',
    darken2: '#152832',
}

const primary: Color = {
    base: '#3B1F2B'
}

export default new Vuetify({
    theme: {
        themes: {
            light: {
                primary: primary,
                secondary: secondary,
                accent: colors.shades.black,
                error: colors.red.accent3,
                background: colors.indigo.lighten5
            },
        }
    }
});