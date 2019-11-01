<template>
  <v-layout>
    <v-flex xs12 md12>
      <v-card color="#1f2833">
        <v-card-title>
          <v-layout justify-center row wrap>
            <v-flex xs12 md12>
              <v-row align="center" justify="center">
                <v-img :src="logo" max-width="100" max-height="100"></v-img>
              </v-row>
            </v-flex>
            <v-flex xs12 md12 class="px-5">
              <v-text-field
                height="100"
                color="grey darken-4"
                v-model="productName"
                placeholder="Click to start typing your product name"
                solo
                light
              ></v-text-field>
            </v-flex>
            <v-flex xs12 md12 text-md-center>
              <label for="file-upload" class="custom-file-upload">
                Upload item images
                <input
                  type="file"
                  id="file-upload"
                  @change="previewImage"
                  accept="image/*"
                />
              </label>
              <!-- <v-btn icon color="green" @click="upload">
                <v-icon>mdi-done</v-icon>
              </v-btn>-->
            </v-flex>
            <v-flex xs4 md4 v-for="(i,index) in files" :key="index">
              <img :src="i" width="100px" height="100px" />
            </v-flex>
            {{files}}
          </v-layout>
        </v-card-title>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import swal from "sweetalert2";
export default {
  data() {
    return {
      productName: "",
      logo: require("@/assets/images/mimlogo.png"),
      files: []
    };
  },
  methods: {
    previewImage: function(event) {
      var input = event.target;
      // Ensure that you have a file before attempting to read it
      if (input.files && input.files[0]) {
        // create a new FileReader to read this image and convert to base64 format
        var reader = new FileReader();
        reader.onload = e => {
          // Read image as base64 and set to imageData
          this.files.push(e.target.result)
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    upload() {
      if (this.image !== null) {
        let data = {
          imageProfile: this.image
        };
        swal.fire("title", this.image, "success");
      }
    }
  }
};
</script>

<style>
.v-input input {
  font-size: 35px !important;
  max-height: 66px !important;
}
.custom-file-upload {
  border: 1px solid #ccc;
  display: inline-block;
  padding: 48px 96px;
  cursor: pointer;
}
input[type="file"] {
  display: none;
}
</style>