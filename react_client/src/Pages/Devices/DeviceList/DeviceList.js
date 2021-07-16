import React, { useCallback, useEffect, useMemo, useState } from "react";
import { Alert, Button, message, notification, Space, Table } from "antd";
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

const onCloseHubs = () => {
  notification.error({
    message: "Error with hubs",
    description:
      "Can't connect to hubs, real-time sync is disabled, please reload the page and try again",
  });
};

const onConnectedHubs = () => {
  notification.success({
    message: "Connect to hubs successfully",
    description: "Real-time sync is enabled",
  });
};

const onConnectingHubs = () => {
  notification.warn({
    message: "Hubs is disconnected, trying to reconnect to hubs",
  });
};

const DeviceList = ({ brandId }) => {
  const [currentPage, currentPageSize, total, setPageInfo] = usePagination();
  const [isLoading, setIsLoading] = useState(false);
  const [deviceInfo, reloadDeviceInfo, loading, error] = useListItem(
    reloadString(brandId, null, currentPageSize)
  );
  const [currentDeviceId, setCurrentDeviceId] = useState(null);
  const [visibleModal, setVisibleModal] = useState(false);
  const [reloadDataMessage, _, isConnectedHubs] = useMySignalR(
    "ReloadData",
    onCloseHubs,
    onConnectedHubs,
    onConnectingHubs
  );

  useEffect(() => {
    if (!reloadDataMessage) return;

    reloadDeviceInfo(reloadString(brandId, currentPage, currentPageSize));
    notification.info({
      message: "Data has been updated",
      description: reloadDataMessage,
    });
  }, [reloadDataMessage]);

  useEffect(() => {
    reloadDeviceInfo(reloadString(brandId, null, currentPageSize));
  }, [brandId]);

  useEffect(() => {
    reloadDeviceInfo(reloadString(brandId, currentPage, currentPageSize));
  }, [currentPage, currentPageSize]);

  useEffect(() => {
    if (!deviceInfo?.pageInfo) return;

    const { page, pageSize, count } = deviceInfo.pageInfo;
    setPageInfo.setSync(page, pageSize, count);
  }, [deviceInfo]);

  const resetModalState = useCallback(() => {
    setIsLoading(false);
    setCurrentDeviceId(null);
    setVisibleModal(false);
  }, [setCurrentDeviceId, setVisibleModal, setIsLoading]);

  const onEdit = useCallback(
    (id) => {
      setCurrentDeviceId(id);
      setVisibleModal(true);
    },
    [setCurrentDeviceId, setVisibleModal]
  );

  const onCreate = useCallback(() => {
    setCurrentDeviceId(null);
    setVisibleModal(true);
  }, [setCurrentDeviceId, setVisibleModal]);

  const handleChangeDataContainer = useCallback(
    async (callback) => {
      try {
        setIsLoading(true);
        await callback();
        message.success("Success");
        reloadDeviceInfo(reloadString(brandId, currentPage, currentPageSize));
        resetModalState();
      } catch (err) {
        message.error(errorHandler(err) ?? "Something wrong");
        setIsLoading(false);
        console.log(err.response);
      }
    },
    [resetModalState, reloadDeviceInfo, setIsLoading]
  );

  const handleDelete = useCallback(
    async (id) => {
      handleChangeDataContainer(async () => await handleDeleteDevice(id));
    },
    [handleChangeDataContainer, handleDeleteDevice]
  );

  const handleAdd = useCallback(
    async (formData) => {
      handleChangeDataContainer(async () => await handleAddDevice(formData));
    },
    [handleAddDevice, handleChangeDataContainer]
  );

  const handleEdit = useCallback(
    async (formData) => {
      handleChangeDataContainer(async () =>
        handleEditDevice(currentDeviceId, formData)
      );
    },
    [handleChangeDataContainer, handleEditDevice, currentDeviceId]
  );

  const handleAddOrEdit = useCallback(
    (formData) => {
      if (currentDeviceId == null) handleAdd(formData);
      else handleEdit(formData);
    },
    [currentDeviceId, handleAdd, handleAdd]
  );

  const columns = useMemo(
    () => tableColumns({ handleDelete, onEdit }),
    [handleDelete, onEdit]
  );

  const paginationConfig = useMemo(
    () => ({
      current: currentPage,
      pageSize: currentPageSize,
      total: total,
      onChange: (num) => setPageInfo.currentPage(num),
    }),
    [currentPage, currentPage, setPageInfo]
  );

  if (error) return <Text type="danger">{error}</Text>;

  return (
    <div>
       {!isConnectedHubs && (
          <Alert
            message="Hubs is disconnecting, trying to reconnect to hubs"
            type="error"
          />
        )}
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
        pagination={paginationConfig}
      />
      <DeviceModal
        visible={visibleModal}
        initData={deviceInfo?.devices?.find((d) => d.id === currentDeviceId)}
        handleOk={handleAddOrEdit}
        onCancel={resetModalState}
        isLoading={isLoading}
      />
    </div>
  );
};

export default DeviceList;
