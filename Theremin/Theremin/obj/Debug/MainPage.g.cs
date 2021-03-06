﻿#pragma checksum "F:\Windows Phone\Theremin\Theremin\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "28A1986F7F75B9EFCD57EBA0D4805771"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.17929
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPScadaControlsV2;


namespace Theremin {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal WPScadaControlsV2.RadialScale scale;
        
        internal WPScadaControlsV2.NeedleIndicator needle;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.TextBlock Notes;
        
        internal System.Windows.Controls.Button Record_Click;
        
        internal System.Windows.Controls.Button Stop_Click;
        
        internal System.Windows.Controls.TextBlock CurrentFrequency;
        
        internal System.Windows.Controls.TextBlock textBlock2;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Theremin;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.scale = ((WPScadaControlsV2.RadialScale)(this.FindName("scale")));
            this.needle = ((WPScadaControlsV2.NeedleIndicator)(this.FindName("needle")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.Notes = ((System.Windows.Controls.TextBlock)(this.FindName("Notes")));
            this.Record_Click = ((System.Windows.Controls.Button)(this.FindName("Record_Click")));
            this.Stop_Click = ((System.Windows.Controls.Button)(this.FindName("Stop_Click")));
            this.CurrentFrequency = ((System.Windows.Controls.TextBlock)(this.FindName("CurrentFrequency")));
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock2")));
        }
    }
}

