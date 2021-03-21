using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopStack
{
    public class Popping
    {
        public int Tries { get; private set; } = 0;
        public List<int> PoppedSoFar= new();

        private readonly int _lookingFor;
        private readonly int _maxTries;

        public Popping(int maxTries, int lookingFor)
        {
            _maxTries = maxTries;
            _lookingFor = lookingFor;
        }

        protected virtual bool PopAndCheck(PoppedStack poppedStack)
        {
            Tries++;
            if (poppedStack.Pop(out int popped))
            {
                PoppedSoFar.Add(popped);
                return popped == _lookingFor;
            }
            PoppedSoFar.Add(popped);
            return false;
        }


        public virtual void KeepTrying(PoppedStack poppedStack) {
            while (!PopAndCheck(poppedStack))
            {
                if (enough())
                    break;
            }

        }
        private bool enough()
        {
            return Tries >= _maxTries;
        }


    }
}
