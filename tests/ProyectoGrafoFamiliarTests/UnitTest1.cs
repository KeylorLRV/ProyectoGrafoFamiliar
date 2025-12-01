using NUnit.Framework;
using ProyectoGrafoFamiliar.Datos;
using ProyectoGrafoFamiliar.Logica;
using System;
using System.Collections.Generic;

namespace ProyectoGrafoFamiliarTests
{
    // Suite de pruebas unitarias para el Sistema de Grafo Familiar
    // Total: 10 pruebas que cubren funcionalidades críticas
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        // TEST 1: Calcular edad correctamente
        [Test]
        [Category("Persona")]
        [Description("Verifica que la edad se calcula correctamente basándose en la fecha de nacimiento")]
        public void Test01_CalcularEdad_PersonaConFechaNacimiento_RetornaEdadCorrecta()
        {
            // Arrange
            var persona = new Persona
            {
                Nombre = "Juan",
                Apellidos = "Pérez",
                Cedula = "123456789",
                FechaNac = new DateTime(1990, 6, 15),
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            // Act
            var edad = persona.CalcularEdad();

            // Assert
            var edadEsperada = DateTime.Today.Year - 1990;
            if (DateTime.Today < new DateTime(DateTime.Today.Year, 6, 15))
                edadEsperada--;

            Assert.AreEqual(edadEsperada, edad, "La edad calculada no coincide con la esperada");
        }


        // TEST 2: Validar coordenadas válidas
        [Test]
        [Category("Coordenada")]
        [Description("Verifica que coordenadas dentro del rango válido retornen true")]
        public void Test02_EsValida_CoordenadasDentroDeRango_RetornaTrue()
        {
            // Arrange
            var coordenada = new Coordenada
            {
                Latitud = 9.935200,   // Costa Rica
                Longitud = -84.081500
            };

            // Act
            var resultado = coordenada.EsValida();

            // Assert
            Assert.IsTrue(resultado, "Las coordenadas válidas deberían retornar true");
        }


        // TEST 3: Validar coordenadas inválidas (latitud)
        [Test]
        [Category("Coordenada")]
        [Description("Verifica que latitud fuera de rango (-90 a 90) retorne false")]
        public void Test03_EsValida_LatitudFueraDeRango_RetornaFalse()
        {
            // Arrange
            var coordenada = new Coordenada
            {
                Latitud = 95,  // Mayor que 90 (inválido)
                Longitud = -84.08
            };

            // Act
            var resultado = coordenada.EsValida();

            // Assert
            Assert.IsFalse(resultado, "Latitud fuera de rango debería retornar false");
        }

        // TEST 4: Validar coordenadas inválidas (longitud)
        [Test]
        [Category("Coordenada")]
        [Description("Verifica que longitud fuera de rango (-180 a 180) retorne false")]
        public void Test04_EsValida_LongitudFueraDeRango_RetornaFalse()
        {
            // Arrange
            var coordenada = new Coordenada
            {
                Latitud = 9.93,
                Longitud = 200  // Mayor que 180 (inválido)
            };

            // Act
            var resultado = coordenada.EsValida();

            // Assert
            Assert.IsFalse(resultado, "Longitud fuera de rango debería retornar false");
        }


        // TEST 5: Establecer padre correctamente
        [Test]
        [Category("Persona")]
        [Description("Verifica que se puede establecer un padre válido y la relación es bidireccional")]
        public void Test05_EstablecerPadre_PadreValido_EstableceRelacionBidireccional()
        {
            // Arrange
            var padre = new Persona
            {
                Nombre = "Carlos",
                Apellidos = "Pérez",
                Cedula = "111111111",
                FechaNac = new DateTime(1970, 1, 1),
                Sexo = Persona.Genero.Masculino,
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            var hijo = new Persona
            {
                Nombre = "Juan",
                Apellidos = "Pérez",
                Cedula = "222222222",
                FechaNac = new DateTime(2000, 1, 1),
                Sexo = Persona.Genero.Masculino,
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            // Act
            hijo.EstablecerPadre(padre);

            // Assert
            Assert.AreEqual(padre, hijo.Padre, "El padre no se estableció correctamente");
            Assert.Contains(hijo, padre.Hijos, "El hijo no se agregó a la lista de hijos del padre");
        }


        // TEST 6: Rechazar padre más joven que hijo
        [Test]
        [Category("Persona")]
        [Description("Verifica que no se puede establecer un padre más joven que el hijo")]
        public void Test06_EstablecerPadre_PadreMenorQueHijo_LanzaExcepcion()
        {
            // Arrange
            var padreMenor = new Persona
            {
                Nombre = "Juan",
                Apellidos = "Pérez",
                Cedula = "111111111",
                FechaNac = new DateTime(2000, 1, 1),  // Más joven
                Sexo = Persona.Genero.Masculino,
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            var hijoMayor = new Persona
            {
                Nombre = "Carlos",
                Apellidos = "Pérez",
                Cedula = "222222222",
                FechaNac = new DateTime(1970, 1, 1),  // Más viejo
                Sexo = Persona.Genero.Masculino,
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => hijoMayor.EstablecerPadre(padreMenor));
            Assert.That(ex.Message, Does.Contain("mayor que el hijo"), "El mensaje de error no es el esperado");
        }


        // TEST 7: Establecer cónyuge correctamente
        [Test]
        [Category("Persona")]
        [Description("Verifica que se puede establecer un cónyuge y la relación es bidireccional")]
        public void Test07_EstablecerConyuge_PersonasNoEmparentadas_EstableceRelacionBidireccional()
        {
            // Arrange
            var persona1 = new Persona
            {
                Nombre = "María",
                Apellidos = "Rodríguez",
                Cedula = "111111111",
                FechaNac = new DateTime(1990, 1, 1),
                Sexo = Persona.Genero.Femenino,
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            var persona2 = new Persona
            {
                Nombre = "José",
                Apellidos = "Méndez",
                Cedula = "222222222",
                FechaNac = new DateTime(1988, 1, 1),
                Sexo = Persona.Genero.Masculino,
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            // Act
            persona1.EstablecerConyuge(persona2);

            // Assert
            Assert.AreEqual(persona2, persona1.Conyuge, "El cónyuge de persona1 no se estableció correctamente");
            Assert.AreEqual(persona1, persona2.Conyuge, "El cónyuge de persona2 no se estableció correctamente");
        }


        // TEST 8: Calcular distancia entre coordenadas
        [Test]
        [Category("CalculadoraDistancia")]
        [Description("Verifica que la fórmula de Haversine calcula distancias correctamente")]
        public void Test08_CalcularDistancia_CoordenadasDiferentes_RetornaDistanciaCorrecta()
        {
            // Arrange
            var calculadora = new CalculadoraDistancia();
            var sanJose = new Coordenada { Latitud = 9.9281, Longitud = -84.0907 };  // San José
            var cartago = new Coordenada { Latitud = 9.8636, Longitud = -83.9186 };  // Cartago

            // Act
            var distancia = calculadora.CalcularDistancia(sanJose, cartago);

            // Assert
            // La distancia real entre San José y Cartago es aproximadamente 20-25 km
            Assert.Greater(distancia, 15, "La distancia debería ser mayor a 15 km");
            Assert.Less(distancia, 30, "La distancia debería ser menor a 30 km");
        }

        // TEST 9: Agregar nodos al grafo
        [Test]
        [Category("GrafoFamiliar")]
        [Description("Verifica que se pueden agregar personas al grafo y no se duplican")]
        public void Test09_AgregarNodo_PersonaNueva_AumentaCantidadDeNodos()
        {
            // Arrange
            var grafo = new GrafoFamiliar();
            var persona1 = new Persona
            {
                Nombre = "Juan",
                Apellidos = "Pérez",
                Cedula = "123456789",
                FechaNac = new DateTime(1990, 1, 1),
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            var persona2 = new Persona
            {
                Nombre = "María",
                Apellidos = "Rodríguez",
                Cedula = "987654321",
                FechaNac = new DateTime(1992, 1, 1),
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 }
            };

            // Act
            grafo.AgregarNodo(persona1);
            grafo.AgregarNodo(persona2);
            grafo.AgregarNodo(persona1); // Intentar agregar duplicado

            // Assert
            Assert.AreEqual(2, grafo.Nodos.Count, "El grafo debería tener 2 nodos (sin duplicados)");
            Assert.Contains(persona1, grafo.Nodos, "Persona1 debería estar en el grafo");
            Assert.Contains(persona2, grafo.Nodos, "Persona2 debería estar en el grafo");
        }


        // TEST 10: Obtener abuelos correctamente
        [Test]
        [Category("Persona")]
        [Description("Verifica que se obtienen correctamente los 4 abuelos de una persona")]
        public void Test10_ObtenerAbuelos_PersonaConAbuelosCompletos_RetornaCuatroAbuelos()
        {
            // Arrange - Crear estructura familiar de 3 generaciones

            // Generación 1: Abuelos
            var abueloPaterno = CrearPersona("Abuelo", "Paterno", "111111111", 1940, Persona.Genero.Masculino);
            var abuelaPaterna = CrearPersona("Abuela", "Paterna", "111111112", 1942, Persona.Genero.Femenino);
            var abueloMaterno = CrearPersona("Abuelo", "Materno", "111111113", 1938, Persona.Genero.Masculino);
            var abuelaMaterna = CrearPersona("Abuela", "Materna", "111111114", 1940, Persona.Genero.Femenino);

            // Generación 2: Padres
            var padre = CrearPersona("Carlos", "Pérez", "222222221", 1970, Persona.Genero.Masculino);
            var madre = CrearPersona("Ana", "Castro", "222222222", 1972, Persona.Genero.Femenino);

            // Establecer relaciones generación 1 -> 2
            padre.EstablecerPadre(abueloPaterno);
            padre.EstablecerMadre(abuelaPaterna);
            madre.EstablecerPadre(abueloMaterno);
            madre.EstablecerMadre(abuelaMaterna);

            // Generación 3: Nieto
            var nieto = CrearPersona("Juan", "Pérez Castro", "333333331", 2000, Persona.Genero.Masculino);
            nieto.EstablecerPadre(padre);
            nieto.EstablecerMadre(madre);

            // Act
            var abuelos = nieto.ObtenerAbuelos();

            // Assert
            Assert.AreEqual(4, abuelos.Count, "Debería haber exactamente 4 abuelos");
            Assert.Contains(abueloPaterno, abuelos, "Debería incluir al abuelo paterno");
            Assert.Contains(abuelaPaterna, abuelos, "Debería incluir a la abuela paterna");
            Assert.Contains(abueloMaterno, abuelos, "Debería incluir al abuelo materno");
            Assert.Contains(abuelaMaterna, abuelos, "Debería incluir a la abuela materna");
        }

        // MÉTODOS AUXILIARES


        // Método helper para crear personas de forma más limpia en las pruebas
        private Persona CrearPersona(string nombre, string apellidos, string cedula, int añoNacimiento, Persona.Genero genero)
        {
            return new Persona
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Cedula = cedula,
                FechaNac = new DateTime(añoNacimiento, 1, 1),
                Sexo = genero,
                Coordenadas = new Coordenada { Latitud = 9.93, Longitud = -84.08 },
                Foto = new byte[] { 1, 2, 3 },
                EstaVivo = true
            };
        }
    }
}
