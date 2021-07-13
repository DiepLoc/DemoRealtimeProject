import { HubConnectionBuilder } from '@microsoft/signalr';
import React, { useEffect, useState } from 'react'

const useMySignalR = (listenEvent) => {
  const [connection, setConnection] = useState(null);
  const [receivedData, setReceivedData] = useState(null);

  useEffect(() => {
    const connect = new HubConnectionBuilder()
      .withUrl(process.env.REACT_APP_BASE_URL + "/hubs")
      .withAutomaticReconnect()
      .build();
    setConnection(connect);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(() => {
          connection.on(listenEvent, (data) => {
            console.log(data)
            setReceivedData(data);
          });
        })
        .catch((error) => console.log(error));
    }
  }, [connection]);

  const sendEvent = async (eventName, sendData) => {
    if (connection) await connection.send(eventName, sendData);
  };

  return [receivedData, sendEvent];
}

export default useMySignalR
