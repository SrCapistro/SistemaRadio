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
        List<ListaCancionesDAO> canciones;
        public MenuCanciones()
        {
            InitializeComponent();
            canciones = new List<ListaCancionesDAO>();
            llenarTabla();
        }

        private void llenarTabla()
        {
            

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

                String[] columnas = { "Id ", " titulo "," cantante "," genero ", " categoria " };

                float[] tamanios = { 1, 4, 4, 4, 4};
                Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                foreach (String columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                }

                string sql = "SELECT mus_canciones.CAN_ID, mus_canciones.CAN_TITULO, mus_cantantes.CNT_NOMBRE, mus_generos.GNR_NOMBRE, mus_categorias.CAT_NOMBRE FROM mus_canciones LEFT JOIN mus_cantantes ON mus_canciones.CAN_ID = mus_cantantes.CNT_ID LEFT JOIN mus_generos ON mus_canciones.CAN_ID = mus_generos.GNR_ID LEFT JOIN mus_categorias ON mus_canciones.CAN_ID = mus_categorias.CAT_ID";
                
                MySqlConnection conexionBD = ConexionBD.getConnetion();
                
                //conexionBD.Open();

                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["CAN_ID"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["CAN_TITULO"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["CNT_NOMBRE"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["GNR_NOMBRE"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["CAT_NOMBRE"].ToString()).SetFont(fontContenido)));
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
            crearSegundoPDF();
        }
        private void crearSegundoPDF() {
            try
            {
                PdfWriter pdfWriter = new PdfWriter("Reporte de Canciones NO Ocupadas pruebaaa.pdf");
                PdfDocument pdf = new PdfDocument(pdfWriter);
                Document documento = new Document(pdf, PageSize.LETTER);

                documento.SetMargins(20, 20, 20, 20);
                var parrafo = new Paragraph("Reporte de canciones NO Ocupadas pruebaaa");
                documento.Add(parrafo);

                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                String[] columnas = {"Id ", " titulo " };

                float[] tamanios = { 1, 2,};
                Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                foreach (String columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                }

                string sql = "SELECT LIST_IDCANCION, CAN_TITULO FROM mus_listacanciones LEFT JOIN mus_canciones ON mus_listacanciones.LIST_IDCANCION = mus_canciones.CAN_ID EXCEPT SELECT LIST_IDCANCION, CAN_TITULO FROM mus_listacanciones RIGHT JOIN mus_canciones ON mus_listacanciones.LIST_IDCANCION = mus_canciones.CAN_ID";
                MySqlConnection conexionBD = ConexionBD.getConnetion();

                //conexionBD.Open();

                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["LIST_IDCANCION"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(reader["CAN_TITULO"].ToString()).SetFont(fontContenido)));
                }

                    documento.Add(tabla);
                    documento.Close();
                    MessageBox.Show("Reporte generado exitosamente!", "Mensaje de Confirmación");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("error");
                MessageBox.Show("Error al generar el archivo. Intente más tarde", "ERROR");
            }
        }
    }
}
