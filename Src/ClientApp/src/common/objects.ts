export const emailPattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

export const formRules = {
    required: (value:any) => !!value || 'verplicht veld',
    counterMax200: (value:any) => value.length <= 200 || 'Maximaal 200 tekens',
    counterMax2000: (value:any) => value.length <= 2000 || 'Maximaal 2000 tekens',
    email: (value:any) => {
        return emailPattern.test(value) || 'Ongeldig email'
    },
}