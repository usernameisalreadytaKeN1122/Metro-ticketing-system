﻿#pragma checksum "..\..\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7284E606D52675A598B8C00310CEC9AAEB3CAFBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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
using 第二组综合设计地铁购票系统;


namespace 第二组综合设计地铁购票系统 {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel title;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border win_min;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border win_close;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border 售票系统;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border 管理系统;
        
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
            System.Uri resourceLocater = new System.Uri("/第二组综合设计地铁购票系统;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
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
            this.title = ((System.Windows.Controls.DockPanel)(target));
            
            #line 27 "..\..\Login.xaml"
            this.title.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.title_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.win_min = ((System.Windows.Controls.Border)(target));
            
            #line 34 "..\..\Login.xaml"
            this.win_min.MouseEnter += new System.Windows.Input.MouseEventHandler(this.win_min_MouseEnter);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Login.xaml"
            this.win_min.MouseLeave += new System.Windows.Input.MouseEventHandler(this.win_min_MouseLeave);
            
            #line default
            #line hidden
            
            #line 37 "..\..\Login.xaml"
            this.win_min.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.win_min_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.win_close = ((System.Windows.Controls.Border)(target));
            
            #line 41 "..\..\Login.xaml"
            this.win_close.MouseLeave += new System.Windows.Input.MouseEventHandler(this.win_min_MouseLeave);
            
            #line default
            #line hidden
            
            #line 42 "..\..\Login.xaml"
            this.win_close.MouseEnter += new System.Windows.Input.MouseEventHandler(this.win_min_MouseEnter);
            
            #line default
            #line hidden
            
            #line 43 "..\..\Login.xaml"
            this.win_close.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.win_close_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.售票系统 = ((System.Windows.Controls.Border)(target));
            
            #line 71 "..\..\Login.xaml"
            this.售票系统.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.售票系统_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.管理系统 = ((System.Windows.Controls.Border)(target));
            
            #line 74 "..\..\Login.xaml"
            this.管理系统.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.管理系统_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

