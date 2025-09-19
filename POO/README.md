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
```
Persona p1 = new Persona();
p1.Nombre = "Juan";
p1.Edad = 30;
p1.Saludar(); // "Hola, me llamo Juan"
```

## Los 4 fundamentos de la programación orientada a objetos:

**Abstracción**: este principio dice que la POO busca modelar los objetos, busca abstraerse y simplificar un objeto de la vida real a solo un par de atributos. En otras palabras, buscaremos transformar un objeto de la vida real en atributos (características) y sus acciones (métodos). Consiste en encontrar las partes fundamentales de un sistema para describirlas de manera simple y precisa.

**Encapsulamiento**: es la cualidad de los objetos de ocultar los detalles de implementación y su estado interno del mundo exterior
Características:
* Esconde detalles de implementación.
* Protege el estado interno de los objetos.
* Un objeto sólo muestra su “cara visible” por medio de su protocolo.
* Los métodos y su estado quedan escondidos para cualquier otro objeto. Es el objeto quien decide qué se publica.
* Facilita modularidad y reutilización.

**Herencia**: es el mecanismo por el cual las subclases reutilizan el comportamiento y estructura reunido en sus superclases. En otras palabras, permite que una clase pueda servir como plantilla para la creación de futuras clases.
La herencia permite:
* Crear una nueva clase como refinamiento de otra.
* Diseñar e implementar sólo la diferencia que presenta la nueva clase.
* Abstraer las similitudes en común.

**Polimorfismo**: un solo nombre de una clase o método puede representar diferentes implementaciones, pero solo una interfaz. Es decir, comportamientos diferentes, asociados a objetos distintos, pueden compartir el mismo nombre; al llamarlos por ese nombre se utilizará el comportamiento correspondiente al objeto que se esté usando. Dicho de otro modo, las referencias y las colecciones de objetos pueden contener objetos de diferentes tipos, y la invocación de un comportamiento en una referencia producirá el comportamiento correcto para el tipo real del objeto referenciado.

Fuente:

https://medium.com/@cancerian0684/what-are-four-basic-principles-of-object-oriented-programming-645af8b43727

## Cohesión y acoplamiento

La cohesión es el efecto que se produce cuando las cosas se reunen o adhieren entre sí. Algo está cohesionado si tiene sentido y una dirección común. Algo tiene alta cohesión si tiene un alcance definido, unos límites claros y un contenido delimitado y perfectamente ubicado. Si hablásemos de POO, una clase tendrá alta cohesión si sus métodos están relacionados entre sí, tienen un contenido claro y temática común, trabajan con tipos similares, etc. Todo bien encerrado dentro de la clase, y perfectamente delimitado.

El acoplamiento es el grado en que los módulos de un programa dependen unos de otros. Si para hacer cambios en un módulo del programa es necesario hacer cambios en otro módulo distinto, existe acoplamiento entre ambos módulos.

Lo ideal es tener bajo acoplamiento y alta cohesión.

Fuente:
- https://www.disrupciontecnologica.com/acoplamiento-y-cohesion/
