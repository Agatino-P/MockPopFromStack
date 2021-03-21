using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopStack.Test
{
    public class PoppingTestable : Popping
    {
        public PoppingTestable(int maxTries, int lookingFor) : base(maxTries, lookingFor)
        {
        }
        protected  override bool PopAndCheck(PoppedStack poppedStack) => base.PopAndCheck(poppedStack);
        public override void KeepTrying(PoppedStack poppedStack) => base.KeepTrying(poppedStack);

    }
}
