using System;
using Fruity.Core;
using TechTalk.SpecFlow;

namespace Fruity.Tests
{
    [Binding]
    public class FruitMachineSteps
    {
        [Given(@"there are (.*) credits in the machine")]
        public void GivenThereAreCreditsInTheMachine(int numberOfCredits)
        {
			var classUnderTest = new FruitMachineViewModel(numberOfCredits);
			ScenarioContext.Current.Add("classUnderTest", classUnderTest);
        }
        
        [When(@"I spin the reels")]
        public void WhenISpinTheReels()
        {
			var classUnderTest = (FruitMachineViewModel)ScenarioContext.Current["classUnderTest"];
			classUnderTest.Spin();
        }
        
        [Then(@"there should be (.*) credits in the machine")]
        public void ThenThereShouldBeCreditsInTheMachine(int expectedCredits)
        {
			var classUnderTest = (FruitMachineViewModel)ScenarioContext.Current["classUnderTest"];
			NUnit.Framework.Assert.AreEqual(expectedCredits, classUnderTest.Credits);
		}		

		[Then(@"I should not be able to play")]
		public void ThenIShouldNotBeAbleToPlay()
		{
			var classUnderTest = (FruitMachineViewModel)ScenarioContext.Current["classUnderTest"];
			NUnit.Framework.Assert.IsFalse(classUnderTest.CanPlay);
		}

		[When(@"I insert a coin")]
		public void WhenIInsertACoin()
		{
			var classUnderTest = (FruitMachineViewModel)ScenarioContext.Current["classUnderTest"];
			classUnderTest.InsertCoin();
		}

		[Then(@"I should be able to play")]
		public void ThenIShouldBeAbleToPlay()
		{
			var classUnderTest = (FruitMachineViewModel)ScenarioContext.Current["classUnderTest"];
			NUnit.Framework.Assert.IsTrue(classUnderTest.CanPlay);
		}


	}
}
