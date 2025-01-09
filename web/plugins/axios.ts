import axios from 'axios';

export default defineNuxtPlugin((nuxtApp) => {
  const instance = axios.create({
    baseURL: 'http://localhost:5125/api/',
    headers: {
      common: {
        'Accept': 'application/json, text/plain, */*'
      }
    }
  });

  // Adicione o Axios à instância Nuxt
  nuxtApp.provide('axios', instance);
});
