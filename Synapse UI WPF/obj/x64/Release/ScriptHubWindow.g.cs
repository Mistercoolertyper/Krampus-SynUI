﻿#pragma checksum "..\..\..\ScriptHubWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4D7A5FFABAE28C6C6D51A00AB026F0EF00B0BF906D3ED1D42CE290A44A954E98"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Synapse_UI_WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Synapse_UI_WPF {
    
    
    /// <summary>
    /// ScriptHubWindow
    /// </summary>
    public partial class ScriptHubWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TopBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IconBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MiniButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ScriptBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ScriptPictureBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExecuteButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\ScriptHubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Synapse UI WPF;component/scripthubwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ScriptHubWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\ScriptHubWindow.xaml"
            ((Synapse_UI_WPF.ScriptHubWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\ScriptHubWindow.xaml"
            ((Synapse_UI_WPF.ScriptHubWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\ScriptHubWindow.xaml"
            ((Synapse_UI_WPF.ScriptHubWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TopBox = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.TitleBox = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.IconBox = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.MiniButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\ScriptHubWindow.xaml"
            this.MiniButton.Click += new System.Windows.RoutedEventHandler(this.MiniButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ScriptBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\..\ScriptHubWindow.xaml"
            this.ScriptBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ScriptBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ScriptPictureBox = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.DescriptionBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.ExecuteButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\ScriptHubWindow.xaml"
            this.ExecuteButton.Click += new System.Windows.RoutedEventHandler(this.ExecuteButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\ScriptHubWindow.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

