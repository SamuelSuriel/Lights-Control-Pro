using LightControlPro.Models;
using LightControlPro.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LightControlPro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            //BackgroundImage = "icon.png";
            //BackgroundColor = Constants.BackgroundColor;
            //Lbl_Username.TextColor = Constants.MainTextColor;
            //Lbl_Password.TextColor = Constants.MainTextColor;
            //icon.HeightRequest = Constants.iconHeight;
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedureAsync(s, e);
            Btn_Signin.IsEnabled = true;
        }
        async void SignInProcedureAsync(object sender, EventArgs e)
        {
            //if (Entry_Username.Text == string.Empty & Entry_Password.Text == string.Empty)
            if (Entry_Username.Text == null && Entry_Password.Text == null)
            {
                await DisplayAlert("Message", "Please fill the user and password", "OK");
            }
            else
            {
                User user = new User(Entry_Username.Text, Entry_Password.Text);
                if (user.CheckInformation())
                {
                    //ActivitySpinner.IsVisible = false;
                    //var result = await App.RestService.Login(user);
                    //result = new Token();

                    await DisplayAlert("Login", "Login Success!", "OK");
                    //if (result != null)
                    //{
                    //    App.UserDatabase.SaveUser(user);
                    //    App.TokenDatabase.SaveToken(result);
                    //}
                    if (Device.OS == TargetPlatform.Android)
                    {
                        //Application.Current.MainPage = (new NavigationPage(new Account()));
                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        //await Navigation.PushAsync(new NavigationPage (new Account()));
                    }
                    else
                    {
                        await DisplayAlert("Login", "Login Not Correct, empty username or password.", "OK");
                        //ActivitySpinner.IsVisible = false;
                    }

                }
            }
        }

        //private void ButtonSkip_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new MainPage());
        //}
    }
}