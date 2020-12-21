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

    h1,h2,h3,h4,label,p {
        color: rgb(230,230,230);
    }
</style>
