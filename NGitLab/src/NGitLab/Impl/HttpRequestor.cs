using Newtonsoft.Json;
using NGitLab.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class HttpRequestor
    {
        private object _data;
        private const string ApplicationJsonContentType = "application/json";

        /// <summary>
        /// GitLab Host url as a string.
        /// </summary>
        public string HostUrl { get; set; }

        /// <summary>
        /// <see cref="HttpClient"/> used to make requests.
        /// </summary>
        public HttpClient Client { get; set; }

        /// <summary>
        /// Fluid API method to add Data to the http request call.
        /// </summary>
        /// <param name="data">The data that will be serialized and sent to the http endpoint.</param>
        public HttpRequestor With(object data)
        {
            _data = data;
            return this;
        }

        /// <summary>
        /// Sends a PUT request to the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the response value.</typeparam>
        /// <param name="tailApiUrl">The specified api url</param>
        /// <returns>Returns the deserialized response or throws a <see cref="GitLabException"/>.</returns>
        public async Task<T> Put<T>(string tailApiUrl)
        {
            var result = default(T);
            StringContent content;
            if (_data != null)
            {
                content = new StringContent(JsonConvert.SerializeObject(_data));
                content.Headers.ContentType = new MediaTypeHeaderValue(ApplicationJsonContentType);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            content.Headers.ContentType = new MediaTypeHeaderValue(ApplicationJsonContentType);
            var responseMessage = await Client.PutAsync(GetAPIUrl(tailApiUrl), content);

            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                var errorMessage = JsonConvert.DeserializeObject<Error>(errorResponse);
                throw new GitLabException(errorMessage);
            }

            var reponse = await responseMessage.Content.ReadAsStringAsync();

            result = JsonConvert.DeserializeObject<T>(reponse);

            return result;
        }

        /// <summary>
        /// Sends a POST request to the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the response value.</typeparam>
        /// <param name="tailApiUrl">The specified api url</param>
        /// <returns>Returns the deserialized response or throws a <see cref="GitLabException"/>.</returns>
        public async Task<T> Post<T>(string tailApiUrl)
        {
            var result = default(T);

            StringContent content;
            if (_data != null)
            {
                content = new StringContent(JsonConvert.SerializeObject(_data, Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }));
                content.Headers.ContentType = new MediaTypeHeaderValue(ApplicationJsonContentType);
            }
            else
            {
                content = new StringContent(string.Empty);
            }

            var responseMessage = await Client.PostAsync(GetAPIUrl(tailApiUrl), content);

            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                var errorMessage = JsonConvert.DeserializeObject<Error>(errorResponse);
                throw new GitLabException(errorMessage);
            }

            var response = await responseMessage.Content.ReadAsStringAsync();

            result = JsonConvert.DeserializeObject<T>(response);

            return result;
        }

        /// <summary>
        /// Sends a DELETE request to the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the response value.</typeparam>
        /// <param name="tailApiUrl">The specified api url</param>
        public async Task Delete(string tailApiUrl)
        {
            var responseMessage = await Client.DeleteAsync(GetAPIUrl(tailApiUrl));

            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                var errorMessage = JsonConvert.DeserializeObject<Error>(errorResponse);
                throw new GitLabException(errorMessage);
            }
        }

        /// <summary>
        /// Sends a GET request to the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the response value.</typeparam>
        /// <param name="tailApiUrl">The specified api url</param>
        /// <returns>Returns the deserialized response or throws a <see cref="GitLabException"/>.</returns>
        public async Task<T> Get<T>(string tailApiUrl)
        {
            var result = default(T);

            var responseMessage = await Client.GetAsync(GetAPIUrl(tailApiUrl));

            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                var errorMessage = JsonConvert.DeserializeObject<Error>(errorResponse);
                throw new GitLabException(errorMessage);
            }

            var response = await responseMessage.Content.ReadAsStringAsync();

            if (typeof(T) == typeof(string))
            {
                result = (T)Convert.ChangeType(response, typeof(T));
            }
            else
            {
                result = JsonConvert.DeserializeObject<T>(response);
            }

            return result;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string tailUrl)
        {
            var buffer = new List<T>();
            var nextUrlToLoad = GetAPIUrl(tailUrl);

            do
            {
                using (var responseMessage = await Client.GetAsync(nextUrlToLoad))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                        var errorMessage = JsonConvert.DeserializeObject<Error>(errorResponse);
                        throw new GitLabException(errorMessage);
                    }

                    IEnumerable<string> links;
                    var keyFound = responseMessage.Headers.TryGetValues("Link", out links);

                    if (keyFound)
                    {

                        var link = links.FirstOrDefault();
                        string[] nextLink = null;
                        if (string.IsNullOrEmpty(link) == false)
                            nextLink = link.Split(',')
                                .Select(l => l.Split(';'))
                                .FirstOrDefault(pair => pair[1].Contains("next"));

                        if (nextLink != null)
                        {
                            nextUrlToLoad = nextLink[0].Trim('<', '>', ' ');
                        }
                        else
                        {
                            nextUrlToLoad = null;
                        }
                    }
                    else
                    {
                        nextUrlToLoad = null;
                    }

                    var result = await responseMessage.Content.ReadAsStringAsync();
                    buffer.AddRange(JsonConvert.DeserializeObject<T[]>(result));
                }

            } while (nextUrlToLoad != null);

            return buffer;
        }

        private string GetAPIUrl(string tailAPIUrl)
        {
            if (!tailAPIUrl.StartsWith("/", StringComparison.Ordinal))
            {
                tailAPIUrl = "/" + tailAPIUrl;
            }

            if (!tailAPIUrl.StartsWith("/api/v3", StringComparison.Ordinal))
            {
                tailAPIUrl = "/api/v3" + tailAPIUrl;
            }

            return tailAPIUrl;
        }
    }
}
