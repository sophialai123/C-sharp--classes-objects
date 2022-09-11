using System;

namespace BasicClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //make a new instance of the Forest class
            //and store the result in a variable f.
            Forest f = new Forest();

            //Set values to those four fields.
            f.name = "Congo";
            f.trees = 0;
            f.age = 0;
            f.biome = "Tropical";

            //print the name field to the console.
            Console.WriteLine(f.name);
        }
    }
}
