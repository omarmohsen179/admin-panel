import { useCallback, useState } from "react";
import { useHistory ,Link} from "react-router-dom";
import { LOGIN } from "./Login.Api";

import "./Login.css";
function Login(props) {
  let history =useHistory()
  let [values, setvalues] = useState({ email: "", password: "" });
  let HandleChange = useCallback((e) => {
    setvalues((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  }, []);
  let Submit = useCallback(async(e) => {
    e.preventDefault();
    LOGIN(values).then((res ) =>{
      localStorage.setItem("user", JSON.stringify(res))
      history.push('/')
    }).catch((err)=>{

    })
  }, [values,history]);
    return (
    <div class="main">
      <p class="sign" align="center">
        Sign in
      </p>
      <form class="form1" onSubmit={Submit}>
        <input
          class="un "
          type="email"
          align="center"
          name={"email"}
          autoComplete={false}
          onChange={HandleChange}
          value={values.email}
          placeholder="E-mail"
        />
        <input
          type="password"
          align="center"
          name="password"
          className="un"
          autoComplete={false}
          value={values.password}
          onChange={HandleChange}
          placeholder="Password"
        />

      <button class="submit" type={"submit"} align="center">
        Sign in
      </button>
      </form>
      <p class="forgot" align="center">
        <Link to="/forget-password" >Forgot Password?</Link>
      </p>
    </div>
  );
}

export default Login;
