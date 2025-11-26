# Introducción
### Propósito del Proyecto
El Sistema de Árbol Genealógico es una aplicación de escritorio diseñada para gestionar y visualizar información familiar de manera integral. Este proyecto combina estructuras de datos avanzadas (grafos y árboles) con visualización geográfica, permitiendo no solo registrar el linaje familiar, sino también analizar la distribución geográfica de los miembros de la familia.
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
