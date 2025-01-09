<template>
  <v-dialog v-model="localShow" persistent max-width="600px">
    <v-card>
      <v-card-title>
        <span class="headline">{{ isEditMode ? 'Editar Manutenção' : 'Cadastrar Manutenção' }}</span>
      </v-card-title>
      <v-card-text>
        <v-form ref="form">
          <v-text-field v-model="localMaintenance.observation" label="Observação" ></v-text-field>
          <v-autocomplete
            v-model="localMaintenance.productId"
            :items="products"
            item-value="id"
            item-title="name"
            label="Produto"
          ></v-autocomplete>
          <v-text-field v-model="localMaintenance.scheduleAt" label="Agendado para" type="datetime-local" required></v-text-field>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
        <v-btn color="blue darken-1" text @click="saveMaintenance">{{ isEditMode ? 'Salvar' : 'Cadastrar' }}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: {
    show: Boolean,
    maintenance: Object,
    products: Array,
    isEditMode: Boolean
  },
  data() {
    return {
      localShow: false,
      localMaintenance: { ...this.maintenance }
    };
  },
  watch: {
    maintenance(newVal) {
      this.localMaintenance = { ...newVal };
    },
    show(newVal) {
      this.localShow = newVal;
    }
  },
  methods: {
    close() {
      this.$emit('close');
    },
    saveMaintenance() {
      this.$emit('save', this.localMaintenance);
      this.close();
    }
  }
};
</script>
