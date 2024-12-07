using Microsoft.Xna.Framework;
using TrainStation.Frameworks;

namespace TrainStation.Utilities
{
	public sealed class ModConfig
	{
		public Point TicketMachineTilePoint = new(32, 40);
	}

	internal class GMCMUtility
	{
		internal static void Initialize()
		{
			ReadConfig();
			Register();
		}

		private static void ReadConfig()
		{
			ModEntry.Config = ModEntry.Helper.ReadConfig<ModConfig>();
		}

		private static void Register()
		{
			// Get Generic Mod Config Menu's API
			IGenericModConfigMenuApi gmcm = ModEntry.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

			if (gmcm is not null)
			{
				// Register mod
				gmcm.Register(
					mod: ModEntry.ModManifest,
					reset: () => ModEntry.Config = new ModConfig(),
					save: () => {
						TransportFrameworkUtility.SetStationAccessTiles();
						ModEntry.Helper.WriteConfig(ModEntry.Config);
					}
				);

				// Main section
				gmcm.AddNumberOption(
					mod: ModEntry.ModManifest,
					name: () => ModEntry.Helper.Translation.Get("GMCM.TicketMachineTilePointX.Title"),
					tooltip: () => ModEntry.Helper.Translation.Get("GMCM.TicketMachineTilePointX.Tooltip"),
					getValue: () => ModEntry.Config.TicketMachineTilePoint.X,
					setValue: (value) => {
						ModEntry.Config.TicketMachineTilePoint.X = value;
						ModEntry.Helper.GameContent.InvalidateCache("Maps/Railroad");
					}
				);
				gmcm.AddNumberOption(
					mod: ModEntry.ModManifest,
					name: () => ModEntry.Helper.Translation.Get("GMCM.TicketMachineTilePointY.Title"),
					tooltip: () => ModEntry.Helper.Translation.Get("GMCM.TicketMachineTilePointY.Tooltip"),
					getValue: () => ModEntry.Config.TicketMachineTilePoint.Y,
					setValue: (value) => {
						ModEntry.Config.TicketMachineTilePoint.Y = value;
						ModEntry.Helper.GameContent.InvalidateCache("Maps/Railroad");
					}
				);
			}
		}
	}
}
