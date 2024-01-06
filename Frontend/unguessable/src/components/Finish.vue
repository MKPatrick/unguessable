<script setup lang="ts">
import { Word } from '../classes/Word';


defineProps({
  wordsCorrect:Array<Word>,
    wordsIncorrect:Array<Word>
})

</script>
<template>
  <div class="container text-center">
   <div class="row">
    <div class="col-6">
    <div class="text-center">
<li class="text-success" v-for="item in wordsCorrect">
  {{ item.Word }}
</li>
</div>
<div class="col-6">
<li class="text-danger" v-for="item in wordsIncorrect">
  {{ item.Word }}
</li>
</div>
</div>

<router-link to="/CategorySelection">
    <button class="btn btn-primary">Zurück zur Kategorien auswahl</button>
    </router-link>

</div>
</div>
</template>