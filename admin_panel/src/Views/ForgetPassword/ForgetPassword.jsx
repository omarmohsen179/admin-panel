import { useCallback, useState } from "react";
import { useHistory } from "react-router";
import { LOGIN } from "./Login.Api";

import "./Login.css";
function ForgetPassword() {
  let history =useHistory()
  let [values, setvalues] = useState({ email: "" });
  let HandleChange = useCallback((e) => {
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
       Forget Password 
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

      <button class="submit" type={"submit"} align="center">
        Submit
      </button>
      </form>
      <p class="forgot" align="center">
        <a href="/log-in" >Sign In </a>
      </p>
    </div>
  );
}

export default ForgetPassword;
