using System;
using StardewValley;

namespace TrainStation.Utilities
{
	internal class TrainUtility
	{
		private static int? trainTimeCache;

		public static void Reset()
		{
			trainTimeCache = null;
		}

		public static bool IsTrainDay()
		{
			return GetTrainTime() >= 0;
		}

		public static int GetTrainTime()
		{
			if (trainTimeCache.HasValue)
			{
				return trainTimeCache.Value;
			}

			Random random = Utility.CreateDaySaveRandom();
			int trainTime = -1;

			if (random.NextDouble() < 0.2 && Game1.isLocationAccessible("Railroad"))
			{
				trainTime = random.Next(900, 1800);
				trainTime -= trainTime % 10;
				if (trainTime % 100 >= 60)
				{
					trainTime = -1;
				}
			}
			trainTimeCache = trainTime;
			return trainTimeCache.Value;
		}
	}
}
