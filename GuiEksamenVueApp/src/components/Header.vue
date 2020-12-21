

<template>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-dark box-shadow mb-3">
        <div class="container">
            <router-link class="navbar-brand" to="/"><img class="logo" src="../assets/logo.png" /></router-link>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                <ul class="navbar-nav flex-grow-1">
                    <li class="nav-item" v-if="loggedIn">
                        <router-link class="nav-link text-light" to="/Breathe">Breathe</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link text-light" to="/create">Sign up</router-link>
                    </li>
                    <li class="nav-item" v-if="!loggedIn">
                        <router-link class="nav-link text-light" to="/login">Login</router-link>
                    </li>
                    <li class="nav-item" v-if="loggedIn">
                        <a class="nav-link text-light" to="/login" @click="logout">Logout</a>
                    </li>
                </ul>
            </div>
            <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">

            </div>
        </div>
    </nav>
</template>

<script>
    export default {
        name: 'MyHeader',
        methods: {
            logout() {
                this.$store.dispatch('logout');
                this.$router.push('/'); // Redirect to Home
            }
        },
        computed: {
            loggedIn() {
                return this.$store.getters.isLoggedIn;
            },
            isManager() {
                let id = this.$store.getters.userId;
            },
            isModel() {
                let id = this.$store.getters.userId;
            }
        }
    }
</script>

<style scoped>
    .logo {
        height: 50px;
        width: 50px;
    }

    a:hover {
        cursor: pointer;
    }
</style>