<template>
    <div id="app">
        <my-header />
        <router-view></router-view>
    </div>
</template>

<script>
    import MyHeader from './components/Header.vue';

    export default {
        name: 'app',
        components: {
            MyHeader
        }
    };
</script>

<style>
    body {
        background-color: rgb(40,45,50) !important;
    }



    nav {
        background-color: rgb(30,35,40) !important;
    }

    h1 {
        color: rgb(230,230,230);
    }

    h2 {
        color: rgb(230,230,230);
    }

    h5 {
        color: rgb(220,220,220);
    }

    label {
        color: rgb(220,220,220);
    }
</style>
