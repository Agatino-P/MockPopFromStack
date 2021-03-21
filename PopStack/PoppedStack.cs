using System.Collections.Generic;
using System.Linq;

namespace PopStack
{
    public class PoppedStack
    {
        private List<int> _numbers { get; set; }

        private int _limit;
        public PoppedStack(IEnumerable<int> numbers, int limit)
        {
            _numbers = new List<int>(numbers);
            _limit = limit;
        }

        public virtual bool Pop(out int popped)
        {
            popped = -1;

            if (!Continue())
            {
                return false;
            }

            if (_numbers.Count < 1)
            {
                return false;
            }

            popped = _numbers.Last();
            
            _numbers.Remove(popped);
            return true;
        }

        protected bool Continue() => _numbers.Count >= _limit;

    }
}
