<template>
  <v-container>
    <h1>Manutenções</h1>
    <v-row justify="end" class="ma-4">
      <v-btn color="primary" @click="openCreateModal">Cadastrar Manutenção</v-btn>
    </v-row>
    <v-data-table-server v-model:items-per-page="itemsPerPage" :headers="headers" :items="serverItems"
      :items-length="totalItems" :loading="loading" :search="search" item-value="observation"
      @update:options="loadItems">
      <template #item.action="{ item }">
        <v-btn color="teal-lighten-4" class="ma-2" icon @click="openEditModal(item)">
          <v-icon>mdi-pencil</v-icon>
        </v-btn>
        <v-btn color="red-lighten-3" class="ma-2"  icon @click="removeMaintenance(item.id)">
          <v-icon>mdi-delete</v-icon>
        </v-btn>
      </template>
      <template #item.scheduleAt="{ item }">
        {{ new Date(item.scheduleAt).toLocaleString('pt-BR', { year: 'numeric', month: 'numeric', day: 'numeric', hour: '2-digit', minute: '2-digit' }) }}
      </template>
    </v-data-table-server>



    <MaintenanceModal :show="showModal" :maintenance="selectedMaintenance" :products="products" :isEditMode="isEditMode"
      @close="closeModal" @save="saveMaintenance" />
  </v-container>
</template>

<script>
import MaintenanceModal from '~/components/MaintenanceModal.vue';

export default {
  components: {
    MaintenanceModal
  },
  data() {
    return {
      itemsPerPage: 5,
      headers: [
        { title: 'Observação', key: 'observation' },
        { title: 'Produto', key: 'product.name' },
        { title: 'Agendado para', key: 'scheduleAt' },
        { title: 'Ação', key: 'action', align: 'center' }
      ],
      search: '',
      serverItems: [],
      loading: true,
      totalItems: 0,
      showModal: false,
      selectedMaintenance: { observation: '', productId: 0, scheduleAt: '' },
      products: [],
      isEditMode: false
    };
  },
  methods: {
    async loadItems({ page, itemsPerPage, sortBy }) {
      this.loading = true;
      await this.$axios.get('Maintenances').then(response => {
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
      this.selectedMaintenance = { observation: '', productId: null, scheduleAt: '' };
      this.isEditMode = false;
      this.showModal = true;
    },
    openEditModal(maintenance) {
      this.selectedMaintenance = { ...maintenance };
      this.isEditMode = true;
      this.showModal = true;
    },
    closeModal() {
      this.showModal = false;
    },
    async saveMaintenance(maintenance) {
      if (this.isEditMode) {
        await this.$axios.put(`Maintenances/${maintenance.id}`, maintenance);
      } else {
        await this.$axios.post('Maintenances', maintenance);
      }
      this.loadItems({ page: 1, itemsPerPage: this.itemsPerPage });
    },
    async removeMaintenance(maintenanceId) {
      try {
        await this.$axios.delete(`Maintenances/${maintenanceId}`);
        this.loadItems({ page: 1, itemsPerPage: this.itemsPerPage });
      } catch (error) {
        console.error(error);
      }
    }
  }
};
</script>
