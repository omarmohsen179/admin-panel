import { useCallback, useState } from "react";
import { useHistory ,Link} from "react-router-dom";
import { FORGET_PASSWORD } from "./ForgetPassword.Api";

function ForgetPassword() {
  let history =useHistory()
  let [values, setvalues] = useState({ email: "" });
  let HandleChange = useCallback((e) => {
    setvalues((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  }, []);
  let Submit = useCallback(async(e) => {
    e.preventDefault();
    FORGET_PASSWORD(values).then((res ) =>{
      localStorage.setItem("user", JSON.stringify(res))
      history.push('/log-in')
    }).catch((err)=>{

    })
  }, [values,history]);
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
      <Link to="/log-in" >Sign In</Link>
    
      </p>
    </div>
  );
}

export default ForgetPassword;
