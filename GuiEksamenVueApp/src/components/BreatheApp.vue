<template>
    <div id="app">
        <input id="interval" type="number" placeholder="Interval" />
        <input id="timeInput" type="number" placeholder="Time" />

        <input id="start" type="button" value="Start" @click="start" />
        <input id="stop" type="button" value="Stop" @click="stop" />
        <br /><br />
        <p id="timeMsg"></p>

        <p id="msg"></p>
    </div>
</template>

<script>
    export default {
        name: 'Breathe',
        data() {
            return {
                intervalTime: null,
                durationTimer: null,
                duration: 0
            };
        },

        mounted: function () {
            this.myConst();
        },

        methods: {
            myConst: function () {
                console.log(timeInput);
                this.duration = 10;
            },

            start: function () {
                var self = this;

                this.intervalTime = setInterval(function () {
                    if (msg.innerHTML == "Breathe in") {
                        msg.innerHTML = "Breathe out";
                    }
                    else {
                        msg.innerHTML = "Breathe in";
                    }
                }, parseInt(interval.value));

                this.durationTimer = setInterval(function () {
                    if (self.duration <= 0) {
                        self.stop();
                        return;
                    }
                    self.duration--;
                    console.log(self.duration);
                    timeMsg.innerHTML = "Time left: " + self.duration;
                }, 1000);
            },
            stop: function () {
                clearInterval(this.intervalTime);
                clearInterval(this.durationTimer);
            }
        }
    };
</script>

<style scoped>
    #msg {
        font-size: 40px;
    }
</style>