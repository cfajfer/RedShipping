import React from 'react';

import Grid from '@material-ui/core/Grid';
import MaterialTable from 'material-table'

const Carrier = (props) => {
    const handleSelection = (data) => {
        props.updateState('carrier', data);
        props.handleNext();
    }

    const carriers = [
        {carrierName: "Star Shipping", cost: 5.20, priority: "Highest", insured: true},
        {carrierName: "Midwest Trailers", cost: 1.75, priority: "Low", insured: false},
        {carrierName: "Toxic Transportation", cost: 3.00, priority: "High", insured: true},
    ]

    const columns = [
        {title: "Name", field: "carrierName"},
        {title: "Cost (USD) / mile", field: "cost", type: "currency"},
        {title: "Priority", field: "priority"},
        {title: "Insured", field: "insured", type: "boolean"},
    ]

    return (
        <Grid container>
            <MaterialTable style={{ width:'100%' }} title="Carriers" columns={columns} data={carriers}
            onRowClick={((evt, selectedRow) => handleSelection(selectedRow.carrierName))}/>
        </Grid>
    );
}

export default Carrier;