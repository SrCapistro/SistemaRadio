using SistemaDeRadio.DAO;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using System.Data;

namespace SistemaDeRadio.Ventanas
{
    /// <summary>
    /// Lógica de interacción para VisualizarCronograma.xaml
    /// </summary>
    public partial class VisualizarCronograma : Window
    {

        List<Programa> programas;
        List<Formato> formatos;
        List<ReporteProgramacionDelDia> elementosReporte;
        String fechaHoy = DateTime.Now.ToString("dddd");

        public VisualizarCronograma()
        {
            InitializeComponent();
            programas = new List<Programa>();
            formatos = new List<Formato>();
            elementosReporte = new List<ReporteProgramacionDelDia>();
            cargarProgramasDelDia(fechaHoy);
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            salir();
        } 

        private void salir()
        {
            PantallaPrincipal regresarPrincipal = new PantallaPrincipal();
            regresarPrincipal.Show();
            this.Close();
        }

        void cargarProgramasDelDia(String fecha)
        {

            try
            {
                lbFecha.Content = "Cronograma - " + fecha;

                programas = ProgramaDAO.obtenerProgramasProgramados(fecha, PantallaPrincipal.estacion);
                dgProgramas.AutoGenerateColumns = false;

                dgProgramas.ItemsSource = programas;
                dgProgramas.CanUserAddRows = false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
                        
        private void seleccionPrograma_Click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Programa programaSeleccionado = new Programa();
                programaSeleccionado = programas[dgProgramas.SelectedIndex];

                int idHorarioAux = programaSeleccionado.IdHorario;
                formatos = FormatoDAO.obtenerElementosDelPrograma(idHorarioAux);

                dgSegunPrograma.AutoGenerateColumns = false;
                dgSegunPrograma.ItemsSource = formatos;
                dgSegunPrograma.CanUserAddRows = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnGenerarPdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                elementosReporte = FormatoDAO.obtenerElementosParaReporteDelDia(PantallaPrincipal.estacion, fechaHoy);


                //Create a new PDF document.
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();

                //AQUI LO DEL NUEVO CODIGO
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 30);

                //Draw the text
                graphics.DrawString("Reporte de Programación del Día - " +  fechaHoy, font, PdfBrushes.Blue, new PointF(0, 0));

                //ACA ACABA


                //Create a DataTable.
                DataTable dataTable = new DataTable();
                //Add columns to the DataTable
                dataTable.Columns.Add("Nombre Programa");
                dataTable.Columns.Add("Hora Inicio");
                dataTable.Columns.Add("Hora Fin");
                dataTable.Columns.Add("Elemento");
                dataTable.Columns.Add("Comentarios");
                dataTable.Columns.Add("Patron");

                //Add rows to the DataTable.


                foreach (ReporteProgramacionDelDia reporteR in elementosReporte)
                {
                    dataTable.Rows.Add(reporteR.NombrePrograma, reporteR.HoraInicio, reporteR.HoraFin, reporteR.NombreElemento, reporteR.Comentario, reporteR.NombrePatron);
                }

                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new PointF(20, 50));
                                
                //Save the document.
                doc.Save("ReporteP2.pdf");
                //close the document
                doc.Close(true);

                MessageBox.Show("Reporte generado exitosamente!", "Mensaje de Confirmación");
                salir();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Error al generar el archivo. Intente más tarde", "ERROR");
            }
        }
    }
}
