import React from 'react';

import Grid from '@material-ui/core/Grid';
import MaterialTable from 'material-table'


const Freight = (props) => {
    const locations = {
        Indianapolis: "Indianapolis", Chicago: "Chicago", NewYork: "New York", Detroit: "Detroit"
    }

    const columns = [
        {title: "Quantity", field: "quantity", type: "numeric"},
        {title: "Name", field: "shipperName"},
        {title: "Weight (kg)", field: "weight", type: "numeric"},
        {title: "Start Location", field: "startLocation", lookup: locations},
        {title: "End Location", field: "endLocation", lookup: locations},
    ]

    return (
        <Grid container>
            <MaterialTable style={{ width:'100%' }} title="Freight" columns={columns} data={props.freightData}
                editable={{
                onRowAdd: newFreightData =>
                    new Promise((resolve, reject) => {
                      setTimeout(() => {
                        props.updateState('freight', [...props.freightData, newFreightData]);
                        resolve();
                      }, 10)
                    }),
                onRowDelete: oldFreightData =>
                    new Promise((resolve, reject) => {
                      setTimeout(() => {
                        const dataDelete = [...props.freightData];
                        const index = oldFreightData.tableData.id;
                        dataDelete.splice(index, 1);
                        props.updateState('freight', [...dataDelete]);
                        resolve()
                      }, 10)
                    }),
                }}
            />
        </Grid>
    );
}

export default Freight;