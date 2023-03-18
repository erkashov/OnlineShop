using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace OnlineShop.Data
{
    public class BaseHttpService<T>
    {
        private static HttpClient _httpClient = new HttpClient();
        private static readonly string _basePath = "http://localhost:7082/api";

        public static async Task<List<T>> SendListAsync<T>(string action, HttpMethod method, object model = null)
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

        public static async Task<T> SendAsync<T>(string action, HttpMethod method, object model = null)
        where T : new()
        {
            try
            {
                var uri = $"{_basePath}/{action}";
                var message = CreateMessage(uri, method, model);
                var response = await _httpClient.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();

                T res;
                try
                {
                    res = JsonConvert.DeserializeObject<T>(content);
                    if (res == null)
                        return new T();

                    return res;
                }
                catch (Exception)
                {
                    return new T();
                }
            }
            catch (Exception)
            {
                return new T();
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

    public class HttpResponce<T>
    {
        public string? Error { get; set; }
        public bool IsSuccess { get; set; } = true;
        public T? Responce { get; set; }
        public HttpResponce(T res)
        {
            Responce = res;
        }
        public HttpResponce() { }
        public HttpResponce(string res)
        {
            Error = res;
            IsSuccess = false;
        }

        public bool HasErrors
        {
            get
            {
                return !String.IsNullOrEmpty(Error);
            }
        }
    }

    public class HttpService<T>
    {
        private static HttpClient _httpClient = new HttpClient();
        private static readonly string _basePath = "http://localhost:7082/api";
        public static void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public static async Task<HttpResponce<List<T>>> SendListAsync<T>(string action, HttpMethod method, object model = null, string token = "")
        {
            try
            {
                if(token != "") SetToken(token); 
                var uri = $"{_basePath}/{action}";
                var message = CreateMessage(uri, method, model);
                var response = await _httpClient.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (content == "") return new HttpResponce<List<T>>();
                    List<T> result = new List<T>();
                    T res;
                    try
                    {
                        result = JsonConvert.DeserializeObject<List<T>>(content);
                        if (result == null)
                            return new HttpResponce<List<T>>("Ошибка при преобразовании в список");

                        return new HttpResponce<List<T>>(result);
                    }
                    catch (Exception)
                    {
                        res = JsonConvert.DeserializeObject<T>(content);
                        if (res == null)
                            return new HttpResponce<List<T>>("Ошибка при преобразовании в объект");

                        result.Add(res);
                        return new HttpResponce<List<T>>(result);
                    }
                }
                else
                {
                    return new HttpResponce<List<T>>(content);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponce<List<T>>(ex.ToString());
            }
        }

        public static async Task<T> SendAsync<T>(string action, HttpMethod method, object model = null)
        where T : new()
        {
            try
            {
                var uri = $"{_basePath}/{action}";
                var message = CreateMessage(uri, method, model);
                var response = await _httpClient.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();

                T res;
                try
                {
                    res = JsonConvert.DeserializeObject<T>(content);
                    if (res == null)
                        return new T();

                    return res;
                }
                catch (Exception)
                {
                    return new T();
                }
            }
            catch (Exception)
            {
                return new T();
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
