<template>
    <div class="container">
        <main id="main" role="main" class="pb-3">
            <breathe-app />
        </main>
    </div>
</template>

<script>
    import BreatheApp from '../components/BreatheApp.vue';

    export default {
        name: 'Home',
        components: {
            BreatheApp
        }
    };
</script>

<style scoped>
    #msg{
        font-size: 40px;
    }
</style>