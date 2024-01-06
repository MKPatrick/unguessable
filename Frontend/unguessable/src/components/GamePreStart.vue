<script setup lang="ts">
import { ref } from 'vue';


const catPlaying=ref("");
const randomInteger=getRandomInt(3);
if(randomInteger==0)
{
    catPlaying.value="/cat1.json";
}
else if(randomInteger==1)
{
    catPlaying.value="/cat2.json";
}
else if(randomInteger==2)
{
    catPlaying.value="/cat3.json";
}

function getRandomInt(max:number) {
  return Math.floor(Math.random() * max);
}

</script>
<template>

<div class="container">
<h1>Mach dich bereit!</h1>
<lottie-player style="height: 30vh"   :src="catPlaying" background="transparent" speed="1" direction="1" mode="normal" loop  autoplay></lottie-player>
</div>
</template>

