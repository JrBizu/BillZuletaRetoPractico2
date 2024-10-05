Reto Practico 02 - Desarrollar un Sistema de Logs en C# con Azure Cosmos DB

Se creo una aplicación, una API que permite la creación de logs, se utiliza una base de datos para almacenar los logs (CosmosDB en Azure).
Se Implementó un modelo de datos simple para los registros de los logs, campos: ID, Type(Information, Warining, Error), Description, CreatedDate(Momento en que se registra el log).
La API tiene 2 endpoints, una para Crear un nuevo log y el otro para Obtener una lista de todos los logs.
La aplicación se desarrolló con una arquitectura hexagonal.

