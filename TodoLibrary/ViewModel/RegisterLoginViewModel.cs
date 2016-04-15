using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Net.Http;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Inject;
using Storm.Mvvm.Navigation;
using TodoLibrary.Model;
using TodoLibrary.Services;
using PCLCrypto;

namespace TodoLibrary.ViewModel
{
    public class RegisterLoginViewModel : ViewModelBase
    {
        private string _login;
        private string _pwd;

        public ITodoService TodoService => LazyResolver<ITodoService>.Service;
        public IHttpService HttpService => LazyResolver<IHttpService>.Service;

        public ICommand ButtonRegister { get; private set; }
        public ICommand ButtonLogin { get; private set; }

        public String Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }
        public String Pwd
        {
            get { return _pwd; }
            set { SetProperty(ref _pwd, value); }
        }

        public RegisterLoginViewModel()
        {
            ButtonRegister = new DelegateCommand(ClickedRegister);
            ButtonLogin = new DelegateCommand(ClickedLogin);
        }

        private void ClickedRegister()
        {
            byte[] data = Encoding.ASCII.GetBytes(Pwd);
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            byte[] hash = hasher.HashData(data);
            StringBuilder hex = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
                hex.AppendFormat("{0:x2}", b);
            if (HttpService.Register(Login, hex.ToString()))
                NavigationService.Navigate("HomeViewModel");
        }

        private void ClickedLogin()
        {
            byte[] data = Encoding.ASCII.GetBytes(Pwd);
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            byte[] hash = hasher.HashData(data);
            StringBuilder hex = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
                hex.AppendFormat("{0:x2}", b);
            if (HttpService.Connection(Login,hex.ToString()))
                NavigationService.Navigate("HomeViewModel");
        }
    }
}