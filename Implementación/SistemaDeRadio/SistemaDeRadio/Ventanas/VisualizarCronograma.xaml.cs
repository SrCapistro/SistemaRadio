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

                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.Pages.Add();
                PdfGrid pdfGrid = new PdfGrid();

                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 30);
                graphics.DrawString("Reporte de Programación del Día - " + fechaHoy, font, PdfBrushes.Blue, new PointF(0, 0));

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Nombre Programa");
                dataTable.Columns.Add("Hora Inicio");
                dataTable.Columns.Add("Hora Fin");
                dataTable.Columns.Add("Elemento");
                dataTable.Columns.Add("Comentarios");
                dataTable.Columns.Add("Patron");

                foreach (ReporteProgramacionDelDia reporteR in elementosReporte)
                {
                    dataTable.Rows.Add(reporteR.NombrePrograma, reporteR.HoraInicio, reporteR.HoraFin, reporteR.NombreElemento, reporteR.Comentario, reporteR.NombrePatron);
                }

                pdfGrid.DataSource = dataTable;
                pdfGrid.Draw(page, new PointF(20, 50));

                Random r = new Random();
                String archivoAux = "ReporteProgramacionDelDia" + r.Next(0, 10000) + ".pdf";
                doc.Save(archivoAux);
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
