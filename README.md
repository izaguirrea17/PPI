Aclaraciones y consideraciones para la resolución del ejercicio:

- La arquitectura de la aplicación y el diagrama de base de datos se puede ver en el siguiente link
  https://docs.google.com/document/d/14sbacZWKeUDFi8bSFrCO4iL-qdC1E6akQkWwfnXRegY/edit?usp=sharing
- En la clase program, en la linea 10 se configura el repositorio, en este caso SqlRepositorio que
  apunta a una base de datos de SQL Server, acá con un simple cambio se puede configurar el repositorio
  que se quiera usar.
- Para ejecutar los tests, setear en la clase program la linea 11 para usar el FakeRepositorio, tiene datos mockeados para probar la aplicación.
- Para usar la aplicación, setear en la clase program para usar SqlRepositorio, adjunto script para crear la base de datos.
- Se aplicó el patrón DTO, por eso se agregaron clases Data Transfer Object, para adaptar las solicitudes y respuestas de la
  aplicación para cada caso, por ejemplo, según la minuta lo único que puede modificarse de una orden existente es el estado,
  por eso el OrdenActualizarDto tiene solo idorden y estado, para que el usuario envíe solo esos datos, y se devuelve el objeto
  OrdenDto ya que puede ser de interes ver el nombre del activo asociado a la orden, en lugar de IDActivo.
- Asumí que no se agregarían mas tipos de activos, estados de ordenes o comisiones en un futuro cercano, por eso están en enums,
  si se supiera que se agregarían mas activos o mas estados de ordenes con frecuencia, esta decisión tendría que revisarse, así
  como el switch en el método de controlador CrearOrden, porque no sería una buena práctica.
- No creí necesario hacer que las clases accion, bono, y fci hereden de la clase activo, preferí usarlas para que ellas sean las
  encargadas de calcular el monto total en base a las reglas de negocio de cada uno de los tipos con métodos de clase, y así separar
  esa funcionalidad. Si hubiera hecho que hereden de activo, seguramente hubiera tenido que crear un método CalcularMontoTotal en la
  clase Activo para que lo hereden y sobreescriban su implementación, pero entonces la clase Activo tendría un método que no va a usar,
  esto no es una buena práctica según principios SOLID.
- El controller se comunica con el repositorio y este con la fuente de datos, si hubiera sido una aplicación más grande, con muchos
  métodos que recolecten datos, se podría haber creado una clase Servicios que esté entre el controller y el repositorio, no lo hice
  esta vez por ser una aplicación muy pequeña.
- Usé entityFramwork para recolectar los datos de la base de datos, al igual que en el item anterior, si la aplicación hubiera manejado
  grandes volumenes de datos, por ejemplo, una tabla con millones de registros de ordenes, hubieramos tenido que hacer llamadas a procedimientos
  de SQL para que traigan los datos filtrados, porque sino, de la manera que se está haciendo ahora, al usar linkQ por ejemplo en una instrucción
  y hacer _context.Ordenes, nos estamos trayendo todos los datos de la tabla a memoria y afectaría el rendimiento de la aplicación.
- Se devuelven respuestas de tipo Ok o BadRequest para que ya incluyan los statuscode.
- En el archivo appsettings.json esta la cadena de conexión por si necesitan cambiarla
- Adjunto el script de la base de datos en la solución

  Cualquier consulta o duda por favor escribanme a izaguirrea17@gmail.com


La solución cumple con todas las funcionalidades requeridas.

El diseño y la arquitectura son aceptables, pero podrían mejorarse.

Se podría haber aplicado Restful para el naming de los endpoint.

Se debería haber generado la clase de servicio más allá del tamaño de la aplicación.

El esquema de base de datos es aceptable, pero presenta algunas deficiencias menores.

Se observa un uso limitado de patrones de diseño.

El código es claro, organizado y sigue buenas prácticas de desarrollo en C#/.NET Core.
