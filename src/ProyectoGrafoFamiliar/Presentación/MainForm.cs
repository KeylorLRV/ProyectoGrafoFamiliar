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
                ConfigurarMapa();
                
                this.grafo = grafo;
                this.calculadora = calculadora;
                
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
                
                InicializarValoresPorDefecto();
            }
            catch (Exception ex)
            {
                Program.LogException(ex);
                MessageBox.Show("Ocurrió un error al inicializar la ventana principal. Revise logs/startup.log para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void InicializarValoresPorDefecto()
        {
            // Establecer valores por defecto para coordenadas
            numLatitud.Value = 9.935M;
            numLongitud.Value = -84.081M;
            
            // Establecer fecha de nacimiento por defecto
            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-30);

            // Establecer valor por defecto para género
            cmbGenero.SelectedIndex = 2; // "Otro" por defecto

            fotoBytes = null;
            cmbPadre.Items.Clear();
            cmbMadre.Items.Clear();
            cmbConyuge.Items.Clear();
            lstHijos.Items.Clear();
            lstHermanos.Items.Clear();
            
            foreach (var persona in grafo.Nodos)
            {
                if (persona.Sexo == Persona.Genero.Masculino)
                    cmbPadre.Items.Add(persona);
                if (persona.Sexo == Persona.Genero.Femenino)
                    cmbMadre.Items.Add(persona);
                cmbConyuge.Items.Add(persona);
                lstHijos.Items.Add(persona);
                cmbPadre.Items.Add(persona);
                cmbMadre.Items.Add(persona);
                lstHermanos.Items.Add(persona);
            }
            
            // Establecer DisplayMember para mostrar nombre completo
            cmbPadre.DisplayMember = "NombreCompleto";
            cmbMadre.DisplayMember = "NombreCompleto";
            cmbConyuge.DisplayMember = "NombreCompleto";
            lstHijos.DisplayMember = "NombreCompleto";
            lstHermanos.DisplayMember = "NombreCompleto";

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

                if (cmbGenero.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione el género.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbGenero.Focus();
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
                    Foto = fotoBytes,
                    Sexo = (Persona.Genero)cmbGenero.SelectedIndex
                }; 

                // Validar datos de la persona
                if (!persona.ValidarDatos())
                {
                    MessageBox.Show("Los datos ingresados no son válidos. Por favor, verifique todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar persona al grafo
                grafo.AgregarNodo(persona);
                try
                {
                    // Aplicar padre
                    if (cmbPadre.SelectedItem is Persona padre)
                    {
                        persona.EstablecerPadre(padre);
                        grafo.AgregarConexion(persona, padre);
                    }
                    
                    // Aplicar madre
                    if (cmbMadre.SelectedItem is Persona madre)
                    {
                        persona.EstablecerMadre(madre);
                        grafo.AgregarConexion(persona, madre);
                    }
                    
                    // Aplicar cónyuge
                    if (cmbConyuge.SelectedItem is Persona conyuge)
                    {
                        persona.EstablecerConyuge(conyuge);
                        grafo.AgregarConexion(persona, conyuge);
                    }
                    
                    // Aplicar hijos
                    foreach (var item in lstHijos.SelectedItems)
                    {
                        if (item is Persona hijo)
                        {
                            persona.AgregarHijo(hijo);
                            grafo.AgregarConexion(persona, hijo);
                        }
                    }
                    // Aplicar hermanos
                    foreach (var item in lstHermanos.SelectedItems)
                    {
                        if (item is Persona hermano)
                        {
                            persona.EstablecerHermano(hermano);
                            grafo.AgregarConexion(persona, hermano);
                        }
                    }
                    
                    MessageBox.Show($"Persona {persona.Nombre} {persona.Apellidos} agregada con relaciones.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    // Remover la persona del grafo si hay error en relaciones
                    Program.LogException(ex);
                    MessageBox.Show($"Error al agregar persona o relaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
                MessageBox.Show($"Persona {persona.Nombre} {persona.Apellidos} agregada. Ahora aplica relaciones.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cmbGenero.SelectedIndex = 2;
            // Limpiar selecciones de relaciones
            cmbPadre.SelectedIndex = -1;
            cmbMadre.SelectedIndex = -1;
            cmbConyuge.SelectedIndex = -1;
            lstHijos.ClearSelected();
            lstHermanos.ClearSelected();
            InicializarValoresPorDefecto();
            
            txtNombre.Focus();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual para volver al menú
            this.Close();
        }
        private void ConfigurarMapa()
        {
            MapaControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            MapaControl.Position = new PointLatLng(9.748917, -83.753428); // Centro en Costa Rica
            MapaControl.MinZoom = 2;
            MapaControl.MaxZoom = 18;
            MapaControl.Zoom = 7;
            MapaControl.DragButton = MouseButtons.Left;
            MapaControl.CanDragMap = true;
            MapaControl.MouseWheelZoomEnabled = true;
            MapaControl.ShowCenter = false;
            
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            try
            {
                MapaControl.Manager.Mode = AccessMode.ServerAndCache;
                MapaControl.Position = new PointLatLng(9.748917, -83.753428);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el mapa: " + ex.Message);
            }
            
            MapaControl.MouseClick += MapaControl_MouseClick;
        }
        private void MapaControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Obtener las coordenadas del punto clickeado
                var punto = MapaControl.FromLocalToLatLng(e.X, e.Y);
                numLatitud.Value = (decimal)punto.Lat;
                numLongitud.Value = (decimal)punto.Lng;
                
                MessageBox.Show($"Coordenadas seleccionadas: Lat {punto.Lat:F6}, Lng {punto.Lng:F6}");
            }
        }
        
    }
}
