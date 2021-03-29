import axios from 'axios';

const Query = async (endpoint, method, data) => {

    let response = await axios({
        method: method,
        url: endpoint,
        data: data
    }).then(res => {
        let obj = {};
        switch (res.status) {
            //Success
            case 200:
                obj.error = false;
                obj.data = res.data;
                break;
            //Unknown Error
            default:
                obj.error = true;
                obj.msg = "error occured";
                break;
        }
        return obj;
    }).catch(err => {
        //Default Error
        return {
            error: true,
            msg: err.response.data.message
        }
    });

    return response;
}

export default Query;