using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK4Life
{
    class Patch
    {
        public uint offset;
        public byte[] patch;

        public Patch(uint offset, byte[] patch)
        {
            this.offset = offset;
            this.patch = patch;
        }

    }
}
