import {
  Button,
  message,
  notification,
  Popconfirm,
  Space,
  Table,
  Tooltip,
} from "antd";
import { PlusCircleOutlined } from "@ant-design/icons";
import Text from "antd/lib/typography/Text";
import React, { useEffect, useState } from "react";
import useListItem from "../../../Components/useListItem";
import useMySignalR from "../../../Components/useMySignalR";
import DeviceModal from "../DeviceModal/DeviceModal";
import { handleAddDevice, handleDeleteDevice, handleEditDevice } from "./DeviceAxios";

const reloadString = (brandId, page) =>
  `devices?${brandId !== "all" ? `&brandid=${brandId}` : ""}${
    page ? `&page=${page}` : ""
  }`;

const DeviceList = ({ brandId }) => {
  const [deviceInfo, reloadDeviceInfo, loading, error] = useListItem(
    reloadString(brandId)
  );
  const [currentDeviceId, setCurrentDeviceId] = useState(null);
  const [visibleModal, setVisibleModal] = useState(false);

  const [requestReload] = useMySignalR("ReloadData");

  const [currentPage, setCurrentPage] = useState(1);
  const [currentPageSize, setCurrentPageSize] = useState(2);
  const [total, setTotal] = useState(0);

  useEffect(() => {
    reloadDeviceInfo(reloadString(brandId, currentPage));
    notification.info({message: "Data has been updated", description: "Data has just been updated"})
  }, [requestReload]);

  useEffect(() => {
    reloadDeviceInfo(reloadString(brandId));
  }, [brandId]);

  useEffect(() => {
    reloadDeviceInfo(reloadString(brandId, currentPage));
  }, [currentPage]);

  useEffect(() => {
    if (!deviceInfo?.pageInfo) return;

    const {page, pageSize, count} = deviceInfo.pageInfo;

    if (page !== currentPage) setCurrentPage(page);
    if (pageSize !== currentPageSize) setCurrentPageSize(pageSize);
    if (count !== total) setTotal(count);

  }, [deviceInfo]);

  const columns = [
    {
      title: "Id",
      dataIndex: "id",
      key: "id",
      render: (text) => <a>{text}</a>,
    },
    {
      title: "Name",
      dataIndex: "name",
      key: "name",
    },
    {
      title: "Brand",
      dataIndex: "braneName",
      key: "brandName",
      render: (_, record) => record.brand.name,
    },
    {
      title: "Price",
      dataIndex: "price",
      key: "price",
    },
    {
      title: "Action",
      dataIndex: "action",
      render: (_, record) => (
        <Space>
          <Button onClick={() => onEdit(record.id)}>Edit</Button>
          <Popconfirm
            title="Are you sure to delete this record? Cannot be rollback!"
            placement="bottomRight"
            onConfirm={() => handleDelete(record.id)}
            okText="Delete"
            cancelText="No"
            okButtonProps={{ ghost: true, danger: true }}
          >
            <Tooltip title="Remove">
              <Button danger>Delete</Button>
            </Tooltip>
          </Popconfirm>
        </Space>
      ),
    },
  ];

  const resetModalState = () => {
    setCurrentDeviceId(null);
    setVisibleModal(false);
  }

  const onEdit = (id) => {
    setCurrentDeviceId(id);
    setVisibleModal(true);
  };

  const onCreate = () => {
    setCurrentDeviceId(null);
    setVisibleModal(true);
  };

  const onCancel = () => {
    resetModalState();
  };

  const handleDelete = async (id) => {
    try {
      await handleDeleteDevice(id);

      message.success("Success");
    } catch (err) {
      message.error("Failed");
      console.log(err.response);
    }
  };

  const handleAddOrEdit = (formData) => {
    if (currentDeviceId == null) handleAdd(formData);
    else handleEdit(formData);
  };

  const handleAdd = async (formData) => {
    try {
      await handleAddDevice(formData);

      message.success("Success");
      resetModalState();
    } catch(err) {
      message.error("Failed");
      console.log(err.response);
    }
  }

  const handleEdit = async (formData) => {
    try {
      await handleEditDevice(currentDeviceId, formData);

      message.success("Success");
      resetModalState();
    } catch(err) {
      message.error("Failed");
      console.log(err.response);
    }
  }

  if (error) return <Text type="danger">{error}</Text>;

  return (
    <div>
      <Button
        type="primary"
        icon={<PlusCircleOutlined />}
        style={{ marginBottom: 16 }}
        onClick={onCreate}
      >
        Add
      </Button>
      <Table
        loading={loading}
        columns={columns}
        dataSource={deviceInfo.devices}
        pagination={{
          current: currentPage,
          pageSize: currentPageSize,
          total,
          onChange: (num) => setCurrentPage(num),
        }}
      />
      <DeviceModal
        visible={visibleModal}
        initData={deviceInfo?.devices?.find((d) => d.id === currentDeviceId)}
        handleOk={handleAddOrEdit}
        onCancel={onCancel}
      />
    </div>
  );
};

export default DeviceList;
