using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using SistemaDeRadio.DAO;
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
using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;

namespace SistemaDeRadio.Ventanas
{
    /// <summary>
    /// Lógica de interacción para MenuCanciones.xaml
    /// </summary>
    public partial class MenuCanciones : Window
    {
        public MenuCanciones()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Close();
        }

        private void btnBuscarCancion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificarCancion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistrarCancion_Click(object sender, RoutedEventArgs e)
        {
            RegistrarCancion registrarCancion = new RegistrarCancion();
            registrarCancion.Show();
            this.Close();
        }

        private void btnGenerarReporteCanciones_Click(object sender, RoutedEventArgs e)
        {
            crearPDF();
        }

        private void crearPDF()
        {
            try
            {
                PdfWriter pdfWriter = new PdfWriter("Inventario de Canciones.pdf");
                PdfDocument pdf = new PdfDocument(pdfWriter);
                Document documento = new Document(pdf, PageSize.LETTER);

                documento.SetMargins(20, 20, 20, 20);
                var parrafo = new Paragraph("Inventario de canciones");
                documento.Add(parrafo);

                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                String[] columnas = { "Id ", " titulo " };

                float[] tamanios = { 2, 6 };
                Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                foreach (String columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                }

                string sql = "SELECT CAN_ID, CAN_TITULO FROM mus_canciones";
                
                MySqlConnection conexionBD = ConexionBD.getConnetion();
                
                //conexionBD.Open();

                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["CAN_ID"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["CAN_TITULO"].ToString()).SetFont(fontContenido)));
                }

                documento.Add(tabla);
                documento.Close();
                MessageBox.Show("Reporte generado exitosamente!", "Mensaje de Confirmación");
            }
            catch
            {
                Console.WriteLine("error");
                MessageBox.Show("Error al generar el archivo. Intente más tarde", "ERROR");
            }
        }

        private void btnGenerarReporteCancionesSinUso_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
