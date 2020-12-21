<template>
    <div id="app">
        <label class="control-label">Frequency(Hz)</label>
        <input id="freqEle" class="input form-control" type="number" placeholder="Interval" />
        
        <label class="control-label">Time duration(seconds)</label>
        <input id="timeEle" class="input form-control" type="number" placeholder="Time" />

        <div class="form-group text-center">
            <input id="start" type="button" class="btn btn-primary" value="Start" @click="start" />
            <input id="stop" type="button" class="btn btn-danger" value="Stop" @click="stop" />
        </div>
        <br /><br />
        <p id="timeMsg"></p>

        <p id="freqMsg"></p>
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
            },

            start: function () {
                this.duration = timeEle.value;
                this.intervalTime = setInterval(this.intervalHandle.bind(this), parseInt(freqEle.value));
                this.durationTimer = setInterval(this.durationHandle.bind(this), 1000);
            },
            stop: function () {
                clearInterval(this.intervalTime);
                clearInterval(this.durationTimer);
            },

            intervalHandle: function () {
                if (freqMsg.innerHTML == "Breathe in") {
                    freqMsg.innerHTML = "Breathe out";
                }
                else {
                    freqMsg.innerHTML = "Breathe in";
                }
            },
            durationHandle: function () {
                if (this.duration <= 0) {
                    this.stop();
                    return;
                }
                this.duration--;
                timeMsg.innerHTML = "Time left: " + this.duration;
            }
        }
    };
</script>

<style scoped>
    #freqMsg {
        font-size: 40px;
    }
    input{
        margin: 20px;
    }
    label{
        font-size:20px;
    }
    .btn{
        font-size:25px;
    }
</style>