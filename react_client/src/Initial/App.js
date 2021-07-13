import React, { useEffect, useReducer } from "react";
import { Route, Switch } from "react-router-dom";
import routerConfig from "../Configs/router-config";
import AppFooter from "../Layouts/AppFooter";
import AppHeader from "../Layouts/AppHeader";
import reducer from "./reducer";
import initStore from "./initStore";
import "./App.css";

const AppContext = React.createContext(null);

function App() {
  const [state, dispatch] = useReducer(reducer, initStore());

  return (
    <AppContext.Provider value={{ state, dispatch }}>
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
    </AppContext.Provider>
  );
}
export { AppContext };
export default App;
