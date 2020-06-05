using LightControlPro.MenuItems;
using System;
using LightControlPro.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LightControlPro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Home", Icon = "ic_lcp3.png", TargetType = typeof(ViewMain) };
            var page2 = new MasterPageItem() { Title = "SavingTips", Icon = "ic_lcp6.png", TargetType = typeof(SavingTips) };
            var page3 = new MasterPageItem() { Title = "About", Icon = "ic_lcp7.png", TargetType = typeof(About) };
            //var page4 = new MasterPageItem() { Title = "Support", Icon = "ic_lcp9.png", TargetType = typeof(Chat) };
            //var page5 = new MasterPageItem() { Title = "Settings", Icon = "ic_lcp5.png", TargetType = typeof(Settings) };
            var page6 = new MasterPageItem() { Title = "Account", Icon = "ic_lcp8.png", TargetType = typeof(Account) };


            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            //menuList.Add(page4);
            //menuList.Add(page5);
            menuList.Add(page6);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ViewMain)));
            this.BindingContext = new
            {
                Header = "",
                Image = "ic_launcher.png",
                //Footer = "         -------- User --------           "
                Footer = "User"
            };
        }



        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            //Detail.Navigation.PushAsync((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
