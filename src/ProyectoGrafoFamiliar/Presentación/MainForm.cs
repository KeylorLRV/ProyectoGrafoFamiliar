using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using ProyectoGrafoFamiliar.Datos;
using ProyectoGrafoFamiliar.Logica;


namespace ProyectoGrafoFamiliar.Presentacion
{
    public partial class MainForm : Form
    {
        private GrafoFamiliar grafo;
        private CalculadoraDistancia calculadora;

        public MainForm(GrafoFamiliar grafo, CalculadoraDistancia calculadora)
        {
            try
            {
                InitializeComponent();
                
                this.grafo = grafo;
                this.calculadora = calculadora;
                
            }
            catch (Exception ex)
            {
                Program.LogException(ex);
                MessageBox.Show("Ocurrió un error al inicializar la ventana principal. Revise logs/startup.log para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public MainForm()
        {
            try
            {
                InitializeComponent();

                grafo = new GrafoFamiliar();
                calculadora = new CalculadoraDistancia();
                
            }
            catch (Exception ex)
            {
                // Log and surface a friendly message
                Program.LogException(ex);
                MessageBox.Show("Ocurrió un error al inicializar la ventana principal. Revise logs/startup.log para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void AgregarPersona_Click(object sender, EventArgs e)
        {
            // Validar y crear persona
            if (string.IsNullOrWhiteSpace(TxtCedula.Text))
            {
                MessageBox.Show("Ingrese una cédula válida.");
                return;
            }
            // Crear coordenada y persona (solo ejemplo estático; adaptalo)
            var coord = new Coordenada() { Latitud = 9.935, Longitud = -84.081 }; // Ejemplo Costa Rica
            var persona = new Persona()
            {
                Cedula = TxtCedula.Text.Trim(),
                Coordenadas = coord,
                FechaNac = DateTime.Now.AddYears(-30), // Ejemplo edad 30 años
                Foto = null // Aquí carga byte[] de foto si tienes
            };
            if (!persona.ValidarDatos())
            {
                MessageBox.Show("Datos inválidos en la persona.");
                return;
            }
            grafo.AgregarNodo(persona);
            // Quitar: visualizador.AgregarMarcador(persona);
            MessageBox.Show($"Persona {persona.Cedula} agregada al grafo.");
        }

    }
}
