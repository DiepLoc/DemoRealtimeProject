import { Route, Switch } from "react-router-dom";
import routerConfig from "../Configs/router-config";
import AppFooter from "../Layouts/AppFooter";
import AppHeader from "../Layouts/AppHeader";
import "./App.css";

function App() {
  return (
    <div className="App">
      <AppHeader></AppHeader>
      <div style={{ padding: "50px 50px", margin: "0px auto" }}>
        <Switch>
          {routerConfig.map((router) => (
            <Route
              key={router.key}
              path={router.path}
              exact={router.exact}
              children={router.children}
            />
          ))}
        </Switch>
      </div>
      <AppFooter></AppFooter>
    </div>
  );
}

export default App;
