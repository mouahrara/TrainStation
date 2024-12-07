using Microsoft.Xna.Framework;
using StardewModdingAPI;
using TrainStation.Frameworks;

namespace TrainStation.Utilities
{
	internal class TransportFrameworkUtility
	{
		internal static ITransportFrameworkApi tfapi = null;

		internal static void Initialize()
		{
			Register();
		}

		internal static void SetStationAccessTiles()
		{
			if (!Context.IsWorldReady)
				return;

			const string id = "mouahrara.TFTrainStation_Train_Railroad";
			IStation station = tfapi.GetStation(id);

			station.AccessTiles[0] = new Point(ModEntry.Config.TicketMachineTilePoint.X, ModEntry.Config.TicketMachineTilePoint.Y);
			tfapi.SetStation(id, station);
		}

		private static void Register()
		{
			tfapi = ModEntry.Helper.ModRegistry.GetApi<ITransportFrameworkApi>("mouahrara.TransportFramework");
		}
	}
}
