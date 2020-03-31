import { UserlistTemplate } from "../templates/userlist-template.js";

const UserList = {
    template: UserlistTemplate,
    props: ['isDetails'],
    created: function () {
    },
    mounted: function () {
        this.load();
    },
    data: function () {
        return {
            items: [],
            headers: [
                { text: 'Фамилия', value: 'surname' },
                { text: 'Имя', value: 'firstName' },
                { text: 'Адрес', value: 'address' },
                { text: 'Действия', value: 'action', sortable: false }
            ]            
        };
    },
    methods: {
        load() {
            axios
                .get('/api/v1/users')
                .then(response => {
                    console.log(response);                
                    this.items = response.data;
                    // test response.status = 200   data
                })
                .catch(error => {
                    console.error(error);
                });
        },
        async refresh() {
            this.queries = [];
        },
        editItem(item) {
            console.log(item);
            this.$router.push({ name: 'userById', params: { id: item.id } });
        },
        deleteItem(item) {
            axios.delete('/api/v1/users/' + item.id)
                .then((response) => {
                    console.log(response);
                    this.load();
                })
                .catch((error) => {
                    console.error(error);
                });
        }
    }

};

export { UserList };