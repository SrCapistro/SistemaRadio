﻿#pragma checksum "..\..\..\Ventanas\PatronesRegistrados.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3FBC95B9DA51260B4CD68DEAB17BCF375358C3598F8167347438A6C8A39AA4DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using SistemaDeRadio.Ventanas;
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


namespace SistemaDeRadio.Ventanas {
    
    
    /// <summary>
    /// PatronesRegistrados
    /// </summary>
    public partial class PatronesRegistrados : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Ventanas\PatronesRegistrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tablaPatrones;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Ventanas\PatronesRegistrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCrearPatron;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Ventanas\PatronesRegistrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificarPatron;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Ventanas\PatronesRegistrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarPatron;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Ventanas\PatronesRegistrados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGenerarReporte;
        
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
            System.Uri resourceLocater = new System.Uri("/SistemaDeRadio;component/ventanas/patronesregistrados.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Ventanas\PatronesRegistrados.xaml"
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
            this.tablaPatrones = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnCrearPatron = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Ventanas\PatronesRegistrados.xaml"
            this.btnCrearPatron.Click += new System.Windows.RoutedEventHandler(this.btnCrearPatron_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnModificarPatron = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Ventanas\PatronesRegistrados.xaml"
            this.btnModificarPatron.Click += new System.Windows.RoutedEventHandler(this.btnModificarPatron_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnEliminarPatron = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Ventanas\PatronesRegistrados.xaml"
            this.btnEliminarPatron.Click += new System.Windows.RoutedEventHandler(this.btnEliminarPatron_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnGenerarReporte = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            
            #line 65 "..\..\..\Ventanas\PatronesRegistrados.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

