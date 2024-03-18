# General tips for the interview

1. Do not hit around the bush (don't hide). Interviewer doesn't have time.
2. Say the important points first.
3. Use polished right technical vocabulary.

# .NET Interview Questions

## What is the .NET framework?

The .NET framework supports an object-oriented approach that is used for building applications on windows. It supports various languages like C#, VB, Cobol, Perl, .NET, etc. It has a wide variety of tools and functionalities like class, library and APIs that are used to build, deploy and run web services and different applications.

## What are the different components of .NET?

Following are the components of .NET:
* Common Language run-time
* Application Domain
* Common Type System
* .NET Class Library
* .NET Framework
* Profiling

## What do you know about boxing and unboxing?

Boxing
* Implicit
* Converting a value type to the type object
* eg : obj myObject = i;

Unboxing
* Explicit
* Extracting the value type from the object
* eg : i = (int)myObject;

## What is the difference between managed and unmanaged code?

Managed code
* Managed code is managed by CLR
* .NET framework is necessary to execute managed code
* CLR manages memory management through garbage collection

Unmanaged code
* Any code that is not managed by CLR
* Independent of .NET framework
* Own runtime environment for compilation and execution

## Explain the difference between a class and an object?

Class
* Class is the definition of an object
* It is a template of the object
* It describes all the methods, properties, etc

Object
* An object is an instance of a class.
* A class does not become an object unless instantiated
* An object is used to access all those properties from the class.

## Differentiate between constants and read-only variables.

Constants
* Evaluated at compile time
* Support only value type variables
* They are used when the value is not changing at compile time
* Cannot be initialized at the time of declaration or in a constructor

Read-only Variables
* Evaluated at run-time
* They can hold the reference type variables
* Used when the actual value is unknown before the run-time
* Can be initialized at the time of declaration or in a constructor

Fuentes:

- https://www.edureka.co/blog/interview-questions/dot-net-interview-questions/
- https://www.interviewbit.com/dot-net-interview-questions/
- https://mindmajix.com/net-interview-questions
