import React from 'react'

const errorHandler = (err) => {
  let errorMessage = "";
  const data = err.response.data;
  if (data.message) errorMessage = data.message;
  else if (data.errors) {
    Object.keys(data.errors).forEach((key, index) => {
      if (index !== 0) errorMessage += " & ";
      errorMessage += data.errors[key]
    })
  }
  return errorMessage;
}

export default errorHandler
