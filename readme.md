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
---
## Properties

Properties are another type of class member. Each property is like a spokesperson for a field: it controls the access (getting and setting) to that field. We can use this to validate values before they are set to a field. A property is made up of two methods:

 - a `get()` method, or getter: called when the property is accessed

 - a `set()` method, or setter: called when the property is assigned a value

 This shows a basic `Area` property without validation:

 ```
 public int area;
public int Area
{
  get { return area; }
  set { area = value; }
}
 ```

 The `Area` property is associated with the `area` field. It’s common to name a property with the title-cased version of its field’s name, e.g. `age` and `Age`, `name` and `Name`.

The `set()` method above uses the keyword `value`, which represents the value we assign to the property. Back in Program.cs, when we access the Area property, the `get()` and `set()` methods are called:

```
Forest f = new Forest();
f.Area = -1; // set() is called
Console.WriteLine(f.Area); // get() is called; prints -1
```

In the above example, when `set()` is called, the value variable is -1, so `area `is set to `-1`.

Here’s the same property with validation in the `set()` method. If we try to set `Area` to a negative value, it will be changed to `0`.

```
public int Area
{
  get { return area; }
  set 
  { 
    if (value < 0) { area = 0; }
    else { area = value; }
  }
}
```

In Program.cs:

```
Forest f = new Forest();
// set() is called
f.Area = -1; 
// get() is called; prints 0
Console.WriteLine(f.Area);
```
---

## Automatic Properties

It might have felt tedious to write the same getter and setter for the `Name `and `Trees` properties. C# has a solution for that! The basic getter and setter pattern is so common that there is a short-hand called an **automatic property**. As a reminder, here’s the basic pattern for an imaginary size property:

```
public string size;
public string Size
{
  get { return size; }
  set { size = value; }
}
```

This pattern can be written as an automatic property:

```
public string Size
{ get; set; }
```
In this form, you don’t have to write out the `get()` and `set()` methods, and you don’t have to define a `size` field at all! A hidden field is defined in the background for us. All we have to worry about is the `Size` property.
