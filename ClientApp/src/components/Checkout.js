import React from 'react';

import Grid from '@material-ui/core/Grid';
import MaterialTable from 'material-table'

const Checkout = (props) => {
    const freightColumns = [
        {title: "Quantity", field: "quantity"},
        {title: "Name", field: "shipperName"},
        {title: "Weight (kg)", field: "weight"},
        {title: "Start Location", field: "startLocation"},
        {title: "End Location", field: "endLocation"},
    ]

    return (
        <Grid container>
            <MaterialTable style={{ width:'100%' }} title={`Selected Carrier: ${props.carrierData}`} columns={freightColumns} data={props.freightData}/>
        </Grid>
    );
}

export default Checkout;