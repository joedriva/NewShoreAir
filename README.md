# NewShoreAir

Para el correcto funcionamiento del api se debe tener en cuenta lo siguiente:

- En el archivo appsetting.json del api se debe modificar el source=xxx por la ruta de su servidor de base de datos.
- Debe crear en su servidor de base de datos, una base de datos vacia llamada NewShoreAir
- debe establecer como proyecto de inicio el proyecto NewShoreAir.API y seleccionar como proyecto predeterminado NewShoreAir.Infrastructure
  en la consola del administrador de paquetes y ejecutar el comando "update-database" con esto se creara la estructura de base de datos en su servidor

Despuestos de estos pasos el api quedara funcionando de forma correcta.

Para tener en cuenta:

- Parámetro NumberMaxFlight buscan viajes con un numero de vuelos igual o menor a este número, si se deja en 0 o null, no tendrá en cuenta este parámetro.
- Se implemento la opción de enviar un parámetro llamado NumberMaxFlight para controlar el numero máximo de vuelos para el viaje al momento de calcular y 
  de consultar en la base de datos, a esta implementación le hace falta más reglas de negocio, por ejemplo, si inicialmente solicito solo 2 vuelos máximo 
  por viaje, se realiza el cálculo y lo almacena en base de datos, cuando vuelvo a consultar para un número mayor de vuelos por ejemplo 4 realiza esta consulta
  en base de datos si para este viaje ya existen registros con un número menor al número máximo de vuelos trae esta información y no calcula si existen viajes
  con 3 o 4 vuelos para este ejemplo.

