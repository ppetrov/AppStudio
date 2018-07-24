using System;
using System.Collections.Generic;
using AppStudio.Data;

namespace AppStudio
{
	public sealed class ActivationCompliance
	{
		public string ActivationId { get; }
		public int ActivationIndex { get; }
		public string ParamName { get; }
		public string ParamValue { get; }

		public ActivationCompliance(string activationId, int activationIndex, string paramName, string paramValue)
		{
			if (activationId == null) throw new ArgumentNullException(nameof(activationId));
			if (paramName == null) throw new ArgumentNullException(nameof(paramName));
			if (paramValue == null) throw new ArgumentNullException(nameof(paramValue));

			this.ActivationId = activationId;
			this.ActivationIndex = activationIndex;
			this.ParamName = paramName;
			this.ParamValue = paramValue;
		}

		public static List<ActivationCompliance> GetActivationCompliance(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivationCompliance>();

			var query = new Query<ActivationCompliance>(@"SELECT ACTIVATION_ID, ACTIVATION_INDEX, PARAM_NAME, PARAM_VALUE FROM ACTIVATION_COMPLIANCES", r =>
			{
				return null;
			});

			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}
	}



	

}