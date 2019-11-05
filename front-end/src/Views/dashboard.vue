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
          <v-text-field color="#0b0c10" light solo rounded prepend-inner-icon="mdi-sigma mdi-spin"></v-text-field>
        </v-card-text>
      </v-card>
    </v-flex>
    <v-flex xs6 md6 class="pa-1">
      <v-card color="#1f2833" class="white--text" raised>
        <v-card-title>
          <div class="title">History Transaction</div>
        </v-card-title>
        <v-card-text>
          <v-container>
            <historytable-component></historytable-component>
          </v-container>
        </v-card-text>
      </v-card>
    </v-flex>
    <v-flex xs3 md3 class="pa-1">
      <v-card color="#c5c6c7" raised>
        <v-card-title>
          <div class="title grey--text text--darken-4">Transaction processing</div>
        </v-card-title>
        <v-card-text>
          <list-component></list-component>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import historytableComponent from "@/components/dashboard/historyTable";
import listComponent from "@/components/dashboard/list";
import axios from 'axios'
export default {
  data() {
    return {
      username:'',
      userDetail:''
    };
  },
  async created() {
    this.username = await localStorage.getItem('authToken')
    this.getUserDetail(this.username)
  },
  methods: {
    getUserDetail(userId){
      axios.get('https://localhost:5001/user/getDetail',{params:{username:userId}}).then((result) => {
        this.userDetail = result.data
      }).catch((err) => {
        console.log(err)
      });
    }
  },
  components: {
    historytableComponent,
    listComponent
  }
};
</script>

<style>
.theme--dark.v-text-field--solo > .v-input__control > .v-input__slot {
  background: #c5c6c7;
}
</style>