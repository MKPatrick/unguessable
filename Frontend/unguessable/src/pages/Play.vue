<script setup lang="ts">
import { Ref, onMounted, onUnmounted, ref } from 'vue';
import Timer from '../components/Timer.vue'
import { useRoute } from 'vue-router'
import GamePreStart from '../components/GamePreStart.vue';
import {GameState} from '../classes/Gamestate.ts'
import {GuessState} from '../classes/GuessState.ts'
import {Word} from '../classes/Word.ts';
import WordGuessCard from '../components/WordGuessCard.vue';
import Success from '../components/Success.vue';
import Lose from '../components/Lose.vue';
import Finish from '../components/Finish.vue';
import axios from 'axios';
const route = useRoute();

const audioCorrect = new Audio('/ok.wav'); 
const audioNotCorrect = new Audio('/fail.mp3');
const countdown = new Audio('/countdown.mp3');

const gameTimer:Ref<number>=ref(10);
const gameTimerTrigger:Ref<boolean>=ref(false);
const words:Ref<Word[]>=ref([]);
const currentWord:Ref<Word>=ref(new Word());
const timeForInitalCountdown:Ref<number>=ref(3);


const selectedCategoriesFromParamters =route.params.categories as string;
const selectedCategories:Ref<number[]>= ref(JSON.parse(selectedCategoriesFromParamters));
let state:Ref<GameState>=ref(GameState.Preload);
let guessState:Ref<GuessState>=ref(GuessState.Unknown);
let wordsIncorrect:Array<Word>=[];
let wordsCorrect:Array<Word>=[];
 


 function PreloadTimerFinished()
{
  state.value=GameState.Started;
  MovementEnabler();
  gameTimerTrigger.value=true;
  currentWord.value=words.value.pop()!;
}

onMounted(()=>
{
  axios.post('https://localhost:7049/api/Words/WordsByCategory', {
    categoriesID: selectedCategories.value,
}).then((resp)=>
{
const data:Array<Word>=resp.data
  words.value=data;

});
  countdown.play();
});

onUnmounted(() => {
  window.removeEventListener("deviceorientation", handleOrientation);
});


function GameFinished()
{
state.value=GameState.Finished;
window.removeEventListener("deviceorientation", handleOrientation);
}

function MovementEnabler()
{
  //IOS?
  window.addEventListener("deviceorientation", handleOrientation);
}

function handleOrientation(event:any) {

  if(event.gamma==0)return;

if(guessState.value===GuessState.Unknown)
{
  if(event.gamma>-64 && event.gamma<-40)
{
  wordsCorrect.push(currentWord.value);
  audioCorrect.play();
  guessState.value=GuessState.Guessed;
  setTimeout(NextWord, 1500);
}
else if(event.gamma<64 && event.gamma>20)
{
  wordsIncorrect.push(currentWord.value);
  audioNotCorrect.play();
  guessState.value=GuessState.NotGuessed;
  setTimeout(NextWord, 2100);
}


}
  
}

function NextWord()
{
  guessState.value=GuessState.Unknown;
  currentWord.value=words.value.pop()!;
}



</script>
<template>

<div v-if="state==GameState.Finished">
<Finish :wordsCorrect="wordsCorrect" :wordsIncorrect="wordsIncorrect" />
</div>

<div class="rotated timer-top " v-if="state!=GameState.Finished">
  <Timer style="font-size: x-large;" class="" @timerFinished="GameFinished" v-bind:timeInSeconds=gameTimer v-bind:start=gameTimerTrigger />
</div>

<div class="center-container">
<div class="rotated text-center">
 
  <div v-if="state==GameState.Preload">
<Timer style="font-size: x-large;" @timerFinished="PreloadTimerFinished" v-bind:timeInSeconds=timeForInitalCountdown v-bind:start=true />
<GamePreStart />
</div>


<div v-if="state==GameState.Started">
<WordGuessCard  v-if="guessState==GuessState.Unknown" :word="currentWord?.word" :wordForbidden1="currentWord.wordForbidden1" :wordForbidden2="currentWord.wordForbidden1" :wordForbidden3="currentWord.wordForbidden3" />
<Lose  v-if="guessState==GuessState.NotGuessed" />
<Success  v-if="guessState==GuessState.Guessed" />
</div>


</div>

</div>




</template>
<style>
.rotated
{
  transform: rotate(-90deg);
  -webkit-transform: rotate(-90deg);
  -moz-transform: rotate(-90deg);
  -ms-transform: rotate(-90deg);
  -o-transform: rotate(-90deg);
}


.timer-top
{
  position: absolute;
  top: 45%;
  left:30px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.center-container {
      margin: 0;
      height: 100vh;
      display: flex;
      justify-content: center;
      align-items: center;
    }
</style>