import axios from 'axios';
import { getAccessToken} from './auth';

const api = axios.create({
    baseURL: 'https://ste-api.azurewebsites.net/api/',
});

api.interceptors.request.use(
    async (config) => {
        const token = getAccessToken();
        if (token) {
            config.headers['Authorization'] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

export default api;