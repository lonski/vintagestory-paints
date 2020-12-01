using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using System.IO;
using Vintagestory.API.Config;
using Vintagestory.GameContent;
using System.Text.RegularExpressions;

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
		}

		public override void StartPre(ICoreAPI api)
        {
        }
		
		public override void StartClientSide(ICoreClientAPI api)
		{		
		}
		
		public override void StartServerSide(ICoreServerAPI api)
		{
		}
	}
}