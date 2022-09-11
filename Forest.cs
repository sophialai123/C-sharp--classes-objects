using System;

namespace BasicClasses
{
    class Forest
    {
        //field of type string:
        //a private member can only be accessed by
        //code in the same class
        private string biome;

        //field of type int:
        public int age;

        /*  Each property is like a spokesperson for a field:
         it controls the access (getting and setting) to that field. */
        // Name property for the name field
        // getter and setter without validation
        //Automatic Properties
        public string Name { get; set; }

        /* Define a constructor for the Forest class
         two parameters and set properies */
        public Forest(string name, string biome)
        {
            this.Name = name;
            this.Biome = biome;
            Age = 0;
        }

        //Overloading Constructors
        //Define a second constructor for the Forest class:
        public Forest(string name) :
            this(name, "Unknown")
        {
            Console
                .WriteLine("Name property not specified. Value defaulted to 'Unknown'.");
        }

        //Define a basic Trees property for the trees field.
        //getter and setter without validation
        //Automatic Properties
        public int Trees { get; set; }

        public int Age
        {
            get
            {
                return age;
            }
            private
            set
            {
                age = value;
            }
        }

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

        //define a public method
        public int Grow()
        {
            Trees += 30;
            Age += 1;
            return Trees;
        }

        //Define a public method Burn()
        public int Burn()
        {
            Trees -= 20;
            Age += 1;
            return Trees;
        }
    }
}
