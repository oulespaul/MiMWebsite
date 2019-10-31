<template>
  <v-layout>
    <v-flex xs12 md12>
      <v-card>
        <v-card-title>
          <v-layout justify-center row wrap>
            <v-flex xs12 md12>
              <v-row align="center" justify="center">
                <v-img :src="logo" max-width="100" max-height="100"></v-img>
              </v-row>
            </v-flex>
            <v-flex xs10 md10>
              <v-text-field
                height="100"
                color="grey darken-4"
                v-model="productName"
                placeholder="Click to start typing your product name"
                solo
                light
              ></v-text-field>
            </v-flex>
            <v-flex xs4 md4>
              <v-file-input v-model="files" chips multiple label="Product Image"></v-file-input>
            </v-flex>
          </v-layout>
        </v-card-title>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  data() {
    return {
      productName: "",
      logo: require("@/assets/images/mimlogo.png"),
      files:[]
    };
  }
};
</script>

<style>
.v-input input {
  font-size: 35px !important;
  max-height: 66px !important;
}
</style>