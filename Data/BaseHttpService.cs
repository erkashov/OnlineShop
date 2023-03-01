using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace OnlineShop.Data
{
    public class BaseHttpService<T> where T : class
    {
        private static HttpClient _httpClient = new HttpClient();
        private static readonly string _basePath = "http://localhost/api";

        public static async Task<List<T>> SendAsync<T>(string action, HttpMethod method, object model = null)
        where T : class, new()
        {
            try
            {
                var uri = $"{_basePath}/{action}";
                var message = CreateMessage(uri, method, model);
                var response = await _httpClient.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();

                List<T> result = new List<T>();
                T res;
                try
                {
                    result = JsonConvert.DeserializeObject<List<T>>(content);
                    if (result == null)
                        return new List<T>();

                    return result;
                }
                catch (Exception)
                {
                    res = JsonConvert.DeserializeObject<T>(content);
                    if (res == null)
                        return new List<T>();

                    result.Add(res);
                    return result;
                }
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        private static HttpRequestMessage CreateMessage(string uri, HttpMethod method, object model)
        {
            var message = new HttpRequestMessage(method, uri);
            if (method != HttpMethod.Post && method != HttpMethod.Put)
                return message;

            message.Content = CreateContent(model);
            return message;
        }

        private static HttpContent CreateContent(object model)
        {
            if (model is HttpContent cont)
                return cont;

            var content = new ByteArrayContent(model == null
                ? Array.Empty<byte>()
                : Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentEncoding.Add("UTF-8");
            return content;
        }

        private static string _baseErr(Exception exc)
        {
            return $"Message: {exc.Message}, Inner exception: {exc.InnerException?.Message}";
        }
    }
}
