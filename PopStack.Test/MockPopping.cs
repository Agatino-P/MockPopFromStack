using Moq;
using Moq.Protected;

namespace PopStack.Test
{
    public class MockPopping : Mock<PoppingTestable>
    {
        public MockPopping(int maxTries, int lookingFor) :base(MockBehavior.Strict, new object[] { maxTries, lookingFor })
        {
            CallBase = true;
        }
        public void AdditionalSetup()
        {
            this.Protected().Setup("PopAndCheck", ItExpr.IsAny<PoppedStack>()).CallBase().Verifiable();
            Setup(m => m.KeepTrying(It.IsAny<PoppedStack>())).CallBase().Verifiable();

        }
    }
}
