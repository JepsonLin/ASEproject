using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace pdf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    

    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void Hyperlinkbutton_Click_register_confirm(object sender, RoutedEventArgs e)
        {


            // Clear Erro message 
            // Create proxy instance 
            pdf.ServiceReference3.Service3Client serviceClient_f = new pdf.ServiceReference3.Service3Client();

            // async call WCF method to get returned data 
            pdf.ServiceReference3.querySqlRequest request_f = new pdf.ServiceReference3.querySqlRequest(AccountInput.Text, PasswordInput.Text, true);
            pdf.ServiceReference3.querySqlResponse ds_f = await serviceClient_f.querySqlAsync(request_f);


            if (ds_f.queryParam)
            {
                // Convert Xml to List<Article> 
                XDocument xdoc = XDocument.Parse(ds_f.querySqlResult.Nodes[1].ToString(), LoadOptions.None);
                var data = from query in xdoc.Descendants("Table")
                           select new Article_f
                           {

                               userid = query.Element("userid").Value,

                           };
                if (data.Count() == 0)
                {
                    pdf.ServiceReference4.Service4Client serviceClient = new pdf.ServiceReference4.Service4Client();

                    // async call WCF method to get returned data 
                    pdf.ServiceReference4.querySqlRequest request = new pdf.ServiceReference4.querySqlRequest(AccountInput.Text.Trim(), PasswordInput.Text.Trim());
                    pdf.ServiceReference4.querySqlResponse ds = await serviceClient.querySqlAsync(request);

                    if (ds.queryParam)
                    {
                        // Convert Xml to List<Article> 
                        /*  XDocument xdoc = XDocument.Parse(ds.querySqlResult.Nodes[1].ToString(), LoadOptions.None);
                          var data = from query in xdoc.Descendants("Table")
                                     select new Article
                                     {
                                         userid = query.Element("userid").Value,
                                         password = query.Element("password").Value
                                     };*/

                        /*   {
                               CoreApplicationView newView = CoreApplication.CreateNewView();
                               int newViewId = 0;
                               await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                               {
                                   Frame frame = new Frame();
                                   frame.Navigate(typeof(RegisterPageSecondarypage1), null);
                                   Window.Current.Content = frame;
                                   // You have to activate the window in order to show it later.
                                   Window.Current.Activate();

                                   newViewId = ApplicationView.GetForCurrentView().Id;
                               });
                               bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);

                           }*/
                        var dialog = new ContentDialog()
                        {
                            Title = "Info",
                            Content = "Register Success!",
                            PrimaryButtonText = "OK",
                            SecondaryButtonText = "Cancel",
                            FullSizeDesired = false,
                        };

                        dialog.PrimaryButtonClick += (_s, _e) => { };
                        await dialog.ShowAsync();

                        this.Frame.Navigate(typeof(MainPage));
                        // Set ItemsSource of ListView control 
                        //lvDataTemplates.ItemsSource = data;
                    }
                    else
                    {
                        greetingOutput.Text = "Insert Error occurs. Please make sure the database has been attached to SQL Server!";
                    }
                }

                //log in success
                else
                {
                    var dialog = new ContentDialog()
                    {
                        Title = "Info",
                        Content = "Userid exists",
                        PrimaryButtonText = "return",
                        FullSizeDesired = false,
                    };

                    dialog.PrimaryButtonClick += (_s, _e) => { };
                    await dialog.ShowAsync();
                }
                // Set ItemsSource of ListView control 
                //lvDataTemplates.ItemsSource = data;
            }
            else
            {
                greetingOutput.Text = "Select Error occurs. Please make sure the database has been attached to SQL Server!";
            }

            // Create proxy instance 

        }


    }

}
