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

using System.Xml.Linq;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace pdf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginHomePage : Page
    {
        public LoginHomePage()
        {
            this.InitializeComponent();
        }

        private async void ConfirmAction(object sender, RoutedEventArgs e)
        {
            // Clear Erro message 


            // Create proxy instance 
            pdf.ServiceReference3.Service3Client serviceClient = new pdf.ServiceReference3.Service3Client();

            // async call WCF method to get returned data 
            pdf.ServiceReference3.querySqlRequest request = new pdf.ServiceReference3.querySqlRequest(AccountInput.Text, PasswordInput.Text, false);
            pdf.ServiceReference3.querySqlResponse ds = await serviceClient.querySqlAsync(request);



            if (ds.queryParam)
            {
                // Convert Xml to List<Article> 
                XDocument xdoc = XDocument.Parse(ds.querySqlResult.Nodes[1].ToString(), LoadOptions.None);
                var data = from query in xdoc.Descendants("Table")
                           select new Article
                           {

                               userid = query.Element("userid").Value,
                               password = query.Element("password").Value
                           };
                if (data.Count() == 0)
                {
                    greetingOutput.Text = "account or password is wrong";
                }

                //log in success
                else
                {
                    StorageFolder folder;
                    folder = ApplicationData.Current.LocalFolder;
                    string file_name = "local_user";
                    StorageFile file_demonstration = await folder.CreateFileAsync(file_name, CreationCollisionOption.ReplaceExisting);
                    //Stream file = await file_demonstration.OpenStreamForWriteAsync();
                    using (Stream file = await file_demonstration.OpenStreamForWriteAsync())
                    {
                        using (StreamWriter write = new StreamWriter(file))
                        {
                            write.Write(AccountInput.Text);
                        }
                    }
                    this.Frame.Navigate(typeof(MainPage));
                }
                // Set ItemsSource of ListView control 
                //lvDataTemplates.ItemsSource = data;
            }
            else
            {
                greetingOutput.Text = "Error occurs. Please make sure the database has been attached to SQL Server!";
            }

        }

        private void Hyperlinkbutton_Click_register(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }
    }
}