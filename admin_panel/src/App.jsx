import "font-awesome/css/font-awesome.min.css";
import "../node_modules/bootstrap/dist/css/bootstrap.css";
import "bootstrap/dist/js/bootstrap.bundle";
import "popper.js/dist/popper";
import "devextreme/dist/css/dx.light.css";

import "@fortawesome/fontawesome-free/css/all.min.css";
import { Route, Switch } from "react-router-dom";
import Layout from "./Layout/Layout";
import Login from "./Views/LogIn/Login";
import ForgetPassword from "./Views/ForgetPassword/ForgetPassword";
import { GetFromLocalStorage } from "./Services/LocalStorageService";

import { useDispatch } from "react-redux";
import { useEffect } from "react";
import { userLoginLocalStorage } from "./Store/AuthReducer";
function App() {
  const dispatch = useDispatch();

  useEffect(() => {
    GetFromLocalStorage("user-auth") &&
      dispatch(userLoginLocalStorage(GetFromLocalStorage("user-auth")));
  }, []);
  return (
    <div className="App">
      <Switch>
        <Route path="/log-in" component={Login} />
        <Route path="/forget-password" component={ForgetPassword} />
        <Route path="/" component={Layout} />
      </Switch>
    </div>
  );
}

export default App;
