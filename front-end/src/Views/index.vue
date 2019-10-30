<template>
  <!-- <v-container class="indigo darken-1"> -->
  <div>
    <v-layout row wrap text-md-center text-sm-center justify-center align-center fill-height>
      <v-flex xs12 md12 class="mt-5">
        <v-row justify="center">
          <v-img :src="image" aspect-ratio="1" max-width="500" max-height="300"></v-img>
        </v-row>
      </v-flex>
      <v-flex xs4 md4>
        <v-text-field label="MiM PIN" outlined width="200"></v-text-field>
      </v-flex>
      <v-flex md12 xs12></v-flex>
      <v-layout row>
        <v-flex md12 xs12 class="ma-2 d-inline">
          <v-btn @click="loginModal = true" color="#66fcf1" outlined>Login</v-btn>
        </v-flex>
        <v-flex xs12 md12 justify-center>
          <div class="subtitle-1">or</div>
        </v-flex>
        <v-flex md12 xs12 class="ma-2 d-inline">
          <v-btn @click="registerModal = !registerModal" color="#66fcf1" outlined>Register</v-btn>
        </v-flex>
      </v-layout>
    </v-layout>
    <v-dialog v-model="loginModal">
      <login-component></login-component>
    </v-dialog>
    <v-dialog v-model="registerModal" width="500">
      <register-component></register-component>
    </v-dialog>
  </div>
  <!-- </v-container> -->
</template>

<script>
import loginComponent from "@/components/login";
import registerComponent from "@/components/register";
export default {
  data() {
    return {
      loginModal: false,
      registerModal: false,
      image: require("@/assets/images/mimlogo.png")
    };
  },
  components: {
    loginComponent,
    registerComponent
  },
  methods: {
    login() {
      this.loginModal = true;
    },
    register() {
      this.registerModal = true;
    }
  }
};
</script>

<style>
</style>