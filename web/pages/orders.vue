<template>
    <v-container>
      <h1>Retiradas</h1>
      <v-row justify="end" class="ma-4">
        <v-btn color="primary" @click="openCreateModal">Nova ordem</v-btn>
      </v-row>
      <v-data-table-server v-model:items-per-page="itemsPerPage" :headers="headers" :items="serverItems"
        :items-length="totalItems" :loading="loading" :search="search" item-value="observation"
        @update:options="loadItems">
        <template #item.action="{ item }">
          <v-btn color="teal-lighten-4" class="ma-2" icon @click="openEditModal(item)">
            <v-icon>mdi-pencil</v-icon>
          </v-btn>
          <v-btn color="red-lighten-3" class="ma-2"  icon @click="removeOrder(item.id)">
            <v-icon>mdi-delete</v-icon>
          </v-btn>
        </template>
        <template #item.scheduleAt="{ item }">
          {{ new Date(item.scheduleAt).toLocaleString('pt-BR', { year: 'numeric', month: 'numeric', day: 'numeric', hour: '2-digit', minute: '2-digit' }) }}
        </template>
      </v-data-table-server>
  
      <OrderModal :show="showModal" :order="selectedOrder" :products="products" :isEditMode="isEditMode"
        @close="closeModal" @save="saveOrder" />
    </v-container>
  </template>
  
  <script>
  import OrderModal from '~/components/OrderModal.vue';
  
  export default {
    components: {
      OrderModal
    },
    data() {
      return {
        itemsPerPage: 5,
        headers: [
          { title: 'Observação', key: 'observation' },
          { title: 'Produto', key: 'product.name' },
          { title: 'Quantidade', key: 'quantity' },
        ],
        search: '',
        serverItems: [],
        loading: true,
        totalItems: 0,
        showModal: false,
        selectedOrder: { observation: '', productId: 0, scheduleAt: '' },
        products: [],
        isEditMode: false
      };
    },
    methods: {
      async loadItems({ page, itemsPerPage, sortBy }) {
        this.loading = true;
        await this.$axios.get('Orders').then(response => {
          this.serverItems = response.data;
          this.totalItems = response.data.length;
        }).finally(() => {
          this.loading = false;
        });
  
        // Load products for the select search
        await this.$axios.get('Products').then(response => {
          this.products = response.data;
        });
      },
      openCreateModal() {
        this.selectedOrder = { observation: '', productId: null, scheduleAt: '' };
        this.isEditMode = false;
        this.showModal = true;
      },
      openEditModal(order) {
        this.selectedOrder = { ...order };
        this.isEditMode = true;
        this.showModal = true;
      },
      closeModal() {
        this.showModal = false;
      },
      async saveOrder(order) {
        if (this.isEditMode) {
          await this.$axios.put(`Orders/${order.id}`, order);
        } else {
          await this.$axios.post('Orders', order);
        }
        this.loadItems({ page: 1, itemsPerPage: this.itemsPerPage });
      },
      async removeOrder(orderId) {
        try {
          await this.$axios.delete(`Orders/${orderId}`);
          this.loadItems({ page: 1, itemsPerPage: this.itemsPerPage });
        } catch (error) {
          console.error(error);
        }
      }
    }
  };
  </script>
