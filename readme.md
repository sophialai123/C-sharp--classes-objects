## Introduction to Classes
In C#, a custom data type is defined with a class, and each instance of this type is an object

---
## Making Classes
C# provides built-in data types, like string: each instance of the string type has its own values and functionality.

```
string phrase = "zoinks!";
Console.WriteLine(phrase.Length);
Console.WriteLine(phrase.IndexOf("k"));
```

In this case `phrase `is an instance of the `string` type. Every `string` has a `Length` property and `IndexOf()` method, but the resulting values are different for each instance.

A class represents a custom data type. In C#, the class defines the kinds of information and methods included in a custom type.

You can then make instances of that class (above, `phrase` was an instance of `string`). There may be many instances of the same class, all with unique values.

To begin defining a class, C# uses this structure:

```
class Forest {
}



Forest f = new Forest();
```

In other parts of code, like `Main()` in Program.cs, we can use the class. We make instances, or objects, of the `Forest` class with the `new` keyword:


We could say f is an instance of the Forest class, or f is of type Forest.

---
## Fields

We need to associate different pieces of data, like a size and name, to each `Forest` object. In C#, these pieces of data are called fields. Fields are one type of class member, which is the general term for the building blocks of a class.

Create fields like this:

```
class Forest {
  public string name;
  public int trees;
}
```

This might look similar to defining a variable. It is! Each field is a variable and it will have a different value for each object.


With the code above, we haven’t set the value of either field, so each has a default value. In this case `strings default to null`, `ints to 0`, and `bools to false`. You can find the default values for more types in [Microsoft’s default values table](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/default-values).

It is common practice to name fields using all **lowercase** (`name` instead of `Name`). This makes fields easy to recognize later on!

Once we create a `Forest` instance, we can access and edit each field with dot notation:
Each instance has a `name` field, but the value may differ across instances.

```
Forest f = new Forest();
f.name = "Amazon";
Console.WriteLine(f.name); // Prints "Amazon"
 
Forest f2 = new Forest();
f2.name = "Congo";
Console.WriteLine(f2.name); // Prints "Congo"
```