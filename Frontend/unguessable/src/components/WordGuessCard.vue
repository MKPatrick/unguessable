<script setup lang="ts">

defineProps({
  word:String,
  wordForbidden1: String,
  wordForbidden2: String,
  wordForbidden3: String,
})


</script>
<template>
  <div class="mainCard">
<h1>{{ word }}</h1>
<br/>
<br/>
<div class="container row">
<div class="col-4">
<h4>{{ wordForbidden1}}</h4>
</div>

<div class="col-4">
<h4>{{ wordForbidden2}}</h4>
</div>


<div class="col-4">
<h4>{{ wordForbidden3}}</h4>
</div>

</div>
</div>
</template>

<style>

.mainCard
{
  width: 90vh;
}
</style>