<template>
  <v-card color="#66fcf1" light>
    <v-card-title>
      <v-layout>
        <v-flex xs4 md4>
          <v-img :src="logo" width="100" height="100"></v-img>
          <div class="headline">User Login</div>
        </v-flex>
      </v-layout>
    </v-card-title>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field label="Tel*" color="required"></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field label="Password*" type="password" required></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="#0b0c10" outlined text @click="dialog = false">Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      logo: require("@/assets/images/mimlogo.png")
    };
  }
};
</script>

<style>
</style>