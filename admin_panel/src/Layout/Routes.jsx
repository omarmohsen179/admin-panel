import AboutUs from "../Views/AboutUs/AbourUs";
import Footer from "../Views/Footer/Footer";
import Home from "../Views/Home/Home";

export const routes = [
  {
    path: "/",
    name: "Home",
    icon: "fas fa-home",
    component: Home,
    layout: "",
  },
  {
    path: "/About-us",
    name: "About us",
    icon: "fas fa-user-edit",
    component: AboutUs,
    layout: "",
  },
  {
    path: "/Footer",
    name: "Footer",
    icon: "fas fa-home",
    component: Footer,
    layout: "",
  },
];
