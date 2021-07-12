import { Tabs, Typography, Spin } from "antd";
import { useState } from "react";
import useListItem from "../../Components/useListItem";
import DeviceList from "./DeviceList/DeviceList";
const { TabPane } = Tabs;
const { Text } = Typography;

const Devices = () => {
  const [brands, reloadBrands, loadingBrand, errorBrand] =
    useListItem("brands");
  const [currentBrandId, setCurrentBrandId] = useState("all");

  if (errorBrand) return <Text type="danger">{errorBrand}</Text>;

  if (loadingBrand)
    return (
      <div style={{ display: "flex", justifyContent: "center", marginTop: 50 }}>
        <Spin />
      </div>
    );

  return (
    <div>
      <Tabs
        onChange={(activekey) => setCurrentBrandId(activekey)}
        type="card"
        activeKey={currentBrandId}
      >
        <TabPane tab="All" key="all"></TabPane>
        {brands.map((brand) => {
          return <TabPane tab={brand.name} key={brand.id}></TabPane>;
        })}
      </Tabs>

      <DeviceList brandId={currentBrandId}/>
    </div>
  );
};

export default Devices;
