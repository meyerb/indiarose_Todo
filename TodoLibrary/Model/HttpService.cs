using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

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
        private readonly HttpClient _client = new HttpClient();

        public HttpService()
        {
            
        }

        public bool Connection(string login, string pwd)
        {
            IEnumerable<KeyValuePair<string,string>> data= new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("login",login),
                new KeyValuePair<string, string>("password",pwd)
            };
            HttpContent content= new FormUrlEncodedContent(data);
            var ret = _client.PostAsync(Url, content);
            return true;
        }

        public bool Register(string login, string pwd)
        {
            return true;
        }
    }
}