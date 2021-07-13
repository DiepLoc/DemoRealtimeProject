import { Button, Divider, Form, Input, InputNumber, Modal, Select } from "antd";
import { useForm } from "antd/lib/form/Form";
import React, { useEffect } from "react";
import useListItem from "../../../Components/useListItem";

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

const DeviceModal = ({ visible, handleOk, onCancel, initData }) => {
  const [form] = useForm();
  const [brands, _, loadingBrand] = useListItem("brands");

  useEffect(() => {
    if (initData) {
      form.setFieldsValue({ ...initData });
    } else form.resetFields();
  }, [visible]);

  const onFinish = (formData) => {
    console.log(formData);
    handleOk(formData);
  };

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
        <Form.Item
          label="Name"
          name="name"
          rules={[{ required: true, max: 50 }]}
        >
          <Input />
        </Form.Item>
        <Form.Item label="Brand" name="brandId" rules={[{ required: true }]}>
          <Select
            loading={loadingBrand}
            placeholder="Select device's brand"
            showSearch
            filterOption={(input, option) =>
              option.children.toLowerCase().includes(input.toLowerCase())
            }
          >
            {brands.map((brand) => (
              <Select.Option value={brand.id} key={brand.name}>
                {brand.name}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item
          name="price"
          rules={[{ type: "integer", min: 0, required: true }]}
          label="Price"
          extra="Unit: dollar ($)"
        >
          <InputNumber
            formatter={(value) =>
              `$ ${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ",")
            }
          />
        </Form.Item>
        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit">
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
