using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using AppCore;
using AppStudio;
using AppStudio.Config;
using AppStudio.Db;
using AppStudio.Generators;

namespace DemoClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = @"C:\Users\PetarPetrov\AppData\Local\Packages\9ed4bf97-9c34-45dc-a217-5f8121aa6dfc_7gbmn9e1bm2jj\LocalState\ifsa.sqlite";

			//path = @"C:\Users\PetarPetrov\Desktop\app_studio.sqlite";

			var projectConfig = new ProjectConfig();
			projectConfig.Add(new EntityConfig(@"ACTIVATION_COMPLIANCES"));
			// TODO : !!!
			//projectConfig.Load(null); // load to a file
			//projectConfig.Save(null); // save to a file

			var cnString = $@"Data Source = {path}; Version = 3; DateTimeFormat=Ticks;";

			var classes = new StringBuilder();
			var dataprovider = new StringBuilder();

			var register = new StringBuilder();

			using (var dbContext = new DbContext(cnString))
			{
				var tables = DataProvider.GetTables(dbContext);

				foreach (var table in tables)
				{
					if (table.Name.Contains('$') ||
						table.Name.IndexOf(@"Asset_Class", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"open_bala", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"factory_cal", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Visit_dat", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Temp_data", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						continue;
					}

					//Console.WriteLine(table.Name);
					//foreach (var column in table.Columns)
					//{
					//	var fk = string.Empty;
					//	if (column.ForeignKey != null)
					//	{
					//		fk = $@"{column.ForeignKey.TableName}({column.ForeignKey.ColumnName})";
					//	}
					//	Console.WriteLine("\t" + column.Name + @":" + column.Type + @" ->" + column.IsPrimaryKey + @", " + fk);
					//}
					//Console.WriteLine();

					var buffer = new StringBuilder();

					//var config = projectConfig.GetEntityConfig(table.Name);
					//Console.WriteLine(config.ClassName);
					//Console.WriteLine(config.ClassPluralName);
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Select(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Insert(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Update(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Delete(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();



					buffer.Clear();
					CodeGenerator.GenerateClass(buffer, table, projectConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					classes.AppendLine(buffer.ToString());

					buffer.Clear();
					CodeGenerator.GenerateGetAllAsList(buffer, table, projectConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					dataprovider.AppendLine(buffer.ToString());


					//register.AppendLine($@"Console.Write(""{table.Name}"" + "" : "");");
					//register.AppendLine($@"Console.WriteLine(DataProviders.Get{projectConfig.GetEntityConfig(table.Name).ClassPluralName}(dbContext, cache).Count);");


					register.AppendLine($@"s.Add(""{table.Name}"", DataProviders.Get{projectConfig.GetEntityConfig(table.Name).ClassPluralName}(dbContext, cache).Count);");

					//code.AppendLine(buffer.ToString());
				}


				var cache = new DataCache();
				//cache.Register(DataProviders.GetBrandKinds);
				//cache.Register(DataProviders.GetBrands);
				//cache.Register(DataProviders.GetFlavours);
				//var arts = DataProviders.GetArticles(ctx, cache);
				//Console.WriteLine(arts.Count);

				var s = new Dictionary<string, int>();

				s.Add("ACTIVATION_COMPLIANCES", DataProviders.GetActivationCompliances(dbContext, cache).Count);
				s.Add("ACTIVATION_DEFINITIONS", DataProviders.GetActivationDefinitions(dbContext, cache).Count);
				s.Add("ACTIVATION_REJECTS", DataProviders.GetActivationRejects(dbContext, cache).Count);
				s.Add("ACTIVATION_STATUS", DataProviders.GetActivationStatus(dbContext, cache).Count);
				s.Add("ACTIVITIES", DataProviders.GetActivities(dbContext, cache).Count);
				s.Add("ACTIVITY_STATUSES", DataProviders.GetActivityStatuses(dbContext, cache).Count);
				s.Add("ACTIVITY_STATUS_LOG", DataProviders.GetActivityStatusLogs(dbContext, cache).Count);
				s.Add("ACTIVITY_TYPES", DataProviders.GetActivityTypes(dbContext, cache).Count);
				s.Add("ALL_ARTICLE_GROUPS", DataProviders.GetAllArticleGroups(dbContext, cache).Count);
				s.Add("ARTICLE_PRICES", DataProviders.GetArticlePrices(dbContext, cache).Count);
				s.Add("ARTICLE_SNAP", DataProviders.GetArticleSnaps(dbContext, cache).Count);
				s.Add("ARTICLE_TYPES", DataProviders.GetArticleTypes(dbContext, cache).Count);
				s.Add("ARTICLE_UNIT_CONVERSIONS", DataProviders.GetArticleUnitConversions(dbContext, cache).Count);
				s.Add("AR_BANK_DEPOSITS", DataProviders.GetArBankDeposits(dbContext, cache).Count);
				s.Add("AR_CURRENCY", DataProviders.GetArCurrencys(dbContext, cache).Count);
				s.Add("AR_INVOICES", DataProviders.GetArInvoices(dbContext, cache).Count);
				s.Add("AR_PAYMENTS", DataProviders.GetArPayments(dbContext, cache).Count);
				s.Add("AR_PAYMENT_CHEQUES", DataProviders.GetArPaymentCheques(dbContext, cache).Count);
				s.Add("AR_PAYMENT_DETAILS", DataProviders.GetArPaymentDetails(dbContext, cache).Count);
				s.Add("ASSORTMENTS", DataProviders.GetAssortments(dbContext, cache).Count);
				s.Add("ATP_ORDER_DETAILS", DataProviders.GetAtpOrderDetails(dbContext, cache).Count);
				s.Add("ATP_ORDER_MESSAGES", DataProviders.GetAtpOrderMessages(dbContext, cache).Count);
				s.Add("BEACON_LOGS", DataProviders.GetBeaconLogs(dbContext, cache).Count);
				s.Add("BUSINESS_TYPES", DataProviders.GetBusinessTypes(dbContext, cache).Count);
				s.Add("CALLING_ASSIGNMENTS", DataProviders.GetCallingAssignments(dbContext, cache).Count);
				s.Add("CALLING_ROUTES", DataProviders.GetCallingRoutes(dbContext, cache).Count);
				s.Add("CCAF_CHANNELS", DataProviders.GetCcafChannels(dbContext, cache).Count);
				s.Add("CCAF_SEGMENTS", DataProviders.GetCcafSegments(dbContext, cache).Count);
				s.Add("CC_ORDERS", DataProviders.GetCcOrders(dbContext, cache).Count);
				s.Add("CC_ORDER_DETAILS", DataProviders.GetCcOrderDetails(dbContext, cache).Count);
				s.Add("CHANNEL_ASSORTMENTS", DataProviders.GetChannelAssortments(dbContext, cache).Count);
				s.Add("CLIENT_SEQUENCES", DataProviders.GetClientSequences(dbContext, cache).Count);
				s.Add("CLIENT_VERSIONS", DataProviders.GetClientVersions(dbContext, cache).Count);
				s.Add("COMPLAINT_DETAILS", DataProviders.GetComplaintDetails(dbContext, cache).Count);
				s.Add("CONTACT_PERSONS", DataProviders.GetContactPersons(dbContext, cache).Count);
				s.Add("CONTRACT_TEMPLATES", DataProviders.GetContractTemplates(dbContext, cache).Count);
				s.Add("CUS_PLANNING_TOOL_CUST", DataProviders.GetCusPlanningToolCusts(dbContext, cache).Count);
				s.Add("CUS_POP_ASSORTMENTS", DataProviders.GetCusPopAssortments(dbContext, cache).Count);
				s.Add("CUS_SURVEYS", DataProviders.GetCusSurveys(dbContext, cache).Count);
				s.Add("CUS_SURVEYS_HIER_NODES", DataProviders.GetCusSurveysHierNodes(dbContext, cache).Count);
				s.Add("DELIVERY_HIST_DETAILS", DataProviders.GetDeliveryHistDetails(dbContext, cache).Count);
				s.Add("DELIVERY_HIST_HEADERS", DataProviders.GetDeliveryHistHeaders(dbContext, cache).Count);
				s.Add("DELIVERY_LEAD_TIMES", DataProviders.GetDeliveryLeadTimes(dbContext, cache).Count);
				s.Add("DELIVERY_LOCATIONS", DataProviders.GetDeliveryLocations(dbContext, cache).Count);
				s.Add("DELIVERY_TRANSACTIONS", DataProviders.GetDeliveryTransactions(dbContext, cache).Count);
				s.Add("DELIVERY_TYPES", DataProviders.GetDeliveryTypes(dbContext, cache).Count);
				s.Add("EQUIPMENT", DataProviders.GetEquipments(dbContext, cache).Count);
				s.Add("EQUIPMENT_ACTIVITY", DataProviders.GetEquipmentActivitys(dbContext, cache).Count);
				s.Add("EQUIPMENT_CHECK", DataProviders.GetEquipmentChecks(dbContext, cache).Count);
				s.Add("EQUIPMENT_MATRIX", DataProviders.GetEquipmentMatrixs(dbContext, cache).Count);
				s.Add("EQUIPMENT_MATRIX_TYPES", DataProviders.GetEquipmentMatrixTypes(dbContext, cache).Count);
				s.Add("EQUIPMENT_MESSAGES", DataProviders.GetEquipmentMessages(dbContext, cache).Count);
				s.Add("EQUIPMENT_TYPES", DataProviders.GetEquipmentTypes(dbContext, cache).Count);
				s.Add("EQUIPMENT_TYPE_IMAGES", DataProviders.GetEquipmentTypeImages(dbContext, cache).Count);
				s.Add("GPS_DATA", DataProviders.GetGpsDatas(dbContext, cache).Count);
				s.Add("HOLIDAYS", DataProviders.GetHolidays(dbContext, cache).Count);
				s.Add("INVENTORY_DETAILS", DataProviders.GetInventoryDetails(dbContext, cache).Count);
				s.Add("INVENTORY_HEADERS", DataProviders.GetInventoryHeaders(dbContext, cache).Count);
				s.Add("LINKED_WHOLESALERS", DataProviders.GetLinkedWholesalers(dbContext, cache).Count);
				s.Add("MATERIAL_CATEGORIES", DataProviders.GetMaterialCategories(dbContext, cache).Count);
				s.Add("MEASURE_DOMAINS", DataProviders.GetMeasureDomains(dbContext, cache).Count);
				s.Add("MEASURE_DOMAIN_LOVS", DataProviders.GetMeasureDomainLovs(dbContext, cache).Count);
				s.Add("MEASURE_NODES", DataProviders.GetMeasureNodes(dbContext, cache).Count);
				s.Add("MEASURE_VALUES", DataProviders.GetMeasureValues(dbContext, cache).Count);
				s.Add("ORDER_DATE_OUTLET_CPLS", DataProviders.GetOrderDateOutletCpls(dbContext, cache).Count);
				s.Add("ORDER_DETAILS", DataProviders.GetOrderDetails(dbContext, cache).Count);
				s.Add("ORDER_DETAIL_PROMOTIONS", DataProviders.GetOrderDetailPromotions(dbContext, cache).Count);
				s.Add("ORDER_FREE_PRODUCTS", DataProviders.GetOrderFreeProducts(dbContext, cache).Count);
				s.Add("ORDER_HEADERS", DataProviders.GetOrderHeaders(dbContext, cache).Count);
				s.Add("ORDER_TEXTS", DataProviders.GetOrderTexts(dbContext, cache).Count);
				s.Add("ORDER_TYPES", DataProviders.GetOrderTypes(dbContext, cache).Count);
				s.Add("OUTLETS_EXTENSIONS", DataProviders.GetOutletsExtensions(dbContext, cache).Count);
				s.Add("OUTLET_ADDRESSES", DataProviders.GetOutletAddresses(dbContext, cache).Count);
				s.Add("OUTLET_CLUSTERS", DataProviders.GetOutletClusters(dbContext, cache).Count);
				s.Add("OUTLET_HIER_LEVELS", DataProviders.GetOutletHierLevels(dbContext, cache).Count);
				s.Add("OUTLET_MARKET_ATTRIBUTES", DataProviders.GetOutletMarketAttributes(dbContext, cache).Count);
				s.Add("OUTLET_RULES", DataProviders.GetOutletRules(dbContext, cache).Count);
				s.Add("OUTLET_SNAP", DataProviders.GetOutletSnaps(dbContext, cache).Count);
				s.Add("OUTLET_TEXTS", DataProviders.GetOutletTexts(dbContext, cache).Count);
				s.Add("PARAMETERS", DataProviders.GetParameters(dbContext, cache).Count);
				s.Add("PAYER_OUTLETS", DataProviders.GetPayerOutlets(dbContext, cache).Count);
				s.Add("PHPOOLEDSNAPCOLUMNDESC", DataProviders.GetPhpooledsnapcolumndescs(dbContext, cache).Count);
				s.Add("PLACEMENT_REQUESTS", DataProviders.GetPlacementRequests(dbContext, cache).Count);
				s.Add("PLANNED_VOLUMES", DataProviders.GetPlannedVolumes(dbContext, cache).Count);
				s.Add("PLANNING_TOOL_DAILY_CUSTOMS", DataProviders.GetPlanningToolDailyCustoms(dbContext, cache).Count);
				s.Add("PLANNING_TOOL_DAILY_TARGETS", DataProviders.GetPlanningToolDailyTargets(dbContext, cache).Count);
				s.Add("PLANNING_TOOL_DAILY_VOLUMES", DataProviders.GetPlanningToolDailyVolumes(dbContext, cache).Count);
				s.Add("PLANNING_TOOL_TARGETS", DataProviders.GetPlanningToolTargets(dbContext, cache).Count);
				s.Add("PLANNING_TOOL_TEAMS", DataProviders.GetPlanningToolTeams(dbContext, cache).Count);
				s.Add("PLANNING_TOOL_USERS", DataProviders.GetPlanningToolUsers(dbContext, cache).Count);
				s.Add("POP_ARTICLES", DataProviders.GetPopArticles(dbContext, cache).Count);
				s.Add("POP_ENTRIES", DataProviders.GetPopEntries(dbContext, cache).Count);
				s.Add("PROMOTION_HEADERS", DataProviders.GetPromotionHeaders(dbContext, cache).Count);
				s.Add("PROMOTION_PRD_ITEMS", DataProviders.GetPromotionPrdItems(dbContext, cache).Count);
				s.Add("PROMO_MECHANICS_HEADERS", DataProviders.GetPromoMechanicsHeaders(dbContext, cache).Count);
				s.Add("PROMO_PARTNERS_HIERARCHY", DataProviders.GetPromoPartnersHierarchys(dbContext, cache).Count);
				s.Add("PROMO_SCALES", DataProviders.GetPromoScales(dbContext, cache).Count);
				s.Add("RED_ACTIVITIES_LOG", DataProviders.GetRedActivitiesLogs(dbContext, cache).Count);
				s.Add("RED_CCC_H", DataProviders.GetRedCccHs(dbContext, cache).Count);
				s.Add("RED_CCC_LIST", DataProviders.GetRedCccLists(dbContext, cache).Count);
				s.Add("RED_CCC_OUTL", DataProviders.GetRedCccOutls(dbContext, cache).Count);
				s.Add("RED_CCC_PAR_VAL", DataProviders.GetRedCccParVals(dbContext, cache).Count);
				s.Add("RED_CCC_TARG", DataProviders.GetRedCccTargs(dbContext, cache).Count);
				s.Add("RED_CCC_TAR_VAL", DataProviders.GetRedCccTarVals(dbContext, cache).Count);
				s.Add("RED_GAPS_ACTIONS", DataProviders.GetRedGapsActions(dbContext, cache).Count);
				s.Add("RED_GAPS_PLANNING", DataProviders.GetRedGapsPlannings(dbContext, cache).Count);
				s.Add("RED_LISTING_ANSWERS", DataProviders.GetRedListingAnswers(dbContext, cache).Count);
				s.Add("RED_LISTING_HEADERS", DataProviders.GetRedListingHeaders(dbContext, cache).Count);
				s.Add("RED_LISTING_ITEMS", DataProviders.GetRedListingItems(dbContext, cache).Count);
				s.Add("RED_LIST_MAPPING", DataProviders.GetRedListMappings(dbContext, cache).Count);
				s.Add("RED_LIST_PARAMS", DataProviders.GetRedListParams(dbContext, cache).Count);
				s.Add("RED_MAPPING", DataProviders.GetRedMappings(dbContext, cache).Count);
				s.Add("RED_PARAMS_VALUES", DataProviders.GetRedParamsValues(dbContext, cache).Count);
				s.Add("RED_POS_DESCRIPTIONS", DataProviders.GetRedPosDescriptions(dbContext, cache).Count);
				s.Add("SALES_DISTRICTS", DataProviders.GetSalesDistricts(dbContext, cache).Count);
				s.Add("SAP_ACTIVITY_HISTORY", DataProviders.GetSapActivityHistorys(dbContext, cache).Count);
				s.Add("SAP_ACTIVITY_HISTORY_DETAILS", DataProviders.GetSapActivityHistoryDetails(dbContext, cache).Count);
				s.Add("SAP_ACTIVITY_PROC_TYPES", DataProviders.GetSapActivityProcTypes(dbContext, cache).Count);
				s.Add("SHIP_TO_OUTLETS", DataProviders.GetShipToOutlets(dbContext, cache).Count);
				s.Add("SMART_DEVICE_TYPES", DataProviders.GetSmartDeviceTypes(dbContext, cache).Count);
				s.Add("STATUS_LISTS", DataProviders.GetStatusLists(dbContext, cache).Count);
				s.Add("SUB_TRADE_CHANNELS", DataProviders.GetSubTradeChannels(dbContext, cache).Count);
				s.Add("SURVEYS", DataProviders.GetSurveys(dbContext, cache).Count);
				s.Add("SURVEY_ACTIVITIES", DataProviders.GetSurveyActivities(dbContext, cache).Count);
				s.Add("TRACING", DataProviders.GetTracings(dbContext, cache).Count);
				s.Add("TRADE_CHANNELS", DataProviders.GetTradeChannels(dbContext, cache).Count);
				s.Add("USER_MESSAGES", DataProviders.GetUserMessages(dbContext, cache).Count);
				s.Add("USER_ROUTE_SNAP", DataProviders.GetUserRouteSnaps(dbContext, cache).Count);
				s.Add("USER_SETTINGS", DataProviders.GetUserSettings(dbContext, cache).Count);
				s.Add("USER_SNAP", DataProviders.GetUserSnaps(dbContext, cache).Count);
				s.Add("VISITS", DataProviders.GetVisits(dbContext, cache).Count);
				s.Add("VISIT_COMMENTS", DataProviders.GetVisitComments(dbContext, cache).Count);
				s.Add("WHOLESALERS", DataProviders.GetWholesalers(dbContext, cache).Count);

				var vals = s
					.Where(v => v.Value != 0)
					.Select(v => Tuple.Create(v.Key, v.Value))
					.ToList();
				vals.Sort((x, y) =>
					{
						var cmp = y.Item2.CompareTo(x.Item2);
						if (cmp == 0)
						{
							cmp = string.Compare(x.Item1, y.Item1, StringComparison.OrdinalIgnoreCase);
						}
						return cmp;
					}
				);

				foreach (var v in vals)
				{
					Console.WriteLine(v);
				}


				dbContext.Complete();
			}

			var code = classes.ToString();
			var data = dataprovider.ToString();
			Console.WriteLine(code.Length);
			Console.WriteLine(data.Length);

			foreach (var s in register.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
			{
				Debug.WriteLine(s);
			}

			File.WriteAllText(@"C:\Atos\AppStudio\Objects.cs", string.Format(@"using System;

namespace AppStudio
{{
	{0}
}}
", code));

			File.WriteAllText(@"C:\Atos\AppStudio\DataProviders.cs", string.Format(@"using System;
using System.Collections.Generic;
using AppCore;
using AppCore.Data;

namespace AppStudio
{{
	public static class DataProviders
	{{
		{0}
	}}
}}
", data));



			//Console.WriteLine();
			//foreach (var t in DataProvider.AllTypes)
			//{
			//	Console.WriteLine(t);
			//}
		}


	}
}
