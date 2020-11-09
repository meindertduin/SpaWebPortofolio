export const formRules = {
    required: value => !!value || 'verplicht veld',
    counterMax200: value => value.length <= 200 || 'Maximaal 200 tekens',
    counterMax2000: value => value.length <= 2000 || 'Maximaal 2000 tekens',
    email: value => {
        return this.emailPattern.test(value) || 'Ongeldig email'
    },
}