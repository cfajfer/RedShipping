import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './pages/Home';
import ShipmentFlow from './pages/ShipmentFlow';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/new-shipment' component={ShipmentFlow} />
        <Route path='/orders' component={ShipmentFlow} />
      </Layout>
    );
  }
}
