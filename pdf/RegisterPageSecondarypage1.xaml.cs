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

using System.Threading.Tasks;
using System.Threading;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace pdf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPageSecondarypage1 : Page
    {
        public RegisterPageSecondarypage1()
        {
            this.InitializeComponent();
            this.timer_();

        }
        public async void timer_()
        {
            bool flag = false;
            int time = 3;
            while (!flag)
            {
                await Task.Delay(1000);
                Timer_.Text = time.ToString();
                time = time - 1;
                if (time == 0)
                {
                    flag = true;
                }
            }
            Window.Current.Close();
        }
    }
}
