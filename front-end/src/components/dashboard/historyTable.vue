<template>
  <v-timeline>
    <v-timeline-item v-for="(n,index) in items" :key="index" color="#c5c6c7" large dark>
      <template v-slot:opposite>
        <span class="white--text text--darken-4">{{n.date}}</span>
      </template>
      <v-card class="elevation-2 grey--text text--darken-4" color="#45a29e">
        <v-card-title class="headline grey--text text--darken-4">
          <div class="header">{{n.itemName}}</div>
          <v-spacer></v-spacer>
          <v-avatar color="indigo" size="50" tile>
            <v-img :src="n.photo"></v-img>
          </v-avatar>
        </v-card-title>
        <v-card-text class="grey--text text--darken-4">
          <v-divider></v-divider>
          <div class="subtitle-1">MIMPIN: {{n.mimpin}}</div>
          <div class="subtitle-1">ราคา {{n.price}}</div>
        </v-card-text>
      </v-card>
    </v-timeline-item>
  </v-timeline>
</template>

<script>
export default {
  data() {
    return {};
  },
  props: ["items"]
};
</script>

<style>
</style>