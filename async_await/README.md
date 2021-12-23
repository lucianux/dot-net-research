# Async / Await

## Para ejecutarlo

dotnet run -p ./exampleAsyncAwait/exampleAsyncAwait.csproj

## Salida (consola)

The Beginning
LongProcess - It has started
ShortProcess - It has started
ShortProcess - It has finished
LongProcess - It has finished
The End

## Explicación

Tanto LongProcess, como ShortProcess arrancan a la par, ninguno bloquea al otro.
Lo que se debe notar es que, el primero que arranca es LongProcess (el que más tarda) y no retrasa a ShortProcess.

Fuentes

https://www.youtube.com/watch?v=9a-tll-wy7M&t=746s // Video de Hector de León
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/