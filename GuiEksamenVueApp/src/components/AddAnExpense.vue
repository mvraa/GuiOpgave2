<template>
    <div>
        <table>
            <tr>
                <td><label>Amount:</label></td>
                <td><input v-model="expenseAmount" class="input" type="number" placeholder="Enter Expense in DKK"></td>
            </tr>
            <tr>
                <td><label>Note:</label></td>
                <td><input v-model="note" class="input" type="text" placeholder="Write note"></td>
            </tr>
        </table>
        <button class="btn btn-primary btn-block" @click="addExpense">Add Expense</button>
        <p>{{ msg }}</p>
    </div>
</template>

<script>
    import moment from 'moment'

    export default {
        props: ['jobId'],
        data() {
            return {
                expenseAmount: '',
                note: '',
                msg: ''
            }
        },
        methods: {
            addExpense() {

                var jsonthing = JSON.stringify({
                    modelId: parseInt(this.getModelId),
                    jobId: this.jobId,
                    date: this.getNow(),
                    text: this.note,
                    amount: this.expenseAmount
                });

                console.log(jsonthing);

                fetch('https://localhost:44368/api/Expenses', {
                    method: 'POST',
                    body: JSON.stringify({
                        maodelId: parseInt(this.getModelId),
                        jobId: this.jobId,
                        date: this.getNow(),
                        text: this.note,
                        amount: parseInt(this.expenseAmount)
                    }),
                    credentials: 'include',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                        'Content-Type': 'application/json'
                    }
                })
                    .then(res => {
                        if (res.status == 200 || res.status == 201) {
                            this.msg = 'Added the expense of ' + this.expenseAmount + ' DKK!';
                            return res.json();
                        }
                        else if (res.status == 403) {
                            this.msg = res.status + ': Access Denied!';
                        }
                    })
                    .then(responseJson => {
                        console.log(responseJson);
                        this.expenseAmount = '';
                        this.note = '';
                    })
                    .catch(error => {
                        console.error('Something bad happened: ' + error);
                    });
            },
            getNow() {
                return moment().format();
            }
        },
        computed: {
            getModelId() {
                return this.$store.getters.userId;
            }
        },
    }
</script>

