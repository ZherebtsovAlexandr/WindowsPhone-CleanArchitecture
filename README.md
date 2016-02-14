# WindowsPhone-CleanArchitecture
Sample Windows Phone App with The Clean Architecture.

Sources of inspiration article [The Clean Architecture] and [Android-CleanArchitecture project].

Solution has three projects:

**Data layer**
Windows Phone Class Library with SqLite library.
 Implements `IPrepository ` from Domain layer.

**Domain layer**
Windows Phone Class Library.
Contains interfaces for repository and business logic.

**Presentation layer**
Windows Phone App with MVVM pattern. Contains `View`'s and `ViewModel`'s. It's Composition Root for other layers.

The project uses Reactive Extension it is an important part of the project.





[The Clean Architecture]: http://blog.8thlight.com/uncle-bob/2012/08/13/the-clean-architecture.html
[Android-CleanArchitecture project]: https://github.com/android10/Android-CleanArchitecture
