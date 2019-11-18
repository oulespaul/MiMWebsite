<template>
  <v-layout row wrap>
    <v-flex xs3 md3 class="pa-1" fill-height>
      <v-card color="#45a29e" raised>
        <v-card-title>
          <div class="title">{{username}}</div>
        </v-card-title>
        <v-card-text>
          <!-- <div class="subtitle-1 ml-5">Shop Name:{{userDetail}}</div> -->
          <div class="subtitle-1 ml-5">Balance: {{userDetail.balance}}</div>
          <v-divider color="red darken-4" class="mx-5"></v-divider>
          <div class="subtitle-1 ml-5">A/C Number: {{userDetail.acNo}}</div>
          <div class="subtitle-1 ml-5">A/C Name: {{userDetail.acName}}</div>
          <!-- <div class="subtitle-1 ml-5">Email: oulespaul@gmail.com</div> -->
        </v-card-text>
      </v-card>
      <v-card color="#c5c6c7" class="mt-5" raised>
        <v-card-title>
          <div class="title grey--text text--darken-4">Top-up</div>
        </v-card-title>
        <v-divider class="mx-5"></v-divider>
        <v-card-text>
          <v-layout text-md-center>
            <v-flex>
              <v-btn fab icon class="d-inline">
                <v-avatar size="45">
                  <v-img src="https://cdn.omise.co/assets/dashboard/images/omise-logo.png"></v-img>
                </v-avatar>
              </v-btn>
              <v-btn fab icon class="d-inline">
                <v-avatar size="45">
                  <v-img
                    src="https://cdn.truemoney.com/wp-content/uploads/2018/09/logo-truemoneywallet-300x300.jpg"
                  ></v-img>
                </v-avatar>
              </v-btn>
              <v-btn fab icon class="d-inline">
                <v-avatar size="45">
                  <v-img
                    src="https://lh3.googleusercontent.com/AyX675vwNz8X2sYUTSrjUTRVzzXMZUW_nMQ8Vk__Nabj6zQ7s7We-bpZbFmoYf7e2YM"
                  ></v-img>
                </v-avatar>
              </v-btn>
              <v-btn fab icon class="d-inline">
                <v-avatar size="45">
                  <v-img
                    src="https://is3-ssl.mzstatic.com/image/thumb/Purple7/v4/dd/b8/60/ddb86082-1c8a-e7a4-1b00-455d92765701/source/512x512bb.jpg"
                  ></v-img>
                </v-avatar>
              </v-btn>
            </v-flex>
          </v-layout>
        </v-card-text>
      </v-card>
      <v-card color="blue" class="mt-5" raised>
        <v-card-title>
          <div class="title grey--text text--darken-4">Quick MIM</div>
        </v-card-title>
        <v-card-text>
          <v-divider class="mx-5"></v-divider>
          <br />
          <v-text-field
            color="#0b0c10"
            v-model="pin"
            @keydown.enter="gotoDashboard"
            light
            solo
            rounded
            prepend-inner-icon="mdi-sigma mdi-spin"
          ></v-text-field>
        </v-card-text>
      </v-card>
      <v-card color="blue" class="mt-5" raised>
        <div class="text-center">
          <v-dialog v-model="dialog" width="500">
            <template v-slot:activator="{ on }">
              <v-btn width="300" color="red lighten-2" x-large dark v-on="on">สรุปผลการซื้อ-ขาย</v-btn>
            </template>

            <v-card>
              <v-card-title class="headline grey darken-4" primary-title>ข้อมูลการซื้อ - ขาย</v-card-title>

              <v-card-text>
                <graph-component :buy="buy" :sell="sell"></graph-component>
              </v-card-text>

              <v-divider></v-divider>

              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="primary" text @click="dialog = false">I accept</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </div>
      </v-card>
    </v-flex>
    <v-flex xs6 md6 class="pa-1">
      <v-card color="#1f2833" class="white--text" raised>
        <v-card-title>
          <div class="title">History Transaction</div>
        </v-card-title>
        <v-card-text>
          <v-container>
            <historytable-component :items="history"></historytable-component>
          </v-container>
        </v-card-text>
      </v-card>
    </v-flex>
    <v-flex xs3 md3 class="pa-1">
      <v-card color="#c5c6c7" raised>
        <v-card-title>
          <div class="title grey--text text--darken-4">รายการที่กำลังดำเนินการอยู่</div>
        </v-card-title>
        <v-card-text>
          <list-component :header="header1" :trx="items1" class="my-5"></list-component>
          <list-component :header="header2" :trx="items2"></list-component>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import historytableComponent from "@/components/dashboard/historyTable";
import listComponent from "@/components/dashboard/list";
import graphComponent from '@/components/dashboard/graph'
import axios from "axios";
export default {
  data() {
    return {
      username: "",
      userDetail: "",
      items1: [],
      items2: [],
      header1: "ที่กำลังขาย",
      header2: "ที่กำลังซื้อ",
      history: [],
      pin: "",
      dialog: false,
      buy:[],
      sell:[]
    };
  },
  async created() {
    this.username = await localStorage.getItem("authToken");
    this.getUserDetail(this.username);
    this.getTransactionByUserId(this.username);
    console.log(this.history);
  },
  methods: {
    getUserDetail(userId) {
      axios
        .get("https://localhost:5001/user/getDetail", {
          params: { username: userId }
        })
        .then(result => {
          this.userDetail = result.data;
        })
        .catch(err => {
          console.log(err);
        });
    },
    gotoDashboard() {
      this.$router.push({ name: "trx", params: { mimpin: this.pin } });
    },
    getTransactionByUserId(userId) {
      axios
        .get("https://localhost:5001/transaction/getTransactionByUserId", {
          params: { userId: userId }
        })
        .then(result => {
          console.log(result.data);
          this.history = result.data.history;
          this.buy.push(result.data.history[0].h.price)
          this.buy.push(result.data.history[2].h.price)
          this.sell.push(result.data.history[1].h.price)
          this.items1 = result.data.seller;
          this.items2 = result.data.buyer;
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  components: {
    historytableComponent,
    listComponent,
    graphComponent
  }
};
</script>

<style>
.theme--dark.v-text-field--solo > .v-input__control > .v-input__slot {
  background: #c5c6c7;
}
</style>