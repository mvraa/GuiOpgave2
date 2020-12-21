<template>
    <div class="container">
        <main role="main" class="pb-3">
            <login-form/>
        </main>
    </div>
</template>

<script>
    import LoginForm from '../components/LoginForm.vue';

    export default {
        name: 'Login',
        components: {
            LoginForm
        }
    };
</script>