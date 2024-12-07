using StardewModdingAPI.Events;
using TrainStation.Utilities;

namespace TrainStation.Handlers
{
	internal static class DayEndingHandler
	{
		/// <inheritdoc cref="IGameLoopEvents.DayEnding"/>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event data.</param>
		internal static void Apply(object sender, DayEndingEventArgs e)
		{
			// Reset train time
			TrainUtility.Reset();
		}
	}
}
