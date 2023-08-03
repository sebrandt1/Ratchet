using RatchetMemoryApi.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.UI.Bindings
{
    internal class AnimationBinder
    {
        public Animator Animator { get; set; }

        public AnimationBinder()
        {
            Animator = new Animator();
        }
    }
}
