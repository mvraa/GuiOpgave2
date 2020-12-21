<template>
    <div>
        <h1>Login</h1>
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div v-html="msg"></div>
                    <div class="form-group">
                        <label class="control-label">Email</label>
                        <input v-model="username" class="form-control" type="text" />
                    </div>
                    <div class="form-group">
                        <label class="control-label">Password</label>
                        <input v-model="password" class="form-control" type="password" />
                    </div>
                    <div class="form-group">
                        <input style="margin-top:30px" value="Login" @click="Sub" class="btn btn-primary btn-block" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Login',
        data() {
            return {
                username: '',
                password: '',
                msg: '',
                modelId: ''
            }
        },
        methods: {
            Sub() {
                fetch('https://localhost:44368/api/Account/login', {
                    method: 'POST',
                    body: JSON.stringify({
                        email: this.username,
                        password: this.password
                    }),
                    headers: new Headers({
                        'Content-Type': 'application/json'
                    })
                })
                    .then(res => res.json())
                    .then((token) => {
                        localStorage.setItem("token", token.jwt);
                        if (token.jwt == undefined)
                            this.msg = '<div class="alert alert-danger"><strong >Unsuccesful!</strong > Login might be incorrect!</div >';
                        else {
                            let jwtJson = this.parseJwt(token.jwt);
                            this.msg = '<div class="alert alert-success"><strong >Success!</strong > Login info is correct!</div >';
                            this.$store.commit('login', jwtJson.ModelId);
                            this.$router.push('/');
                        }
                    })
                    .catch(error => console.error('Error:', error));
            },

            parseJwt(token) {
                var base64Url = token.split('.')[1];
                var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
                var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
                    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
                }).join(''));

                console.log(jsonPayload);

                return JSON.parse(jsonPayload);
            }
        }
    }
</script>

<style scoped>
    .logo {
        height: 50px;
        width: 50px;
    }
</style>