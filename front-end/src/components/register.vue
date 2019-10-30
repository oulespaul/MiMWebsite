<template>
      <v-card color="#26347a">
        <v-card-title>
          <span class="headline">User Login</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12">
                <v-text-field label="Username*" color= required></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field label="Password*" type="password" required></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <div class="flex-grow-1"></div>
          <v-btn color="#E1F5FE" text @click="dialog = false">Login</v-btn>
        </v-card-actions>
      </v-card>
</template>

<script>

export default {
}
</script>

<style>

</style>