﻿#pragma checksum "C:\Users\v-ljianp\Downloads\foxitSDK-master\ASEproject\pdf\LoginHomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "36822E9972C1F053F863ED64EE625F94"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pdf
{
    partial class LoginHomePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.PageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.contentPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.AccountPannel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4:
                {
                    this.PasswordPannel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5:
                {
                    this.ConfirmButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 22 "..\..\..\LoginHomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ConfirmButton).Click += this.ConfirmAction;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.HyperlinkButton element6 = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 24 "..\..\..\LoginHomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)element6).Click += this.Hyperlinkbutton_Click_register;
                    #line default
                }
                break;
            case 7:
                {
                    this.greetingOutput = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.PasswordInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9:
                {
                    this.AccountInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
