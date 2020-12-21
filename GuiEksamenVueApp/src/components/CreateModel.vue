<template>
    <div>
        <h2>Create Model</h2>
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
                <label class="control-label">PhoneNo</label>
                <input v-model="PhoneNo" class="input form-control" type="text" placeholder="PhoneNo">
            </div>

            <div class="form-group">
                <label class="control-label">AddresLine1</label>
                <input v-model="AddresLine1" class="input form-control" type="text" placeholder="AddresLine1">
            </div>

            <div class="form-group">
                <label class="control-label">AddresLine2</label>
                <input v-model="AddresLine2" class="input form-control" type="text" placeholder="AddresLine2">
            </div>

            <div class="form-group">
                <label class="control-label">Zip</label>
                <input v-model="Zip" class="input form-control" type="text" placeholder="Zip">
            </div>

            <div class="form-group">
                <label class="control-label">City</label>
                <input v-model="City" class="input form-control" type="text" placeholder="City">
            </div>

            <div class="form-group">
                <label class="control-label">Country</label>
                <input v-model="Country" class="input form-control" type="text" placeholder="Country">
            </div>

            <div class="form-group">
                <label class="control-label">BirthDate</label>
                <input v-model="BirthDate" class="input form-control" type="date" placeholder="BirthDate">
            </div>

            <div class="form-group">
                <label class="control-label">Nationality</label>
                <input v-model="Nationality" class="input form-control" type="text" placeholder="Nationality">
            </div>

            <div class="form-group">
                <label class="control-label">Height</label>
                <input v-model="Height" class="input form-control" type="number" placeholder="Height">
            </div>

            <div class="form-group">
                <label class="control-label">ShoeSize</label>
                <input v-model="ShoeSize" class="input form-control" type="number" placeholder="ShoeSize">
            </div>

            <div class="form-group">
                <label class="control-label">HairColor</label>
                <input v-model="HairColor" class="input form-control" type="text" placeholder="HairColor">
            </div>

            <div class="form-group">
                <label class="control-label">EyeColor</label>
                <input v-model="EyeColor" class="input form-control" type="text" placeholder="EyeColor">
            </div>

            <div class="form-group">
                <label class="control-label">Comments</label>
                <input v-model="Comments" class="input form-control" type="text" placeholder="Comments">
            </div>

            <div class="form-group">
                <button type="submit" @click="CreateModel" class="btn btn-primary">Create</button>
            </div>

            <div v-html="msg"></div>
        </form>
    </div>
</template>

<script>

    export default {
        name: 'CreateModel',
        data() {
            return {
                Firstname: '',
                Lastname: '',
                Email: '',
                Password: '',
                PhoneNo: '',
                AddresLine1: '',
                AddresLine2: '',
                Zip: '',
                City: '',
                Country: '',
                BirthDate: '',
                Nationality: '',
                Height: '',
                ShoeSize: '',
                HairColor: '',
                EyeColor: '',
                Comments: '',
                msg: ''
            }
        },
        methods: {
            CreateModel() {
                fetch('https://localhost:44368/api/Models', {
                    method: 'POST',
                    body: JSON.stringify({
                        firstname: this.Firstname,
                        lastname: this.Lastname,
                        email: this.Email,
                        password: this.Password,
                        phoneNo: this.PhoneNo,
                        addresLine1: this.AddresLine1,
                        addresLine2: this.AddresLine2,
                        zip: this.Zip,
                        city: this.City,
                        country: this.Country,
                        birthDate: this.BirthDate,
                        nationality: this.Nationality,
                        height: parseInt(this.Height),
                        shoeSize: parseInt(this.ShoeSize),
                        hairColor: this.HairColor,
                        eyeColor: this.EyeColor,
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