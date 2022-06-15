# Creador de peers para Asterisk
[![N|Solid](https://www.programaenlinea.net/wp-content/uploads/2020/07/net-1.png)](https://docs.microsoft.com/en-us/dotnet/framework/get-started/)

___
Esta aplicación de consola fue creado en base a la oportunidad y/o necesidad de crear peers o extensiones telefonicas
para las pbx de forma agíl y sin errores, permitiendo crear un documento .CONF que luego puede ser extendido en 
el documento raiz de la pbx

___
## Ejecución
La aplicación es de ejecución unica, es decir se ejecuta y una vez, crea el documento, espera durante un rato y se cierra automaticamente, el paso a paso de la creación del documento es:

1. Crea el folder, en la ruta especificada en el App.config, si el folder existe omite este paso.
2. Solicita el nombre del documento.
3. Solicita el contexto de los peers
4. Solicita desde que extensión hasta que extensión se crearan los peers
5. Crea el documento en la carpeta y con el nombre asignado


`Recomendacion: `Por defecto la carpeta raiz es `C:/Peers_Sterisk`, se recomienda cambiar esta dirección, para cambiarlo se debe cambiar el valor de la `key  'Path_folder'` en el archivo `App.conf`

___

## Arquitectura

* Models 
  - NumbersPeer
    - la cual permite asignar los vales desde - hasta el cual se crearan los peers.
* Services
  - CreatePeers
    - Aquí recae la lógica de la app,contiene los métodos created, getNameDocument, getContext, getNumberPeers, createFolder y
       logError, los cuales son los encargador de desarrollar las funciones básicas y suficientes.

___

## Librerias

* ConfigurationManager - V 6.0.0
* AccessControl - V 6.0.0
* AccessControl - V 6.0.0
* AccessControl - V 6.0.0

___
### Version beta
### Autor [Italo Alberto Guevara Villamil - alberto.villamil.1997@gmail.com]