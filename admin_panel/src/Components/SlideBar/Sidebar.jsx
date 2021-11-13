import React from "react";
import { NavLink } from "react-router-dom";
import { Nav } from "reactstrap";

const SideBar = (props) => {
  const sidebar = React.useRef(null);
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
        {"my username"}
      </div>
      <div className="sidebar-wrapper" ref={sidebar}>
        <Nav>
          {props.routes.map((prop, key) => {
            return (
              <li
                key={key}
                className={"list-slid-bar "}
                onClick={() => {
                  var element =
                    document.getElementsByClassName("list-slid-bar");
                  for (var i = 0; i < element.length; i++) {
                    if (i == key) {
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
                  className="nav-link"
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
