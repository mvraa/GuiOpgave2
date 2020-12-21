<!--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-->
<!--Følgene kode er ikke lavet af os. Det taget fra et open source project fra github: https://github.com/alligatorio/vue-image-slider -->
<!--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-->

<template>
    <div>
        <h5 class="text-center">Latest fashion trends:</h5>
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
                    "https://cdn.trendhunterstatic.com/thumbs/hazmat-suit-fashion.jpeg",
                    "https://i.pinimg.com/originals/cd/78/e1/cd78e150ad22908af830c2991374abe6.jpg",
                    "https://i.pinimg.com/736x/da/81/ed/da81ed6b39388d37729193408f2cfdfb.jpg",
                    "https://cdn.trendhunterstatic.com/phpthumbnails/263/263667/263667_4_600.jpeg"
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