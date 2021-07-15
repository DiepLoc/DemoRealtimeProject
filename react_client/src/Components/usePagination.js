import React, { useEffect, useState } from "react";

const usePagination = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [currentPageSize, setCurrentPageSize] = useState(2);
  const [total, setTotal] = useState(0);

  const setSync = (page, size, tot) => {
    setCurrentPage(page);
    setCurrentPageSize(size);
    setTotal(tot);
  }

  return [
    currentPage,
    currentPageSize,
    total,
    {
      currentPage: setCurrentPage,
      currentPageSize: setCurrentPageSize,
      total: setTotal,
      setSync: setSync
    },
  ];
};

export default usePagination;
