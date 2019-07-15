import * as React from 'react';
import * as ReactDOM from 'react-dom';
// import App from './App';
import Login from '../src/components/Login';
import './index.css';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(
  // <App />,
  <Login />,
  document.getElementById('root') as HTMLElement
);
registerServiceWorker();
