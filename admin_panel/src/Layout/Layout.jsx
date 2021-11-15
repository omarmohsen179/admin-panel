import React from "react";
// javascript plugin used to create scrollbars on windows

import { Route, Switch, useHistory, useLocation } from "react-router-dom";
import { routes } from "./Routes";
import Navbar from "../Components/Navbar/Navbar";
import SideBar from "../Components/SlideBar/Sidebar";
import { CHECK_ADMIN } from "./Layout.Api";

const Layout = (props) => {
  let history = useHistory();
  require("../css/paper-dashboard.css");
  const mainPanel = React.useRef(null);
  const location = useLocation();

  React.useEffect(() => {
    mainPanel.current && (mainPanel.current.scrollTop = 0);
    document.scrollingElement && (document.scrollingElement.scrollTop = 0);
  }, [location]);
  const item = localStorage.getItem("user")
    ? JSON.parse(localStorage.getItem("user"))
    : {};
  if (!item?.type || item.type[0] !== "Admin") {
   //history.push("/log-in");
  } else {
    CHECK_ADMIN()
      .then((res) => console.log("success"))
      .catch((err) => {
      //   history.push("/log-in");
        localStorage.removeItem("user");
      });
  }

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
