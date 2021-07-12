import { Spin, Table } from "antd";
import Text from "antd/lib/typography/Text";
import React, { useEffect } from "react";
import useListItem from "../../../Components/useListItem";

const columns = [
  {
    title: 'Id',
    dataIndex: 'id',
    key: 'id',
    render: text => <a>{text}</a>,
  },
  {
    title: 'Name',
    dataIndex: 'name',
    key: 'name',
  },
  {
    title: 'Brand',
    dataIndex: 'braneName',
    key: 'brandName',
    render: (_,record) => record.brand.name 
  },
  {
    title: 'Price',
    dataIndex: 'price',
    key: 'price',
  },
]

const reloadString = (brandId) =>
  `devices?brand_id=${brandId == "all" ? "" : brandId}`;

const DeviceList = ({ brandId }) => {
  const [devices, reloadDevices, loading, error] = useListItem(
    reloadString(brandId)
  );

  useEffect(() => {
    reloadDevices( reloadString(brandId));
  }, [brandId]);

  if (error) return <Text type="danger">{error}</Text>;

  if (loading)
    return (
      <div style={{ display: "flex", justifyContent: "center", marginTop: 50 }}>
        <Spin />
      </div>
    );

  return <Table columns={columns} dataSource={devices} />
};

export default DeviceList;
