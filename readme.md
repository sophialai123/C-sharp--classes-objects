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

---
## Public vs. Private

At this point we have built fields to associate data with a class and properties to control the getting and setting of each field. As it is now, any code outside of the `Forest` class can “sneak past” our properties by directly accessing the field:

```
f.Age = 32; // using property
f.age = -1; // using field
```

The second line avoids the property’s validation by directly accessing the field. We can fix this by using the access modifiers `public` and `private`:

- `public` — a public member can be accessed by any class

- `private `— a private member can only be accessed by code in the same class


For simplicity, we’ve been adding `public` to every member so far. That allows code to access the members from the `Main()` method, which doesn’t belong to the `Forest` class. When we switch a field from `public` to `private` it will no longer be accessible from `Main()`, although code inside the `Forest` class — like properties — can still access it.

Access modifiers can be applied to all members of a class, including fields, properties, and the rest of the members covered in this lesson.


`public` and `private` are necessary to encapsulate our classes. Think of it like “defensive coding”: you are protecting the inner mechanisms of a class with `private` so that other code can’t break your class. You only expose what you want to be `public`.


For example, since a class’ properties define how other programs get and set its fields, it’s good practice to make fields `private` and properties `public`.

C# encourages encapsulation by defaulting class members to `private` and classes to `public`.

---
## Get-Only Properties
Previously we used properties for field validation. By applying `public` and `private`, we can also use properties to control access to fields.

Recall our imaginary Area property. Say we want programs to get the value of the property, but we don’t want programs to set the value of the property. Then we either:

1. don’t include a set() method, or
2. make the set() method private.

This shows approach 1 — don’t include a `set()`:
```
public string Area
{
  get { return area; }
}
```

We can still get Area, but if we try to set Area we get an error:
`error CS0200: Property or indexer 'Forest.Area' cannot be assigned to (it is read-only)`


#### this is a better way
This shows approach 2 — make `set() private`:


```
public int Area
{
  get { return area; }
  private set { area = value; }  
}
```
We can still get Area, but if we try to set Area in Main() we get an error:
`error CS0272: The property or indexer 'Forest.Area' cannot be used in this context because the set accessor is inaccessible`

Notice that in approach 1 we get an error for setting `Area` anywhere. In approach 2 we only get an error for setting Area outside of the `Forest `class. Generally we prefer **approach 2** because it allows other `Forest `methods to set `Area`.

---
## Methods
The third type of member in classes is methods.most methods belong to a class (even the ones you have written!), so methods are also used to define how an instance of a class behaves. You can think of them as the “actions” or function that an object can perform.

This code defines a method IncreaseArea() that changes the value of the Area property:

```
class Forest {
  public int Area
  { /* property body omitted */  }
  public int IncreaseArea(int growth)
  {
    Area = Area + growth;
    return Area;
  }
}
```

You would call the method like so:

```
Forest f = new Forest();
int result = f.IncreaseArea(2);
Console.WriteLine(result); // Prints 2
```
---
## Constructors

In each of the examples so far, we created a new `Forest` object and set the property values one by one. It would be nice if we could write a method that’s run every time an object is created to set those values at once.

C# has a special type of method, called a **constructor**, that does just that. It looks like a method, but there is no return type listed and the method name is the name of its enclosing class:

```
class Forest 
{
  public Forest()
  {
  }
}
```
We can add code in the constructor to set values to fields:

```
class Forest
{
  public int Area;
 
  public Forest(int area)
  {
    Area = area;
  }
}
```

This constructor method is used whenever we instantiate an object with the new keyword:

```
 // Constructor is called here
Forest f = new Forest(400);
```

If no constructor is defined in a class, one is automatically created for us. It takes no parameters, so it’s called a parameterless constructor. That’s why we have been able to instantiate new objects without errors:
`Forest f = new Forest();`

---
## this
The parameter for the constructor `area` looks a lot like the old field `area` and the new property Area. It’s good to be explicit when writing code so that there is no room for misinterpretation. We can refer to the current instance of a class with the `this` keyword.
```
class Forest
{
  public int Area
  { /* property omitted */ }
 
  public Forest(int area)
  {
    this.Area = area;
  }
```

`this.Area = area `means “when this constructor is used to make a new instance, use the argument `area` to set the value of this new instance’s `Area `field”.

We would call it the same way:
`Forest f = new Forest(400);`

f.Area now equals 400.

---
## Overloading Constructors
Just like other methods, constructors can be overloaded. For example, we may want to define an additional constructor that takes one argument:

```
public Forest(int area, string country)
{ 
  this.Area = area;
  this.Country = country;
 }
 
public Forest(int area)
{ 
  this.Area = area;
  this.Country = "Unknown";
}
```

The first constructor provides values for both fields, and the second gives a default value when the country is not provided. Now you can create a `Forest` instance in two ways:

```
Forest f = new Forest(800, "Hungary");
Forest f2 = new Forest(400);
```
Notice how we’ve written duplicate code for our second constructor: `this.Area = area`;. Later on, if we need to adjust the constructor, we’ll need to find every copy of the code and make the exact same change. That means more work and chances for errors.


We have two options to resolve this. In either case we will remove the duplicated code:

1. Use default arguments. This is useful if you are using C# 4.0 or later (which is fairly common) and the only difference between constructors is default values.

```
public Forest(int area, string country = "Unknown")
{
  this.Area = area;
  this.Country = country;
}
```

2. Use : `this()`, which refers to another constructor in the same class. This is useful for old C# programs (before 4.0) and when your second constructor has additional functionality. This example has an additional functionality of announcing the default value.

Remember that `this.Area` refers to the current instance of a class. When we use `this()` like a method, it refers to another constructor in the current class. In this example, the second constructor calls `this()` — which refers to the first `Forest()` constructor — AND it prints information to the console.

---
## Review
- Define a class
- Instantiate an object using new
- Define fields, the pieces of data for each class
- Define properties, the spokespeople for each field
- Define automatic properties, the shorthand for making properties
- Define methods, the actions a class can take
- Define constructors, the special methods called when a class is instantiated
- Overload constructors and reuse code with this
- Control access to class members using public and private


