<template>
    <div>
        <div class="container">
            <main role="main" class="pb-3">
                <h1 class="text-center">Jobs</h1>
                <list-jobs></list-jobs>
            </main>
        </div>
    </div>
</template>

<script>
    import ListJobs from '../components/ListJobs.vue';


    export default {
        name: 'ListOfJobs',
        components: {
            ListJobs
        }
    };

</script>

<style scoped>
</style>