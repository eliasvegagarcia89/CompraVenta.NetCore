import axios from 'axios';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
// import App from './App';
import Login from '../src/components/Login';
import './index.css';
import registerServiceWorker from './registerServiceWorker';
import {API_ENDPOINT} from 'src/variables/global';

axios.defaults.baseURL = API_ENDPOINT;//process.env.REACT_APP_API_URL;
axios.defaults.headers.common.Authorization = '';

axios.interceptors.request.use(request => {
  if (request.method === "get") {
      const params = { ...request.params };
      // params.codigoModular = perfil.institucionEducativa.codigoModular;
      // params.anexo = perfil.institucionEducativa.anexo;
      // params.anioId = perfil.institucionEducativa.anio;
      // params.nivelId = perfil.institucionEducativa.nivelEducativo.id;
      // params.usuarioId = perfil.usuario.usuario
      request.params = params;
  }
  else if (request.method === "post" && request.headers["Content-Type"] === "multipart/form-data") {
      // request.data.append("codigoModular", perfil.institucionEducativa.codigoModular);
      // request.data.append("anexo", perfil.institucionEducativa.anexo)
      // request.data.append("anioId", perfil.institucionEducativa.anio)
      // request.data.append("nivelId", perfil.institucionEducativa.nivelEducativo.id)
      // request.data.append("usuarioId", perfil.usuario.usuario)

  } else if (request.method === "post" && request.headers["Content-Type"] !== "multipart/form-data") {
      const data = { ...request.data };
      // data.codigoModular = perfil.institucionEducativa.codigoModular;
      // data.anexo = perfil.institucionEducativa.anexo;
      // data.anioId = perfil.institucionEducativa.anio;
      // data.nivelId = perfil.institucionEducativa.nivelEducativo.id;
      // data.usuarioId = perfil.usuario.usuario
      request.data = data;
  }

  return request;
}, error => {
  return Promise.reject(error);
});

axios.interceptors.response.use(response => {
  if (response.data.success === undefined || response.data.success === null) {
      alert("Formato de respuesta no válido");
  // } else if (response.success === false) {
  //     alert(response.messages);
  }
  return response.data;
}, error => {
  // console.log("error axios response");
  return Promise.reject(error);
});

ReactDOM.render(
  // <App />,
  <Login />,
  document.getElementById('root') as HTMLElement
);
registerServiceWorker();
