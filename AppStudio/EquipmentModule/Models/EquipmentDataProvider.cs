using System;
using System.Collections.Generic;
using AppCore;
using AppCore.Data;

namespace AppStudio.EquipmentModule.Models
{
	// TODO : Copy properties for caption
	public sealed class EquipmentDataProvider
	{
		public IEnumerable<Equipment> GetEquipments(MainContext mainContext, EquipmentsParameters parameters)
		{
			if (mainContext == null) throw new ArgumentNullException(nameof(mainContext));
			if (parameters == null) throw new ArgumentNullException(nameof(parameters));

			var equipments = default(IEnumerable<Equipment>);

			using (var ctx = mainContext.GetService<IDbContext>())
			{
				equipments = GetEquipments2(ctx);

				ctx.Complete();
			}

			return equipments;
		}

		public static IEnumerable<Equipment> GetEquipments2(IDbContext dbContext)
		{
			if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

			var query = new Query<Equipment>(@"SELECT Id, Serial_Number, Power, Last_Checked FROM Equipments", r =>
			{
				var id = Query.GetLong(r, 0);
				var serialNumber = Query.GetString(r, 1);
				var power = Query.GetDecimal(r, 2);
				var lastChecked = Query.GetDateTime(r, 3);

				return new Equipment(id, serialNumber, power, lastChecked);
			});

			return dbContext.Execute(query);
		}

	}
}