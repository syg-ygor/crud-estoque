<template>
    <v-container>
      <h1>Produtos</h1>
      <v-row justify="end" class="ma-4">
        <v-btn color="primary" @click="openCreateModal">Cadastrar Produto</v-btn>
      </v-row>
      <v-data-table-server v-model:items-per-page="itemsPerPage" :headers="headers" :items="serverItems"
        :items-length="totalItems" :loading="loading" :search="search" item-value="name"
        @update:options="loadItems">
        <template #item.action="{ item }">
          <v-btn color="teal-lighten-4" class="ma-2" icon @click="openEditModal(item)">
            <v-icon>mdi-pencil</v-icon>
          </v-btn>
          <v-btn color="red-lighten-3" class="ma-2" icon @click="removeProduct(item.id)">
            <v-icon>mdi-delete</v-icon>
          </v-btn>
        </template>
      </v-data-table-server>
  

  
      <ProductModal :show="showModal" :product="selectedProduct" :isEditMode="isEditMode" @close="closeModal"
        @save="saveProduct" />
    </v-container>
  </template>
  
  <script>
  import ProductModal from '~/components/ProductModal.vue';
  
  export default {
    components: {
      ProductModal
    },
    data() {
      return {
        itemsPerPage: 5,
        headers: [
          { title: 'Nome', key: 'name' },
          { title: 'Quantidade', key: 'quantity', align: 'end' },
          { title: 'Valor (R$)', key: 'value', align: 'end' },
          { title: 'Ação', key: 'action', align: 'center' }
        ],
        search: '',
        serverItems: [],
        loading: true,
        totalItems: 0,
        showModal: false,
        selectedProduct: { name: '', quantity: 0, value: 0 },
        isEditMode: false
      };
    },
    methods: {
      async loadItems({ page, itemsPerPage, sortBy }) {
        this.loading = true;
        await this.$axios.get('Products').then(response => {
          this.serverItems = response.data;
          this.totalItems = response.data.length;
        }).finally(() => {
          this.loading = false;
        });
      },
      openCreateModal() {
        this.selectedProduct = { name: '', quantity: 0, value: 0 };
        this.isEditMode = false;
        this.showModal = true;
      },
      openEditModal(product) {
        this.selectedProduct = { ...product };
        this.isEditMode = true;
        this.showModal = true;
      },
      closeModal() {
        this.showModal = false;
      },
      async saveProduct(product) {
        if (this.isEditMode) {
          await this.$axios.put(`Products/${product.id}`, product);
        } else {
          await this.$axios.post('Products', product);
        }
        this.loadItems({ page: 1, itemsPerPage: this.itemsPerPage });
      },
      async removeProduct(productId) {
        try {
          await this.$axios.delete(`Products/${productId}`);
          this.loadItems({ page: 1, itemsPerPage: this.itemsPerPage });
        } catch (error) {
          console.error(error);
        }
      }
    }
  };
  </script>
  