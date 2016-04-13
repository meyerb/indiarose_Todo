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
using TodoLibrary.Services;

namespace TodoLibrary.Model
{
    public class HttpService : IHttpService
    {
        private const string Url = "http://storm-project.fr/ios/api";
        private string _responseValue;
        private const string PostLogin = "/login";
        private const string PostRegister = "/register";
        private const string PostList = "/list";
        private readonly HttpClient _client = new HttpClient();

        public HttpService()
        {
            
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
            var ret = _client.PostAsync(Url+PostLogin, content).Result;
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

            return true;
        }

        public bool Register(string login, string pwd)
        {
            IEnumerable<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("login",login),
                new KeyValuePair<string, string>("password",pwd)
            };
            HttpContent content = new FormUrlEncodedContent(data);
            var ret = _client.PostAsync(Url+PostRegister, content).Result;
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
            Connection(login,pwd);
            return true;
        }
    }
}