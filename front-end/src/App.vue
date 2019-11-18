<template>
  <v-app id="inspire">
    <!-- <v-navigation-drawer
      v-model="drawer"
      app
      clipped
      color="transparent"
    >
      <v-list dense>
        <v-list-item  @click="changePage('/')">
          <v-list-item-action>
            <v-icon>mdi-view-dashboard</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>index</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item @click="changePage('createmim')">
          <v-list-item-action>
            <v-icon>mdi-settings</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>createmim</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item @click="changePage('dashboard')">
          <v-list-item-action>
            <v-icon>mdi-settings</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>dashboard</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>-->

    <v-app-bar app clipped-left color="transparent" hide-on-scroll elevate-on-scroll>
      <v-toolbar-title>
        <v-btn color="white" x-large text @click="changePage('/')" class="ma-2">MiM</v-btn>
      </v-toolbar-title>
      <div class="flex-grow-1"></div>
      <v-btn
        color="#66fcf1"
        @click="changePage('/createmim')"
        class="ma-2 grey--text text--darken-4"
      >CreateMim</v-btn>
      <v-btn
        color="#66fcf1"
        @click="changePage('/dashboard')"
        class="ma-2 grey--text text--darken-4"
      >Dashboard</v-btn>
      <v-btn
        color="yellow"
        @click="logout"
        v-show="user != ''"
        class="ma-2 grey--text text--darken-4"
      >Logout</v-btn>
    </v-app-bar>
    <v-content>
      <v-container>
        <router-view></router-view>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
  props: {
    source: String
  },
  data: () => ({
    drawer: null,
    user: ""
  }),
  created() {
    this.$vuetify.theme.dark = true;
    this.user = localStorage.getItem("authToken");
  },
  methods: {
    changePage(page) {
      this.$router.push({ path: page });
    },
    logout() {
      localStorage.setItem("authToken", "");
      window.location.replace("/");
    }
  }
};
</script>
<style>
.theme--dark.v-application {
  background: #191a1b !important;
  color: #ffffff;
}
</style>