using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vintagestory.API;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;

namespace Paints
{
    class PaintedPlanks : BlockSlabSnowRemove
    {
        private int x;
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            this.api = api;
            x = Attributes["colorX"].AsInt();
            System.Console.WriteLine("XXX PaintedPlanks loaded x="+x);
        }

        public override void OnJsonTesselation(ref MeshData sourceMesh, BlockPos pos, int[] chunkExtIds, ushort[] chunkLightExt, int extIndex3d)
        {
            System.Console.WriteLine("YYY PaintedPlanks tesselation");
            base.OnJsonTesselation(ref sourceMesh, pos, chunkExtIds, chunkLightExt, extIndex3d);
            int y = 0;

            // Shape shape = api.Assets.Get("shapes/block/basic/paintedslab-down.json").ToObject<Shape>();
            // (api as ICoreClientAPI).Tesselator.TesselateShape("slab snow cover", shape, out sourceMesh, this);               
            
            sourceMesh.CustomInts = new CustomMeshDataPartInt(sourceMesh.FlagsCount);
            sourceMesh.CustomInts.Values.Fill(0xfffffff); // light foam only
            sourceMesh.CustomInts.Count = sourceMesh.FlagsCount;

            // if (sourceMesh == null){
            //     System.Console.WriteLine("YYY SourceMesh null!");
            //     return;
            // }
            // if (sourceMesh.CustomInts == null) {
            //     System.Console.WriteLine("YYY SourceMesh.CustomInts null!");
            //     return;
            // }

            
            for (int i = 0; i < sourceMesh.CustomInts.Count; i++)
            {
                sourceMesh.CustomInts.Values[i] &= ~(0xffff << 16);
                sourceMesh.CustomInts.Values[i] |= (x << 16) | (y << 24);
            }
        }
    }
       
}
