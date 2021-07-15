import { Button, Popconfirm, Space, Tooltip } from "antd";

const tableColumns = ({handleDelete, onEdit}) => [
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

export default tableColumns
