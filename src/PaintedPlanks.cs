using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace Paints
{
    class PaintedPlanks : Block
    {
        private int x;
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            x = Attributes["colorX"].AsInt();
            System.Console.WriteLine("XXX PaintedPlanks loaded x="+x);
            
        }

        public override void OnJsonTesselation(ref MeshData sourceMesh, BlockPos pos, int[] chunkExtIds, ushort[] chunkLightExt, int extIndex3d)
        {
            int y = 16;

            for (int i = 0; i < sourceMesh.CustomInts.Count; i++)
            {
                sourceMesh.CustomInts.Values[i] &= ~(0xffff << 16);
                sourceMesh.CustomInts.Values[i] |= (x << 16) | (y << 24);
            }
        }
    }
       
}
