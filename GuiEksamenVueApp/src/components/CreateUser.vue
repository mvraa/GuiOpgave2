<template>
    <div>
        <h2>Create User</h2>
        <form class="form-group">
            <div class="form-group">
                <label class="control-label">Firstname</label>
                <input v-model="Firstname" class="input form-control" type="text" placeholder="Firstname">
            </div>

            <div class="form-group">
                <label class="control-label">Lastname</label>
                <input v-model="Lastname" class="input form-control" type="text" placeholder="Lastname">
            </div>

            <div class="form-group">
                <label class="control-label">Email</label>
                <input v-model="Email" class="input form-control" type="text" placeholder="Email">
            </div>

            <div class="form-group">
                <label class="control-label">Password</label>
                <input v-model="Password" class="input form-control" type="text" placeholder="Password">
            </div>

            <div class="form-group">
                <label class="control-label">Frequency</label>
                <input v-model="Freq" class="input form-control" type="number" placeholder="Frequency">
            </div>

            <div class="form-group">
                <label class="control-label">Duration</label>
                <input v-model="Duration" class="input form-control" type="number" placeholder="Duration">
            </div>

            <div class="form-group">
                <button type="submit" @click="CreateUser" class="btn btn-primary">Create</button>
            </div>

            <div v-html="msg"></div>
        </form>
    </div>
</template>

<script>

    export default {
        name: 'CreateUser',
        data() {
            return {
                Firstname: '',
                Lastname: '',
                Email: '',
                Password: '',
                Freq: '',
                Duration: '',
                msg: ''
            }
        },
        methods: {
            CreateUser() {
                fetch('https://localhost:44368/api/Managers', {
                    method: 'POST',
                    body: JSON.stringify({
                        firstname: this.Firstname,
                        lastname: this.Lastname,
                        email: this.Email,
                        password: this.Password,
                        freq: parseInt(this.Freq),
                        duration: parseInt(this.Duration)
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
        }
    }
</script>