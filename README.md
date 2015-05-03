# Unity Lifestyle Decorations

Some simple lifestyle registration attributes that for Unity.

Register as [Singleton], [Transient] or [PerHttpRequest]

The PerRequestLifetimeManager is ripped directly out of Unity.MVC source https://unity.codeplex.com/SourceControl/latest#source/Unity.Mvc/Src/PerRequestLifetimeManager.cs

A registration can be named, and can target a specific interface, e.g.

<pre><code>
[Singleton(Name: "MySingleton", InterfaceType: typeof(IMyInterface"]
</code></pre>
Default behavours
---------------------

Unnamed registration have the default unity behaviour of a null name.

Registrations that do not target a specific interface are registerde for all implemented interfaces of the class and for the concrete instance of the class.

e.g.

<pre><code>
[Singleton]
class MyClass : IService, ISomthingElse
</code></pre>
is registered as the default for IService, ISomthingElse and MyClass

<pre><code>
[Singleton(typeof(IService)]
class MyClass : IService, ISomthingElse
</code></pre>
is registered as the default for IService

<pre><code>
[Singleton("MyService"]
class MyClass : IService, ISomthingElse
</code></pre>
is registered as named instance for IService, ISomthingElse and MyClass

Not really tested
-------------------

not really tested yet....
