import { useEffect, useState } from "react";
import clientAxios from "../Services/Axios/clientAxios";

const useTotalCount = () => {
  const [count, setCount] = useState(0);

  const loadCount = async () => {
    try {
      const { data } = await clientAxios.get("devices?pagesize=1");
      console.log(data)
      setCount(parseInt(data?.pageInfo.count) || 0);
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    loadCount();
  }, []);

  return [count, loadCount];
};

export default useTotalCount;