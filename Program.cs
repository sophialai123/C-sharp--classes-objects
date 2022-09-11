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
            f.Name = "Congo";
            f.Trees = 0;
            f.age = 0;
            f.Biome = "Tropical";

            //print the name Proprety to the console.
            Console.WriteLine(f.Name);

            f.Biome = "Tropical"; // Prints Tropical

            f.Biome = "Desert";

            // get() is called and Prints Unknown
            Console.WriteLine(f.Biome);
        }
    }
}
