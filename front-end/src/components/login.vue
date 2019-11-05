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
            <v-text-field label="Tel*" v-model="tel" color="required"></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field label="Password*" v-model="password" type="password" required></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="#0b0c10" outlined text @click="login">Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
import axios from "axios";
import swal from "sweetalert2";
export default {
  data() {
    return {
      logo: require("@/assets/images/mimlogo.png"),
      tel: "",
      password: ""
    };
  },
  methods: {
    login() {
      let data = {
        Tel: this.tel,
        Password: this.password
      };
      axios
        .post("https://localhost:5001/user/login", data)
        .then(result => {
          localStorage.setItem("authToken", result.data.authToken);
          swal.fire("Login Success!", "", "success").then(()=>{
            this.$router.push({path:'/dashboard'})
          })
        })
        .catch(err => {
          swal.fire("Login failed!", "", "error").then(()=>{
            this.$router.push({path:'/'})
          })
        });
    }
  }
};
</script>

<style>
</style>