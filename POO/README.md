# Programación orientada a objetos

## Principios

### Clase

- Es un molde o plantilla que define cómo serán los objetos.
- Contiene:
  - Atributos (propiedades, campos): describen el estado (ej. nombre, edad).
  - Métodos (funciones): definen el comportamiento (ej. caminar, comer).
- Por sí sola no ocupa memoria (es una definición).

### Objeto

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

## Los 4 fundamentos de la programación orientada a objetos:

### Abstracción

Este principio dice que la POO busca modelar los objetos, busca abstraerse y simplificar un objeto de la vida real a solo un par de atributos. En otras palabras, buscaremos transformar un objeto de la vida real en atributos (características) y sus acciones (métodos). Consiste en encontrar las partes fundamentales de un sistema para describirlas de manera simple y precisa.

### Encapsulamiento

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

### Herencia

Es el mecanismo por el cual las subclases (hija o derivada) reutilicen las propiedades y métodos de sus superclases (padre o base). En otras palabras, permite que una clase pueda servir como plantilla para la creación de futuras clases.

La herencia permite:
* Crear una nueva clase como refinamiento de otra.
* Diseñar e implementar sólo la diferencia que presenta la nueva clase.
* Abstraer las similitudes en común, evitando la **duplicación de código y fomentando la reutilización**.

Características en C#:
* Se usa la palabra clave : para indicar herencia.
* Soporta herencia simple (una sola clase padre).
* Se puede sobrescribir métodos de la clase base con virtual y override.

### Polimorfismo

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

## Cohesión y acoplamiento

La cohesión es el efecto que se produce cuando las cosas se reunen o adhieren entre sí. Algo está cohesionado si tiene sentido y una dirección común. Algo tiene alta cohesión si tiene un alcance definido, unos límites claros y un contenido delimitado y perfectamente ubicado. Si hablásemos de POO, una clase tendrá alta cohesión si sus métodos están relacionados entre sí, tienen un contenido claro y temática común, trabajan con tipos similares, etc. Todo bien encerrado dentro de la clase, y perfectamente delimitado.

El acoplamiento es el grado en que los módulos de un programa dependen unos de otros. Si para hacer cambios en un módulo del programa es necesario hacer cambios en otro módulo distinto, existe acoplamiento entre ambos módulos.

Lo ideal es tener bajo acoplamiento y alta cohesión.

Fuente:
- https://www.disrupciontecnologica.com/acoplamiento-y-cohesion/
