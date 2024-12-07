using StardewValley;
using StardewValley.Delegates;

namespace TrainStation.Utilities
{
	internal class QueriesUtility
	{
		public static void Register()
		{
			GameStateQuery.Register($"{ModEntry.ModManifest.UniqueID}_IsTrainDay", IsTrainDay);
		}

		private static bool IsTrainDay(string[] query, GameStateQueryContext context)
		{
			return TrainUtility.IsTrainDay();
		}
	}
}
