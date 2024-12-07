using StardewModdingAPI;
using TrainStation.Handlers;
using TrainStation.Utilities;

namespace TrainStation
{
	/// <summary>The mod entry point.</summary>
	internal sealed class ModEntry : Mod
	{
		// Shared static helpers
		internal static new IModHelper	Helper		{ get; private set; }
		internal static new IMonitor	Monitor		{ get; private set; }
		internal static new IManifest	ModManifest	{ get; private set; }

		public static ModConfig	Config;

		public override void Entry(IModHelper helper)
		{
			Helper = base.Helper;
			Monitor = base.Monitor;
			ModManifest = base.ModManifest;

			// Subscribe to events
			Helper.Events.GameLoop.GameLaunched += GameLaunchedHandler.Apply;
			Helper.Events.GameLoop.SaveLoaded += SaveLoadedHandler.Apply;
			Helper.Events.GameLoop.DayStarted += DayStartedHandler.Apply;
			Helper.Events.GameLoop.DayEnding += DayEndingHandler.Apply;
			Helper.Events.GameLoop.ReturnedToTitle += ReturnedToTitleHandler.Apply;
			Helper.Events.Content.AssetRequested += AssetRequestedHandler.Apply;
		}
	}
}
