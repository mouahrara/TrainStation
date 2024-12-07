using xTile;
using xTile.Tiles;
using xTile.Layers;
using xTile.Dimensions;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace TrainStation.Utilities
{
	internal class RailroadUtility
	{
		public static void AddTicketMachine(AssetRequestedEventArgs e)
		{
			if (e.NameWithoutLocale.IsEquivalentTo("Maps/Railroad"))
			{
				e.Edit(asset =>
				{
					AddTicketMachine(asset.AsMap().Data);
					RemoveCenterColumn(asset.AsMap().Data);
				});
			}
		}

		public static void AddTicketMachine()
		{
			GameLocation location = Game1.getLocationFromName("Railroad");

			if (location is not null)
			{
				AddTicketMachine(location.Map);
			}
		}

		private static void AddTicketMachine(Map map)
		{
			Layer frontLayer = map.GetLayer("Front");
			Layer buildingsLayer = map.GetLayer("Buildings");
			TileSheet tileSheet = map.GetTileSheet("untitled tile sheet");

			if (frontLayer is not null && buildingsLayer is not null)
			{
				Location frontPosition = new(ModEntry.Config.TicketMachineTilePoint.X, ModEntry.Config.TicketMachineTilePoint.Y - 1);
				Location buildingsPosition = new(ModEntry.Config.TicketMachineTilePoint.X, ModEntry.Config.TicketMachineTilePoint.Y);

				if (!frontLayer.IsValidTileLocation(frontPosition))
				{
					ModEntry.Monitor.Log($"Failed to add ticket machine: The ticket machine coordinates ({frontPosition.X}, {frontPosition.Y}) are outside the map boundaries ({frontLayer.LayerWidth - 1} x {frontLayer.LayerHeight - 1}).", LogLevel.Error);
					return;
				}
				if (!buildingsLayer.IsValidTileLocation(buildingsPosition))
				{
					ModEntry.Monitor.Log($"Failed to add ticket machine: The ticket machine coordinates ({buildingsPosition.X}, {buildingsPosition.Y}) are outside the map boundaries ({buildingsLayer.LayerWidth - 1} x {buildingsLayer.LayerHeight - 1}).", LogLevel.Error);
					return;
				}
				frontLayer.Tiles[frontPosition] = new StaticTile(frontLayer, tileSheet, BlendMode.Alpha, 1032);
				buildingsLayer.Tiles[buildingsPosition] = new StaticTile(buildingsLayer, tileSheet, BlendMode.Alpha, 1057);
			}
		}

		public static void RemoveCenterColumn()
		{
			GameLocation location = Game1.getLocationFromName("Railroad");

			if (location is not null)
			{
				RemoveCenterColumn(location.Map);
			}
		}

		private static void RemoveCenterColumn(Map map)
		{
			const string tileSheetId = "untitled tile sheet";
			Layer alwaysFrontLayer = map.GetLayer("AlwaysFront");
			Layer frontLayer = map.GetLayer("Front");
			Layer buildingsLayer = map.GetLayer("Buildings");
			Layer backLayer = map.GetLayer("Back");
			Location alwaysFrontPosition = new(42, 39);
			Location frontPosition = new(42, 40);
			Location buildingsPosition = new(42, 41);
			Location backPosition = new(41, 41);

			if (alwaysFrontLayer is not null && frontLayer is not null && buildingsLayer is not null && backLayer is not null)
			{
				Tile alwaysFrontTile = alwaysFrontLayer.Tiles[alwaysFrontPosition];
				Tile frontTile = frontLayer.Tiles[frontPosition];
				Tile buildingsTile = buildingsLayer.Tiles[buildingsPosition];
				Tile backTile = backLayer.Tiles[backPosition];

				if (alwaysFrontTile is not null && frontTile is not null && buildingsTile is not null && backTile is not null)
				{
					if (alwaysFrontTile.TileSheet.Id.Equals(tileSheetId) && alwaysFrontTile.TileIndex == 1154 && frontTile.TileSheet.Id.Equals(tileSheetId) && frontTile.TileIndex == 1179 && buildingsTile.TileSheet.Id.Equals(tileSheetId) && buildingsTile.TileIndex == 1204 && backTile.TileSheet.Id.Equals(tileSheetId) && backTile.TileIndex == 1206)
					{
						alwaysFrontLayer.Tiles[alwaysFrontPosition].TileIndex = 1156;
						frontLayer.Tiles[frontPosition] = null;
						buildingsLayer.Tiles[buildingsPosition] = null;
						backLayer.Tiles[backPosition].TileIndex = 1151;
					}
				}
			}
		}
	}
}
