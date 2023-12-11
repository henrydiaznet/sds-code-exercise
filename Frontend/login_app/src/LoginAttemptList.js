import React from "react";
import "./LoginAttemptList.css";

const LoginAttemptList = (props) => (
	<div className="Attempt-List-Main">
	 	<p>Recent activity</p>
	  	<input type="input" placeholder="Filter..." />
		<ul className="Attempt-List">
			{
				props.attempts.map((item, index) => <li key={index}>{'Login:' + item.login + ', Password:' + item.password}</li>)
			}
		</ul>
	</div>
);

export default LoginAttemptList;