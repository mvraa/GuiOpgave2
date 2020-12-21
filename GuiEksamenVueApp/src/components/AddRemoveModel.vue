<template>
    <div>
        <table>
            <tr>
                <td><input v-model="modelId" class="input" type="number" placeholder="Enter Model-ID"></td>
            </tr>
        </table>
        <div style="margin-top: 10px">
            <button style="margin-right: 15px" class="btn btn-primary" @click="addModel"> Add </button>
            <button class="btn btn-danger" @click="deleteModel"> Remove </button>

        </div>
        <p>{{ statusMsg }}</p>

    </div>
</template>

<script>
    export default {
        props: ['jobId'],
        data() {
            return {
                modelId: '',
                statusMsg: ''
            }
        },
        methods: {
            addModel() {
                fetch('https://localhost:44368/api/Jobs/' + this.jobId + '/model/' + this.modelId, {
                    method: 'POST',
                    credentials: 'include',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                        'Content-Type': 'application/json'
                    }
                })
                    .then(res => {
                        if (res.status == 200 || res.status == 201) {
                            this.statusMsg = 'Added model with ID ' + this.modelId + '!';
                        }
                        else if (res.status == 403) {
                            this.statusMsg = res.status + ': Access Denied!';
                        }
                        else {
                            this.statusMsg = res.status + ': Error!';
                        }

                        return res.json();
                    })
                    .then(responseJson => {
                        console.log(responseJson);
                    })
                    .catch(error => {
                        console.error('Something bad happened: ', error);
                    });
            },
            deleteModel() {
                fetch('https://localhost:44368/api/Jobs/' + this.jobId + '/model/' + this.modelId, {
                    method: 'DELETE',
                    credentials: 'include',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                        'Content-Type': 'application/json'
                    }
                })
                    .then(res => {
                        if (res.status == 200 || res.status == 202) {
                            this.statusMsg = 'Removed model with ID ' + this.modelId + '!';
                        }
                        else if (res.status == 403) {
                            this.statusMsg = res.status + ': Access Denied!';
                        }
                        else {
                            this.statusMsg = res.status + ': Error!';
                        }

                        return res.json();
                    })
                    .then(responseJson => {
                        console.log(responseJson);
                    })
                    .catch(error => {
                        console.error('Something bad happened: ', error);
                    });
            }
        }
    }
</script>

<style scoped>

    p {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size: small;
        margin: 5px;
    }
</style>