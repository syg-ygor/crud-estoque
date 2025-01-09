<template>
    <v-dialog v-model="localShow" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="headline">{{ isEditMode ? 'Editar Ordem' : 'Cadastrar Ordem' }}</span>
        </v-card-title>
        <v-card-text>
          <v-form ref="form">
            <v-text-field v-model="localOrder.observation" label="Observação" ></v-text-field>
            <v-autocomplete
              v-model="localOrder.productId"
              :items="products"
              item-value="id"
              item-title="name"
              label="Produto"
            ></v-autocomplete>
            <v-text-field v-model="localOrder.quantity" label="Quantidade" type="number" required></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
          <v-btn color="blue darken-1" text @click="saveOrder">{{ isEditMode ? 'Salvar' : 'Cadastrar' }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>
  
  <script>
  export default {
    props: {
      show: Boolean,
      order: Object,
      products: Array,
      isEditMode: Boolean
    },
    data() {
      return {
        localShow: false,
        localOrder: { ...this.order }
      };
    },
    watch: {
      order(newVal) {
        this.localOrder = { ...newVal };
      },
      show(newVal) {
        this.localShow = newVal;
      }
    },
    methods: {
      close() {
        this.$emit('close');
      },
      saveOrder() {
        this.$emit('save', this.localOrder);
        this.close();
      }
    }
  };
  </script>
  