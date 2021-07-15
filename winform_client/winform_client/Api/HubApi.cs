using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace winform_client.Api
{
    class HubApi
    {
        private static HubApi instance = null;
        public static HubApi GetIntance()
        {
            if (instance == null) instance = new HubApi();
            return instance;
        }

        private HubConnection connection;
        private Action<string> callBack;

        public void SetCallBack(Action<string> callbackFunc)
        {
            callBack = callbackFunc;
            connection.On<string>("ReloadData", (message) =>
            {
                callBack(message);
            });
        }

        private HubApi()
        {
            startConnectAsync();
        }

        private async void startConnectAsync()
        {
            try
            {
                connection = new HubConnectionBuilder()
                .WithUrl(@"https://localhost:44318/api/Hubs")
                .WithAutomaticReconnect()
                .Build();
                await connection.StartAsync();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
