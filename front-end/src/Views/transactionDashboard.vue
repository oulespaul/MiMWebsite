<template>
  <v-layout row wrap>
    <v-flex xs8 md8>
      <v-card class="ma-5">
        <v-layout row wrap>
          <v-flex xs12 md12>
            <v-carousel cycle height="500" hide-delimiter-background show-arrows-on-hover>
              <v-carousel-item v-for="(i, index) in detail" :key="index">
                <v-sheet height="100%" color="#c5c6c7">
                  <v-row class="fill-height" align="center" justify="center">
                    <v-img max-width="500" max-height="800" :src="i.p.imageText"></v-img>
                  </v-row>
                </v-sheet>
              </v-carousel-item>
            </v-carousel>
          </v-flex>
        </v-layout>
      </v-card>
      <v-card>
        <v-card-title>
          <div class="title">{{detail[0].i.itemName}}</div>
        </v-card-title>
        <v-card-text>
          <v-divider></v-divider>
          <div class="title ma-3">รายละเอียดสินค้า</div>
          <div class="subtitle-1 mx-3">{{detail[0].i.itemDetail}}</div>
          <div class="title ma-3">สถานะรายการ</div>
          <div class="subtitle-1 mx-3">{{detail[0].t.trxStatus}}</div>
          <v-divider></v-divider>
          <div v-show="buyer === true" class="ma-5">
            <v-layout row wrap justify-center text-md-center>
              <v-flex xs12 md12>
                <omise-component :trxId="detail[0].t.id" :amount="detail[0].t.amountTotal" v-show="detail[0].t.trxStatus == 'ผู้ใช้เข้าห้องซื้อขายแล้ว'"></omise-component>
              </v-flex>
            </v-layout>
          </div>
          <div v-show="seller === true" class="ma-5">
            <v-layout row wrap justify-center text-md-center>
              <v-flex xs12 md12>
                <v-btn v-show="detail[0].t.trxStatus == 'จ่ายเงินสำเร็จแล้ว'" @click="shipped(detail[0].t.id)">ส่งของแล้ว</v-btn>
              </v-flex>
            </v-layout>
          </div>
           <div v-show="buyer === true" class="ma-5">
            <v-layout row wrap justify-center text-md-center>
              <v-flex xs12 md12>
                <v-btn v-show="detail[0].t.trxStatus == 'ส่งของแล้ว(อยู่ในกระบวนการจัดส่ง)'" @click="pickuped(detail[0].t.id,detail[0].t.seller,detail[0].t.amountTotal)">ได้รับของแล้ว</v-btn>
              </v-flex>
            </v-layout>
          </div>
        </v-card-text>
      </v-card>
    </v-flex>
    <v-flex xs4 md4>
      <v-card raised class="ma-5 pa-2 grey--text text--darken-4" shaped color="#c5c6c7">
        <v-card-title>
          <div class="display-1">MIMPIN: {{detail[0].t.id}}</div>
        </v-card-title>
        <v-card-text>
          <div class="headline grey--text text--darken-4">{{detail[0].t.amountTotal}} บาท</div>
        </v-card-text>
      </v-card>
      <v-card raised class="ma-5 pa-2 grey--text text--darken-4" color="#c5c6c7">
        <v-layout row wrap justify-center>
          <v-flex xs12 md12>
            <div class="display-1 ma-5">{{detail[0].t.seller}}</div>
          </v-flex>
          <v-btn x-large width="300" color="#5BB56D" class="my-3" dark>
            <v-icon left>mdi-message-alert</v-icon>คุยกับผู้ขาย
          </v-btn>
          <v-btn
            x-large
            width="300"
            @click="showTel = !showTel"
            outlined
            color="#5BB56D"
            class="my-3"
            dark
          >
            <span v-show="showTel === false">
              <v-icon left>mdi-cellphone-iphone</v-icon>ดูเบอร์ผู้ขาย
            </span>
            <span v-show="showTel === true">{{detail[0].u}}</span>
          </v-btn>
        </v-layout>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import axios from "axios";
import swal from "sweetalert2";
import omiseComponent from "@/components/omise";
export default {
  data() {
    return {
      detail: "",
      showTel: false,
      buyer: false,
      seller: false
    };
  },
  components: {
    omiseComponent
  },
  async mounted() {
    await this.middleware();
  },
  props: ["mimpin"],
  methods: {
    getDetail() {
      axios
        .get("https://localhost:5001/transaction/getTransactionById", {
          params: { id: this.mimpin }
        })
        .then(result => {
          this.detail = result.data;
          console.log(result.data);
        })
        .catch(err => {
          console.log(err);
        });
    },
    middleware() {
      let data = {
        id: this.mimpin,
        Buyer: localStorage.getItem("authToken")
      };
      axios
        .post("https://localhost:5001/transaction/updateBuyer", data)
        .then(result => {
          if (result.data == "You're Buyer") {
            this.buyer = true;
          }else if(result.data == "You're Seller"){
            this.seller = true;
          }
          this.getDetail();
        })
        .catch(err => {
          swal.fire("Error", "ไม่สามารถเข้า MIM ได้", "error").then(() => {
            this.$router.push("/");
          });
        });
    },
    shipped(id){
      let data = {
        id:id,
        TrxStatus:"ส่งของแล้ว(อยู่ในกระบวนการจัดส่ง)"
      }
      axios.post('https://localhost:5001/transaction/updateStatus',data).then((result) => {
        swal.fire('จัดส่งสินค้าเรียบร้อย','','success')
      }).catch((err) => {
        swal.fire('จัดส่งสินค้าไม่สำเร็จ','','error')
      });
    },
    pickuped(id,seller,amount){
      let data = {
        id:id,
        seller:seller,
        amount:amount
      }
      axios.post("https://localhost:5001/transaction/pickupedItem",data).then((result) => {
        swal.fire('ได้รับของเรียบร้อย','ขอบคุณที่ไว้วางใจ MiM','success')
      }).catch((err) => {
        swal.fire('การได้รับของไม่เสร็จสมบูรณ์','','error')
      });
    }
  }
};
</script>
<style>
</style>