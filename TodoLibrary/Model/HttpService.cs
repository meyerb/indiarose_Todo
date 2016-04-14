using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Org.Json;
using TodoLibrary.Services;

namespace TodoLibrary.Model
{
    public class HttpService : IHttpService
    {
        private const string Url = "http://storm-project.fr/ios/api";
        private string _responseValue;
        private string _responseListe;
        private Json _responseJson;
        private const string PostLogin = "/login";
        private const string PostRegister = "/register";
        private const string PostAdd = "/add";
        private const string PostEdit = "/edit";
        private const string PostDelete = "/delete";
        private const string GetList = "/list";
        private readonly HttpClient _client = new HttpClient();

        public HttpService()
        {
            
        }
        public string ResponseListe
        {
            get { return _responseListe; }
            set { _responseListe = value; }
        }
        public Json ResponseJson
        {
            get { return _responseJson; }
            set { _responseJson = value; }
        }
        public string ResponseValue
        {
            get { return _responseValue; }
            set { _responseValue = value; }
        }

        public bool Connection(string login, string pwd)
        {
            IEnumerable<KeyValuePair<string,string>> data= new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("login",login),
                new KeyValuePair<string, string>("password",pwd)
            };
            HttpContent content= new FormUrlEncodedContent(data);
            try
            {
                var ret = _client.PostAsync(Url + PostLogin, content).Result;

                if (ret != null)
                {
                    ResponseValue = string.Empty;

                    Task task = ret.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            ResponseValue = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
                ResponseJson = JsonConvert.DeserializeObject<Json>(ResponseValue);
                GetTodos();
            }
            catch (AggregateException a)
            {
                return false;}
            return ResponseJson.Ok;
        }

        public bool Register(string login, string pwd)
        {
            IEnumerable<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("login",login),
                new KeyValuePair<string, string>("password",pwd)
            };
            HttpContent content = new FormUrlEncodedContent(data);
            try
            {
                var ret = _client.PostAsync(Url + PostRegister, content).Result;
                if (ret != null)
                {
                    ResponseValue = string.Empty;

                    Task task = ret.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            ResponseValue = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
                ResponseJson = JsonConvert.DeserializeObject<Json>(ResponseValue);
                Connection(login, pwd);
                GetTodos();
            }
            catch (AggregateException a)
            {
                return false; }
            return ResponseJson.Ok;
        }

        public string GetTodos()
        {
            try
            {
                var ret = _client.GetAsync(Url + GetList).Result;
                if (ret != null)
                {
                    ResponseListe = string.Empty;

                    Task task = ret.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            ResponseListe = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
                ResponseJson = JsonConvert.DeserializeObject<Json>(ResponseListe);
            }
            catch (AggregateException a)
            {
                return ""; }
            return ResponseJson.Resource.ToString();
        }

        public bool AddTodo(string title,string description)
        {
            IEnumerable<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("title",title),
                new KeyValuePair<string, string>("description",description)
            };
            HttpContent content = new FormUrlEncodedContent(data);
            try
            {
                var ret = _client.PostAsync(Url + PostAdd, content).Result;

                if (ret != null)
                {
                    ResponseValue = string.Empty;

                    Task task = ret.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            ResponseValue = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
                ResponseJson = JsonConvert.DeserializeObject<Json>(ResponseValue);
            }
            catch (AggregateException a)
            {
                return false; }
            return ResponseJson.Ok;
        }
        public bool EditTodo(string id,string title, string description)
        {
            IEnumerable<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id",id),
                new KeyValuePair<string, string>("title",title),
                new KeyValuePair<string, string>("description",description)
            };
            HttpContent content = new FormUrlEncodedContent(data);
            try
            {
                var ret = _client.PostAsync(Url + PostEdit, content).Result;

                if (ret != null)
                {
                    ResponseValue = string.Empty;

                    Task task = ret.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            ResponseValue = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
                ResponseJson = JsonConvert.DeserializeObject<Json>(ResponseValue);
            }
            catch (AggregateException a)
            {
                return false; }
            return ResponseJson.Ok;
        }
        public bool DeleteTodo(string id)
        {
            IEnumerable<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id",id)
            };
            HttpContent content = new FormUrlEncodedContent(data);
            try
            {
                var ret = _client.PostAsync(Url + PostDelete, content).Result;

                if (ret != null)
                {
                    ResponseValue = string.Empty;

                    Task task = ret.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            ResponseValue = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
                ResponseJson = JsonConvert.DeserializeObject<Json>(ResponseValue);
            }
            catch (AggregateException a)
            {
                return false; }
            return ResponseJson.Ok;
        }
    }
}