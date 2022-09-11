using System;

namespace BasicClasses
{
    class Forest
    {
        //field of type string:
        public string biome;

        //field of type int:
        public int age;

        /*  Each property is like a spokesperson for a field:
         it controls the access (getting and setting) to that field. */
        // Name property for the name field
        // getter and setter without validation
        //Automatic Properties
        public string Name { get; set; }

        //Define a basic Trees property for the trees field.
        //getter and setter without validation
        //Automatic Properties
        public int Trees { get; set; }

        //Define a Biome property for the biome field
        //with validation in the set() method
        public string Biome
        {
            get
            {
                return biome;
            }
            set
            {
                if (
                    value == "Tropical" ||
                    value == "Temperate" ||
                    value == "Boreal"
                )
                {
                    biome = value;
                }
                else
                {
                    biome = "Unknown";
                }
            }
        }
    }
}
