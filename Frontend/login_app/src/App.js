import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';
import CurrentUser from "./CurrentUser";

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);
  const [loggedInUser, setLoggedInUser] = useState('');
  function handleLoginSubmit(formdata) {
    setLoginAttempts([...loginAttempts, {login: formdata.login, password: formdata.password}]);
    if(formdata.password === 'qwerty'){
      setLoggedInUser(formdata.login);
    }
  }

  return (
    <div className="App">
      <CurrentUser login={loggedInUser}></CurrentUser>
      <LoginForm onSubmit={handleLoginSubmit} />
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};


export default App;
