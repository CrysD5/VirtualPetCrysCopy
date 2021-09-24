using System;

namespace VirtualPet
{
    public class Ironper : Pet
    {
        //public int chargLevel;

        public bool chargingMode;
        public void HookupCharger() 
        { 
            this.chargingMode = true;
        }

        public void UnHookCharger() 
        { 
            this.chargingMode = false;
        }

        public override void Tick() 
        {
            if ((this.Boredom += 5) > 100)
            {
                this.Boredom = 100;
            }
            else
            {
                this.Boredom += 5;
            }

            if ((this.Hunger += 5) > 100)
            {
                this.Hunger = 100;
            }
            else
            {
                this.Hunger += 5;
            }

            if (chargingMode == true)
            {
                if ((this.Health += 10) > 100)
                {
                    this.Health = 100;
                }
                else { this.Health += 10; }
            }
            else
            {
                this.Health -= 1;
            }
                
        }

        public override void CheckStatus() 
        {
            Console.WriteLine("Bored Level: " + GetBoredom());
            Console.WriteLine("Oil Level: " + GetHunger());
            Console.WriteLine("Battery Level: " + GetHealth());
            if (chargingMode == true)
            {
                Console.WriteLine("Your robot is hooked up to a charger.");
            }
            else
            {
                Console.WriteLine("Your robot is not hooked up to a charger.");
            }
            Console.WriteLine("Press any key to continue.");
            // Console.Read();
        }

        public override void Play() 
        {
            chargingMode = false; 
            base.Health -= 20;
            Console.WriteLine("You played with your robot.");
            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }

        public override void Feed()
        {
            this.Hunger += 40;
            Console.WriteLine("You filled your robot up with oil!");
            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }
        public override void SeeDoctor() 
        {
            if (chargingMode == false)
            {
                HookupCharger();
                Console.WriteLine("You hooked your robot up to a charger!");
            }

            else
            {
                UnHookCharger();
                Console.WriteLine("You unhooked your robot from the charger.");
            }

            CheckStatus();
        }


    }
}
