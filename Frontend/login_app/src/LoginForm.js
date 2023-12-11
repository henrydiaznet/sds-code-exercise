import React, {useState} from "react";
import './LoginForm.css';

const LoginForm = (props) => {
	const handleSubmit = (event) =>{
		event.preventDefault();
		const form = event.target;
		const formData = new FormData(form);
		const formObject = Object.fromEntries(formData.entries());
		console.log(formObject);
		props.onSubmit({
			login: formObject.login,
			password: formObject.password,
		});
		event.target.reset();
	}

	return (
		<form className="form" onSubmit={handleSubmit}>
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" id="name" name="login"/>
			<label htmlFor="password">Password</label>
			<input type="password" id="password" name="password" />
			<button type="submit" >Continue</button>
		</form>
	)
}

export default LoginForm;