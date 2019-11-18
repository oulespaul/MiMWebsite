<template>
  <v-layout>
    <v-flex xs12 md12>
      <v-card color="#1f2833">
        <v-card-title>
          <v-layout justify-center row wrap>
            <v-flex xs12 md12>
              <v-row align="center" justify="center">
                <v-img :src="logo" max-width="150" max-height="150"></v-img>
              </v-row>
            </v-flex>
            <v-layout justify-center>
              <v-flex xs6 md6 class="px-5">
                <v-text-field
                  height="100"
                  color="grey darken-4"
                  v-model="productName"
                  placeholder="หัวข้อสินค้าที่คุณต้องการลงขาย"
                  :counter="20"
                  required
                  :rules="nameRules"
                  solo
                  light
                ></v-text-field>
                <v-flex xs6 md6>
                  <v-text-field
                    height="100"
                    color="grey darken-4"
                    v-model="productPrice"
                    placeholder="ระบุราคาขาย"
                    @keyup="focusOut1"
                    @blur="focusOut1"
                    :rules="priceRules"
                    solo
                    light
                  ></v-text-field>
                </v-flex>
                <v-flex>
                  <v-textarea
                    height="100"
                    color="grey darken-4"
                    v-model="productDetail"
                    placeholder="รายละเอียดสินค้า"
                    solo
                    light
                  ></v-textarea>
                </v-flex>
              </v-flex>
            </v-layout>
            <v-flex xs12 md12 text-md-center class="ma-5">
              <label for="file-upload" class="custom-file-upload">
                เลือกรูปภาพ
                <input
                  type="file"
                  id="file-upload"
                  @change="previewImage"
                  accept="image/*"
                />
              </label>
            </v-flex>
            <v-layout justify-center>
              <v-flex xs2 md2 class="ma-5" v-show="files != ''">
                <v-carousel hide-delimiters height="250">
                  <v-carousel-item v-for="(item,i) in files" :key="i" :src="item"></v-carousel-item>
                </v-carousel>
              </v-flex>
            </v-layout>
          </v-layout>
        </v-card-title>
        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn color="#66fcf1" @click="createMim" class="grey--text text--darken-4">สร้าง MiM</v-btn>
          <v-btn color="error">ยกเลิก</v-btn>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import axios from "axios";
import swal from "sweetalert2";
export default {
  data() {
    return {
      logo: require("@/assets/images/mimlogo.png"),
      productName: "",
      productPrice: "",
      productDetail: "",
      files: [],
      user: "",
      nameRules: [
        v => !!v || "Name is required",
        v => v.length <= 20 || "Tel must be less than 20 characters"
      ],
      priceRules: [
        v => !!v || "Price is required",
        v => v.length <= 5 || "Cannot over thoundsunds",
      ]
    };
  },
  created() {
    this.user = localStorage.getItem("authToken");
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
          this.files.push(e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    focusOut1: function(event) {
      this.productPrice = this.productPrice.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    },
    createMim() {
      if(this.files.length == 0 ){
        swal.fire('กรุณากรอกข้อมูลให้ครบ','กรุณาใส่ราคาและรูปสินค้า','error')
        return
      }
      if(this.productPrice == ""){
        swal.fire('กรุณากรอกข้อมูลให้ครบ','กรุณาใส่ราคาและรูปสินค้า','error')
        return
      }
      if(this.productName == ""){
        swal.fire('กรุณากรอกข้อมูลให้ครบ','กรุณาใส่ราคาและรูปสินค้า','error')
        return
      }
      let data = {
        ItemName: this.productName,
        ItemPrice: this.productPrice,
        ItemDetail: this.productDetail,
        ItemImage: this.files,
        Seller: this.user
      };
      axios
        .post("https://localhost:5001/transaction/createTrx", data)
        .then(result => {
          var mimpin = result.data.result.value.mimpin.toString();
          swal
            .fire("สร้าง MiM สำเร็จ", `MIMPIN: ${mimpin}`, "success")
            .then(() => {
              this.$router.push({ path: "/dashboard" });
            });
        })
        .catch(err => {
          swal.fire("สร้าง MiM ไม่สำเร็จ", "", "error");
        });
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
  border: 1px dashed #ccc;
  display: inline-block;
  padding: 48px 96px;
  cursor: pointer;
}
input[type="file"] {
  display: none;
}
</style>