import React, { useEffect, useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';

import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography'
import Grid from '@material-ui/core/Grid'
import Button from '@material-ui/core/Button'
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Divider from '@material-ui/core/Divider';
import LocalShippingIcon from '@material-ui/icons/LocalShipping';
import HistoryIcon from '@material-ui/icons/History';

const useStyles = makeStyles({
  card: {
    transition: 'all 0.15s ease-in-out',

    '&:hover': {
      background: 'rgba(0, 0, 0, .05)',
    },
  },
  button: {
    color: 'rgba(0, 0, 0, 0.87)',
    boxShadow: 'inset 0 -2px 0 #db3534',
    borderRadius: 0,
    padding: '4px 8px',
    transition: 'all 0.15s ease-in-out',

    '&:hover': {
      color: '#fff',
      boxShadow: 'inset 0 -10em 0 #d92a29',
    },
  },
  heroImg: {
    marginRight: 'auto',
    display: 'flex',
  },
  heroGrid: {
    marginBottom: '2rem',
  },
  contentGrid: {
    marginTop: '2rem',
  },
  divider: {
    width: '100%',
    height: '2px',
    backgroundColor: '#db3534',
  },
});

const Welcome = () => {
  const classes = useStyles();
  const [cardStyle, setCardStyle] = useState('');

  return (
    <Grid container direction="column" justify="center" alignItems="center">

      <Grid className={classes.heroGrid} container direction="row" spacing={10}>
        <Grid item md={6} xs={12}>
          <Typography variant="h2" color="initial" align="right">
            SHIPPING<br/>LOGISTICS<br/>MADE EASY
          </Typography>
        </Grid>
        <Grid item md={6} xs={12}>
          <img className={classes.heroImg} src="/hero.png" />
        </Grid>
      </Grid>

      <Divider className={classes.divider}/>

      <Grid className={classes.contentGrid} container direction="row" spacing={10}>
        <Grid item md={6} xs={12}>
          <Card className={cardStyle}>
          <CardMedia component="img" alt="Shipping Portal" height="190" image="/shipping.jpg" title="Shipping Portal"/>
          <CardContent>
            <Typography gutterBottom variant="h4" component="h2">
              Shipping Portal
            </Typography>
            <Typography variant="body1" color="textSecondary" component="p">
              Select your freight and a carrier to start shipping today. Receive quotes and decide on the most efficient shipping method.
            </Typography>
          </CardContent>
          <CardActions>
            <Button className={classes.button} size="large" color="primary" endIcon={<LocalShippingIcon />} component={RouterLink} to="/new-shipment" onMouseEnter={() => {setCardStyle(classes.card)}} onMouseLeave={() => {setCardStyle('')}}>
              Start Shipping
            </Button>
          </CardActions>
          </Card>
        </Grid>

        <Grid item md={6} xs={12}>
          <Card className={cardStyle}>
          <CardMedia component="img" alt="Shipping Portal" height="190" image="/orders.jpg" title="Shipping Portal"/>
          <CardContent>
            <Typography gutterBottom variant="h4" component="h2">
              Invoice Portal
            </Typography>
            <Typography variant="body1" color="textSecondary" component="p">
              Review your previous orders and see detailed information about freight shipments.
            </Typography>
          </CardContent>
          <CardActions>
            <Button className={classes.button} size="large" color="primary" endIcon={<HistoryIcon />} component={RouterLink} to="/order" onMouseEnter={() => {setCardStyle(classes.card)}} onMouseLeave={() => {setCardStyle('')}}>
              Review Orders
            </Button>
          </CardActions>
          </Card>
        </Grid>
      </Grid>

    </Grid>
  );
}

export default Welcome;