using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Collections.Generic;

namespace PopStack.Test
{
    [TestClass]
    public class PoppingShould
    {
        [TestMethod]
        public void KeepTryingUntilFound() 
        {
            //Arrange
            PoppedStackDummy poppedStackDummy= new(new List<int>() {1,2,3,4,5,6,7,8,9,10},3);

            MockPopping mockPopping = new(20, 5);
            mockPopping.AdditionalSetup();
            Popping sut = mockPopping.Object;
            
            //Act
            sut.KeepTrying(poppedStackDummy);

            //Assert
            List<int> expetedPopped = new List<int>() { 5, 6, 7, 8, 9, 10 };

            sut.PoppedSoFar.Should().BeEquivalentTo(expetedPopped);
            sut.Tries.Should().Be(6);
            mockPopping.Protected().Verify("PopAndCheck",Times.Exactly(6),new object[] { poppedStackDummy});

        }

        [TestMethod]
        public void KeepTryingUntilFound2()
        {
            //Arrange
            MockPoppedStack mockPoppedStack= new(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3);

            MockPopping mockPopping = new(20, 5);
            mockPopping.AdditionalSetup();
            Popping sut = mockPopping.Object;

            //Act
            sut.KeepTrying(mockPoppedStack.Object);

            //Assert
            List<int> expetedPopped = new List<int>() { 5, 6, 7, 8, 9, 10 };

            sut.PoppedSoFar.Should().BeEquivalentTo(expetedPopped);
            sut.Tries.Should().Be(6);
            mockPopping.Protected().Verify("PopAndCheck", Times.Exactly(6), new object[] { mockPoppedStack.Object });

        }


    }
}
