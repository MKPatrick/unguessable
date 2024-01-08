<script setup lang="ts">


</script>
<template>
<div class="container page">
  <div class="row">
<h1 class="headlineStart text-center mt-3">Unguessable</h1>
    <div class="col-12 mt-3">
        <router-link to="/CategorySelection">
      <button type="button" class="btn btn-primary btn-block mb-2">Zu den Kategorien</button>
    </router-link>

    </div>
  </div>

</div>


<img class="bottomImage img-fluid" src="/guys.png" />


</template>

<style>

.headlineStart
{
  font-family: 'Rock Salt', cursive;


}

.bottomImage {
            position: fixed;
            bottom: -50px;
            left: 30;
            width: 100%;
            z-index: -1; /* To place it behind the content */
        }
        
        </style>