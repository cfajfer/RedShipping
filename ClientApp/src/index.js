import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
rootElement.setAttribute("style", "max-width: 100vw; background-image: linear-gradient(to bottom, rgba(255, 255, 255, 0) 0%, rgba(255, 255, 255, 0) 120px, white 35rem), url(https://redtms.com/wp-content/themes/red-tms-theme/images/bg-pattern--plus-and-dashes-@2x.png); background-repeat: repeat; background-position: 50% 0; background-size: auto, 15px auto;");

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();

