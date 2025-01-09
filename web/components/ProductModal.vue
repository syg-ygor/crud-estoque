<template>
    <v-dialog v-model="localShow" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="headline">{{ isEditMode ? 'Editar Produto' : 'Cadastrar Produto' }}</span>
        </v-card-title>
        <v-card-text>
          <v-form ref="form">
            <v-text-field v-model="localProduct.name" label="Nome" required></v-text-field>
            <v-text-field v-model="localProduct.quantity" label="Quantidade" type="number" required></v-text-field>
            <v-text-field v-model="localProduct.value" label="Valor (R$)" type="number" required></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
          <v-btn color="blue darken-1" text @click="saveProduct">{{ isEditMode ? 'Salvar' : 'Cadastrar' }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>
  
  <script>
  export default {
    props: {
      show: Boolean,
      product: Object,
      isEditMode: Boolean
    },
    data() {
      return {
        localShow: false,
        localProduct: { ...this.product }
      };
    },
    watch: {
      show(newVal) {
        this.localShow = newVal;
      },
      product(newVal) {
        this.localProduct = { ...newVal };
      }
    },
    methods: {
      close() {
        this.$emit('close');
      },
      saveProduct() {
        this.$emit('save', this.localProduct);
        this.close();
      }
    }
  };
  </script>
  