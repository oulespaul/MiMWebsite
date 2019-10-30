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

    <v-app-bar app clipped-left color="transparent" elevate-on-scroll>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>MiM</v-toolbar-title>
      <div class="flex-grow-1"></div>
          <v-btn color="#26347a" @click="changePage('/')" class="ma-2">Index</v-btn>
          <v-btn color="#26347a" @click="changePage('/createmim')" class="ma-2">CreateMim</v-btn>
          <v-btn color="#26347a" @click="changePage('/dashboard')" class="ma-2">Dashboard</v-btn>
    </v-app-bar>

      <router-view></router-view>
  </v-app>
</template>

<script>
export default {
  props: {
    source: String
  },
  data: () => ({
    drawer: null
  }),
  created() {
    this.$vuetify.theme.dark = true;
  },
  methods: {
    changePage(page) {
      this.$router.push({ path: page });
    }
  }
};
</script>
<style>
.theme--dark.v-application {
  background: #26347a;
  color: #ffffff;
}
</style>