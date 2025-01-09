<template>
  <div>
    <canvas height="100" ref="canvas"></canvas>
  </div>
</template>

<script>
import { Bar } from 'vue-chartjs';
import { Chart, BarElement, CategoryScale, LinearScale, Tooltip, Legend } from 'chart.js';

Chart.register(BarElement, CategoryScale, LinearScale, Tooltip, Legend);

export default {
  props: {
    chartData: {
      type: Object,
      required: true
    }
  },
  mounted() {
    this.createChart();
  },
  watch: {
    chartData: {
      handler() {
        if (this.chart) {
          this.chart.data = this.chartData;
          this.chart.update();
        }
      },
      deep: true
    }
  },
  methods: {
    createChart() {
      this.chart = new Chart(this.$refs.canvas, {
        type: 'bar',
        data: this.chartData,
        options: {
          responsive: true,
          scales: {
            y: {
              beginAtZero: true
            }
          }
        }
      });
    }
  }
};
</script>
