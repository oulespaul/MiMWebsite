<template>
  <v-timeline >
    <v-timeline-item
      v-for="n in 3"
      :key="n"
      color="#c5c6c7"
      large
      dark
    >
      <template v-slot:opposite>
        <span class="white--text text--darken-4">Tus eu perfecto</span>
      </template>
      <v-card class="elevation-2 grey--text text--darken-4" color="#45a29e">
        <v-card-title class="headline grey--text text--darken-4">Lorem ipsum</v-card-title>
        <v-card-text class="grey--text text--darken-4">
          Lorem ipsum dolor sit amet, no nam oblique veritus. Commune scaevola imperdiet nec ut, sed euismod convenire principes at. Est et nobis iisque percipit, an vim zril disputando voluptatibus, vix an salutandi sententiae.
        </v-card-text>
      </v-card>
    </v-timeline-item>
  </v-timeline>
</template>

<script>
export default {

}
</script>

<style>

</style>