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
          <v-btn x-large width="300" outlined color="#5BB56D" class="my-3" dark>
            <v-icon left>mdi-cellphone-iphone</v-icon>ดูเบอร์ผู้ขาย
          </v-btn>
        </v-layout>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      detail: ""
    };
  },
  mounted() {
    this.getDetail();
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
        })
        .catch(err => {});
    }
  }
};
</script>

<style>
</style>