import React, { useEffect, useState } from 'react';
import {Container} from 'reactstrap';
import Query from '../utility/Query';

import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles({
  appbar: {
    color: '#fff',
    background: '#161616',
  },
  appbarTypography: {
    lineHeight: 1,
    fontWeight: 600,
  },
  logo: {
    height: '50px',
    margin: '1rem 0px',
  },
});

const Header = () => {
  const classes = useStyles();
  const [shipperName, setShipperName] = useState('');

  useEffect(() => {
    async function callQuery(){
        let response = await Query('/api/DBShippers', 'get');
        response = (!response.error ? response.data : null);
        setShipperName(response.map(cur => (cur.name)));
    }
    callQuery();
  }, []);

  return (
    <Grid container>
      <AppBar className={classes.appbar} position="static" elevation={0}>
      <Toolbar variant="dense">
        <Container>

          <Typography className={classes.appbarTypography} variant="subtitle1" color="inherit">
            Welcome {shipperName}!
          </Typography>

        </Container>
      </Toolbar>
      </AppBar>

      <Container>
        <a href="/"><img className={classes.logo} src="/logo.png" /></a>
      </Container>
    </Grid>
  );
}

export default Header;