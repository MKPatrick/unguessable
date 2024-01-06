<script setup lang="ts">
import {  onUnmounted, ref, watch } from 'vue';


let intervallID=0;
let totalTimeToRun=100;
let elapsedTime = 0;


const props = defineProps({
  timeInSeconds:Number,
  start: Boolean,
})
const timeToDisplay=ref("");

onUnmounted(() => {
    StopTimer();
});

watch(
  () => props.start,
  (startValue) => {
    if(startValue==true)
    {
StartTimer();
    }
    else{
StopTimer();
    }
  })

const emit = defineEmits<{
  (e: 'timerFinished' ): void
}>()


if(props.start)
{
    StartTimer();
}


function StartTimer()
{

    totalTimeToRun=props.timeInSeconds!;
    DisplayTime();
    intervallID=  setInterval(onTick, 1000);

}


function StopTimer()
{
clearInterval(intervallID);
timeToDisplay.value="";
}


function onTick() {
  

    elapsedTime++;
    if (elapsedTime === totalTimeToRun) {
        emit("timerFinished");
        StopTimer();
    }


 DisplayTime();


  }

  function DisplayTime()
  {
    let timeLeft=totalTimeToRun-elapsedTime;
    if(timeLeft>60)
    {
         const minutes= timeLeft/60;
        const seconds=timeLeft%60;
        timeToDisplay.value=~~minutes +":" + seconds.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping:false});
   
        }
    else{
        timeToDisplay.value=timeLeft.toString();
    }

  }

</script>
<template>
<p class="timer">{{ timeToDisplay }}</p>
</template>

<style>

.timer
{

  font-family: 'Rubik Maps', system-ui;
}</style>