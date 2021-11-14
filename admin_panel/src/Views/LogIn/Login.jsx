import { useCallback, useState } from "react";
import { useHistory } from "react-router";
import { LOGIN } from "./Login.Api";

import "./Login.css";
function Login() {
  let history =useHistory()
  let [values, setvalues] = useState({ email: "", password: "" });
  let HandleChange = useCallback((e) => {
    console.log(e)
    setvalues((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  }, []);
  let Submit = useCallback(async(e) => {
    e.preventDefault();
    LOGIN(values).then((res ) =>{
      localStorage.setItem("user", JSON.stringify(res))
      history.push('/log-in')
    }).catch((err)=>{

    })
  }, [values]);
    return (
    <div class="main">
      <p class="sign" align="center">
        Sign in
      </p>
      <form class="form1" onSubmit={Submit}>
        <input
          class="un "
          type="text"
          align="center"
          name={"email"}
          onChange={HandleChange}
          value={values.email}
          placeholder="E-mail"
        />
        <input
          type="password"
          align="center"
          name="password"
          className="un"
          value={values.password}
          onChange={HandleChange}
          placeholder="Password"
        />

      <button class="submit" type={"submit"} align="center">
        Sign in
      </button>
      </form>
      <p class="forgot" align="center">
        <a href="#">Forgot Password?</a>
      </p>
    </div>
  );
}

export default Login;
