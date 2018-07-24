using System;
using System.Collections.Generic;
using AppStudio.Data;

namespace AppStudio
{
	public class Class2
	{


		public static List<ActivationCompliance> GetActivationCompliances(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivationCompliance>();

			var query = new Query<ActivationCompliance>(@"SELECT ACTIVATION_ID, ACTIVATION_INDEX, PARAM_NAME, PARAM_VALUE FROM ACTIVATION_COMPLIANCES", r =>
			{
				var activationId = string.Empty;
				var activationIndex = 0;
				var paramName = string.Empty;
				var paramValue = string.Empty;
				return new ActivationCompliance(activationId, activationIndex, paramName, paramValue);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ActivationDefinition> GetActivationDefinitions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivationDefinition>();

			var query = new Query<ActivationDefinition>(@"SELECT ACTIVATION_ID, ACTIVATION_NAME, ACTIVATION_DESC, ACTIVATION_START, ACTIVATION_END, ACTIVATION_TYPE, IS_MANDATORY, IS_GENERATOR, STATUS, LINKED_DOC, ZONE_SUBZONE, PROMO_COMPLIANCE, POP_ACTIVATION, QUANT_OF_POI, SIZE_OF_POI, CUST_SPACE_TYPE_CODE, CUST_SPACE_TYPE_TEXT, TARGET_ZONE FROM ACTIVATION_DEFINITIONS", r =>
			{
				var activationId = string.Empty;
				var activationName = string.Empty;
				var activationDesc = string.Empty;
				var activationStart = DateTime.MinValue;
				var activationEnd = DateTime.MinValue;
				var activationType = string.Empty;
				var isMandatory = 0;
				var isGenerator = 0;
				var status = string.Empty;
				var linkedDoc = string.Empty;
				var zoneSubzone = string.Empty;
				var promoCompliance = string.Empty;
				var popActivation = string.Empty;
				var quantOfPoi = string.Empty;
				var sizeOfPoi = string.Empty;
				var custSpaceTypeCode = string.Empty;
				var custSpaceTypeText = string.Empty;
				var targetZone = string.Empty;
				return new ActivationDefinition(activationId, activationName, activationDesc, activationStart, activationEnd, activationType, isMandatory, isGenerator, status, linkedDoc, zoneSubzone, promoCompliance, popActivation, quantOfPoi, sizeOfPoi, custSpaceTypeCode, custSpaceTypeText, targetZone);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ActivationReject> GetActivationRejects(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivationReject>();

			var query = new Query<ActivationReject>(@"SELECT Id, Outlet, Activation FROM ACTIVATION_REJECTS", r =>
			{
				var id = 0L;
				var outlet = 0L;
				var activation = string.Empty;
				return new ActivationReject(id, outlet, activation);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ActivationStatu> GetActivationStatus(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivationStatu>();

			var query = new Query<ActivationStatu>(@"SELECT ACTIVATION_ID, QUANTITY_OF_POI, EXECUTED_POI FROM ACTIVATION_STATUS", r =>
			{
				var activationId = string.Empty;
				var quantityOfPoi = 0L;
				var executedPoi = 0L;
				return new ActivationStatu(activationId, quantityOfPoi, executedPoi);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Activitie> GetActivities(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Activitie>();

			var query = new Query<Activitie>(@"SELECT DETAILS, FINISH_TIME, ID, ORIGIN, PRODUCTIVE_TIME, SEQUENCE, START_TIME, STATUS_ID, TYPE_ID, VISIT_ID, STATUS_REASON_LIST_ID, REASON_LIST_ID, SUB_REASON_LIST_ID, SURVEY_ID, STATUS_LIST_ID, ACTUAL_FROM, ACTUAL_TO, DESCRIPTION, SAP_ID, SAP_REASON_LIST_ID, PARENT_ACTIVITY_ID, HEADER_GUID, IS_GPS_TURNED_ON, ACTIVATION_ID FROM ACTIVITIES", r =>
			{
				var details = string.Empty;
				var finishTime = DateTime.MinValue;
				var id = 0L;
				var origin = string.Empty;
				var productiveTime = 0L;
				var sequence = 0;
				var startTime = DateTime.MinValue;
				var statusId = 0;
				var typeId = 0;
				var visitId = 0L;
				var statusReasonListId = 0L;
				var reasonListId = 0L;
				var subReasonListId = 0L;
				var surveyId = 0L;
				var statusListId = 0L;
				var actualFrom = DateTime.MinValue;
				var actualTo = DateTime.MinValue;
				var description = string.Empty;
				var sapId = 0L;
				var sapReasonListId = 0L;
				var parentActivityId = 0L;
				var headerGuid = string.Empty;
				var isGpsTurnedOn = 0;
				var activationId = string.Empty;
				return new Activitie(details, finishTime, id, origin, productiveTime, sequence, startTime, statusId, typeId, visitId, statusReasonListId, reasonListId, subReasonListId, surveyId, statusListId, actualFrom, actualTo, description, sapId, sapReasonListId, parentActivityId, headerGuid, isGpsTurnedOn, activationId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ActivityStatuse> GetActivityStatuses(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivityStatuse>();

			var query = new Query<ActivityStatuse>(@"SELECT DESCRIPTION, ID, NAME FROM ACTIVITY_STATUSES", r =>
			{
				var description = string.Empty;
				var id = 0;
				var name = string.Empty;
				return new ActivityStatuse(description, id, name);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ActivityStatusLog> GetActivityStatusLogs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivityStatusLog>();

			var query = new Query<ActivityStatusLog>(@"SELECT ACTIVITY_ID, TEXT, STATUS_TYPE FROM ACTIVITY_STATUS_LOG", r =>
			{
				var activityId = 0L;
				var text = string.Empty;
				var statusType = 0;
				return new ActivityStatusLog(activityId, text, statusType);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ActivityType> GetActivityTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ActivityType>();

			var query = new Query<ActivityType>(@"SELECT DESCRIPTION, ID, IS_ACTIVE, LOCAL_NAME, NAME, SAP_CODE, CATEGORY FROM ACTIVITY_TYPES", r =>
			{
				var description = string.Empty;
				var id = 0;
				var isActive = 0;
				var localName = string.Empty;
				var name = string.Empty;
				var sapCode = string.Empty;
				var category = string.Empty;
				return new ActivityType(description, id, isActive, localName, name, sapCode, category);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<AllArticleGroup> GetAllArticleGroups(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<AllArticleGroup>();

			var query = new Query<AllArticleGroup>(@"SELECT ART_GROUP, PRC_GROUP, DESCRIPTION FROM ALL_ARTICLE_GROUPS", r =>
			{
				var artGroup = 0L;
				var prcGroup = string.Empty;
				var description = string.Empty;
				return new AllArticleGroup(artGroup, prcGroup, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArticlePrice> GetArticlePrices(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArticlePrice>();

			var query = new Query<ArticlePrice>(@"SELECT ARTICLE_NUMBER, CURRENCY, PRICE, PRICE_GROUP, VALID_FROM, VALID_TO FROM ARTICLE_PRICES", r =>
			{
				var articleNumber = 0L;
				var currency = string.Empty;
				var price = 0M;
				var priceGroup = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new ArticlePrice(articleNumber, currency, price, priceGroup, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArticleSnap> GetArticleSnaps(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArticleSnap>();

			var query = new Query<ArticleSnap>(@"SELECT ARTICLES_PER_PALETTE, ARTICLE_GROUP1_BCODE, ARTICLE_GROUP1_DESC, ARTICLE_GROUP2_BCODE, ARTICLE_GROUP2_DESC, ARTICLE_GROUP3_BCODE, ARTICLE_GROUP3_DESC, ARTICLE_GROUP4_BCODE, ARTICLE_GROUP4_DESC, ARTICLE_GROUP5_BCODE, ARTICLE_GROUP5_DESC, ARTICLE_NUMBER, ARTICLE_TYPE_CODE, CONVFACTOR1, CONVFACTOR2, CUBE, EANCODE, EANSUBUNITCODE, EMPTIES_ARTICLE_NUMBER, EMPTIES_SUBUNIT_ARTICLE_NUMBER, LONG_NAME, MATERIAL_CATEGORY_CODE, PRICE, SEQUENCE, SHORT_NAME, SUBUNITS, SUPPRDATE, SUPPRESSED_CODE, WEIGHT, EXTERNAL_NUMBER, BASE_UNIT, BASE_SUBUNIT, BASE_ARTICLE_NUMBER, MATERIAL_PRICING_GROUP FROM ARTICLE_SNAP", r =>
			{
				var articlesPerPalette = 0;
				var articleGroup1Bcode = string.Empty;
				var articleGroup1Desc = string.Empty;
				var articleGroup2Bcode = string.Empty;
				var articleGroup2Desc = string.Empty;
				var articleGroup3Bcode = string.Empty;
				var articleGroup3Desc = string.Empty;
				var articleGroup4Bcode = string.Empty;
				var articleGroup4Desc = string.Empty;
				var articleGroup5Bcode = string.Empty;
				var articleGroup5Desc = string.Empty;
				var articleNumber = 0L;
				var articleTypeCode = 0L;
				var convfactor1 = 0M;
				var convfactor2 = 0M;
				var cube = 0M;
				var eancode = string.Empty;
				var eansubunitcode = string.Empty;
				var emptiesArticleNumber = 0L;
				var emptiesSubunitArticleNumber = 0L;
				var longName = string.Empty;
				var materialCategoryCode = 0L;
				var price = 0M;
				var sequence = 0;
				var shortName = string.Empty;
				var subunits = 0L;
				var supprdate = DateTime.MinValue;
				var suppressedCode = string.Empty;
				var weight = 0M;
				var externalNumber = string.Empty;
				var baseUnit = string.Empty;
				var baseSubunit = string.Empty;
				var baseArticleNumber = 0L;
				var materialPricingGroup = string.Empty;
				return new ArticleSnap(articlesPerPalette, articleGroup1Bcode, articleGroup1Desc, articleGroup2Bcode, articleGroup2Desc, articleGroup3Bcode, articleGroup3Desc, articleGroup4Bcode, articleGroup4Desc, articleGroup5Bcode, articleGroup5Desc, articleNumber, articleTypeCode, convfactor1, convfactor2, cube, eancode, eansubunitcode, emptiesArticleNumber, emptiesSubunitArticleNumber, longName, materialCategoryCode, price, sequence, shortName, subunits, supprdate, suppressedCode, weight, externalNumber, baseUnit, baseSubunit, baseArticleNumber, materialPricingGroup);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArticleType> GetArticleTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArticleType>();

			var query = new Query<ArticleType>(@"SELECT CODE, MTART, DESCRIPTION FROM ARTICLE_TYPES", r =>
			{
				var code = 0L;
				var mtart = string.Empty;
				var description = string.Empty;
				return new ArticleType(code, mtart, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArticleUnitConversion> GetArticleUnitConversions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArticleUnitConversion>();

			var query = new Query<ArticleUnitConversion>(@"SELECT ARTICLE_NUMBER, DENOMINATOR, EXPONENT10, IS_BASE_UNIT, NUMERATOR, UNIT, VALID_FROM, VALID_TO FROM ARTICLE_UNIT_CONVERSIONS", r =>
			{
				var articleNumber = 0L;
				var denominator = 0L;
				var exponent10 = 0;
				var isBaseUnit = 0;
				var numerator = 0L;
				var unit = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new ArticleUnitConversion(articleNumber, denominator, exponent10, isBaseUnit, numerator, unit, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArBankDeposit> GetArBankDeposits(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArBankDeposit>();

			var query = new Query<ArBankDeposit>(@"SELECT BANK_NAME, CASH_DEPOSIT_AMOUNT, CHEQUE_DEPOSIT_AMOUNT, DEPOSIT_DATE, DEPOSIT_KEY, DEPOSIT_SLIP_NUMBER, ID, IS_CLOSED, NIGHT_SAFE, OTHERS_AMOUNT, USER_ID FROM AR_BANK_DEPOSITS", r =>
			{
				var bankName = string.Empty;
				var cashDepositAmount = 0M;
				var chequeDepositAmount = 0M;
				var depositDate = DateTime.MinValue;
				var depositKey = string.Empty;
				var depositSlipNumber = string.Empty;
				var id = 0L;
				var isClosed = 0;
				var nightSafe = 0;
				var othersAmount = 0M;
				var userId = 0L;
				return new ArBankDeposit(bankName, cashDepositAmount, chequeDepositAmount, depositDate, depositKey, depositSlipNumber, id, isClosed, nightSafe, othersAmount, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArCurrency> GetArCurrencys(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArCurrency>();

			var query = new Query<ArCurrency>(@"SELECT DESCRIPTION, ID, IS_DEFAULT, LOCAL_DESCRIPTION, SHORT_NAME FROM AR_CURRENCY", r =>
			{
				var description = string.Empty;
				var id = 0L;
				var isDefault = 0;
				var localDescription = string.Empty;
				var shortName = string.Empty;
				return new ArCurrency(description, id, isDefault, localDescription, shortName);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArInvoice> GetArInvoices(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArInvoice>();

			var query = new Query<ArInvoice>(@"SELECT DUE_DATE, ID, INVOICE_DATE, INVOICE_NUMBER, IS_DELETED, NOTE, OPEN_AMOUNT, OUTLET_NUMBER, PAYER_NUMBER, TOTAL_AMOUNT FROM AR_INVOICES", r =>
			{
				var dueDate = DateTime.MinValue;
				var id = 0L;
				var invoiceDate = DateTime.MinValue;
				var invoiceNumber = string.Empty;
				var isDeleted = 0;
				var note = string.Empty;
				var openAmount = 0M;
				var outletNumber = 0L;
				var payerNumber = 0L;
				var totalAmount = 0M;
				return new ArInvoice(dueDate, id, invoiceDate, invoiceNumber, isDeleted, note, openAmount, outletNumber, payerNumber, totalAmount);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArPayment> GetArPayments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArPayment>();

			var query = new Query<ArPayment>(@"SELECT ACTIVITY_ID, BANK_DEPOSIT_ID, CASH_PAID_AMOUNT, CURRENCY_ID, CUSTOMER_RECEIPT_NBR, DELIVERY_DOC_NBR, ID, NOTE, OTHERS_AMOUNT, OTHERS_DESCRIPTION, PAYMENT_DATE, PRINT_TIME, TOTALS_AMOUNT FROM AR_PAYMENTS", r =>
			{
				var activityId = 0L;
				var bankDepositId = 0L;
				var cashPaidAmount = 0M;
				var currencyId = 0L;
				var customerReceiptNbr = string.Empty;
				var deliveryDocNbr = string.Empty;
				var id = 0L;
				var note = string.Empty;
				var othersAmount = 0M;
				var othersDescription = string.Empty;
				var paymentDate = DateTime.MinValue;
				var printTime = DateTime.MinValue;
				var totalsAmount = 0M;
				return new ArPayment(activityId, bankDepositId, cashPaidAmount, currencyId, customerReceiptNbr, deliveryDocNbr, id, note, othersAmount, othersDescription, paymentDate, printTime, totalsAmount);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArPaymentCheque> GetArPaymentCheques(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArPaymentCheque>();

			var query = new Query<ArPaymentCheque>(@"SELECT BANK_NAME, CHEQUE_NUMBER, PAID_AMOUNT, PAYMENT_ID, VALID_FROM, VALID_TO FROM AR_PAYMENT_CHEQUES", r =>
			{
				var bankName = string.Empty;
				var chequeNumber = string.Empty;
				var paidAmount = 0M;
				var paymentId = 0L;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new ArPaymentCheque(bankName, chequeNumber, paidAmount, paymentId, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ArPaymentDetail> GetArPaymentDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ArPaymentDetail>();

			var query = new Query<ArPaymentDetail>(@"SELECT BANK_DEPOSIT_ID, INVOICE_ID, IS_PARTIAL, OPEN_AMOUNT, PAID_AMOUNT, PAYMENT_ID FROM AR_PAYMENT_DETAILS", r =>
			{
				var bankDepositId = 0L;
				var invoiceId = 0L;
				var isPartial = 0;
				var openAmount = 0M;
				var paidAmount = 0M;
				var paymentId = 0L;
				return new ArPaymentDetail(bankDepositId, invoiceId, isPartial, openAmount, paidAmount, paymentId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Assortment> GetAssortments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Assortment>();

			var query = new Query<Assortment>(@"SELECT ARTICLENUMBER, OUTLETNUMBER, SEQUENCE FROM ASSORTMENTS", r =>
			{
				var articlenumber = 0L;
				var outletnumber = 0L;
				var sequence = 0L;
				return new Assortment(articlenumber, outletnumber, sequence);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<AtpOrderDetail> GetAtpOrderDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<AtpOrderDetail>();

			var query = new Query<AtpOrderDetail>(@"SELECT ARTICLE_NUMBER, ATP_ALT_PRODUCT, ATP_CONFIRMED_QUANTITY, ATP_ITEM_TYPE, ATP_ORDERED_QUANTITY, ATP_PRICE, ATP_PROMOTION, ATP_QUANTITY_UNITS, ATP_STATUS, ATP_VENDOR, ORDER_NUMBER, SEQUENTIAL_NUMBER FROM ATP_ORDER_DETAILS", r =>
			{
				var articleNumber = 0L;
				var atpAltProduct = 0L;
				var atpConfirmedQuantity = 0M;
				var atpItemType = string.Empty;
				var atpOrderedQuantity = 0M;
				var atpPrice = 0M;
				var atpPromotion = string.Empty;
				var atpQuantityUnits = string.Empty;
				var atpStatus = string.Empty;
				var atpVendor = string.Empty;
				var orderNumber = 0L;
				var sequentialNumber = 0L;
				return new AtpOrderDetail(articleNumber, atpAltProduct, atpConfirmedQuantity, atpItemType, atpOrderedQuantity, atpPrice, atpPromotion, atpQuantityUnits, atpStatus, atpVendor, orderNumber, sequentialNumber);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<AtpOrderMessage> GetAtpOrderMessages(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<AtpOrderMessage>();

			var query = new Query<AtpOrderMessage>(@"SELECT ORDER_NUMBER, SEQUENTIAL_NUMBER, TEXT FROM ATP_ORDER_MESSAGES", r =>
			{
				var orderNumber = 0L;
				var sequentialNumber = 0L;
				var text = string.Empty;
				return new AtpOrderMessage(orderNumber, sequentialNumber, text);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<BeaconLog> GetBeaconLogs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<BeaconLog>();

			var query = new Query<BeaconLog>(@"SELECT GUID, STARTED_AT, FINISHED_AT, EQUIPMENT_NUMBER, EDDYSTONE_INSTANCE, OUTLET_NUMBER, USER_ID, OPERATION_TYPE, NUMBER_OF_EVENTS, NUMBER_OF_IMAGES, STATUS, ERROR_TEXT, SIZE_IN_BYTES FROM BEACON_LOGS", r =>
			{
				var guid = string.Empty;
				var startedAt = DateTime.MinValue;
				var finishedAt = DateTime.MinValue;
				var equipmentNumber = string.Empty;
				var eddystoneInstance = string.Empty;
				var outletNumber = 0L;
				var userId = 0L;
				var operationType = string.Empty;
				var numberOfEvents = 0L;
				var numberOfImages = 0L;
				var status = string.Empty;
				var errorText = string.Empty;
				var sizeInBytes = 0L;
				return new BeaconLog(guid, startedAt, finishedAt, equipmentNumber, eddystoneInstance, outletNumber, userId, operationType, numberOfEvents, numberOfImages, status, errorText, sizeInBytes);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<BusinessType> GetBusinessTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<BusinessType>();

			var query = new Query<BusinessType>(@"SELECT CODE, KDGRP, DESCRIPTION FROM BUSINESS_TYPES", r =>
			{
				var code = 0L;
				var kdgrp = string.Empty;
				var description = string.Empty;
				return new BusinessType(code, kdgrp, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CallingAssignment> GetCallingAssignments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CallingAssignment>();

			var query = new Query<CallingAssignment>(@"SELECT ACTUAL_FROM_DATE, ACTUAL_TO_DATE, ID, OUTLET_NUMBER, USER_ID, USER_ROUTE_ID FROM CALLING_ASSIGNMENTS", r =>
			{
				var actualFromDate = DateTime.MinValue;
				var actualToDate = DateTime.MinValue;
				var id = 0L;
				var outletNumber = 0L;
				var userId = 0L;
				var userRouteId = 0L;
				return new CallingAssignment(actualFromDate, actualToDate, id, outletNumber, userId, userRouteId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CallingRoute> GetCallingRoutes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CallingRoute>();

			var query = new Query<CallingRoute>(@"SELECT CLIENT, CODE, DESCRIPTION, LANGU, TERRITORY FROM CALLING_ROUTES", r =>
			{
				var client = string.Empty;
				var code = 0L;
				var description = string.Empty;
				var langu = string.Empty;
				var territory = string.Empty;
				return new CallingRoute(client, code, description, langu, territory);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CcafChannel> GetCcafChannels(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CcafChannel>();

			var query = new Query<CcafChannel>(@"SELECT CODE, LOCAL_NAME, NAME FROM CCAF_CHANNELS", r =>
			{
				var code = string.Empty;
				var localName = string.Empty;
				var name = string.Empty;
				return new CcafChannel(code, localName, name);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CcafSegment> GetCcafSegments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CcafSegment>();

			var query = new Query<CcafSegment>(@"SELECT CODE, NAME, LOCAL_NAME FROM CCAF_SEGMENTS", r =>
			{
				var code = 0;
				var name = string.Empty;
				var localName = string.Empty;
				return new CcafSegment(code, name, localName);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CcOrder> GetCcOrders(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CcOrder>();

			var query = new Query<CcOrder>(@"SELECT DELIVERY_DATE, ID, OUTLET_NUMBER, POSTING_DATE, PROCESS_TYPE, SAP_ID, SAP_SOURCE, STATUS_TEXT, STATUS_TYPE, TYPE_CODE FROM CC_ORDERS", r =>
			{
				var deliveryDate = DateTime.MinValue;
				var id = 0L;
				var outletNumber = 0L;
				var postingDate = DateTime.MinValue;
				var processType = string.Empty;
				var sapId = string.Empty;
				var sapSource = string.Empty;
				var statusText = string.Empty;
				var statusType = 0;
				var typeCode = 0L;
				return new CcOrder(deliveryDate, id, outletNumber, postingDate, processType, sapId, sapSource, statusText, statusType, typeCode);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CcOrderDetail> GetCcOrderDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CcOrderDetail>();

			var query = new Query<CcOrderDetail>(@"SELECT ARTICLE_NUMBER, CC_ORDER_ID, CONFIRMED_QUANTITY, CURRENCY, ITEM_CATEGORY, NET_VALUE, QUANTITY FROM CC_ORDER_DETAILS", r =>
			{
				var articleNumber = 0L;
				var ccOrderId = 0L;
				var confirmedQuantity = 0M;
				var currency = string.Empty;
				var itemCategory = string.Empty;
				var netValue = 0M;
				var quantity = 0M;
				return new CcOrderDetail(articleNumber, ccOrderId, confirmedQuantity, currency, itemCategory, netValue, quantity);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ChannelAssortment> GetChannelAssortments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ChannelAssortment>();

			var query = new Query<ChannelAssortment>(@"SELECT ARTICLE_NUMBER, CUSTOMER_GROUP, ID, IS_LOCKED, OUTLET_NUMBER, PRICE_GROUP, SALES_ORG_ASSORTMENT_ID, SCREEN_POSITION FROM CHANNEL_ASSORTMENTS", r =>
			{
				var articleNumber = 0L;
				var customerGroup = string.Empty;
				var id = 0L;
				var isLocked = 0;
				var outletNumber = 0L;
				var priceGroup = string.Empty;
				var salesOrgAssortmentId = string.Empty;
				var screenPosition = 0L;
				return new ChannelAssortment(articleNumber, customerGroup, id, isLocked, outletNumber, priceGroup, salesOrgAssortmentId, screenPosition);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ClientSequence> GetClientSequences(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ClientSequence>();

			var query = new Query<ClientSequence>(@"SELECT MAX_VALUE, MIN_VALUE, NEXT_VALUE, PC_ID, SEQUENCE_ID FROM CLIENT_SEQUENCES", r =>
			{
				var maxValue = 0L;
				var minValue = 0L;
				var nextValue = 0L;
				var pcId = 0M;
				var sequenceId = 0L;
				return new ClientSequence(maxValue, minValue, nextValue, pcId, sequenceId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ClientVersion> GetClientVersions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ClientVersion>();

			var query = new Query<ClientVersion>(@"SELECT MODULE_NAME, PC_ID, VERSION_STRING FROM CLIENT_VERSIONS", r =>
			{
				var moduleName = string.Empty;
				var pcId = 0L;
				var versionString = string.Empty;
				return new ClientVersion(moduleName, pcId, versionString);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ComplaintDetail> GetComplaintDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ComplaintDetail>();

			var query = new Query<ComplaintDetail>(@"SELECT ACTIVITY_ID, ARTICLE_NUMBER, QUANTITY, QUANTITY_SU FROM COMPLAINT_DETAILS", r =>
			{
				var activityId = 0L;
				var articleNumber = 0L;
				var quantity = 0M;
				var quantitySu = 0L;
				return new ComplaintDetail(activityId, articleNumber, quantity, quantitySu);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ContactPerson> GetContactPersons(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ContactPerson>();

			var query = new Query<ContactPerson>(@"SELECT FIRSTNAME, FUNCTION, ID, ISMANAGER, LASTNAME, ORIGIN, OUTLET_NUMBER, STATUS FROM CONTACT_PERSONS", r =>
			{
				var firstname = string.Empty;
				var function = string.Empty;
				var id = 0L;
				var ismanager = 0;
				var lastname = string.Empty;
				var origin = string.Empty;
				var outletNumber = 0L;
				var status = string.Empty;
				return new ContactPerson(firstname, function, id, ismanager, lastname, origin, outletNumber, status);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ContractTemplate> GetContractTemplates(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ContractTemplate>();

			var query = new Query<ContractTemplate>(@"SELECT ACTIVITY_TYPE_ID, EULA, LAST_MODIFIED, SIGN_BY_BD, SIGN_BY_CUSTOMER FROM CONTRACT_TEMPLATES", r =>
			{
				var activityTypeId = 0;
				var eula = string.Empty;
				var lastModified = DateTime.MinValue;
				var signByBd = 0;
				var signByCustomer = 0;
				return new ContractTemplate(activityTypeId, eula, lastModified, signByBd, signByCustomer);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CusPlanningToolCust> GetCusPlanningToolCusts(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CusPlanningToolCust>();

			var query = new Query<CusPlanningToolCust>(@"SELECT CFSMINDC, DELTA, DESCRIPTION, IS_SUPPRESSED, PROCESS_TYPE, REASON_CODE, REASON_CODE2, REASON_CODEGRP, SORT_INDICATOR FROM CUS_PLANNING_TOOL_CUST", r =>
			{
				var cfsmindc = string.Empty;
				var delta = 0M;
				var description = string.Empty;
				var isSuppressed = 0;
				var processType = string.Empty;
				var reasonCode = string.Empty;
				var reasonCode2 = string.Empty;
				var reasonCodegrp = string.Empty;
				var sortIndicator = 0;
				return new CusPlanningToolCust(cfsmindc, delta, description, isSuppressed, processType, reasonCode, reasonCode2, reasonCodegrp, sortIndicator);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CusPopAssortment> GetCusPopAssortments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CusPopAssortment>();

			var query = new Query<CusPopAssortment>(@"SELECT SALES_ORG_ASSORTMENT_ID FROM CUS_POP_ASSORTMENTS", r =>
			{
				var salesOrgAssortmentId = string.Empty;
				return new CusPopAssortment(salesOrgAssortmentId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CusSurvey> GetCusSurveys(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CusSurvey>();

			var query = new Query<CusSurvey>(@"SELECT ANSWER_SUMMARY, ANSWER_TOTAL, COPY_LAST_VALUES, IDEAL_OUTLET, MUST, PERCENTAGE, QUESTION_SUMMARY, QUESTION_TOTAL, SCORING, SURVEY_ID, TRANSACTION_TYPE, VALID_FROM, VALID_TO FROM CUS_SURVEYS", r =>
			{
				var answerSummary = string.Empty;
				var answerTotal = string.Empty;
				var copyLastValues = string.Empty;
				var idealOutlet = string.Empty;
				var must = string.Empty;
				var percentage = string.Empty;
				var questionSummary = string.Empty;
				var questionTotal = string.Empty;
				var scoring = string.Empty;
				var surveyId = 0L;
				var transactionType = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new CusSurvey(answerSummary, answerTotal, copyLastValues, idealOutlet, must, percentage, questionSummary, questionTotal, scoring, surveyId, transactionType, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<CusSurveysHierNode> GetCusSurveysHierNodes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<CusSurveysHierNode>();

			var query = new Query<CusSurveysHierNode>(@"SELECT NODE_GUID, SURVEY_ID FROM CUS_SURVEYS_HIER_NODES", r =>
			{
				var nodeGuid = string.Empty;
				var surveyId = 0L;
				return new CusSurveysHierNode(nodeGuid, surveyId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<DeliveryHistDetail> GetDeliveryHistDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<DeliveryHistDetail>();

			var query = new Query<DeliveryHistDetail>(@"SELECT ARTICLE_NUMBER, DELIVERY1, DELIVERY2, DELIVERY3, DELIVERY4, DELIVERY5, DELIVERY6, OUTLET_NUMBER FROM DELIVERY_HIST_DETAILS", r =>
			{
				var articleNumber = 0L;
				var delivery1 = 0L;
				var delivery2 = 0L;
				var delivery3 = 0L;
				var delivery4 = 0L;
				var delivery5 = 0L;
				var delivery6 = 0L;
				var outletNumber = 0L;
				return new DeliveryHistDetail(articleNumber, delivery1, delivery2, delivery3, delivery4, delivery5, delivery6, outletNumber);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<DeliveryHistHeader> GetDeliveryHistHeaders(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<DeliveryHistHeader>();

			var query = new Query<DeliveryHistHeader>(@"SELECT DELIVERY_DATE1, DELIVERY_DATE2, DELIVERY_DATE3, DELIVERY_DATE4, DELIVERY_DATE5, DELIVERY_DATE6, OUTLET_NUMBER FROM DELIVERY_HIST_HEADERS", r =>
			{
				var deliveryDate1 = DateTime.MinValue;
				var deliveryDate2 = DateTime.MinValue;
				var deliveryDate3 = DateTime.MinValue;
				var deliveryDate4 = DateTime.MinValue;
				var deliveryDate5 = DateTime.MinValue;
				var deliveryDate6 = DateTime.MinValue;
				var outletNumber = 0L;
				return new DeliveryHistHeader(deliveryDate1, deliveryDate2, deliveryDate3, deliveryDate4, deliveryDate5, deliveryDate6, outletNumber);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<DeliveryLeadTime> GetDeliveryLeadTimes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<DeliveryLeadTime>();

			var query = new Query<DeliveryLeadTime>(@"SELECT CODE, ATTRIB_5, DESCRIPTION FROM DELIVERY_LEAD_TIMES", r =>
			{
				var code = 0L;
				var attrib5 = string.Empty;
				var description = string.Empty;
				return new DeliveryLeadTime(code, attrib5, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<DeliveryLocation> GetDeliveryLocations(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<DeliveryLocation>();

			var query = new Query<DeliveryLocation>(@"SELECT CODE, WERKS, DESCRIPTION, IS_SUPPRESSED, NAME1, NAME2, ADDRESS FROM DELIVERY_LOCATIONS", r =>
			{
				var code = 0L;
				var werks = string.Empty;
				var description = string.Empty;
				var isSuppressed = 0;
				var name1 = string.Empty;
				var name2 = string.Empty;
				var address = string.Empty;
				return new DeliveryLocation(code, werks, description, isSuppressed, name1, name2, address);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<DeliveryTransaction> GetDeliveryTransactions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<DeliveryTransaction>();

			var query = new Query<DeliveryTransaction>(@"SELECT BASIS_CODE, BASIS_LOCATION, BASIS_SUBKEY, CODE, DESCRIPTION, IS_SUPPRESSED, ORIGIN, SEQUENCE FROM DELIVERY_TRANSACTIONS", r =>
			{
				var basisCode = string.Empty;
				var basisLocation = string.Empty;
				var basisSubkey = string.Empty;
				var code = 0L;
				var description = string.Empty;
				var isSuppressed = 0;
				var origin = string.Empty;
				var sequence = 0;
				return new DeliveryTransaction(basisCode, basisLocation, basisSubkey, code, description, isSuppressed, origin, sequence);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<DeliveryType> GetDeliveryTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<DeliveryType>();

			var query = new Query<DeliveryType>(@"SELECT CODE, ATTRIB_4, DESCRIPTION FROM DELIVERY_TYPES", r =>
			{
				var code = 0L;
				var attrib4 = string.Empty;
				var description = string.Empty;
				return new DeliveryType(code, attrib4, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Equipment> GetEquipments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Equipment>();

			var query = new Query<Equipment>(@"SELECT EQUIPMENT_NUMBER, EQUIPMENT_TYPE_CODE, IS_SUPPRESSED, OUTLET_NUMBER, RENT_CONTRACT_NUMBER, SERIAL_NUMBER, ASSET_CLASS, IBEACON_MAJOR, IBEACON_MINOR, IBEACON_UUID, EDDYSTONE_NAMESPACE, EDDYSTONE_INSTANCE, DOOR_OPENS_COUNT, DOWNLOAD_DATE, RED_COOLER_QUALITY, BRANDING, AV_TRAFF_DOOR, MONTHLY_AV_TEMP, MONTHLY_AV_ACTIVE_TEMP, AV_TRAF_LIGHT_TEMP, TRAF_LIGHT_DOWNLOAD_DATE, SMART_TYPE, BEACON_MAC_ADDRESS, BEACON_PASSWORD FROM EQUIPMENT", r =>
			{
				var equipmentNumber = string.Empty;
				var equipmentTypeCode = 0L;
				var isSuppressed = 0;
				var outletNumber = 0L;
				var rentContractNumber = string.Empty;
				var serialNumber = string.Empty;
				var assetClass = string.Empty;
				var ibeaconMajor = 0;
				var ibeaconMinor = 0;
				var ibeaconUuid = string.Empty;
				var eddystoneNamespace = string.Empty;
				var eddystoneInstance = string.Empty;
				var doorOpensCount = 0M;
				var downloadDate = DateTime.MinValue;
				var redCoolerQuality = 0M;
				var branding = string.Empty;
				var avTraffDoor = string.Empty;
				var monthlyAvTemp = 0M;
				var monthlyAvActiveTemp = 0M;
				var avTrafLightTemp = string.Empty;
				var trafLightDownloadDate = DateTime.MinValue;
				var smartType = string.Empty;
				var beaconMacAddress = string.Empty;
				var beaconPassword = string.Empty;
				return new Equipment(equipmentNumber, equipmentTypeCode, isSuppressed, outletNumber, rentContractNumber, serialNumber, assetClass, ibeaconMajor, ibeaconMinor, ibeaconUuid, eddystoneNamespace, eddystoneInstance, doorOpensCount, downloadDate, redCoolerQuality, branding, avTraffDoor, monthlyAvTemp, monthlyAvActiveTemp, avTrafLightTemp, trafLightDownloadDate, smartType, beaconMacAddress, beaconPassword);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<EquipmentActivity> GetEquipmentActivitys(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<EquipmentActivity>();

			var query = new Query<EquipmentActivity>(@"SELECT ACTIVITY_ID, EQUIPMENT_MODEL_CODE, EQUIPMENT_TYPE_CODE, EQUIPMENT_NUMBER, NEW_OUTLET_NUMBER, STATUS_LIST_ID FROM EQUIPMENT_ACTIVITY", r =>
			{
				var activityId = 0L;
				var equipmentModelCode = 0L;
				var equipmentTypeCode = 0L;
				var equipmentNumber = string.Empty;
				var newOutletNumber = 0L;
				var statusListId = 0L;
				return new EquipmentActivity(activityId, equipmentModelCode, equipmentTypeCode, equipmentNumber, newOutletNumber, statusListId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<EquipmentCheck> GetEquipmentChecks(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<EquipmentCheck>();

			var query = new Query<EquipmentCheck>(@"SELECT ACTIVITY_ID, ADMIN_COMMENTS, AVAILABLE, BARCODE_CUTTING, CDE_STATUS_ID, COMMENTS, EQUIPMENT_LOAD, EQUIPMENT_NUMBER, EQ_TAG_STATUS_ID, LAST_CHECKED, LAST_SCANNED, LOCATION_STATUS_ID, MODEL, OUTLET_NUMBER, PERCENT_STATUS_ID, SERIAL_NUMBER, SOURCE, STATUS, TB_RESOLVED, VISIT_ID, LAST_CHECKED_BY_USER_ID, IBEACON_MAJOR, IBEACON_MINOR, IBEACON_UUID, EDDYSTONE_NAMESPACE, EDDYSTONE_INSTANCE, DOOR_OPENS_COUNT, DOWNLOAD_DATE, RED_COOLER_QUALITY, BRANDING, AV_TRAFF_DOOR, MONTHLY_AV_TEMP, MONTHLY_AV_ACTIVE_TEMP, AV_TRAF_LIGHT_TEMP, TRAF_LIGHT_DOWNLOAD_DATE, SMART_TYPE, BEACON_MAC_ADDRESS, BEACON_PASSWORD FROM EQUIPMENT_CHECK", r =>
			{
				var activityId = 0L;
				var adminComments = string.Empty;
				var available = 0;
				var barcodeCutting = string.Empty;
				var cdeStatusId = 0L;
				var comments = string.Empty;
				var equipmentLoad = 0;
				var equipmentNumber = string.Empty;
				var eqTagStatusId = 0L;
				var lastChecked = DateTime.MinValue;
				var lastScanned = DateTime.MinValue;
				var locationStatusId = 0L;
				var model = string.Empty;
				var outletNumber = 0L;
				var percentStatusId = 0L;
				var serialNumber = string.Empty;
				var source = string.Empty;
				var status = string.Empty;
				var tbResolved = string.Empty;
				var visitId = 0L;
				var lastCheckedByUserId = 0L;
				var ibeaconMajor = 0;
				var ibeaconMinor = 0;
				var ibeaconUuid = string.Empty;
				var eddystoneNamespace = string.Empty;
				var eddystoneInstance = string.Empty;
				var doorOpensCount = 0M;
				var downloadDate = DateTime.MinValue;
				var redCoolerQuality = 0M;
				var branding = string.Empty;
				var avTraffDoor = string.Empty;
				var monthlyAvTemp = 0M;
				var monthlyAvActiveTemp = 0M;
				var avTrafLightTemp = string.Empty;
				var trafLightDownloadDate = DateTime.MinValue;
				var smartType = string.Empty;
				var beaconMacAddress = string.Empty;
				var beaconPassword = string.Empty;
				return new EquipmentCheck(activityId, adminComments, available, barcodeCutting, cdeStatusId, comments, equipmentLoad, equipmentNumber, eqTagStatusId, lastChecked, lastScanned, locationStatusId, model, outletNumber, percentStatusId, serialNumber, source, status, tbResolved, visitId, lastCheckedByUserId, ibeaconMajor, ibeaconMinor, ibeaconUuid, eddystoneNamespace, eddystoneInstance, doorOpensCount, downloadDate, redCoolerQuality, branding, avTraffDoor, monthlyAvTemp, monthlyAvActiveTemp, avTrafLightTemp, trafLightDownloadDate, smartType, beaconMacAddress, beaconPassword);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<EquipmentMatrix> GetEquipmentMatrixs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<EquipmentMatrix>();

			var query = new Query<EquipmentMatrix>(@"SELECT CCAF_CHANNEL_CODE, CCAF_SEGMENT_CODE, HIERARCHY_LEVEL, ID, OUTLET_CLUSTER_ATTRIBUTE_CODE, OUTLET_CLUSTER_HIERARCHY_NODE, RED_PICTURE_OF_SUCCESS_FORMAT, TRADE_CHANNEL_CODE FROM EQUIPMENT_MATRIX", r =>
			{
				var ccafChannelCode = string.Empty;
				var ccafSegmentCode = 0;
				var hierarchyLevel = string.Empty;
				var id = 0L;
				var outletClusterAttributeCode = 0M;
				var outletClusterHierarchyNode = 0M;
				var redPictureOfSuccessFormat = string.Empty;
				var tradeChannelCode = 0L;
				return new EquipmentMatrix(ccafChannelCode, ccafSegmentCode, hierarchyLevel, id, outletClusterAttributeCode, outletClusterHierarchyNode, redPictureOfSuccessFormat, tradeChannelCode);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<EquipmentMatrixType> GetEquipmentMatrixTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<EquipmentMatrixType>();

			var query = new Query<EquipmentMatrixType>(@"SELECT EQUIPMENT_MATRIX_ID, EQUIPMENT_TYPE_CODE FROM EQUIPMENT_MATRIX_TYPES", r =>
			{
				var equipmentMatrixId = 0L;
				var equipmentTypeCode = 0L;
				return new EquipmentMatrixType(equipmentMatrixId, equipmentTypeCode);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<EquipmentMessage> GetEquipmentMessages(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<EquipmentMessage>();

			var query = new Query<EquipmentMessage>(@"SELECT ID, MESSAGE, ORIGIN, STATUS FROM EQUIPMENT_MESSAGES", r =>
			{
				var id = 0L;
				var message = string.Empty;
				var origin = string.Empty;
				var status = string.Empty;
				return new EquipmentMessage(id, message, origin, status);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<EquipmentType> GetEquipmentTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<EquipmentType>();

			var query = new Query<EquipmentType>(@"SELECT CODE, DESCRIPTION, IS_SUPPRESSED, NOTE, BRANDING, NUMBER_OF_DOORS, WIDTH, HEIGHT, DEPTH, POWER, SAP_CODE FROM EQUIPMENT_TYPES", r =>
			{
				var code = 0L;
				var description = string.Empty;
				var isSuppressed = 0;
				var note = string.Empty;
				var branding = string.Empty;
				var numberOfDoors = 0L;
				var width = 0L;
				var height = 0L;
				var depth = 0L;
				var power = 0M;
				var sapCode = string.Empty;
				return new EquipmentType(code, description, isSuppressed, note, branding, numberOfDoors, width, height, depth, power, sapCode);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<EquipmentTypeImage> GetEquipmentTypeImages(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<EquipmentTypeImage>();

			var query = new Query<EquipmentTypeImage>(@"SELECT EQUIPMENT_TYPE_CODE, ID, IMAGE FROM EQUIPMENT_TYPE_IMAGES", r =>
			{
				var equipmentTypeCode = 0L;
				var id = 0L;
				var image = default(byte[]);
				return new EquipmentTypeImage(equipmentTypeCode, id, image);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<GpsData> GetGpsDatas(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<GpsData>();

			var query = new Query<GpsData>(@"SELECT ACTIVITY_ID, DEVICE_ID, ID, LATITUDE, LONGITUDE, RIL_CELL_ID, RIL_LOCATION_AREA_CODE, RIL_MOBILE_COUNTRY_CODE, RIL_MOBILE_NETWORK_CODE, TIME_STAMP, USER_ID FROM GPS_DATA", r =>
			{
				var activityId = 0L;
				var deviceId = 0M;
				var id = 0L;
				var latitude = 0M;
				var longitude = 0M;
				var rilCellId = 0L;
				var rilLocationAreaCode = 0L;
				var rilMobileCountryCode = 0L;
				var rilMobileNetworkCode = 0L;
				var timeStamp = DateTime.MinValue;
				var userId = 0L;
				return new GpsData(activityId, deviceId, id, latitude, longitude, rilCellId, rilLocationAreaCode, rilMobileCountryCode, rilMobileNetworkCode, timeStamp, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Holiday> GetHolidays(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Holiday>();

			var query = new Query<Holiday>(@"SELECT CALENDAR_DATE, SELECTOR_KEY FROM HOLIDAYS", r =>
			{
				var calendarDate = DateTime.MinValue;
				var selectorKey = string.Empty;
				return new Holiday(calendarDate, selectorKey);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<InventoryDetail> GetInventoryDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<InventoryDetail>();

			var query = new Query<InventoryDetail>(@"SELECT ARTICLE_NUMBER, INVENTORY_HEADER_ID, STOCK_BACK, STOCK_BACK_SU, STOCK_EQUIPMENT, STOCK_EQUIPMENT_SU, STOCK_SHELF, STOCK_SHELF_SU, STOCK_TOTAL, STOCK_TOTAL_SU FROM INVENTORY_DETAILS", r =>
			{
				var articleNumber = 0L;
				var inventoryHeaderId = 0L;
				var stockBack = 0;
				var stockBackSu = 0;
				var stockEquipment = 0;
				var stockEquipmentSu = 0;
				var stockShelf = 0;
				var stockShelfSu = 0;
				var stockTotal = 0;
				var stockTotalSu = 0;
				return new InventoryDetail(articleNumber, inventoryHeaderId, stockBack, stockBackSu, stockEquipment, stockEquipmentSu, stockShelf, stockShelfSu, stockTotal, stockTotalSu);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<InventoryHeader> GetInventoryHeaders(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<InventoryHeader>();

			var query = new Query<InventoryHeader>(@"SELECT ACTIVITY_ID, CREATED_AT, ID, LAST_SAVED_AT, VISIT_ID FROM INVENTORY_HEADERS", r =>
			{
				var activityId = 0L;
				var createdAt = DateTime.MinValue;
				var id = 0L;
				var lastSavedAt = DateTime.MinValue;
				var visitId = 0L;
				return new InventoryHeader(activityId, createdAt, id, lastSavedAt, visitId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<LinkedWholesaler> GetLinkedWholesalers(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<LinkedWholesaler>();

			var query = new Query<LinkedWholesaler>(@"SELECT GRID_NUMBER, IS_DEFAULT, OUTLET_NUMBER, VALID_FROM, VALID_TO, WHOLESALER_ID FROM LINKED_WHOLESALERS", r =>
			{
				var gridNumber = string.Empty;
				var isDefault = 0;
				var outletNumber = 0L;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				var wholesalerId = 0L;
				return new LinkedWholesaler(gridNumber, isDefault, outletNumber, validFrom, validTo, wholesalerId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<MaterialCategorie> GetMaterialCategories(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<MaterialCategorie>();

			var query = new Query<MaterialCategorie>(@"SELECT CODE, PRODH, DESCRIPTION FROM MATERIAL_CATEGORIES", r =>
			{
				var code = 0L;
				var prodh = string.Empty;
				var description = string.Empty;
				return new MaterialCategorie(code, prodh, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<MeasureDomain> GetMeasureDomains(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<MeasureDomain>();

			var query = new Query<MeasureDomain>(@"SELECT ID, IS_SUPPRESSED, VALUE_TYPE FROM MEASURE_DOMAINS", r =>
			{
				var id = 0L;
				var isSuppressed = 0;
				var valueType = 0L;
				return new MeasureDomain(id, isSuppressed, valueType);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<MeasureDomainLov> GetMeasureDomainLovs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<MeasureDomainLov>();

			var query = new Query<MeasureDomainLov>(@"SELECT DESCRIPTION, DOMAIN_ID, NO, WEIGTH, NOT_APPLICABLE, VALUE FROM MEASURE_DOMAIN_LOVS", r =>
			{
				var description = string.Empty;
				var domainId = 0L;
				var no = 0L;
				var weigth = 0L;
				var notApplicable = 0;
				var value = string.Empty;
				return new MeasureDomainLov(description, domainId, no, weigth, notApplicable, value);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<MeasureNode> GetMeasureNodes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<MeasureNode>();

			var query = new Query<MeasureNode>(@"SELECT ID, SURVEY_ID, IS_REQUIRED, FIRST_DOMAIN_ID, OWNER_ID, DESCRIPTION, DEFAULT_VALUE, CAN_EDIT, SUPPRESSED, SEQUENCE, TREE_LEVEL, SCORE, LONG_DESCRIPTION, MAXVAL, MINVAL, MARKET_ATTRIBUTE, TARGET_SCORE, TYPE, RELATED_NODE, VALID_FROM, VALID_TO, WEIGHT, GUID, PFP_REL FROM MEASURE_NODES", r =>
			{
				var id = 0L;
				var surveyId = 0L;
				var isRequired = 0;
				var firstDomainId = 0L;
				var ownerId = 0L;
				var description = string.Empty;
				var defaultValue = string.Empty;
				var canEdit = 0;
				var suppressed = 0;
				var sequence = 0L;
				var treeLevel = 0L;
				var score = 0M;
				var longDescription = string.Empty;
				var maxval = 0M;
				var minval = 0M;
				var marketAttribute = string.Empty;
				var targetScore = 0M;
				var type = string.Empty;
				var relatedNode = 0L;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				var weight = 0M;
				var guid = string.Empty;
				var pfpRel = string.Empty;
				return new MeasureNode(id, surveyId, isRequired, firstDomainId, ownerId, description, defaultValue, canEdit, suppressed, sequence, treeLevel, score, longDescription, maxval, minval, marketAttribute, targetScore, type, relatedNode, validFrom, validTo, weight, guid, pfpRel);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<MeasureValue> GetMeasureValues(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<MeasureValue>();

			var query = new Query<MeasureValue>(@"SELECT ACTIVITY_ID, NODE_ID, SURVEY_ID, VALUE, VISIT_ID FROM MEASURE_VALUES", r =>
			{
				var activityId = 0L;
				var nodeId = 0L;
				var surveyId = 0L;
				var value = string.Empty;
				var visitId = 0L;
				return new MeasureValue(activityId, nodeId, surveyId, value, visitId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OrderDateOutletCpl> GetOrderDateOutletCpls(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OrderDateOutletCpl>();

			var query = new Query<OrderDateOutletCpl>(@"SELECT CPL FROM ORDER_DATE_OUTLET_CPLS", r =>
			{
				var cpl = string.Empty;
				return new OrderDateOutletCpl(cpl);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OrderDetail> GetOrderDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OrderDetail>();

			var query = new Query<OrderDetail>(@"SELECT ADJUSTMENT_NUMBER, ADJUSTMENT_QUANTITY, ADJUSTMENT_QUANTITY_SU, ADJUSTMENT_TYPE, ARTICLE_NUMBER, ORDER_HEADER_ID, PREVIOUS_CONSUMPTION, PREVIOUS_CONSUMPTION_SU, QUANTITY, QUANTITY_SU, SUGGESTED_QUANTITY, SUGGESTED_QUANTITY_SU FROM ORDER_DETAILS", r =>
			{
				var adjustmentNumber = 0L;
				var adjustmentQuantity = 0M;
				var adjustmentQuantitySu = 0L;
				var adjustmentType = string.Empty;
				var articleNumber = 0L;
				var orderHeaderId = 0L;
				var previousConsumption = 0M;
				var previousConsumptionSu = 0L;
				var quantity = 0M;
				var quantitySu = 0L;
				var suggestedQuantity = 0M;
				var suggestedQuantitySu = 0M;
				return new OrderDetail(adjustmentNumber, adjustmentQuantity, adjustmentQuantitySu, adjustmentType, articleNumber, orderHeaderId, previousConsumption, previousConsumptionSu, quantity, quantitySu, suggestedQuantity, suggestedQuantitySu);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OrderDetailPromotion> GetOrderDetailPromotions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OrderDetailPromotion>();

			var query = new Query<OrderDetailPromotion>(@"SELECT ORDERED_ARTICLE_NUMBER, ORDER_NUMBER, PROMOTED_ARTICLE_NUMBER, PROMOTED_FREE_FLAG, PROMOTED_QUANTITY, PROMOTED_QUANTITY_SU, PROMOTION_GUID FROM ORDER_DETAIL_PROMOTIONS", r =>
			{
				var orderedArticleNumber = 0L;
				var orderNumber = 0L;
				var promotedArticleNumber = 0L;
				var promotedFreeFlag = string.Empty;
				var promotedQuantity = 0M;
				var promotedQuantitySu = 0M;
				var promotionGuid = string.Empty;
				return new OrderDetailPromotion(orderedArticleNumber, orderNumber, promotedArticleNumber, promotedFreeFlag, promotedQuantity, promotedQuantitySu, promotionGuid);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OrderFreeProduct> GetOrderFreeProducts(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OrderFreeProduct>();

			var query = new Query<OrderFreeProduct>(@"SELECT ARTICLE_NUMBER, ORDER_NUMBER, QUANTITY, REASON_CODE FROM ORDER_FREE_PRODUCTS", r =>
			{
				var articleNumber = 0L;
				var orderNumber = 0L;
				var quantity = 0L;
				var reasonCode = string.Empty;
				return new OrderFreeProduct(articleNumber, orderNumber, quantity, reasonCode);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OrderHeader> GetOrderHeaders(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OrderHeader>();

			var query = new Query<OrderHeader>(@"SELECT ACTIVITY_ID, ADDRESS_NUMBER, ATP_DEPOSIT, ATP_PROMO_DISCOUNT, ATP_GROSS_TOTAL, ATP_TAX_TOTAL, ATP_TIMESTAMP, ATP_TOTAL, CONVERTED_QUANTITY, CREATED_AT, CUSTOMER_REFERENCE, DELIVERY_DATE, DELIVERY_LOCATION_CODE, DELIVERY_TRANSACTION_CODE, EXTERNAL_REFERENCE_NUMBER, GRID_NUMBER, HAS_EMPTIES, LAST_SAVED_AT, ORDER_DATE, ORDER_NUMBER, ORDER_STATUS, ORDER_TYPE_CODE, POP_ARTICLE_GROUP, PRICELIST_BASED_AMOUNT, PRICE_LIST_CODE, PROMOTION_CODE_GROUP, PROMOTION_REASON, TOTAL_CASES, TOTAL_CASES_CONV, TOTAL_CASES_CONV_AMOUNT, TRANSACTION_DESCRIPTION, UNPRODUCTIVE, VISIT_ID, WHOLESALER_ID, TO_OUTLET_NUMBER, REASON_LIST_ID, VENDOR_LIST_ID, PAYMENT_TERMS_LIST_ID FROM ORDER_HEADERS", r =>
			{
				var activityId = 0L;
				var addressNumber = 0L;
				var atpDeposit = 0M;
				var atpPromoDiscount = 0M;
				var atpGrossTotal = 0M;
				var atpTaxTotal = 0M;
				var atpTimestamp = DateTime.MinValue;
				var atpTotal = 0M;
				var convertedQuantity = 0M;
				var createdAt = DateTime.MinValue;
				var customerReference = string.Empty;
				var deliveryDate = DateTime.MinValue;
				var deliveryLocationCode = 0L;
				var deliveryTransactionCode = 0L;
				var externalReferenceNumber = string.Empty;
				var gridNumber = string.Empty;
				var hasEmpties = 0;
				var lastSavedAt = DateTime.MinValue;
				var orderDate = DateTime.MinValue;
				var orderNumber = 0L;
				var orderStatus = 0;
				var orderTypeCode = 0L;
				var popArticleGroup = 0L;
				var pricelistBasedAmount = 0M;
				var priceListCode = 0L;
				var promotionCodeGroup = string.Empty;
				var promotionReason = string.Empty;
				var totalCases = 0M;
				var totalCasesConv = 0M;
				var totalCasesConvAmount = 0M;
				var transactionDescription = string.Empty;
				var unproductive = 0;
				var visitId = 0L;
				var wholesalerId = 0L;
				var toOutletNumber = 0L;
				var reasonListId = 0L;
				var vendorListId = 0L;
				var paymentTermsListId = 0L;
				return new OrderHeader(activityId, addressNumber, atpDeposit, atpPromoDiscount, atpGrossTotal, atpTaxTotal, atpTimestamp, atpTotal, convertedQuantity, createdAt, customerReference, deliveryDate, deliveryLocationCode, deliveryTransactionCode, externalReferenceNumber, gridNumber, hasEmpties, lastSavedAt, orderDate, orderNumber, orderStatus, orderTypeCode, popArticleGroup, pricelistBasedAmount, priceListCode, promotionCodeGroup, promotionReason, totalCases, totalCasesConv, totalCasesConvAmount, transactionDescription, unproductive, visitId, wholesalerId, toOutletNumber, reasonListId, vendorListId, paymentTermsListId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OrderText> GetOrderTexts(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OrderText>();

			var query = new Query<OrderText>(@"SELECT ACTIVITY_ID, DEVICE_ID, LINE_NO, LINE_TEXT, LIST_CODE, ORIGIN FROM ORDER_TEXTS", r =>
			{
				var activityId = 0L;
				var deviceId = 0M;
				var lineNo = 0;
				var lineText = string.Empty;
				var listCode = string.Empty;
				var origin = string.Empty;
				return new OrderText(activityId, deviceId, lineNo, lineText, listCode, origin);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OrderType> GetOrderTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OrderType>();

			var query = new Query<OrderType>(@"SELECT CODE, LOCAL_NAME, NAME FROM ORDER_TYPES", r =>
			{
				var code = 0L;
				var localName = string.Empty;
				var name = string.Empty;
				return new OrderType(code, localName, name);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletsExtension> GetOutletsExtensions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletsExtension>();

			var query = new Query<OutletsExtension>(@"SELECT NAME, ORDINAL, OUTLET_NUMBER, VALUE FROM OUTLETS_EXTENSIONS", r =>
			{
				var name = string.Empty;
				var ordinal = 0;
				var outletNumber = 0L;
				var value = string.Empty;
				return new OutletsExtension(name, ordinal, outletNumber, value);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletsTempData> GetOutletsTempDatas(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletsTempData>();

			var query = new Query<OutletsTempData>(@"SELECT OUTLET_NUMBER, TYPE, WHOLESALER, RAW_DATA, CREATED_AT FROM OUTLETS_TEMP_DATA", r =>
			{
				var outletNumber = 0L;
				var type = 0L;
				var wholesaler = string.Empty;
				var rawData = string.Empty;
				var createdAt = DateTime.MinValue;
				return new OutletsTempData(outletNumber, type, wholesaler, rawData, createdAt);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletAddresse> GetOutletAddresses(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletAddresse>();

			var query = new Query<OutletAddresse>(@"SELECT ADDRESS_NUMBER, OUTLET_NUMBER, STREET, HOUSE_NUMBER, POSTAL_CODE, ORIGIN, CITY, IS_DEFAULT, VALID_FROM, VALID_TO FROM OUTLET_ADDRESSES", r =>
			{
				var addressNumber = 0L;
				var outletNumber = 0L;
				var street = string.Empty;
				var houseNumber = string.Empty;
				var postalCode = string.Empty;
				var origin = string.Empty;
				var city = string.Empty;
				var isDefault = 0;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new OutletAddresse(addressNumber, outletNumber, street, houseNumber, postalCode, origin, city, isDefault, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletCluster> GetOutletClusters(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletCluster>();

			var query = new Query<OutletCluster>(@"SELECT HIERARCHY_NODE, ATTRIBUTE_CODE, DESCRIPTION FROM OUTLET_CLUSTERS", r =>
			{
				var hierarchyNode = 0M;
				var attributeCode = 0M;
				var description = string.Empty;
				return new OutletCluster(hierarchyNode, attributeCode, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletHierLevel> GetOutletHierLevels(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletHierLevel>();

			var query = new Query<OutletHierLevel>(@"SELECT DESCRIPTION, HIER_LEVEL, HIER_NODE, OUTLET_NUMBER, PARENT_OUTLET_NUMBER FROM OUTLET_HIER_LEVELS", r =>
			{
				var description = string.Empty;
				var hierLevel = 0L;
				var hierNode = string.Empty;
				var outletNumber = 0L;
				var parentOutletNumber = 0L;
				return new OutletHierLevel(description, hierLevel, hierNode, outletNumber, parentOutletNumber);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletMarketAttribute> GetOutletMarketAttributes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletMarketAttribute>();

			var query = new Query<OutletMarketAttribute>(@"SELECT ATVALUEDESCR, CHANGED_AT, CHANGED_BY, CHARACT, CHARACT_DESCR, DESCRIPTION, INHERITED, INSTANCE, OUTLET_NUMBER, VALUE, VALUE_ASSIGNMENT, VALUE_NEUTRAL, VAL_ASSIGN FROM OUTLET_MARKET_ATTRIBUTES", r =>
			{
				var atvaluedescr = string.Empty;
				var changedAt = DateTime.MinValue;
				var changedBy = string.Empty;
				var charact = string.Empty;
				var charactDescr = string.Empty;
				var description = string.Empty;
				var inherited = string.Empty;
				var instance = 0;
				var outletNumber = 0L;
				var value = string.Empty;
				var valueAssignment = string.Empty;
				var valueNeutral = string.Empty;
				var valAssign = string.Empty;
				return new OutletMarketAttribute(atvaluedescr, changedAt, changedBy, charact, charactDescr, description, inherited, instance, outletNumber, value, valueAssignment, valueNeutral, valAssign);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletRule> GetOutletRules(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletRule>();

			var query = new Query<OutletRule>(@"SELECT IDX, OUTLET_NUMBER, TEXT FROM OUTLET_RULES", r =>
			{
				var idx = 0L;
				var outletNumber = 0L;
				var text = string.Empty;
				return new OutletRule(idx, outletNumber, text);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletSnap> GetOutletSnaps(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletSnap>();

			var query = new Query<OutletSnap>(@"SELECT ADDRESS, BANK_ACCOUNT_NUMBER, BILLING_BLOCK, BILL_TO_OUTLET_NUMBER, BUSINESS_TYPE_CODE, CITY, CONTACT_PERSON, CREDIT_DAYS, CREDIT_LIMIT, CURRENCY, CUSTOMER_GROUP, DELIVERY_BLOCK, DELIVERY_DELAY, DELIVERY_LEAD_TIME_CODE, DELIVERY_LOCATION_CODE, DELIVERY_TRANSACTIONS_DESC, DELIVERY_TRANSACTION_CODE, DELIVERY_TYPE_CODE, EMAIL, EXPRESS_ORDER_ALLOWED, FACTORY, FAX, LATITUDE, LONGITUDE, NAME1, NAME2, ORDER_BLOCK, OUTLET_NUMBER, PAYER_NUMBER, POSTAL_CODE, PRICE_GROUP, PRIMARY_CONSUMER_ACTIVITY, RED_POS_ID, SALES_BLOCK, SALES_DISTRICT_CODE, SALES_GROUP_CODE, SALES_OFFICE_CODE, SHIP_TO_OUTLET_NUMBER, SUB_TRADE_CHANNEL_CODE, SUPPRESSED_CODE, SUPPRESSION_DATE, TELEPHONE, TELEPHONE_2, TRADE_CHANNEL_CODE, VAT_NUMBER, WHOLESALER_ID FROM OUTLET_SNAP", r =>
			{
				var address = string.Empty;
				var bankAccountNumber = string.Empty;
				var billingBlock = string.Empty;
				var billToOutletNumber = 0L;
				var businessTypeCode = 0L;
				var city = string.Empty;
				var contactPerson = string.Empty;
				var creditDays = 0;
				var creditLimit = 0L;
				var currency = string.Empty;
				var customerGroup = string.Empty;
				var deliveryBlock = string.Empty;
				var deliveryDelay = 0L;
				var deliveryLeadTimeCode = 0L;
				var deliveryLocationCode = 0L;
				var deliveryTransactionsDesc = string.Empty;
				var deliveryTransactionCode = 0L;
				var deliveryTypeCode = 0L;
				var email = string.Empty;
				var expressOrderAllowed = 0;
				var factory = string.Empty;
				var fax = string.Empty;
				var latitude = 0M;
				var longitude = 0M;
				var name1 = string.Empty;
				var name2 = string.Empty;
				var orderBlock = string.Empty;
				var outletNumber = 0L;
				var payerNumber = 0L;
				var postalCode = string.Empty;
				var priceGroup = string.Empty;
				var primaryConsumerActivity = string.Empty;
				var redPosId = string.Empty;
				var salesBlock = 0;
				var salesDistrictCode = 0L;
				var salesGroupCode = 0L;
				var salesOfficeCode = 0L;
				var shipToOutletNumber = 0L;
				var subTradeChannelCode = 0L;
				var suppressedCode = string.Empty;
				var suppressionDate = DateTime.MinValue;
				var telephone = string.Empty;
				var telephone2 = string.Empty;
				var tradeChannelCode = 0L;
				var vatNumber = string.Empty;
				var wholesalerId = 0L;
				return new OutletSnap(address, bankAccountNumber, billingBlock, billToOutletNumber, businessTypeCode, city, contactPerson, creditDays, creditLimit, currency, customerGroup, deliveryBlock, deliveryDelay, deliveryLeadTimeCode, deliveryLocationCode, deliveryTransactionsDesc, deliveryTransactionCode, deliveryTypeCode, email, expressOrderAllowed, factory, fax, latitude, longitude, name1, name2, orderBlock, outletNumber, payerNumber, postalCode, priceGroup, primaryConsumerActivity, redPosId, salesBlock, salesDistrictCode, salesGroupCode, salesOfficeCode, shipToOutletNumber, subTradeChannelCode, suppressedCode, suppressionDate, telephone, telephone2, tradeChannelCode, vatNumber, wholesalerId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<OutletText> GetOutletTexts(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<OutletText>();

			var query = new Query<OutletText>(@"SELECT CHANGED_AT, CHANGED_BY, DEVICE_ID, LINE_FORMAT, LINE_NO, LINE_TEXT, LIST_CODE, ORIGIN, OUTLET_NUMBER FROM OUTLET_TEXTS", r =>
			{
				var changedAt = DateTime.MinValue;
				var changedBy = string.Empty;
				var deviceId = 0M;
				var lineFormat = string.Empty;
				var lineNo = 0;
				var lineText = string.Empty;
				var listCode = string.Empty;
				var origin = string.Empty;
				var outletNumber = 0L;
				return new OutletText(changedAt, changedBy, deviceId, lineFormat, lineNo, lineText, listCode, origin, outletNumber);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Parameter> GetParameters(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Parameter>();

			var query = new Query<Parameter>(@"SELECT DESCRIPTION, ID, PARAMETER_ID, PARAMETER_NAME, PARAMETER_TYPE, PARAMETER_VALUE, SET_ID FROM PARAMETERS", r =>
			{
				var description = string.Empty;
				var id = 0L;
				var parameterId = 0L;
				var parameterName = string.Empty;
				var parameterType = string.Empty;
				var parameterValue = string.Empty;
				var setId = 0L;
				return new Parameter(description, id, parameterId, parameterName, parameterType, parameterValue, setId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PayerOutlet> GetPayerOutlets(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PayerOutlet>();

			var query = new Query<PayerOutlet>(@"SELECT FROM_DATE, IS_SUPPRESSED, OUTLET_NUMBER, PAYER_NUMBER, SUPPRESSION_DATE, TO_DATE FROM PAYER_OUTLETS", r =>
			{
				var fromDate = DateTime.MinValue;
				var isSuppressed = 0;
				var outletNumber = 0L;
				var payerNumber = 0L;
				var suppressionDate = DateTime.MinValue;
				var toDate = DateTime.MinValue;
				return new PayerOutlet(fromDate, isSuppressed, outletNumber, payerNumber, suppressionDate, toDate);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Phpooledsnapcolumndesc> GetPhpooledsnapcolumndescs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Phpooledsnapcolumndesc>();

			var query = new Query<Phpooledsnapcolumndesc>(@"SELECT ID, NAME, DATA_LENGTH, DATA_PRECISION, DATA_SCALE, SNAPSHOT_ID, DATA_TYPE, IS_SYSTEM, IS_NULL FROM PHPOOLEDSNAPCOLUMNDESC", r =>
			{
				var id = 0L;
				var name = string.Empty;
				var dataLength = 0M;
				var dataPrecision = 0M;
				var dataScale = 0M;
				var snapshotId = 0L;
				var dataType = string.Empty;
				var isSystem = 0;
				var isNull = 0M;
				return new Phpooledsnapcolumndesc(id, name, dataLength, dataPrecision, dataScale, snapshotId, dataType, isSystem, isNull);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlacementRequest> GetPlacementRequests(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlacementRequest>();

			var query = new Query<PlacementRequest>(@"SELECT ACTIVATION_ON, ACTIVITY_ID, DELIVERY_ON, EQUIPMENT_TYPE_CODE, ID, ORIGIN FROM PLACEMENT_REQUESTS", r =>
			{
				var activationOn = DateTime.MinValue;
				var activityId = 0L;
				var deliveryOn = DateTime.MinValue;
				var equipmentTypeCode = 0L;
				var id = 0L;
				var origin = string.Empty;
				return new PlacementRequest(activationOn, activityId, deliveryOn, equipmentTypeCode, id, origin);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlannedVolume> GetPlannedVolumes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlannedVolume>();

			var query = new Query<PlannedVolume>(@"SELECT KBI_INDICATOR, OUTLET_NUMBER, PLANNED_DATE, PLANNED_QTY, PLANNED_QTY_SU FROM PLANNED_VOLUMES", r =>
			{
				var kbiIndicator = string.Empty;
				var outletNumber = 0L;
				var plannedDate = DateTime.MinValue;
				var plannedQty = 0L;
				var plannedQtySu = 0L;
				return new PlannedVolume(kbiIndicator, outletNumber, plannedDate, plannedQty, plannedQtySu);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlanningToolDailyCustom> GetPlanningToolDailyCustoms(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlanningToolDailyCustom>();

			var query = new Query<PlanningToolDailyCustom>(@"SELECT ACTIVITY_TYPE_ID, DELTA, DESCRIPTION, FOCUS_FLAG, FSM_INDICATOR, PLANNABLE_FLAG, PROCESS_TYPE, REASON_CODE, REASON_CODE2, REASON_CODE_GROUP, SORT_INDICATOR, UNIT_OF_MEASURE, VALID_FROM, VALID_TO, VOLUME_FLAG FROM PLANNING_TOOL_DAILY_CUSTOMS", r =>
			{
				var activityTypeId = 0M;
				var delta = 0M;
				var description = string.Empty;
				var focusFlag = string.Empty;
				var fsmIndicator = string.Empty;
				var plannableFlag = string.Empty;
				var processType = string.Empty;
				var reasonCode = string.Empty;
				var reasonCode2 = string.Empty;
				var reasonCodeGroup = string.Empty;
				var sortIndicator = string.Empty;
				var unitOfMeasure = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				var volumeFlag = string.Empty;
				return new PlanningToolDailyCustom(activityTypeId, delta, description, focusFlag, fsmIndicator, plannableFlag, processType, reasonCode, reasonCode2, reasonCodeGroup, sortIndicator, unitOfMeasure, validFrom, validTo, volumeFlag);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlanningToolDailyTarget> GetPlanningToolDailyTargets(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlanningToolDailyTarget>();

			var query = new Query<PlanningToolDailyTarget>(@"SELECT AVERAGE_ORDER, FISCAL_YEAR_PERIOD, FISCAL_YEAR_VARIANT, FSM_INDICATOR, FSM_INDICATOR_KEY, LAST_ORDER_DATE, LAST_ORDER_VOLUME, LAST_YEAR_FPA, MTD_ACTUALS, OUTLET_NUMBER, PAST_YEAR_FPA, RECORD_MODE, TRANSACTION_DATE FROM PLANNING_TOOL_DAILY_TARGETS", r =>
			{
				var averageOrder = 0M;
				var fiscalYearPeriod = DateTime.MinValue;
				var fiscalYearVariant = string.Empty;
				var fsmIndicator = string.Empty;
				var fsmIndicatorKey = string.Empty;
				var lastOrderDate = DateTime.MinValue;
				var lastOrderVolume = 0M;
				var lastYearFpa = 0M;
				var mtdActuals = 0M;
				var outletNumber = 0L;
				var pastYearFpa = 0M;
				var recordMode = string.Empty;
				var transactionDate = DateTime.MinValue;
				return new PlanningToolDailyTarget(averageOrder, fiscalYearPeriod, fiscalYearVariant, fsmIndicator, fsmIndicatorKey, lastOrderDate, lastOrderVolume, lastYearFpa, mtdActuals, outletNumber, pastYearFpa, recordMode, transactionDate);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlanningToolDailyVolume> GetPlanningToolDailyVolumes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlanningToolDailyVolume>();

			var query = new Query<PlanningToolDailyVolume>(@"SELECT FIELD_ID, FIELD_INDEX, FSM_INDICATOR, OPERATION_TYPE, SIGN, VALID_FROM, VALID_TO, VALUE_HIGH, VALUE_LOW FROM PLANNING_TOOL_DAILY_VOLUMES", r =>
			{
				var fieldId = string.Empty;
				var fieldIndex = 0;
				var fsmIndicator = string.Empty;
				var operationType = string.Empty;
				var sign = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				var valueHigh = string.Empty;
				var valueLow = string.Empty;
				return new PlanningToolDailyVolume(fieldId, fieldIndex, fsmIndicator, operationType, sign, validFrom, validTo, valueHigh, valueLow);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlanningToolTarget> GetPlanningToolTargets(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlanningToolTarget>();

			var query = new Query<PlanningToolTarget>(@"SELECT ACTUALS, COMPANY_CODE, FISCAL_YEAR_PERIOD, FISCAL_YEAR_VARIANT, FSM_INDICATOR, FSM_INDICATOR_KEY, ORIGIN, ROUTE_CODE, TARGET, TERRITORY_ID, TRANSACTION_DATE FROM PLANNING_TOOL_TARGETS", r =>
			{
				var actuals = 0M;
				var companyCode = string.Empty;
				var fiscalYearPeriod = DateTime.MinValue;
				var fiscalYearVariant = string.Empty;
				var fsmIndicator = string.Empty;
				var fsmIndicatorKey = string.Empty;
				var origin = string.Empty;
				var routeCode = 0L;
				var target = 0M;
				var territoryId = string.Empty;
				var transactionDate = DateTime.MinValue;
				return new PlanningToolTarget(actuals, companyCode, fiscalYearPeriod, fiscalYearVariant, fsmIndicator, fsmIndicatorKey, origin, routeCode, target, territoryId, transactionDate);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlanningToolTeam> GetPlanningToolTeams(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlanningToolTeam>();

			var query = new Query<PlanningToolTeam>(@"SELECT FSM_INDICATOR, PLANNED_VALUE, PLANNING_DATE, USER_ID FROM PLANNING_TOOL_TEAMS", r =>
			{
				var fsmIndicator = string.Empty;
				var plannedValue = 0M;
				var planningDate = DateTime.MinValue;
				var userId = 0L;
				return new PlanningToolTeam(fsmIndicator, plannedValue, planningDate, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PlanningToolUser> GetPlanningToolUsers(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PlanningToolUser>();

			var query = new Query<PlanningToolUser>(@"SELECT ACTUAL_VALUE, FSM_INDICATOR, OUTLET_NUMBER, PLANNED_VALUE, PLANNING_DATE, USER_ID FROM PLANNING_TOOL_USERS", r =>
			{
				var actualValue = 0M;
				var fsmIndicator = string.Empty;
				var outletNumber = 0L;
				var plannedValue = 0M;
				var planningDate = DateTime.MinValue;
				var userId = 0L;
				return new PlanningToolUser(actualValue, fsmIndicator, outletNumber, plannedValue, planningDate, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PopArticle> GetPopArticles(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PopArticle>();

			var query = new Query<PopArticle>(@"SELECT ARTICLE_NUMBER, ENTRY_ID FROM POP_ARTICLES", r =>
			{
				var articleNumber = 0L;
				var entryId = 0L;
				return new PopArticle(articleNumber, entryId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PopEntrie> GetPopEntries(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PopEntrie>();

			var query = new Query<PopEntrie>(@"SELECT COMMENTS, ID, IS_DEFAULT, IS_VALID, NAME FROM POP_ENTRIES", r =>
			{
				var comments = string.Empty;
				var id = 0L;
				var isDefault = 0;
				var isValid = 0;
				var name = string.Empty;
				return new PopEntrie(comments, id, isDefault, isValid, name);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PromotionHeader> GetPromotionHeaders(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PromotionHeader>();

			var query = new Query<PromotionHeader>(@"SELECT ACTUALFINISH, ACTUALSTART, DESCRIPTION, IS_SUPPRESSED, MANUAL_STATUS, OBJECTIVE, PRIORITY, PROMOTION_GUID, PROMOTION_ID, TACTIC, TYPE, LONG_TEXT, PROMO_TYPE, PLANNED_START, PLANNED_FINISH, THRESHOLD FROM PROMOTION_HEADERS", r =>
			{
				var actualfinish = DateTime.MinValue;
				var actualstart = DateTime.MinValue;
				var description = string.Empty;
				var isSuppressed = 0;
				var manualStatus = string.Empty;
				var objective = string.Empty;
				var priority = 0;
				var promotionGuid = string.Empty;
				var promotionId = string.Empty;
				var tactic = string.Empty;
				var type = string.Empty;
				var longText = string.Empty;
				var promoType = string.Empty;
				var plannedStart = DateTime.MinValue;
				var plannedFinish = DateTime.MinValue;
				var threshold = 0L;
				return new PromotionHeader(actualfinish, actualstart, description, isSuppressed, manualStatus, objective, priority, promotionGuid, promotionId, tactic, type, longText, promoType, plannedStart, plannedFinish, threshold);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PromotionPrdItem> GetPromotionPrdItems(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PromotionPrdItem>();

			var query = new Query<PromotionPrdItem>(@"SELECT FREE_FLAG, PROMOTION_GUID, ARTICLE_NUMBER FROM PROMOTION_PRD_ITEMS", r =>
			{
				var freeFlag = string.Empty;
				var promotionGuid = string.Empty;
				var articleNumber = 0L;
				return new PromotionPrdItem(freeFlag, promotionGuid, articleNumber);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PromoMechanicsHeader> GetPromoMechanicsHeaders(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PromoMechanicsHeader>();

			var query = new Query<PromoMechanicsHeader>(@"SELECT GROUP_DESCRIPTION, GROUP_TYPE, MAX_GR, MIN_GR, PROMOTION_GUID FROM PROMO_MECHANICS_HEADERS", r =>
			{
				var groupDescription = string.Empty;
				var groupType = string.Empty;
				var maxGr = 0;
				var minGr = 0;
				var promotionGuid = string.Empty;
				return new PromoMechanicsHeader(groupDescription, groupType, maxGr, minGr, promotionGuid);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PromoPartnersHierarchy> GetPromoPartnersHierarchys(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PromoPartnersHierarchy>();

			var query = new Query<PromoPartnersHierarchy>(@"SELECT HIER_NODE, PROMOTION_GUID FROM PROMO_PARTNERS_HIERARCHY", r =>
			{
				var hierNode = string.Empty;
				var promotionGuid = string.Empty;
				return new PromoPartnersHierarchy(hierNode, promotionGuid);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<PromoScale> GetPromoScales(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<PromoScale>();

			var query = new Query<PromoScale>(@"SELECT FREE, GROUP1_STEP, GROUP2_STEP, GROUP3_STEP, PROMOTION_GUID FROM PROMO_SCALES", r =>
			{
				var free = 0;
				var group1Step = 0;
				var group2Step = 0;
				var group3Step = 0;
				var promotionGuid = string.Empty;
				return new PromoScale(free, group1Step, group2Step, group3Step, promotionGuid);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedActivitiesLog> GetRedActivitiesLogs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedActivitiesLog>();

			var query = new Query<RedActivitiesLog>(@"SELECT ACTIVITY_DATE, ACTIVITY_ID, ACTIVITY_TYPE, OUTLET_NUMBER, RED_INDEX, USER_ID FROM RED_ACTIVITIES_LOG", r =>
			{
				var activityDate = DateTime.MinValue;
				var activityId = 0L;
				var activityType = 0;
				var outletNumber = 0L;
				var redIndex = 0M;
				var userId = 0L;
				return new RedActivitiesLog(activityDate, activityId, activityType, outletNumber, redIndex, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedCccH> GetRedCccHs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedCccH>();

			var query = new Query<RedCccH>(@"SELECT COMMIT_ID, CONTRACT_ID, DESCRIPTION, VALID_FROM, VALID_TO FROM RED_CCC_H", r =>
			{
				var commitId = string.Empty;
				var contractId = string.Empty;
				var description = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new RedCccH(commitId, contractId, description, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedCccList> GetRedCccLists(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedCccList>();

			var query = new Query<RedCccList>(@"SELECT COMMIT_ID, LIST_TYPE, ARTICLE_NUMBER, PRODUCT, PARAM1, PARAM10, PARAM11, PARAM12, PARAM13, PARAM14, PARAM2, PARAM3, PARAM4, PARAM5, PARAM6, PARAM7, PARAM8, PARAM9, PARAM_POS, PFP_TARGET, QUESTION_ID, SHORT_TEXT, WEIGHT FROM RED_CCC_LIST", r =>
			{
				var commitId = string.Empty;
				var listType = 0;
				var articleNumber = 0L;
				var product = string.Empty;
				var param1 = string.Empty;
				var param10 = string.Empty;
				var param11 = string.Empty;
				var param12 = string.Empty;
				var param13 = string.Empty;
				var param14 = string.Empty;
				var param2 = string.Empty;
				var param3 = string.Empty;
				var param4 = string.Empty;
				var param5 = string.Empty;
				var param6 = string.Empty;
				var param7 = string.Empty;
				var param8 = string.Empty;
				var param9 = string.Empty;
				var paramPos = string.Empty;
				var pfpTarget = 0M;
				var questionId = string.Empty;
				var shortText = string.Empty;
				var weight = 0M;
				return new RedCccList(commitId, listType, articleNumber, product, param1, param10, param11, param12, param13, param14, param2, param3, param4, param5, param6, param7, param8, param9, paramPos, pfpTarget, questionId, shortText, weight);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedCccOutl> GetRedCccOutls(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedCccOutl>();

			var query = new Query<RedCccOutl>(@"SELECT COMMIT_ID, OUTLET_NUMBER, OUTL_ID, VALID_FROM, VALID_TO FROM RED_CCC_OUTL", r =>
			{
				var commitId = string.Empty;
				var outletNumber = 0L;
				var outlId = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new RedCccOutl(commitId, outletNumber, outlId, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedCccParVal> GetRedCccParVals(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedCccParVal>();

			var query = new Query<RedCccParVal>(@"SELECT PARAM_CODE, PARAM_ID, PARAM_POS, PARAM_TEXT, TYPE FROM RED_CCC_PAR_VAL", r =>
			{
				var paramCode = string.Empty;
				var paramId = string.Empty;
				var paramPos = string.Empty;
				var paramText = string.Empty;
				var type = 0;
				return new RedCccParVal(paramCode, paramId, paramPos, paramText, type);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedCccTarg> GetRedCccTargs(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedCccTarg>();

			var query = new Query<RedCccTarg>(@"SELECT COMMIT_ID, PFP_TARGET, QUESTION_ID FROM RED_CCC_TARG", r =>
			{
				var commitId = string.Empty;
				var pfpTarget = 0M;
				var questionId = string.Empty;
				return new RedCccTarg(commitId, pfpTarget, questionId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedCccTarVal> GetRedCccTarVals(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedCccTarVal>();

			var query = new Query<RedCccTarVal>(@"SELECT COMMIT_ID, QUESTION_ID, VALID_FROM, VALID_TO FROM RED_CCC_TAR_VAL", r =>
			{
				var commitId = string.Empty;
				var questionId = string.Empty;
				var validFrom = DateTime.MinValue;
				var validTo = DateTime.MinValue;
				return new RedCccTarVal(commitId, questionId, validFrom, validTo);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedGapsAction> GetRedGapsActions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedGapsAction>();

			var query = new Query<RedGapsAction>(@"SELECT TYPE, SECTION_ID, QUESTION_ID, GAP_ACTION FROM RED_GAPS_ACTIONS", r =>
			{
				var type = string.Empty;
				var sectionId = string.Empty;
				var questionId = string.Empty;
				var gapAction = string.Empty;
				return new RedGapsAction(type, sectionId, questionId, gapAction);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedGapsPlanning> GetRedGapsPlannings(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedGapsPlanning>();

			var query = new Query<RedGapsPlanning>(@"SELECT QUESTION_ID, REASON_CODE2, REASON_CODE, REASON_CODEGRP, PROCESS_TYPE FROM RED_GAPS_PLANNING", r =>
			{
				var questionId = string.Empty;
				var reasonCode2 = string.Empty;
				var reasonCode = string.Empty;
				var reasonCodegrp = string.Empty;
				var processType = string.Empty;
				return new RedGapsPlanning(questionId, reasonCode2, reasonCode, reasonCodegrp, processType);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedListingAnswer> GetRedListingAnswers(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedListingAnswer>();

			var query = new Query<RedListingAnswer>(@"SELECT ACTIVITY_ID, ORDINAL_NUMBER, VALUE FROM RED_LISTING_ANSWERS", r =>
			{
				var activityId = 0L;
				var ordinalNumber = 0L;
				var value = string.Empty;
				return new RedListingAnswer(activityId, ordinalNumber, value);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedListingHeader> GetRedListingHeaders(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedListingHeader>();

			var query = new Query<RedListingHeader>(@"SELECT LISTING_ID, TYPE, DESCRIPTION FROM RED_LISTING_HEADERS", r =>
			{
				var listingId = string.Empty;
				var type = 0;
				var description = string.Empty;
				return new RedListingHeader(listingId, type, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedListingItem> GetRedListingItems(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedListingItem>();

			var query = new Query<RedListingItem>(@"SELECT ID, WEIGHT, PARAM_POS, PARAM14, PARAM13, PARAM12, PARAM11, PARAM10, PARAM9, PARAM8, PARAM7, PARAM6, PARAM5, PARAM4, PARAM3, PARAM2, PARAM1, PRODUCT, LISTING_ID, ARTICLE_NUMBER, SHORT_TEXT FROM RED_LISTING_ITEMS", r =>
			{
				var id = 0L;
				var weight = 0M;
				var paramPos = string.Empty;
				var param14 = string.Empty;
				var param13 = string.Empty;
				var param12 = string.Empty;
				var param11 = string.Empty;
				var param10 = string.Empty;
				var param9 = string.Empty;
				var param8 = string.Empty;
				var param7 = string.Empty;
				var param6 = string.Empty;
				var param5 = string.Empty;
				var param4 = string.Empty;
				var param3 = string.Empty;
				var param2 = string.Empty;
				var param1 = string.Empty;
				var product = string.Empty;
				var listingId = string.Empty;
				var articleNumber = 0L;
				var shortText = string.Empty;
				return new RedListingItem(id, weight, paramPos, param14, param13, param12, param11, param10, param9, param8, param7, param6, param5, param4, param3, param2, param1, product, listingId, articleNumber, shortText);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedListMapping> GetRedListMappings(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedListMapping>();

			var query = new Query<RedListMapping>(@"SELECT POS_ID, LISTING_ID, QUESTION_ID, RED_POS FROM RED_LIST_MAPPING", r =>
			{
				var posId = string.Empty;
				var listingId = string.Empty;
				var questionId = string.Empty;
				var redPos = string.Empty;
				return new RedListMapping(posId, listingId, questionId, redPos);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedListParam> GetRedListParams(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedListParam>();

			var query = new Query<RedListParam>(@"SELECT TYPE, TEXT_FIELD, FIELD, VALUE_TABLE, FUNCTION_MODULE, DESCRIPTION, PARAM_POS, PARAM_ID FROM RED_LIST_PARAMS", r =>
			{
				var type = 0;
				var textField = string.Empty;
				var field = string.Empty;
				var valueTable = string.Empty;
				var functionModule = string.Empty;
				var description = string.Empty;
				var paramPos = string.Empty;
				var paramId = string.Empty;
				return new RedListParam(type, textField, field, valueTable, functionModule, description, paramPos, paramId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedMapping> GetRedMappings(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedMapping>();

			var query = new Query<RedMapping>(@"SELECT CCAF_VALUE, CHANNEL, CPL, POS_ID, DESCRIPTION, CPL_CHANNEL_CCAF FROM RED_MAPPING", r =>
			{
				var ccafValue = string.Empty;
				var channel = string.Empty;
				var cpl = string.Empty;
				var posId = string.Empty;
				var description = string.Empty;
				var cplChannelCcaf = string.Empty;
				return new RedMapping(ccafValue, channel, cpl, posId, description, cplChannelCcaf);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedParamsValue> GetRedParamsValues(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedParamsValue>();

			var query = new Query<RedParamsValue>(@"SELECT TYPE, PARAM_TEXT, PARAM_CODE, PARAM_ID, PARAM_POS FROM RED_PARAMS_VALUES", r =>
			{
				var type = 0;
				var paramText = string.Empty;
				var paramCode = string.Empty;
				var paramId = string.Empty;
				var paramPos = string.Empty;
				return new RedParamsValue(type, paramText, paramCode, paramId, paramPos);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<RedPosDescription> GetRedPosDescriptions(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<RedPosDescription>();

			var query = new Query<RedPosDescription>(@"SELECT POS_ID, DESCRIPTION FROM RED_POS_DESCRIPTIONS", r =>
			{
				var posId = string.Empty;
				var description = string.Empty;
				return new RedPosDescription(posId, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<SalesDistrict> GetSalesDistricts(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<SalesDistrict>();

			var query = new Query<SalesDistrict>(@"SELECT CODE, BZIRK, DESCRIPTION FROM SALES_DISTRICTS", r =>
			{
				var code = 0L;
				var bzirk = string.Empty;
				var description = string.Empty;
				return new SalesDistrict(code, bzirk, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<SapActivityHistory> GetSapActivityHistorys(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<SapActivityHistory>();

			var query = new Query<SapActivityHistory>(@"SELECT ACTIVITY_TYPE_ID, CHANGED_AT, CHANGED_BY, CREATED_AT, CREATED_BY, CRM_CHANGED_AT, DESCRIPTION, EXPIRES_AT, INPUT_CHANNEL, OUTLET_NUMBER, PARTNER_NO, PHX_CHANGED_AT, POSTING_DATE, SAP_CODE, SAP_ID, GUID FROM SAP_ACTIVITY_HISTORY", r =>
			{
				var activityTypeId = 0;
				var changedAt = DateTime.MinValue;
				var changedBy = string.Empty;
				var createdAt = DateTime.MinValue;
				var createdBy = string.Empty;
				var crmChangedAt = DateTime.MinValue;
				var description = string.Empty;
				var expiresAt = DateTime.MinValue;
				var inputChannel = string.Empty;
				var outletNumber = 0L;
				var partnerNo = string.Empty;
				var phxChangedAt = DateTime.MinValue;
				var postingDate = DateTime.MinValue;
				var sapCode = string.Empty;
				var sapId = 0L;
				var guid = string.Empty;
				return new SapActivityHistory(activityTypeId, changedAt, changedBy, createdAt, createdBy, crmChangedAt, description, expiresAt, inputChannel, outletNumber, partnerNo, phxChangedAt, postingDate, sapCode, sapId, guid);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<SapActivityHistoryDetail> GetSapActivityHistoryDetails(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<SapActivityHistoryDetail>();

			var query = new Query<SapActivityHistoryDetail>(@"SELECT DISPLAY_TEXT, IS_PENDING, SAP_ID, SAP_STATUS, SAP_STATUS_PROFILE, STATUS_TYPE, TEXT FROM SAP_ACTIVITY_HISTORY_DETAILS", r =>
			{
				var displayText = string.Empty;
				var isPending = 0;
				var sapId = 0L;
				var sapStatus = string.Empty;
				var sapStatusProfile = string.Empty;
				var statusType = 0;
				var text = string.Empty;
				return new SapActivityHistoryDetail(displayText, isPending, sapId, sapStatus, sapStatusProfile, statusType, text);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<SapActivityProcType> GetSapActivityProcTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<SapActivityProcType>();

			var query = new Query<SapActivityProcType>(@"SELECT PROCESS_TYPE, DESCRIPTION, ENSCRIPTION FROM SAP_ACTIVITY_PROC_TYPES", r =>
			{
				var processType = string.Empty;
				var description = string.Empty;
				var enscription = string.Empty;
				return new SapActivityProcType(processType, description, enscription);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<ShipToOutlet> GetShipToOutlets(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<ShipToOutlet>();

			var query = new Query<ShipToOutlet>(@"SELECT OUTLET_NUMBER, NAME1, NAME2, ADDRESS, FAX, POSTAL_CODE, CITY, TELEPHONE, CONTACT_PERSON, TELEPHONE_2, EMAIL, LONGITUDE, LATITUDE FROM SHIP_TO_OUTLETS", r =>
			{
				var outletNumber = 0L;
				var name1 = string.Empty;
				var name2 = string.Empty;
				var address = string.Empty;
				var fax = string.Empty;
				var postalCode = string.Empty;
				var city = string.Empty;
				var telephone = string.Empty;
				var contactPerson = string.Empty;
				var telephone2 = string.Empty;
				var email = string.Empty;
				var longitude = 0M;
				var latitude = 0M;
				return new ShipToOutlet(outletNumber, name1, name2, address, fax, postalCode, city, telephone, contactPerson, telephone2, email, longitude, latitude);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<SmartDeviceType> GetSmartDeviceTypes(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<SmartDeviceType>();

			var query = new Query<SmartDeviceType>(@"SELECT DESCRIPTION, IS_DATA_CAPABLE, LANG, TYPE_ID FROM SMART_DEVICE_TYPES", r =>
			{
				var description = string.Empty;
				var isDataCapable = 0;
				var lang = string.Empty;
				var typeId = string.Empty;
				return new SmartDeviceType(description, isDataCapable, lang, typeId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<StatusList> GetStatusLists(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<StatusList>();

			var query = new Query<StatusList>(@"SELECT ID, PARENT_ID, DESCRIPTION, DROPDOWN_ID, IS_SUPPRESSED, PARENT_DROPDOWN_ID, CODE, PARENT_CODE FROM STATUS_LISTS", r =>
			{
				var id = 0L;
				var parentId = 0L;
				var description = string.Empty;
				var dropdownId = 0L;
				var isSuppressed = 0;
				var parentDropdownId = 0L;
				var code = string.Empty;
				var parentCode = string.Empty;
				return new StatusList(id, parentId, description, dropdownId, isSuppressed, parentDropdownId, code, parentCode);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<SubTradeChannel> GetSubTradeChannels(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<SubTradeChannel>();

			var query = new Query<SubTradeChannel>(@"SELECT CODE, ATTRIB_7, DESCRIPTION FROM SUB_TRADE_CHANNELS", r =>
			{
				var code = 0L;
				var attrib7 = string.Empty;
				var description = string.Empty;
				return new SubTradeChannel(code, attrib7, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Survey> GetSurveys(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Survey>();

			var query = new Query<Survey>(@"SELECT DESCRIPTION, FROM_DATE, ID, IS_COPY_LAST_VALUES, IS_GRID_VIEW, IS_RED, POS_ID, RED_INDEX, SEQUENCE, SET_ID, SUPPRESSED, TO_DATE, WEIGHT_RATIO FROM SURVEYS", r =>
			{
				var description = string.Empty;
				var fromDate = DateTime.MinValue;
				var id = 0L;
				var isCopyLastValues = 0;
				var isGridView = 0;
				var isRed = 0;
				var posId = string.Empty;
				var redIndex = 0L;
				var sequence = 0L;
				var setId = 0L;
				var suppressed = 0;
				var toDate = DateTime.MinValue;
				var weightRatio = 0M;
				return new Survey(description, fromDate, id, isCopyLastValues, isGridView, isRed, posId, redIndex, sequence, setId, suppressed, toDate, weightRatio);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<SurveyActivitie> GetSurveyActivities(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<SurveyActivitie>();

			var query = new Query<SurveyActivitie>(@"SELECT ACTIVITY_ID, SURVEY_ID, IS_COMPLETED, TARGET_SCORE, ACTUAL_SCORE, COMMIT_ID, RED_INDEX FROM SURVEY_ACTIVITIES", r =>
			{
				var activityId = 0L;
				var surveyId = 0L;
				var isCompleted = 0;
				var targetScore = 0M;
				var actualScore = 0M;
				var commitId = string.Empty;
				var redIndex = 0M;
				return new SurveyActivitie(activityId, surveyId, isCompleted, targetScore, actualScore, commitId, redIndex);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Tracing> GetTracings(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Tracing>();

			var query = new Query<Tracing>(@"SELECT ASSEMBLY_VERSION, CATEGORY, DEVICE_ID, LOG_TIME, MESSAGE, SAVE_ORDER, USER_ID, APL_SCREEN, APL_OPERATION, APL_CONTROL_TYPE, APL_DETAILS, APL_USER_NAME FROM TRACING", r =>
			{
				var assemblyVersion = string.Empty;
				var category = 0;
				var deviceId = 0L;
				var logTime = DateTime.MinValue;
				var message = string.Empty;
				var saveOrder = 0;
				var userId = 0L;
				var aplScreen = string.Empty;
				var aplOperation = string.Empty;
				var aplControlType = string.Empty;
				var aplDetails = string.Empty;
				var aplUserName = string.Empty;
				return new Tracing(assemblyVersion, category, deviceId, logTime, message, saveOrder, userId, aplScreen, aplOperation, aplControlType, aplDetails, aplUserName);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<TradeChannel> GetTradeChannels(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<TradeChannel>();

			var query = new Query<TradeChannel>(@"SELECT CODE, ATTRIB_6, DESCRIPTION FROM TRADE_CHANNELS", r =>
			{
				var code = 0L;
				var attrib6 = string.Empty;
				var description = string.Empty;
				return new TradeChannel(code, attrib6, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<UserMessage> GetUserMessages(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<UserMessage>();

			var query = new Query<UserMessage>(@"SELECT CREATED_ON, EXPIRES_ON, ACTIVE_FROM, ID, IS_READ, IS_URGENT, MESSAGE, PC_ID, USER_GROUP, USER_ID FROM USER_MESSAGES", r =>
			{
				var createdOn = DateTime.MinValue;
				var expiresOn = DateTime.MinValue;
				var activeFrom = DateTime.MinValue;
				var id = 0L;
				var isRead = 0;
				var isUrgent = 0;
				var message = string.Empty;
				var pcId = 0L;
				var userGroup = 0L;
				var userId = 0L;
				return new UserMessage(createdOn, expiresOn, activeFrom, id, isRead, isUrgent, message, pcId, userGroup, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<UserRouteSnap> GetUserRouteSnaps(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<UserRouteSnap>();

			var query = new Query<UserRouteSnap>(@"SELECT FROM_DATE, ID, ROUTE_CODE, TERRITORY, TO_DATE, USER_ID FROM USER_ROUTE_SNAP", r =>
			{
				var fromDate = DateTime.MinValue;
				var id = 0L;
				var routeCode = 0L;
				var territory = string.Empty;
				var toDate = DateTime.MinValue;
				var userId = 0L;
				return new UserRouteSnap(fromDate, id, routeCode, territory, toDate, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<UserSetting> GetUserSettings(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<UserSetting>();

			var query = new Query<UserSetting>(@"SELECT Id, Context, Name, Value FROM USER_SETTINGS", r =>
			{
				var id = 0L;
				var ctx = string.Empty;
				var name = string.Empty;
				var value = string.Empty;
				return new UserSetting(id, ctx, name, value);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<UserSnap> GetUserSnaps(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<UserSnap>();

			var query = new Query<UserSnap>(@"SELECT ADDRESS, E_MAIL, FULL_NAME, INDUSTRY, IS_AUDITTOOL_USER, IS_SUPERVISOR, PARENT_ID, PHONE_NUMBER, SHORT_NAME, USER_GROUP_ID, USER_ID FROM USER_SNAP", r =>
			{
				var address = string.Empty;
				var eMail = string.Empty;
				var fullName = string.Empty;
				var industry = string.Empty;
				var isAudittoolUser = 0;
				var isSupervisor = 0;
				var parentId = 0L;
				var phoneNumber = string.Empty;
				var shortName = string.Empty;
				var userGroupId = 0L;
				var userId = 0L;
				return new UserSnap(address, eMail, fullName, industry, isAudittoolUser, isSupervisor, parentId, phoneNumber, shortName, userGroupId, userId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Visit> GetVisits(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Visit>();

			var query = new Query<Visit>(@"SELECT ID, CREATION_DATE, IS_CLOSED, ORIGIN, OUTLET_NUMBER, PLANNED_DATE, PLANNED_TIMEIN, SEQUENCE, STATUS_CODE, TIMEIN, TIMEOUT, USER_ID, VISIT_DATE, STATUS_REASON_LIST_ID, REASON_LIST_ID, SUB_REASON_LIST_ID, EQUIPMENT_NUMBER, NOT_SCANNED_REASON_LIST_ID, SCANNED_TIME, STATUS_LIST_ID, ACTUAL_FROM, ACTUAL_TO, DESCRIPTION FROM VISITS", r =>
			{
				var id = 0L;
				var creationDate = DateTime.MinValue;
				var isClosed = 0;
				var origin = string.Empty;
				var outletNumber = 0L;
				var plannedDate = DateTime.MinValue;
				var plannedTimein = DateTime.MinValue;
				var sequence = 0;
				var statusCode = 0L;
				var timein = DateTime.MinValue;
				var timeout = DateTime.MinValue;
				var userId = 0L;
				var visitDate = DateTime.MinValue;
				var statusReasonListId = 0L;
				var reasonListId = 0L;
				var subReasonListId = 0L;
				var equipmentNumber = string.Empty;
				var notScannedReasonListId = 0L;
				var scannedTime = DateTime.MinValue;
				var statusListId = 0L;
				var actualFrom = DateTime.MinValue;
				var actualTo = DateTime.MinValue;
				var description = string.Empty;
				return new Visit(id, creationDate, isClosed, origin, outletNumber, plannedDate, plannedTimein, sequence, statusCode, timein, timeout, userId, visitDate, statusReasonListId, reasonListId, subReasonListId, equipmentNumber, notScannedReasonListId, scannedTime, statusListId, actualFrom, actualTo, description);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<VisitComment> GetVisitComments(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<VisitComment>();

			var query = new Query<VisitComment>(@"SELECT ACTIVITY_ID, CREATED_ON, ID, IS_BY_ADMIN, MESSAGE, SEQUENCE_NUM, USERNAME, VISIT_ID FROM VISIT_COMMENTS", r =>
			{
				var activityId = 0L;
				var createdOn = DateTime.MinValue;
				var id = 0L;
				var isByAdmin = 0;
				var message = string.Empty;
				var sequenceNum = 0L;
				var username = string.Empty;
				var visitId = 0L;
				return new VisitComment(activityId, createdOn, id, isByAdmin, message, sequenceNum, username, visitId);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}

		public static List<Wholesaler> GetWholesalers(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var items = new List<Wholesaler>();

			var query = new Query<Wholesaler>(@"SELECT ADDRESS, CITY, DELIVERY_LOCATION_CODE, E_MAIL, FAX_NUMBER, GRID_DESCRIPTION, GRID_NUMBER, GRID_TYPE, ID, INDUSTRY, IS_SUPPRESSED, NAME1, NAME2, POSTAL_CODE, TEL_NUMBER, BLOCK_REASON FROM WHOLESALERS", r =>
			{
				var address = string.Empty;
				var city = string.Empty;
				var deliveryLocationCode = 0L;
				var eMail = string.Empty;
				var faxNumber = string.Empty;
				var gridDescription = string.Empty;
				var gridNumber = string.Empty;
				var gridType = string.Empty;
				var id = 0L;
				var industry = string.Empty;
				var isSuppressed = 0;
				var name1 = string.Empty;
				var name2 = string.Empty;
				var postalCode = string.Empty;
				var telNumber = string.Empty;
				var blockReason = string.Empty;
				return new Wholesaler(address, city, deliveryLocationCode, eMail, faxNumber, gridDescription, gridNumber, gridType, id, industry, isSuppressed, name1, name2, postalCode, telNumber, blockReason);
			});
			foreach (var item in context.Execute(query))
			{
				items.Add(item);
			}

			return items;
		}







	}
}