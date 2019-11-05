<template>
  <v-card color="#66fcf1" light>
    <v-card-title>
      <v-layout>
        <v-flex xs4 md4>
          <v-img :src="logo" width="100" height="100"></v-img>
          <div class="headline">User Register</div>
        </v-flex>
      </v-layout>
    </v-card-title>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field label="Tel*" color="required" v-model="Tel"></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field label="Password*" type="password" v-model="Password" required></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field label="A/C No.*" type v-model="AcNo" required></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field label="A/C Name*" type v-model="AcName" required></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="#0b0c10" outlined text @click="register">Register</v-btn>
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
      AcNo: "",
      AcName: "",
      Tel: "",
      Password: ""
    };
  },
  methods: {
    register() {
      let data = {
        AcNo: this.AcNo,
        AcName: this.AcName,
        Tel: this.Tel,
        Password: this.Password
      };
      axios
        .post("https://localhost:5001/user/create", data)
        .then(result => {
          if (result.status === 200) {
            swal.fire("Register Success!", "", "success").then(() => {
              location.reload();
            });
          }
        })
        .catch(err => {
          swal.fire("Register Failed!", "", "error");
        });
    }
  }
};
</script>

<style>
</style>