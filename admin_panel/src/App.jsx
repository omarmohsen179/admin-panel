import "font-awesome/css/font-awesome.min.css";
import "../node_modules/bootstrap/dist/css/bootstrap.css";
import "bootstrap/dist/js/bootstrap.bundle";
import "popper.js/dist/popper";

import "@fortawesome/fontawesome-free/css/all.min.css";
import { Route, Switch } from "react-router-dom";
import Layout from "./Layout/Layout";
import Login from "./Views/LogIn/Login";
import ForgetPassword from "./Views/ForgetPassword/ForgetPassword";
function App() {
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
