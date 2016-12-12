# <h1>UserviceConnect</h1>

UWP uygularda servis isteklerini kolaylaştıran dll kütüphanesi.

**Örnekleme**

Uygun Authenticationa göre aşağıdaki gibi örneklenir.


* Not Authentication.

`UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest(); `

* Basic Authentication.

`UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest("userName","password");` 
`
* Token Based Authentication.

`UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest("accessToken");`

***

## Metotlar

### 1. GET

**Kullanım :**


`await asyncRequest.GetAsync(string requestUrl, string contentType = "application/json")`

* Gönderilen Url adresine GET metoduyla istekte bulunur.
* Geriye json formatında String Döner.
* Content Type Default olarak "application/json" dur. 

**Örn :**

            // Not Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest();
            object response;
            response = await asyncRequest.GetAsync("http://192.168.1.79/ExampleApi/api/Products/Gets");

            *****************************************************************************************

            // Basic Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest("user1","1234");
            object response;
            response = await asyncRequest.GetAsync("http://192.168.1.79/ExampleApi/api/Products/Gets");

            *****************************************************************************************

            // Token Based Authentication. 

            string accessToken = "naxwfgabfubvWIOEFYB2C6ZCNLUITlFGKVNNFHFGFFgfdgjsgsfsgGdgdfGDFhdfjddgh...";

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest(accessToken);
            object response;
            response = await asyncRequest.GetAsync("http://192.168.1.79/ExampleApi/api/Products/Gets");

### 2. POST

**Kullanım :**


`await asyncRequest.PostAsync(string requestUrl, string responseStringJSON, string contentType = "application/json")`

* Gönderilen Url adresine gönderilen string  ile  POST  metoduyla istekte bulunur.
* Geriye json formatında String Döner.
* Content Type Default olarak "application/json" dur.

**Örn :**

            // Not Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest();
            string json = "{'Key':Value,'Key':Value}";
            object response;
            response = await asyncRequest.PostAsync("http://192.168.1.79/ExampleApi/api/Products/Create", json);

            *****************************************************************************************

            // Basic Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest("user1","1234");
            string json = "{'Key':Value,'Key':Value}";
            object response;
            response = await asyncRequest.PostAsync("http://192.168.1.79/ExampleApi/api/Products/Create", json);

            *****************************************************************************************

            // Token Based Authentication. 

            string accessToken = "naxwfgabfubvWIOEFYB2C6ZCNLUITlFGKVNNFHFGFFgfdgjsgsfsgGdgdfGDFhdfjddgh...";

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest(accessToken);
            string json = "{'Key':Value,'Key':Value}";
            object response;
            response = await asyncRequest.PostAsync("http://192.168.1.79/ExampleApi/api/Products/Create", json);

### 3. PUT

**Kullanım :**


`await asyncRequest.PutAsync(string requestUrl, string responseStringJSON, string contentType = "application/json")`

* Gönderilen Url adresine gönderilen string  ile  PUT metoduyla istekte bulunur.
* Geriye json formatında String Döner.
* Content Type Default olarak "application/json" dur.

**Örn :**

            // Not Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest();
            string json = "{'Key':Value,'Key':Value}";
            object response;
            response = await asyncRequest.PutAsync("http://192.168.1.79/ExampleApi/api/Products/Update", json);

            *****************************************************************************************

            // Basic Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest("user1","1234");
            string json = "{'Key':Value,'Key':Value}";
            object response;
            response = await asyncRequest.PutAsync("http://192.168.1.79/ExampleApi/api/Products/Update", json);

            *****************************************************************************************

            // Token Based Authentication. 

            string accessToken = "naxwfgabfubvWIOEFYB2C6ZCNLUITlFGKVNNFHFGFFgfdgjsgsfsgGdgdfGDFhdfjddgh...";

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest(accessToken);
            string json = "{'Key':Value,'Key':Value}";
            object response;
            response = await asyncRequest.PutAsync("http://192.168.1.79/ExampleApi/api/Products/Update", json);

### 4. DELETE

**Kullanım :**


`await asyncRequest.DeleteAsync(string requestUrl, string contentType = "application/json")`

* Gönderilen Url adresine DELETE metoduyla istekte bulunur.
* Geriye json formatında String Döner.
* Content Type Default olarak "application/json" dur. 

**Örn :**

            // Not Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest();
            object response;
            response = request.DeleteAsync("http://192.168.1.79/ExampleApi/api/Products/Delete/5");

            *****************************************************************************************

            // Basic Authentication. 

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest("user1","1234");
            object response;
            response = request.DeleteAsync("http://192.168.1.79/ExampleApi/api/Products/Delete/5");

            *****************************************************************************************

            // Token Based Authentication. 

            string accessToken = "naxwfgabfubvWIOEFYB2C6ZCNLUITlFGKVNNFHFGFFgfdgjsgsfsgGdgdfGDFhdfjddgh...";

            UHttpServiceAsyncRequest asyncRequest = new UHttpServiceAsyncRequest(accessToken);
            object response;
            response = request.DeleteAsync("http://192.168.1.79/ExampleApi/api/Products/Delete/5");


