using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopStack.Test
{
    public class MockPoppedStack : Mock<PoppedStack>
    {
        private List<int> _numbers = new();
        private int _limit;


        //https://github.com/Moq/moq4/wiki/Quickstart
        //https://stackoverflow.com/questions/1068095/assigning-out-ref-parameters-in-moq

        public MockPoppedStack(IEnumerable<int> numbers, int limit) :base(MockBehavior.Strict, new object[] { numbers, limit})
        {
            _numbers = new List<int>(numbers);
            _limit = limit;
            Setup(m => m.Pop(out It.Ref<int>.IsAny)).Returns(new repPopDel((out int popped)=>replacementPop(out popped)));
        }

        delegate bool repPopDel(out int popped);


        private bool replacementPop(out int popped)
        {
            popped = -1;
            int last = _numbers.Last();
            if (last == _limit)
                return false;
            popped = last;
            _numbers.Remove(last);
            return true;
        }
    }
}
