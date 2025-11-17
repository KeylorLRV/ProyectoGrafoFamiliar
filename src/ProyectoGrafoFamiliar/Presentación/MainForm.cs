using System;
using System.IO;
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
        private byte[] fotoBytes;

        public MainForm(GrafoFamiliar grafo, CalculadoraDistancia calculadora)
        {
            try
            {
                InitializeComponent();
                
                this.grafo = grafo;
                this.calculadora = calculadora;
                
                // Inicializar valores por defecto
                InicializarValoresPorDefecto();
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
                
                // Inicializar valores por defecto
                InicializarValoresPorDefecto();
            }
            catch (Exception ex)
            {
                // Log and surface a friendly message
                Program.LogException(ex);
                MessageBox.Show("Ocurrió un error al inicializar la ventana principal. Revise logs/startup.log para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void InicializarValoresPorDefecto()
        {
            // Establecer valores por defecto para coordenadas (Costa Rica como ejemplo)
            numLatitud.Value = 9.935M;
            numLongitud.Value = -84.081M;
            
            // Establecer fecha de nacimiento por defecto (hace 30 años)
            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-30);
            
            fotoBytes = null;
        }

        private void BtnCargarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos los archivos|*.*";
                    openFileDialog.Title = "Seleccionar Foto de la Persona";
                    
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Cargar la imagen en el PictureBox
                        picFoto.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                        
                        // Convertir la imagen a byte[]
                        fotoBytes = File.ReadAllBytes(openFileDialog.FileName);
                        
                        MessageBox.Show("Foto cargada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.LogException(ex);
                MessageBox.Show($"Error al cargar la foto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    MessageBox.Show("Por favor, ingrese los apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellidos.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCedula.Text))
                {
                    MessageBox.Show("Por favor, ingrese la cédula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCedula.Focus();
                    return;
                }

                if (fotoBytes == null || fotoBytes.Length == 0)
                {
                    MessageBox.Show("Por favor, cargue una foto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear coordenada con los valores ingresados
                var coord = new Coordenada() 
                { 
                    Latitud = (double)numLatitud.Value, 
                    Longitud = (double)numLongitud.Value 
                };

                // Validar coordenadas
                if (!coord.EsValida())
                {
                    MessageBox.Show("Las coordenadas ingresadas no son válidas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear persona con todos los datos
                var persona = new Persona()
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Cedula = txtCedula.Text.Trim(),
                    Coordenadas = coord,
                    FechaNac = dtpFechaNacimiento.Value,
                    Foto = fotoBytes
                };

                // Validar datos de la persona
                if (!persona.ValidarDatos())
                {
                    MessageBox.Show("Los datos ingresados no son válidos. Por favor, verifique todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar persona al grafo
                grafo.AgregarNodo(persona);
                
                MessageBox.Show($"Persona {persona.Nombre} {persona.Apellidos} agregada al grafo exitosamente.\nEdad: {persona.Edad} años", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Limpiar formulario para agregar otra persona
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Program.LogException(ex);
                MessageBox.Show($"Error al agregar la persona: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCedula.Clear();
            picFoto.Image = null;
            fotoBytes = null;
            
            // Restablecer valores por defecto
            InicializarValoresPorDefecto();
            
            txtNombre.Focus();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual para volver al menú
            this.Close();
        }
    }
}
