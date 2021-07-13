import clientAxios from "../../../Services/Axios/clientAxios"

const handleAddDevice = async (formData) => {
  return await clientAxios.post('devices', formData);
}

const handleEditDevice = async (id, formData) => {
  return await clientAxios.put(`devices/${id}`, {id, ...formData});
}

const handleDeleteDevice = async (id) => {
  return await clientAxios.delete(`devices/${id}`);
}

export {handleAddDevice, handleEditDevice, handleDeleteDevice};

