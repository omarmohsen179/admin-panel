
import 'font-awesome/css/font-awesome.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';

import './style/scss/paper-dashboard.scss'
import { Route,Switch } from "react-router-dom";
import Layout from './Layout/Layout';
import Login from './Views/LogIn/Login';
function App() {
  return (
    <div className="App"> 
    <div className="test-css-class">

      dsggdfg
    </div>
      <Switch>
        <Route path="/" component={Layout} />
        <Route path="/log-in" component={Login} />
      </Switch>

     </div>
  );
}



export default App;