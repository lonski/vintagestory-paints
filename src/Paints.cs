using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using System.IO;
using Vintagestory.API.Config;
using Vintagestory.GameContent;

[assembly: ModInfo( "Paints",
	Description = "Vintage Story mod which adds paint preparation and coloured planks",
	Website     = "https://github.com/lonski/vintagestory-paints",
	Authors     = new []{ "Sps" } )]

namespace Paints
{
	public class PaintsMod : ModSystem
	{
		public override void Start(ICoreAPI api)
		{
			// api.RegisterBlockEntityClass("PaintedPlanks", typeof(BEPaintedPlanks));
		}

		public override void StartPre(ICoreAPI api)
        {
			// api.RegisterBlockEntityClass("PaintedPlanks", typeof(BEPaintedPlanks));
        }
		
		public override void StartClientSide(ICoreClientAPI api)
		{
			api.RegisterBlockClass("PaintedPlanks", typeof(PaintedPlanks));
			// api.RegisterBlockEntityClass("PaintedPlanks", typeof(BEPaintedPlanks));
			// api.RegisterEntityRendererClass("PaintedPlanks", typeof(PaintedPlanksRenderer));
		}
		
		public override void StartServerSide(ICoreServerAPI api)
		{				
			api.RegisterBlockClass("PaintedPlanks", typeof(PaintedPlanks));
			// api.RegisterBlockEntityClass("PaintedPlanks", typeof(BEPaintedPlanks));
		}
	}
}