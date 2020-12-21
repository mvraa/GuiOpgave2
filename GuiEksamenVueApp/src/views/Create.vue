<template>
    <div class="container">
        <h1 class="text-center">Create</h1><br />
        <div class="row">
            <create-user/>
        </div> 
    </div>
</template>

<script>
    import CreateUser from '../components/CreateUser.vue';

    export default {
        name: 'Create',
        components: {
            CreateUser
        }
    }
</script>

<style scoped>
</style>