import { HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState } from "react";

const useMySignalR = (
  listenEvent,
  closeCallback = null,
  reconnectedCallback = null,
  connectingCallback = null
) => {
  const [connection, setConnection] = useState(null);
  const [receivedData, setReceivedData] = useState(null);
  const [isConnected, setIsConnected] = useState(true);

  useEffect(() => {
    const connect = new HubConnectionBuilder()
      .withUrl(process.env.REACT_APP_BASE_URL + "/hubs")
      .withAutomaticReconnect({
        nextRetryDelayInMilliseconds: (retryContext) => {
          if (retryContext.elapsedMilliseconds < 60000) {
            return 5000;
          } else {
            return null;
          }
        },
      })
      .build();
    connect.onreconnecting(() => {
      setIsConnected(false);
      if (closeCallback) connectingCallback()
    });
    connect.onclose(() => {
      setIsConnected(false);
      if (closeCallback) closeCallback();
    });
    connect.onreconnected(() => {
      setIsConnected(true);
      if (reconnectedCallback) reconnectedCallback();
    });

    setConnection(connect);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(() => {
          connection.on(listenEvent, (data) => {
            console.log(data);
            setReceivedData(data);
          });
        })
        .catch((error) => console.log(error));
    }
  }, [connection]);

  const sendEvent = async (eventName, sendData) => {
    if (connection) await connection.send(eventName, sendData);
  };

  return [receivedData, sendEvent, isConnected];
};

export default useMySignalR;
