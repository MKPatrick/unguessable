<script setup lang="ts">
import { Word } from '../classes/Word';


defineProps({
  wordsCorrect:Array<Word>,
    wordsIncorrect:Array<Word>
})

</script>
<template>
<div class="container mt-3">
<h3 class="text-center mt-3">Hier die Übersicht deiner Wörter</h3>
    <div class="text-center">
<p class="text-success" v-for="item in wordsCorrect">
  {{ item.word }}
</p>
<p class="text-danger" v-for="item in wordsIncorrect">
  {{ item.word }}
</p>

<router-link to="/CategorySelection">
    <button class="btn btn-primary">Zurück zu den Kategorien</button>
    </router-link>

</div>
</div>
</template>

<style>


</style>