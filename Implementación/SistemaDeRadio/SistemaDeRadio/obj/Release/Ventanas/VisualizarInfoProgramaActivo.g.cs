#pragma checksum "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3444254B07EF85A34A3EE355699C91F7D22CBC87129B20865CD0BB8B995C23F0"
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
    /// VisualizarInfoProgramaActivo
    /// </summary>
    public partial class VisualizarInfoProgramaActivo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegresar;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbNombrePrograma;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbHoraInicio;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbHoraFin;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbDiaProgramado;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbEstacion;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgElementos;
        
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
            System.Uri resourceLocater = new System.Uri("/SistemaDeRadio;component/ventanas/visualizarinfoprogramaactivo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
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
            this.btnRegresar = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Ventanas\VisualizarInfoProgramaActivo.xaml"
            this.btnRegresar.Click += new System.Windows.RoutedEventHandler(this.btnRegresar_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbNombrePrograma = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lbHoraInicio = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lbHoraFin = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbDiaProgramado = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lbEstacion = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.dgElementos = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

