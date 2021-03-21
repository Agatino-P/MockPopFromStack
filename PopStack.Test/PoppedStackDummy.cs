using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopStack.Test
{
    public class PoppedStackDummy : PoppedStack
    {
        private List<int> _numbers = new();
        private int _limit;

        public PoppedStackDummy(IEnumerable<int> numbers, int limit) : base(numbers, limit)
        {
            _numbers = new List<int>(numbers);
            _limit = limit;
        }

        public override bool Pop(out int popped)
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
