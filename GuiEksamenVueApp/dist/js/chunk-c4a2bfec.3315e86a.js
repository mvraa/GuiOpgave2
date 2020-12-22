(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-c4a2bfec"],{"5abc":function(t,e,n){},afbf:function(t,e,n){},cbb0:function(t,e,n){"use strict";n.r(e);var a=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"container"},[n("main",{staticClass:"pb-3",attrs:{id:"main",role:"main"}},[n("breathe-app")],1)])},i=[],r=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{attrs:{id:"app"}},[n("h1",{staticClass:"text-center",attrs:{id:"title"}},[t._v("Breathe")]),n("hr"),n("label",{staticClass:"control-label"},[t._v("Frequency(Hz)")]),n("input",{staticClass:"input form-control",attrs:{id:"freqEle",type:"number",placeholder:"Interval"}}),n("label",{staticClass:"control-label"},[t._v("Time duration(seconds)")]),n("input",{staticClass:"input form-control",attrs:{id:"timeEle",type:"number",placeholder:"Time"}}),n("div",{staticClass:"form-group text-center"},[n("input",{staticClass:"btn btn-primary",attrs:{id:"start",type:"button",value:"Start"},on:{click:t.start}}),n("input",{staticClass:"btn btn-danger",attrs:{id:"stop",type:"button",value:"Stop"},on:{click:t.stop}})]),n("hr"),t._m(0)])},s=[function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"text-center"},[n("p",{attrs:{id:"timeMsg"}}),n("p",{attrs:{id:"freqMsg"}}),n("p",{attrs:{id:"testMsg"}})])}],l={name:"Breathe",data:function(){return{intervalTime:null,durationTimer:null}},mounted:function(){this.myConst()},methods:{myConst:function(){this.fetchData(this.getUserId())},start:function(){this.duration=timeEle.value,this.intervalTime=setInterval(this.intervalHandle.bind(this),parseInt(freqEle.value)),this.durationTimer=setInterval(this.durationHandle.bind(this),1e3)},stop:function(){clearInterval(this.intervalTime),clearInterval(this.durationTimer)},intervalHandle:function(){"Breathe in"==freqMsg.innerHTML?freqMsg.innerHTML="Breathe out":freqMsg.innerHTML="Breathe in"},durationHandle:function(){this.duration<=0?this.stop():(this.duration--,timeMsg.innerHTML="Time left: "+this.duration)},fetchData:function(t){console.log(t),fetch("https://localhost:44368/api/User/"+t,{credentials:"include",headers:{Authorization:"Bearer "+localStorage.getItem("token"),"Content-Type":"application/json"}}).then(function(t){return t.json()}).then(function(t){title.innerHTML="Hello, "+t.firstName+" "+t.lastName,freqEle.value=t.freq,timeEle.value=t.duration})},fetchTimeData:function(t){console.log(t),fetch("https://localhost:44368/api/User/usertime"+t,{credentials:"include",headers:{Authorization:"Bearer "+localStorage.getItem("token"),"Content-Type":"application/json"}}).then(function(t){return t.json()}).then(function(t){title.innerHTML="Hello, "+t.firstName+" "+t.lastName,freqEle.value=t.freq,timeEle.value=t.duration})},getUserId:function(){return this.$store.getters.userId}}},o=l,c=(n("f5d2"),n("2877")),u=Object(c["a"])(o,r,s,!1,null,"772c6894",null),f=u.exports,d={name:"Home",components:{BreatheApp:f}},h=d,p=(n("f2f4"),Object(c["a"])(h,a,i,!1,null,"57cae8d8",null));e["default"]=p.exports},f2f4:function(t,e,n){"use strict";n("5abc")},f5d2:function(t,e,n){"use strict";n("afbf")}}]);
//# sourceMappingURL=chunk-c4a2bfec.3315e86a.js.map