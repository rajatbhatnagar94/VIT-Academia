using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//using NotificationsExtensions.TileContent;
using Windows.UI.Notifications;
//using NotificationsExtensions.BadgeContent;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Runtime.Serialization;
using System.Text;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            webview1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            this.SizeChanged += (a, b) =>
            {
                ApplicationViewState views = ApplicationView.Value;
                VisualStateManager.GoToState(this, views.ToString(), false);

            };
          /*  ITileWideText03 tileContent = TileContentFactory.CreateTileWideText03();
            tileContent.TextHeadingWrap.Text = "Hello World! My very own tile notification";
            ITileSquareText04 squareContent = TileContentFactory.CreateTileSquareText04();
            squareContent.TextBodyWrap.Text = "Hello World! My very own tile notification";
            tileContent.SquareContent = squareContent;

            // send the notification
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());

            BadgeNumericNotificationContent badgeContent = new BadgeNumericNotificationContent((uint)1);

            // send the notification to the app's application tile
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeContent.CreateNotification());
            BadgeGlyphNotificationContent badgeContent2 = new BadgeGlyphNotificationContent((GlyphValue)1);

            // send the notification to the app's application tile
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeContent2.CreateNotification());
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);
            */
        }

        public static bool IsInternet()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            return internet;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (IsInternet())
            {
                Uri ur = new Uri("https://academics.vit.ac.in/parent/captcha.asp");
                webview1.Navigate(ur);
                try
                {
                    await RestoreAsync();
                }
                catch (Exception)
                { }
            }
            else
            {
                var dlg = new Windows.UI.Popups.MessageDialog("An internet connection is needed. Please check your connection and restart the app.");
                dlg.Commands.Add(new UICommand("Exit", (UICommandInvokedHandler) =>
                {
                    Application.Current.Exit();
                }));
                dlg.Commands.Add(new UICommand("Try Again", (UICommandInvokedHandler) =>
                {
                    
                }));
                await dlg.ShowAsync();
            }

        }



        string getstring(string id, string pass, string captcha)
        {
            string g = @"<form name='parent_login' id='f1' action='https://academics.vit.ac.in/parent/parent_login_submit.asp' method='post'>
						<input type='TEXT' name='message' value='Invalid Register Number....!'/>
		    			<input type='text' name='wdregno' value='" + id + @"' class='textbox2' size='15' maxlength='9' value='' tabindex='1'/>
						<input type='password' name='wdpswd' value='" + pass + @"' class='textbox' size='15' maxlength='8' tabindex='2' />
						<input type='text' name='vrfcd' value='" + captcha + @"' class='textbox' size='10' maxlength='6' tabindex='3'/>
						
		
		</form>
            <script type='text/javascript' >
           var k=document.getElementById(f1);
             f1.style.display = false;   
            f1.submit();

            </script>
	";
            return g;

        }
        public class UserDetail
        {

            public string Id { get; set; }

            public string Name { get; set; }

        }
        UserDetail Stats = new UserDetail();

        async Task RestoreAsync()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("UserDetails");

            if (file == null) return;

            IRandomAccessStream inStream = await file.OpenReadAsync();

            // Deserialize the Session State.

            DataContractSerializer serializer = new DataContractSerializer(typeof(UserDetail));

            var StatsDetails = (UserDetail)serializer.ReadObject(inStream.AsStreamForRead());

            inStream.Dispose();

            wdregno.Text = StatsDetails.Name;

            wdpswd.Password = StatsDetails.Id;

        }
        async Task SaveAsync()
        {

            StorageFile userdetailsfile = await ApplicationData.Current.LocalFolder.CreateFileAsync("UserDetails", CreationCollisionOption.ReplaceExisting);

            IRandomAccessStream raStream = await userdetailsfile.OpenAsync(FileAccessMode.ReadWrite);

            using (IOutputStream outStream = raStream.GetOutputStreamAt(0))
            {

                // Serialize the Session State.

                DataContractSerializer serializer = new DataContractSerializer(typeof(UserDetail));

                serializer.WriteObject(outStream.AsStreamForWrite(), Stats);

                await outStream.FlushAsync();

            }
        }
        private async void Login_Click_1(object sender, RoutedEventArgs e)
        {
            if (wdregno.Text.Length < 9)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Invalid Register number!!!");
                var result = messageDialog.ShowAsync();

            }
            else if (wdpswd.Password.Length < 8)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Invalid DOB!!!");
                var result = messageDialog.ShowAsync();

            }
            else if (cap.Text.Length < 6)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Wrong Captcha!!!");
                var result = messageDialog.ShowAsync();
            }
            else
            {
                string ht = getstring(wdregno.Text, wdpswd.Password, cap.Text);
                ww.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                maingrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                bar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                bar.IsIndeterminate = true;
                Stats.Name = wdregno.Text;

                Stats.Id = wdpswd.Password;

                await SaveAsync();

                ww.NavigateToString(ht);
            }
            //var messageDialog = new Windows.UI.Popups.MessageDialog("Enter Correct details!!!");
            //var result = messageDialog.ShowAsync();

        }


        private void webview1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            webview1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ring.IsActive = false;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ring.IsActive = true;
            webview1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Uri ur = new Uri("https://academics.vit.ac.in/parent/captcha.asp");
            webview1.Navigate(ur);

        }

        private void ww_LoadCompleted(object sender, NavigationEventArgs e)
        {
            // ww.Visibility = Windows.UI.Xaml.Visibility.Visible;

            bar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            bar.IsIndeterminate = false;
            this.Frame.Navigate(typeof(BasicPage1));
        }



        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            cap.Text = cap.Text.ToUpper();
            wdregno.Text = wdregno.Text.ToUpper();

        }

        private void cap_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            if (e.Key.ToString().Equals("Enter"))
            {
                Login_Click_1(sender, e);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            wdregno.Text = "";
            wdpswd.Password = "";
            cap.Text = "";

        }

        private async void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog message = new MessageDialog("Help Menu","Help Menu");
            await message.ShowAsync();
        }
    }
}
