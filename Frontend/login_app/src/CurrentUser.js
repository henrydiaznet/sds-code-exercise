import React from "react";

function CurrentUser(props){
    if (props.login !== ''){
        return <h2>Logged in user: {props.login }</h2>
    }
    else {
        return <></>
    }
}

export default CurrentUser;