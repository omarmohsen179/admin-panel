import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import { HashRouter } from "react-router-dom";
import App from "./App";
import { Provider } from "react-redux";
import configureStore from "./Store/ConfigureStore";
import { LanguageProvider } from "./Services/LangueContext";
ReactDOM.render(
  <HashRouter>
    <LanguageProvider>
      <Provider store={configureStore()}>
        <App />
      </Provider>
    </LanguageProvider>
  </HashRouter>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
//reportWebVitals();
