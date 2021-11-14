import { useCallback, useState } from "react";
import { LOGIN } from "./Login.Api";

import "./Login.css";
function Login() {
  let [values, setvalues] = useState({ Email: "", Password: "" });
  let HandleChange = useCallback((e) => {
    setvalues((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  }, []);
  let Submit = useCallback(async(e) => {
    e.preventDefault();
    LOGIN(values)
  }, []);
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
          name={"Email"}
          onChange={HandleChange}
          value={values.Email}
          placeholder="E-mail"
        />
        <input
          type="password"
          align="center"
          name="Password"
          className="un"
          value={values.Password}
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
