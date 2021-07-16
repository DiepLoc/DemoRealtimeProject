import { Button, Divider, Form, Input, InputNumber, Modal, Select } from "antd";
import { useForm } from "antd/lib/form/Form";
import React, { useCallback, useEffect, useMemo } from "react";
import useListItem from "../../../Components/useListItem";
import {
  nameValidator,
  brandNameValidator,
  priceValidator,
  priceFormatter,
  selectedOptionFilter,
} from "../../../Helpers/fieldValidator";

const layout = {
  labelCol: {
    span: 8,
  },
  wrapperCol: {
    span: 16,
  },
};
const tailLayout = {
  wrapperCol: {
    offset: 8,
    span: 16,
  },
};

const initValues = {};

const DeviceModal = ({ visible, handleOk, onCancel, initData, isLoading }) => {
  const [form] = useForm();
  const [brands, _, loadingBrand] = useListItem("brands");

  useEffect(() => {
    if (initData) {
      form.setFieldsValue({ ...initData });
    } else form.resetFields();
  }, [visible]);

  const onFinish = useCallback((formData) => {
    handleOk(formData);
  }, [handleOk]);

  const brandsSelectOptions = useMemo(
    () =>
      brands.map((brand) => (
        <Select.Option value={brand.id} key={brand.name}>
          {brand.name}
        </Select.Option>
      )),
    [brands]
  );

  return (
    <Modal
      title={initData ? "Edit" : "Create"}
      visible={visible}
      centered
      footer={false}
      onCancel={onCancel}
    >
      <Form
        name="device-modal"
        form={form}
        initialValues={initValues}
        onFinish={onFinish}
        {...layout}
      >
        <Form.Item label="Name" name="name" rules={nameValidator}>
          <Input />
        </Form.Item>
        <Form.Item label="Brand" name="brandId" rules={brandNameValidator}>
          <Select
            loading={loadingBrand}
            placeholder="Select device's brand"
            showSearch
            filterOption={selectedOptionFilter}
          >
            {brandsSelectOptions}
          </Select>
        </Form.Item>
        <Form.Item
          name="price"
          rules={priceValidator}
          label="Price"
          extra="Unit: dollar ($)"
        >
          <InputNumber formatter={priceFormatter} />
        </Form.Item>
        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit" loading={isLoading}>
            Submit
          </Button>
          <Divider type="vertical" />
          <Button onClick={onCancel}>Cancel</Button>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default DeviceModal;
