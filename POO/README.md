# Principios

## Clase

- Es un molde o plantilla que define cómo serán los objetos.
- Contiene:
  - Atributos (propiedades, campos): describen el estado (ej. nombre, edad).
  - Métodos (funciones): definen el comportamiento (ej. caminar, comer).
- Por sí sola no ocupa memoria (es una definición).

## Objeto

- Es una instancia concreta de una clase.
- Representa un ente real o conceptual con un estado específico.
- Sí ocupa memoria porque tiene valores propios en sus atributos.

Analogía simple: la clase es como el plano de una casa, mientras que el objeto es la casa construida a partir de ese plano.

Ejemplo:
```csharp
Persona p1 = new Persona();
p1.Nombre = "Juan";
p1.Edad = 30;
p1.Saludar(); // "Hola, me llamo Juan"
```

# Los 4 fundamentos de la programación orientada a objetos:

## Abstracción

**A grendes rasgos, es el principio que permite definir comportamientos comunes sin necesidad de implementar los detalles; nos centramos en qué hace un objeto, no en cómo lo hace.** Este principio dice que la POO busca modelar los objetos, busca abstraerse y simplificar un objeto de la vida real a solo un par de atributos. En otras palabras, buscaremos transformar un objeto de la vida real en atributos (características) y sus acciones (métodos). Consiste en encontrar las partes fundamentales de un sistema para describirlas de manera simple y precisa.

Formas de implementarla en C#:

- Clases abstractas
  - Se declaran con abstract.
  - Pueden tener métodos con implementación y métodos abstractos (sin cuerpo).
  - No se pueden instanciar directamente.

```csharp
abstract class Figura {
    public abstract double CalcularArea(); // obliga a implementarlo
}

class Circulo : Figura {
    public double Radio { get; set; }
    public override double CalcularArea() => Math.PI * Radio * Radio;
}
```

- Interfaces
  - Se declaran con interface.
  - Solo definen la firma de métodos y propiedades.
  - Una clase puede implementar varias interfaces (multiplicidad).

```csharp
interface IImprimible {
    void Imprimir();
}

class Documento : IImprimible {
    public void Imprimir() {
        Console.WriteLine("Imprimiendo documento...");
    }
}
```

## Encapsulamiento

Es la cualidad de los objetos de ocultar los detalles de implementación y su estado interno del mundo exterior. Es decir, establece que los detalles internos de un objeto deben estar protegidos y que el acceso a sus datos debe hacerse solo mediante métodos o propiedades controladas.

Características:
* Esconde detalles de implementación.
* Protege el estado interno de los objetos.
* Un objeto sólo muestra su "cara visible" por medio de su protocolo.
* Los métodos y su estado quedan escondidos para cualquier otro objeto. Es el objeto quien decide qué se publica.
* Facilita modularidad y reutilización.

Ésto se logra, usando los modificadores de acceso:
- public → accesible desde cualquier lugar.
- private → accesible solo dentro de la clase.
- protected → accesible dentro de la clase y clases derivadas.
- internal → accesible dentro del mismo ensamblado.
- private protected → permite el acceso desde clases derivadas (como protected), pero únicamente si esas derivadas están en el mismo ensamblado (en protected, pueden estar en otro ensamblado).
- protected internal → es accesible:
  - desde cualquier clase del mismo ensamblado (como si fuera internal).
  - desde clases derivadas, aunque estén en otro ensamblado (como si fuera protected).

Más fácil de recordar:
- protected internal = más abierto → unión de permisos entre protected + internal.
- private protected = más restringido → intersección de permisos entre protected + internal.

## Herencia

Es el mecanismo por el cual las subclases (hija o derivada) reutilicen las propiedades y métodos de sus superclases (padre o base). En otras palabras, permite que una clase pueda servir como plantilla para la creación de futuras clases.

La herencia permite:
* Crear una nueva clase como refinamiento de otra.
* Diseñar e implementar sólo la diferencia que presenta la nueva clase.
* Abstraer las similitudes en común, evitando la **duplicación de código y fomentando la reutilización**.

Características en C#:
* Se usa la palabra clave : para indicar herencia.
* Soporta herencia simple (una sola clase padre).
* Se puede sobrescribir métodos de la clase base con virtual y override.

## Polimorfismo

Es la capacidad de que un mismo método o interfaz tenga múltiples implementaciones, de modo que una llamada al método ejecute el comportamiento correcto según el tipo real del objeto en tiempo de ejecución. **En líneas generales, el polimorfismo permite que distintas clases respondan de manera diferente a un mismo mensaje o método.**

Tipos en C#:

- Polimorfismo en tiempo de compilación (estático / overloading): mismo método con distinta firma (número o tipo de parámetros).
Ejemplo:
```csharp
class Calculadora {
    public int Sumar(int a, int b) => a + b;
    public double Sumar(double a, double b) => a + b;
}
```

- Polimorfismo en tiempo de ejecución (dinámico / overriding): una clase derivada redefine un método de la base.
Ejemplo:
```csharp
class Animal {
    public virtual void HacerSonido() {
        Console.WriteLine("Sonido genérico");
    }
}

class Perro : Animal {
    public override void HacerSonido() {
        Console.WriteLine("Guau guau");
    }
}
```

# Cohesión y acoplamiento

**La cohesión** es el grado en que los elementos de un módulo o clase trabajan juntos hacia un mismo propósito. Una clase tiene alta cohesión si todos sus métodos y atributos están claramente relacionados entre sí y contribuyen a una única responsabilidad. Existen distintos grados de cohesión (cohesión lógica, funcional, secuencial, etc.), y que lo más deseable es la cohesión funcional: que todos los métodos de una clase contribuyan a un único propósito.

**El acoplamiento** es el grado en que los módulos de un programa dependen unos de otros. Si para hacer cambios en un módulo del programa es necesario hacer cambios en otro módulo distinto, existe acoplamiento entre ambos módulos. Los tipos más comunes de acoplamiento son:
- Acoplamiento fuerte: cuando una clase conoce demasiado de otra.
- Acoplamiento débil: cuando se relacionan solo a través de contratos, ej. interfaces.
En .NET muchas veces se reduce el acoplamiento usando inyección de dependencias (DI).

**En líneas generales, lo ideal es tener bajo acoplamiento (módulos independientes que se comunican a través de interfaces o contratos) y alta cohesión (clases enfocadas y claras).**

Ejemplo:
```csharp
// Alta cohesión, bajo acoplamiento
class RepositorioClientes {
    private readonly IConexionBD _conexion;

    public RepositorioClientes(IConexionBD conexion) {
        _conexion = conexion;
    }

    public Cliente ObtenerPorId(int id) {
        return _conexion.Query<Cliente>($"SELECT * FROM Clientes WHERE Id={id}");
    }
}
```
- La clase tiene alta cohesión (solo se ocupa de clientes)
- Tiene bajo acoplamiento (usa una interfaz para la BD, no una implementación fija).

# Diseño y buenas prácticas

## Diferencias entre clase abstracta e interfaz:

- Similitud: ambas no pueden instanciarse directamente; deben usarse mediante clases derivadas (abstracta) o implementadoras (interfaz).
- Clases abstractas:
  - Pueden tener métodos abstractos (sin implementación) y concretos (con implementación).
  - Pueden contener constructores, campos, propiedades y métodos.
  - Solo se puede heredar de una clase (herencia simple). Una clase puede heredar sólo de una clase.
- Interfaces:
  - Definen contratos que una clase debe implementar.
  - Pueden heredar de múltiples interfaces (soporte para herencia múltiple).
  - Tradicionalmente no podían tener implementación, pero desde C# 8+ pueden incluir métodos con implementación por defecto, métodos estáticos y miembros privados.
- Una clase abstracta puede heredar o extender cualquier clase (independientemente de que esta sea abstracta o no), mientras que una interfaz solamente puede extender o implementar otras interfaces.
- Los métodos de una interfaz son públicos y abstractos, por lo que no hace falta especificar public ni abstract. Hasta C# 7, no se permitía agregar modificadores de acceso ni implementación en los métodos. Desde C# 8 en adelante, las interfaces pueden contener:
  - Métodos con implementación (llamados default interface methods).
  - Métodos privados, protegidos o internos dentro de la interfaz (solo para ser usados en la misma).
  - Métodos estáticos y miembros estáticos (desde C# 11).
- Resumen práctico:
  - Usa clases abstractas cuando quieras compartir código base + contrato.
  - Usa interfaces cuando quieras solo definir un contrato común entre clases, sin importar jerarquías.

Ejemplo de implementaciones por defecto:
```csharp
public interface ILog {
    void Log(string message); // abstracto

    // Implementación por defecto (desde C# 8+)
    void LogError(string message) {
        Log($"ERROR: {message}");
    }
}
```

## Clases y métodos sealed

- Una clase sealed (sellada) no puede usarse como clase base.
- Las clases selladas impiden la herencia.
- Esto anula el aspecto virtual de los miembros para cualquier clase derivada adicional.

## Virtual vs Abstract

- Los métodos abstractos no contienen código y las subclases deben sobrescribirlos.
- Los métodos virtuales sí pueden contener código (normalmente una implementación por defecto), y las subclases pueden sobrescribirlos usando el modificador override para dar una implementación personalizada.

## SOLID

- S: Single Responsibility Principle (SRP): una clase debe tener una única responsabilidad y, por lo tanto, una sola razón para cambiar. **Ejemplo:** una clase Factura debe encargarse de manejar datos de facturación, pero no de guardar facturas en la base de datos (eso sería tarea de un repositorio).
- O: Open-Closed Principle (OCP): el software debe estar abierto a la extensión pero cerrado a la modificación. Es decir, se puede agregar nuevas funcionalidades sin tener que modificar el código existente. **Ejemplo:** usar herencia o interfaces para extender comportamiento en lugar de editar la clase base directamente.
- L: Liskov Substitution Principle (LSP): los objetos de una superclase deben poder ser sustituidos por objetos de sus subclases sin alterar el correcto funcionamiento del programa. Es decir, que una subclase debe respetar el contrato de la clase base. **Ejemplo:** si Ave tiene un método Volar(), una subclase Pinguino no debería heredar de Ave porque rompería el contrato (los pingüinos no vuelan).
- I: Interface Segregation Principle (ISP): es mejor crear interfaces específicas y pequeñas en lugar de una interfaz grande y genérica. Es decir, los clientes no deben verse obligados a depender de métodos que no necesitan. **Ejemplo:** en vez de tener una interfaz IMultifuncional con Imprimir(), Escanear(), Fax(), Copiar(), es mejor separar en IImpresora, IEscaner, etc., de modo que cada clase implemente solo lo que realmente usa.
- D: Dependency Inversion Principle (DIP): el código debe depender de abstracciones (interfaces), no de implementaciones concretas. En este principio hay dos reglas:
  - Los módulos de alto nivel no deben depender de módulos de bajo nivel. (relación de conocimiento con abstracciones)
  - Las abstracciones no deben depender de los detalles, sino que los detalles deben depender de las abstracciones. (implementar una interfase o clase abstracta)
**Ejemplo:** en lugar de que una clase ServicioPedidos cree directamente un RepositorioPedidosSql, debe depender de una interfaz IRepositorioPedidos, y que el detalle concreto (RepositorioPedidosSql, RepositorioPedidosOracle, etc.) se inyecte externamente.

S: Una clase = una responsabilidad.
O: Extender, no modificar.
L: Las subclases deben cumplir lo prometido por la superclase.
I: Interfaces pequeñas y específicas.
D: Depender de abstracciones, no de implementaciones.

## Inyección por dependencias

La Inyección de Dependencias (DI) es un mecanismo que busca reducir el acoplamiento entre clases.

En lugar de que una clase cree directamente sus dependencias (por ejemplo, new ServicioConcreto()), se hace que estas le sean inyectadas desde el exterior, normalmente a través de interfaces.

Esto ayuda a:
- Cumplir el Principio de Inversión de Dependencias (DIP) de SOLID.
- Mantener clases con una sola responsabilidad.
- Poder cambiar una implementación por otra sin modificar el código que la usa (ej. RepositorioSql ↔ RepositorioOracle)

### Inversión de Control (IoC)

La DI se apoya en el concepto de Inversión de Control (IoC):
- Tradicionalmente, una clase controla qué dependencias crea y usa.
- Con IoC, ese control se invierte: es el contenedor (framework, configuración o factoría) el que provee la implementación adecuada.

### Tipos de Inyección de Dependencias

1. Por constructor (la más usada en .NET Core):
```csharp
public class PedidoService {
    private readonly IRepositorioPedidos _repo;

    public PedidoService(IRepositorioPedidos repo) {
        _repo = repo;
    }
}
```

2. Por propiedad (setter injection):
```csharp
public class PedidoService {
    public IRepositorioPedidos Repo { get; set; }
}
```

3. Por método (method injection):
```csharp
public class PedidoService {
    public void Procesar(IRepositorioPedidos repo) {
        repo.Guardar();
    }
}
```

### Dependency Injection en .NET Core

En ASP.NET Core, la DI está integrada de forma nativa a través de la librería Microsoft.Extensions.DependencyInjection.
La configuración se realiza en Program.cs o en Startup.ConfigureServices:

```csharp
// Registro en el contenedor de servicios
services.AddScoped<IRepositorioPedidos, RepositorioPedidosSql>();
```

Luego, cualquier clase que requiera IRepositorioPedidos recibirá automáticamente la implementación registrada:

```csharp
public class PedidoController : ControllerBase {
    private readonly IRepositorioPedidos _repo;

    public PedidoController(IRepositorioPedidos repo) {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult CrearPedido(Pedido pedido) {
        _repo.Guardar(pedido);
        return Ok();
    }
}
```

### Ciclo de vida de los servicios

Al registrar dependencias, se debe indicar el lifetime del objeto:
- Transient: se crea una instancia nueva cada vez que se solicita.
- Scoped: se crea una instancia por cada request HTTP.
- Singleton: se crea una sola instancia para toda la aplicación.

### Ventajas de DI

- Bajo acoplamiento y mayor cohesión.
- Facilidad para sustituir implementaciones (ej. cambiar repositorio SQL por repositorio en memoria).
- Facilita las pruebas unitarias mediante mocks o stubs.
- Favorece la extensibilidad y el mantenimiento.

### Riesgos si se abusa:

- Clases con demasiadas dependencias inyectadas (mal diseño).
- Selección incorrecta del ciclo de vida → problemas de rendimiento o concurrencia.

En resumen, la Inyección de Dependencias en .NET Core es la implementación práctica del principio DIP de SOLID:
- Los módulos de alto nivel dependen de abstracciones.
- Las implementaciones concretas (detalles) dependen de esas abstracciones.

### Resumen

La Inyección de Dependencias (DI) es un patrón que permite reducir el acoplamiento entre clases haciendo que dependan de abstracciones y no de implementaciones concretas. En lugar de crear sus dependencias, las reciben desde afuera (IoC).

En .NET Core está integrada con Microsoft.Extensions.DependencyInjection y se configura en Program.cs o Startup.

Existen tres formas de inyección: por constructor (la más común), por propiedad y por método.

Los servicios se registran con un ciclo de vida: Transient, Scoped o Singleton.

En resumen: la DI es la aplicación práctica del Principio de Inversión de Dependencias (DIP) de SOLID.

## Patrones de diseño básicos en .NET

### Factory

**Qué es:** Un patrón creacional que encapsula la lógica de creación de objetos.  
**Cuándo usarlo:** Cuando queremos delegar la responsabilidad de instanciar objetos y no acoplar nuestro código a `new`.  

``` csharp
public interface ITransporte {
    void Enviar();
}

public class Avion : ITransporte {
    public void Enviar() => Console.WriteLine("Envío por avión");
}

public class Barco : ITransporte {
    public void Enviar() => Console.WriteLine("Envío por barco");
}

public static class TransporteFactory {
    public static ITransporte Crear(string tipo) =>
        tipo switch {
            "avion" => new Avion(),
            "barco" => new Barco(),
            _ => throw new ArgumentException("Tipo inválido")
        };
}
```

### Singleton

**Qué es:** Un patrón creacional que asegura que **solo exista una instancia** de una clase en toda la aplicación.  
**Cuándo usarlo:** Cuando se necesita un único punto de acceso global, como configuración, cache, logger.  

``` csharp
public sealed class Logger {
    private static readonly Logger _instancia = new Logger();
    public static Logger Instancia => _instancia;
    private Logger() { }
    public void Log(string msg) => Console.WriteLine(msg);
}
```

### Strategy

**Qué es:** Un patrón de comportamiento que define una **familia de algoritmos** y permite intercambiarlos en tiempo de ejecución.  
**Cuándo usarlo:** Cuando querés cambiar dinámicamente cómo se hace una operación sin modificar el cliente.  

``` csharp
public interface ICalculoImpuesto {
    decimal Calcular(decimal monto);
}

public class IVA : ICalculoImpuesto {
    public decimal Calcular(decimal monto) => monto * 0.21m;
}

public class Ganancias : ICalculoImpuesto {
    public decimal Calcular(decimal monto) => monto * 0.35m;
}

public class Factura {
    private readonly ICalculoImpuesto _estrategia;
    public Factura(ICalculoImpuesto estrategia) {
        _estrategia = estrategia;
    }
    public decimal CalcularTotal(decimal monto) => monto + _estrategia.Calcular(monto);
}
```

### Repository

**Qué es:** Un patrón estructural que abstrae el acceso a datos. Actúa como un **intermediario entre la aplicación y la capa de persistencia**.  
**Cuándo usarlo:** Para aislar la lógica de negocio de la lógica de acceso a datos.  

``` csharp
public interface IClienteRepository {
    Cliente ObtenerPorId(int id);
    void Agregar(Cliente cliente);
}

public class ClienteRepositorySql : IClienteRepository {
    public Cliente ObtenerPorId(int id) {
        // Lógica SQL
        return new Cliente { Id = id, Nombre = "Juan" };
    }
    public void Agregar(Cliente cliente) {
        // Insert SQL
    }
}
```

### Dependency Injection (DI) - Lo vimos previamente

**Qué es:** Un patrón que implementa la **Inversión de Dependencias (DIP)** de SOLID. Las clases no crean sus dependencias, sino que las reciben (se inyectan).  
**Cuándo usarlo:** Para reducir acoplamiento, facilitar pruebas unitarias y permitir intercambiar implementaciones.  

``` csharp
// Registro
services.AddScoped<IClienteRepository, ClienteRepositorySql>();

// Uso
public class ClienteService {
    private readonly IClienteRepository _repo;
    public ClienteService(IClienteRepository repo) {
        _repo = repo;
    }
}
```

### Facade

**Qué es:** Un patrón estructural que proporciona una **interfaz simplificada** a un sistema complejo.  
**Cuándo usarlo:** Cuando se quiere ocultar la complejidad interna y ofrecer un punto de acceso único.  

```csharp
public class SistemaComplejo {
    public void Paso1() => Console.WriteLine("Ejecutando paso 1");
    public void Paso2() => Console.WriteLine("Ejecutando paso 2");
    public void Paso3() => Console.WriteLine("Ejecutando paso 3");
}

public class Fachada {
    private readonly SistemaComplejo _sistema = new SistemaComplejo();
    public void Operacion() {
        _sistema.Paso1();
        _sistema.Paso2();
        _sistema.Paso3();
    }
}
```

### Mediator

**Qué es:** Un patrón de comportamiento que centraliza la comunicación entre objetos.  
**Cuándo usarlo:** Para reducir dependencias directas entre clases.  

```csharp
public interface IMediador {
    void Enviar(string mensaje, Colega emisor);
}

public abstract class Colega {
    protected IMediador mediador;
    public Colega(IMediador m) { mediador = m; }
}

public class ColegaConcreto : Colega {
    public ColegaConcreto(IMediador m) : base(m) {}
    public void Enviar(string mensaje) => mediador.Enviar(mensaje, this);
    public void Recibir(string mensaje) => Console.WriteLine($"Recibido: {mensaje}");
}
```

### Resumen

- **Factory:** delega la creación de objetos.\
- **Singleton:** asegura una única instancia global.\
- **Strategy:** define algoritmos intercambiables.\
- **Repository:** separa lógica de negocio del acceso a datos.\
- **Dependency Injection:** inyecta dependencias externas, favorece bajo acoplamiento.
- **Facade:** simplifica acceso a sistemas complejos.  
- **Mediator:** centraliza comunicación entre objetos.  
- **Builder:** construye objetos paso a paso.  
- **Template Method:** define algoritmo base, pasos en subclases.  
- **Unit of Work:** coordina transacciones en persistencia.  
- **Command:** encapsula solicitudes como objetos.  
- **Observer:** notifica a múltiples objetos ante cambios.  
- **Iterator:** recorre colecciones sin exponer detalles.  
- **Adapter:** convierte una interfaz en otra compatible.  
- **State:** cambia comportamiento según estado interno.  
- **Strategy:** intercambia algoritmos en tiempo de ejecución.  
