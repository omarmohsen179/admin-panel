import React from "react";
// javascript plugin used to create scrollbars on windows
import { signOut, user_selector } from "../Store/AuthReducer";
import { Route, Switch, useHistory, useLocation } from "react-router-dom";
import { routes } from "./Routes";
import Navbar from "../Components/Navbar/Navbar";
import SideBar from "../Components/SlideBar/Sidebar";
import { CHECK_ADMIN } from "./Layout.Api";
import { useSelector, useDispatch } from "react-redux";
import { RemoveFromLocalStorage } from "../Services/LocalStorageService";
import axios from "axios";
const Layout = (props) => {
  let history = useHistory();
  let dispatch = useDispatch();
  let selector = useSelector(user_selector);
  require("../css/paper-dashboard.css");
  const mainPanel = React.useRef(null);
  const location = useLocation();

  React.useEffect(async () => {
    console.log(selector);
    if (Object.keys(selector).length === 0) {
      history.push("/log-in");
    }
    mainPanel.current && (mainPanel.current.scrollTop = 0);
    document.scrollingElement && (document.scrollingElement.scrollTop = 0);
  }, [location]);

  /*const item = localStorage.getItem("user")
    ? JSON.parse(localStorage.getItem("user"))
    : {};
  if (!item.token) {
    
  } else {

  }*/

  return (
    <div className="wrapper">
      <SideBar
        {...props}
        routes={routes}
        bgColor={"black"}
        activeColor={"primary"}
      />
      <div className="main-panel" ref={mainPanel}>
        <Navbar {...props} />

        <Switch>
          {routes.map((prop, key) => {
            // prop.name != 'Logout' ?
            return (
              <Route
                path={prop.layout + prop.path}
                component={prop.component}
                exact
                key={key}
              />
            );
          })}
        </Switch>
      </div>
    </div>
  );
};

export default Layout;
