<template>
    <div>
        
        <h2>Create Job</h2>
        <form class="form-group">
            <div class="form-group">
                <label class="control-label">Customer</label>
                <input v-model="Customer" class="input form-control" type="text" placeholder="Customer">
            </div>

            <div class="form-group">
                <label class="control-label">StartDate</label>
                <input v-model="StartDate" class="input form-control" type="date" placeholder="Date">
            </div>

            <div class="form-group">
                <label class="control-label">Days</label>
                <input v-model="Days" class="input form-control" type="number" placeholder="Days">
            </div>
            <div class="form-group">
                <label class="control-label">Location</label>
                <input v-model="Location" class="input form-control" type="text" placeholder="Location">
            </div>

            <div class="form-group">
                <label class="control-label">Comments</label>
                <input v-model="Comments" class="input form-control" type="text" placeholder="Comments">
            </div>

            <div class="form-group">
                <button type="submit" @click="CreateJob" class="btn btn-primary">Create</button>
            </div>

            <div v-html="msg"></div>
        </form>
    </div>
</template>

<script>

export default {
name: 'CreateJob',
    data(){
        return{
            Customer: '',
            StartDate: '',
            Days: '',
            Location: '',
            Comments: '',
            msg: ''
        }
    },
    methods:{
        CreateJob(){
            fetch('https://localhost:44368/api/Jobs', {
                method: 'POST',
                body: JSON.stringify({
                    customer: this.Customer,
                    startDate: this.StartDate,
                    days: parseInt(this.Days),
                    location: this.Location,
                    comments: this.Comments
                }),
                credentials: 'include',
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem("token"),
                    'Content-Type': 'application/json'
                }
            })
                .then(res => {
                    if (res.status !== 201) {
                        this.msg = '<div class="alert alert-danger"><strong >Unsuccesful!</strong >!</div >';
                    }
                    else {
                        this.msg = '<div class="alert alert-success"><strong >Success!</strong ></div >';
                    }
                });
        }
    },
    mounted() {
            var id = this.$store.getters.userId;

            if (id !== '-1') {
                this.$router.push('/');
            }
    }
}
</script>