using StardewModdingAPI.Events;
using TrainStation.Utilities;

namespace TrainStation.Handlers
{
	internal static class GameLaunchedHandler
	{
		/// <inheritdoc cref="IGameLoopEvents.GameLaunched"/>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event data.</param>
		internal static void Apply(object sender, GameLaunchedEventArgs e)
		{
			// Register queries
			QueriesUtility.Register();

			// Initialize GMCM
			GMCMUtility.Initialize();

			// Initialize TransportFramework
			TransportFrameworkUtility.Initialize();
		}
	}
}
