import Devices from "../Pages/Devices/DeviceContainer";

const routerConfig = [
  {
    key: "home",
    path: "/",
    exact: true,
    children: () => <div>Home</div>
  },
  {
    key: "device",
    path: "/device",
    exact: false,
    children: () => <Devices/>
  },
  {
    key: "error",
    path: "*",
    exact: false,
    children: () => <div>error</div>
  },
]

export default routerConfig;