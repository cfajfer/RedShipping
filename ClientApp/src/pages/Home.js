import React, { Component } from 'react';

import Welcome from '../components/Welcome';
import Grid from '@material-ui/core/Grid';

export class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {

    }
  }

  render(){
    return (
      <Grid container direction="row" justify="center" alignItems="center">
        <Welcome />
      </Grid>
    );
  }
}