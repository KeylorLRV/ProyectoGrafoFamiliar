# Manual de Usuario
Esta guía le ayudará a utilizar todas las funcionalidades de la aplicación.
## Requisitos del Sistema
**Requisitos Mínimos**
- Sistema Operativo: Windows 7 o superior
- Framework: .NET Framework 4.7.2 o superior
- RAM: 2 GB mínimo
- Disco: 100 MB de espacio libre
- Conexión a Internet: Requerida para visualización de mapas
- 
**Software Necesario**
- Visual Studio 2019 o superior (para desarrollo)
- Paquetes NuGet:

  > GMap.NET.Windows  
  > System.Drawing

## Inicio de la Aplicación
Al ejecutar la aplicación, aparecerá el Menú Principal:  
![Imagen de Menu principal](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/1a552f7e056cf33e63dddaf9634004a6d31d6e1f/docs/image/ImagenMenuPrincipal.png)  
El menú principal presenta tres opciones principales:  
**1. Agregar Persona al Grafo**
- Abre el formulario para registrar nuevos miembros
- Permite establecer relaciones familiares

**2. Visualizar Grafo en Mapa**
- Muestra todos los miembros en un mapa interactivo
- Visualiza las conexiones entre familiares

**3. Visualizar Estadísticas Familiares**
- Presenta análisis de distancias geográficas
- Muestra pares extremos y promedios

## Agregar Personas
**Paso 1:** Abrir el Formulario  
Desde el menú principal, click en **"Agregar Persona al Grafo"**.
![ImageDePrimerOpcion](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/1a552f7e056cf33e63dddaf9634004a6d31d6e1f/docs/image/ImagePrimerOpcion.png)  
![ImageDeVentanaAgregar](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/1a552f7e056cf33e63dddaf9634004a6d31d6e1f/docs/image/ImagenDeVentanaAgregarPersona.png)  

**Paso 2: Ingresar Datos Básicos**  
Complete los siguientes campos obligatorios:  
**Información Personal**  
Nombre:
- Campo de texto libre
- No puede estar vacío
- Ejemplo: "Juan"

Apellidos:
- Campo de texto libre
- No puede estar vacío
- Ejemplo: "Pérez González"

Cédula:
- Identificación única
- No puede estar vacía
- Formato sugerido: números sin espacios
- Ejemplo: "123456789"

Fecha de Nacimiento:
- Use el selector de fecha (DateTimePicker)
- Click en el calendario para seleccionar
- La edad se calcula automáticamente
- Restricción: No puede ser una fecha futuro.
- Ejemplo:
> Fecha seleccionada: 15/03/1990  
> Edad calculada: 35 años (aproximadamente)

**Paso 3: Seleccionar Ubicación Geográfica**

**Opción A:** Usando el Mapa Interactivo

![ImagenUbicacion](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/4dd506f666a07d82b437d6c2b6acc2bf07de5a90/docs/image/UsandoMapaInteractivo.png)
1. Localice el mapa en la parte derecha del formulario 

2. Navegue usando:
- Arrastrar con el mouse (botón izquierdo presionado)
- Zoom con la rueda del mouse

3. Click en el punto exacto donde reside la persona

4. Confirmación: Aparecerá un mensaje con las coordenadas seleccionadas
![Res](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/4dd506f666a07d82b437d6c2b6acc2bf07de5a90/docs/image/ResultadoDeUsarMapaInteractivo.png)

**Opción B:** Ingreso Manual

Si conoce las coordenadas exactas:

![UbicacionManual](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/4dd506f666a07d82b437d6c2b6acc2bf07de5a90/docs/image/UbicacionManual.png)

Latitud:
- Rango válido: -90 a 90
- 6 decimales de precisión
- Ejemplo: 9.935200 (Costa Rica)

Longitud:
- Rango válido: -180 a 180
- 6 decimales de precisión
- Ejemplo: -84.081500 (Costa Rica)

**Paso 4:** Cargar Fotografía

![Foto](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/5912742ea91f7a03c1ec7ac45c414df3b93d5266/docs/image/Foto.png)

- Click en el botón "Cargar..." junto al espacio de foto

- Seleccione una imagen desde su computadora

- Formatos aceptados: JPG/JPEG PNG BMP 

Recomendaciones:
- Use fotos de rostro frontal
- Imagen clara y bien iluminada
- Tamaño recomendado: 300x300 píxeles o mayor
- Evite imágenes borrosas o muy grandes

**Paso 5:** Establecer Relaciones Familiares

![Relacion](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/ed2f5bccf9851cf580808aeefc9edd2198eaad0e/docs/image/Relacion.png)

**Padre** (Opcional)

Seleccione del menú desplegable si aplica

Validaciones automáticas:
- El padre debe ser mayor que la persona
- No puede ser la misma persona
- No puede ser un descendiente

**Madre** (Opcional)

Seleccione del menú desplegable si aplica

Validaciones automáticas:
- La madre debe ser mayor que la persona
- No puede ser la misma persona
- No puede ser una descendiente



**Cónyuge** (Opcional)

Seleccione del menú desplegable si aplica
Aparecen todas las personas registradas

Validaciones automáticas:
- No puede ser un pariente directo (padre, madre, hijo, hermano)
- No puede ser la misma persona
- Si ya tiene cónyuge, se establece "divorcio implícito"

Nota: La relación de cónyuge es bidireccional automáticamente.

**Hijos** (Opcional)

Seleccione múltiples hijos de la lista

Use Ctrl + Click para selección múltiple

Validaciones automáticas:
- Los hijos deben ser menores que la persona
- Se establece como padre o madre según el género
- Se agregan a la lista de hijos del cónyuge (si existe)

**Hermanos** (Opcional)

Seleccione múltiples hermanos de la lista

Use Ctrl + Click para selección múltiple

Validaciones automáticas:
- No puede ser la misma persona
- No puede ser un pariente directo (padre, hijo)
- La relación es bidireccional automática
