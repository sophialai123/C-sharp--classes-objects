using System;

namespace BasicClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Call the new constructor 
            create a Forest object with the 
            name “Congo” and biome “Tropical”. */
            Forest f = new Forest("Congo", "Tropical");

            //Set values to those four fields.
            f.Name = "Congo";
            f.Trees = 0;
            f.age = 0;
            f.Biome = "Tropical";

            //print the name Proprety to the console.
            Console.WriteLine(f.Name);

            // get() is called and Prints Unknown
            //use the property (Biome) instead of the field (biome)
            Console.WriteLine(f.Biome);

            //call the second constructor
            Forest f2 = new Forest("Rendlesham");
            Console.WriteLine(f.Biome);
        }
    }
}
