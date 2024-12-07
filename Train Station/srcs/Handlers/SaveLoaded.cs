using StardewModdingAPI.Events;
using TrainStation.Utilities;

namespace TrainStation.Handlers
{
	internal static class SaveLoadedHandler
	{
		/// <inheritdoc cref="IGameLoopEvents.SaveLoaded"/>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event data.</param>
		internal static void Apply(object sender, SaveLoadedEventArgs e)
		{
			// Set station access tiles
			TransportFrameworkUtility.SetStationAccessTiles();
		}
	}
}
