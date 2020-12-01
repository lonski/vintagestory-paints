using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace Paints
{
    class BEPaintedPlanks : BlockEntity
    {

        public BEPaintedPlanks()
        {
            System.Console.WriteLine("XXX Constr BE");
        }
        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);
            System.Console.WriteLine("XXX BEPaintedPlanks");
            if (api.Side == EnumAppSide.Client)
            {
                PaintedPlanksRenderer renderer = new PaintedPlanksRenderer(Block, Pos, api as ICoreClientAPI);
               (api as ICoreClientAPI).Event.RegisterRenderer(renderer, EnumRenderStage.Opaque, "paintedplanks");             
            }
        }
    }
}
