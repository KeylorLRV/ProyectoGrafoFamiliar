# Introducción
### Propósito del Proyecto
El Sistema de Grafo Genealógico es una aplicación de escritorio diseñada para gestionar y visualizar información familiar de manera integral. Este proyecto combina estructuras de datos avanzadas (grafos y árboles) con visualización geográfica, permitiendo no solo registrar el linaje familiar, sino también analizar la distribución geográfica de los miembros de la familia.
### Motivación
En la era digital, mantener un registro organizado de la historia familiar es fundamental. Este proyecto surge de la necesidad de:
- Preservar la memoria familiar: Documentar relaciones y fotografías.
- Visualizar conexiones: Entender las relaciones familiares de forma intuitiva.
- Análisis geográfico: Comprender cómo están distribuidos geográficamente los miembros de una familia.
- Educación: Aplicar conceptos de estructuras de datos en un contexto real y significativo.
### Conceptos Clave Implementados
#### Estructuras de Datos
##### Grafo Personalizado
- Implementación desde cero de un grafo dirigido
- Gestión de nodos (personas) y aristas (relaciones familiares)
- Métodos de recorrido (DFS con stack)
- Verificación de conectividad
##### Árbol Genealógico
- Estructura jerárquica de relaciones padre-hijo
- Navegación ascendente y descendente (abuelos, nietos)
- Validación de coherencia del linaje
#### Algoritmos
##### Cálculo de Distancias
- Fórmula de Haversine para distancias geodésicas
- Análisis de pares (más cercano, más lejano)
- Cálculo de promedios en grafos completos
##### Validaciones
- Coherencia temporal (padres mayores que hijos)
- Prevención de relaciones inválidas (auto-referencia, incesto)
- Validación de coordenadas geográficas
### Arquitectura General
El proyecto sigue una arquitectura de tres capas:
- Capa de **Datos** (Datos/): Modelos de dominio (Persona, Coordenada)
- Capa de **Lógica** (Logica/): Algoritmos y estructuras de datos (Grafo, Calculadora)
- Capa de **Presentación** (Presentacion/): Interfaces de usuario (Windows Forms)
 
Esta separación promueve:
- Mantenibilidad del código
- Reutilización de componentes
- Facilidad para pruebas unitarias
- Escalabilidad futura

### Funcionalidades Principales
#### 1. Gestión de Miembros

- Registro de información personal completa
- Carga de fotografías
- Asignación de coordenadas geográficas mediante mapa interactivo
- Cálculo automático de edad

#### 2. Relaciones Familiares

- Padre y madre biológicos
- Cónyuges con historial
- Hijos múltiples
- Hermanos (biológicos y agregados manualmente)

#### 3. Visualización Geográfica

- Mapa mundial interactivo
- Marcadores con información de cada persona
- Conexiones visuales entre familiares relacionados

#### 4. Análisis Estadístico

- Par de familiares más cercano geográficamente
- Par de familiares más lejano
- Distancia promedio entre todos los miembros
- Presentación visual de tarjetas con información

### Alcance del Proyecto
#### Incluido en esta versión

- Creación y gestión de un árbol genealógico único
- Información completa de cada miembro (foto, cédula, coordenadas, fechas)
- Grafo implementado desde cero
- Visualización en mapa mundial
- Estadísticas geográficas

#### Limitaciones Actuales

- Solo soporta un árbol genealógico a la vez
- No incluye persistencia de datos (guardado/carga)
- Requiere conexión a internet para cargar mapas

# Diagrama
### Diagrama de clases
![Diagrama de clases](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/e261491c38047506b2b3851bc0b286f197f564ed/docs/image/Grafo_Genealogico.drawio.png)  
[Haz click para descargar archivo .drawio](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/15e171c1297ee777f6fc7b2a670da2fbf189eab9/docs/Grafo_Genealogico.drawio)
#### Relaciones entre Clases

**1. Persona ↔ Coordenada** (Composición)

- Cada persona tiene exactamente una coordenada
- La coordenada no existe sin la persona

**2. Persona ↔ Persona** (Asociación)

- Relaciones familiares múltiples (padre, madre, cónyuge, hijos, hermanos)
- Bidireccionales y auto-referenciadas

**3. GrafoFamiliar → Persona** (Agregación)
 
- El grafo contiene múltiples personas
- Las personas pueden existir independientemente

**4. EstadisticasFamiliares → GrafoFamiliar + CalculadoraDistancia** (Dependencia)

- Usa ambas clases para generar análisis 

### Diagrama de arquitectura
![Diagrama de arquitectura](https://github.com/KeylorLRV/ProyectoGrafoFamiliar/blob/12ab56dcee809acf549b4df7c3e9ff5e7dcb244a/docs/image/DiagramaDeArquitectura.drawio.png)  
[Haz click para descargar archivo .drawio]()
