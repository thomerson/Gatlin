//import Vue from 'vue';
//import axios from 'axios';


Vue.prototype.$axios = axios
axios.defaults.baseURL = 'http://localhost:6323/api';
axios.defaults.headers.common['Authorization'] = "Bearer " + document.cookie['token'];

//axios.defaults.headers.post['Content-Type'] = 'application/json';
//axios.defaults.headers.put['Content-Type'] = 'application/json';
axios.defaults.headers.post['Content-Type'] = 'application/json;charset=UTF-8';

// 添加请求拦截器
axios.interceptors.request.use(function (config) {
    config.headers.Authorization = "Bearer " + document.cookie['token'];
    console.info(config);
    return config;
}, function (error) {
    return Promise.reject(error);
});

//export default axios

