<template>
  <canvas id="my-chart"></canvas>
</template>

<script>
import Chart from "chart.js";

export default {
  props: ["buy", "sell"],
  mounted() {
    var ctx = document.getElementById("my-chart");

    var myChart = new Chart(ctx, {
      type: "bar",
      data: {
        labels: [`ส่วนต่าง${this.sell[0]-this.buy[0]}`, `ส่วนต่าง${this.sell[1]-this.buy[1]}`, "Week 3", "Week 4"],
        datasets: [
          {
            label: "ซื้อ",
            data: this.buy,
            borderColor: "#ffffff",
            fill: false
          },
          {
            label: "ขาย",
            data: this.sell,
            borderColor: "#000000",
            fill: false
          }
        ]
      },
      options: {
        responsive: true
      }
    });
  }
};
</script>

<style>
</style>