import React, { Component } from 'react';
import Query from '../utility/Query';
import Freight from '../components/Freight';
import Carrier from '../components/Carrier';
import Checkout from '../components/Checkout';

import { withStyles } from '@material-ui/core/styles';
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

const styles = theme => ({
  button: {
    color: 'rgba(0, 0, 0, 0.87)',
    boxShadow: 'inset 0 -2px 0 #db3534',
    borderRadius: 0,
    padding: '4px 8px',
    transition: 'all 0.15s ease-in-out',
    backgroundColor: 'transparent',

    '&:hover': {
      color: '#fff',
      boxShadow: 'inset 0 -10em 0 #d92a29',
    },
  },
  stepper: {
    backgroundColor: 'transparent',
  },
});


// Main class for shipment flow (add freight -> select carrier -> checkout)
// Contains state for Freight.js, Carrier.js, and Checkout.js components.
class ShipmentFlow extends Component {
  constructor(props) {
    super(props);
    this.state = {
      freightData: [],
      carrierData: [],
      activeStep: 0,
    }
    this.getSteps = this.getSteps.bind(this);
    this.updateState = this.updateState.bind(this);
    this.getStepContent = this.getStepContent.bind(this);
    this.handleFinish = this.handleFinish.bind(this);
    this.handleNext = this.handleNext.bind(this);
    this.handleBack = this.handleBack.bind(this);
  }
  
  getSteps() {
    return ['Add your freight', 'Select available carrier', 'Confirm shipment'];
  };

  updateState(state ,data) {
    if(state === 'freight'){
      this.setState({freightData: data});
      console.log(data);
    }
    if(state === 'carrier'){
      this.setState({carrierData: data});
      console.log(data);
    }
  };

  getStepContent(step) {
    switch (step) {
      case 0:
          return <Freight freightData={this.state.freightData} updateState={this.updateState}/>;
      case 1:
        return <Carrier carrierData={this.state.carrierData} updateState={this.updateState}handleNext={this.handleNext} />;
      case 2:
        return <Checkout carrierData={this.state.carrierData} freightData={this.state.freightData} />;
      default:
        return 'Error return to shipping homepage';
    }
  };

  // Handle data submission
  async handleFinish() {
    // await Query('/api/DBShipments', 'post', this.state.freightData);
    this.setState(prevState => {
      return {
        activeStep: prevState.activeStep + 1 
      }
    });
  }
  // Next step handler
  handleNext() {
    this.setState(prevState => {
      return {
        activeStep: prevState.activeStep + 1 
      }
    });
  };
  // Previous step handler
  handleBack() {
    this.setState(prevState => {
      return {
        activeStep: prevState.activeStep - 1 
      }
    });
  };

  render(){

    const { classes } = this.props;
    const steps = this.getSteps();

  return (
    <div>
      <Stepper className={classes.stepper} activeStep={this.state.activeStep}>
        {steps.map((label, index) => {
          const stepProps = {};
          const labelProps = {};
          return (
            <Step key={label} {...stepProps}>
              <StepLabel {...labelProps}>{label}</StepLabel>
            </Step>
          );
        })}
      </Stepper>
      <div>
        {this.state.activeStep === steps.length ? (
          <div>
            <Typography variant="h2" color="initial" align="centter">
              Thank you for your shipment!
            </Typography>
          </div>
        ) : (
          <div>
            <Typography>{this.getStepContent(this.state.activeStep)}</Typography>
            <div>
              <Button disabled={this.state.activeStep === 0} onClick={this.handleBack} size="large">
                Back
              </Button>

              {/* Next step button is disabled if freight has not been entered or when a carrier has not been selected. */}
              <Button className={classes.button} disabled={this.state.activeStep === 1 || this.state.freightData.length === 0}
              variant="contained" color="primary" size="large"
              onClick={this.state.activeStep === steps.length - 1 ? this.handleFinish : this.handleNext} >
                {this.state.activeStep === steps.length - 1 ? 'Finish' : 'Next'}
              </Button>
            </div>
          </div>
        )}
      </div>
    </div>
  );
  }
}

export default withStyles(styles)(ShipmentFlow);
