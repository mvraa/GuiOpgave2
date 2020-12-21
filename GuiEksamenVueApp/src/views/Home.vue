<template>
    <div>
        <div class="container">
            <main role="main" class="pb-3">
                <h1 class="text-center">Home</h1>
            </main>
        </div>
        <Slider />
    </div>
</template>

<script>
    import Slider from '../components/Slider.vue';

    export default {
        name: 'Home',
        components: {
            Slider
        }
    };
</script>