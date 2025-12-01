// EstadisticasForm.cs
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProyectoGrafoFamiliar.Logica;
using ProyectoGrafoFamiliar.Datos;

namespace ProyectoGrafoFamiliar.Presentacion
{
    public partial class EstadisticasForm : Form
    {
        private EstadisticasFamiliares estadisticas;

        public EstadisticasForm(EstadisticasFamiliares est)
        {
            InitializeComponent();
            estadisticas = est;
            MostrarEstadisticas();
        }

        private void MostrarEstadisticas()
        {
            flowLayoutPanelPersonas.Controls.Clear();
            lblResumen.Text = estadisticas.GenerarResumen();
            double promedio = estadisticas.CalculaDistanciaPromedio();
            Label lblPromedio = new Label
            {
                Text = $"Promedio de Distancias en el Grafo: {promedio:F2} km",
                Font = new Font("Arial", 11, FontStyle.Bold),
                Size = new Size(flowLayoutPanelPersonas.Width - 40, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(10),
                BackColor = Color.LightGray
            };
            flowLayoutPanelPersonas.Controls.Add(lblPromedio);

            var parCercano = estadisticas.ObtenerParMasCercano();
            var parLejano = estadisticas.ObtenerParMasLejano();
            // Función que crea una tarjeta 
            Panel CrearTarjeta(Persona persona, Persona otraPersona)
            {
                Panel panelPersona = new Panel
                {
                    Size = new Size(200, 310),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                };

                // PictureBox para la foto
                PictureBox picFoto = new PictureBox
                {
                    Size = new Size(150, 150),
                    Location = new Point(25, 10),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle
                };
                if (persona.Foto != null && persona.Foto.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(persona.Foto))
                        {
                            picFoto.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        picFoto.Image = null;
                        Console.WriteLine($"Error cargando foto de {persona.NombreCompleto}: {ex.Message}");
                    }
                }

                // Label para el nombre
                Label lblNombre = new Label
                {
                    Text = persona.NombreCompleto,
                    Location = new Point(10, 170),
                    Size = new Size(180, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                // Label para el genero
                Label lblGenero = new Label
                {
                    Text = $"Género: {persona.ObtenerGeneroTexto()}",
                    Location = new Point(10, 195),
                    Size = new Size(180, 15),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 8, FontStyle.Italic),
                    
                };
                // Label para las relaciones
                Label lblRelaciones = new Label
                {
                    Text = persona.ObtenerDescripcionRelaciones(),
                    Location = new Point(10, 215),
                    Size = new Size(180, 50),
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Arial", 8)
                };

                // Label para la distancia al otro miembro del par
                double distancia = estadisticas.Calculadora.CalcularDistanciaPersonas(persona, otraPersona);
                Label lblDistancia = new Label
                {
                    Text = $"Distancia a {otraPersona.NombreCompleto}: {distancia:F2} km",
                    Location = new Point(10, 275),
                    Size = new Size(180, 25),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 8, FontStyle.Italic)
                };

                // Agregar controles al panel
                panelPersona.Controls.Add(picFoto);
                panelPersona.Controls.Add(lblNombre);
                panelPersona.Controls.Add(lblGenero);
                panelPersona.Controls.Add(lblRelaciones);
                panelPersona.Controls.Add(lblDistancia);

                return panelPersona;
            }
            
            Panel CrearSeccion(string titulo, Persona p1, Persona p2)
            {
                var panelSeccion = new Panel
                {
                    Size = new Size(flowLayoutPanelPersonas.Width - 40, 350),
                    Margin = new Padding(10),
                };
                Label lblTitulo = new Label
                {
                    Text = titulo,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 20,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(0, 0, 0, 5),
                };
                panelSeccion.Controls.Add(lblTitulo);
                FlowLayoutPanel flowTarjetas = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    Dock = DockStyle.Fill,
                    AutoScroll = false,
                };
                flowTarjetas.Controls.Add(CrearTarjeta(p1, p2));
                flowTarjetas.Controls.Add(CrearTarjeta(p2, p1));
                panelSeccion.Controls.Add(flowTarjetas);
                return panelSeccion;
            }

            // Agregar las secciones con pares correctamente agrupados
            if (parCercano.Item1 != null && parCercano.Item2 != null)
            {
                flowLayoutPanelPersonas.Controls.Add(CrearSeccion("Par Más Cercano", parCercano.Item1, parCercano.Item2));
            }
            if (parLejano.Item1 != null && parLejano.Item2 != null)
            {
                flowLayoutPanelPersonas.Controls.Add(CrearSeccion("Par Más Lejano", parLejano.Item1, parLejano.Item2));
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}