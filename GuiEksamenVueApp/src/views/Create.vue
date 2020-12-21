<template>
    <div class="container">
        <h1 class="text-center">Create</h1><br />
        <div class="row">
            <div class="col-md-4">
                <create-job />
            </div>
            <div class="col-md-4">
                <create-manager />
            </div>
            <div class="col-md-4">
                <create-model />
            </div>
        </div> 
    </div>
</template>

<script>
    import CreateJob from '../components/CreateJob.vue';
    import CreateManager from '../components/CreateManager.vue';
    import CreateModel from '../components/CreateModel.vue';

    export default {
        name: 'Create',
        components: {
            CreateJob,
            CreateManager,
            CreateModel
        }
    }
</script>

<style scoped>
</style>