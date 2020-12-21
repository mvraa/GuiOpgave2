<template>
    <div class="container">
        <h1 class="text-center">Create</h1><br />
        <div class="row">
            <create-manager/>
        </div> 
    </div>
</template>

<script>
    import CreateManager from '../components/CreateManager.vue';

    export default {
        name: 'Create',
        components: {
            CreateManager
        }
    }
</script>

<style scoped>
</style>