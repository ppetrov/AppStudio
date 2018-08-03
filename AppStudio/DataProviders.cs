using System;
using System.Collections.Generic;
using AppCore;
using AppCore.Data;

namespace AppStudio
{
	public static class DataProviders
	{
		
public static List<ActivationCompliance> GetActivationCompliances(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ActivationCompliance>();
	
	var query = new Query<ActivationCompliance>(@"SELECT ACTIVATION_ID, ACTIVATION_INDEX, PARAM_NAME, PARAM_VALUE FROM ACTIVATION_COMPLIANCES", r =>
	{
	var activationId = Query.GetString(r, 0);
var activationIndex = Query.GetInt(r, 1);
var paramName = Query.GetString(r, 2);
var paramValue = Query.GetString(r, 3);

return new ActivationCompliance(activationId, activationIndex, paramName, paramValue);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ActivationDefinition> GetActivationDefinitions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ActivationDefinition>();
	
	var query = new Query<ActivationDefinition>(@"SELECT ACTIVATION_ID, ACTIVATION_NAME, ACTIVATION_DESC, ACTIVATION_START, ACTIVATION_END, ACTIVATION_TYPE, IS_MANDATORY, IS_GENERATOR, STATUS, LINKED_DOC, ZONE_SUBZONE, PROMO_COMPLIANCE, POP_ACTIVATION, QUANT_OF_POI, SIZE_OF_POI, CUST_SPACE_TYPE_CODE, CUST_SPACE_TYPE_TEXT, TARGET_ZONE FROM ACTIVATION_DEFINITIONS", r =>
	{
	var activationId = Query.GetString(r, 0);
var activationName = Query.GetString(r, 1);
var activationDesc = Query.GetString(r, 2);
var activationStart = Query.GetDateTime(r, 3);
var activationEnd = Query.GetDateTime(r, 4);
var activationType = Query.GetString(r, 5);
var isMandatory = Query.GetInt(r, 6);
var isGenerator = Query.GetInt(r, 7);
var status = Query.GetString(r, 8);
var linkedDoc = Query.GetString(r, 9);
var zoneSubzone = Query.GetString(r, 10);
var promoCompliance = Query.GetString(r, 11);
var popActivation = Query.GetString(r, 12);
var quantOfPoi = Query.GetString(r, 13);
var sizeOfPoi = Query.GetString(r, 14);
var custSpaceTypeCode = Query.GetString(r, 15);
var custSpaceTypeText = Query.GetString(r, 16);
var targetZone = Query.GetString(r, 17);

return new ActivationDefinition(activationId, activationName, activationDesc, activationStart, activationEnd, activationType, isMandatory, isGenerator, status, linkedDoc, zoneSubzone, promoCompliance, popActivation, quantOfPoi, sizeOfPoi, custSpaceTypeCode, custSpaceTypeText, targetZone);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ActivationReject> GetActivationRejects(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ActivationReject>();
	
	var query = new Query<ActivationReject>(@"SELECT Id, Outlet, Activation FROM ACTIVATION_REJECTS", r =>
	{
	var id = Query.GetLong(r, 0);
var outlet = Query.GetLong(r, 1);
var activation = Query.GetString(r, 2);

return new ActivationReject(id, outlet, activation);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ActivationStatu> GetActivationStatus(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ActivationStatu>();
	
	var query = new Query<ActivationStatu>(@"SELECT ACTIVATION_ID, QUANTITY_OF_POI, EXECUTED_POI FROM ACTIVATION_STATUS", r =>
	{
	var activationId = Query.GetString(r, 0);
var quantityOfPoi = Query.GetLong(r, 1);
var executedPoi = Query.GetLong(r, 2);

return new ActivationStatu(activationId, quantityOfPoi, executedPoi);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Activitie> GetActivities(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Activitie>();
	
	var query = new Query<Activitie>(@"SELECT DETAILS, FINISH_TIME, ID, ORIGIN, PRODUCTIVE_TIME, SEQUENCE, START_TIME, STATUS_ID, TYPE_ID, VISIT_ID, STATUS_REASON_LIST_ID, REASON_LIST_ID, SUB_REASON_LIST_ID, SURVEY_ID, STATUS_LIST_ID, ACTUAL_FROM, ACTUAL_TO, DESCRIPTION, SAP_ID, SAP_REASON_LIST_ID, PARENT_ACTIVITY_ID, HEADER_GUID, IS_GPS_TURNED_ON, ACTIVATION_ID FROM ACTIVITIES", r =>
	{
	var details = Query.GetString(r, 0);
var finishTime = Query.GetDateTime(r, 1);
var id = Query.GetLong(r, 2);
var origin = Query.GetString(r, 3);
var productiveTime = Query.GetLong(r, 4);
var sequence = Query.GetInt(r, 5);
var startTime = Query.GetDateTime(r, 6);
var statusId = Query.GetInt(r, 7);
var typeId = Query.GetInt(r, 8);
var visitId = Query.GetLong(r, 9);
var statusReasonListId = Query.GetLong(r, 10);
var reasonListId = Query.GetLong(r, 11);
var subReasonListId = Query.GetLong(r, 12);
var surveyId = Query.GetLong(r, 13);
var statusListId = Query.GetLong(r, 14);
var actualFrom = Query.GetDateTime(r, 15);
var actualTo = Query.GetDateTime(r, 16);
var description = Query.GetString(r, 17);
var sapId = Query.GetLong(r, 18);
var sapReasonListId = Query.GetLong(r, 19);
var parentActivityId = Query.GetLong(r, 20);
var headerGuid = Query.GetString(r, 21);
var isGpsTurnedOn = Query.GetInt(r, 22);
var activationId = Query.GetString(r, 23);

return new Activitie(details, finishTime, id, origin, productiveTime, sequence, startTime, statusId, typeId, visitId, statusReasonListId, reasonListId, subReasonListId, surveyId, statusListId, actualFrom, actualTo, description, sapId, sapReasonListId, parentActivityId, headerGuid, isGpsTurnedOn, activationId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ActivityStatuse> GetActivityStatuses(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ActivityStatuse>();
	
	var query = new Query<ActivityStatuse>(@"SELECT DESCRIPTION, ID, NAME FROM ACTIVITY_STATUSES", r =>
	{
	var description = Query.GetString(r, 0);
var id = Query.GetInt(r, 1);
var name = Query.GetString(r, 2);

return new ActivityStatuse(description, id, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ActivityStatusLog> GetActivityStatusLogs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ActivityStatusLog>();
	
	var query = new Query<ActivityStatusLog>(@"SELECT ACTIVITY_ID, TEXT, STATUS_TYPE FROM ACTIVITY_STATUS_LOG", r =>
	{
	var activityId = Query.GetLong(r, 0);
var text = Query.GetString(r, 1);
var statusType = Query.GetInt(r, 2);

return new ActivityStatusLog(activityId, text, statusType);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ActivityType> GetActivityTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ActivityType>();
	
	var query = new Query<ActivityType>(@"SELECT DESCRIPTION, ID, IS_ACTIVE, LOCAL_NAME, NAME, SAP_CODE, CATEGORY FROM ACTIVITY_TYPES", r =>
	{
	var description = Query.GetString(r, 0);
var id = Query.GetInt(r, 1);
var isActive = Query.GetInt(r, 2);
var localName = Query.GetString(r, 3);
var name = Query.GetString(r, 4);
var sapCode = Query.GetString(r, 5);
var category = Query.GetString(r, 6);

return new ActivityType(description, id, isActive, localName, name, sapCode, category);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<AllArticleGroup> GetAllArticleGroups(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<AllArticleGroup>();
	
	var query = new Query<AllArticleGroup>(@"SELECT ART_GROUP, PRC_GROUP, DESCRIPTION FROM ALL_ARTICLE_GROUPS", r =>
	{
	var artGroup = Query.GetLong(r, 0);
var prcGroup = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new AllArticleGroup(artGroup, prcGroup, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArticlePrice> GetArticlePrices(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArticlePrice>();
	
	var query = new Query<ArticlePrice>(@"SELECT ARTICLE_NUMBER, CURRENCY, PRICE, PRICE_GROUP, VALID_FROM, VALID_TO FROM ARTICLE_PRICES", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var currency = Query.GetString(r, 1);
var price = Query.GetDecimal(r, 2);
var priceGroup = Query.GetString(r, 3);
var validFrom = Query.GetDateTime(r, 4);
var validTo = Query.GetDateTime(r, 5);

return new ArticlePrice(articleNumber, currency, price, priceGroup, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArticleSnap> GetArticleSnaps(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArticleSnap>();
	
	var query = new Query<ArticleSnap>(@"SELECT ARTICLES_PER_PALETTE, ARTICLE_GROUP1_BCODE, ARTICLE_GROUP1_DESC, ARTICLE_GROUP2_BCODE, ARTICLE_GROUP2_DESC, ARTICLE_GROUP3_BCODE, ARTICLE_GROUP3_DESC, ARTICLE_GROUP4_BCODE, ARTICLE_GROUP4_DESC, ARTICLE_GROUP5_BCODE, ARTICLE_GROUP5_DESC, ARTICLE_NUMBER, ARTICLE_TYPE_CODE, CONVFACTOR1, CONVFACTOR2, CUBE, EANCODE, EANSUBUNITCODE, EMPTIES_ARTICLE_NUMBER, EMPTIES_SUBUNIT_ARTICLE_NUMBER, LONG_NAME, MATERIAL_CATEGORY_CODE, PRICE, SEQUENCE, SHORT_NAME, SUBUNITS, SUPPRDATE, SUPPRESSED_CODE, WEIGHT, EXTERNAL_NUMBER, BASE_UNIT, BASE_SUBUNIT, BASE_ARTICLE_NUMBER, MATERIAL_PRICING_GROUP FROM ARTICLE_SNAP", r =>
	{
	var articlesPerPalette = Query.GetInt(r, 0);
var articleGroup1Bcode = Query.GetString(r, 1);
var articleGroup1Desc = Query.GetString(r, 2);
var articleGroup2Bcode = Query.GetString(r, 3);
var articleGroup2Desc = Query.GetString(r, 4);
var articleGroup3Bcode = Query.GetString(r, 5);
var articleGroup3Desc = Query.GetString(r, 6);
var articleGroup4Bcode = Query.GetString(r, 7);
var articleGroup4Desc = Query.GetString(r, 8);
var articleGroup5Bcode = Query.GetString(r, 9);
var articleGroup5Desc = Query.GetString(r, 10);
var articleNumber = Query.GetLong(r, 11);
var articleTypeCode = Query.GetLong(r, 12);
var convfactor1 = Query.GetDecimal(r, 13);
var convfactor2 = Query.GetDecimal(r, 14);
var cube = Query.GetDecimal(r, 15);
var eancode = Query.GetString(r, 16);
var eansubunitcode = Query.GetString(r, 17);
var emptiesArticleNumber = Query.GetLong(r, 18);
var emptiesSubunitArticleNumber = Query.GetLong(r, 19);
var longName = Query.GetString(r, 20);
var materialCategoryCode = Query.GetLong(r, 21);
var price = Query.GetDecimal(r, 22);
var sequence = Query.GetInt(r, 23);
var shortName = Query.GetString(r, 24);
var subunits = Query.GetLong(r, 25);
var supprdate = Query.GetDateTime(r, 26);
var suppressedCode = Query.GetString(r, 27);
var weight = Query.GetDecimal(r, 28);
var externalNumber = Query.GetString(r, 29);
var baseUnit = Query.GetString(r, 30);
var baseSubunit = Query.GetString(r, 31);
var baseArticleNumber = Query.GetLong(r, 32);
var materialPricingGroup = Query.GetString(r, 33);

return new ArticleSnap(articlesPerPalette, articleGroup1Bcode, articleGroup1Desc, articleGroup2Bcode, articleGroup2Desc, articleGroup3Bcode, articleGroup3Desc, articleGroup4Bcode, articleGroup4Desc, articleGroup5Bcode, articleGroup5Desc, articleNumber, articleTypeCode, convfactor1, convfactor2, cube, eancode, eansubunitcode, emptiesArticleNumber, emptiesSubunitArticleNumber, longName, materialCategoryCode, price, sequence, shortName, subunits, supprdate, suppressedCode, weight, externalNumber, baseUnit, baseSubunit, baseArticleNumber, materialPricingGroup);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArticleType> GetArticleTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArticleType>();
	
	var query = new Query<ArticleType>(@"SELECT CODE, MTART, DESCRIPTION FROM ARTICLE_TYPES", r =>
	{
	var code = Query.GetLong(r, 0);
var mtart = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new ArticleType(code, mtart, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArticleUnitConversion> GetArticleUnitConversions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArticleUnitConversion>();
	
	var query = new Query<ArticleUnitConversion>(@"SELECT ARTICLE_NUMBER, DENOMINATOR, EXPONENT10, IS_BASE_UNIT, NUMERATOR, UNIT, VALID_FROM, VALID_TO FROM ARTICLE_UNIT_CONVERSIONS", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var denominator = Query.GetLong(r, 1);
var exponent10 = Query.GetInt(r, 2);
var isBaseUnit = Query.GetInt(r, 3);
var numerator = Query.GetLong(r, 4);
var unit = Query.GetString(r, 5);
var validFrom = Query.GetDateTime(r, 6);
var validTo = Query.GetDateTime(r, 7);

return new ArticleUnitConversion(articleNumber, denominator, exponent10, isBaseUnit, numerator, unit, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArBankDeposit> GetArBankDeposits(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArBankDeposit>();
	
	var query = new Query<ArBankDeposit>(@"SELECT BANK_NAME, CASH_DEPOSIT_AMOUNT, CHEQUE_DEPOSIT_AMOUNT, DEPOSIT_DATE, DEPOSIT_KEY, DEPOSIT_SLIP_NUMBER, ID, IS_CLOSED, NIGHT_SAFE, OTHERS_AMOUNT, USER_ID FROM AR_BANK_DEPOSITS", r =>
	{
	var bankName = Query.GetString(r, 0);
var cashDepositAmount = Query.GetDecimal(r, 1);
var chequeDepositAmount = Query.GetDecimal(r, 2);
var depositDate = Query.GetDateTime(r, 3);
var depositKey = Query.GetString(r, 4);
var depositSlipNumber = Query.GetString(r, 5);
var id = Query.GetLong(r, 6);
var isClosed = Query.GetInt(r, 7);
var nightSafe = Query.GetInt(r, 8);
var othersAmount = Query.GetDecimal(r, 9);
var userId = Query.GetLong(r, 10);

return new ArBankDeposit(bankName, cashDepositAmount, chequeDepositAmount, depositDate, depositKey, depositSlipNumber, id, isClosed, nightSafe, othersAmount, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArCurrency> GetArCurrencys(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArCurrency>();
	
	var query = new Query<ArCurrency>(@"SELECT DESCRIPTION, ID, IS_DEFAULT, LOCAL_DESCRIPTION, SHORT_NAME FROM AR_CURRENCY", r =>
	{
	var description = Query.GetString(r, 0);
var id = Query.GetLong(r, 1);
var isDefault = Query.GetInt(r, 2);
var localDescription = Query.GetString(r, 3);
var shortName = Query.GetString(r, 4);

return new ArCurrency(description, id, isDefault, localDescription, shortName);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArInvoice> GetArInvoices(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArInvoice>();
	
	var query = new Query<ArInvoice>(@"SELECT DUE_DATE, ID, INVOICE_DATE, INVOICE_NUMBER, IS_DELETED, NOTE, OPEN_AMOUNT, OUTLET_NUMBER, PAYER_NUMBER, TOTAL_AMOUNT FROM AR_INVOICES", r =>
	{
	var dueDate = Query.GetDateTime(r, 0);
var id = Query.GetLong(r, 1);
var invoiceDate = Query.GetDateTime(r, 2);
var invoiceNumber = Query.GetString(r, 3);
var isDeleted = Query.GetInt(r, 4);
var note = Query.GetString(r, 5);
var openAmount = Query.GetDecimal(r, 6);
var outletNumber = Query.GetLong(r, 7);
var payerNumber = Query.GetLong(r, 8);
var totalAmount = Query.GetDecimal(r, 9);

return new ArInvoice(dueDate, id, invoiceDate, invoiceNumber, isDeleted, note, openAmount, outletNumber, payerNumber, totalAmount);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArPayment> GetArPayments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArPayment>();
	
	var query = new Query<ArPayment>(@"SELECT ACTIVITY_ID, BANK_DEPOSIT_ID, CASH_PAID_AMOUNT, CURRENCY_ID, CUSTOMER_RECEIPT_NBR, DELIVERY_DOC_NBR, ID, NOTE, OTHERS_AMOUNT, OTHERS_DESCRIPTION, PAYMENT_DATE, PRINT_TIME, TOTALS_AMOUNT FROM AR_PAYMENTS", r =>
	{
	var activityId = Query.GetLong(r, 0);
var bankDepositId = Query.GetLong(r, 1);
var cashPaidAmount = Query.GetDecimal(r, 2);
var currencyId = Query.GetLong(r, 3);
var customerReceiptNbr = Query.GetString(r, 4);
var deliveryDocNbr = Query.GetString(r, 5);
var id = Query.GetLong(r, 6);
var note = Query.GetString(r, 7);
var othersAmount = Query.GetDecimal(r, 8);
var othersDescription = Query.GetString(r, 9);
var paymentDate = Query.GetDateTime(r, 10);
var printTime = Query.GetDateTime(r, 11);
var totalsAmount = Query.GetDecimal(r, 12);

return new ArPayment(activityId, bankDepositId, cashPaidAmount, currencyId, customerReceiptNbr, deliveryDocNbr, id, note, othersAmount, othersDescription, paymentDate, printTime, totalsAmount);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArPaymentCheque> GetArPaymentCheques(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArPaymentCheque>();
	
	var query = new Query<ArPaymentCheque>(@"SELECT BANK_NAME, CHEQUE_NUMBER, PAID_AMOUNT, PAYMENT_ID, VALID_FROM, VALID_TO FROM AR_PAYMENT_CHEQUES", r =>
	{
	var bankName = Query.GetString(r, 0);
var chequeNumber = Query.GetString(r, 1);
var paidAmount = Query.GetDecimal(r, 2);
var paymentId = Query.GetLong(r, 3);
var validFrom = Query.GetDateTime(r, 4);
var validTo = Query.GetDateTime(r, 5);

return new ArPaymentCheque(bankName, chequeNumber, paidAmount, paymentId, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ArPaymentDetail> GetArPaymentDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ArPaymentDetail>();
	
	var query = new Query<ArPaymentDetail>(@"SELECT BANK_DEPOSIT_ID, INVOICE_ID, IS_PARTIAL, OPEN_AMOUNT, PAID_AMOUNT, PAYMENT_ID FROM AR_PAYMENT_DETAILS", r =>
	{
	var bankDepositId = Query.GetLong(r, 0);
var invoiceId = Query.GetLong(r, 1);
var isPartial = Query.GetInt(r, 2);
var openAmount = Query.GetDecimal(r, 3);
var paidAmount = Query.GetDecimal(r, 4);
var paymentId = Query.GetLong(r, 5);

return new ArPaymentDetail(bankDepositId, invoiceId, isPartial, openAmount, paidAmount, paymentId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Assortment> GetAssortments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Assortment>();
	
	var query = new Query<Assortment>(@"SELECT ARTICLENUMBER, OUTLETNUMBER, SEQUENCE FROM ASSORTMENTS", r =>
	{
	var articlenumber = Query.GetLong(r, 0);
var outletnumber = Query.GetLong(r, 1);
var sequence = Query.GetLong(r, 2);

return new Assortment(articlenumber, outletnumber, sequence);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<AtpOrderDetail> GetAtpOrderDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<AtpOrderDetail>();
	
	var query = new Query<AtpOrderDetail>(@"SELECT ARTICLE_NUMBER, ATP_ALT_PRODUCT, ATP_CONFIRMED_QUANTITY, ATP_ITEM_TYPE, ATP_ORDERED_QUANTITY, ATP_PRICE, ATP_PROMOTION, ATP_QUANTITY_UNITS, ATP_STATUS, ATP_VENDOR, ORDER_NUMBER, SEQUENTIAL_NUMBER FROM ATP_ORDER_DETAILS", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var atpAltProduct = Query.GetLong(r, 1);
var atpConfirmedQuantity = Query.GetDecimal(r, 2);
var atpItemType = Query.GetString(r, 3);
var atpOrderedQuantity = Query.GetDecimal(r, 4);
var atpPrice = Query.GetDecimal(r, 5);
var atpPromotion = Query.GetString(r, 6);
var atpQuantityUnits = Query.GetString(r, 7);
var atpStatus = Query.GetString(r, 8);
var atpVendor = Query.GetString(r, 9);
var orderNumber = Query.GetLong(r, 10);
var sequentialNumber = Query.GetLong(r, 11);

return new AtpOrderDetail(articleNumber, atpAltProduct, atpConfirmedQuantity, atpItemType, atpOrderedQuantity, atpPrice, atpPromotion, atpQuantityUnits, atpStatus, atpVendor, orderNumber, sequentialNumber);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<AtpOrderMessage> GetAtpOrderMessages(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<AtpOrderMessage>();
	
	var query = new Query<AtpOrderMessage>(@"SELECT ORDER_NUMBER, SEQUENTIAL_NUMBER, TEXT FROM ATP_ORDER_MESSAGES", r =>
	{
	var orderNumber = Query.GetLong(r, 0);
var sequentialNumber = Query.GetLong(r, 1);
var text = Query.GetString(r, 2);

return new AtpOrderMessage(orderNumber, sequentialNumber, text);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<BeaconLog> GetBeaconLogs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<BeaconLog>();
	
	var query = new Query<BeaconLog>(@"SELECT GUID, STARTED_AT, FINISHED_AT, EQUIPMENT_NUMBER, EDDYSTONE_INSTANCE, OUTLET_NUMBER, USER_ID, OPERATION_TYPE, NUMBER_OF_EVENTS, NUMBER_OF_IMAGES, STATUS, ERROR_TEXT, SIZE_IN_BYTES, SESSION_ID, SESSION_SEQUENCE FROM BEACON_LOGS", r =>
	{
	var guid = Query.GetString(r, 0);
var startedAt = Query.GetDateTime(r, 1);
var finishedAt = Query.GetDateTime(r, 2);
var equipmentNumber = Query.GetString(r, 3);
var eddystoneInstance = Query.GetString(r, 4);
var outletNumber = Query.GetLong(r, 5);
var userId = Query.GetLong(r, 6);
var operationType = Query.GetString(r, 7);
var numberOfEvents = Query.GetLong(r, 8);
var numberOfImages = Query.GetLong(r, 9);
var status = Query.GetString(r, 10);
var errorText = Query.GetString(r, 11);
var sizeInBytes = Query.GetLong(r, 12);
var sessionId = Query.GetString(r, 13);
var sessionSequence = Query.GetDecimal(r, 14);

return new BeaconLog(guid, startedAt, finishedAt, equipmentNumber, eddystoneInstance, outletNumber, userId, operationType, numberOfEvents, numberOfImages, status, errorText, sizeInBytes, sessionId, sessionSequence);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<BusinessType> GetBusinessTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<BusinessType>();
	
	var query = new Query<BusinessType>(@"SELECT CODE, KDGRP, DESCRIPTION FROM BUSINESS_TYPES", r =>
	{
	var code = Query.GetLong(r, 0);
var kdgrp = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new BusinessType(code, kdgrp, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CallingAssignment> GetCallingAssignments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CallingAssignment>();
	
	var query = new Query<CallingAssignment>(@"SELECT ACTUAL_FROM_DATE, ACTUAL_TO_DATE, ID, OUTLET_NUMBER, USER_ID, USER_ROUTE_ID FROM CALLING_ASSIGNMENTS", r =>
	{
	var actualFromDate = Query.GetDateTime(r, 0);
var actualToDate = Query.GetDateTime(r, 1);
var id = Query.GetLong(r, 2);
var outletNumber = Query.GetLong(r, 3);
var userId = Query.GetLong(r, 4);
var userRouteId = Query.GetLong(r, 5);

return new CallingAssignment(actualFromDate, actualToDate, id, outletNumber, userId, userRouteId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CallingRoute> GetCallingRoutes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CallingRoute>();
	
	var query = new Query<CallingRoute>(@"SELECT CLIENT, CODE, DESCRIPTION, LANGU, TERRITORY FROM CALLING_ROUTES", r =>
	{
	var client = Query.GetString(r, 0);
var code = Query.GetLong(r, 1);
var description = Query.GetString(r, 2);
var langu = Query.GetString(r, 3);
var territory = Query.GetString(r, 4);

return new CallingRoute(client, code, description, langu, territory);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CcafChannel> GetCcafChannels(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CcafChannel>();
	
	var query = new Query<CcafChannel>(@"SELECT CODE, LOCAL_NAME, NAME FROM CCAF_CHANNELS", r =>
	{
	var code = Query.GetString(r, 0);
var localName = Query.GetString(r, 1);
var name = Query.GetString(r, 2);

return new CcafChannel(code, localName, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CcafSegment> GetCcafSegments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CcafSegment>();
	
	var query = new Query<CcafSegment>(@"SELECT CODE, NAME, LOCAL_NAME FROM CCAF_SEGMENTS", r =>
	{
	var code = Query.GetInt(r, 0);
var name = Query.GetString(r, 1);
var localName = Query.GetString(r, 2);

return new CcafSegment(code, name, localName);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CcOrder> GetCcOrders(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CcOrder>();
	
	var query = new Query<CcOrder>(@"SELECT DELIVERY_DATE, ID, OUTLET_NUMBER, POSTING_DATE, PROCESS_TYPE, SAP_ID, SAP_SOURCE, STATUS_TEXT, STATUS_TYPE, TYPE_CODE FROM CC_ORDERS", r =>
	{
	var deliveryDate = Query.GetDateTime(r, 0);
var id = Query.GetLong(r, 1);
var outletNumber = Query.GetLong(r, 2);
var postingDate = Query.GetDateTime(r, 3);
var processType = Query.GetString(r, 4);
var sapId = Query.GetString(r, 5);
var sapSource = Query.GetString(r, 6);
var statusText = Query.GetString(r, 7);
var statusType = Query.GetInt(r, 8);
var typeCode = Query.GetLong(r, 9);

return new CcOrder(deliveryDate, id, outletNumber, postingDate, processType, sapId, sapSource, statusText, statusType, typeCode);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CcOrderDetail> GetCcOrderDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CcOrderDetail>();
	
	var query = new Query<CcOrderDetail>(@"SELECT ARTICLE_NUMBER, CC_ORDER_ID, CONFIRMED_QUANTITY, CURRENCY, ITEM_CATEGORY, NET_VALUE, QUANTITY FROM CC_ORDER_DETAILS", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var ccOrderId = Query.GetLong(r, 1);
var confirmedQuantity = Query.GetDecimal(r, 2);
var currency = Query.GetString(r, 3);
var itemCategory = Query.GetString(r, 4);
var netValue = Query.GetDecimal(r, 5);
var quantity = Query.GetDecimal(r, 6);

return new CcOrderDetail(articleNumber, ccOrderId, confirmedQuantity, currency, itemCategory, netValue, quantity);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ChannelAssortment> GetChannelAssortments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ChannelAssortment>();
	
	var query = new Query<ChannelAssortment>(@"SELECT ARTICLE_NUMBER, CUSTOMER_GROUP, ID, IS_LOCKED, OUTLET_NUMBER, PRICE_GROUP, SALES_ORG_ASSORTMENT_ID, SCREEN_POSITION FROM CHANNEL_ASSORTMENTS", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var customerGroup = Query.GetString(r, 1);
var id = Query.GetLong(r, 2);
var isLocked = Query.GetInt(r, 3);
var outletNumber = Query.GetLong(r, 4);
var priceGroup = Query.GetString(r, 5);
var salesOrgAssortmentId = Query.GetString(r, 6);
var screenPosition = Query.GetLong(r, 7);

return new ChannelAssortment(articleNumber, customerGroup, id, isLocked, outletNumber, priceGroup, salesOrgAssortmentId, screenPosition);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ClientSequence> GetClientSequences(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ClientSequence>();
	
	var query = new Query<ClientSequence>(@"SELECT MAX_VALUE, MIN_VALUE, NEXT_VALUE, PC_ID, SEQUENCE_ID FROM CLIENT_SEQUENCES", r =>
	{
	var maxValue = Query.GetLong(r, 0);
var minValue = Query.GetLong(r, 1);
var nextValue = Query.GetLong(r, 2);
var pcId = Query.GetDecimal(r, 3);
var sequenceId = Query.GetLong(r, 4);

return new ClientSequence(maxValue, minValue, nextValue, pcId, sequenceId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ClientVersion> GetClientVersions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ClientVersion>();
	
	var query = new Query<ClientVersion>(@"SELECT MODULE_NAME, PC_ID, VERSION_STRING FROM CLIENT_VERSIONS", r =>
	{
	var moduleName = Query.GetString(r, 0);
var pcId = Query.GetLong(r, 1);
var versionString = Query.GetString(r, 2);

return new ClientVersion(moduleName, pcId, versionString);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ComplaintDetail> GetComplaintDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ComplaintDetail>();
	
	var query = new Query<ComplaintDetail>(@"SELECT ACTIVITY_ID, ARTICLE_NUMBER, QUANTITY, QUANTITY_SU FROM COMPLAINT_DETAILS", r =>
	{
	var activityId = Query.GetLong(r, 0);
var articleNumber = Query.GetLong(r, 1);
var quantity = Query.GetDecimal(r, 2);
var quantitySu = Query.GetLong(r, 3);

return new ComplaintDetail(activityId, articleNumber, quantity, quantitySu);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ContactPerson> GetContactPersons(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ContactPerson>();
	
	var query = new Query<ContactPerson>(@"SELECT FIRSTNAME, FUNCTION, ID, ISMANAGER, LASTNAME, ORIGIN, OUTLET_NUMBER, STATUS FROM CONTACT_PERSONS", r =>
	{
	var firstname = Query.GetString(r, 0);
var function = Query.GetString(r, 1);
var id = Query.GetLong(r, 2);
var ismanager = Query.GetInt(r, 3);
var lastname = Query.GetString(r, 4);
var origin = Query.GetString(r, 5);
var outletNumber = Query.GetLong(r, 6);
var status = Query.GetString(r, 7);

return new ContactPerson(firstname, function, id, ismanager, lastname, origin, outletNumber, status);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ContractTemplate> GetContractTemplates(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ContractTemplate>();
	
	var query = new Query<ContractTemplate>(@"SELECT ACTIVITY_TYPE_ID, EULA, LAST_MODIFIED, SIGN_BY_BD, SIGN_BY_CUSTOMER FROM CONTRACT_TEMPLATES", r =>
	{
	var activityTypeId = Query.GetInt(r, 0);
var eula = Query.GetString(r, 1);
var lastModified = Query.GetDateTime(r, 2);
var signByBd = Query.GetInt(r, 3);
var signByCustomer = Query.GetInt(r, 4);

return new ContractTemplate(activityTypeId, eula, lastModified, signByBd, signByCustomer);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CusPlanningToolCust> GetCusPlanningToolCusts(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CusPlanningToolCust>();
	
	var query = new Query<CusPlanningToolCust>(@"SELECT CFSMINDC, DELTA, DESCRIPTION, IS_SUPPRESSED, PROCESS_TYPE, REASON_CODE, REASON_CODE2, REASON_CODEGRP, SORT_INDICATOR FROM CUS_PLANNING_TOOL_CUST", r =>
	{
	var cfsmindc = Query.GetString(r, 0);
var delta = Query.GetDecimal(r, 1);
var description = Query.GetString(r, 2);
var isSuppressed = Query.GetInt(r, 3);
var processType = Query.GetString(r, 4);
var reasonCode = Query.GetString(r, 5);
var reasonCode2 = Query.GetString(r, 6);
var reasonCodegrp = Query.GetString(r, 7);
var sortIndicator = Query.GetInt(r, 8);

return new CusPlanningToolCust(cfsmindc, delta, description, isSuppressed, processType, reasonCode, reasonCode2, reasonCodegrp, sortIndicator);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CusPopAssortment> GetCusPopAssortments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CusPopAssortment>();
	
	var query = new Query<CusPopAssortment>(@"SELECT SALES_ORG_ASSORTMENT_ID FROM CUS_POP_ASSORTMENTS", r =>
	{
	var salesOrgAssortmentId = Query.GetString(r, 0);

return new CusPopAssortment(salesOrgAssortmentId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CusSurvey> GetCusSurveys(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CusSurvey>();
	
	var query = new Query<CusSurvey>(@"SELECT ANSWER_SUMMARY, ANSWER_TOTAL, COPY_LAST_VALUES, IDEAL_OUTLET, MUST, PERCENTAGE, QUESTION_SUMMARY, QUESTION_TOTAL, SCORING, SURVEY_ID, TRANSACTION_TYPE, VALID_FROM, VALID_TO FROM CUS_SURVEYS", r =>
	{
	var answerSummary = Query.GetString(r, 0);
var answerTotal = Query.GetString(r, 1);
var copyLastValues = Query.GetString(r, 2);
var idealOutlet = Query.GetString(r, 3);
var must = Query.GetString(r, 4);
var percentage = Query.GetString(r, 5);
var questionSummary = Query.GetString(r, 6);
var questionTotal = Query.GetString(r, 7);
var scoring = Query.GetString(r, 8);
var surveyId = Query.GetLong(r, 9);
var transactionType = Query.GetString(r, 10);
var validFrom = Query.GetDateTime(r, 11);
var validTo = Query.GetDateTime(r, 12);

return new CusSurvey(answerSummary, answerTotal, copyLastValues, idealOutlet, must, percentage, questionSummary, questionTotal, scoring, surveyId, transactionType, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<CusSurveysHierNode> GetCusSurveysHierNodes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<CusSurveysHierNode>();
	
	var query = new Query<CusSurveysHierNode>(@"SELECT NODE_GUID, SURVEY_ID FROM CUS_SURVEYS_HIER_NODES", r =>
	{
	var nodeGuid = Query.GetString(r, 0);
var surveyId = Query.GetLong(r, 1);

return new CusSurveysHierNode(nodeGuid, surveyId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<DeliveryHistDetail> GetDeliveryHistDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<DeliveryHistDetail>();
	
	var query = new Query<DeliveryHistDetail>(@"SELECT ARTICLE_NUMBER, DELIVERY1, DELIVERY2, DELIVERY3, DELIVERY4, DELIVERY5, DELIVERY6, OUTLET_NUMBER FROM DELIVERY_HIST_DETAILS", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var delivery1 = Query.GetLong(r, 1);
var delivery2 = Query.GetLong(r, 2);
var delivery3 = Query.GetLong(r, 3);
var delivery4 = Query.GetLong(r, 4);
var delivery5 = Query.GetLong(r, 5);
var delivery6 = Query.GetLong(r, 6);
var outletNumber = Query.GetLong(r, 7);

return new DeliveryHistDetail(articleNumber, delivery1, delivery2, delivery3, delivery4, delivery5, delivery6, outletNumber);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<DeliveryHistHeader> GetDeliveryHistHeaders(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<DeliveryHistHeader>();
	
	var query = new Query<DeliveryHistHeader>(@"SELECT DELIVERY_DATE1, DELIVERY_DATE2, DELIVERY_DATE3, DELIVERY_DATE4, DELIVERY_DATE5, DELIVERY_DATE6, OUTLET_NUMBER FROM DELIVERY_HIST_HEADERS", r =>
	{
	var deliveryDate1 = Query.GetDateTime(r, 0);
var deliveryDate2 = Query.GetDateTime(r, 1);
var deliveryDate3 = Query.GetDateTime(r, 2);
var deliveryDate4 = Query.GetDateTime(r, 3);
var deliveryDate5 = Query.GetDateTime(r, 4);
var deliveryDate6 = Query.GetDateTime(r, 5);
var outletNumber = Query.GetLong(r, 6);

return new DeliveryHistHeader(deliveryDate1, deliveryDate2, deliveryDate3, deliveryDate4, deliveryDate5, deliveryDate6, outletNumber);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<DeliveryLeadTime> GetDeliveryLeadTimes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<DeliveryLeadTime>();
	
	var query = new Query<DeliveryLeadTime>(@"SELECT CODE, ATTRIB_5, DESCRIPTION FROM DELIVERY_LEAD_TIMES", r =>
	{
	var code = Query.GetLong(r, 0);
var attrib5 = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new DeliveryLeadTime(code, attrib5, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<DeliveryLocation> GetDeliveryLocations(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<DeliveryLocation>();
	
	var query = new Query<DeliveryLocation>(@"SELECT CODE, WERKS, DESCRIPTION, IS_SUPPRESSED, NAME1, NAME2, ADDRESS FROM DELIVERY_LOCATIONS", r =>
	{
	var code = Query.GetLong(r, 0);
var werks = Query.GetString(r, 1);
var description = Query.GetString(r, 2);
var isSuppressed = Query.GetInt(r, 3);
var name1 = Query.GetString(r, 4);
var name2 = Query.GetString(r, 5);
var address = Query.GetString(r, 6);

return new DeliveryLocation(code, werks, description, isSuppressed, name1, name2, address);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<DeliveryTransaction> GetDeliveryTransactions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<DeliveryTransaction>();
	
	var query = new Query<DeliveryTransaction>(@"SELECT BASIS_CODE, BASIS_LOCATION, BASIS_SUBKEY, CODE, DESCRIPTION, IS_SUPPRESSED, ORIGIN, SEQUENCE FROM DELIVERY_TRANSACTIONS", r =>
	{
	var basisCode = Query.GetString(r, 0);
var basisLocation = Query.GetString(r, 1);
var basisSubkey = Query.GetString(r, 2);
var code = Query.GetLong(r, 3);
var description = Query.GetString(r, 4);
var isSuppressed = Query.GetInt(r, 5);
var origin = Query.GetString(r, 6);
var sequence = Query.GetInt(r, 7);

return new DeliveryTransaction(basisCode, basisLocation, basisSubkey, code, description, isSuppressed, origin, sequence);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<DeliveryType> GetDeliveryTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<DeliveryType>();
	
	var query = new Query<DeliveryType>(@"SELECT CODE, ATTRIB_4, DESCRIPTION FROM DELIVERY_TYPES", r =>
	{
	var code = Query.GetLong(r, 0);
var attrib4 = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new DeliveryType(code, attrib4, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Equipment> GetEquipments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Equipment>();
	
	var query = new Query<Equipment>(@"SELECT EQUIPMENT_NUMBER, EQUIPMENT_TYPE_CODE, IS_SUPPRESSED, OUTLET_NUMBER, RENT_CONTRACT_NUMBER, SERIAL_NUMBER, ASSET_CLASS, IBEACON_MAJOR, IBEACON_MINOR, QUOTE(IBEACON_UUID), EDDYSTONE_NAMESPACE, EDDYSTONE_INSTANCE, DOOR_OPENS_COUNT, DOWNLOAD_DATE, RED_COOLER_QUALITY, BRANDING, AV_TRAFF_DOOR, MONTHLY_AV_TEMP, MONTHLY_AV_ACTIVE_TEMP, AV_TRAF_LIGHT_TEMP, TRAF_LIGHT_DOWNLOAD_DATE, SMART_TYPE, BEACON_MAC_ADDRESS, BEACON_PASSWORD FROM EQUIPMENT", r =>
	{
	var equipmentNumber = Query.GetString(r, 0);
var equipmentTypeCode = Query.GetLong(r, 1);
var isSuppressed = Query.GetInt(r, 2);
var outletNumber = Query.GetLong(r, 3);
var rentContractNumber = Query.GetString(r, 4);
var serialNumber = Query.GetString(r, 5);
var assetClass = Query.GetString(r, 6);
var ibeaconMajor = Query.GetInt(r, 7);
var ibeaconMinor = Query.GetInt(r, 8);
var ibeaconUuid = Query.GetGuid(r, 9);
var eddystoneNamespace = Query.GetString(r, 10);
var eddystoneInstance = Query.GetString(r, 11);
var doorOpensCount = Query.GetDecimal(r, 12);
var downloadDate = Query.GetDateTime(r, 13);
var redCoolerQuality = Query.GetDecimal(r, 14);
var branding = Query.GetString(r, 15);
var avTraffDoor = Query.GetString(r, 16);
var monthlyAvTemp = Query.GetDecimal(r, 17);
var monthlyAvActiveTemp = Query.GetDecimal(r, 18);
var avTrafLightTemp = Query.GetString(r, 19);
var trafLightDownloadDate = Query.GetDateTime(r, 20);
var smartType = Query.GetString(r, 21);
var beaconMacAddress = Query.GetString(r, 22);
var beaconPassword = Query.GetString(r, 23);

return new Equipment(equipmentNumber, equipmentTypeCode, isSuppressed, outletNumber, rentContractNumber, serialNumber, assetClass, ibeaconMajor, ibeaconMinor, ibeaconUuid, eddystoneNamespace, eddystoneInstance, doorOpensCount, downloadDate, redCoolerQuality, branding, avTraffDoor, monthlyAvTemp, monthlyAvActiveTemp, avTrafLightTemp, trafLightDownloadDate, smartType, beaconMacAddress, beaconPassword);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<EquipmentActivity> GetEquipmentActivitys(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<EquipmentActivity>();
	
	var query = new Query<EquipmentActivity>(@"SELECT ACTIVITY_ID, EQUIPMENT_MODEL_CODE, EQUIPMENT_TYPE_CODE, EQUIPMENT_NUMBER, NEW_OUTLET_NUMBER, STATUS_LIST_ID FROM EQUIPMENT_ACTIVITY", r =>
	{
	var activityId = Query.GetLong(r, 0);
var equipmentModelCode = Query.GetLong(r, 1);
var equipmentTypeCode = Query.GetLong(r, 2);
var equipmentNumber = Query.GetString(r, 3);
var newOutletNumber = Query.GetLong(r, 4);
var statusListId = Query.GetLong(r, 5);

return new EquipmentActivity(activityId, equipmentModelCode, equipmentTypeCode, equipmentNumber, newOutletNumber, statusListId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<EquipmentCheck> GetEquipmentChecks(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<EquipmentCheck>();
	
	var query = new Query<EquipmentCheck>(@"SELECT ACTIVITY_ID, ADMIN_COMMENTS, AVAILABLE, BARCODE_CUTTING, CDE_STATUS_ID, COMMENTS, EQUIPMENT_LOAD, EQUIPMENT_NUMBER, EQ_TAG_STATUS_ID, LAST_CHECKED, LAST_SCANNED, LOCATION_STATUS_ID, MODEL, OUTLET_NUMBER, PERCENT_STATUS_ID, SERIAL_NUMBER, SOURCE, STATUS, TB_RESOLVED, VISIT_ID, LAST_CHECKED_BY_USER_ID, IBEACON_MAJOR, IBEACON_MINOR, QUOTE(IBEACON_UUID), EDDYSTONE_NAMESPACE, EDDYSTONE_INSTANCE, DOOR_OPENS_COUNT, DOWNLOAD_DATE, RED_COOLER_QUALITY, BRANDING, AV_TRAFF_DOOR, MONTHLY_AV_TEMP, MONTHLY_AV_ACTIVE_TEMP, AV_TRAF_LIGHT_TEMP, TRAF_LIGHT_DOWNLOAD_DATE, SMART_TYPE, BEACON_MAC_ADDRESS, BEACON_PASSWORD FROM EQUIPMENT_CHECK", r =>
	{
	var activityId = Query.GetLong(r, 0);
var adminComments = Query.GetString(r, 1);
var available = Query.GetInt(r, 2);
var barcodeCutting = Query.GetString(r, 3);
var cdeStatusId = Query.GetLong(r, 4);
var comments = Query.GetString(r, 5);
var equipmentLoad = Query.GetInt(r, 6);
var equipmentNumber = Query.GetString(r, 7);
var eqTagStatusId = Query.GetLong(r, 8);
var lastChecked = Query.GetDateTime(r, 9);
var lastScanned = Query.GetDateTime(r, 10);
var locationStatusId = Query.GetLong(r, 11);
var model = Query.GetString(r, 12);
var outletNumber = Query.GetLong(r, 13);
var percentStatusId = Query.GetLong(r, 14);
var serialNumber = Query.GetString(r, 15);
var source = Query.GetString(r, 16);
var status = Query.GetString(r, 17);
var tbResolved = Query.GetString(r, 18);
var visitId = Query.GetLong(r, 19);
var lastCheckedByUserId = Query.GetLong(r, 20);
var ibeaconMajor = Query.GetInt(r, 21);
var ibeaconMinor = Query.GetInt(r, 22);
var ibeaconUuid = Query.GetGuid(r, 23);
var eddystoneNamespace = Query.GetString(r, 24);
var eddystoneInstance = Query.GetString(r, 25);
var doorOpensCount = Query.GetDecimal(r, 26);
var downloadDate = Query.GetDateTime(r, 27);
var redCoolerQuality = Query.GetDecimal(r, 28);
var branding = Query.GetString(r, 29);
var avTraffDoor = Query.GetString(r, 30);
var monthlyAvTemp = Query.GetDecimal(r, 31);
var monthlyAvActiveTemp = Query.GetDecimal(r, 32);
var avTrafLightTemp = Query.GetString(r, 33);
var trafLightDownloadDate = Query.GetDateTime(r, 34);
var smartType = Query.GetString(r, 35);
var beaconMacAddress = Query.GetString(r, 36);
var beaconPassword = Query.GetString(r, 37);

return new EquipmentCheck(activityId, adminComments, available, barcodeCutting, cdeStatusId, comments, equipmentLoad, equipmentNumber, eqTagStatusId, lastChecked, lastScanned, locationStatusId, model, outletNumber, percentStatusId, serialNumber, source, status, tbResolved, visitId, lastCheckedByUserId, ibeaconMajor, ibeaconMinor, ibeaconUuid, eddystoneNamespace, eddystoneInstance, doorOpensCount, downloadDate, redCoolerQuality, branding, avTraffDoor, monthlyAvTemp, monthlyAvActiveTemp, avTrafLightTemp, trafLightDownloadDate, smartType, beaconMacAddress, beaconPassword);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<EquipmentMatrix> GetEquipmentMatrixs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<EquipmentMatrix>();
	
	var query = new Query<EquipmentMatrix>(@"SELECT CCAF_CHANNEL_CODE, CCAF_SEGMENT_CODE, HIERARCHY_LEVEL, ID, OUTLET_CLUSTER_ATTRIBUTE_CODE, OUTLET_CLUSTER_HIERARCHY_NODE, RED_PICTURE_OF_SUCCESS_FORMAT, TRADE_CHANNEL_CODE FROM EQUIPMENT_MATRIX", r =>
	{
	var ccafChannelCode = Query.GetString(r, 0);
var ccafSegmentCode = Query.GetInt(r, 1);
var hierarchyLevel = Query.GetString(r, 2);
var id = Query.GetLong(r, 3);
var outletClusterAttributeCode = Query.GetDecimal(r, 4);
var outletClusterHierarchyNode = Query.GetDecimal(r, 5);
var redPictureOfSuccessFormat = Query.GetString(r, 6);
var tradeChannelCode = Query.GetLong(r, 7);

return new EquipmentMatrix(ccafChannelCode, ccafSegmentCode, hierarchyLevel, id, outletClusterAttributeCode, outletClusterHierarchyNode, redPictureOfSuccessFormat, tradeChannelCode);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<EquipmentMatrixType> GetEquipmentMatrixTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<EquipmentMatrixType>();
	
	var query = new Query<EquipmentMatrixType>(@"SELECT EQUIPMENT_MATRIX_ID, EQUIPMENT_TYPE_CODE FROM EQUIPMENT_MATRIX_TYPES", r =>
	{
	var equipmentMatrixId = Query.GetLong(r, 0);
var equipmentTypeCode = Query.GetLong(r, 1);

return new EquipmentMatrixType(equipmentMatrixId, equipmentTypeCode);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<EquipmentMessage> GetEquipmentMessages(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<EquipmentMessage>();
	
	var query = new Query<EquipmentMessage>(@"SELECT ID, MESSAGE, ORIGIN, STATUS FROM EQUIPMENT_MESSAGES", r =>
	{
	var id = Query.GetLong(r, 0);
var message = Query.GetString(r, 1);
var origin = Query.GetString(r, 2);
var status = Query.GetString(r, 3);

return new EquipmentMessage(id, message, origin, status);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<EquipmentType> GetEquipmentTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<EquipmentType>();
	
	var query = new Query<EquipmentType>(@"SELECT CODE, DESCRIPTION, IS_SUPPRESSED, NOTE, BRANDING, NUMBER_OF_DOORS, WIDTH, HEIGHT, DEPTH, POWER, SAP_CODE FROM EQUIPMENT_TYPES", r =>
	{
	var code = Query.GetLong(r, 0);
var description = Query.GetString(r, 1);
var isSuppressed = Query.GetInt(r, 2);
var note = Query.GetString(r, 3);
var branding = Query.GetString(r, 4);
var numberOfDoors = Query.GetLong(r, 5);
var width = Query.GetLong(r, 6);
var height = Query.GetLong(r, 7);
var depth = Query.GetLong(r, 8);
var power = Query.GetDecimal(r, 9);
var sapCode = Query.GetString(r, 10);

return new EquipmentType(code, description, isSuppressed, note, branding, numberOfDoors, width, height, depth, power, sapCode);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<EquipmentTypeImage> GetEquipmentTypeImages(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<EquipmentTypeImage>();
	
	var query = new Query<EquipmentTypeImage>(@"SELECT EQUIPMENT_TYPE_CODE, ID, IMAGE FROM EQUIPMENT_TYPE_IMAGES", r =>
	{
	var equipmentTypeCode = Query.GetLong(r, 0);
var id = Query.GetLong(r, 1);
var image = Query.GetByteArray(r, 2);

return new EquipmentTypeImage(equipmentTypeCode, id, image);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<GpsData> GetGpsDatas(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<GpsData>();
	
	var query = new Query<GpsData>(@"SELECT ACTIVITY_ID, DEVICE_ID, ID, LATITUDE, LONGITUDE, RIL_CELL_ID, RIL_LOCATION_AREA_CODE, RIL_MOBILE_COUNTRY_CODE, RIL_MOBILE_NETWORK_CODE, TIME_STAMP, USER_ID FROM GPS_DATA", r =>
	{
	var activityId = Query.GetLong(r, 0);
var deviceId = Query.GetDecimal(r, 1);
var id = Query.GetLong(r, 2);
var latitude = Query.GetDecimal(r, 3);
var longitude = Query.GetDecimal(r, 4);
var rilCellId = Query.GetLong(r, 5);
var rilLocationAreaCode = Query.GetLong(r, 6);
var rilMobileCountryCode = Query.GetLong(r, 7);
var rilMobileNetworkCode = Query.GetLong(r, 8);
var timeStamp = Query.GetDateTime(r, 9);
var userId = Query.GetLong(r, 10);

return new GpsData(activityId, deviceId, id, latitude, longitude, rilCellId, rilLocationAreaCode, rilMobileCountryCode, rilMobileNetworkCode, timeStamp, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Holiday> GetHolidays(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Holiday>();
	
	var query = new Query<Holiday>(@"SELECT CALENDAR_DATE, SELECTOR_KEY FROM HOLIDAYS", r =>
	{
	var calendarDate = Query.GetDateTime(r, 0);
var selectorKey = Query.GetString(r, 1);

return new Holiday(calendarDate, selectorKey);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<InventoryDetail> GetInventoryDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<InventoryDetail>();
	
	var query = new Query<InventoryDetail>(@"SELECT ARTICLE_NUMBER, INVENTORY_HEADER_ID, STOCK_BACK, STOCK_BACK_SU, STOCK_EQUIPMENT, STOCK_EQUIPMENT_SU, STOCK_SHELF, STOCK_SHELF_SU, STOCK_TOTAL, STOCK_TOTAL_SU FROM INVENTORY_DETAILS", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var inventoryHeaderId = Query.GetLong(r, 1);
var stockBack = Query.GetInt(r, 2);
var stockBackSu = Query.GetInt(r, 3);
var stockEquipment = Query.GetInt(r, 4);
var stockEquipmentSu = Query.GetInt(r, 5);
var stockShelf = Query.GetInt(r, 6);
var stockShelfSu = Query.GetInt(r, 7);
var stockTotal = Query.GetInt(r, 8);
var stockTotalSu = Query.GetInt(r, 9);

return new InventoryDetail(articleNumber, inventoryHeaderId, stockBack, stockBackSu, stockEquipment, stockEquipmentSu, stockShelf, stockShelfSu, stockTotal, stockTotalSu);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<InventoryHeader> GetInventoryHeaders(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<InventoryHeader>();
	
	var query = new Query<InventoryHeader>(@"SELECT ACTIVITY_ID, CREATED_AT, ID, LAST_SAVED_AT, VISIT_ID FROM INVENTORY_HEADERS", r =>
	{
	var activityId = Query.GetLong(r, 0);
var createdAt = Query.GetDateTime(r, 1);
var id = Query.GetLong(r, 2);
var lastSavedAt = Query.GetDateTime(r, 3);
var visitId = Query.GetLong(r, 4);

return new InventoryHeader(activityId, createdAt, id, lastSavedAt, visitId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<LinkedWholesaler> GetLinkedWholesalers(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<LinkedWholesaler>();
	
	var query = new Query<LinkedWholesaler>(@"SELECT GRID_NUMBER, IS_DEFAULT, OUTLET_NUMBER, VALID_FROM, VALID_TO, WHOLESALER_ID FROM LINKED_WHOLESALERS", r =>
	{
	var gridNumber = Query.GetString(r, 0);
var isDefault = Query.GetInt(r, 1);
var outletNumber = Query.GetLong(r, 2);
var validFrom = Query.GetDateTime(r, 3);
var validTo = Query.GetDateTime(r, 4);
var wholesalerId = Query.GetLong(r, 5);

return new LinkedWholesaler(gridNumber, isDefault, outletNumber, validFrom, validTo, wholesalerId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<MaterialCategorie> GetMaterialCategories(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<MaterialCategorie>();
	
	var query = new Query<MaterialCategorie>(@"SELECT CODE, PRODH, DESCRIPTION FROM MATERIAL_CATEGORIES", r =>
	{
	var code = Query.GetLong(r, 0);
var prodh = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new MaterialCategorie(code, prodh, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<MeasureDomain> GetMeasureDomains(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<MeasureDomain>();
	
	var query = new Query<MeasureDomain>(@"SELECT ID, IS_SUPPRESSED, VALUE_TYPE FROM MEASURE_DOMAINS", r =>
	{
	var id = Query.GetLong(r, 0);
var isSuppressed = Query.GetInt(r, 1);
var valueType = Query.GetLong(r, 2);

return new MeasureDomain(id, isSuppressed, valueType);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<MeasureDomainLov> GetMeasureDomainLovs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<MeasureDomainLov>();
	
	var query = new Query<MeasureDomainLov>(@"SELECT DESCRIPTION, DOMAIN_ID, NO, WEIGTH, NOT_APPLICABLE, VALUE FROM MEASURE_DOMAIN_LOVS", r =>
	{
	var description = Query.GetString(r, 0);
var domainId = Query.GetLong(r, 1);
var no = Query.GetLong(r, 2);
var weigth = Query.GetLong(r, 3);
var notApplicable = Query.GetInt(r, 4);
var value = Query.GetString(r, 5);

return new MeasureDomainLov(description, domainId, no, weigth, notApplicable, value);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<MeasureNode> GetMeasureNodes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<MeasureNode>();
	
	var query = new Query<MeasureNode>(@"SELECT ID, SURVEY_ID, IS_REQUIRED, FIRST_DOMAIN_ID, OWNER_ID, DESCRIPTION, DEFAULT_VALUE, CAN_EDIT, SUPPRESSED, SEQUENCE, TREE_LEVEL, SCORE, LONG_DESCRIPTION, MAXVAL, MINVAL, MARKET_ATTRIBUTE, TARGET_SCORE, TYPE, RELATED_NODE, VALID_FROM, VALID_TO, WEIGHT, GUID, PFP_REL FROM MEASURE_NODES", r =>
	{
	var id = Query.GetLong(r, 0);
var surveyId = Query.GetLong(r, 1);
var isRequired = Query.GetInt(r, 2);
var firstDomainId = Query.GetLong(r, 3);
var ownerId = Query.GetLong(r, 4);
var description = Query.GetString(r, 5);
var defaultValue = Query.GetString(r, 6);
var canEdit = Query.GetInt(r, 7);
var suppressed = Query.GetInt(r, 8);
var sequence = Query.GetLong(r, 9);
var treeLevel = Query.GetLong(r, 10);
var score = Query.GetDecimal(r, 11);
var longDescription = Query.GetString(r, 12);
var maxval = Query.GetDecimal(r, 13);
var minval = Query.GetDecimal(r, 14);
var marketAttribute = Query.GetString(r, 15);
var targetScore = Query.GetDecimal(r, 16);
var type = Query.GetString(r, 17);
var relatedNode = Query.GetLong(r, 18);
var validFrom = Query.GetDateTime(r, 19);
var validTo = Query.GetDateTime(r, 20);
var weight = Query.GetDecimal(r, 21);
var guid = Query.GetString(r, 22);
var pfpRel = Query.GetString(r, 23);

return new MeasureNode(id, surveyId, isRequired, firstDomainId, ownerId, description, defaultValue, canEdit, suppressed, sequence, treeLevel, score, longDescription, maxval, minval, marketAttribute, targetScore, type, relatedNode, validFrom, validTo, weight, guid, pfpRel);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<MeasureValue> GetMeasureValues(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<MeasureValue>();
	
	var query = new Query<MeasureValue>(@"SELECT ACTIVITY_ID, NODE_ID, SURVEY_ID, VALUE, VISIT_ID FROM MEASURE_VALUES", r =>
	{
	var activityId = Query.GetLong(r, 0);
var nodeId = Query.GetLong(r, 1);
var surveyId = Query.GetLong(r, 2);
var value = Query.GetString(r, 3);
var visitId = Query.GetLong(r, 4);

return new MeasureValue(activityId, nodeId, surveyId, value, visitId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OrderDateOutletCpl> GetOrderDateOutletCpls(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OrderDateOutletCpl>();
	
	var query = new Query<OrderDateOutletCpl>(@"SELECT CPL FROM ORDER_DATE_OUTLET_CPLS", r =>
	{
	var cpl = Query.GetString(r, 0);

return new OrderDateOutletCpl(cpl);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OrderDetail> GetOrderDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OrderDetail>();
	
	var query = new Query<OrderDetail>(@"SELECT ADJUSTMENT_NUMBER, ADJUSTMENT_QUANTITY, ADJUSTMENT_QUANTITY_SU, ADJUSTMENT_TYPE, ARTICLE_NUMBER, ORDER_HEADER_ID, PREVIOUS_CONSUMPTION, PREVIOUS_CONSUMPTION_SU, QUANTITY, QUANTITY_SU, SUGGESTED_QUANTITY, SUGGESTED_QUANTITY_SU FROM ORDER_DETAILS", r =>
	{
	var adjustmentNumber = Query.GetLong(r, 0);
var adjustmentQuantity = Query.GetDecimal(r, 1);
var adjustmentQuantitySu = Query.GetLong(r, 2);
var adjustmentType = Query.GetString(r, 3);
var articleNumber = Query.GetLong(r, 4);
var orderHeaderId = Query.GetLong(r, 5);
var previousConsumption = Query.GetDecimal(r, 6);
var previousConsumptionSu = Query.GetLong(r, 7);
var quantity = Query.GetDecimal(r, 8);
var quantitySu = Query.GetLong(r, 9);
var suggestedQuantity = Query.GetDecimal(r, 10);
var suggestedQuantitySu = Query.GetDecimal(r, 11);

return new OrderDetail(adjustmentNumber, adjustmentQuantity, adjustmentQuantitySu, adjustmentType, articleNumber, orderHeaderId, previousConsumption, previousConsumptionSu, quantity, quantitySu, suggestedQuantity, suggestedQuantitySu);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OrderDetailPromotion> GetOrderDetailPromotions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OrderDetailPromotion>();
	
	var query = new Query<OrderDetailPromotion>(@"SELECT ORDERED_ARTICLE_NUMBER, ORDER_NUMBER, PROMOTED_ARTICLE_NUMBER, PROMOTED_FREE_FLAG, PROMOTED_QUANTITY, PROMOTED_QUANTITY_SU, PROMOTION_GUID FROM ORDER_DETAIL_PROMOTIONS", r =>
	{
	var orderedArticleNumber = Query.GetLong(r, 0);
var orderNumber = Query.GetLong(r, 1);
var promotedArticleNumber = Query.GetLong(r, 2);
var promotedFreeFlag = Query.GetString(r, 3);
var promotedQuantity = Query.GetDecimal(r, 4);
var promotedQuantitySu = Query.GetDecimal(r, 5);
var promotionGuid = Query.GetString(r, 6);

return new OrderDetailPromotion(orderedArticleNumber, orderNumber, promotedArticleNumber, promotedFreeFlag, promotedQuantity, promotedQuantitySu, promotionGuid);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OrderFreeProduct> GetOrderFreeProducts(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OrderFreeProduct>();
	
	var query = new Query<OrderFreeProduct>(@"SELECT ARTICLE_NUMBER, ORDER_NUMBER, QUANTITY, REASON_CODE FROM ORDER_FREE_PRODUCTS", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var orderNumber = Query.GetLong(r, 1);
var quantity = Query.GetLong(r, 2);
var reasonCode = Query.GetString(r, 3);

return new OrderFreeProduct(articleNumber, orderNumber, quantity, reasonCode);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OrderHeader> GetOrderHeaders(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OrderHeader>();
	
	var query = new Query<OrderHeader>(@"SELECT ACTIVITY_ID, ADDRESS_NUMBER, ATP_DEPOSIT, ATP_PROMO_DISCOUNT, ATP_GROSS_TOTAL, ATP_TAX_TOTAL, ATP_TIMESTAMP, ATP_TOTAL, CONVERTED_QUANTITY, CREATED_AT, CUSTOMER_REFERENCE, DELIVERY_DATE, DELIVERY_LOCATION_CODE, DELIVERY_TRANSACTION_CODE, EXTERNAL_REFERENCE_NUMBER, GRID_NUMBER, HAS_EMPTIES, LAST_SAVED_AT, ORDER_DATE, ORDER_NUMBER, ORDER_STATUS, ORDER_TYPE_CODE, POP_ARTICLE_GROUP, PRICELIST_BASED_AMOUNT, PRICE_LIST_CODE, PROMOTION_CODE_GROUP, PROMOTION_REASON, TOTAL_CASES, TOTAL_CASES_CONV, TOTAL_CASES_CONV_AMOUNT, TRANSACTION_DESCRIPTION, UNPRODUCTIVE, VISIT_ID, WHOLESALER_ID, TO_OUTLET_NUMBER, REASON_LIST_ID, VENDOR_LIST_ID, PAYMENT_TERMS_LIST_ID FROM ORDER_HEADERS", r =>
	{
	var activityId = Query.GetLong(r, 0);
var addressNumber = Query.GetLong(r, 1);
var atpDeposit = Query.GetDecimal(r, 2);
var atpPromoDiscount = Query.GetDecimal(r, 3);
var atpGrossTotal = Query.GetDecimal(r, 4);
var atpTaxTotal = Query.GetDecimal(r, 5);
var atpTimestamp = Query.GetDateTime(r, 6);
var atpTotal = Query.GetDecimal(r, 7);
var convertedQuantity = Query.GetDecimal(r, 8);
var createdAt = Query.GetDateTime(r, 9);
var customerReference = Query.GetString(r, 10);
var deliveryDate = Query.GetDateTime(r, 11);
var deliveryLocationCode = Query.GetLong(r, 12);
var deliveryTransactionCode = Query.GetLong(r, 13);
var externalReferenceNumber = Query.GetString(r, 14);
var gridNumber = Query.GetString(r, 15);
var hasEmpties = Query.GetInt(r, 16);
var lastSavedAt = Query.GetDateTime(r, 17);
var orderDate = Query.GetDateTime(r, 18);
var orderNumber = Query.GetLong(r, 19);
var orderStatus = Query.GetInt(r, 20);
var orderTypeCode = Query.GetLong(r, 21);
var popArticleGroup = Query.GetLong(r, 22);
var pricelistBasedAmount = Query.GetDecimal(r, 23);
var priceListCode = Query.GetLong(r, 24);
var promotionCodeGroup = Query.GetString(r, 25);
var promotionReason = Query.GetString(r, 26);
var totalCases = Query.GetDecimal(r, 27);
var totalCasesConv = Query.GetDecimal(r, 28);
var totalCasesConvAmount = Query.GetDecimal(r, 29);
var transactionDescription = Query.GetString(r, 30);
var unproductive = Query.GetInt(r, 31);
var visitId = Query.GetLong(r, 32);
var wholesalerId = Query.GetLong(r, 33);
var toOutletNumber = Query.GetLong(r, 34);
var reasonListId = Query.GetLong(r, 35);
var vendorListId = Query.GetLong(r, 36);
var paymentTermsListId = Query.GetLong(r, 37);

return new OrderHeader(activityId, addressNumber, atpDeposit, atpPromoDiscount, atpGrossTotal, atpTaxTotal, atpTimestamp, atpTotal, convertedQuantity, createdAt, customerReference, deliveryDate, deliveryLocationCode, deliveryTransactionCode, externalReferenceNumber, gridNumber, hasEmpties, lastSavedAt, orderDate, orderNumber, orderStatus, orderTypeCode, popArticleGroup, pricelistBasedAmount, priceListCode, promotionCodeGroup, promotionReason, totalCases, totalCasesConv, totalCasesConvAmount, transactionDescription, unproductive, visitId, wholesalerId, toOutletNumber, reasonListId, vendorListId, paymentTermsListId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OrderText> GetOrderTexts(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OrderText>();
	
	var query = new Query<OrderText>(@"SELECT ACTIVITY_ID, DEVICE_ID, LINE_NO, LINE_TEXT, LIST_CODE, ORIGIN FROM ORDER_TEXTS", r =>
	{
	var activityId = Query.GetLong(r, 0);
var deviceId = Query.GetDecimal(r, 1);
var lineNo = Query.GetInt(r, 2);
var lineText = Query.GetString(r, 3);
var listCode = Query.GetString(r, 4);
var origin = Query.GetString(r, 5);

return new OrderText(activityId, deviceId, lineNo, lineText, listCode, origin);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OrderType> GetOrderTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OrderType>();
	
	var query = new Query<OrderType>(@"SELECT CODE, LOCAL_NAME, NAME FROM ORDER_TYPES", r =>
	{
	var code = Query.GetLong(r, 0);
var localName = Query.GetString(r, 1);
var name = Query.GetString(r, 2);

return new OrderType(code, localName, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletsExtension> GetOutletsExtensions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletsExtension>();
	
	var query = new Query<OutletsExtension>(@"SELECT NAME, ORDINAL, OUTLET_NUMBER, VALUE FROM OUTLETS_EXTENSIONS", r =>
	{
	var name = Query.GetString(r, 0);
var ordinal = Query.GetInt(r, 1);
var outletNumber = Query.GetLong(r, 2);
var value = Query.GetString(r, 3);

return new OutletsExtension(name, ordinal, outletNumber, value);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletAddresse> GetOutletAddresses(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletAddresse>();
	
	var query = new Query<OutletAddresse>(@"SELECT ADDRESS_NUMBER, OUTLET_NUMBER, STREET, HOUSE_NUMBER, POSTAL_CODE, ORIGIN, CITY, IS_DEFAULT, VALID_FROM, VALID_TO FROM OUTLET_ADDRESSES", r =>
	{
	var addressNumber = Query.GetLong(r, 0);
var outletNumber = Query.GetLong(r, 1);
var street = Query.GetString(r, 2);
var houseNumber = Query.GetString(r, 3);
var postalCode = Query.GetString(r, 4);
var origin = Query.GetString(r, 5);
var city = Query.GetString(r, 6);
var isDefault = Query.GetInt(r, 7);
var validFrom = Query.GetDateTime(r, 8);
var validTo = Query.GetDateTime(r, 9);

return new OutletAddresse(addressNumber, outletNumber, street, houseNumber, postalCode, origin, city, isDefault, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletCluster> GetOutletClusters(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletCluster>();
	
	var query = new Query<OutletCluster>(@"SELECT HIERARCHY_NODE, ATTRIBUTE_CODE, DESCRIPTION FROM OUTLET_CLUSTERS", r =>
	{
	var hierarchyNode = Query.GetDecimal(r, 0);
var attributeCode = Query.GetDecimal(r, 1);
var description = Query.GetString(r, 2);

return new OutletCluster(hierarchyNode, attributeCode, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletHierLevel> GetOutletHierLevels(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletHierLevel>();
	
	var query = new Query<OutletHierLevel>(@"SELECT DESCRIPTION, HIER_LEVEL, HIER_NODE, OUTLET_NUMBER, PARENT_OUTLET_NUMBER FROM OUTLET_HIER_LEVELS", r =>
	{
	var description = Query.GetString(r, 0);
var hierLevel = Query.GetLong(r, 1);
var hierNode = Query.GetString(r, 2);
var outletNumber = Query.GetLong(r, 3);
var parentOutletNumber = Query.GetLong(r, 4);

return new OutletHierLevel(description, hierLevel, hierNode, outletNumber, parentOutletNumber);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletMarketAttribute> GetOutletMarketAttributes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletMarketAttribute>();
	
	var query = new Query<OutletMarketAttribute>(@"SELECT ATVALUEDESCR, CHANGED_AT, CHANGED_BY, CHARACT, CHARACT_DESCR, DESCRIPTION, INHERITED, INSTANCE, OUTLET_NUMBER, VALUE, VALUE_ASSIGNMENT, VALUE_NEUTRAL, VAL_ASSIGN FROM OUTLET_MARKET_ATTRIBUTES", r =>
	{
	var atvaluedescr = Query.GetString(r, 0);
var changedAt = Query.GetDateTime(r, 1);
var changedBy = Query.GetString(r, 2);
var charact = Query.GetString(r, 3);
var charactDescr = Query.GetString(r, 4);
var description = Query.GetString(r, 5);
var inherited = Query.GetString(r, 6);
var instance = Query.GetInt(r, 7);
var outletNumber = Query.GetLong(r, 8);
var value = Query.GetString(r, 9);
var valueAssignment = Query.GetString(r, 10);
var valueNeutral = Query.GetString(r, 11);
var valAssign = Query.GetString(r, 12);

return new OutletMarketAttribute(atvaluedescr, changedAt, changedBy, charact, charactDescr, description, inherited, instance, outletNumber, value, valueAssignment, valueNeutral, valAssign);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletRule> GetOutletRules(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletRule>();
	
	var query = new Query<OutletRule>(@"SELECT IDX, OUTLET_NUMBER, TEXT FROM OUTLET_RULES", r =>
	{
	var idx = Query.GetLong(r, 0);
var outletNumber = Query.GetLong(r, 1);
var text = Query.GetString(r, 2);

return new OutletRule(idx, outletNumber, text);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletSnap> GetOutletSnaps(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletSnap>();
	
	var query = new Query<OutletSnap>(@"SELECT ADDRESS, BANK_ACCOUNT_NUMBER, BILLING_BLOCK, BILL_TO_OUTLET_NUMBER, BUSINESS_TYPE_CODE, CITY, CONTACT_PERSON, CREDIT_DAYS, CREDIT_LIMIT, CURRENCY, CUSTOMER_GROUP, DELIVERY_BLOCK, DELIVERY_DELAY, DELIVERY_LEAD_TIME_CODE, DELIVERY_LOCATION_CODE, DELIVERY_TRANSACTIONS_DESC, DELIVERY_TRANSACTION_CODE, DELIVERY_TYPE_CODE, EMAIL, EXPRESS_ORDER_ALLOWED, FACTORY, FAX, LATITUDE, LONGITUDE, NAME1, NAME2, ORDER_BLOCK, OUTLET_NUMBER, PAYER_NUMBER, POSTAL_CODE, PRICE_GROUP, PRIMARY_CONSUMER_ACTIVITY, RED_POS_ID, SALES_BLOCK, SALES_DISTRICT_CODE, SALES_GROUP_CODE, SALES_OFFICE_CODE, SHIP_TO_OUTLET_NUMBER, SUB_TRADE_CHANNEL_CODE, SUPPRESSED_CODE, SUPPRESSION_DATE, TELEPHONE, TELEPHONE_2, TRADE_CHANNEL_CODE, VAT_NUMBER, WHOLESALER_ID FROM OUTLET_SNAP", r =>
	{
	var address = Query.GetString(r, 0);
var bankAccountNumber = Query.GetString(r, 1);
var billingBlock = Query.GetString(r, 2);
var billToOutletNumber = Query.GetLong(r, 3);
var businessTypeCode = Query.GetLong(r, 4);
var city = Query.GetString(r, 5);
var contactPerson = Query.GetString(r, 6);
var creditDays = Query.GetInt(r, 7);
var creditLimit = Query.GetLong(r, 8);
var currency = Query.GetString(r, 9);
var customerGroup = Query.GetString(r, 10);
var deliveryBlock = Query.GetString(r, 11);
var deliveryDelay = Query.GetLong(r, 12);
var deliveryLeadTimeCode = Query.GetLong(r, 13);
var deliveryLocationCode = Query.GetLong(r, 14);
var deliveryTransactionsDesc = Query.GetString(r, 15);
var deliveryTransactionCode = Query.GetLong(r, 16);
var deliveryTypeCode = Query.GetLong(r, 17);
var email = Query.GetString(r, 18);
var expressOrderAllowed = Query.GetInt(r, 19);
var factory = Query.GetString(r, 20);
var fax = Query.GetString(r, 21);
var latitude = Query.GetDecimal(r, 22);
var longitude = Query.GetDecimal(r, 23);
var name1 = Query.GetString(r, 24);
var name2 = Query.GetString(r, 25);
var orderBlock = Query.GetString(r, 26);
var outletNumber = Query.GetLong(r, 27);
var payerNumber = Query.GetLong(r, 28);
var postalCode = Query.GetString(r, 29);
var priceGroup = Query.GetString(r, 30);
var primaryConsumerActivity = Query.GetString(r, 31);
var redPosId = Query.GetString(r, 32);
var salesBlock = Query.GetInt(r, 33);
var salesDistrictCode = Query.GetLong(r, 34);
var salesGroupCode = Query.GetLong(r, 35);
var salesOfficeCode = Query.GetLong(r, 36);
var shipToOutletNumber = Query.GetLong(r, 37);
var subTradeChannelCode = Query.GetLong(r, 38);
var suppressedCode = Query.GetString(r, 39);
var suppressionDate = Query.GetDateTime(r, 40);
var telephone = Query.GetString(r, 41);
var telephone2 = Query.GetString(r, 42);
var tradeChannelCode = Query.GetLong(r, 43);
var vatNumber = Query.GetString(r, 44);
var wholesalerId = Query.GetLong(r, 45);

return new OutletSnap(address, bankAccountNumber, billingBlock, billToOutletNumber, businessTypeCode, city, contactPerson, creditDays, creditLimit, currency, customerGroup, deliveryBlock, deliveryDelay, deliveryLeadTimeCode, deliveryLocationCode, deliveryTransactionsDesc, deliveryTransactionCode, deliveryTypeCode, email, expressOrderAllowed, factory, fax, latitude, longitude, name1, name2, orderBlock, outletNumber, payerNumber, postalCode, priceGroup, primaryConsumerActivity, redPosId, salesBlock, salesDistrictCode, salesGroupCode, salesOfficeCode, shipToOutletNumber, subTradeChannelCode, suppressedCode, suppressionDate, telephone, telephone2, tradeChannelCode, vatNumber, wholesalerId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<OutletText> GetOutletTexts(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<OutletText>();
	
	var query = new Query<OutletText>(@"SELECT CHANGED_AT, CHANGED_BY, DEVICE_ID, LINE_FORMAT, LINE_NO, LINE_TEXT, LIST_CODE, ORIGIN, OUTLET_NUMBER FROM OUTLET_TEXTS", r =>
	{
	var changedAt = Query.GetDateTime(r, 0);
var changedBy = Query.GetString(r, 1);
var deviceId = Query.GetDecimal(r, 2);
var lineFormat = Query.GetString(r, 3);
var lineNo = Query.GetInt(r, 4);
var lineText = Query.GetString(r, 5);
var listCode = Query.GetString(r, 6);
var origin = Query.GetString(r, 7);
var outletNumber = Query.GetLong(r, 8);

return new OutletText(changedAt, changedBy, deviceId, lineFormat, lineNo, lineText, listCode, origin, outletNumber);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Parameter> GetParameters(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Parameter>();
	
	var query = new Query<Parameter>(@"SELECT DESCRIPTION, ID, PARAMETER_ID, PARAMETER_NAME, PARAMETER_TYPE, PARAMETER_VALUE, SET_ID FROM PARAMETERS", r =>
	{
	var description = Query.GetString(r, 0);
var id = Query.GetLong(r, 1);
var parameterId = Query.GetLong(r, 2);
var parameterName = Query.GetString(r, 3);
var parameterType = Query.GetString(r, 4);
var parameterValue = Query.GetString(r, 5);
var setId = Query.GetLong(r, 6);

return new Parameter(description, id, parameterId, parameterName, parameterType, parameterValue, setId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PayerOutlet> GetPayerOutlets(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PayerOutlet>();
	
	var query = new Query<PayerOutlet>(@"SELECT FROM_DATE, IS_SUPPRESSED, OUTLET_NUMBER, PAYER_NUMBER, SUPPRESSION_DATE, TO_DATE FROM PAYER_OUTLETS", r =>
	{
	var fromDate = Query.GetDateTime(r, 0);
var isSuppressed = Query.GetInt(r, 1);
var outletNumber = Query.GetLong(r, 2);
var payerNumber = Query.GetLong(r, 3);
var suppressionDate = Query.GetDateTime(r, 4);
var toDate = Query.GetDateTime(r, 5);

return new PayerOutlet(fromDate, isSuppressed, outletNumber, payerNumber, suppressionDate, toDate);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Phpooledsnapcolumndesc> GetPhpooledsnapcolumndescs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Phpooledsnapcolumndesc>();
	
	var query = new Query<Phpooledsnapcolumndesc>(@"SELECT ID, NAME, DATA_LENGTH, DATA_PRECISION, DATA_SCALE, SNAPSHOT_ID, DATA_TYPE, IS_SYSTEM, IS_NULL FROM PHPOOLEDSNAPCOLUMNDESC", r =>
	{
	var id = Query.GetLong(r, 0);
var name = Query.GetString(r, 1);
var dataLength = Query.GetDecimal(r, 2);
var dataPrecision = Query.GetDecimal(r, 3);
var dataScale = Query.GetDecimal(r, 4);
var snapshotId = Query.GetLong(r, 5);
var dataType = Query.GetString(r, 6);
var isSystem = Query.GetInt(r, 7);
var isNull = Query.GetDecimal(r, 8);

return new Phpooledsnapcolumndesc(id, name, dataLength, dataPrecision, dataScale, snapshotId, dataType, isSystem, isNull);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlacementRequest> GetPlacementRequests(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlacementRequest>();
	
	var query = new Query<PlacementRequest>(@"SELECT ACTIVATION_ON, ACTIVITY_ID, DELIVERY_ON, EQUIPMENT_TYPE_CODE, ID, ORIGIN FROM PLACEMENT_REQUESTS", r =>
	{
	var activationOn = Query.GetDateTime(r, 0);
var activityId = Query.GetLong(r, 1);
var deliveryOn = Query.GetDateTime(r, 2);
var equipmentTypeCode = Query.GetLong(r, 3);
var id = Query.GetLong(r, 4);
var origin = Query.GetString(r, 5);

return new PlacementRequest(activationOn, activityId, deliveryOn, equipmentTypeCode, id, origin);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlannedVolume> GetPlannedVolumes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlannedVolume>();
	
	var query = new Query<PlannedVolume>(@"SELECT KBI_INDICATOR, OUTLET_NUMBER, PLANNED_DATE, PLANNED_QTY, PLANNED_QTY_SU FROM PLANNED_VOLUMES", r =>
	{
	var kbiIndicator = Query.GetString(r, 0);
var outletNumber = Query.GetLong(r, 1);
var plannedDate = Query.GetDateTime(r, 2);
var plannedQty = Query.GetLong(r, 3);
var plannedQtySu = Query.GetLong(r, 4);

return new PlannedVolume(kbiIndicator, outletNumber, plannedDate, plannedQty, plannedQtySu);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlanningToolDailyCustom> GetPlanningToolDailyCustoms(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlanningToolDailyCustom>();
	
	var query = new Query<PlanningToolDailyCustom>(@"SELECT ACTIVITY_TYPE_ID, DELTA, DESCRIPTION, FOCUS_FLAG, FSM_INDICATOR, PLANNABLE_FLAG, PROCESS_TYPE, REASON_CODE, REASON_CODE2, REASON_CODE_GROUP, SORT_INDICATOR, UNIT_OF_MEASURE, VALID_FROM, VALID_TO, VOLUME_FLAG FROM PLANNING_TOOL_DAILY_CUSTOMS", r =>
	{
	var activityTypeId = Query.GetDecimal(r, 0);
var delta = Query.GetDecimal(r, 1);
var description = Query.GetString(r, 2);
var focusFlag = Query.GetString(r, 3);
var fsmIndicator = Query.GetString(r, 4);
var plannableFlag = Query.GetString(r, 5);
var processType = Query.GetString(r, 6);
var reasonCode = Query.GetString(r, 7);
var reasonCode2 = Query.GetString(r, 8);
var reasonCodeGroup = Query.GetString(r, 9);
var sortIndicator = Query.GetString(r, 10);
var unitOfMeasure = Query.GetString(r, 11);
var validFrom = Query.GetDateTime(r, 12);
var validTo = Query.GetDateTime(r, 13);
var volumeFlag = Query.GetString(r, 14);

return new PlanningToolDailyCustom(activityTypeId, delta, description, focusFlag, fsmIndicator, plannableFlag, processType, reasonCode, reasonCode2, reasonCodeGroup, sortIndicator, unitOfMeasure, validFrom, validTo, volumeFlag);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlanningToolDailyTarget> GetPlanningToolDailyTargets(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlanningToolDailyTarget>();
	
	var query = new Query<PlanningToolDailyTarget>(@"SELECT AVERAGE_ORDER, FISCAL_YEAR_PERIOD, FISCAL_YEAR_VARIANT, FSM_INDICATOR, FSM_INDICATOR_KEY, LAST_ORDER_DATE, LAST_ORDER_VOLUME, LAST_YEAR_FPA, MTD_ACTUALS, OUTLET_NUMBER, PAST_YEAR_FPA, RECORD_MODE, TRANSACTION_DATE FROM PLANNING_TOOL_DAILY_TARGETS", r =>
	{
	var averageOrder = Query.GetDecimal(r, 0);
var fiscalYearPeriod = Query.GetDateTime(r, 1);
var fiscalYearVariant = Query.GetString(r, 2);
var fsmIndicator = Query.GetString(r, 3);
var fsmIndicatorKey = Query.GetString(r, 4);
var lastOrderDate = Query.GetDateTime(r, 5);
var lastOrderVolume = Query.GetDecimal(r, 6);
var lastYearFpa = Query.GetDecimal(r, 7);
var mtdActuals = Query.GetDecimal(r, 8);
var outletNumber = Query.GetLong(r, 9);
var pastYearFpa = Query.GetDecimal(r, 10);
var recordMode = Query.GetString(r, 11);
var transactionDate = Query.GetDateTime(r, 12);

return new PlanningToolDailyTarget(averageOrder, fiscalYearPeriod, fiscalYearVariant, fsmIndicator, fsmIndicatorKey, lastOrderDate, lastOrderVolume, lastYearFpa, mtdActuals, outletNumber, pastYearFpa, recordMode, transactionDate);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlanningToolDailyVolume> GetPlanningToolDailyVolumes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlanningToolDailyVolume>();
	
	var query = new Query<PlanningToolDailyVolume>(@"SELECT FIELD_ID, FIELD_INDEX, FSM_INDICATOR, OPERATION_TYPE, SIGN, VALID_FROM, VALID_TO, VALUE_HIGH, VALUE_LOW FROM PLANNING_TOOL_DAILY_VOLUMES", r =>
	{
	var fieldId = Query.GetString(r, 0);
var fieldIndex = Query.GetInt(r, 1);
var fsmIndicator = Query.GetString(r, 2);
var operationType = Query.GetString(r, 3);
var sign = Query.GetString(r, 4);
var validFrom = Query.GetDateTime(r, 5);
var validTo = Query.GetDateTime(r, 6);
var valueHigh = Query.GetString(r, 7);
var valueLow = Query.GetString(r, 8);

return new PlanningToolDailyVolume(fieldId, fieldIndex, fsmIndicator, operationType, sign, validFrom, validTo, valueHigh, valueLow);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlanningToolTarget> GetPlanningToolTargets(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlanningToolTarget>();
	
	var query = new Query<PlanningToolTarget>(@"SELECT ACTUALS, COMPANY_CODE, FISCAL_YEAR_PERIOD, FISCAL_YEAR_VARIANT, FSM_INDICATOR, FSM_INDICATOR_KEY, ORIGIN, ROUTE_CODE, TARGET, TERRITORY_ID, TRANSACTION_DATE FROM PLANNING_TOOL_TARGETS", r =>
	{
	var actuals = Query.GetDecimal(r, 0);
var companyCode = Query.GetString(r, 1);
var fiscalYearPeriod = Query.GetDateTime(r, 2);
var fiscalYearVariant = Query.GetString(r, 3);
var fsmIndicator = Query.GetString(r, 4);
var fsmIndicatorKey = Query.GetString(r, 5);
var origin = Query.GetString(r, 6);
var routeCode = Query.GetLong(r, 7);
var target = Query.GetDecimal(r, 8);
var territoryId = Query.GetString(r, 9);
var transactionDate = Query.GetDateTime(r, 10);

return new PlanningToolTarget(actuals, companyCode, fiscalYearPeriod, fiscalYearVariant, fsmIndicator, fsmIndicatorKey, origin, routeCode, target, territoryId, transactionDate);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlanningToolTeam> GetPlanningToolTeams(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlanningToolTeam>();
	
	var query = new Query<PlanningToolTeam>(@"SELECT FSM_INDICATOR, PLANNED_VALUE, PLANNING_DATE, USER_ID FROM PLANNING_TOOL_TEAMS", r =>
	{
	var fsmIndicator = Query.GetString(r, 0);
var plannedValue = Query.GetDecimal(r, 1);
var planningDate = Query.GetDateTime(r, 2);
var userId = Query.GetLong(r, 3);

return new PlanningToolTeam(fsmIndicator, plannedValue, planningDate, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PlanningToolUser> GetPlanningToolUsers(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PlanningToolUser>();
	
	var query = new Query<PlanningToolUser>(@"SELECT ACTUAL_VALUE, FSM_INDICATOR, OUTLET_NUMBER, PLANNED_VALUE, PLANNING_DATE, USER_ID FROM PLANNING_TOOL_USERS", r =>
	{
	var actualValue = Query.GetDecimal(r, 0);
var fsmIndicator = Query.GetString(r, 1);
var outletNumber = Query.GetLong(r, 2);
var plannedValue = Query.GetDecimal(r, 3);
var planningDate = Query.GetDateTime(r, 4);
var userId = Query.GetLong(r, 5);

return new PlanningToolUser(actualValue, fsmIndicator, outletNumber, plannedValue, planningDate, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PopArticle> GetPopArticles(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PopArticle>();
	
	var query = new Query<PopArticle>(@"SELECT ARTICLE_NUMBER, ENTRY_ID FROM POP_ARTICLES", r =>
	{
	var articleNumber = Query.GetLong(r, 0);
var entryId = Query.GetLong(r, 1);

return new PopArticle(articleNumber, entryId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PopEntrie> GetPopEntries(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PopEntrie>();
	
	var query = new Query<PopEntrie>(@"SELECT COMMENTS, ID, IS_DEFAULT, IS_VALID, NAME FROM POP_ENTRIES", r =>
	{
	var comments = Query.GetString(r, 0);
var id = Query.GetLong(r, 1);
var isDefault = Query.GetInt(r, 2);
var isValid = Query.GetInt(r, 3);
var name = Query.GetString(r, 4);

return new PopEntrie(comments, id, isDefault, isValid, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PromotionHeader> GetPromotionHeaders(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PromotionHeader>();
	
	var query = new Query<PromotionHeader>(@"SELECT ACTUALFINISH, ACTUALSTART, DESCRIPTION, IS_SUPPRESSED, MANUAL_STATUS, OBJECTIVE, PRIORITY, PROMOTION_GUID, PROMOTION_ID, TACTIC, TYPE, LONG_TEXT, PROMO_TYPE, PLANNED_START, PLANNED_FINISH, THRESHOLD FROM PROMOTION_HEADERS", r =>
	{
	var actualfinish = Query.GetDateTime(r, 0);
var actualstart = Query.GetDateTime(r, 1);
var description = Query.GetString(r, 2);
var isSuppressed = Query.GetInt(r, 3);
var manualStatus = Query.GetString(r, 4);
var objective = Query.GetString(r, 5);
var priority = Query.GetInt(r, 6);
var promotionGuid = Query.GetString(r, 7);
var promotionId = Query.GetString(r, 8);
var tactic = Query.GetString(r, 9);
var type = Query.GetString(r, 10);
var longText = Query.GetString(r, 11);
var promoType = Query.GetString(r, 12);
var plannedStart = Query.GetDateTime(r, 13);
var plannedFinish = Query.GetDateTime(r, 14);
var threshold = Query.GetLong(r, 15);

return new PromotionHeader(actualfinish, actualstart, description, isSuppressed, manualStatus, objective, priority, promotionGuid, promotionId, tactic, type, longText, promoType, plannedStart, plannedFinish, threshold);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PromotionPrdItem> GetPromotionPrdItems(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PromotionPrdItem>();
	
	var query = new Query<PromotionPrdItem>(@"SELECT FREE_FLAG, PROMOTION_GUID, ARTICLE_NUMBER FROM PROMOTION_PRD_ITEMS", r =>
	{
	var freeFlag = Query.GetString(r, 0);
var promotionGuid = Query.GetString(r, 1);
var articleNumber = Query.GetLong(r, 2);

return new PromotionPrdItem(freeFlag, promotionGuid, articleNumber);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PromoMechanicsHeader> GetPromoMechanicsHeaders(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PromoMechanicsHeader>();
	
	var query = new Query<PromoMechanicsHeader>(@"SELECT GROUP_DESCRIPTION, GROUP_TYPE, MAX_GR, MIN_GR, PROMOTION_GUID FROM PROMO_MECHANICS_HEADERS", r =>
	{
	var groupDescription = Query.GetString(r, 0);
var groupType = Query.GetString(r, 1);
var maxGr = Query.GetInt(r, 2);
var minGr = Query.GetInt(r, 3);
var promotionGuid = Query.GetString(r, 4);

return new PromoMechanicsHeader(groupDescription, groupType, maxGr, minGr, promotionGuid);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PromoPartnersHierarchy> GetPromoPartnersHierarchys(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PromoPartnersHierarchy>();
	
	var query = new Query<PromoPartnersHierarchy>(@"SELECT HIER_NODE, PROMOTION_GUID FROM PROMO_PARTNERS_HIERARCHY", r =>
	{
	var hierNode = Query.GetString(r, 0);
var promotionGuid = Query.GetString(r, 1);

return new PromoPartnersHierarchy(hierNode, promotionGuid);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<PromoScale> GetPromoScales(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<PromoScale>();
	
	var query = new Query<PromoScale>(@"SELECT FREE, GROUP1_STEP, GROUP2_STEP, GROUP3_STEP, PROMOTION_GUID FROM PROMO_SCALES", r =>
	{
	var free = Query.GetInt(r, 0);
var group1Step = Query.GetInt(r, 1);
var group2Step = Query.GetInt(r, 2);
var group3Step = Query.GetInt(r, 3);
var promotionGuid = Query.GetString(r, 4);

return new PromoScale(free, group1Step, group2Step, group3Step, promotionGuid);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedActivitiesLog> GetRedActivitiesLogs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedActivitiesLog>();
	
	var query = new Query<RedActivitiesLog>(@"SELECT ACTIVITY_DATE, ACTIVITY_ID, ACTIVITY_TYPE, OUTLET_NUMBER, RED_INDEX, USER_ID FROM RED_ACTIVITIES_LOG", r =>
	{
	var activityDate = Query.GetDateTime(r, 0);
var activityId = Query.GetLong(r, 1);
var activityType = Query.GetInt(r, 2);
var outletNumber = Query.GetLong(r, 3);
var redIndex = Query.GetDecimal(r, 4);
var userId = Query.GetLong(r, 5);

return new RedActivitiesLog(activityDate, activityId, activityType, outletNumber, redIndex, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedCccH> GetRedCccHs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedCccH>();
	
	var query = new Query<RedCccH>(@"SELECT COMMIT_ID, CONTRACT_ID, DESCRIPTION, VALID_FROM, VALID_TO FROM RED_CCC_H", r =>
	{
	var commitId = Query.GetString(r, 0);
var contractId = Query.GetString(r, 1);
var description = Query.GetString(r, 2);
var validFrom = Query.GetDateTime(r, 3);
var validTo = Query.GetDateTime(r, 4);

return new RedCccH(commitId, contractId, description, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedCccList> GetRedCccLists(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedCccList>();
	
	var query = new Query<RedCccList>(@"SELECT COMMIT_ID, LIST_TYPE, ARTICLE_NUMBER, PRODUCT, PARAM1, PARAM10, PARAM11, PARAM12, PARAM13, PARAM14, PARAM2, PARAM3, PARAM4, PARAM5, PARAM6, PARAM7, PARAM8, PARAM9, PARAM_POS, PFP_TARGET, QUESTION_ID, SHORT_TEXT, WEIGHT FROM RED_CCC_LIST", r =>
	{
	var commitId = Query.GetString(r, 0);
var listType = Query.GetInt(r, 1);
var articleNumber = Query.GetLong(r, 2);
var product = Query.GetString(r, 3);
var param1 = Query.GetString(r, 4);
var param10 = Query.GetString(r, 5);
var param11 = Query.GetString(r, 6);
var param12 = Query.GetString(r, 7);
var param13 = Query.GetString(r, 8);
var param14 = Query.GetString(r, 9);
var param2 = Query.GetString(r, 10);
var param3 = Query.GetString(r, 11);
var param4 = Query.GetString(r, 12);
var param5 = Query.GetString(r, 13);
var param6 = Query.GetString(r, 14);
var param7 = Query.GetString(r, 15);
var param8 = Query.GetString(r, 16);
var param9 = Query.GetString(r, 17);
var paramPos = Query.GetString(r, 18);
var pfpTarget = Query.GetDecimal(r, 19);
var questionId = Query.GetString(r, 20);
var shortText = Query.GetString(r, 21);
var weight = Query.GetDecimal(r, 22);

return new RedCccList(commitId, listType, articleNumber, product, param1, param10, param11, param12, param13, param14, param2, param3, param4, param5, param6, param7, param8, param9, paramPos, pfpTarget, questionId, shortText, weight);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedCccOutl> GetRedCccOutls(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedCccOutl>();
	
	var query = new Query<RedCccOutl>(@"SELECT COMMIT_ID, OUTLET_NUMBER, OUTL_ID, VALID_FROM, VALID_TO FROM RED_CCC_OUTL", r =>
	{
	var commitId = Query.GetString(r, 0);
var outletNumber = Query.GetLong(r, 1);
var outlId = Query.GetString(r, 2);
var validFrom = Query.GetDateTime(r, 3);
var validTo = Query.GetDateTime(r, 4);

return new RedCccOutl(commitId, outletNumber, outlId, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedCccParVal> GetRedCccParVals(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedCccParVal>();
	
	var query = new Query<RedCccParVal>(@"SELECT PARAM_CODE, PARAM_ID, PARAM_POS, PARAM_TEXT, TYPE FROM RED_CCC_PAR_VAL", r =>
	{
	var paramCode = Query.GetString(r, 0);
var paramId = Query.GetString(r, 1);
var paramPos = Query.GetString(r, 2);
var paramText = Query.GetString(r, 3);
var type = Query.GetInt(r, 4);

return new RedCccParVal(paramCode, paramId, paramPos, paramText, type);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedCccTarg> GetRedCccTargs(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedCccTarg>();
	
	var query = new Query<RedCccTarg>(@"SELECT COMMIT_ID, PFP_TARGET, QUESTION_ID FROM RED_CCC_TARG", r =>
	{
	var commitId = Query.GetString(r, 0);
var pfpTarget = Query.GetDecimal(r, 1);
var questionId = Query.GetString(r, 2);

return new RedCccTarg(commitId, pfpTarget, questionId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedCccTarVal> GetRedCccTarVals(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedCccTarVal>();
	
	var query = new Query<RedCccTarVal>(@"SELECT COMMIT_ID, QUESTION_ID, VALID_FROM, VALID_TO FROM RED_CCC_TAR_VAL", r =>
	{
	var commitId = Query.GetString(r, 0);
var questionId = Query.GetString(r, 1);
var validFrom = Query.GetDateTime(r, 2);
var validTo = Query.GetDateTime(r, 3);

return new RedCccTarVal(commitId, questionId, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedGapsAction> GetRedGapsActions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedGapsAction>();
	
	var query = new Query<RedGapsAction>(@"SELECT TYPE, SECTION_ID, QUESTION_ID, GAP_ACTION FROM RED_GAPS_ACTIONS", r =>
	{
	var type = Query.GetString(r, 0);
var sectionId = Query.GetString(r, 1);
var questionId = Query.GetString(r, 2);
var gapAction = Query.GetString(r, 3);

return new RedGapsAction(type, sectionId, questionId, gapAction);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedGapsPlanning> GetRedGapsPlannings(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedGapsPlanning>();
	
	var query = new Query<RedGapsPlanning>(@"SELECT QUESTION_ID, REASON_CODE2, REASON_CODE, REASON_CODEGRP, PROCESS_TYPE FROM RED_GAPS_PLANNING", r =>
	{
	var questionId = Query.GetString(r, 0);
var reasonCode2 = Query.GetString(r, 1);
var reasonCode = Query.GetString(r, 2);
var reasonCodegrp = Query.GetString(r, 3);
var processType = Query.GetString(r, 4);

return new RedGapsPlanning(questionId, reasonCode2, reasonCode, reasonCodegrp, processType);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedListingAnswer> GetRedListingAnswers(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedListingAnswer>();
	
	var query = new Query<RedListingAnswer>(@"SELECT ACTIVITY_ID, ORDINAL_NUMBER, VALUE FROM RED_LISTING_ANSWERS", r =>
	{
	var activityId = Query.GetLong(r, 0);
var ordinalNumber = Query.GetLong(r, 1);
var value = Query.GetString(r, 2);

return new RedListingAnswer(activityId, ordinalNumber, value);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedListingHeader> GetRedListingHeaders(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedListingHeader>();
	
	var query = new Query<RedListingHeader>(@"SELECT LISTING_ID, TYPE, DESCRIPTION FROM RED_LISTING_HEADERS", r =>
	{
	var listingId = Query.GetString(r, 0);
var type = Query.GetInt(r, 1);
var description = Query.GetString(r, 2);

return new RedListingHeader(listingId, type, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedListingItem> GetRedListingItems(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedListingItem>();
	
	var query = new Query<RedListingItem>(@"SELECT ID, WEIGHT, PARAM_POS, PARAM14, PARAM13, PARAM12, PARAM11, PARAM10, PARAM9, PARAM8, PARAM7, PARAM6, PARAM5, PARAM4, PARAM3, PARAM2, PARAM1, PRODUCT, LISTING_ID, ARTICLE_NUMBER, SHORT_TEXT FROM RED_LISTING_ITEMS", r =>
	{
	var id = Query.GetLong(r, 0);
var weight = Query.GetDecimal(r, 1);
var paramPos = Query.GetString(r, 2);
var param14 = Query.GetString(r, 3);
var param13 = Query.GetString(r, 4);
var param12 = Query.GetString(r, 5);
var param11 = Query.GetString(r, 6);
var param10 = Query.GetString(r, 7);
var param9 = Query.GetString(r, 8);
var param8 = Query.GetString(r, 9);
var param7 = Query.GetString(r, 10);
var param6 = Query.GetString(r, 11);
var param5 = Query.GetString(r, 12);
var param4 = Query.GetString(r, 13);
var param3 = Query.GetString(r, 14);
var param2 = Query.GetString(r, 15);
var param1 = Query.GetString(r, 16);
var product = Query.GetString(r, 17);
var listingId = Query.GetString(r, 18);
var articleNumber = Query.GetLong(r, 19);
var shortText = Query.GetString(r, 20);

return new RedListingItem(id, weight, paramPos, param14, param13, param12, param11, param10, param9, param8, param7, param6, param5, param4, param3, param2, param1, product, listingId, articleNumber, shortText);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedListMapping> GetRedListMappings(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedListMapping>();
	
	var query = new Query<RedListMapping>(@"SELECT POS_ID, LISTING_ID, QUESTION_ID, RED_POS FROM RED_LIST_MAPPING", r =>
	{
	var posId = Query.GetString(r, 0);
var listingId = Query.GetString(r, 1);
var questionId = Query.GetString(r, 2);
var redPos = Query.GetString(r, 3);

return new RedListMapping(posId, listingId, questionId, redPos);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedListParam> GetRedListParams(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedListParam>();
	
	var query = new Query<RedListParam>(@"SELECT TYPE, TEXT_FIELD, FIELD, VALUE_TABLE, FUNCTION_MODULE, DESCRIPTION, PARAM_POS, PARAM_ID FROM RED_LIST_PARAMS", r =>
	{
	var type = Query.GetInt(r, 0);
var textField = Query.GetString(r, 1);
var field = Query.GetString(r, 2);
var valueTable = Query.GetString(r, 3);
var functionModule = Query.GetString(r, 4);
var description = Query.GetString(r, 5);
var paramPos = Query.GetString(r, 6);
var paramId = Query.GetString(r, 7);

return new RedListParam(type, textField, field, valueTable, functionModule, description, paramPos, paramId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedMapping> GetRedMappings(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedMapping>();
	
	var query = new Query<RedMapping>(@"SELECT CCAF_VALUE, CHANNEL, CPL, POS_ID, DESCRIPTION, CPL_CHANNEL_CCAF FROM RED_MAPPING", r =>
	{
	var ccafValue = Query.GetString(r, 0);
var channel = Query.GetString(r, 1);
var cpl = Query.GetString(r, 2);
var posId = Query.GetString(r, 3);
var description = Query.GetString(r, 4);
var cplChannelCcaf = Query.GetString(r, 5);

return new RedMapping(ccafValue, channel, cpl, posId, description, cplChannelCcaf);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedParamsValue> GetRedParamsValues(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedParamsValue>();
	
	var query = new Query<RedParamsValue>(@"SELECT TYPE, PARAM_TEXT, PARAM_CODE, PARAM_ID, PARAM_POS FROM RED_PARAMS_VALUES", r =>
	{
	var type = Query.GetInt(r, 0);
var paramText = Query.GetString(r, 1);
var paramCode = Query.GetString(r, 2);
var paramId = Query.GetString(r, 3);
var paramPos = Query.GetString(r, 4);

return new RedParamsValue(type, paramText, paramCode, paramId, paramPos);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<RedPosDescription> GetRedPosDescriptions(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<RedPosDescription>();
	
	var query = new Query<RedPosDescription>(@"SELECT POS_ID, DESCRIPTION FROM RED_POS_DESCRIPTIONS", r =>
	{
	var posId = Query.GetString(r, 0);
var description = Query.GetString(r, 1);

return new RedPosDescription(posId, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<SalesDistrict> GetSalesDistricts(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<SalesDistrict>();
	
	var query = new Query<SalesDistrict>(@"SELECT CODE, BZIRK, DESCRIPTION FROM SALES_DISTRICTS", r =>
	{
	var code = Query.GetLong(r, 0);
var bzirk = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new SalesDistrict(code, bzirk, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<SapActivityHistory> GetSapActivityHistorys(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<SapActivityHistory>();
	
	var query = new Query<SapActivityHistory>(@"SELECT ACTIVITY_TYPE_ID, CHANGED_AT, CHANGED_BY, CREATED_AT, CREATED_BY, CRM_CHANGED_AT, DESCRIPTION, EXPIRES_AT, INPUT_CHANNEL, OUTLET_NUMBER, PARTNER_NO, PHX_CHANGED_AT, POSTING_DATE, SAP_CODE, SAP_ID, QUOTE(GUID) FROM SAP_ACTIVITY_HISTORY", r =>
	{
	var activityTypeId = Query.GetInt(r, 0);
var changedAt = Query.GetDateTime(r, 1);
var changedBy = Query.GetString(r, 2);
var createdAt = Query.GetDateTime(r, 3);
var createdBy = Query.GetString(r, 4);
var crmChangedAt = Query.GetDateTime(r, 5);
var description = Query.GetString(r, 6);
var expiresAt = Query.GetDateTime(r, 7);
var inputChannel = Query.GetString(r, 8);
var outletNumber = Query.GetLong(r, 9);
var partnerNo = Query.GetString(r, 10);
var phxChangedAt = Query.GetDateTime(r, 11);
var postingDate = Query.GetDateTime(r, 12);
var sapCode = Query.GetString(r, 13);
var sapId = Query.GetLong(r, 14);
var guid = Query.GetGuid(r, 15);

return new SapActivityHistory(activityTypeId, changedAt, changedBy, createdAt, createdBy, crmChangedAt, description, expiresAt, inputChannel, outletNumber, partnerNo, phxChangedAt, postingDate, sapCode, sapId, guid);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<SapActivityHistoryDetail> GetSapActivityHistoryDetails(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<SapActivityHistoryDetail>();
	
	var query = new Query<SapActivityHistoryDetail>(@"SELECT DISPLAY_TEXT, IS_PENDING, SAP_ID, SAP_STATUS, SAP_STATUS_PROFILE, STATUS_TYPE, TEXT FROM SAP_ACTIVITY_HISTORY_DETAILS", r =>
	{
	var displayText = Query.GetString(r, 0);
var isPending = Query.GetInt(r, 1);
var sapId = Query.GetLong(r, 2);
var sapStatus = Query.GetString(r, 3);
var sapStatusProfile = Query.GetString(r, 4);
var statusType = Query.GetInt(r, 5);
var text = Query.GetString(r, 6);

return new SapActivityHistoryDetail(displayText, isPending, sapId, sapStatus, sapStatusProfile, statusType, text);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<SapActivityProcType> GetSapActivityProcTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<SapActivityProcType>();
	
	var query = new Query<SapActivityProcType>(@"SELECT PROCESS_TYPE, DESCRIPTION, ENSCRIPTION FROM SAP_ACTIVITY_PROC_TYPES", r =>
	{
	var processType = Query.GetString(r, 0);
var description = Query.GetString(r, 1);
var enscription = Query.GetString(r, 2);

return new SapActivityProcType(processType, description, enscription);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<ShipToOutlet> GetShipToOutlets(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<ShipToOutlet>();
	
	var query = new Query<ShipToOutlet>(@"SELECT OUTLET_NUMBER, NAME1, NAME2, ADDRESS, FAX, POSTAL_CODE, CITY, TELEPHONE, CONTACT_PERSON, TELEPHONE_2, EMAIL, LONGITUDE, LATITUDE FROM SHIP_TO_OUTLETS", r =>
	{
	var outletNumber = Query.GetLong(r, 0);
var name1 = Query.GetString(r, 1);
var name2 = Query.GetString(r, 2);
var address = Query.GetString(r, 3);
var fax = Query.GetString(r, 4);
var postalCode = Query.GetString(r, 5);
var city = Query.GetString(r, 6);
var telephone = Query.GetString(r, 7);
var contactPerson = Query.GetString(r, 8);
var telephone2 = Query.GetString(r, 9);
var email = Query.GetString(r, 10);
var longitude = Query.GetDecimal(r, 11);
var latitude = Query.GetDecimal(r, 12);

return new ShipToOutlet(outletNumber, name1, name2, address, fax, postalCode, city, telephone, contactPerson, telephone2, email, longitude, latitude);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<SmartDeviceType> GetSmartDeviceTypes(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<SmartDeviceType>();
	
	var query = new Query<SmartDeviceType>(@"SELECT DESCRIPTION, IS_DATA_CAPABLE, LANG, TYPE_ID FROM SMART_DEVICE_TYPES", r =>
	{
	var description = Query.GetString(r, 0);
var isDataCapable = Query.GetInt(r, 1);
var lang = Query.GetString(r, 2);
var typeId = Query.GetString(r, 3);

return new SmartDeviceType(description, isDataCapable, lang, typeId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<StatusList> GetStatusLists(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<StatusList>();
	
	var query = new Query<StatusList>(@"SELECT ID, PARENT_ID, DESCRIPTION, DROPDOWN_ID, IS_SUPPRESSED, PARENT_DROPDOWN_ID, CODE, PARENT_CODE FROM STATUS_LISTS", r =>
	{
	var id = Query.GetLong(r, 0);
var parentId = Query.GetLong(r, 1);
var description = Query.GetString(r, 2);
var dropdownId = Query.GetLong(r, 3);
var isSuppressed = Query.GetInt(r, 4);
var parentDropdownId = Query.GetLong(r, 5);
var code = Query.GetString(r, 6);
var parentCode = Query.GetString(r, 7);

return new StatusList(id, parentId, description, dropdownId, isSuppressed, parentDropdownId, code, parentCode);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<SubTradeChannel> GetSubTradeChannels(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<SubTradeChannel>();
	
	var query = new Query<SubTradeChannel>(@"SELECT CODE, ATTRIB_7, DESCRIPTION FROM SUB_TRADE_CHANNELS", r =>
	{
	var code = Query.GetLong(r, 0);
var attrib7 = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new SubTradeChannel(code, attrib7, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Survey> GetSurveys(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Survey>();
	
	var query = new Query<Survey>(@"SELECT DESCRIPTION, FROM_DATE, ID, IS_COPY_LAST_VALUES, IS_GRID_VIEW, IS_RED, POS_ID, RED_INDEX, SEQUENCE, SET_ID, SUPPRESSED, TO_DATE, WEIGHT_RATIO FROM SURVEYS", r =>
	{
	var description = Query.GetString(r, 0);
var fromDate = Query.GetDateTime(r, 1);
var id = Query.GetLong(r, 2);
var isCopyLastValues = Query.GetInt(r, 3);
var isGridView = Query.GetInt(r, 4);
var isRed = Query.GetInt(r, 5);
var posId = Query.GetString(r, 6);
var redIndex = Query.GetLong(r, 7);
var sequence = Query.GetLong(r, 8);
var setId = Query.GetLong(r, 9);
var suppressed = Query.GetInt(r, 10);
var toDate = Query.GetDateTime(r, 11);
var weightRatio = Query.GetDecimal(r, 12);

return new Survey(description, fromDate, id, isCopyLastValues, isGridView, isRed, posId, redIndex, sequence, setId, suppressed, toDate, weightRatio);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<SurveyActivitie> GetSurveyActivities(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<SurveyActivitie>();
	
	var query = new Query<SurveyActivitie>(@"SELECT ACTIVITY_ID, SURVEY_ID, IS_COMPLETED, TARGET_SCORE, ACTUAL_SCORE, COMMIT_ID, RED_INDEX FROM SURVEY_ACTIVITIES", r =>
	{
	var activityId = Query.GetLong(r, 0);
var surveyId = Query.GetLong(r, 1);
var isCompleted = Query.GetInt(r, 2);
var targetScore = Query.GetDecimal(r, 3);
var actualScore = Query.GetDecimal(r, 4);
var commitId = Query.GetString(r, 5);
var redIndex = Query.GetDecimal(r, 6);

return new SurveyActivitie(activityId, surveyId, isCompleted, targetScore, actualScore, commitId, redIndex);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Tracing> GetTracings(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Tracing>();
	
	var query = new Query<Tracing>(@"SELECT ASSEMBLY_VERSION, CATEGORY, DEVICE_ID, LOG_TIME, MESSAGE, SAVE_ORDER, USER_ID, APL_SCREEN, APL_OPERATION, APL_CONTROL_TYPE, APL_DETAILS, APL_USER_NAME FROM TRACING", r =>
	{
	var assemblyVersion = Query.GetString(r, 0);
var category = Query.GetInt(r, 1);
var deviceId = Query.GetLong(r, 2);
var logTime = Query.GetDateTime(r, 3);
var message = Query.GetString(r, 4);
var saveOrder = Query.GetInt(r, 5);
var userId = Query.GetLong(r, 6);
var aplScreen = Query.GetString(r, 7);
var aplOperation = Query.GetString(r, 8);
var aplControlType = Query.GetString(r, 9);
var aplDetails = Query.GetString(r, 10);
var aplUserName = Query.GetString(r, 11);

return new Tracing(assemblyVersion, category, deviceId, logTime, message, saveOrder, userId, aplScreen, aplOperation, aplControlType, aplDetails, aplUserName);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<TradeChannel> GetTradeChannels(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<TradeChannel>();
	
	var query = new Query<TradeChannel>(@"SELECT CODE, ATTRIB_6, DESCRIPTION FROM TRADE_CHANNELS", r =>
	{
	var code = Query.GetLong(r, 0);
var attrib6 = Query.GetString(r, 1);
var description = Query.GetString(r, 2);

return new TradeChannel(code, attrib6, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<UserMessage> GetUserMessages(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<UserMessage>();
	
	var query = new Query<UserMessage>(@"SELECT CREATED_ON, EXPIRES_ON, ACTIVE_FROM, ID, IS_READ, IS_URGENT, MESSAGE, PC_ID, USER_GROUP, USER_ID FROM USER_MESSAGES", r =>
	{
	var createdOn = Query.GetDateTime(r, 0);
var expiresOn = Query.GetDateTime(r, 1);
var activeFrom = Query.GetDateTime(r, 2);
var id = Query.GetLong(r, 3);
var isRead = Query.GetInt(r, 4);
var isUrgent = Query.GetInt(r, 5);
var message = Query.GetString(r, 6);
var pcId = Query.GetLong(r, 7);
var userGroup = Query.GetLong(r, 8);
var userId = Query.GetLong(r, 9);

return new UserMessage(createdOn, expiresOn, activeFrom, id, isRead, isUrgent, message, pcId, userGroup, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<UserRouteSnap> GetUserRouteSnaps(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<UserRouteSnap>();
	
	var query = new Query<UserRouteSnap>(@"SELECT FROM_DATE, ID, ROUTE_CODE, TERRITORY, TO_DATE, USER_ID FROM USER_ROUTE_SNAP", r =>
	{
	var fromDate = Query.GetDateTime(r, 0);
var id = Query.GetLong(r, 1);
var routeCode = Query.GetLong(r, 2);
var territory = Query.GetString(r, 3);
var toDate = Query.GetDateTime(r, 4);
var userId = Query.GetLong(r, 5);

return new UserRouteSnap(fromDate, id, routeCode, territory, toDate, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<UserSetting> GetUserSettings(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<UserSetting>();
	
	var query = new Query<UserSetting>(@"SELECT Id, Context, Name, Value FROM USER_SETTINGS", r =>
	{
	var id = Query.GetLong(r, 0);
var context = Query.GetString(r, 1);
var name = Query.GetString(r, 2);
var value = Query.GetString(r, 3);

return new UserSetting(id, context, name, value);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<UserSnap> GetUserSnaps(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<UserSnap>();
	
	var query = new Query<UserSnap>(@"SELECT ADDRESS, E_MAIL, FULL_NAME, INDUSTRY, IS_AUDITTOOL_USER, IS_SUPERVISOR, PARENT_ID, PHONE_NUMBER, SHORT_NAME, USER_GROUP_ID, USER_ID FROM USER_SNAP", r =>
	{
	var address = Query.GetString(r, 0);
var eMail = Query.GetString(r, 1);
var fullName = Query.GetString(r, 2);
var industry = Query.GetString(r, 3);
var isAudittoolUser = Query.GetInt(r, 4);
var isSupervisor = Query.GetInt(r, 5);
var parentId = Query.GetLong(r, 6);
var phoneNumber = Query.GetString(r, 7);
var shortName = Query.GetString(r, 8);
var userGroupId = Query.GetLong(r, 9);
var userId = Query.GetLong(r, 10);

return new UserSnap(address, eMail, fullName, industry, isAudittoolUser, isSupervisor, parentId, phoneNumber, shortName, userGroupId, userId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Visit> GetVisits(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Visit>();
	
	var query = new Query<Visit>(@"SELECT ID, CREATION_DATE, IS_CLOSED, ORIGIN, OUTLET_NUMBER, PLANNED_DATE, PLANNED_TIMEIN, SEQUENCE, STATUS_CODE, TIMEIN, TIMEOUT, USER_ID, VISIT_DATE, STATUS_REASON_LIST_ID, REASON_LIST_ID, SUB_REASON_LIST_ID, EQUIPMENT_NUMBER, NOT_SCANNED_REASON_LIST_ID, SCANNED_TIME, STATUS_LIST_ID, ACTUAL_FROM, ACTUAL_TO, DESCRIPTION FROM VISITS", r =>
	{
	var id = Query.GetLong(r, 0);
var creationDate = Query.GetDateTime(r, 1);
var isClosed = Query.GetInt(r, 2);
var origin = Query.GetString(r, 3);
var outletNumber = Query.GetLong(r, 4);
var plannedDate = Query.GetDateTime(r, 5);
var plannedTimein = Query.GetDateTime(r, 6);
var sequence = Query.GetInt(r, 7);
var statusCode = Query.GetLong(r, 8);
var timein = Query.GetDateTime(r, 9);
var timeout = Query.GetDateTime(r, 10);
var userId = Query.GetLong(r, 11);
var visitDate = Query.GetDateTime(r, 12);
var statusReasonListId = Query.GetLong(r, 13);
var reasonListId = Query.GetLong(r, 14);
var subReasonListId = Query.GetLong(r, 15);
var equipmentNumber = Query.GetString(r, 16);
var notScannedReasonListId = Query.GetLong(r, 17);
var scannedTime = Query.GetDateTime(r, 18);
var statusListId = Query.GetLong(r, 19);
var actualFrom = Query.GetDateTime(r, 20);
var actualTo = Query.GetDateTime(r, 21);
var description = Query.GetString(r, 22);

return new Visit(id, creationDate, isClosed, origin, outletNumber, plannedDate, plannedTimein, sequence, statusCode, timein, timeout, userId, visitDate, statusReasonListId, reasonListId, subReasonListId, equipmentNumber, notScannedReasonListId, scannedTime, statusListId, actualFrom, actualTo, description);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<VisitComment> GetVisitComments(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<VisitComment>();
	
	var query = new Query<VisitComment>(@"SELECT ACTIVITY_ID, CREATED_ON, ID, IS_BY_ADMIN, MESSAGE, SEQUENCE_NUM, USERNAME, VISIT_ID FROM VISIT_COMMENTS", r =>
	{
	var activityId = Query.GetLong(r, 0);
var createdOn = Query.GetDateTime(r, 1);
var id = Query.GetLong(r, 2);
var isByAdmin = Query.GetInt(r, 3);
var message = Query.GetString(r, 4);
var sequenceNum = Query.GetLong(r, 5);
var username = Query.GetString(r, 6);
var visitId = Query.GetLong(r, 7);

return new VisitComment(activityId, createdOn, id, isByAdmin, message, sequenceNum, username, visitId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Wholesaler> GetWholesalers(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<Wholesaler>();
	
	var query = new Query<Wholesaler>(@"SELECT ADDRESS, CITY, DELIVERY_LOCATION_CODE, E_MAIL, FAX_NUMBER, GRID_DESCRIPTION, GRID_NUMBER, GRID_TYPE, ID, INDUSTRY, IS_SUPPRESSED, NAME1, NAME2, POSTAL_CODE, TEL_NUMBER, BLOCK_REASON FROM WHOLESALERS", r =>
	{
	var address = Query.GetString(r, 0);
var city = Query.GetString(r, 1);
var deliveryLocationCode = Query.GetLong(r, 2);
var eMail = Query.GetString(r, 3);
var faxNumber = Query.GetString(r, 4);
var gridDescription = Query.GetString(r, 5);
var gridNumber = Query.GetString(r, 6);
var gridType = Query.GetString(r, 7);
var id = Query.GetLong(r, 8);
var industry = Query.GetString(r, 9);
var isSuppressed = Query.GetInt(r, 10);
var name1 = Query.GetString(r, 11);
var name2 = Query.GetString(r, 12);
var postalCode = Query.GetString(r, 13);
var telNumber = Query.GetString(r, 14);
var blockReason = Query.GetString(r, 15);

return new Wholesaler(address, city, deliveryLocationCode, eMail, faxNumber, gridDescription, gridNumber, gridType, id, industry, isSuppressed, name1, name2, postalCode, telNumber, blockReason);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

	}
}
