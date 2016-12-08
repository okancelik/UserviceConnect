using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UServiceConnect.Objects;

namespace UServiceConnect
{
    public class UHttpServiceAsyncRequest
    {
        private string UserName, Password, TokenUrl, AccessToken = String.Empty;

        private bool IsTokenBased = false;
        private bool IsAuthorization = true;

        /// <summary>
        /// Not Authentication.
        /// </summary>
        public UHttpServiceAsyncRequest()
        {
            IsAuthorization = false;
        }

        /// <summary>
        /// Basic Authentication.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        public UHttpServiceAsyncRequest(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        /// <summary>
        /// Token Based Authentication.
        /// </summary>
        /// <param name="token"></param>
        public UHttpServiceAsyncRequest(string token)
        {
            AccessToken  = token.Trim();
            IsTokenBased = true;
        }

        /// Token oluşturur.
        /// </summary>
        /// <returns></returns>
        private  AuthenticationHeaderValue GetToken()
        {
            if (AccessToken != String.Empty)
                return new AuthenticationHeaderValue("bearer", AccessToken); // Arada bir boşluk bırakılıp gönderilecek...
            else
                return new AuthenticationHeaderValue(String.Empty, String.Empty);
        }


        /// <summary>
        /// Basic Kod üretir.
        /// </summary>
        /// <returns></returns>
        private AuthenticationHeaderValue GetBasic()
        {
            String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(UserName + ":" + Password));
            return new AuthenticationHeaderValue("Basic", encoded);
        }

        /// <summary>
        /// Parametre olarak gönderilen Url adresine Http Get isteğinde bulunur.
        /// Geriye Json formatında String Döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string requestUrl, string contentType = "application/json")
        {
            HttpClient Client  = new HttpClient();
            Client.BaseAddress = new Uri(requestUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            if (IsAuthorization)
            {
                if (!IsTokenBased)
                    Client.DefaultRequestHeaders.Authorization = GetBasic();
                else
                    Client.DefaultRequestHeaders.Authorization = GetToken();
            }

            HttpResponseMessage response = await Client.GetAsync(Client.BaseAddress);
            string jsonString = response.Content.ReadAsStringAsync().Result;

            return jsonString;
        }

        /// <summary>
        /// Parametre olarak gönderilen Url adresine parametre olarak gönderilen objeyi json verisine çevirip Post eder.
        /// Geriye Json formatında String Döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="responseObject"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string requestUrl, object responseObject, string contentType = "application/json")
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(requestUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            if (IsAuthorization)
            {
                if (!IsTokenBased)
                    Client.DefaultRequestHeaders.Authorization = GetBasic();
                else
                    Client.DefaultRequestHeaders.Authorization = GetToken();
            }

            string jsonResponseObject = JsonConvert.SerializeObject(responseObject);
            HttpResponseMessage response = await Client.PostAsync(Client.BaseAddress, new StringContent(jsonResponseObject, Encoding.UTF8, "application/json"));
            string jsonString = response.Content.ReadAsStringAsync().Result;

            return jsonString;
        }

        /// <summary>
        /// Parametre olarak gönderilen Url adresine parametre olarak gönderilen objeyi json verisine çevirip Post eder.
        /// Geriye Json formatında String Döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="responseObject"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string requestUrl, string responseObject, string contentType = "application/json")
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(requestUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            if (IsAuthorization)
            {
                if (!IsTokenBased)
                    Client.DefaultRequestHeaders.Authorization = GetBasic();
                else
                    Client.DefaultRequestHeaders.Authorization = GetToken();
            }

            HttpResponseMessage response = await Client.PostAsync(Client.BaseAddress, new StringContent(responseObject, Encoding.UTF8, "application/json"));
            string jsonString = response.Content.ReadAsStringAsync().Result;

            return jsonString;
        }



        /// <summary>
        /// Parametre olarak gönderilen Url adresine parametre olarak gönderilen objeyi json verisine çevirip Put eder.
        /// Güncellemede kullanılır.
        /// Geriye Json formatında String Döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="responseObject"></param>
        /// <returns></returns>
        public async Task<string> PutAsync(string requestUrl, object responseObject, string contentType = "application/json")
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(requestUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            if (IsAuthorization)
            {
                if (!IsTokenBased)
                    Client.DefaultRequestHeaders.Authorization = GetBasic();
                else
                    Client.DefaultRequestHeaders.Authorization = GetToken();
            }

            string jsonResponseObject = JsonConvert.SerializeObject(responseObject);
            HttpResponseMessage response = await Client.PutAsync(Client.BaseAddress, new StringContent(jsonResponseObject, Encoding.UTF8, "application/json"));
            string jsonString = response.Content.ReadAsStringAsync().Result;

            return jsonString;
        }


        /// <summary>
        /// Parametre olarak gönderilen Url adresine parametre olarak gönderilen objeyi json verisine çevirip Put eder.
        /// Güncellemede kullanılır.
        /// Geriye Json formatında String Döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="responseObject"></param>
        /// <returns></returns>
        public async Task<string> PutAsync(string requestUrl, string responseObject, string contentType = "application/json")
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(requestUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            if (IsAuthorization)
            {
                if (!IsTokenBased)
                    Client.DefaultRequestHeaders.Authorization = GetBasic();
                else
                    Client.DefaultRequestHeaders.Authorization = GetToken();
            }

            HttpResponseMessage response = await Client.PutAsync(Client.BaseAddress, new StringContent(responseObject, Encoding.UTF8, "application/json"));
            string jsonString = response.Content.ReadAsStringAsync().Result;

            return jsonString;
        }

        /// <summary>
        /// Parametre olarak gönderilen Url adresine Http Delete isteğinde bulunur.
        /// Geriye Json formatında String Döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public async Task<string> DeleteAsync(string requestUrl, string contentType = "application/json")
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(requestUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            if (IsAuthorization)
            {
                if (!IsTokenBased)
                    Client.DefaultRequestHeaders.Authorization = GetBasic();
                else
                    Client.DefaultRequestHeaders.Authorization = GetToken();
            }

            HttpResponseMessage response = await Client.DeleteAsync(Client.BaseAddress);
            string jsonString = response.Content.ReadAsStringAsync().Result;

            return jsonString;
        }

        /// <summary>
        /// Manuel basit istekte Bulunur.
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<string> RequestAsync(Request req)
        {
            string jsonResponseObject = String.Empty;

            if (req == null)
                req = new Request();

            HttpResponseMessage response = new HttpResponseMessage();

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(req.Uri);
            Client.DefaultRequestHeaders.Accept.Clear();

            if (req.Content_Type !=null)
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(req.Content_Type));

            if (req.Authorization != null)
                Client.DefaultRequestHeaders.Authorization = req.Authorization;

            if (req.Body != null)
                jsonResponseObject = req.Body.ToString();

            if (req.Headers != null)
            {
                foreach (var item in req.Headers)
                {
                    string[] Headers = item.ToString().Trim().Split(':');
                    Client.DefaultRequestHeaders.Add(Headers[0].Trim(), Headers[1].Trim());
                }
            }

            if (req.Method!= null)
            {
                if (req.Method.ToLower()      == "get")
                    response = await Client.GetAsync(Client.BaseAddress);
                else if(req.Method.ToLower()  == "post")
                    response = await Client.PostAsync(Client.BaseAddress, new StringContent(jsonResponseObject, Encoding.UTF8, "application/json"));
                else if(req.Method.ToLower()  == "put")
                    response = await Client.PutAsync(Client.BaseAddress, new StringContent(jsonResponseObject, Encoding.UTF8, "application/json"));
                else if (req.Method.ToLower() == "delete")
                    response = await Client.DeleteAsync(Client.BaseAddress);
            }
            else
            {
                 response = await Client.GetAsync(Client.BaseAddress);
            }

            string jsonString = response.Content.ReadAsStringAsync().Result;
            return jsonString;
        }

        /// <summary>
        /// Token objesi geriye döner.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Token> RequestTokenAsync(Request req)
        {
            string jsonResponseObject = String.Empty;

            if (req == null)
                req = new Request();

            HttpResponseMessage response = new HttpResponseMessage();

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(req.Uri);
            Client.DefaultRequestHeaders.Accept.Clear();

            if (req.Content_Type != null)
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(req.Content_Type));

            if (req.Authorization != null)
                Client.DefaultRequestHeaders.Authorization = req.Authorization;

            if (req.Body != null)
                jsonResponseObject = req.Body.ToString();

            if (req.Headers != null)
            {
                foreach (var item in req.Headers)
                {
                    string[] Headers = item.ToString().Trim().Split(':');
                    Client.DefaultRequestHeaders.Add(Headers[0].Trim(), Headers[1].Trim());
                }
            }

            if (req.Method != null)
            {
                if (req.Method.ToLower()      == "get")
                    response = await Client.GetAsync(Client.BaseAddress);
                else if (req.Method.ToLower() == "post")
                    response = await Client.PostAsync(Client.BaseAddress, new StringContent(jsonResponseObject, Encoding.UTF8, "application/json"));
                else if (req.Method.ToLower() == "put")
                    response = await Client.PutAsync(Client.BaseAddress, new StringContent(jsonResponseObject, Encoding.UTF8, "application/json"));
                else if (req.Method.ToLower() == "delete")
                    response = await Client.DeleteAsync(Client.BaseAddress);
            }
            else
            {
                response = await Client.GetAsync(Client.BaseAddress);
            }

            string jsonString = response.Content.ReadAsStringAsync().Result;
            Token token = JsonConvert.DeserializeObject<Token>(jsonString);
            return token;
        }
    }
}
