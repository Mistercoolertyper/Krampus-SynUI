﻿#pragma checksum "..\..\..\OptionsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "62AB8E6BBE0C5D589B3DED293791D2ECF4259FACBB08F859D0AB53F261A2544C"
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
    /// OptionsWindow
    /// </summary>
    public partial class OptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IconBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox UnlockBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AutoLaunchBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AutoAttachBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox InternalUIBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IngameChatBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BetaReleaseBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ResetLabel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider ScaleSlider;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\OptionsWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Synapse UI WPF;component/optionswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OptionsWindow.xaml"
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
            
            #line 8 "..\..\..\OptionsWindow.xaml"
            ((Synapse_UI_WPF.OptionsWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\OptionsWindow.xaml"
            ((Synapse_UI_WPF.OptionsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IconBox = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.UnlockBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.AutoLaunchBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 25 "..\..\..\OptionsWindow.xaml"
            this.AutoLaunchBox.Click += new System.Windows.RoutedEventHandler(this.AutoLaunchBox_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AutoAttachBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.InternalUIBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.IngameChatBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.BetaReleaseBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 29 "..\..\..\OptionsWindow.xaml"
            this.BetaReleaseBox.Click += new System.Windows.RoutedEventHandler(this.BetaReleaseBox_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ResetLabel = ((System.Windows.Controls.Label)(target));
            
            #line 32 "..\..\..\OptionsWindow.xaml"
            this.ResetLabel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ResetLabel_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ScaleSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 34 "..\..\..\OptionsWindow.xaml"
            this.ScaleSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ScaleSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\OptionsWindow.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
