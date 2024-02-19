# ReactJS

## Para arrancar, instalar estas herramientas:

- NodeJs
- NPM
- Visual Studio Code
- Create React App (https://create-react-app.dev/)
- React Developer Tools (extensión para Chrome)
- Cmder

## Para crear un proyecto:
```
npx create-react-app my-app
```

## Para ver la App corri endo en el browser:
```
http://localhost:3000/
```

# Conceptos claves

## Basado en componentes:
- Reutilizable: React se basa en la idea de Componentes reutilizables.
- Independencia: un componente es una pieza de la UI encapsulada que puede gestionar su propio estado y renderizado.
- Composición: los componentes pueden ser compuestos por otros componentes, y así poder crear interfaces de usuario complejas.
  
Un componente es una pieza de código reutilizable que representa una parte de una interfaz de usuario, en fin, es una función. Los componentes se utilizan para representar, administrar y actualizar los elementos de la interfaz de usuario en su aplicación. En React, por lo general, los componentes se escriben en JSX. Todas las funciones, constantes y variables tienen que ir adentro de la función principal que representa a un componente.

## JSX
JSX es una extensión de sintaxis para JavaScript que se parece al HTML. Te permite escribir la estructura de la UI de una manera que es fami1iar para muchos desarrolladores. Un elemento JSX es una combinación de código Javascript y HTML que describe lo que se quiere mostrar.

## State
El estado es un conjunto de datos que determina el comportamiento de un componente y cómo se renderiza. El cambio de estado lleva a la re-renderización del componente. En las versiones modernas de React, el estado se maneja a menudo a través de hooks como useState.

## Props
Las propiedades, o props, son una forma de pasar datos de un componente padre a un componente hijo; son como parámetros de entrada para el componente. Son de sólo lectura para el componente hijo y permiten a los componentes ser dinámicos y reutilizables.

## Hooks
Los hooks son funciones que permiten a los componentes funcionales tener estado y otros rasgos de React sin necesidad de ser clases. Los hooks más comunes incluyen useState, useEffect y useContext.

## Context
React Context permite compartir valores como preferencias del usuario o temas de UI entre componentes sin tener que pasar explícitamente props a través de cada nivel del árbol de Componentes.

## Ciclo de Vida de los Componentes
Los componentes en React tienen un ciclo de vida que comienza con su montaje, pasa por varias actualizaciones y termina con su desmontaje. React proporciona métodos de ciclo de vida que se pueden sobrescribir para ejecutar código en diferentes puntos del ciclo de vida de un componente.

## Extra: Renderizado Declarativo
React sigue un modelo declarativo en lugar de imperativo. En lugar de decirle al navegador cómo crear la UI, simplemente se declara cómo debe verse la UI en un punto en el tiempo y React se encarga de actualizar el DOM para que coincida con esa descripción.

## Extra: Virtual DOM
React mantiene una representación 1igera del DOM en memoria, conocida como Virtual DOM, es como una caché. Cuando el estado de un componente cambia, React primero realiza cambios en la Virtual DOM, y luego, mediante un algoritmo de reconciliación, actualiza el DOM real de 1a manera más eficiente posible.

---

# Ejercicios prácticos.

## Ejercicio: crear un proyecto de ejemplo usando el template llamado "template-example" y correrla
## Solución: ejecutar los comandos:
npx create-react-app template-example
cd my-app
npm start

## Ejercicio: Al ejemplo base, 1e quiero agregar un componente nuevo que muestre un botón:
```
<button>I'm a button</button>
```
## Solución:
Crear un nuevo archivo para el componente 1lamado "MyButton.js" en el directorio raíz.
Detinir el componente con el siguiente código:
```
import React from 'react';
const MyButton = () => {
  return (
    <button>I'm a button</button>
  );
);
export default MyButton;
```
Usar el componente en alguna parte de la aplicación "App.js":
```
<div>
  <MyButton />
</div>
```

## Ejercicio: Al componente anterior, le quiero agregar estilos:
```
span { color: red; }
```
## Solución: agregar la siguiente 1ínea:
```
import './MyButton.css';
```

## Ejercicio: se necesita mostrar datos en JSX.
## Solución: se pueden usar las 1laves para escapar al contexto del template y acceder a los datos del Componente. Por ejemplo, Supongamos que tenemos esta estructura:
```
const user = {
  name: 'Pedro',
  age: 41
};
```
Entonces la podemos usar de esta manera:
```
<p>Name: {user. name}</p>
<p>Age : {user.age}</p>
```

## JSX - Conditional rendering
Ejemplo compacto:
```
<div>
  { isLoggedIn ? ( <AdminPanel /> ) : ( <LoginForm /> )}
</div>
```

## JSX - Renderizando listas
Se pueden procesar arrays para formar expresiones HTML para renderizar, para ello se puede utilizar la prop "Key" para especificar una clave única para cada elemento. Esta Key se usa para identificar qué elemento actualizar cuando se quiera actualizar un elemento específico. Por ejemplo, si tenemos este array:
```
const products = [
  { title: 'Banana', id: 1 },
  { title: 'Naranja, id: 2 },
  { title: 'Manzana, id: 3 },
];
```
Con este array se puede formar esta expresión en HTML:
```
const listItems = products.map(product =>
  <1i key={product.id}>
    {product.title}
  </li>
);
```
Y luego retorno el valor de una forma sencilla:
```
return ( <ul>{listItems}</ul> );
```

## JSX - Respuesta a Eventos
Es una feature de JSX, se pueden usar los nombres de la funciones como Event Handlers. Por ejemplo, con esta función:
```
function handleclick() { alert(' You clicked me!'); }
```
Podemos devolver esta expresión:
```
return ( <button onClick={handleClick}> Click me </button> );
```

## Actualización de pantalla
Para que un componente guarde sus estados, se puede usar variables de estado.
Primero, se importa:
```
import { usestate } from 'react';
```
Segundo, dentro de la función componente, se usa la función usestate que recibe el valor inicial, devuelve la variable que guarda el estado y el setter.
```
const [count, setCount] = useState (0);
```
Luego, se los usa, por ejemplo para tener un contador:
```
function handleClick() {
  setCount(count + 1);
}
return (
  <button onClick={handleClick}>
    Clicked {count} times
  </button>
);
```
  
## Hooks
Los Hooks son funciones especiales, están dentro de un componente. Hay hooks que vienen con React (helpers) y hay Hooks que son custom (los desarrollados por nosotros).

## State y Props
El estado se gestiona dentro del componente, son similares a las variables declaradas dentro de una función. Cuando se cambia el valor de un estado compartido con otros componentes hijos, entonces se actualiza en los componentes hijos (si se lo muestra, se actualiza la UI). Ésto se llama "lifting state up".
Las Props son valores que se le pueden pasar a los componentes, como parámetros de entrada del componente.
Un problema recurrente es cuando se quiere cambiar el valor de una prop dentro de un componente hijo. Para resolver este problema se pasa una función como parámetro (un callback) para que realice el cambio, dado que desde adentro no se puede llevar el cambio.

## Ciclos de vida de un componente
Cada componente de React pasa por el mismo ciclo de vida:
- Un componente se monta (mounting) cuando se agrega a la pantalla.
- Un componente se actualiza (updating) cuando recibe nuevos accesorios o estados, generalmente en respuesta a una interacción.
- Un componente se desmonta (unmounting) cuando se elimina de la pantalla.
Los ciclos de vida de un componente vienen junto con varios métodos que se pueden sobreescribir para ejecutar código en momentos determinados del proceso. Sin embargo, no se recomienda utilizar métodos de ciclo de vida manualmente. En su lugar, utilice el hook useEffect con los componentes.

## useRef
Es un hook que se usa para guardar datos dentro de un componente (como el state), pero no se quiere provocar un re renderizado del componente con las actualizaciones de este lado. Este valor es mutable, es decir, se puede leer y escribir. Es un dato de un componente que React no monitorea.

## useEffect
Es un hook que te permite sincronizar un componente con un sistema externo.

## React Router
```
npm create vite@latest
npm install react-router-dom localforage match-sorter sort-by
```

Más info en:
https://reactrouter.com/en/main/start/tutorial

## Context
https://react.dev/learn/passing-data-deeply-with-context

## React Query
```
npx create-react-app call-api-example
cd call-api-example
npm i tanstack/react-query
npm start
```

Más info en:
https://tanstack.com/query/latest/docs/react/overview

---

# Fuentes
- https://react.dev/learn
- https://roadmap.sh/react

