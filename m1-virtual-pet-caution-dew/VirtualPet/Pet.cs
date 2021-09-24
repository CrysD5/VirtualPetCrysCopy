using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{


    public class Pet
    {

        public string Name { set; get; }
        public string Species { set; get; }
        public int Hunger { set; get; } = 60;
        public int Boredom { set; get; } = 20;

        public int Health { set; get; } = 60;


        public void SetName(string name) { this.Name = name; }
        public string GetName() { return this.Name; }

        public void SetSpecies(string sp) { this.Species = sp; }
        public string GetSpecies() { return this.Species; }
        public int GetHunger() { return this.Hunger; }

        public int GetBoredom() {  return this.Boredom; }

        public int GetHealth()
        {
            return this.Health;
        }

        public virtual void Feed()
        {
            this.Hunger -= 40;
            Console.WriteLine("You fed your pet.");
            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }

        public virtual void SeeDoctor()
        {
            this.Health += 30;
            Console.WriteLine("You took your pet to the Doctor.");
            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }
        public virtual void Play()
        {
            this.Boredom -= 20;
            this.Health += 10;
            this.Hunger += 10;
            Console.WriteLine("You played with your pet.");
            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }

        public virtual void CheckStatus()
        {

            Console.WriteLine("Bored Level " + GetBoredom());
            Console.WriteLine("Hunger Level " + GetHunger());
            Console.WriteLine("Health Level " + GetHealth());
           // Console.ReadKey();
            
        }

        public virtual void Tick()
        {
            if ((this.Boredom += 5) > 100)
            {
                this.Boredom = 100;
            }
            //else
            //{
            //    this.Boredom += 5;
            //}

            if ((this.Health -= 5) < 0)
            {
                this.Health = 0;
            }
            //else
            //{
            //    this.Health -= 5;
            //}

            if ((this.Hunger += 5) > 100)
            {
                this.Hunger = 100;
            }
            //else
            //{
            //    this.Hunger += 5;
            //}
            // will prevent amounts going over 100 or into negatives; caps them off by setting a "max/min"
        }

    }
}