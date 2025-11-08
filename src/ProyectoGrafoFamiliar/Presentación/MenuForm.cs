using System;
using System.Windows.Forms;
using ProyectoGrafoFamiliar.Datos;
using ProyectoGrafoFamiliar.Logica;

namespace ProyectoGrafoFamiliar.Presentacion
{
    public partial class MenuForm : Form
    {
        // Instancias compartidas para mantener estado entre formularios
        private GrafoFamiliar grafo;
        private CalculadoraDistancia calculadora;
        private EstadisticasFamiliares estadisticas;

        public MenuForm()
        {
            InitializeComponent();
            grafo = new GrafoFamiliar();
            calculadora = new CalculadoraDistancia();
            estadisticas = new EstadisticasFamiliares(grafo, calculadora);
        }

        private void BtnAgregarPersona_Click(object sender, EventArgs e)
        {
            // Abre MainForm para agregar persona (pasa el grafo para compartir estado)
            using (var agregarForm = new MainForm(grafo, calculadora))
            {
                agregarForm.ShowDialog(); // Modal: bloquea el menú hasta cerrar
            }
        }

        private void BtnVisualizarGrafo_Click(object sender, EventArgs e)
        {
            // Abre un nuevo formulario para visualizar el grafo en mapa con conexiones
            using (var visualizarForm = new VisualizarGrafoForm(grafo, calculadora))
            {
                visualizarForm.ShowDialog();
            }
        }

        private void BtnVisualizarEstadisticas_Click(object sender, EventArgs e)
        {
            // Abre un formulario para mostrar estadísticas
            using (var estadisticasForm = new EstadisticasForm(estadisticas))
            {
                estadisticasForm.ShowDialog();
            }
        }
    }
}