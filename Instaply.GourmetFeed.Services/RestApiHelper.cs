﻿using Instaply.GourmetFeed.Models.Core;
using Instaply.GourmetFeed.Services.Core;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Instaply.GourmetFeed.Services
{
    internal static class RestApiHelper
    {
        /// <summary>
        /// Contact the service and retrieving a casted object T
        /// </summary>
        /// <typeparam name="T">output type (converted from json sended by backend)</typeparam>
        /// <typeparam name="T2">input parameter type</typeparam>
        /// <param name="source">input parameter. Will be serialized to json prior to send to backend</param>
        /// <param name="endpoint">endpoint address to contact</param>
        /// <param name="method">HttpMethod for the call</param>
        /// <returns>Object of type T</returns>
        public static async Task<T> ExecuteAsync<T, T2>(T2 source, string endpoint, HttpMethod method)
            where T : new()
            where T2 : class
        {
            var message = new HttpRequestMessage(method, ApiEndpoints.Version + endpoint);

            if (source != null)
            {
                string json = JsonConvert.SerializeObject(source);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                message.Content = stringContent;
            }
            return await ExecuteAsync<T>(message);
        }

        /// <summary>
        /// Contact the service and retrieving a casted object T
        /// </summary>
        /// <typeparam name="T">output type (converted from json sended by backend)</typeparam>
        /// <param name="endpoint">endpoint address to contact</param>
        /// <param name="method">HttpMethod for the call</param>
        /// <returns>Object of type T</returns>
        public static async Task<T> ExecuteAsync<T>(string endpoint, HttpMethod method)
            where T : new()
        {
            var message = new HttpRequestMessage(method, ApiEndpoints.Version + endpoint);
            return await ExecuteAsync<T>(message);
        }

        /// <summary>
        /// Contact the service and retrieving a casted object T
        /// </summary>
        /// <typeparam name="T">output type (converted from json sended by backend)</typeparam>
        /// <param name="message">http message to send</param>
        /// <returns>Object of type T</returns>
        private static async Task<T> ExecuteAsync<T>(HttpRequestMessage message)
            where T : new()
        {
            dynamic taskResult = new T();
            TaskCompletionSource<T> result = new TaskCompletionSource<T>();

            try
            {
                using (var handler = new HttpClientHandler { UseCookies = false })
                {
                    using (var client = new HttpClient(handler) { BaseAddress = new Uri(ApiEndpoints.BaseUrl) })
                    {
                        if (ApplicationContext.User != null && !string.IsNullOrEmpty(ApplicationContext.User.AccessToken))
                            message.Headers.Add("apiToken", "" + ApplicationContext.User.AccessToken);

                        HttpResponseMessage httpResponseMessage = await client.SendAsync(message);
                        string stringResult = await httpResponseMessage.Content.ReadAsStringAsync();

                        taskResult = JsonConvert.DeserializeObject<T>(stringResult);

                        result.TrySetResult(taskResult);
                    }
                }

            }
            catch (WebException webException)
            {
                var errResponse = webException.Response as HttpWebResponse;
                if (errResponse != null)
                {
                    result.TrySetResult(taskResult);
                    result.TrySetException(webException);
                }
            }
            catch (Exception ex)
            {
                result.TrySetException(ex);
            }

            return await result.Task;
        }
    }
}
