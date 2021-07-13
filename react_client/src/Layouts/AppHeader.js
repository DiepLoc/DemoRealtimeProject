import { Badge, Menu } from "antd";
import { Header } from "antd/lib/layout/layout";
import { Link, useLocation } from "react-router-dom";
import headerConfig from "../Configs/header-config";
import { DesktopOutlined } from "@ant-design/icons";
import "./index.css";
import { useContext, useEffect } from "react";
import { AppContext } from "../Initial/App";
import useTotalCount from "../Components/useTotalCount";
import useMySignalR from "../Components/useMySignalR";

const AppHeader = () => {
  const location = useLocation();
  const currentPath = location?.pathname?.split("/")[1] || "";

  const [count, reloadCount] = useTotalCount();
  const [requestReload] = useMySignalR("ReloadData");

  const { state, dispatch } = useContext(AppContext);

  useEffect(() => {
    reloadCount();
  }, [requestReload]);
  console.log(requestReload)

  useEffect(() => {
    dispatch({type: "CHANGE_TOTAL_DEVICE", payload: count});
    console.log(count)
  }, [count])

  return (
    <Header>
      <Menu
        id="header-menu"
        theme="dark"
        mode="horizontal"
        selectedKeys={currentPath}
      >
        {headerConfig.map((header) => (
          <Menu.Item key={header.key}>
            <Link to={header.link}>{header.displayName}</Link>
          </Menu.Item>
        ))}
      </Menu>
      <div
        style={{ marginTop: 20, display: "flex", justifyContent: "flex-end" }}
      >
        <Badge count={state.totalDevice} showZero>
          <DesktopOutlined style={{ fontSize: "1.5rem" }} />
        </Badge>
      </div>
    </Header>
  );
};

export default AppHeader;
