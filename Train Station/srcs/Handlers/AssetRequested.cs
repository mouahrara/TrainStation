using StardewModdingAPI.Events;
using TrainStation.Utilities;

namespace TrainStation.Handlers
{
	internal static class AssetRequestedHandler
	{
		/// <inheritdoc cref="IContentEvents.AssetRequested"/>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event data.</param>
		internal static void Apply(object sender, AssetRequestedEventArgs e)
		{
			// Add ticket machine to Railroad
			RailroadUtility.AddTicketMachine(e);
		}
	}
}
