
import 'font-awesome/css/font-awesome.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';
import { Route,Switch } from "react-router-dom";
import Layout from './Layout/Layout';
import Login from './Views/LogIn/Login';
function App() {
  return (
    <div className="App">
xx
      <Switch>
        <Route path="/" component={Layout} />
        <Route path="/log-in" component={Login} />
      </Switch>

     </div>
  );
}



export default App;