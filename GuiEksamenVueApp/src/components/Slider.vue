<!--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-->
<!--Følgene kode er ikke lavet af os. Det taget fra et open source project fra github: https://github.com/alligatorio/vue-image-slider -->
<!--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-->

<template>
    <div>
        <transition-group name="fade" tag="div">
            <div v-for="i in [currentIndex]" :key="i">
                <img :src="currentImg" />
            </div>
        </transition-group>
        <a class="prev" @click="prev" href="#">&#10094; Previous</a>
        <a class="next" @click="next" href="#">&#10095; Next</a>
    </div>
</template>

<style>
    .fade-enter-active,
    .fade-leave-active {
        transition: all 0.9s ease;
        overflow: hidden;
        visibility: visible;
        position: absolute;
        width: 100%;
        opacity: 1;
    }

    .fade-enter,
    .fade-leave-to {
        visibility: hidden;
        width: 100%;
        opacity: 0;
    }

    img {
        height: 1500px;
        width: 100%;
    }

    .prev, .next {
        cursor: pointer;
        position: absolute;
        top: 40%;
        width: auto;
        padding: 16px;
        color: grey;
        font-weight: bold;
        font-size: 18px;
        transition: 0.7s ease;
        border-radius: 0 4px 4px 0;
        text-decoration: none;
        user-select: none;
    }

    .next {
        right: 0;
    }

    .prev {
        left: 0;
    }

        .prev:hover, .next:hover {
            background-color: rgba(20,20,20,20.9);
        }
</style>

<script>
    export default {
        name: "Slider",
        data() {
            return {
                images: [
                    "https://i.ytimg.com/vi/grVvvs3Mx3U/maxresdefault.jpg",
                    "https://i.ytimg.com/vi/tHwP_eAFeDg/maxresdefault.jpg",
                    "https://i.ytimg.com/vi/SNNquGgYvbs/maxresdefault.jpg",
                    "https://i.ytimg.com/vi/yeILl2yFzg8/maxresdefault.jpg"
                ],
                timer: null,
                currentIndex: 0
            };
        },

        mounted: function () {
            this.startSlide();
        },

        methods: {
            startSlide: function () {
                this.timer = setInterval(this.next, 4000);
            },

            next: function () {
                this.currentIndex += 1;
            },
            prev: function () {
                this.currentIndex -= 1;
            }
        },

        computed: {
            currentImg: function () {
                return this.images[Math.abs(this.currentIndex) % this.images.length];
            }
        }
    };
</script>