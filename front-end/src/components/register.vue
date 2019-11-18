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
      <v-form v-model="valid">
        <v-container>
          <v-row>
            <v-col cols="12">
              <!-- <v-text-field label="Tel*" color="required" v-model="Tel"></v-text-field> -->
              <v-text-field
                v-model="Tel"
                :rules="telRules"
                :counter="12"
                label="Tel*"
                required
              ></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field 
              label="Password*"
               type="password" 
               v-model="Password" 
               required>
              </v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field
                label="A/C No.*"
                type
                v-model="AcNo"
                :rules="acNoRules"
                required
              ></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field 
              label="A/C Name*" 
              type v-model="AcName" 
              required>
              </v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-form>
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
      valid: false,
      logo: require("@/assets/images/mimlogo.png"),
      AcNo: "",
      AcName: "",
      Tel: "08",
      Password: "",
      phoneValue: 0,
      preventNextIteration: false,
      telRules: [
        v => !!v || "Tel is required",
        v => v.length <= 12 || "Tel must be less than 10 characters",
        v => /(\d{1,3})(\d{1,3})(\d{1,4})/.test(v) || "Tel must be Number"
      ],
      acNoRules: [
        v => !!v || "Tel is required",
        v => v.length <= 13 || "Tel must be less than 10 characters",
        
      ]
    };
  },

  methods: {
    register() {
      
      if(this.Tel.length < 10 ){
        swal.fire('หมายเลขไม่ครบ','','error')
        return
      }
      if(!this.Tel.startsWith("08")){
        swal.fire('ต้องเริ่มต้นด้วย 08','','error')
        return
      }
      if(this.Password == ""){
        swal.fire('Password Enter','','error')
        return
      }
      if(this.AcNo == "")
      {
        swal.fire('AccountNumber Enter','','error')
        return
      }
      if(this.AcName == "")
      {
        swal.fire('AccountName Enter','','error')
        return
      }

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
    },
    computed: {
      telError() {
        const errors = [];
        if (!this.$v.Tel.$dirty) return errors;
        !this.$v.Tel.maxLength &&
          errors.push("Tel must be at most 10 characters long");
        !this.$v.Tel.required && errors.push("Tel is required.");
        return errors;
      }
    }
  }
};
</script>

<style>
</style>