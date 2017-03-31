using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CM.Payments.Client
{
    /// <summary>
    ///     Base class for REST-ful Web API Clients.
    /// </summary>
    public abstract class RestBaseClient
    {
        private const string JsonMediaType = "application/json";
        private static readonly Encoding Encoding = Encoding.UTF8;
        private readonly OAuth _auth;
        private readonly Uri _baseUri = new Uri("https://api.cmpayments.com/");

        internal RestBaseClient(string consumerKey, string consumerSecret)
        {
            this._auth = new OAuth(consumerKey, consumerSecret);
        }

        internal async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var client = this.BuildClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));
                var request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + url);
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    "OAuth",
                    this._auth.GenerateHeader(request.Method.Method, request.RequestUri.AbsoluteUri));
                var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return default(T);
                }
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        internal async Task<T> PostAsync<T>(string url, object data, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var client = this.BuildClient())
            {
                var settings = new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        args.ErrorContext.Handled = true;
                        Console.Write(args.ErrorContext.Error);
                    }
                };
                var requestData = JsonConvert.SerializeObject(data, settings);
                var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + url)
                {
                    Content = new StringContent(requestData, Encoding, JsonMediaType)
                };
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    "OAuth",
                    this._auth.GenerateHeader(request.Method.Method, request.RequestUri.AbsoluteUri, requestData));
                var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException exc)
                {
                    throw new UnhandledRequestException("Unable to process your request.", exc);
                }
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return default(T);
                }

                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        private HttpClient BuildClient()
        {
            return new HttpClient {BaseAddress = this._baseUri};
        }
    }
}