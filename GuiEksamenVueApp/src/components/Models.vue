<template>
    <div v-if="isLoading">
        <p>Loading...</p>
    </div>
    <div v-for="model in models" :key="model.efModelId">
        <p> {{ model.email }}</p>
    </div>
</template>

<script>    export default {
        name: 'Models',
        data() {
            return {
                isLoading: true,
                message: '',
                models: []
            }
        },
        methods: {
            GetModels() {
                fetch('https://localhost:44368/api/Models', {
                    method: 'GET',
                    credentials: 'include',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                        'Content-Type': 'application/json'
                    }
                }).then(response => {
                    if (response.status == 200) {
                        return response.json();//uploading json data
                    }
                    })
                    .then(responseJson => {
                        this.models = responseJson;
                        this.isLoading = false;
                    }).catch(error => {
                        this.isLoading = false;
                        this.message = 'Error occured' + error;
                    });
            }
        },
        mounted() {
            this.GetModels();
        }
    }
</script>

<style scoped>
    /*add styling*/
</style>