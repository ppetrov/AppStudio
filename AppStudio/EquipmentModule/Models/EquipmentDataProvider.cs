using System;
using System.Collections.Generic;
using System.Linq;
using AppCore;
using AppCore.Data;

namespace AppStudio.EquipmentModule.Models
{
	// TODO : Generate this class
	public static class EquipmentDataProvider
	{
		public static List<Equipment> GetEquipments(MainContext mainContext)
		{
			if (mainContext == null) throw new ArgumentNullException(nameof(mainContext));

			List<Equipment> equipments;

			using (var dbContext = mainContext.GetService<IDbContext>())
			{
				var query = new Query<Equipment>(@"SELECT Id, Serial_Number, Power, Last_Checked FROM Equipments", r =>
				{
					var id = Query.GetLong(r, 0);
					var serialNumber = Query.GetString(r, 1);
					var power = Query.GetDecimal(r, 2);
					var lastChecked = Query.GetDateTime(r, 3);

					return new Equipment(id, serialNumber, power, lastChecked);
				});

				equipments = dbContext.Execute(query).ToList();

				dbContext.Complete();
			}

			return equipments;
		}
	}
}