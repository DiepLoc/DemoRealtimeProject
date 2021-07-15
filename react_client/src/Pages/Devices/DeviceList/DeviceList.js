import React, { useEffect, useState } from "react";
import { Button, message, notification, Table } from "antd";
import { PlusCircleOutlined } from "@ant-design/icons";
import Text from "antd/lib/typography/Text";
import { useListItem, useMySignalR, usePagination } from "../../../Components";
import DeviceModal from "../DeviceModal/DeviceModal";
import tableColumns from "./tableColumns";
import {
  handleAddDevice,
  handleDeleteDevice,
  handleEditDevice,
} from "./DeviceAxios";
import errorHandler from "../../../Helpers/errorHandler";

const reloadString = (brandId, page, pageSize) => {
  let urlString = "devices?";
  if (brandId !== "all") urlString += `&brandid=${brandId}`;
  if (page) urlString += `&page=${page}`;
  if (pageSize) urlString += `&pageSize=${pageSize}`;
  return urlString;
};

const DeviceList = ({ brandId }) => {
  const [currentPage, currentPageSize, total, setPageInfo] = usePagination();
  const [deviceInfo, reloadDeviceInfo, loading, error] = useListItem(
    reloadString(brandId, null, currentPageSize)
  );
  const [currentDeviceId, setCurrentDeviceId] = useState(null);
  const [visibleModal, setVisibleModal] = useState(false);
  const [reloadDataMessage] = useMySignalR("ReloadData");

  useEffect(() => {
    if (!reloadDataMessage) return;

    reloadDeviceInfo(
      reloadString(brandId, currentPage, currentPageSize)
    );
    notification.info({
      message: "Data has been updated",
      description: reloadDataMessage,
    });
  }, [reloadDataMessage]);

  useEffect(() => {
    reloadDeviceInfo(reloadString(brandId, null, currentPageSize));
  }, [brandId]);

  useEffect(() => {
    reloadDeviceInfo(
      reloadString(brandId, currentPage, currentPageSize)
    );
  }, [currentPage, currentPageSize]);

  useEffect(() => {
    if (!deviceInfo?.pageInfo) return;
    
    const { page, pageSize, count } = deviceInfo.pageInfo;
    setPageInfo.setSync(page, pageSize, count)
  }, [deviceInfo]);

  const resetModalState = () => {
    setCurrentDeviceId(null);
    setVisibleModal(false);
  };

  const onEdit = (id) => {
    setCurrentDeviceId(id);
    setVisibleModal(true);
  };

  const onCreate = () => {
    setCurrentDeviceId(null);
    setVisibleModal(true);
  };

  const handleDelete = async (id) => {
    handleChangeDataContainer(async () => await handleDeleteDevice(id));
  };

  const handleAddOrEdit = (formData) => {
    if (currentDeviceId == null) handleAdd(formData);
    else handleEdit(formData);
  };

  const handleAdd = async (formData) => {
    handleChangeDataContainer(async () => await handleAddDevice(formData));
  };

  const handleEdit = async (formData) => {
    handleChangeDataContainer(async () =>
      handleEditDevice(currentDeviceId, formData)
    );
  };

  const handleChangeDataContainer = async (callback) => {
    try {
      await callback();
      message.success("Success");
      resetModalState();
    } catch (err) {
      message.error(errorHandler(err) ?? "Something wrong");
      console.log(err.response);
    }
  };

  const columns = tableColumns({ handleDelete, onEdit });

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
          total: total,
          onChange: (num) => setPageInfo.currentPage(num),
        }}
      />
      <DeviceModal
        visible={visibleModal}
        initData={deviceInfo?.devices?.find((d) => d.id === currentDeviceId)}
        handleOk={handleAddOrEdit}
        onCancel={resetModalState}
      />
    </div>
  );
};

export default DeviceList;
