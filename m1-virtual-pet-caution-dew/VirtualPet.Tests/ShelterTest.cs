using System;
using System.Collections.Generic;
using Xunit;

namespace VirtualPet.Tests
{
    public class Shelter1Test
    {
        private Shelter shelter;

        public Shelter1Test()
        { shelter = new Shelter(); }


        [Fact]
        public void AddPet_Should_Increase_List_Size_By_1()
        {
            shelter.AddPet(new Pet());


            Assert.Single(shelter.ListOfPets);
        }
        [Fact]
        public void ListPets_Should_Be_Empty_By_Default()
        {
            shelter.ListOfPets = new List<Pet>();

            Assert.Empty(shelter.ListOfPets);
        }
        [Fact]
        public void Adopt_Should_Decrease_List_By_1()
        {
            shelter.ListOfPets = new List<Pet>();
            
            Pet pet1 = new Pet();
            shelter.AddPet(pet1);
            shelter.Adopt(pet1);
            Assert.Empty(shelter.ListOfPets);


        }
    }
}