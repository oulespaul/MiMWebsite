<template>
  <div>
    <div class="title grey--text text--darken-4">{{header}}</div>
    <v-list three-line>
      <template v-for="(item,index) in trx">
        <v-list-item :key="item.date" @click="gotoTrxDashboard(item.mimpin)">
          <v-list-item-avatar tile>
            <v-img :src="item.photo"></v-img>
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title v-html="item.itemName"></v-list-item-title>
            <v-list-item-subtitle v-html="`วันที่:${item.date}`"></v-list-item-subtitle>
            <v-list-item-subtitle v-html="`ราคา:${item.price}`"></v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
        <v-divider :key="index" inset></v-divider>
      </template>
    </v-list>
  </div>
</template>

<script>
export default {
  data: () => ({}),
  props: ["header", "trx"],
  methods: {
    gotoTrxDashboard(pin){
      this.$router.push({name:'trx',params:{mimpin:pin}})
    }
  },
};
</script>

<style>
</style>