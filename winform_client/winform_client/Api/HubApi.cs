using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        private Action firstConnecedSuccessfulyCallback = null;

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
            StartConnectAsync();
            SetReconnect();
        }

        private async void StartConnectAsync()
        {
            try
            {
                connection = new HubConnectionBuilder()
                .WithUrl(Environment.GetEnvironmentVariable("hub-url") ?? @"https://localhost:44318/api/Hubs")
                .WithAutomaticReconnect()
                .Build();
                await ConnectWithRetryAsync();
                if (firstConnecedSuccessfulyCallback != null) firstConnecedSuccessfulyCallback();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ConnectWithRetryAsync()
        {
            while (true)
            {
                try
                {
                    await connection.StartAsync();
                    return;
                }
                catch
                {
                    await Task.Delay(5000);
                }
            }
        }

        public void SetFirstConnectCallback(Action action)
        {
            firstConnecedSuccessfulyCallback = action;
        }
        
        public void SetErrorCallback(Action action)
        {
            connection.Reconnecting += error =>
            {
                action();
                return Task.CompletedTask;
            };
        }

        private void SetReconnect()
        {
            connection.Closed += async (error) =>
            {
                await Task.Delay(5000);
                await connection.StartAsync();
            };
        }

        public void SetReconnectedCallback(Action action)
        {
            connection.Reconnected += connectionId =>
            {
                action();
                return Task.CompletedTask;
            };
        }

        public void SetClosedConnection(Action action)
        {
            connection.Closed += error =>
            {
                action();
                return Task.CompletedTask;
            };
        }
    }
}
