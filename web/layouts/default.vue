<template>
    <v-app>
      <v-app-bar app  color="cyan-darken-4">
        <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
        <v-toolbar-title>Meu App</v-toolbar-title>
      </v-app-bar>
  
      <v-navigation-drawer color="cyan-darken-3" v-model="drawer" app>
        <v-list>
          <v-list-item
            v-for="item in items"
            :key="item.title"
            :to="item.to"
            link
          >
            <v-list-item-content>
              <v-row>
                <v-col md="2">
                  <v-icon :icon="item.icon"></v-icon>
                </v-col>
                <v-col>
                  <v-list-item-title>{{ item.title }}</v-list-item-title>
                </v-col>
              </v-row>
              
              
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>
  
      <v-main>
        <v-container>
            <slot />
        </v-container>
      </v-main>
    </v-app>
  </template>
  
  <script>
  export default {
    data() {
      return {
        drawer: false,
        items: [
          { icon:'mdi-home',title: 'Home',  to: '/' },
          { icon:'mdi-ballot-recount-outline',title: 'Produtos', to: '/products' },
          { icon:'mdi-cart',title: 'Retiradas', to: '/orders' },
          { icon:'mdi-currency-usd',title: 'Financeiro', to: '/finances' },
          { icon:'mdi-wrench-clock',title: 'Manutenções', to: '/maintenances' },
        ],
      };
    },
  };
  </script>
  