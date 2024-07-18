<template>
  <div id="app">
    <h1>The Bid Calculation Tool</h1>
    <div>
      <label for="textbox" style="width: 100px;">Enter Vehile Price:</label>
    </div>
    <div>
      <input type="text" v-model="textInput" id="textbox" style="width: auto;"/>
    </div>
    <div>
      <label for="dropdown" style="width: 100px;"> Select Type:</label>
      </div>
      <div>
      <select v-model="selectedOption" id="dropdown" style="width: auto;">
        <option value="1">Common</option>
        <option value="2">Luxury</option>
      </select>
    </div>
    <div>
      <button @click="fetchData" class="styled-button">Call API</button>
    </div>
    <div v-if="loading">Loading...</div>
    <div v-if="error">{{ error }}</div>
    <div v-if="items">
      <h2>API Response:</h2>
      <div>
      <table>
        <thead>
          <tr>
            <th>Vehicle Price</th>
            <th>Vehicale Type</th>
            <th>Basic</th>
            <th>Special</th>
            <th>Association</th>
            <th>Storage</th>
            <th>Total</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in items" :key="item.id">
            <td>{{ item.vehiclePrice }}</td>
            <td>{{ item.vehicleType }}</td>
            <td>{{ item.basicBuyerFee }}</td>
            <td>{{ item.sellerSpecialFee }}</td>
            <td>{{ item.associationFee }}</td>
            <td>{{ item.storageFee }}</td>
            <td>{{ item.total }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'App',
  data() {
    return {
      textInput: '',
      selectedOption: '',
      loading: false,
      error: null,
      items:[]
    };
  },
  methods: {
    async fetchData() {
      if (!this.textInput || !this.selectedOption) {
        return this.data = 'Vehicle Price and Type is Required'
      }
      this.loading = true;
      this.error = null;
      try {
        const response = await axios.get('https://localhost:44377/api/v1/bidcalculation/totalprice', {
          params: {
            vehiclePrice: this.textInput,
            vehicleType: this.selectedOption,
          },
        });
        this.items = response.data;
      } catch (error) {
        this.error = 'Error fetching data';
      } finally {
        this.loading = false;
      }
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #2c3e50;
  margin-top: 60px;
  margin-left: auto;
  
}

.styled-button {
  background-color: #4caf50;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-top: 10px;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
}

th {
  background-color: #f2f2f2;
  text-align: left;
}
</style>