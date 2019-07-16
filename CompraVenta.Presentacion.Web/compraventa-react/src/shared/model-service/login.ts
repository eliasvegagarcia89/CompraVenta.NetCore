import axios from 'axios';

const login = (usuario:string, password:string) => {
    return axios.get('/values'
    //     , {
    //     params: {
    //         usuario,
    //         password
    //     }
    // }
    );
}

const LoginService = {
    login
}

export { LoginService };