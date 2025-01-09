<template>
  <v-container>
    <h1>Financeiro</h1>
    <v-card>
      <v-card-title>Valor Total por Produtos em estoque</v-card-title>
      <v-card-text>
        <BarChart :chart-data="chartData" />
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
import axios from 'axios';
import BarChart from '../components/BarChart.vue';

export default {
  components: {
    BarChart
  },
  data() {
    return {
      chartData: {
        labels: [],
        datasets: [
          {
            label: 'Valor Total',
            backgroundColor: '#00838F',
            data: []
          }
        ]
      }
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    async fetchData() {
      try {
        const response = await this.$axios.get('Products/total-value');
        const data = response.data;

        console.log('data',data)

        this.chartData.labels = data.map(item => item.name);
        this.chartData.datasets[0].data = data.map(item => item.totalValue);

        console.log('this.chartData',this.chartData)
      } catch (error) {
        console.error('Erro ao buscar dados:', error);
      }
    }
  }
};
</script>
