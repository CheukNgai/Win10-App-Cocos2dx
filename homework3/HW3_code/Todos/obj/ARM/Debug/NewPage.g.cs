﻿#pragma checksum "C:\Users\Administrator\Desktop\homework3\HW3_code\Todos\NewPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "89A0EE2EB64C5432F7A9156E73A95F68"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Todos
{
    partial class NewPage : 
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
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.Cover = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3:
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.Description = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.Date = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 6:
                {
                    this.createButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 34 "..\..\..\NewPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.createButton).Click += this.Create_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.CancelButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 35 "..\..\..\NewPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.CancelButton).Click += this.Cancel_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.SelectPictureButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 28 "..\..\..\NewPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.SelectPictureButton).Click += this.Upload_Click;
                    #line default
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
