import { UserTemplate } from "../templates/user-template.js";

const User = {
    template: UserTemplate,
    props: {
        id: {
            default: null,
            type: String
        }
    },
    created: async function () {
    },
    mounted: function () {
        this.load();
    },
    data: function () {
        return {
            item: {},
            valid: true,
            lazy: false, 
            firstNameRules: [
                v => !!v || 'Поле Имя обязательно'
            ],
            surnameRules: [
                v => !!v || 'Поле Фамилия обязательно'
            ],
            emailRules: [
                v => !!v || 'Поле E-mail обязательно',
                v => /.+@.+\..+/.test(v) || 'E-mail must be valid'
            ],
            genders: [
                { value: 1, text: 'Мужской' },
                { value: 2, text: 'Женский' }
            ]
        };
    },
    methods: {
        load() {
            if (this.id) {
                axios
                    .get('/api/v1/users/' + this.id)
                    .then(response => {
                        console.log(response);
                        this.item = response.data;
                        // test response.status = 200   data
                    })
                    .catch(error => {
                        console.error(error);
                    });
            }
            else {
                this.item = {};
            }
        },
        save() {
            if (this.id) {
                axios.put('/api/v1/users/' + this.id, this.item)
                    .then((response) => {
                        this.return();
                    })
                    .catch((error) => {
                        console.error(error);
                    });
            }
            else {
                axios.post('/api/v1/users', this.item)
                    .then((response) => {
                        this.return();
                    })
                    .catch((error) => {
                        console.error(error);
                    });
            }
        },
        cancel() {
            this.return();
        },
        return() {
            this.$router.push({ name: 'list' });
        }
    },
    watch: {
        id: function (val) {
            this.load();
        }
    }
};

export { User };