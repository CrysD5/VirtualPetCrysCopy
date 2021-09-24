using System;
using Xunit;
using System.Collections.Generic;


namespace VirtualPet.Tests
{
    public class IronperTest
    {
        private Ironper testPet;

        public IronperTest()
        {
            testPet = new Ironper();


        }


        [Fact]
        public void Check_Charging_Mode_For_Ironper()
        {

            testPet.HookupCharger();
            Assert.True(testPet.chargingMode);
        }

        [Fact]
        public void Checked_Unhooked_Charging_Mode()
        {

            testPet.UnHookCharger();

            Assert.True(!testPet.chargingMode);
        }


    }
}

