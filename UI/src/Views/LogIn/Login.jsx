import { useCallback, useState, useEffect } from "react";
import { useHistory, Link } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { userLogin, user_selector } from "../../Store/AuthReducer";
import "./Login.css";
import { StoreToLocalStorage } from "../../Services/LocalStorageService";
function Login() {
  let dispatch = useDispatch();
  let selector = useSelector(user_selector);
  let history = useHistory();

  let [values, setvalues] = useState({
    email: "",
    password: "",
    rememberMe: false,
  });

  useEffect(() => {
    if (Object.keys(selector).length > 0) {
      history.push("/");
    }
  }, [selector]);
  let HandleChange = useCallback((e) => {
    setvalues((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  }, []);
  let Submit = useCallback(
    async (e) => {
      e.preventDefault();
      dispatch(await userLogin(values));
    },
    [values, history]
  );
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

        <div className="login-remeber-me-checkbox">
          <input
            type="checkbox"
            name="rememberMe"
            onChange={(e) =>
              setvalues({ ...values, rememberMe: e.target.checked })
            }
            value={values.rememberMe}
          />
          <label className="label-shared-style"> Remember me</label>
        </div>

        <button class="submit" type={"submit"} align="center">
          Sign in
        </button>
      </form>
      <p class="forgot" align="center">
        <Link to="/forget-password" className="label-shared-style">
          Forgot Password?
        </Link>
      </p>
    </div>
  );
}

export default Login;
