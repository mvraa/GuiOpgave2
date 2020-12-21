<template>
    <div>
        <div v-if="loading">
            <p>Please wait while we load jobs!</p>
        </div>
        <div v-else>
            <b-table-simple responsive="true" hover striped dark>
                <b-thead>
                    <b-tr>
                        <b-th>Start Date</b-th>
                        <b-th>Customer</b-th>
                        <b-th>Days</b-th>
                        <b-th>Location</b-th>
                        <b-th>Comments</b-th>
                        <b-th v-if="userId >= 0">Add Expense</b-th>
                        <b-th v-if="userId == -1">Add/Remove Model</b-th>
                    </b-tr>
                </b-thead>
                <b-tbody>
                    <b-tr v-for="job in jobs" :key="job.efJobId">
                        <b-td>{{ job.startDate | formatDate }}</b-td>
                        <b-td>{{ job.customer }}</b-td>
                        <b-td>{{ job.days }}</b-td>
                        <b-td>{{ job.location }}</b-td>
                        <b-td>{{ job.comments }}</b-td>
                        <b-td v-if="userId >= 0"><AddAnExpense :jobId="job.efJobId"></AddAnExpense></b-td>
                        <b-td v-if="userId == -1"><AddRemoveModel :jobId="job.efJobId"></AddRemoveModel></b-td>
                    </b-tr>
                </b-tbody>
            </b-table-simple>
        </div>
    </div>
</template>

<script>
    import AddAnExpense from '@/components/AddAnExpense.vue'
    import AddRemoveModel from '@/components/AddRemoveModel.vue'

    export default {
        name: "ListOfJobs",
        data() {
            return {
                loading: true,
                message: '',
                jobs: [],
                userId: this.getUserId
            }
        },
        components: {
            AddAnExpense,
            AddRemoveModel
        },
        mounted() {
            this.userId = this.$store.getters.userId;
            fetch('https://localhost:44368/api/Jobs', {
                method: 'GET',
                credentials: 'include',
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem("token"),
                    'Content-Type': 'application/json'
                }
            })
                .then(res => {
                    if (res.status == 200) {
                        return res.json();
                    }
                })
                .then(responseJson => {
                    console.log(responseJson);
                    this.jobs = responseJson
                    this.loading = false;
                })
                .catch(error => {
                    this.loading = false;
                    this.message = 'An error has occured' + error;

                });
        },
        computed: {
            getUserId() {
                return this.$store.getters.userId;
            }
        }
    }
</script>

<style scoped>
</style>