using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtController
{
    class Art
    {
        public virtual void MakeArt()
        {
            
        }
    }

    class SpaceArt: Art
    {
        public override void MakeArt()
        {
            
            base.MakeArt();
        }
    }
}
