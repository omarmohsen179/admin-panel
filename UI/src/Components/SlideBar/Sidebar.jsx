import React, { useCallback } from "react";
import { NavLink } from "react-router-dom";
import { Nav } from "reactstrap";

const SideBar = (props) => {
  const sidebar = React.useRef(null);

  const activeRouteFUnction = useCallback((routeName, classname) => {
    if (props.location.pathname === "/") {
      return routeName === props.location.pathname
        ? classname + " active"
        : classname;
    }
    return props.location.pathname.indexOf(routeName) > -1 && routeName !== "/"
      ? classname + " active"
      : classname;
  }, []);
  // verifies if routeName is the one active (in browser input)
  return (
    <div
      className="sidebar"
      data-color={props.bgColor}
      data-active-color={props.activeColor}
    >
      <div className="logo slidebar-username">
        <a href="/" className="logo-normal slidebar-title">
          <i className="fas fa-user"></i>
        </a>
      </div>
      <div className="sidebar-wrapper" ref={sidebar}>
        <Nav>
          {props.routes.map((prop, key) => {
            return (
              <li
                key={key}
                className={activeRouteFUnction(prop.path, "list-slid-bar")}
                onClick={() => {
                  var element =
                    document.getElementsByClassName("list-slid-bar");
                  for (var i = 0; i < element.length; i++) {
                    if (i === key) {
                      if (!element[i].classList.contains("active")) {
                        element[i].classList.add("active");
                      }
                    } else {
                      if (element[i].classList.contains("active")) {
                        element[i].classList.remove("active");
                      }
                    }
                  }
                }}
              >
                <NavLink
                  exact
                  to={prop.layout + prop.path}
                  className={activeRouteFUnction(prop.path, "nav-link")}
                  activeClassName="active"
                >
                  <i className={prop.icon} />
                  <p>{prop.name}</p>
                </NavLink>
              </li>
            );
          })}
        </Nav>
      </div>
    </div>
  );
};

export default SideBar;
