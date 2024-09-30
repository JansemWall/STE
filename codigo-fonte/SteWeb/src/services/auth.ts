import axios from 'axios';
import Cookies from 'js-cookie';

const API_URL = 'https://steapi-a0eme3ddf0auezbn.brazilsouth-01.azurewebsites.net/api/';

export function decodeToken(token) {
    const payload = token.split('.')[1];
    const decodedPayload = atob(payload);
    return JSON.parse(decodedPayload);
}

export const login = async (name, password) => {
    try {
        const response = await axios.post(`${API_URL}User/authenticate/`, { name, password });
        if (response.data.access) {
            Cookies.set('access_token', response.data.access, { expires: 1 });

        }
        return response.data;
    } catch (error) {
        console.error('Erro ao fazer login:', error);
        throw error;
    }
};

export const logout = () => {
    Cookies.remove('access_token');
    // Cookies.remove('refresh_token');
    window.location.reload();
};

export const getAccessToken = () => Cookies.get('access_token');