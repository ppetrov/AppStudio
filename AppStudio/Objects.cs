using System;

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
}

public sealed class ActivationDefinition
{
	public string ActivationId { get; }
	public string ActivationName { get; }
	public string ActivationDesc { get; }
	public DateTime ActivationStart { get; }
	public DateTime ActivationEnd { get; }
	public string ActivationType { get; }
	public int IsMandatory { get; }
	public int IsGenerator { get; }
	public string Status { get; }
	public string LinkedDoc { get; }
	public string ZoneSubzone { get; }
	public string PromoCompliance { get; }
	public string PopActivation { get; }
	public string QuantOfPoi { get; }
	public string SizeOfPoi { get; }
	public string CustSpaceTypeCode { get; }
	public string CustSpaceTypeText { get; }
	public string TargetZone { get; }

	public ActivationDefinition(string activationId, string activationName, string activationDesc, DateTime activationStart, DateTime activationEnd, string activationType, int isMandatory, int isGenerator, string status, string linkedDoc, string zoneSubzone, string promoCompliance, string popActivation, string quantOfPoi, string sizeOfPoi, string custSpaceTypeCode, string custSpaceTypeText, string targetZone)
	{
		if (activationId == null) throw new ArgumentNullException(nameof(activationId));
		if (activationName == null) throw new ArgumentNullException(nameof(activationName));
		if (activationDesc == null) throw new ArgumentNullException(nameof(activationDesc));
		if (activationType == null) throw new ArgumentNullException(nameof(activationType));
		if (status == null) throw new ArgumentNullException(nameof(status));
		if (linkedDoc == null) throw new ArgumentNullException(nameof(linkedDoc));
		if (zoneSubzone == null) throw new ArgumentNullException(nameof(zoneSubzone));
		if (promoCompliance == null) throw new ArgumentNullException(nameof(promoCompliance));
		if (popActivation == null) throw new ArgumentNullException(nameof(popActivation));
		if (quantOfPoi == null) throw new ArgumentNullException(nameof(quantOfPoi));
		if (sizeOfPoi == null) throw new ArgumentNullException(nameof(sizeOfPoi));
		if (custSpaceTypeCode == null) throw new ArgumentNullException(nameof(custSpaceTypeCode));
		if (custSpaceTypeText == null) throw new ArgumentNullException(nameof(custSpaceTypeText));
		if (targetZone == null) throw new ArgumentNullException(nameof(targetZone));

		this.ActivationId = activationId;
		this.ActivationName = activationName;
		this.ActivationDesc = activationDesc;
		this.ActivationStart = activationStart;
		this.ActivationEnd = activationEnd;
		this.ActivationType = activationType;
		this.IsMandatory = isMandatory;
		this.IsGenerator = isGenerator;
		this.Status = status;
		this.LinkedDoc = linkedDoc;
		this.ZoneSubzone = zoneSubzone;
		this.PromoCompliance = promoCompliance;
		this.PopActivation = popActivation;
		this.QuantOfPoi = quantOfPoi;
		this.SizeOfPoi = sizeOfPoi;
		this.CustSpaceTypeCode = custSpaceTypeCode;
		this.CustSpaceTypeText = custSpaceTypeText;
		this.TargetZone = targetZone;
	}
}

public sealed class ActivationReject
{
	public long Id { get; }
	public long Outlet { get; }
	public string Activation { get; }

	public ActivationReject(long id, long outlet, string activation)
	{
		if (activation == null) throw new ArgumentNullException(nameof(activation));

		this.Id = id;
		this.Outlet = outlet;
		this.Activation = activation;
	}
}

public sealed class ActivationStatu
{
	public string ActivationId { get; }
	public long QuantityOfPoi { get; }
	public long ExecutedPoi { get; }

	public ActivationStatu(string activationId, long quantityOfPoi, long executedPoi)
	{
		if (activationId == null) throw new ArgumentNullException(nameof(activationId));

		this.ActivationId = activationId;
		this.QuantityOfPoi = quantityOfPoi;
		this.ExecutedPoi = executedPoi;
	}
}

public sealed class Activitie
{
	public string Details { get; }
	public DateTime FinishTime { get; }
	public long Id { get; }
	public string Origin { get; }
	public long ProductiveTime { get; }
	public int Sequence { get; }
	public DateTime StartTime { get; }
	public int StatusId { get; }
	public int TypeId { get; }
	public long VisitId { get; }
	public long StatusReasonListId { get; }
	public long ReasonListId { get; }
	public long SubReasonListId { get; }
	public long SurveyId { get; }
	public long StatusListId { get; }
	public DateTime ActualFrom { get; }
	public DateTime ActualTo { get; }
	public string Description { get; }
	public long SapId { get; }
	public long SapReasonListId { get; }
	public long ParentActivityId { get; }
	public string HeaderGuid { get; }
	public int IsGpsTurnedOn { get; }
	public string ActivationId { get; }

	public Activitie(string details, DateTime finishTime, long id, string origin, long productiveTime, int sequence, DateTime startTime, int statusId, int typeId, long visitId, long statusReasonListId, long reasonListId, long subReasonListId, long surveyId, long statusListId, DateTime actualFrom, DateTime actualTo, string description, long sapId, long sapReasonListId, long parentActivityId, string headerGuid, int isGpsTurnedOn, string activationId)
	{
		if (details == null) throw new ArgumentNullException(nameof(details));
		if (origin == null) throw new ArgumentNullException(nameof(origin));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (headerGuid == null) throw new ArgumentNullException(nameof(headerGuid));
		if (activationId == null) throw new ArgumentNullException(nameof(activationId));

		this.Details = details;
		this.FinishTime = finishTime;
		this.Id = id;
		this.Origin = origin;
		this.ProductiveTime = productiveTime;
		this.Sequence = sequence;
		this.StartTime = startTime;
		this.StatusId = statusId;
		this.TypeId = typeId;
		this.VisitId = visitId;
		this.StatusReasonListId = statusReasonListId;
		this.ReasonListId = reasonListId;
		this.SubReasonListId = subReasonListId;
		this.SurveyId = surveyId;
		this.StatusListId = statusListId;
		this.ActualFrom = actualFrom;
		this.ActualTo = actualTo;
		this.Description = description;
		this.SapId = sapId;
		this.SapReasonListId = sapReasonListId;
		this.ParentActivityId = parentActivityId;
		this.HeaderGuid = headerGuid;
		this.IsGpsTurnedOn = isGpsTurnedOn;
		this.ActivationId = activationId;
	}
}

public sealed class ActivityStatuse
{
	public string Description { get; }
	public int Id { get; }
	public string Name { get; }

	public ActivityStatuse(string description, int id, string name)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Description = description;
		this.Id = id;
		this.Name = name;
	}
}

public sealed class ActivityStatusLog
{
	public long ActivityId { get; }
	public string Text { get; }
	public int StatusType { get; }

	public ActivityStatusLog(long activityId, string text, int statusType)
	{
		if (text == null) throw new ArgumentNullException(nameof(text));

		this.ActivityId = activityId;
		this.Text = text;
		this.StatusType = statusType;
	}
}

public sealed class ActivityType
{
	public string Description { get; }
	public int Id { get; }
	public int IsActive { get; }
	public string LocalName { get; }
	public string Name { get; }
	public string SapCode { get; }
	public string Category { get; }

	public ActivityType(string description, int id, int isActive, string localName, string name, string sapCode, string category)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (localName == null) throw new ArgumentNullException(nameof(localName));
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (sapCode == null) throw new ArgumentNullException(nameof(sapCode));
		if (category == null) throw new ArgumentNullException(nameof(category));

		this.Description = description;
		this.Id = id;
		this.IsActive = isActive;
		this.LocalName = localName;
		this.Name = name;
		this.SapCode = sapCode;
		this.Category = category;
	}
}

public sealed class AllArticleGroup
{
	public long ArtGroup { get; }
	public string PrcGroup { get; }
	public string Description { get; }

	public AllArticleGroup(long artGroup, string prcGroup, string description)
	{
		if (prcGroup == null) throw new ArgumentNullException(nameof(prcGroup));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.ArtGroup = artGroup;
		this.PrcGroup = prcGroup;
		this.Description = description;
	}
}

public sealed class ArticlePrice
{
	public long ArticleNumber { get; }
	public string Currency { get; }
	public decimal Price { get; }
	public string PriceGroup { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public ArticlePrice(long articleNumber, string currency, decimal price, string priceGroup, DateTime validFrom, DateTime validTo)
	{
		if (currency == null) throw new ArgumentNullException(nameof(currency));
		if (priceGroup == null) throw new ArgumentNullException(nameof(priceGroup));

		this.ArticleNumber = articleNumber;
		this.Currency = currency;
		this.Price = price;
		this.PriceGroup = priceGroup;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class ArticleSnap
{
	public int ArticlesPerPalette { get; }
	public string ArticleGroup1Bcode { get; }
	public string ArticleGroup1Desc { get; }
	public string ArticleGroup2Bcode { get; }
	public string ArticleGroup2Desc { get; }
	public string ArticleGroup3Bcode { get; }
	public string ArticleGroup3Desc { get; }
	public string ArticleGroup4Bcode { get; }
	public string ArticleGroup4Desc { get; }
	public string ArticleGroup5Bcode { get; }
	public string ArticleGroup5Desc { get; }
	public long ArticleNumber { get; }
	public long ArticleTypeCode { get; }
	public decimal Convfactor1 { get; }
	public decimal Convfactor2 { get; }
	public decimal Cube { get; }
	public string Eancode { get; }
	public string Eansubunitcode { get; }
	public long EmptiesArticleNumber { get; }
	public long EmptiesSubunitArticleNumber { get; }
	public string LongName { get; }
	public long MaterialCategoryCode { get; }
	public decimal Price { get; }
	public int Sequence { get; }
	public string ShortName { get; }
	public long Subunits { get; }
	public DateTime Supprdate { get; }
	public string SuppressedCode { get; }
	public decimal Weight { get; }
	public string ExternalNumber { get; }
	public string BaseUnit { get; }
	public string BaseSubunit { get; }
	public long BaseArticleNumber { get; }
	public string MaterialPricingGroup { get; }

	public ArticleSnap(int articlesPerPalette, string articleGroup1Bcode, string articleGroup1Desc, string articleGroup2Bcode, string articleGroup2Desc, string articleGroup3Bcode, string articleGroup3Desc, string articleGroup4Bcode, string articleGroup4Desc, string articleGroup5Bcode, string articleGroup5Desc, long articleNumber, long articleTypeCode, decimal convfactor1, decimal convfactor2, decimal cube, string eancode, string eansubunitcode, long emptiesArticleNumber, long emptiesSubunitArticleNumber, string longName, long materialCategoryCode, decimal price, int sequence, string shortName, long subunits, DateTime supprdate, string suppressedCode, decimal weight, string externalNumber, string baseUnit, string baseSubunit, long baseArticleNumber, string materialPricingGroup)
	{
		if (articleGroup1Bcode == null) throw new ArgumentNullException(nameof(articleGroup1Bcode));
		if (articleGroup1Desc == null) throw new ArgumentNullException(nameof(articleGroup1Desc));
		if (articleGroup2Bcode == null) throw new ArgumentNullException(nameof(articleGroup2Bcode));
		if (articleGroup2Desc == null) throw new ArgumentNullException(nameof(articleGroup2Desc));
		if (articleGroup3Bcode == null) throw new ArgumentNullException(nameof(articleGroup3Bcode));
		if (articleGroup3Desc == null) throw new ArgumentNullException(nameof(articleGroup3Desc));
		if (articleGroup4Bcode == null) throw new ArgumentNullException(nameof(articleGroup4Bcode));
		if (articleGroup4Desc == null) throw new ArgumentNullException(nameof(articleGroup4Desc));
		if (articleGroup5Bcode == null) throw new ArgumentNullException(nameof(articleGroup5Bcode));
		if (articleGroup5Desc == null) throw new ArgumentNullException(nameof(articleGroup5Desc));
		if (eancode == null) throw new ArgumentNullException(nameof(eancode));
		if (eansubunitcode == null) throw new ArgumentNullException(nameof(eansubunitcode));
		if (longName == null) throw new ArgumentNullException(nameof(longName));
		if (shortName == null) throw new ArgumentNullException(nameof(shortName));
		if (suppressedCode == null) throw new ArgumentNullException(nameof(suppressedCode));
		if (externalNumber == null) throw new ArgumentNullException(nameof(externalNumber));
		if (baseUnit == null) throw new ArgumentNullException(nameof(baseUnit));
		if (baseSubunit == null) throw new ArgumentNullException(nameof(baseSubunit));
		if (materialPricingGroup == null) throw new ArgumentNullException(nameof(materialPricingGroup));

		this.ArticlesPerPalette = articlesPerPalette;
		this.ArticleGroup1Bcode = articleGroup1Bcode;
		this.ArticleGroup1Desc = articleGroup1Desc;
		this.ArticleGroup2Bcode = articleGroup2Bcode;
		this.ArticleGroup2Desc = articleGroup2Desc;
		this.ArticleGroup3Bcode = articleGroup3Bcode;
		this.ArticleGroup3Desc = articleGroup3Desc;
		this.ArticleGroup4Bcode = articleGroup4Bcode;
		this.ArticleGroup4Desc = articleGroup4Desc;
		this.ArticleGroup5Bcode = articleGroup5Bcode;
		this.ArticleGroup5Desc = articleGroup5Desc;
		this.ArticleNumber = articleNumber;
		this.ArticleTypeCode = articleTypeCode;
		this.Convfactor1 = convfactor1;
		this.Convfactor2 = convfactor2;
		this.Cube = cube;
		this.Eancode = eancode;
		this.Eansubunitcode = eansubunitcode;
		this.EmptiesArticleNumber = emptiesArticleNumber;
		this.EmptiesSubunitArticleNumber = emptiesSubunitArticleNumber;
		this.LongName = longName;
		this.MaterialCategoryCode = materialCategoryCode;
		this.Price = price;
		this.Sequence = sequence;
		this.ShortName = shortName;
		this.Subunits = subunits;
		this.Supprdate = supprdate;
		this.SuppressedCode = suppressedCode;
		this.Weight = weight;
		this.ExternalNumber = externalNumber;
		this.BaseUnit = baseUnit;
		this.BaseSubunit = baseSubunit;
		this.BaseArticleNumber = baseArticleNumber;
		this.MaterialPricingGroup = materialPricingGroup;
	}
}

public sealed class ArticleType
{
	public long Code { get; }
	public string Mtart { get; }
	public string Description { get; }

	public ArticleType(long code, string mtart, string description)
	{
		if (mtart == null) throw new ArgumentNullException(nameof(mtart));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Mtart = mtart;
		this.Description = description;
	}
}

public sealed class ArticleUnitConversion
{
	public long ArticleNumber { get; }
	public long Denominator { get; }
	public int Exponent10 { get; }
	public int IsBaseUnit { get; }
	public long Numerator { get; }
	public string Unit { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public ArticleUnitConversion(long articleNumber, long denominator, int exponent10, int isBaseUnit, long numerator, string unit, DateTime validFrom, DateTime validTo)
	{
		if (unit == null) throw new ArgumentNullException(nameof(unit));

		this.ArticleNumber = articleNumber;
		this.Denominator = denominator;
		this.Exponent10 = exponent10;
		this.IsBaseUnit = isBaseUnit;
		this.Numerator = numerator;
		this.Unit = unit;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class ArBankDeposit
{
	public string BankName { get; }
	public decimal CashDepositAmount { get; }
	public decimal ChequeDepositAmount { get; }
	public DateTime DepositDate { get; }
	public string DepositKey { get; }
	public string DepositSlipNumber { get; }
	public long Id { get; }
	public int IsClosed { get; }
	public int NightSafe { get; }
	public decimal OthersAmount { get; }
	public long UserId { get; }

	public ArBankDeposit(string bankName, decimal cashDepositAmount, decimal chequeDepositAmount, DateTime depositDate, string depositKey, string depositSlipNumber, long id, int isClosed, int nightSafe, decimal othersAmount, long userId)
	{
		if (bankName == null) throw new ArgumentNullException(nameof(bankName));
		if (depositKey == null) throw new ArgumentNullException(nameof(depositKey));
		if (depositSlipNumber == null) throw new ArgumentNullException(nameof(depositSlipNumber));

		this.BankName = bankName;
		this.CashDepositAmount = cashDepositAmount;
		this.ChequeDepositAmount = chequeDepositAmount;
		this.DepositDate = depositDate;
		this.DepositKey = depositKey;
		this.DepositSlipNumber = depositSlipNumber;
		this.Id = id;
		this.IsClosed = isClosed;
		this.NightSafe = nightSafe;
		this.OthersAmount = othersAmount;
		this.UserId = userId;
	}
}

public sealed class ArCurrency
{
	public string Description { get; }
	public long Id { get; }
	public int IsDefault { get; }
	public string LocalDescription { get; }
	public string ShortName { get; }

	public ArCurrency(string description, long id, int isDefault, string localDescription, string shortName)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (localDescription == null) throw new ArgumentNullException(nameof(localDescription));
		if (shortName == null) throw new ArgumentNullException(nameof(shortName));

		this.Description = description;
		this.Id = id;
		this.IsDefault = isDefault;
		this.LocalDescription = localDescription;
		this.ShortName = shortName;
	}
}

public sealed class ArInvoice
{
	public DateTime DueDate { get; }
	public long Id { get; }
	public DateTime InvoiceDate { get; }
	public string InvoiceNumber { get; }
	public int IsDeleted { get; }
	public string Note { get; }
	public decimal OpenAmount { get; }
	public long OutletNumber { get; }
	public long PayerNumber { get; }
	public decimal TotalAmount { get; }

	public ArInvoice(DateTime dueDate, long id, DateTime invoiceDate, string invoiceNumber, int isDeleted, string note, decimal openAmount, long outletNumber, long payerNumber, decimal totalAmount)
	{
		if (invoiceNumber == null) throw new ArgumentNullException(nameof(invoiceNumber));
		if (note == null) throw new ArgumentNullException(nameof(note));

		this.DueDate = dueDate;
		this.Id = id;
		this.InvoiceDate = invoiceDate;
		this.InvoiceNumber = invoiceNumber;
		this.IsDeleted = isDeleted;
		this.Note = note;
		this.OpenAmount = openAmount;
		this.OutletNumber = outletNumber;
		this.PayerNumber = payerNumber;
		this.TotalAmount = totalAmount;
	}
}

public sealed class ArPayment
{
	public long ActivityId { get; }
	public long BankDepositId { get; }
	public decimal CashPaidAmount { get; }
	public long CurrencyId { get; }
	public string CustomerReceiptNbr { get; }
	public string DeliveryDocNbr { get; }
	public long Id { get; }
	public string Note { get; }
	public decimal OthersAmount { get; }
	public string OthersDescription { get; }
	public DateTime PaymentDate { get; }
	public DateTime PrintTime { get; }
	public decimal TotalsAmount { get; }

	public ArPayment(long activityId, long bankDepositId, decimal cashPaidAmount, long currencyId, string customerReceiptNbr, string deliveryDocNbr, long id, string note, decimal othersAmount, string othersDescription, DateTime paymentDate, DateTime printTime, decimal totalsAmount)
	{
		if (customerReceiptNbr == null) throw new ArgumentNullException(nameof(customerReceiptNbr));
		if (deliveryDocNbr == null) throw new ArgumentNullException(nameof(deliveryDocNbr));
		if (note == null) throw new ArgumentNullException(nameof(note));
		if (othersDescription == null) throw new ArgumentNullException(nameof(othersDescription));

		this.ActivityId = activityId;
		this.BankDepositId = bankDepositId;
		this.CashPaidAmount = cashPaidAmount;
		this.CurrencyId = currencyId;
		this.CustomerReceiptNbr = customerReceiptNbr;
		this.DeliveryDocNbr = deliveryDocNbr;
		this.Id = id;
		this.Note = note;
		this.OthersAmount = othersAmount;
		this.OthersDescription = othersDescription;
		this.PaymentDate = paymentDate;
		this.PrintTime = printTime;
		this.TotalsAmount = totalsAmount;
	}
}

public sealed class ArPaymentCheque
{
	public string BankName { get; }
	public string ChequeNumber { get; }
	public decimal PaidAmount { get; }
	public long PaymentId { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public ArPaymentCheque(string bankName, string chequeNumber, decimal paidAmount, long paymentId, DateTime validFrom, DateTime validTo)
	{
		if (bankName == null) throw new ArgumentNullException(nameof(bankName));
		if (chequeNumber == null) throw new ArgumentNullException(nameof(chequeNumber));

		this.BankName = bankName;
		this.ChequeNumber = chequeNumber;
		this.PaidAmount = paidAmount;
		this.PaymentId = paymentId;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class ArPaymentDetail
{
	public long BankDepositId { get; }
	public long InvoiceId { get; }
	public int IsPartial { get; }
	public decimal OpenAmount { get; }
	public decimal PaidAmount { get; }
	public long PaymentId { get; }

	public ArPaymentDetail(long bankDepositId, long invoiceId, int isPartial, decimal openAmount, decimal paidAmount, long paymentId)
	{
		this.BankDepositId = bankDepositId;
		this.InvoiceId = invoiceId;
		this.IsPartial = isPartial;
		this.OpenAmount = openAmount;
		this.PaidAmount = paidAmount;
		this.PaymentId = paymentId;
	}
}

public sealed class Assortment
{
	public long Articlenumber { get; }
	public long Outletnumber { get; }
	public long Sequence { get; }

	public Assortment(long articlenumber, long outletnumber, long sequence)
	{
		this.Articlenumber = articlenumber;
		this.Outletnumber = outletnumber;
		this.Sequence = sequence;
	}
}

public sealed class AtpOrderDetail
{
	public long ArticleNumber { get; }
	public long AtpAltProduct { get; }
	public decimal AtpConfirmedQuantity { get; }
	public string AtpItemType { get; }
	public decimal AtpOrderedQuantity { get; }
	public decimal AtpPrice { get; }
	public string AtpPromotion { get; }
	public string AtpQuantityUnits { get; }
	public string AtpStatus { get; }
	public string AtpVendor { get; }
	public long OrderNumber { get; }
	public long SequentialNumber { get; }

	public AtpOrderDetail(long articleNumber, long atpAltProduct, decimal atpConfirmedQuantity, string atpItemType, decimal atpOrderedQuantity, decimal atpPrice, string atpPromotion, string atpQuantityUnits, string atpStatus, string atpVendor, long orderNumber, long sequentialNumber)
	{
		if (atpItemType == null) throw new ArgumentNullException(nameof(atpItemType));
		if (atpPromotion == null) throw new ArgumentNullException(nameof(atpPromotion));
		if (atpQuantityUnits == null) throw new ArgumentNullException(nameof(atpQuantityUnits));
		if (atpStatus == null) throw new ArgumentNullException(nameof(atpStatus));
		if (atpVendor == null) throw new ArgumentNullException(nameof(atpVendor));

		this.ArticleNumber = articleNumber;
		this.AtpAltProduct = atpAltProduct;
		this.AtpConfirmedQuantity = atpConfirmedQuantity;
		this.AtpItemType = atpItemType;
		this.AtpOrderedQuantity = atpOrderedQuantity;
		this.AtpPrice = atpPrice;
		this.AtpPromotion = atpPromotion;
		this.AtpQuantityUnits = atpQuantityUnits;
		this.AtpStatus = atpStatus;
		this.AtpVendor = atpVendor;
		this.OrderNumber = orderNumber;
		this.SequentialNumber = sequentialNumber;
	}
}

public sealed class AtpOrderMessage
{
	public long OrderNumber { get; }
	public long SequentialNumber { get; }
	public string Text { get; }

	public AtpOrderMessage(long orderNumber, long sequentialNumber, string text)
	{
		if (text == null) throw new ArgumentNullException(nameof(text));

		this.OrderNumber = orderNumber;
		this.SequentialNumber = sequentialNumber;
		this.Text = text;
	}
}

public sealed class BeaconLog
{
	public string Guid { get; }
	public DateTime StartedAt { get; }
	public DateTime FinishedAt { get; }
	public string EquipmentNumber { get; }
	public string EddystoneInstance { get; }
	public long OutletNumber { get; }
	public long UserId { get; }
	public string OperationType { get; }
	public long NumberOfEvents { get; }
	public long NumberOfImages { get; }
	public string Status { get; }
	public string ErrorText { get; }
	public long SizeInBytes { get; }
	public string SessionId { get; }
	public decimal SessionSequence { get; }

	public BeaconLog(string guid, DateTime startedAt, DateTime finishedAt, string equipmentNumber, string eddystoneInstance, long outletNumber, long userId, string operationType, long numberOfEvents, long numberOfImages, string status, string errorText, long sizeInBytes, string sessionId, decimal sessionSequence)
	{
		if (guid == null) throw new ArgumentNullException(nameof(guid));
		if (equipmentNumber == null) throw new ArgumentNullException(nameof(equipmentNumber));
		if (eddystoneInstance == null) throw new ArgumentNullException(nameof(eddystoneInstance));
		if (operationType == null) throw new ArgumentNullException(nameof(operationType));
		if (status == null) throw new ArgumentNullException(nameof(status));
		if (errorText == null) throw new ArgumentNullException(nameof(errorText));
		if (sessionId == null) throw new ArgumentNullException(nameof(sessionId));

		this.Guid = guid;
		this.StartedAt = startedAt;
		this.FinishedAt = finishedAt;
		this.EquipmentNumber = equipmentNumber;
		this.EddystoneInstance = eddystoneInstance;
		this.OutletNumber = outletNumber;
		this.UserId = userId;
		this.OperationType = operationType;
		this.NumberOfEvents = numberOfEvents;
		this.NumberOfImages = numberOfImages;
		this.Status = status;
		this.ErrorText = errorText;
		this.SizeInBytes = sizeInBytes;
		this.SessionId = sessionId;
		this.SessionSequence = sessionSequence;
	}
}

public sealed class BusinessType
{
	public long Code { get; }
	public string Kdgrp { get; }
	public string Description { get; }

	public BusinessType(long code, string kdgrp, string description)
	{
		if (kdgrp == null) throw new ArgumentNullException(nameof(kdgrp));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Kdgrp = kdgrp;
		this.Description = description;
	}
}

public sealed class CallingAssignment
{
	public DateTime ActualFromDate { get; }
	public DateTime ActualToDate { get; }
	public long Id { get; }
	public long OutletNumber { get; }
	public long UserId { get; }
	public long UserRouteId { get; }

	public CallingAssignment(DateTime actualFromDate, DateTime actualToDate, long id, long outletNumber, long userId, long userRouteId)
	{
		this.ActualFromDate = actualFromDate;
		this.ActualToDate = actualToDate;
		this.Id = id;
		this.OutletNumber = outletNumber;
		this.UserId = userId;
		this.UserRouteId = userRouteId;
	}
}

public sealed class CallingRoute
{
	public string Client { get; }
	public long Code { get; }
	public string Description { get; }
	public string Langu { get; }
	public string Territory { get; }

	public CallingRoute(string client, long code, string description, string langu, string territory)
	{
		if (client == null) throw new ArgumentNullException(nameof(client));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (langu == null) throw new ArgumentNullException(nameof(langu));
		if (territory == null) throw new ArgumentNullException(nameof(territory));

		this.Client = client;
		this.Code = code;
		this.Description = description;
		this.Langu = langu;
		this.Territory = territory;
	}
}

public sealed class CcafChannel
{
	public string Code { get; }
	public string LocalName { get; }
	public string Name { get; }

	public CcafChannel(string code, string localName, string name)
	{
		if (code == null) throw new ArgumentNullException(nameof(code));
		if (localName == null) throw new ArgumentNullException(nameof(localName));
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Code = code;
		this.LocalName = localName;
		this.Name = name;
	}
}

public sealed class CcafSegment
{
	public int Code { get; }
	public string Name { get; }
	public string LocalName { get; }

	public CcafSegment(int code, string name, string localName)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (localName == null) throw new ArgumentNullException(nameof(localName));

		this.Code = code;
		this.Name = name;
		this.LocalName = localName;
	}
}

public sealed class CcOrder
{
	public DateTime DeliveryDate { get; }
	public long Id { get; }
	public long OutletNumber { get; }
	public DateTime PostingDate { get; }
	public string ProcessType { get; }
	public string SapId { get; }
	public string SapSource { get; }
	public string StatusText { get; }
	public int StatusType { get; }
	public long TypeCode { get; }

	public CcOrder(DateTime deliveryDate, long id, long outletNumber, DateTime postingDate, string processType, string sapId, string sapSource, string statusText, int statusType, long typeCode)
	{
		if (processType == null) throw new ArgumentNullException(nameof(processType));
		if (sapId == null) throw new ArgumentNullException(nameof(sapId));
		if (sapSource == null) throw new ArgumentNullException(nameof(sapSource));
		if (statusText == null) throw new ArgumentNullException(nameof(statusText));

		this.DeliveryDate = deliveryDate;
		this.Id = id;
		this.OutletNumber = outletNumber;
		this.PostingDate = postingDate;
		this.ProcessType = processType;
		this.SapId = sapId;
		this.SapSource = sapSource;
		this.StatusText = statusText;
		this.StatusType = statusType;
		this.TypeCode = typeCode;
	}
}

public sealed class CcOrderDetail
{
	public long ArticleNumber { get; }
	public long CcOrderId { get; }
	public decimal ConfirmedQuantity { get; }
	public string Currency { get; }
	public string ItemCategory { get; }
	public decimal NetValue { get; }
	public decimal Quantity { get; }

	public CcOrderDetail(long articleNumber, long ccOrderId, decimal confirmedQuantity, string currency, string itemCategory, decimal netValue, decimal quantity)
	{
		if (currency == null) throw new ArgumentNullException(nameof(currency));
		if (itemCategory == null) throw new ArgumentNullException(nameof(itemCategory));

		this.ArticleNumber = articleNumber;
		this.CcOrderId = ccOrderId;
		this.ConfirmedQuantity = confirmedQuantity;
		this.Currency = currency;
		this.ItemCategory = itemCategory;
		this.NetValue = netValue;
		this.Quantity = quantity;
	}
}

public sealed class ChannelAssortment
{
	public long ArticleNumber { get; }
	public string CustomerGroup { get; }
	public long Id { get; }
	public int IsLocked { get; }
	public long OutletNumber { get; }
	public string PriceGroup { get; }
	public string SalesOrgAssortmentId { get; }
	public long ScreenPosition { get; }

	public ChannelAssortment(long articleNumber, string customerGroup, long id, int isLocked, long outletNumber, string priceGroup, string salesOrgAssortmentId, long screenPosition)
	{
		if (customerGroup == null) throw new ArgumentNullException(nameof(customerGroup));
		if (priceGroup == null) throw new ArgumentNullException(nameof(priceGroup));
		if (salesOrgAssortmentId == null) throw new ArgumentNullException(nameof(salesOrgAssortmentId));

		this.ArticleNumber = articleNumber;
		this.CustomerGroup = customerGroup;
		this.Id = id;
		this.IsLocked = isLocked;
		this.OutletNumber = outletNumber;
		this.PriceGroup = priceGroup;
		this.SalesOrgAssortmentId = salesOrgAssortmentId;
		this.ScreenPosition = screenPosition;
	}
}

public sealed class ClientSequence
{
	public long MaxValue { get; }
	public long MinValue { get; }
	public long NextValue { get; }
	public decimal PcId { get; }
	public long SequenceId { get; }

	public ClientSequence(long maxValue, long minValue, long nextValue, decimal pcId, long sequenceId)
	{
		this.MaxValue = maxValue;
		this.MinValue = minValue;
		this.NextValue = nextValue;
		this.PcId = pcId;
		this.SequenceId = sequenceId;
	}
}

public sealed class ClientVersion
{
	public string ModuleName { get; }
	public long PcId { get; }
	public string VersionString { get; }

	public ClientVersion(string moduleName, long pcId, string versionString)
	{
		if (moduleName == null) throw new ArgumentNullException(nameof(moduleName));
		if (versionString == null) throw new ArgumentNullException(nameof(versionString));

		this.ModuleName = moduleName;
		this.PcId = pcId;
		this.VersionString = versionString;
	}
}

public sealed class ComplaintDetail
{
	public long ActivityId { get; }
	public long ArticleNumber { get; }
	public decimal Quantity { get; }
	public long QuantitySu { get; }

	public ComplaintDetail(long activityId, long articleNumber, decimal quantity, long quantitySu)
	{
		this.ActivityId = activityId;
		this.ArticleNumber = articleNumber;
		this.Quantity = quantity;
		this.QuantitySu = quantitySu;
	}
}

public sealed class ContactPerson
{
	public string Firstname { get; }
	public string Function { get; }
	public long Id { get; }
	public int Ismanager { get; }
	public string Lastname { get; }
	public string Origin { get; }
	public long OutletNumber { get; }
	public string Status { get; }

	public ContactPerson(string firstname, string function, long id, int ismanager, string lastname, string origin, long outletNumber, string status)
	{
		if (firstname == null) throw new ArgumentNullException(nameof(firstname));
		if (function == null) throw new ArgumentNullException(nameof(function));
		if (lastname == null) throw new ArgumentNullException(nameof(lastname));
		if (origin == null) throw new ArgumentNullException(nameof(origin));
		if (status == null) throw new ArgumentNullException(nameof(status));

		this.Firstname = firstname;
		this.Function = function;
		this.Id = id;
		this.Ismanager = ismanager;
		this.Lastname = lastname;
		this.Origin = origin;
		this.OutletNumber = outletNumber;
		this.Status = status;
	}
}

public sealed class ContractTemplate
{
	public int ActivityTypeId { get; }
	public string Eula { get; }
	public DateTime LastModified { get; }
	public int SignByBd { get; }
	public int SignByCustomer { get; }

	public ContractTemplate(int activityTypeId, string eula, DateTime lastModified, int signByBd, int signByCustomer)
	{
		if (eula == null) throw new ArgumentNullException(nameof(eula));

		this.ActivityTypeId = activityTypeId;
		this.Eula = eula;
		this.LastModified = lastModified;
		this.SignByBd = signByBd;
		this.SignByCustomer = signByCustomer;
	}
}

public sealed class CusPlanningToolCust
{
	public string Cfsmindc { get; }
	public decimal Delta { get; }
	public string Description { get; }
	public int IsSuppressed { get; }
	public string ProcessType { get; }
	public string ReasonCode { get; }
	public string ReasonCode2 { get; }
	public string ReasonCodegrp { get; }
	public int SortIndicator { get; }

	public CusPlanningToolCust(string cfsmindc, decimal delta, string description, int isSuppressed, string processType, string reasonCode, string reasonCode2, string reasonCodegrp, int sortIndicator)
	{
		if (cfsmindc == null) throw new ArgumentNullException(nameof(cfsmindc));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (processType == null) throw new ArgumentNullException(nameof(processType));
		if (reasonCode == null) throw new ArgumentNullException(nameof(reasonCode));
		if (reasonCode2 == null) throw new ArgumentNullException(nameof(reasonCode2));
		if (reasonCodegrp == null) throw new ArgumentNullException(nameof(reasonCodegrp));

		this.Cfsmindc = cfsmindc;
		this.Delta = delta;
		this.Description = description;
		this.IsSuppressed = isSuppressed;
		this.ProcessType = processType;
		this.ReasonCode = reasonCode;
		this.ReasonCode2 = reasonCode2;
		this.ReasonCodegrp = reasonCodegrp;
		this.SortIndicator = sortIndicator;
	}
}

public sealed class CusPopAssortment
{
	public string SalesOrgAssortmentId { get; }

	public CusPopAssortment(string salesOrgAssortmentId)
	{
		if (salesOrgAssortmentId == null) throw new ArgumentNullException(nameof(salesOrgAssortmentId));

		this.SalesOrgAssortmentId = salesOrgAssortmentId;
	}
}

public sealed class CusSurvey
{
	public string AnswerSummary { get; }
	public string AnswerTotal { get; }
	public string CopyLastValues { get; }
	public string IdealOutlet { get; }
	public string Must { get; }
	public string Percentage { get; }
	public string QuestionSummary { get; }
	public string QuestionTotal { get; }
	public string Scoring { get; }
	public long SurveyId { get; }
	public string TransactionType { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public CusSurvey(string answerSummary, string answerTotal, string copyLastValues, string idealOutlet, string must, string percentage, string questionSummary, string questionTotal, string scoring, long surveyId, string transactionType, DateTime validFrom, DateTime validTo)
	{
		if (answerSummary == null) throw new ArgumentNullException(nameof(answerSummary));
		if (answerTotal == null) throw new ArgumentNullException(nameof(answerTotal));
		if (copyLastValues == null) throw new ArgumentNullException(nameof(copyLastValues));
		if (idealOutlet == null) throw new ArgumentNullException(nameof(idealOutlet));
		if (must == null) throw new ArgumentNullException(nameof(must));
		if (percentage == null) throw new ArgumentNullException(nameof(percentage));
		if (questionSummary == null) throw new ArgumentNullException(nameof(questionSummary));
		if (questionTotal == null) throw new ArgumentNullException(nameof(questionTotal));
		if (scoring == null) throw new ArgumentNullException(nameof(scoring));
		if (transactionType == null) throw new ArgumentNullException(nameof(transactionType));

		this.AnswerSummary = answerSummary;
		this.AnswerTotal = answerTotal;
		this.CopyLastValues = copyLastValues;
		this.IdealOutlet = idealOutlet;
		this.Must = must;
		this.Percentage = percentage;
		this.QuestionSummary = questionSummary;
		this.QuestionTotal = questionTotal;
		this.Scoring = scoring;
		this.SurveyId = surveyId;
		this.TransactionType = transactionType;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class CusSurveysHierNode
{
	public string NodeGuid { get; }
	public long SurveyId { get; }

	public CusSurveysHierNode(string nodeGuid, long surveyId)
	{
		if (nodeGuid == null) throw new ArgumentNullException(nameof(nodeGuid));

		this.NodeGuid = nodeGuid;
		this.SurveyId = surveyId;
	}
}

public sealed class DeliveryHistDetail
{
	public long ArticleNumber { get; }
	public long Delivery1 { get; }
	public long Delivery2 { get; }
	public long Delivery3 { get; }
	public long Delivery4 { get; }
	public long Delivery5 { get; }
	public long Delivery6 { get; }
	public long OutletNumber { get; }

	public DeliveryHistDetail(long articleNumber, long delivery1, long delivery2, long delivery3, long delivery4, long delivery5, long delivery6, long outletNumber)
	{
		this.ArticleNumber = articleNumber;
		this.Delivery1 = delivery1;
		this.Delivery2 = delivery2;
		this.Delivery3 = delivery3;
		this.Delivery4 = delivery4;
		this.Delivery5 = delivery5;
		this.Delivery6 = delivery6;
		this.OutletNumber = outletNumber;
	}
}

public sealed class DeliveryHistHeader
{
	public DateTime DeliveryDate1 { get; }
	public DateTime DeliveryDate2 { get; }
	public DateTime DeliveryDate3 { get; }
	public DateTime DeliveryDate4 { get; }
	public DateTime DeliveryDate5 { get; }
	public DateTime DeliveryDate6 { get; }
	public long OutletNumber { get; }

	public DeliveryHistHeader(DateTime deliveryDate1, DateTime deliveryDate2, DateTime deliveryDate3, DateTime deliveryDate4, DateTime deliveryDate5, DateTime deliveryDate6, long outletNumber)
	{
		this.DeliveryDate1 = deliveryDate1;
		this.DeliveryDate2 = deliveryDate2;
		this.DeliveryDate3 = deliveryDate3;
		this.DeliveryDate4 = deliveryDate4;
		this.DeliveryDate5 = deliveryDate5;
		this.DeliveryDate6 = deliveryDate6;
		this.OutletNumber = outletNumber;
	}
}

public sealed class DeliveryLeadTime
{
	public long Code { get; }
	public string Attrib5 { get; }
	public string Description { get; }

	public DeliveryLeadTime(long code, string attrib5, string description)
	{
		if (attrib5 == null) throw new ArgumentNullException(nameof(attrib5));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Attrib5 = attrib5;
		this.Description = description;
	}
}

public sealed class DeliveryLocation
{
	public long Code { get; }
	public string Werks { get; }
	public string Description { get; }
	public int IsSuppressed { get; }
	public string Name1 { get; }
	public string Name2 { get; }
	public string Address { get; }

	public DeliveryLocation(long code, string werks, string description, int isSuppressed, string name1, string name2, string address)
	{
		if (werks == null) throw new ArgumentNullException(nameof(werks));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (name1 == null) throw new ArgumentNullException(nameof(name1));
		if (name2 == null) throw new ArgumentNullException(nameof(name2));
		if (address == null) throw new ArgumentNullException(nameof(address));

		this.Code = code;
		this.Werks = werks;
		this.Description = description;
		this.IsSuppressed = isSuppressed;
		this.Name1 = name1;
		this.Name2 = name2;
		this.Address = address;
	}
}

public sealed class DeliveryTransaction
{
	public string BasisCode { get; }
	public string BasisLocation { get; }
	public string BasisSubkey { get; }
	public long Code { get; }
	public string Description { get; }
	public int IsSuppressed { get; }
	public string Origin { get; }
	public int Sequence { get; }

	public DeliveryTransaction(string basisCode, string basisLocation, string basisSubkey, long code, string description, int isSuppressed, string origin, int sequence)
	{
		if (basisCode == null) throw new ArgumentNullException(nameof(basisCode));
		if (basisLocation == null) throw new ArgumentNullException(nameof(basisLocation));
		if (basisSubkey == null) throw new ArgumentNullException(nameof(basisSubkey));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (origin == null) throw new ArgumentNullException(nameof(origin));

		this.BasisCode = basisCode;
		this.BasisLocation = basisLocation;
		this.BasisSubkey = basisSubkey;
		this.Code = code;
		this.Description = description;
		this.IsSuppressed = isSuppressed;
		this.Origin = origin;
		this.Sequence = sequence;
	}
}

public sealed class DeliveryType
{
	public long Code { get; }
	public string Attrib4 { get; }
	public string Description { get; }

	public DeliveryType(long code, string attrib4, string description)
	{
		if (attrib4 == null) throw new ArgumentNullException(nameof(attrib4));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Attrib4 = attrib4;
		this.Description = description;
	}
}

public sealed class Equipment
{
	public string EquipmentNumber { get; }
	public long EquipmentTypeCode { get; }
	public int IsSuppressed { get; }
	public long OutletNumber { get; }
	public string RentContractNumber { get; }
	public string SerialNumber { get; }
	public string AssetClass { get; }
	public int IbeaconMajor { get; }
	public int IbeaconMinor { get; }
	public string IbeaconUuid { get; }
	public string EddystoneNamespace { get; }
	public string EddystoneInstance { get; }
	public decimal DoorOpensCount { get; }
	public DateTime DownloadDate { get; }
	public decimal RedCoolerQuality { get; }
	public string Branding { get; }
	public string AvTraffDoor { get; }
	public decimal MonthlyAvTemp { get; }
	public decimal MonthlyAvActiveTemp { get; }
	public string AvTrafLightTemp { get; }
	public DateTime TrafLightDownloadDate { get; }
	public string SmartType { get; }
	public string BeaconMacAddress { get; }
	public string BeaconPassword { get; }

	public Equipment(string equipmentNumber, long equipmentTypeCode, int isSuppressed, long outletNumber, string rentContractNumber, string serialNumber, string assetClass, int ibeaconMajor, int ibeaconMinor, string ibeaconUuid, string eddystoneNamespace, string eddystoneInstance, decimal doorOpensCount, DateTime downloadDate, decimal redCoolerQuality, string branding, string avTraffDoor, decimal monthlyAvTemp, decimal monthlyAvActiveTemp, string avTrafLightTemp, DateTime trafLightDownloadDate, string smartType, string beaconMacAddress, string beaconPassword)
	{
		if (equipmentNumber == null) throw new ArgumentNullException(nameof(equipmentNumber));
		if (rentContractNumber == null) throw new ArgumentNullException(nameof(rentContractNumber));
		if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));
		if (assetClass == null) throw new ArgumentNullException(nameof(assetClass));
		if (ibeaconUuid == null) throw new ArgumentNullException(nameof(ibeaconUuid));
		if (eddystoneNamespace == null) throw new ArgumentNullException(nameof(eddystoneNamespace));
		if (eddystoneInstance == null) throw new ArgumentNullException(nameof(eddystoneInstance));
		if (branding == null) throw new ArgumentNullException(nameof(branding));
		if (avTraffDoor == null) throw new ArgumentNullException(nameof(avTraffDoor));
		if (avTrafLightTemp == null) throw new ArgumentNullException(nameof(avTrafLightTemp));
		if (smartType == null) throw new ArgumentNullException(nameof(smartType));
		if (beaconMacAddress == null) throw new ArgumentNullException(nameof(beaconMacAddress));
		if (beaconPassword == null) throw new ArgumentNullException(nameof(beaconPassword));

		this.EquipmentNumber = equipmentNumber;
		this.EquipmentTypeCode = equipmentTypeCode;
		this.IsSuppressed = isSuppressed;
		this.OutletNumber = outletNumber;
		this.RentContractNumber = rentContractNumber;
		this.SerialNumber = serialNumber;
		this.AssetClass = assetClass;
		this.IbeaconMajor = ibeaconMajor;
		this.IbeaconMinor = ibeaconMinor;
		this.IbeaconUuid = ibeaconUuid;
		this.EddystoneNamespace = eddystoneNamespace;
		this.EddystoneInstance = eddystoneInstance;
		this.DoorOpensCount = doorOpensCount;
		this.DownloadDate = downloadDate;
		this.RedCoolerQuality = redCoolerQuality;
		this.Branding = branding;
		this.AvTraffDoor = avTraffDoor;
		this.MonthlyAvTemp = monthlyAvTemp;
		this.MonthlyAvActiveTemp = monthlyAvActiveTemp;
		this.AvTrafLightTemp = avTrafLightTemp;
		this.TrafLightDownloadDate = trafLightDownloadDate;
		this.SmartType = smartType;
		this.BeaconMacAddress = beaconMacAddress;
		this.BeaconPassword = beaconPassword;
	}
}

public sealed class EquipmentActivity
{
	public long ActivityId { get; }
	public long EquipmentModelCode { get; }
	public long EquipmentTypeCode { get; }
	public string EquipmentNumber { get; }
	public long NewOutletNumber { get; }
	public long StatusListId { get; }

	public EquipmentActivity(long activityId, long equipmentModelCode, long equipmentTypeCode, string equipmentNumber, long newOutletNumber, long statusListId)
	{
		if (equipmentNumber == null) throw new ArgumentNullException(nameof(equipmentNumber));

		this.ActivityId = activityId;
		this.EquipmentModelCode = equipmentModelCode;
		this.EquipmentTypeCode = equipmentTypeCode;
		this.EquipmentNumber = equipmentNumber;
		this.NewOutletNumber = newOutletNumber;
		this.StatusListId = statusListId;
	}
}

public sealed class EquipmentCheck
{
	public long ActivityId { get; }
	public string AdminComments { get; }
	public int Available { get; }
	public string BarcodeCutting { get; }
	public long CdeStatusId { get; }
	public string Comments { get; }
	public int EquipmentLoad { get; }
	public string EquipmentNumber { get; }
	public long EqTagStatusId { get; }
	public DateTime LastChecked { get; }
	public DateTime LastScanned { get; }
	public long LocationStatusId { get; }
	public string Model { get; }
	public long OutletNumber { get; }
	public long PercentStatusId { get; }
	public string SerialNumber { get; }
	public string Source { get; }
	public string Status { get; }
	public string TbResolved { get; }
	public long VisitId { get; }
	public long LastCheckedByUserId { get; }
	public int IbeaconMajor { get; }
	public int IbeaconMinor { get; }
	public string IbeaconUuid { get; }
	public string EddystoneNamespace { get; }
	public string EddystoneInstance { get; }
	public decimal DoorOpensCount { get; }
	public DateTime DownloadDate { get; }
	public decimal RedCoolerQuality { get; }
	public string Branding { get; }
	public string AvTraffDoor { get; }
	public decimal MonthlyAvTemp { get; }
	public decimal MonthlyAvActiveTemp { get; }
	public string AvTrafLightTemp { get; }
	public DateTime TrafLightDownloadDate { get; }
	public string SmartType { get; }
	public string BeaconMacAddress { get; }
	public string BeaconPassword { get; }

	public EquipmentCheck(long activityId, string adminComments, int available, string barcodeCutting, long cdeStatusId, string comments, int equipmentLoad, string equipmentNumber, long eqTagStatusId, DateTime lastChecked, DateTime lastScanned, long locationStatusId, string model, long outletNumber, long percentStatusId, string serialNumber, string source, string status, string tbResolved, long visitId, long lastCheckedByUserId, int ibeaconMajor, int ibeaconMinor, string ibeaconUuid, string eddystoneNamespace, string eddystoneInstance, decimal doorOpensCount, DateTime downloadDate, decimal redCoolerQuality, string branding, string avTraffDoor, decimal monthlyAvTemp, decimal monthlyAvActiveTemp, string avTrafLightTemp, DateTime trafLightDownloadDate, string smartType, string beaconMacAddress, string beaconPassword)
	{
		if (adminComments == null) throw new ArgumentNullException(nameof(adminComments));
		if (barcodeCutting == null) throw new ArgumentNullException(nameof(barcodeCutting));
		if (comments == null) throw new ArgumentNullException(nameof(comments));
		if (equipmentNumber == null) throw new ArgumentNullException(nameof(equipmentNumber));
		if (model == null) throw new ArgumentNullException(nameof(model));
		if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));
		if (source == null) throw new ArgumentNullException(nameof(source));
		if (status == null) throw new ArgumentNullException(nameof(status));
		if (tbResolved == null) throw new ArgumentNullException(nameof(tbResolved));
		if (ibeaconUuid == null) throw new ArgumentNullException(nameof(ibeaconUuid));
		if (eddystoneNamespace == null) throw new ArgumentNullException(nameof(eddystoneNamespace));
		if (eddystoneInstance == null) throw new ArgumentNullException(nameof(eddystoneInstance));
		if (branding == null) throw new ArgumentNullException(nameof(branding));
		if (avTraffDoor == null) throw new ArgumentNullException(nameof(avTraffDoor));
		if (avTrafLightTemp == null) throw new ArgumentNullException(nameof(avTrafLightTemp));
		if (smartType == null) throw new ArgumentNullException(nameof(smartType));
		if (beaconMacAddress == null) throw new ArgumentNullException(nameof(beaconMacAddress));
		if (beaconPassword == null) throw new ArgumentNullException(nameof(beaconPassword));

		this.ActivityId = activityId;
		this.AdminComments = adminComments;
		this.Available = available;
		this.BarcodeCutting = barcodeCutting;
		this.CdeStatusId = cdeStatusId;
		this.Comments = comments;
		this.EquipmentLoad = equipmentLoad;
		this.EquipmentNumber = equipmentNumber;
		this.EqTagStatusId = eqTagStatusId;
		this.LastChecked = lastChecked;
		this.LastScanned = lastScanned;
		this.LocationStatusId = locationStatusId;
		this.Model = model;
		this.OutletNumber = outletNumber;
		this.PercentStatusId = percentStatusId;
		this.SerialNumber = serialNumber;
		this.Source = source;
		this.Status = status;
		this.TbResolved = tbResolved;
		this.VisitId = visitId;
		this.LastCheckedByUserId = lastCheckedByUserId;
		this.IbeaconMajor = ibeaconMajor;
		this.IbeaconMinor = ibeaconMinor;
		this.IbeaconUuid = ibeaconUuid;
		this.EddystoneNamespace = eddystoneNamespace;
		this.EddystoneInstance = eddystoneInstance;
		this.DoorOpensCount = doorOpensCount;
		this.DownloadDate = downloadDate;
		this.RedCoolerQuality = redCoolerQuality;
		this.Branding = branding;
		this.AvTraffDoor = avTraffDoor;
		this.MonthlyAvTemp = monthlyAvTemp;
		this.MonthlyAvActiveTemp = monthlyAvActiveTemp;
		this.AvTrafLightTemp = avTrafLightTemp;
		this.TrafLightDownloadDate = trafLightDownloadDate;
		this.SmartType = smartType;
		this.BeaconMacAddress = beaconMacAddress;
		this.BeaconPassword = beaconPassword;
	}
}

public sealed class EquipmentMatrix
{
	public string CcafChannelCode { get; }
	public int CcafSegmentCode { get; }
	public string HierarchyLevel { get; }
	public long Id { get; }
	public decimal OutletClusterAttributeCode { get; }
	public decimal OutletClusterHierarchyNode { get; }
	public string RedPictureOfSuccessFormat { get; }
	public long TradeChannelCode { get; }

	public EquipmentMatrix(string ccafChannelCode, int ccafSegmentCode, string hierarchyLevel, long id, decimal outletClusterAttributeCode, decimal outletClusterHierarchyNode, string redPictureOfSuccessFormat, long tradeChannelCode)
	{
		if (ccafChannelCode == null) throw new ArgumentNullException(nameof(ccafChannelCode));
		if (hierarchyLevel == null) throw new ArgumentNullException(nameof(hierarchyLevel));
		if (redPictureOfSuccessFormat == null) throw new ArgumentNullException(nameof(redPictureOfSuccessFormat));

		this.CcafChannelCode = ccafChannelCode;
		this.CcafSegmentCode = ccafSegmentCode;
		this.HierarchyLevel = hierarchyLevel;
		this.Id = id;
		this.OutletClusterAttributeCode = outletClusterAttributeCode;
		this.OutletClusterHierarchyNode = outletClusterHierarchyNode;
		this.RedPictureOfSuccessFormat = redPictureOfSuccessFormat;
		this.TradeChannelCode = tradeChannelCode;
	}
}

public sealed class EquipmentMatrixType
{
	public long EquipmentMatrixId { get; }
	public long EquipmentTypeCode { get; }

	public EquipmentMatrixType(long equipmentMatrixId, long equipmentTypeCode)
	{
		this.EquipmentMatrixId = equipmentMatrixId;
		this.EquipmentTypeCode = equipmentTypeCode;
	}
}

public sealed class EquipmentMessage
{
	public long Id { get; }
	public string Message { get; }
	public string Origin { get; }
	public string Status { get; }

	public EquipmentMessage(long id, string message, string origin, string status)
	{
		if (message == null) throw new ArgumentNullException(nameof(message));
		if (origin == null) throw new ArgumentNullException(nameof(origin));
		if (status == null) throw new ArgumentNullException(nameof(status));

		this.Id = id;
		this.Message = message;
		this.Origin = origin;
		this.Status = status;
	}
}

public sealed class EquipmentType
{
	public long Code { get; }
	public string Description { get; }
	public int IsSuppressed { get; }
	public string Note { get; }
	public string Branding { get; }
	public long NumberOfDoors { get; }
	public long Width { get; }
	public long Height { get; }
	public long Depth { get; }
	public decimal Power { get; }
	public string SapCode { get; }

	public EquipmentType(long code, string description, int isSuppressed, string note, string branding, long numberOfDoors, long width, long height, long depth, decimal power, string sapCode)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (note == null) throw new ArgumentNullException(nameof(note));
		if (branding == null) throw new ArgumentNullException(nameof(branding));
		if (sapCode == null) throw new ArgumentNullException(nameof(sapCode));

		this.Code = code;
		this.Description = description;
		this.IsSuppressed = isSuppressed;
		this.Note = note;
		this.Branding = branding;
		this.NumberOfDoors = numberOfDoors;
		this.Width = width;
		this.Height = height;
		this.Depth = depth;
		this.Power = power;
		this.SapCode = sapCode;
	}
}

public sealed class EquipmentTypeImage
{
	public long EquipmentTypeCode { get; }
	public long Id { get; }
	public byte[] Image { get; }

	public EquipmentTypeImage(long equipmentTypeCode, long id, byte[] image)
	{
		if (image == null) throw new ArgumentNullException(nameof(image));

		this.EquipmentTypeCode = equipmentTypeCode;
		this.Id = id;
		this.Image = image;
	}
}

public sealed class GpsData
{
	public long ActivityId { get; }
	public decimal DeviceId { get; }
	public long Id { get; }
	public decimal Latitude { get; }
	public decimal Longitude { get; }
	public long RilCellId { get; }
	public long RilLocationAreaCode { get; }
	public long RilMobileCountryCode { get; }
	public long RilMobileNetworkCode { get; }
	public DateTime TimeStamp { get; }
	public long UserId { get; }

	public GpsData(long activityId, decimal deviceId, long id, decimal latitude, decimal longitude, long rilCellId, long rilLocationAreaCode, long rilMobileCountryCode, long rilMobileNetworkCode, DateTime timeStamp, long userId)
	{
		this.ActivityId = activityId;
		this.DeviceId = deviceId;
		this.Id = id;
		this.Latitude = latitude;
		this.Longitude = longitude;
		this.RilCellId = rilCellId;
		this.RilLocationAreaCode = rilLocationAreaCode;
		this.RilMobileCountryCode = rilMobileCountryCode;
		this.RilMobileNetworkCode = rilMobileNetworkCode;
		this.TimeStamp = timeStamp;
		this.UserId = userId;
	}
}

public sealed class Holiday
{
	public DateTime CalendarDate { get; }
	public string SelectorKey { get; }

	public Holiday(DateTime calendarDate, string selectorKey)
	{
		if (selectorKey == null) throw new ArgumentNullException(nameof(selectorKey));

		this.CalendarDate = calendarDate;
		this.SelectorKey = selectorKey;
	}
}

public sealed class InventoryDetail
{
	public long ArticleNumber { get; }
	public long InventoryHeaderId { get; }
	public int StockBack { get; }
	public int StockBackSu { get; }
	public int StockEquipment { get; }
	public int StockEquipmentSu { get; }
	public int StockShelf { get; }
	public int StockShelfSu { get; }
	public int StockTotal { get; }
	public int StockTotalSu { get; }

	public InventoryDetail(long articleNumber, long inventoryHeaderId, int stockBack, int stockBackSu, int stockEquipment, int stockEquipmentSu, int stockShelf, int stockShelfSu, int stockTotal, int stockTotalSu)
	{
		this.ArticleNumber = articleNumber;
		this.InventoryHeaderId = inventoryHeaderId;
		this.StockBack = stockBack;
		this.StockBackSu = stockBackSu;
		this.StockEquipment = stockEquipment;
		this.StockEquipmentSu = stockEquipmentSu;
		this.StockShelf = stockShelf;
		this.StockShelfSu = stockShelfSu;
		this.StockTotal = stockTotal;
		this.StockTotalSu = stockTotalSu;
	}
}

public sealed class InventoryHeader
{
	public long ActivityId { get; }
	public DateTime CreatedAt { get; }
	public long Id { get; }
	public DateTime LastSavedAt { get; }
	public long VisitId { get; }

	public InventoryHeader(long activityId, DateTime createdAt, long id, DateTime lastSavedAt, long visitId)
	{
		this.ActivityId = activityId;
		this.CreatedAt = createdAt;
		this.Id = id;
		this.LastSavedAt = lastSavedAt;
		this.VisitId = visitId;
	}
}

public sealed class LinkedWholesaler
{
	public string GridNumber { get; }
	public int IsDefault { get; }
	public long OutletNumber { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }
	public long WholesalerId { get; }

	public LinkedWholesaler(string gridNumber, int isDefault, long outletNumber, DateTime validFrom, DateTime validTo, long wholesalerId)
	{
		if (gridNumber == null) throw new ArgumentNullException(nameof(gridNumber));

		this.GridNumber = gridNumber;
		this.IsDefault = isDefault;
		this.OutletNumber = outletNumber;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
		this.WholesalerId = wholesalerId;
	}
}

public sealed class MaterialCategorie
{
	public long Code { get; }
	public string Prodh { get; }
	public string Description { get; }

	public MaterialCategorie(long code, string prodh, string description)
	{
		if (prodh == null) throw new ArgumentNullException(nameof(prodh));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Prodh = prodh;
		this.Description = description;
	}
}

public sealed class MeasureDomain
{
	public long Id { get; }
	public int IsSuppressed { get; }
	public long ValueType { get; }

	public MeasureDomain(long id, int isSuppressed, long valueType)
	{
		this.Id = id;
		this.IsSuppressed = isSuppressed;
		this.ValueType = valueType;
	}
}

public sealed class MeasureDomainLov
{
	public string Description { get; }
	public long DomainId { get; }
	public long No { get; }
	public long Weigth { get; }
	public int NotApplicable { get; }
	public string Value { get; }

	public MeasureDomainLov(string description, long domainId, long no, long weigth, int notApplicable, string value)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (value == null) throw new ArgumentNullException(nameof(value));

		this.Description = description;
		this.DomainId = domainId;
		this.No = no;
		this.Weigth = weigth;
		this.NotApplicable = notApplicable;
		this.Value = value;
	}
}

public sealed class MeasureNode
{
	public long Id { get; }
	public long SurveyId { get; }
	public int IsRequired { get; }
	public long FirstDomainId { get; }
	public long OwnerId { get; }
	public string Description { get; }
	public string DefaultValue { get; }
	public int CanEdit { get; }
	public int Suppressed { get; }
	public long Sequence { get; }
	public long TreeLevel { get; }
	public decimal Score { get; }
	public string LongDescription { get; }
	public decimal Maxval { get; }
	public decimal Minval { get; }
	public string MarketAttribute { get; }
	public decimal TargetScore { get; }
	public string Type { get; }
	public long RelatedNode { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }
	public decimal Weight { get; }
	public string Guid { get; }
	public string PfpRel { get; }

	public MeasureNode(long id, long surveyId, int isRequired, long firstDomainId, long ownerId, string description, string defaultValue, int canEdit, int suppressed, long sequence, long treeLevel, decimal score, string longDescription, decimal maxval, decimal minval, string marketAttribute, decimal targetScore, string type, long relatedNode, DateTime validFrom, DateTime validTo, decimal weight, string guid, string pfpRel)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (defaultValue == null) throw new ArgumentNullException(nameof(defaultValue));
		if (longDescription == null) throw new ArgumentNullException(nameof(longDescription));
		if (marketAttribute == null) throw new ArgumentNullException(nameof(marketAttribute));
		if (type == null) throw new ArgumentNullException(nameof(type));
		if (guid == null) throw new ArgumentNullException(nameof(guid));
		if (pfpRel == null) throw new ArgumentNullException(nameof(pfpRel));

		this.Id = id;
		this.SurveyId = surveyId;
		this.IsRequired = isRequired;
		this.FirstDomainId = firstDomainId;
		this.OwnerId = ownerId;
		this.Description = description;
		this.DefaultValue = defaultValue;
		this.CanEdit = canEdit;
		this.Suppressed = suppressed;
		this.Sequence = sequence;
		this.TreeLevel = treeLevel;
		this.Score = score;
		this.LongDescription = longDescription;
		this.Maxval = maxval;
		this.Minval = minval;
		this.MarketAttribute = marketAttribute;
		this.TargetScore = targetScore;
		this.Type = type;
		this.RelatedNode = relatedNode;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
		this.Weight = weight;
		this.Guid = guid;
		this.PfpRel = pfpRel;
	}
}

public sealed class MeasureValue
{
	public long ActivityId { get; }
	public long NodeId { get; }
	public long SurveyId { get; }
	public string Value { get; }
	public long VisitId { get; }

	public MeasureValue(long activityId, long nodeId, long surveyId, string value, long visitId)
	{
		if (value == null) throw new ArgumentNullException(nameof(value));

		this.ActivityId = activityId;
		this.NodeId = nodeId;
		this.SurveyId = surveyId;
		this.Value = value;
		this.VisitId = visitId;
	}
}

public sealed class OrderDateOutletCpl
{
	public string Cpl { get; }

	public OrderDateOutletCpl(string cpl)
	{
		if (cpl == null) throw new ArgumentNullException(nameof(cpl));

		this.Cpl = cpl;
	}
}

public sealed class OrderDetail
{
	public long AdjustmentNumber { get; }
	public decimal AdjustmentQuantity { get; }
	public long AdjustmentQuantitySu { get; }
	public string AdjustmentType { get; }
	public long ArticleNumber { get; }
	public long OrderHeaderId { get; }
	public decimal PreviousConsumption { get; }
	public long PreviousConsumptionSu { get; }
	public decimal Quantity { get; }
	public long QuantitySu { get; }
	public decimal SuggestedQuantity { get; }
	public decimal SuggestedQuantitySu { get; }

	public OrderDetail(long adjustmentNumber, decimal adjustmentQuantity, long adjustmentQuantitySu, string adjustmentType, long articleNumber, long orderHeaderId, decimal previousConsumption, long previousConsumptionSu, decimal quantity, long quantitySu, decimal suggestedQuantity, decimal suggestedQuantitySu)
	{
		if (adjustmentType == null) throw new ArgumentNullException(nameof(adjustmentType));

		this.AdjustmentNumber = adjustmentNumber;
		this.AdjustmentQuantity = adjustmentQuantity;
		this.AdjustmentQuantitySu = adjustmentQuantitySu;
		this.AdjustmentType = adjustmentType;
		this.ArticleNumber = articleNumber;
		this.OrderHeaderId = orderHeaderId;
		this.PreviousConsumption = previousConsumption;
		this.PreviousConsumptionSu = previousConsumptionSu;
		this.Quantity = quantity;
		this.QuantitySu = quantitySu;
		this.SuggestedQuantity = suggestedQuantity;
		this.SuggestedQuantitySu = suggestedQuantitySu;
	}
}

public sealed class OrderDetailPromotion
{
	public long OrderedArticleNumber { get; }
	public long OrderNumber { get; }
	public long PromotedArticleNumber { get; }
	public string PromotedFreeFlag { get; }
	public decimal PromotedQuantity { get; }
	public decimal PromotedQuantitySu { get; }
	public string PromotionGuid { get; }

	public OrderDetailPromotion(long orderedArticleNumber, long orderNumber, long promotedArticleNumber, string promotedFreeFlag, decimal promotedQuantity, decimal promotedQuantitySu, string promotionGuid)
	{
		if (promotedFreeFlag == null) throw new ArgumentNullException(nameof(promotedFreeFlag));
		if (promotionGuid == null) throw new ArgumentNullException(nameof(promotionGuid));

		this.OrderedArticleNumber = orderedArticleNumber;
		this.OrderNumber = orderNumber;
		this.PromotedArticleNumber = promotedArticleNumber;
		this.PromotedFreeFlag = promotedFreeFlag;
		this.PromotedQuantity = promotedQuantity;
		this.PromotedQuantitySu = promotedQuantitySu;
		this.PromotionGuid = promotionGuid;
	}
}

public sealed class OrderFreeProduct
{
	public long ArticleNumber { get; }
	public long OrderNumber { get; }
	public long Quantity { get; }
	public string ReasonCode { get; }

	public OrderFreeProduct(long articleNumber, long orderNumber, long quantity, string reasonCode)
	{
		if (reasonCode == null) throw new ArgumentNullException(nameof(reasonCode));

		this.ArticleNumber = articleNumber;
		this.OrderNumber = orderNumber;
		this.Quantity = quantity;
		this.ReasonCode = reasonCode;
	}
}

public sealed class OrderHeader
{
	public long ActivityId { get; }
	public long AddressNumber { get; }
	public decimal AtpDeposit { get; }
	public decimal AtpPromoDiscount { get; }
	public decimal AtpGrossTotal { get; }
	public decimal AtpTaxTotal { get; }
	public DateTime AtpTimestamp { get; }
	public decimal AtpTotal { get; }
	public decimal ConvertedQuantity { get; }
	public DateTime CreatedAt { get; }
	public string CustomerReference { get; }
	public DateTime DeliveryDate { get; }
	public long DeliveryLocationCode { get; }
	public long DeliveryTransactionCode { get; }
	public string ExternalReferenceNumber { get; }
	public string GridNumber { get; }
	public int HasEmpties { get; }
	public DateTime LastSavedAt { get; }
	public DateTime OrderDate { get; }
	public long OrderNumber { get; }
	public int OrderStatus { get; }
	public long OrderTypeCode { get; }
	public long PopArticleGroup { get; }
	public decimal PricelistBasedAmount { get; }
	public long PriceListCode { get; }
	public string PromotionCodeGroup { get; }
	public string PromotionReason { get; }
	public decimal TotalCases { get; }
	public decimal TotalCasesConv { get; }
	public decimal TotalCasesConvAmount { get; }
	public string TransactionDescription { get; }
	public int Unproductive { get; }
	public long VisitId { get; }
	public long WholesalerId { get; }
	public long ToOutletNumber { get; }
	public long ReasonListId { get; }
	public long VendorListId { get; }
	public long PaymentTermsListId { get; }

	public OrderHeader(long activityId, long addressNumber, decimal atpDeposit, decimal atpPromoDiscount, decimal atpGrossTotal, decimal atpTaxTotal, DateTime atpTimestamp, decimal atpTotal, decimal convertedQuantity, DateTime createdAt, string customerReference, DateTime deliveryDate, long deliveryLocationCode, long deliveryTransactionCode, string externalReferenceNumber, string gridNumber, int hasEmpties, DateTime lastSavedAt, DateTime orderDate, long orderNumber, int orderStatus, long orderTypeCode, long popArticleGroup, decimal pricelistBasedAmount, long priceListCode, string promotionCodeGroup, string promotionReason, decimal totalCases, decimal totalCasesConv, decimal totalCasesConvAmount, string transactionDescription, int unproductive, long visitId, long wholesalerId, long toOutletNumber, long reasonListId, long vendorListId, long paymentTermsListId)
	{
		if (customerReference == null) throw new ArgumentNullException(nameof(customerReference));
		if (externalReferenceNumber == null) throw new ArgumentNullException(nameof(externalReferenceNumber));
		if (gridNumber == null) throw new ArgumentNullException(nameof(gridNumber));
		if (promotionCodeGroup == null) throw new ArgumentNullException(nameof(promotionCodeGroup));
		if (promotionReason == null) throw new ArgumentNullException(nameof(promotionReason));
		if (transactionDescription == null) throw new ArgumentNullException(nameof(transactionDescription));

		this.ActivityId = activityId;
		this.AddressNumber = addressNumber;
		this.AtpDeposit = atpDeposit;
		this.AtpPromoDiscount = atpPromoDiscount;
		this.AtpGrossTotal = atpGrossTotal;
		this.AtpTaxTotal = atpTaxTotal;
		this.AtpTimestamp = atpTimestamp;
		this.AtpTotal = atpTotal;
		this.ConvertedQuantity = convertedQuantity;
		this.CreatedAt = createdAt;
		this.CustomerReference = customerReference;
		this.DeliveryDate = deliveryDate;
		this.DeliveryLocationCode = deliveryLocationCode;
		this.DeliveryTransactionCode = deliveryTransactionCode;
		this.ExternalReferenceNumber = externalReferenceNumber;
		this.GridNumber = gridNumber;
		this.HasEmpties = hasEmpties;
		this.LastSavedAt = lastSavedAt;
		this.OrderDate = orderDate;
		this.OrderNumber = orderNumber;
		this.OrderStatus = orderStatus;
		this.OrderTypeCode = orderTypeCode;
		this.PopArticleGroup = popArticleGroup;
		this.PricelistBasedAmount = pricelistBasedAmount;
		this.PriceListCode = priceListCode;
		this.PromotionCodeGroup = promotionCodeGroup;
		this.PromotionReason = promotionReason;
		this.TotalCases = totalCases;
		this.TotalCasesConv = totalCasesConv;
		this.TotalCasesConvAmount = totalCasesConvAmount;
		this.TransactionDescription = transactionDescription;
		this.Unproductive = unproductive;
		this.VisitId = visitId;
		this.WholesalerId = wholesalerId;
		this.ToOutletNumber = toOutletNumber;
		this.ReasonListId = reasonListId;
		this.VendorListId = vendorListId;
		this.PaymentTermsListId = paymentTermsListId;
	}
}

public sealed class OrderText
{
	public long ActivityId { get; }
	public decimal DeviceId { get; }
	public int LineNo { get; }
	public string LineText { get; }
	public string ListCode { get; }
	public string Origin { get; }

	public OrderText(long activityId, decimal deviceId, int lineNo, string lineText, string listCode, string origin)
	{
		if (lineText == null) throw new ArgumentNullException(nameof(lineText));
		if (listCode == null) throw new ArgumentNullException(nameof(listCode));
		if (origin == null) throw new ArgumentNullException(nameof(origin));

		this.ActivityId = activityId;
		this.DeviceId = deviceId;
		this.LineNo = lineNo;
		this.LineText = lineText;
		this.ListCode = listCode;
		this.Origin = origin;
	}
}

public sealed class OrderType
{
	public long Code { get; }
	public string LocalName { get; }
	public string Name { get; }

	public OrderType(long code, string localName, string name)
	{
		if (localName == null) throw new ArgumentNullException(nameof(localName));
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Code = code;
		this.LocalName = localName;
		this.Name = name;
	}
}

public sealed class OutletsExtension
{
	public string Name { get; }
	public int Ordinal { get; }
	public long OutletNumber { get; }
	public string Value { get; }

	public OutletsExtension(string name, int ordinal, long outletNumber, string value)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (value == null) throw new ArgumentNullException(nameof(value));

		this.Name = name;
		this.Ordinal = ordinal;
		this.OutletNumber = outletNumber;
		this.Value = value;
	}
}

public sealed class OutletsTempData
{
	public long OutletNumber { get; }
	public long Type { get; }
	public string Wholesaler { get; }
	public string RawData { get; }
	public DateTime CreatedAt { get; }

	public OutletsTempData(long outletNumber, long type, string wholesaler, string rawData, DateTime createdAt)
	{
		if (wholesaler == null) throw new ArgumentNullException(nameof(wholesaler));
		if (rawData == null) throw new ArgumentNullException(nameof(rawData));

		this.OutletNumber = outletNumber;
		this.Type = type;
		this.Wholesaler = wholesaler;
		this.RawData = rawData;
		this.CreatedAt = createdAt;
	}
}

public sealed class OutletAddresse
{
	public long AddressNumber { get; }
	public long OutletNumber { get; }
	public string Street { get; }
	public string HouseNumber { get; }
	public string PostalCode { get; }
	public string Origin { get; }
	public string City { get; }
	public int IsDefault { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public OutletAddresse(long addressNumber, long outletNumber, string street, string houseNumber, string postalCode, string origin, string city, int isDefault, DateTime validFrom, DateTime validTo)
	{
		if (street == null) throw new ArgumentNullException(nameof(street));
		if (houseNumber == null) throw new ArgumentNullException(nameof(houseNumber));
		if (postalCode == null) throw new ArgumentNullException(nameof(postalCode));
		if (origin == null) throw new ArgumentNullException(nameof(origin));
		if (city == null) throw new ArgumentNullException(nameof(city));

		this.AddressNumber = addressNumber;
		this.OutletNumber = outletNumber;
		this.Street = street;
		this.HouseNumber = houseNumber;
		this.PostalCode = postalCode;
		this.Origin = origin;
		this.City = city;
		this.IsDefault = isDefault;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class OutletCluster
{
	public decimal HierarchyNode { get; }
	public decimal AttributeCode { get; }
	public string Description { get; }

	public OutletCluster(decimal hierarchyNode, decimal attributeCode, string description)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.HierarchyNode = hierarchyNode;
		this.AttributeCode = attributeCode;
		this.Description = description;
	}
}

public sealed class OutletHierLevel
{
	public string Description { get; }
	public long HierLevel { get; }
	public string HierNode { get; }
	public long OutletNumber { get; }
	public long ParentOutletNumber { get; }

	public OutletHierLevel(string description, long hierLevel, string hierNode, long outletNumber, long parentOutletNumber)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (hierNode == null) throw new ArgumentNullException(nameof(hierNode));

		this.Description = description;
		this.HierLevel = hierLevel;
		this.HierNode = hierNode;
		this.OutletNumber = outletNumber;
		this.ParentOutletNumber = parentOutletNumber;
	}
}

public sealed class OutletMarketAttribute
{
	public string Atvaluedescr { get; }
	public DateTime ChangedAt { get; }
	public string ChangedBy { get; }
	public string Charact { get; }
	public string CharactDescr { get; }
	public string Description { get; }
	public string Inherited { get; }
	public int Instance { get; }
	public long OutletNumber { get; }
	public string Value { get; }
	public string ValueAssignment { get; }
	public string ValueNeutral { get; }
	public string ValAssign { get; }

	public OutletMarketAttribute(string atvaluedescr, DateTime changedAt, string changedBy, string charact, string charactDescr, string description, string inherited, int instance, long outletNumber, string value, string valueAssignment, string valueNeutral, string valAssign)
	{
		if (atvaluedescr == null) throw new ArgumentNullException(nameof(atvaluedescr));
		if (changedBy == null) throw new ArgumentNullException(nameof(changedBy));
		if (charact == null) throw new ArgumentNullException(nameof(charact));
		if (charactDescr == null) throw new ArgumentNullException(nameof(charactDescr));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (inherited == null) throw new ArgumentNullException(nameof(inherited));
		if (value == null) throw new ArgumentNullException(nameof(value));
		if (valueAssignment == null) throw new ArgumentNullException(nameof(valueAssignment));
		if (valueNeutral == null) throw new ArgumentNullException(nameof(valueNeutral));
		if (valAssign == null) throw new ArgumentNullException(nameof(valAssign));

		this.Atvaluedescr = atvaluedescr;
		this.ChangedAt = changedAt;
		this.ChangedBy = changedBy;
		this.Charact = charact;
		this.CharactDescr = charactDescr;
		this.Description = description;
		this.Inherited = inherited;
		this.Instance = instance;
		this.OutletNumber = outletNumber;
		this.Value = value;
		this.ValueAssignment = valueAssignment;
		this.ValueNeutral = valueNeutral;
		this.ValAssign = valAssign;
	}
}

public sealed class OutletRule
{
	public long Idx { get; }
	public long OutletNumber { get; }
	public string Text { get; }

	public OutletRule(long idx, long outletNumber, string text)
	{
		if (text == null) throw new ArgumentNullException(nameof(text));

		this.Idx = idx;
		this.OutletNumber = outletNumber;
		this.Text = text;
	}
}

public sealed class OutletSnap
{
	public string Address { get; }
	public string BankAccountNumber { get; }
	public string BillingBlock { get; }
	public long BillToOutletNumber { get; }
	public BusinessType Businesstype { get; }
	public string City { get; }
	public string ContactPerson { get; }
	public int CreditDays { get; }
	public long CreditLimit { get; }
	public string Currency { get; }
	public string CustomerGroup { get; }
	public string DeliveryBlock { get; }
	public long DeliveryDelay { get; }
	public long DeliveryLeadTimeCode { get; }
	public long DeliveryLocationCode { get; }
	public string DeliveryTransactionsDesc { get; }
	public long DeliveryTransactionCode { get; }
	public long DeliveryTypeCode { get; }
	public string Email { get; }
	public int ExpressOrderAllowed { get; }
	public string Factory { get; }
	public string Fax { get; }
	public decimal Latitude { get; }
	public decimal Longitude { get; }
	public string Name1 { get; }
	public string Name2 { get; }
	public string OrderBlock { get; }
	public long OutletNumber { get; }
	public long PayerNumber { get; }
	public string PostalCode { get; }
	public string PriceGroup { get; }
	public string PrimaryConsumerActivity { get; }
	public string RedPosId { get; }
	public int SalesBlock { get; }
	public long SalesDistrictCode { get; }
	public long SalesGroupCode { get; }
	public long SalesOfficeCode { get; }
	public long ShipToOutletNumber { get; }
	public long SubTradeChannelCode { get; }
	public string SuppressedCode { get; }
	public DateTime SuppressionDate { get; }
	public string Telephone { get; }
	public string Telephone2 { get; }
	public long TradeChannelCode { get; }
	public string VatNumber { get; }
	public long WholesalerId { get; }

	public OutletSnap(string address, string bankAccountNumber, string billingBlock, long billToOutletNumber, BusinessType businesstype, string city, string contactPerson, int creditDays, long creditLimit, string currency, string customerGroup, string deliveryBlock, long deliveryDelay, long deliveryLeadTimeCode, long deliveryLocationCode, string deliveryTransactionsDesc, long deliveryTransactionCode, long deliveryTypeCode, string email, int expressOrderAllowed, string factory, string fax, decimal latitude, decimal longitude, string name1, string name2, string orderBlock, long outletNumber, long payerNumber, string postalCode, string priceGroup, string primaryConsumerActivity, string redPosId, int salesBlock, long salesDistrictCode, long salesGroupCode, long salesOfficeCode, long shipToOutletNumber, long subTradeChannelCode, string suppressedCode, DateTime suppressionDate, string telephone, string telephone2, long tradeChannelCode, string vatNumber, long wholesalerId)
	{
		if (address == null) throw new ArgumentNullException(nameof(address));
		if (bankAccountNumber == null) throw new ArgumentNullException(nameof(bankAccountNumber));
		if (billingBlock == null) throw new ArgumentNullException(nameof(billingBlock));
		if (businesstype == null) throw new ArgumentNullException(nameof(businesstype));
		if (city == null) throw new ArgumentNullException(nameof(city));
		if (contactPerson == null) throw new ArgumentNullException(nameof(contactPerson));
		if (currency == null) throw new ArgumentNullException(nameof(currency));
		if (customerGroup == null) throw new ArgumentNullException(nameof(customerGroup));
		if (deliveryBlock == null) throw new ArgumentNullException(nameof(deliveryBlock));
		if (deliveryTransactionsDesc == null) throw new ArgumentNullException(nameof(deliveryTransactionsDesc));
		if (email == null) throw new ArgumentNullException(nameof(email));
		if (factory == null) throw new ArgumentNullException(nameof(factory));
		if (fax == null) throw new ArgumentNullException(nameof(fax));
		if (name1 == null) throw new ArgumentNullException(nameof(name1));
		if (name2 == null) throw new ArgumentNullException(nameof(name2));
		if (orderBlock == null) throw new ArgumentNullException(nameof(orderBlock));
		if (postalCode == null) throw new ArgumentNullException(nameof(postalCode));
		if (priceGroup == null) throw new ArgumentNullException(nameof(priceGroup));
		if (primaryConsumerActivity == null) throw new ArgumentNullException(nameof(primaryConsumerActivity));
		if (redPosId == null) throw new ArgumentNullException(nameof(redPosId));
		if (suppressedCode == null) throw new ArgumentNullException(nameof(suppressedCode));
		if (telephone == null) throw new ArgumentNullException(nameof(telephone));
		if (telephone2 == null) throw new ArgumentNullException(nameof(telephone2));
		if (vatNumber == null) throw new ArgumentNullException(nameof(vatNumber));

		this.Address = address;
		this.BankAccountNumber = bankAccountNumber;
		this.BillingBlock = billingBlock;
		this.BillToOutletNumber = billToOutletNumber;
		this.Businesstype = businesstype;
		this.City = city;
		this.ContactPerson = contactPerson;
		this.CreditDays = creditDays;
		this.CreditLimit = creditLimit;
		this.Currency = currency;
		this.CustomerGroup = customerGroup;
		this.DeliveryBlock = deliveryBlock;
		this.DeliveryDelay = deliveryDelay;
		this.DeliveryLeadTimeCode = deliveryLeadTimeCode;
		this.DeliveryLocationCode = deliveryLocationCode;
		this.DeliveryTransactionsDesc = deliveryTransactionsDesc;
		this.DeliveryTransactionCode = deliveryTransactionCode;
		this.DeliveryTypeCode = deliveryTypeCode;
		this.Email = email;
		this.ExpressOrderAllowed = expressOrderAllowed;
		this.Factory = factory;
		this.Fax = fax;
		this.Latitude = latitude;
		this.Longitude = longitude;
		this.Name1 = name1;
		this.Name2 = name2;
		this.OrderBlock = orderBlock;
		this.OutletNumber = outletNumber;
		this.PayerNumber = payerNumber;
		this.PostalCode = postalCode;
		this.PriceGroup = priceGroup;
		this.PrimaryConsumerActivity = primaryConsumerActivity;
		this.RedPosId = redPosId;
		this.SalesBlock = salesBlock;
		this.SalesDistrictCode = salesDistrictCode;
		this.SalesGroupCode = salesGroupCode;
		this.SalesOfficeCode = salesOfficeCode;
		this.ShipToOutletNumber = shipToOutletNumber;
		this.SubTradeChannelCode = subTradeChannelCode;
		this.SuppressedCode = suppressedCode;
		this.SuppressionDate = suppressionDate;
		this.Telephone = telephone;
		this.Telephone2 = telephone2;
		this.TradeChannelCode = tradeChannelCode;
		this.VatNumber = vatNumber;
		this.WholesalerId = wholesalerId;
	}
}

public sealed class OutletText
{
	public DateTime ChangedAt { get; }
	public string ChangedBy { get; }
	public decimal DeviceId { get; }
	public string LineFormat { get; }
	public int LineNo { get; }
	public string LineText { get; }
	public string ListCode { get; }
	public string Origin { get; }
	public long OutletNumber { get; }

	public OutletText(DateTime changedAt, string changedBy, decimal deviceId, string lineFormat, int lineNo, string lineText, string listCode, string origin, long outletNumber)
	{
		if (changedBy == null) throw new ArgumentNullException(nameof(changedBy));
		if (lineFormat == null) throw new ArgumentNullException(nameof(lineFormat));
		if (lineText == null) throw new ArgumentNullException(nameof(lineText));
		if (listCode == null) throw new ArgumentNullException(nameof(listCode));
		if (origin == null) throw new ArgumentNullException(nameof(origin));

		this.ChangedAt = changedAt;
		this.ChangedBy = changedBy;
		this.DeviceId = deviceId;
		this.LineFormat = lineFormat;
		this.LineNo = lineNo;
		this.LineText = lineText;
		this.ListCode = listCode;
		this.Origin = origin;
		this.OutletNumber = outletNumber;
	}
}

public sealed class Parameter
{
	public string Description { get; }
	public long Id { get; }
	public long ParameterId { get; }
	public string ParameterName { get; }
	public string ParameterType { get; }
	public string ParameterValue { get; }
	public long SetId { get; }

	public Parameter(string description, long id, long parameterId, string parameterName, string parameterType, string parameterValue, long setId)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (parameterName == null) throw new ArgumentNullException(nameof(parameterName));
		if (parameterType == null) throw new ArgumentNullException(nameof(parameterType));
		if (parameterValue == null) throw new ArgumentNullException(nameof(parameterValue));

		this.Description = description;
		this.Id = id;
		this.ParameterId = parameterId;
		this.ParameterName = parameterName;
		this.ParameterType = parameterType;
		this.ParameterValue = parameterValue;
		this.SetId = setId;
	}
}

public sealed class PayerOutlet
{
	public DateTime FromDate { get; }
	public int IsSuppressed { get; }
	public long OutletNumber { get; }
	public long PayerNumber { get; }
	public DateTime SuppressionDate { get; }
	public DateTime ToDate { get; }

	public PayerOutlet(DateTime fromDate, int isSuppressed, long outletNumber, long payerNumber, DateTime suppressionDate, DateTime toDate)
	{
		this.FromDate = fromDate;
		this.IsSuppressed = isSuppressed;
		this.OutletNumber = outletNumber;
		this.PayerNumber = payerNumber;
		this.SuppressionDate = suppressionDate;
		this.ToDate = toDate;
	}
}

public sealed class Phpooledsnapcolumndesc
{
	public long Id { get; }
	public string Name { get; }
	public decimal DataLength { get; }
	public decimal DataPrecision { get; }
	public decimal DataScale { get; }
	public long SnapshotId { get; }
	public string DataType { get; }
	public int IsSystem { get; }
	public decimal IsNull { get; }

	public Phpooledsnapcolumndesc(long id, string name, decimal dataLength, decimal dataPrecision, decimal dataScale, long snapshotId, string dataType, int isSystem, decimal isNull)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (dataType == null) throw new ArgumentNullException(nameof(dataType));

		this.Id = id;
		this.Name = name;
		this.DataLength = dataLength;
		this.DataPrecision = dataPrecision;
		this.DataScale = dataScale;
		this.SnapshotId = snapshotId;
		this.DataType = dataType;
		this.IsSystem = isSystem;
		this.IsNull = isNull;
	}
}

public sealed class PlacementRequest
{
	public DateTime ActivationOn { get; }
	public long ActivityId { get; }
	public DateTime DeliveryOn { get; }
	public long EquipmentTypeCode { get; }
	public long Id { get; }
	public string Origin { get; }

	public PlacementRequest(DateTime activationOn, long activityId, DateTime deliveryOn, long equipmentTypeCode, long id, string origin)
	{
		if (origin == null) throw new ArgumentNullException(nameof(origin));

		this.ActivationOn = activationOn;
		this.ActivityId = activityId;
		this.DeliveryOn = deliveryOn;
		this.EquipmentTypeCode = equipmentTypeCode;
		this.Id = id;
		this.Origin = origin;
	}
}

public sealed class PlannedVolume
{
	public string KbiIndicator { get; }
	public long OutletNumber { get; }
	public DateTime PlannedDate { get; }
	public long PlannedQty { get; }
	public long PlannedQtySu { get; }

	public PlannedVolume(string kbiIndicator, long outletNumber, DateTime plannedDate, long plannedQty, long plannedQtySu)
	{
		if (kbiIndicator == null) throw new ArgumentNullException(nameof(kbiIndicator));

		this.KbiIndicator = kbiIndicator;
		this.OutletNumber = outletNumber;
		this.PlannedDate = plannedDate;
		this.PlannedQty = plannedQty;
		this.PlannedQtySu = plannedQtySu;
	}
}

public sealed class PlanningToolDailyCustom
{
	public decimal ActivityTypeId { get; }
	public decimal Delta { get; }
	public string Description { get; }
	public string FocusFlag { get; }
	public string FsmIndicator { get; }
	public string PlannableFlag { get; }
	public string ProcessType { get; }
	public string ReasonCode { get; }
	public string ReasonCode2 { get; }
	public string ReasonCodeGroup { get; }
	public string SortIndicator { get; }
	public string UnitOfMeasure { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }
	public string VolumeFlag { get; }

	public PlanningToolDailyCustom(decimal activityTypeId, decimal delta, string description, string focusFlag, string fsmIndicator, string plannableFlag, string processType, string reasonCode, string reasonCode2, string reasonCodeGroup, string sortIndicator, string unitOfMeasure, DateTime validFrom, DateTime validTo, string volumeFlag)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (focusFlag == null) throw new ArgumentNullException(nameof(focusFlag));
		if (fsmIndicator == null) throw new ArgumentNullException(nameof(fsmIndicator));
		if (plannableFlag == null) throw new ArgumentNullException(nameof(plannableFlag));
		if (processType == null) throw new ArgumentNullException(nameof(processType));
		if (reasonCode == null) throw new ArgumentNullException(nameof(reasonCode));
		if (reasonCode2 == null) throw new ArgumentNullException(nameof(reasonCode2));
		if (reasonCodeGroup == null) throw new ArgumentNullException(nameof(reasonCodeGroup));
		if (sortIndicator == null) throw new ArgumentNullException(nameof(sortIndicator));
		if (unitOfMeasure == null) throw new ArgumentNullException(nameof(unitOfMeasure));
		if (volumeFlag == null) throw new ArgumentNullException(nameof(volumeFlag));

		this.ActivityTypeId = activityTypeId;
		this.Delta = delta;
		this.Description = description;
		this.FocusFlag = focusFlag;
		this.FsmIndicator = fsmIndicator;
		this.PlannableFlag = plannableFlag;
		this.ProcessType = processType;
		this.ReasonCode = reasonCode;
		this.ReasonCode2 = reasonCode2;
		this.ReasonCodeGroup = reasonCodeGroup;
		this.SortIndicator = sortIndicator;
		this.UnitOfMeasure = unitOfMeasure;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
		this.VolumeFlag = volumeFlag;
	}
}

public sealed class PlanningToolDailyTarget
{
	public decimal AverageOrder { get; }
	public DateTime FiscalYearPeriod { get; }
	public string FiscalYearVariant { get; }
	public string FsmIndicator { get; }
	public string FsmIndicatorKey { get; }
	public DateTime LastOrderDate { get; }
	public decimal LastOrderVolume { get; }
	public decimal LastYearFpa { get; }
	public decimal MtdActuals { get; }
	public long OutletNumber { get; }
	public decimal PastYearFpa { get; }
	public string RecordMode { get; }
	public DateTime TransactionDate { get; }

	public PlanningToolDailyTarget(decimal averageOrder, DateTime fiscalYearPeriod, string fiscalYearVariant, string fsmIndicator, string fsmIndicatorKey, DateTime lastOrderDate, decimal lastOrderVolume, decimal lastYearFpa, decimal mtdActuals, long outletNumber, decimal pastYearFpa, string recordMode, DateTime transactionDate)
	{
		if (fiscalYearVariant == null) throw new ArgumentNullException(nameof(fiscalYearVariant));
		if (fsmIndicator == null) throw new ArgumentNullException(nameof(fsmIndicator));
		if (fsmIndicatorKey == null) throw new ArgumentNullException(nameof(fsmIndicatorKey));
		if (recordMode == null) throw new ArgumentNullException(nameof(recordMode));

		this.AverageOrder = averageOrder;
		this.FiscalYearPeriod = fiscalYearPeriod;
		this.FiscalYearVariant = fiscalYearVariant;
		this.FsmIndicator = fsmIndicator;
		this.FsmIndicatorKey = fsmIndicatorKey;
		this.LastOrderDate = lastOrderDate;
		this.LastOrderVolume = lastOrderVolume;
		this.LastYearFpa = lastYearFpa;
		this.MtdActuals = mtdActuals;
		this.OutletNumber = outletNumber;
		this.PastYearFpa = pastYearFpa;
		this.RecordMode = recordMode;
		this.TransactionDate = transactionDate;
	}
}

public sealed class PlanningToolDailyVolume
{
	public string FieldId { get; }
	public int FieldIndex { get; }
	public string FsmIndicator { get; }
	public string OperationType { get; }
	public string Sign { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }
	public string ValueHigh { get; }
	public string ValueLow { get; }

	public PlanningToolDailyVolume(string fieldId, int fieldIndex, string fsmIndicator, string operationType, string sign, DateTime validFrom, DateTime validTo, string valueHigh, string valueLow)
	{
		if (fieldId == null) throw new ArgumentNullException(nameof(fieldId));
		if (fsmIndicator == null) throw new ArgumentNullException(nameof(fsmIndicator));
		if (operationType == null) throw new ArgumentNullException(nameof(operationType));
		if (sign == null) throw new ArgumentNullException(nameof(sign));
		if (valueHigh == null) throw new ArgumentNullException(nameof(valueHigh));
		if (valueLow == null) throw new ArgumentNullException(nameof(valueLow));

		this.FieldId = fieldId;
		this.FieldIndex = fieldIndex;
		this.FsmIndicator = fsmIndicator;
		this.OperationType = operationType;
		this.Sign = sign;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
		this.ValueHigh = valueHigh;
		this.ValueLow = valueLow;
	}
}

public sealed class PlanningToolTarget
{
	public decimal Actuals { get; }
	public string CompanyCode { get; }
	public DateTime FiscalYearPeriod { get; }
	public string FiscalYearVariant { get; }
	public string FsmIndicator { get; }
	public string FsmIndicatorKey { get; }
	public string Origin { get; }
	public long RouteCode { get; }
	public decimal Target { get; }
	public string TerritoryId { get; }
	public DateTime TransactionDate { get; }

	public PlanningToolTarget(decimal actuals, string companyCode, DateTime fiscalYearPeriod, string fiscalYearVariant, string fsmIndicator, string fsmIndicatorKey, string origin, long routeCode, decimal target, string territoryId, DateTime transactionDate)
	{
		if (companyCode == null) throw new ArgumentNullException(nameof(companyCode));
		if (fiscalYearVariant == null) throw new ArgumentNullException(nameof(fiscalYearVariant));
		if (fsmIndicator == null) throw new ArgumentNullException(nameof(fsmIndicator));
		if (fsmIndicatorKey == null) throw new ArgumentNullException(nameof(fsmIndicatorKey));
		if (origin == null) throw new ArgumentNullException(nameof(origin));
		if (territoryId == null) throw new ArgumentNullException(nameof(territoryId));

		this.Actuals = actuals;
		this.CompanyCode = companyCode;
		this.FiscalYearPeriod = fiscalYearPeriod;
		this.FiscalYearVariant = fiscalYearVariant;
		this.FsmIndicator = fsmIndicator;
		this.FsmIndicatorKey = fsmIndicatorKey;
		this.Origin = origin;
		this.RouteCode = routeCode;
		this.Target = target;
		this.TerritoryId = territoryId;
		this.TransactionDate = transactionDate;
	}
}

public sealed class PlanningToolTeam
{
	public string FsmIndicator { get; }
	public decimal PlannedValue { get; }
	public DateTime PlanningDate { get; }
	public long UserId { get; }

	public PlanningToolTeam(string fsmIndicator, decimal plannedValue, DateTime planningDate, long userId)
	{
		if (fsmIndicator == null) throw new ArgumentNullException(nameof(fsmIndicator));

		this.FsmIndicator = fsmIndicator;
		this.PlannedValue = plannedValue;
		this.PlanningDate = planningDate;
		this.UserId = userId;
	}
}

public sealed class PlanningToolUser
{
	public decimal ActualValue { get; }
	public string FsmIndicator { get; }
	public long OutletNumber { get; }
	public decimal PlannedValue { get; }
	public DateTime PlanningDate { get; }
	public long UserId { get; }

	public PlanningToolUser(decimal actualValue, string fsmIndicator, long outletNumber, decimal plannedValue, DateTime planningDate, long userId)
	{
		if (fsmIndicator == null) throw new ArgumentNullException(nameof(fsmIndicator));

		this.ActualValue = actualValue;
		this.FsmIndicator = fsmIndicator;
		this.OutletNumber = outletNumber;
		this.PlannedValue = plannedValue;
		this.PlanningDate = planningDate;
		this.UserId = userId;
	}
}

public sealed class PopArticle
{
	public long ArticleNumber { get; }
	public long EntryId { get; }

	public PopArticle(long articleNumber, long entryId)
	{
		this.ArticleNumber = articleNumber;
		this.EntryId = entryId;
	}
}

public sealed class PopEntrie
{
	public string Comments { get; }
	public long Id { get; }
	public int IsDefault { get; }
	public int IsValid { get; }
	public string Name { get; }

	public PopEntrie(string comments, long id, int isDefault, int isValid, string name)
	{
		if (comments == null) throw new ArgumentNullException(nameof(comments));
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Comments = comments;
		this.Id = id;
		this.IsDefault = isDefault;
		this.IsValid = isValid;
		this.Name = name;
	}
}

public sealed class PromotionHeader
{
	public DateTime Actualfinish { get; }
	public DateTime Actualstart { get; }
	public string Description { get; }
	public int IsSuppressed { get; }
	public string ManualStatus { get; }
	public string Objective { get; }
	public int Priority { get; }
	public string PromotionGuid { get; }
	public string PromotionId { get; }
	public string Tactic { get; }
	public string Type { get; }
	public string LongText { get; }
	public string PromoType { get; }
	public DateTime PlannedStart { get; }
	public DateTime PlannedFinish { get; }
	public long Threshold { get; }

	public PromotionHeader(DateTime actualfinish, DateTime actualstart, string description, int isSuppressed, string manualStatus, string objective, int priority, string promotionGuid, string promotionId, string tactic, string type, string longText, string promoType, DateTime plannedStart, DateTime plannedFinish, long threshold)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (manualStatus == null) throw new ArgumentNullException(nameof(manualStatus));
		if (objective == null) throw new ArgumentNullException(nameof(objective));
		if (promotionGuid == null) throw new ArgumentNullException(nameof(promotionGuid));
		if (promotionId == null) throw new ArgumentNullException(nameof(promotionId));
		if (tactic == null) throw new ArgumentNullException(nameof(tactic));
		if (type == null) throw new ArgumentNullException(nameof(type));
		if (longText == null) throw new ArgumentNullException(nameof(longText));
		if (promoType == null) throw new ArgumentNullException(nameof(promoType));

		this.Actualfinish = actualfinish;
		this.Actualstart = actualstart;
		this.Description = description;
		this.IsSuppressed = isSuppressed;
		this.ManualStatus = manualStatus;
		this.Objective = objective;
		this.Priority = priority;
		this.PromotionGuid = promotionGuid;
		this.PromotionId = promotionId;
		this.Tactic = tactic;
		this.Type = type;
		this.LongText = longText;
		this.PromoType = promoType;
		this.PlannedStart = plannedStart;
		this.PlannedFinish = plannedFinish;
		this.Threshold = threshold;
	}
}

public sealed class PromotionPrdItem
{
	public string FreeFlag { get; }
	public string PromotionGuid { get; }
	public long ArticleNumber { get; }

	public PromotionPrdItem(string freeFlag, string promotionGuid, long articleNumber)
	{
		if (freeFlag == null) throw new ArgumentNullException(nameof(freeFlag));
		if (promotionGuid == null) throw new ArgumentNullException(nameof(promotionGuid));

		this.FreeFlag = freeFlag;
		this.PromotionGuid = promotionGuid;
		this.ArticleNumber = articleNumber;
	}
}

public sealed class PromoMechanicsHeader
{
	public string GroupDescription { get; }
	public string GroupType { get; }
	public int MaxGr { get; }
	public int MinGr { get; }
	public string PromotionGuid { get; }

	public PromoMechanicsHeader(string groupDescription, string groupType, int maxGr, int minGr, string promotionGuid)
	{
		if (groupDescription == null) throw new ArgumentNullException(nameof(groupDescription));
		if (groupType == null) throw new ArgumentNullException(nameof(groupType));
		if (promotionGuid == null) throw new ArgumentNullException(nameof(promotionGuid));

		this.GroupDescription = groupDescription;
		this.GroupType = groupType;
		this.MaxGr = maxGr;
		this.MinGr = minGr;
		this.PromotionGuid = promotionGuid;
	}
}

public sealed class PromoPartnersHierarchy
{
	public string HierNode { get; }
	public string PromotionGuid { get; }

	public PromoPartnersHierarchy(string hierNode, string promotionGuid)
	{
		if (hierNode == null) throw new ArgumentNullException(nameof(hierNode));
		if (promotionGuid == null) throw new ArgumentNullException(nameof(promotionGuid));

		this.HierNode = hierNode;
		this.PromotionGuid = promotionGuid;
	}
}

public sealed class PromoScale
{
	public int Free { get; }
	public int Group1Step { get; }
	public int Group2Step { get; }
	public int Group3Step { get; }
	public string PromotionGuid { get; }

	public PromoScale(int free, int group1Step, int group2Step, int group3Step, string promotionGuid)
	{
		if (promotionGuid == null) throw new ArgumentNullException(nameof(promotionGuid));

		this.Free = free;
		this.Group1Step = group1Step;
		this.Group2Step = group2Step;
		this.Group3Step = group3Step;
		this.PromotionGuid = promotionGuid;
	}
}

public sealed class RedActivitiesLog
{
	public DateTime ActivityDate { get; }
	public long ActivityId { get; }
	public int ActivityType { get; }
	public long OutletNumber { get; }
	public decimal RedIndex { get; }
	public long UserId { get; }

	public RedActivitiesLog(DateTime activityDate, long activityId, int activityType, long outletNumber, decimal redIndex, long userId)
	{
		this.ActivityDate = activityDate;
		this.ActivityId = activityId;
		this.ActivityType = activityType;
		this.OutletNumber = outletNumber;
		this.RedIndex = redIndex;
		this.UserId = userId;
	}
}

public sealed class RedCccH
{
	public string CommitId { get; }
	public string ContractId { get; }
	public string Description { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public RedCccH(string commitId, string contractId, string description, DateTime validFrom, DateTime validTo)
	{
		if (commitId == null) throw new ArgumentNullException(nameof(commitId));
		if (contractId == null) throw new ArgumentNullException(nameof(contractId));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.CommitId = commitId;
		this.ContractId = contractId;
		this.Description = description;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class RedCccList
{
	public string CommitId { get; }
	public int ListType { get; }
	public long ArticleNumber { get; }
	public string Product { get; }
	public string Param1 { get; }
	public string Param10 { get; }
	public string Param11 { get; }
	public string Param12 { get; }
	public string Param13 { get; }
	public string Param14 { get; }
	public string Param2 { get; }
	public string Param3 { get; }
	public string Param4 { get; }
	public string Param5 { get; }
	public string Param6 { get; }
	public string Param7 { get; }
	public string Param8 { get; }
	public string Param9 { get; }
	public string ParamPos { get; }
	public decimal PfpTarget { get; }
	public string QuestionId { get; }
	public string ShortText { get; }
	public decimal Weight { get; }

	public RedCccList(string commitId, int listType, long articleNumber, string product, string param1, string param10, string param11, string param12, string param13, string param14, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string paramPos, decimal pfpTarget, string questionId, string shortText, decimal weight)
	{
		if (commitId == null) throw new ArgumentNullException(nameof(commitId));
		if (product == null) throw new ArgumentNullException(nameof(product));
		if (param1 == null) throw new ArgumentNullException(nameof(param1));
		if (param10 == null) throw new ArgumentNullException(nameof(param10));
		if (param11 == null) throw new ArgumentNullException(nameof(param11));
		if (param12 == null) throw new ArgumentNullException(nameof(param12));
		if (param13 == null) throw new ArgumentNullException(nameof(param13));
		if (param14 == null) throw new ArgumentNullException(nameof(param14));
		if (param2 == null) throw new ArgumentNullException(nameof(param2));
		if (param3 == null) throw new ArgumentNullException(nameof(param3));
		if (param4 == null) throw new ArgumentNullException(nameof(param4));
		if (param5 == null) throw new ArgumentNullException(nameof(param5));
		if (param6 == null) throw new ArgumentNullException(nameof(param6));
		if (param7 == null) throw new ArgumentNullException(nameof(param7));
		if (param8 == null) throw new ArgumentNullException(nameof(param8));
		if (param9 == null) throw new ArgumentNullException(nameof(param9));
		if (paramPos == null) throw new ArgumentNullException(nameof(paramPos));
		if (questionId == null) throw new ArgumentNullException(nameof(questionId));
		if (shortText == null) throw new ArgumentNullException(nameof(shortText));

		this.CommitId = commitId;
		this.ListType = listType;
		this.ArticleNumber = articleNumber;
		this.Product = product;
		this.Param1 = param1;
		this.Param10 = param10;
		this.Param11 = param11;
		this.Param12 = param12;
		this.Param13 = param13;
		this.Param14 = param14;
		this.Param2 = param2;
		this.Param3 = param3;
		this.Param4 = param4;
		this.Param5 = param5;
		this.Param6 = param6;
		this.Param7 = param7;
		this.Param8 = param8;
		this.Param9 = param9;
		this.ParamPos = paramPos;
		this.PfpTarget = pfpTarget;
		this.QuestionId = questionId;
		this.ShortText = shortText;
		this.Weight = weight;
	}
}

public sealed class RedCccOutl
{
	public string CommitId { get; }
	public long OutletNumber { get; }
	public string OutlId { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public RedCccOutl(string commitId, long outletNumber, string outlId, DateTime validFrom, DateTime validTo)
	{
		if (commitId == null) throw new ArgumentNullException(nameof(commitId));
		if (outlId == null) throw new ArgumentNullException(nameof(outlId));

		this.CommitId = commitId;
		this.OutletNumber = outletNumber;
		this.OutlId = outlId;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class RedCccParVal
{
	public string ParamCode { get; }
	public string ParamId { get; }
	public string ParamPos { get; }
	public string ParamText { get; }
	public int Type { get; }

	public RedCccParVal(string paramCode, string paramId, string paramPos, string paramText, int type)
	{
		if (paramCode == null) throw new ArgumentNullException(nameof(paramCode));
		if (paramId == null) throw new ArgumentNullException(nameof(paramId));
		if (paramPos == null) throw new ArgumentNullException(nameof(paramPos));
		if (paramText == null) throw new ArgumentNullException(nameof(paramText));

		this.ParamCode = paramCode;
		this.ParamId = paramId;
		this.ParamPos = paramPos;
		this.ParamText = paramText;
		this.Type = type;
	}
}

public sealed class RedCccTarg
{
	public string CommitId { get; }
	public decimal PfpTarget { get; }
	public string QuestionId { get; }

	public RedCccTarg(string commitId, decimal pfpTarget, string questionId)
	{
		if (commitId == null) throw new ArgumentNullException(nameof(commitId));
		if (questionId == null) throw new ArgumentNullException(nameof(questionId));

		this.CommitId = commitId;
		this.PfpTarget = pfpTarget;
		this.QuestionId = questionId;
	}
}

public sealed class RedCccTarVal
{
	public string CommitId { get; }
	public string QuestionId { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public RedCccTarVal(string commitId, string questionId, DateTime validFrom, DateTime validTo)
	{
		if (commitId == null) throw new ArgumentNullException(nameof(commitId));
		if (questionId == null) throw new ArgumentNullException(nameof(questionId));

		this.CommitId = commitId;
		this.QuestionId = questionId;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class RedGapsAction
{
	public string Type { get; }
	public string SectionId { get; }
	public string QuestionId { get; }
	public string GapAction { get; }

	public RedGapsAction(string type, string sectionId, string questionId, string gapAction)
	{
		if (type == null) throw new ArgumentNullException(nameof(type));
		if (sectionId == null) throw new ArgumentNullException(nameof(sectionId));
		if (questionId == null) throw new ArgumentNullException(nameof(questionId));
		if (gapAction == null) throw new ArgumentNullException(nameof(gapAction));

		this.Type = type;
		this.SectionId = sectionId;
		this.QuestionId = questionId;
		this.GapAction = gapAction;
	}
}

public sealed class RedGapsPlanning
{
	public string QuestionId { get; }
	public string ReasonCode2 { get; }
	public string ReasonCode { get; }
	public string ReasonCodegrp { get; }
	public string ProcessType { get; }

	public RedGapsPlanning(string questionId, string reasonCode2, string reasonCode, string reasonCodegrp, string processType)
	{
		if (questionId == null) throw new ArgumentNullException(nameof(questionId));
		if (reasonCode2 == null) throw new ArgumentNullException(nameof(reasonCode2));
		if (reasonCode == null) throw new ArgumentNullException(nameof(reasonCode));
		if (reasonCodegrp == null) throw new ArgumentNullException(nameof(reasonCodegrp));
		if (processType == null) throw new ArgumentNullException(nameof(processType));

		this.QuestionId = questionId;
		this.ReasonCode2 = reasonCode2;
		this.ReasonCode = reasonCode;
		this.ReasonCodegrp = reasonCodegrp;
		this.ProcessType = processType;
	}
}

public sealed class RedListingAnswer
{
	public long ActivityId { get; }
	public long OrdinalNumber { get; }
	public string Value { get; }

	public RedListingAnswer(long activityId, long ordinalNumber, string value)
	{
		if (value == null) throw new ArgumentNullException(nameof(value));

		this.ActivityId = activityId;
		this.OrdinalNumber = ordinalNumber;
		this.Value = value;
	}
}

public sealed class RedListingHeader
{
	public string ListingId { get; }
	public int Type { get; }
	public string Description { get; }

	public RedListingHeader(string listingId, int type, string description)
	{
		if (listingId == null) throw new ArgumentNullException(nameof(listingId));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.ListingId = listingId;
		this.Type = type;
		this.Description = description;
	}
}

public sealed class RedListingItem
{
	public long Id { get; }
	public decimal Weight { get; }
	public string ParamPos { get; }
	public string Param14 { get; }
	public string Param13 { get; }
	public string Param12 { get; }
	public string Param11 { get; }
	public string Param10 { get; }
	public string Param9 { get; }
	public string Param8 { get; }
	public string Param7 { get; }
	public string Param6 { get; }
	public string Param5 { get; }
	public string Param4 { get; }
	public string Param3 { get; }
	public string Param2 { get; }
	public string Param1 { get; }
	public string Product { get; }
	public string ListingId { get; }
	public long ArticleNumber { get; }
	public string ShortText { get; }

	public RedListingItem(long id, decimal weight, string paramPos, string param14, string param13, string param12, string param11, string param10, string param9, string param8, string param7, string param6, string param5, string param4, string param3, string param2, string param1, string product, string listingId, long articleNumber, string shortText)
	{
		if (paramPos == null) throw new ArgumentNullException(nameof(paramPos));
		if (param14 == null) throw new ArgumentNullException(nameof(param14));
		if (param13 == null) throw new ArgumentNullException(nameof(param13));
		if (param12 == null) throw new ArgumentNullException(nameof(param12));
		if (param11 == null) throw new ArgumentNullException(nameof(param11));
		if (param10 == null) throw new ArgumentNullException(nameof(param10));
		if (param9 == null) throw new ArgumentNullException(nameof(param9));
		if (param8 == null) throw new ArgumentNullException(nameof(param8));
		if (param7 == null) throw new ArgumentNullException(nameof(param7));
		if (param6 == null) throw new ArgumentNullException(nameof(param6));
		if (param5 == null) throw new ArgumentNullException(nameof(param5));
		if (param4 == null) throw new ArgumentNullException(nameof(param4));
		if (param3 == null) throw new ArgumentNullException(nameof(param3));
		if (param2 == null) throw new ArgumentNullException(nameof(param2));
		if (param1 == null) throw new ArgumentNullException(nameof(param1));
		if (product == null) throw new ArgumentNullException(nameof(product));
		if (listingId == null) throw new ArgumentNullException(nameof(listingId));
		if (shortText == null) throw new ArgumentNullException(nameof(shortText));

		this.Id = id;
		this.Weight = weight;
		this.ParamPos = paramPos;
		this.Param14 = param14;
		this.Param13 = param13;
		this.Param12 = param12;
		this.Param11 = param11;
		this.Param10 = param10;
		this.Param9 = param9;
		this.Param8 = param8;
		this.Param7 = param7;
		this.Param6 = param6;
		this.Param5 = param5;
		this.Param4 = param4;
		this.Param3 = param3;
		this.Param2 = param2;
		this.Param1 = param1;
		this.Product = product;
		this.ListingId = listingId;
		this.ArticleNumber = articleNumber;
		this.ShortText = shortText;
	}
}

public sealed class RedListMapping
{
	public string PosId { get; }
	public string ListingId { get; }
	public string QuestionId { get; }
	public string RedPos { get; }

	public RedListMapping(string posId, string listingId, string questionId, string redPos)
	{
		if (posId == null) throw new ArgumentNullException(nameof(posId));
		if (listingId == null) throw new ArgumentNullException(nameof(listingId));
		if (questionId == null) throw new ArgumentNullException(nameof(questionId));
		if (redPos == null) throw new ArgumentNullException(nameof(redPos));

		this.PosId = posId;
		this.ListingId = listingId;
		this.QuestionId = questionId;
		this.RedPos = redPos;
	}
}

public sealed class RedListParam
{
	public int Type { get; }
	public string TextField { get; }
	public string Field { get; }
	public string ValueTable { get; }
	public string FunctionModule { get; }
	public string Description { get; }
	public string ParamPos { get; }
	public string ParamId { get; }

	public RedListParam(int type, string textField, string field, string valueTable, string functionModule, string description, string paramPos, string paramId)
	{
		if (textField == null) throw new ArgumentNullException(nameof(textField));
		if (field == null) throw new ArgumentNullException(nameof(field));
		if (valueTable == null) throw new ArgumentNullException(nameof(valueTable));
		if (functionModule == null) throw new ArgumentNullException(nameof(functionModule));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (paramPos == null) throw new ArgumentNullException(nameof(paramPos));
		if (paramId == null) throw new ArgumentNullException(nameof(paramId));

		this.Type = type;
		this.TextField = textField;
		this.Field = field;
		this.ValueTable = valueTable;
		this.FunctionModule = functionModule;
		this.Description = description;
		this.ParamPos = paramPos;
		this.ParamId = paramId;
	}
}

public sealed class RedMapping
{
	public string CcafValue { get; }
	public string Channel { get; }
	public string Cpl { get; }
	public string PosId { get; }
	public string Description { get; }
	public string CplChannelCcaf { get; }

	public RedMapping(string ccafValue, string channel, string cpl, string posId, string description, string cplChannelCcaf)
	{
		if (ccafValue == null) throw new ArgumentNullException(nameof(ccafValue));
		if (channel == null) throw new ArgumentNullException(nameof(channel));
		if (cpl == null) throw new ArgumentNullException(nameof(cpl));
		if (posId == null) throw new ArgumentNullException(nameof(posId));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (cplChannelCcaf == null) throw new ArgumentNullException(nameof(cplChannelCcaf));

		this.CcafValue = ccafValue;
		this.Channel = channel;
		this.Cpl = cpl;
		this.PosId = posId;
		this.Description = description;
		this.CplChannelCcaf = cplChannelCcaf;
	}
}

public sealed class RedParamsValue
{
	public int Type { get; }
	public string ParamText { get; }
	public string ParamCode { get; }
	public string ParamId { get; }
	public string ParamPos { get; }

	public RedParamsValue(int type, string paramText, string paramCode, string paramId, string paramPos)
	{
		if (paramText == null) throw new ArgumentNullException(nameof(paramText));
		if (paramCode == null) throw new ArgumentNullException(nameof(paramCode));
		if (paramId == null) throw new ArgumentNullException(nameof(paramId));
		if (paramPos == null) throw new ArgumentNullException(nameof(paramPos));

		this.Type = type;
		this.ParamText = paramText;
		this.ParamCode = paramCode;
		this.ParamId = paramId;
		this.ParamPos = paramPos;
	}
}

public sealed class RedPosDescription
{
	public string PosId { get; }
	public string Description { get; }

	public RedPosDescription(string posId, string description)
	{
		if (posId == null) throw new ArgumentNullException(nameof(posId));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.PosId = posId;
		this.Description = description;
	}
}

public sealed class SalesDistrict
{
	public long Code { get; }
	public string Bzirk { get; }
	public string Description { get; }

	public SalesDistrict(long code, string bzirk, string description)
	{
		if (bzirk == null) throw new ArgumentNullException(nameof(bzirk));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Bzirk = bzirk;
		this.Description = description;
	}
}

public sealed class SapActivityHistory
{
	public int ActivityTypeId { get; }
	public DateTime ChangedAt { get; }
	public string ChangedBy { get; }
	public DateTime CreatedAt { get; }
	public string CreatedBy { get; }
	public DateTime CrmChangedAt { get; }
	public string Description { get; }
	public DateTime ExpiresAt { get; }
	public string InputChannel { get; }
	public long OutletNumber { get; }
	public string PartnerNo { get; }
	public DateTime PhxChangedAt { get; }
	public DateTime PostingDate { get; }
	public string SapCode { get; }
	public long SapId { get; }
	public string Guid { get; }

	public SapActivityHistory(int activityTypeId, DateTime changedAt, string changedBy, DateTime createdAt, string createdBy, DateTime crmChangedAt, string description, DateTime expiresAt, string inputChannel, long outletNumber, string partnerNo, DateTime phxChangedAt, DateTime postingDate, string sapCode, long sapId, string guid)
	{
		if (changedBy == null) throw new ArgumentNullException(nameof(changedBy));
		if (createdBy == null) throw new ArgumentNullException(nameof(createdBy));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (inputChannel == null) throw new ArgumentNullException(nameof(inputChannel));
		if (partnerNo == null) throw new ArgumentNullException(nameof(partnerNo));
		if (sapCode == null) throw new ArgumentNullException(nameof(sapCode));
		if (guid == null) throw new ArgumentNullException(nameof(guid));

		this.ActivityTypeId = activityTypeId;
		this.ChangedAt = changedAt;
		this.ChangedBy = changedBy;
		this.CreatedAt = createdAt;
		this.CreatedBy = createdBy;
		this.CrmChangedAt = crmChangedAt;
		this.Description = description;
		this.ExpiresAt = expiresAt;
		this.InputChannel = inputChannel;
		this.OutletNumber = outletNumber;
		this.PartnerNo = partnerNo;
		this.PhxChangedAt = phxChangedAt;
		this.PostingDate = postingDate;
		this.SapCode = sapCode;
		this.SapId = sapId;
		this.Guid = guid;
	}
}

public sealed class SapActivityHistoryDetail
{
	public string DisplayText { get; }
	public int IsPending { get; }
	public long SapId { get; }
	public string SapStatus { get; }
	public string SapStatusProfile { get; }
	public int StatusType { get; }
	public string Text { get; }

	public SapActivityHistoryDetail(string displayText, int isPending, long sapId, string sapStatus, string sapStatusProfile, int statusType, string text)
	{
		if (displayText == null) throw new ArgumentNullException(nameof(displayText));
		if (sapStatus == null) throw new ArgumentNullException(nameof(sapStatus));
		if (sapStatusProfile == null) throw new ArgumentNullException(nameof(sapStatusProfile));
		if (text == null) throw new ArgumentNullException(nameof(text));

		this.DisplayText = displayText;
		this.IsPending = isPending;
		this.SapId = sapId;
		this.SapStatus = sapStatus;
		this.SapStatusProfile = sapStatusProfile;
		this.StatusType = statusType;
		this.Text = text;
	}
}

public sealed class SapActivityProcType
{
	public string ProcessType { get; }
	public string Description { get; }
	public string Enscription { get; }

	public SapActivityProcType(string processType, string description, string enscription)
	{
		if (processType == null) throw new ArgumentNullException(nameof(processType));
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (enscription == null) throw new ArgumentNullException(nameof(enscription));

		this.ProcessType = processType;
		this.Description = description;
		this.Enscription = enscription;
	}
}

public sealed class ShipToOutlet
{
	public long OutletNumber { get; }
	public string Name1 { get; }
	public string Name2 { get; }
	public string Address { get; }
	public string Fax { get; }
	public string PostalCode { get; }
	public string City { get; }
	public string Telephone { get; }
	public string ContactPerson { get; }
	public string Telephone2 { get; }
	public string Email { get; }
	public decimal Longitude { get; }
	public decimal Latitude { get; }

	public ShipToOutlet(long outletNumber, string name1, string name2, string address, string fax, string postalCode, string city, string telephone, string contactPerson, string telephone2, string email, decimal longitude, decimal latitude)
	{
		if (name1 == null) throw new ArgumentNullException(nameof(name1));
		if (name2 == null) throw new ArgumentNullException(nameof(name2));
		if (address == null) throw new ArgumentNullException(nameof(address));
		if (fax == null) throw new ArgumentNullException(nameof(fax));
		if (postalCode == null) throw new ArgumentNullException(nameof(postalCode));
		if (city == null) throw new ArgumentNullException(nameof(city));
		if (telephone == null) throw new ArgumentNullException(nameof(telephone));
		if (contactPerson == null) throw new ArgumentNullException(nameof(contactPerson));
		if (telephone2 == null) throw new ArgumentNullException(nameof(telephone2));
		if (email == null) throw new ArgumentNullException(nameof(email));

		this.OutletNumber = outletNumber;
		this.Name1 = name1;
		this.Name2 = name2;
		this.Address = address;
		this.Fax = fax;
		this.PostalCode = postalCode;
		this.City = city;
		this.Telephone = telephone;
		this.ContactPerson = contactPerson;
		this.Telephone2 = telephone2;
		this.Email = email;
		this.Longitude = longitude;
		this.Latitude = latitude;
	}
}

public sealed class SmartDeviceType
{
	public string Description { get; }
	public int IsDataCapable { get; }
	public string Lang { get; }
	public string TypeId { get; }

	public SmartDeviceType(string description, int isDataCapable, string lang, string typeId)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (lang == null) throw new ArgumentNullException(nameof(lang));
		if (typeId == null) throw new ArgumentNullException(nameof(typeId));

		this.Description = description;
		this.IsDataCapable = isDataCapable;
		this.Lang = lang;
		this.TypeId = typeId;
	}
}

public sealed class StatusList
{
	public long Id { get; }
	public long ParentId { get; }
	public string Description { get; }
	public long DropdownId { get; }
	public int IsSuppressed { get; }
	public long ParentDropdownId { get; }
	public string Code { get; }
	public string ParentCode { get; }

	public StatusList(long id, long parentId, string description, long dropdownId, int isSuppressed, long parentDropdownId, string code, string parentCode)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (code == null) throw new ArgumentNullException(nameof(code));
		if (parentCode == null) throw new ArgumentNullException(nameof(parentCode));

		this.Id = id;
		this.ParentId = parentId;
		this.Description = description;
		this.DropdownId = dropdownId;
		this.IsSuppressed = isSuppressed;
		this.ParentDropdownId = parentDropdownId;
		this.Code = code;
		this.ParentCode = parentCode;
	}
}

public sealed class SubTradeChannel
{
	public long Code { get; }
	public string Attrib7 { get; }
	public string Description { get; }

	public SubTradeChannel(long code, string attrib7, string description)
	{
		if (attrib7 == null) throw new ArgumentNullException(nameof(attrib7));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Attrib7 = attrib7;
		this.Description = description;
	}
}

public sealed class Survey
{
	public string Description { get; }
	public DateTime FromDate { get; }
	public long Id { get; }
	public int IsCopyLastValues { get; }
	public int IsGridView { get; }
	public int IsRed { get; }
	public string PosId { get; }
	public long RedIndex { get; }
	public long Sequence { get; }
	public long SetId { get; }
	public int Suppressed { get; }
	public DateTime ToDate { get; }
	public decimal WeightRatio { get; }

	public Survey(string description, DateTime fromDate, long id, int isCopyLastValues, int isGridView, int isRed, string posId, long redIndex, long sequence, long setId, int suppressed, DateTime toDate, decimal weightRatio)
	{
		if (description == null) throw new ArgumentNullException(nameof(description));
		if (posId == null) throw new ArgumentNullException(nameof(posId));

		this.Description = description;
		this.FromDate = fromDate;
		this.Id = id;
		this.IsCopyLastValues = isCopyLastValues;
		this.IsGridView = isGridView;
		this.IsRed = isRed;
		this.PosId = posId;
		this.RedIndex = redIndex;
		this.Sequence = sequence;
		this.SetId = setId;
		this.Suppressed = suppressed;
		this.ToDate = toDate;
		this.WeightRatio = weightRatio;
	}
}

public sealed class SurveyActivitie
{
	public long ActivityId { get; }
	public long SurveyId { get; }
	public int IsCompleted { get; }
	public decimal TargetScore { get; }
	public decimal ActualScore { get; }
	public string CommitId { get; }
	public decimal RedIndex { get; }

	public SurveyActivitie(long activityId, long surveyId, int isCompleted, decimal targetScore, decimal actualScore, string commitId, decimal redIndex)
	{
		if (commitId == null) throw new ArgumentNullException(nameof(commitId));

		this.ActivityId = activityId;
		this.SurveyId = surveyId;
		this.IsCompleted = isCompleted;
		this.TargetScore = targetScore;
		this.ActualScore = actualScore;
		this.CommitId = commitId;
		this.RedIndex = redIndex;
	}
}

public sealed class Tracing
{
	public string AssemblyVersion { get; }
	public int Category { get; }
	public long DeviceId { get; }
	public DateTime LogTime { get; }
	public string Message { get; }
	public int SaveOrder { get; }
	public long UserId { get; }
	public string AplScreen { get; }
	public string AplOperation { get; }
	public string AplControlType { get; }
	public string AplDetails { get; }
	public string AplUserName { get; }

	public Tracing(string assemblyVersion, int category, long deviceId, DateTime logTime, string message, int saveOrder, long userId, string aplScreen, string aplOperation, string aplControlType, string aplDetails, string aplUserName)
	{
		if (assemblyVersion == null) throw new ArgumentNullException(nameof(assemblyVersion));
		if (message == null) throw new ArgumentNullException(nameof(message));
		if (aplScreen == null) throw new ArgumentNullException(nameof(aplScreen));
		if (aplOperation == null) throw new ArgumentNullException(nameof(aplOperation));
		if (aplControlType == null) throw new ArgumentNullException(nameof(aplControlType));
		if (aplDetails == null) throw new ArgumentNullException(nameof(aplDetails));
		if (aplUserName == null) throw new ArgumentNullException(nameof(aplUserName));

		this.AssemblyVersion = assemblyVersion;
		this.Category = category;
		this.DeviceId = deviceId;
		this.LogTime = logTime;
		this.Message = message;
		this.SaveOrder = saveOrder;
		this.UserId = userId;
		this.AplScreen = aplScreen;
		this.AplOperation = aplOperation;
		this.AplControlType = aplControlType;
		this.AplDetails = aplDetails;
		this.AplUserName = aplUserName;
	}
}

public sealed class TradeChannel
{
	public long Code { get; }
	public string Attrib6 { get; }
	public string Description { get; }

	public TradeChannel(long code, string attrib6, string description)
	{
		if (attrib6 == null) throw new ArgumentNullException(nameof(attrib6));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Code = code;
		this.Attrib6 = attrib6;
		this.Description = description;
	}
}

public sealed class UserMessage
{
	public DateTime CreatedOn { get; }
	public DateTime ExpiresOn { get; }
	public DateTime ActiveFrom { get; }
	public long Id { get; }
	public int IsRead { get; }
	public int IsUrgent { get; }
	public string Message { get; }
	public long PcId { get; }
	public long UserGroup { get; }
	public long UserId { get; }

	public UserMessage(DateTime createdOn, DateTime expiresOn, DateTime activeFrom, long id, int isRead, int isUrgent, string message, long pcId, long userGroup, long userId)
	{
		if (message == null) throw new ArgumentNullException(nameof(message));

		this.CreatedOn = createdOn;
		this.ExpiresOn = expiresOn;
		this.ActiveFrom = activeFrom;
		this.Id = id;
		this.IsRead = isRead;
		this.IsUrgent = isUrgent;
		this.Message = message;
		this.PcId = pcId;
		this.UserGroup = userGroup;
		this.UserId = userId;
	}
}

public sealed class UserRouteSnap
{
	public DateTime FromDate { get; }
	public long Id { get; }
	public long RouteCode { get; }
	public string Territory { get; }
	public DateTime ToDate { get; }
	public long UserId { get; }

	public UserRouteSnap(DateTime fromDate, long id, long routeCode, string territory, DateTime toDate, long userId)
	{
		if (territory == null) throw new ArgumentNullException(nameof(territory));

		this.FromDate = fromDate;
		this.Id = id;
		this.RouteCode = routeCode;
		this.Territory = territory;
		this.ToDate = toDate;
		this.UserId = userId;
	}
}

public sealed class UserSetting
{
	public long Id { get; }
	public string Context { get; }
	public string Name { get; }
	public string Value { get; }

	public UserSetting(long id, string context, string name, string value)
	{
		if (context == null) throw new ArgumentNullException(nameof(context));
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (value == null) throw new ArgumentNullException(nameof(value));

		this.Id = id;
		this.Context = context;
		this.Name = name;
		this.Value = value;
	}
}

public sealed class UserSnap
{
	public string Address { get; }
	public string EMail { get; }
	public string FullName { get; }
	public string Industry { get; }
	public int IsAudittoolUser { get; }
	public int IsSupervisor { get; }
	public long ParentId { get; }
	public string PhoneNumber { get; }
	public string ShortName { get; }
	public long UserGroupId { get; }
	public long UserId { get; }

	public UserSnap(string address, string eMail, string fullName, string industry, int isAudittoolUser, int isSupervisor, long parentId, string phoneNumber, string shortName, long userGroupId, long userId)
	{
		if (address == null) throw new ArgumentNullException(nameof(address));
		if (eMail == null) throw new ArgumentNullException(nameof(eMail));
		if (fullName == null) throw new ArgumentNullException(nameof(fullName));
		if (industry == null) throw new ArgumentNullException(nameof(industry));
		if (phoneNumber == null) throw new ArgumentNullException(nameof(phoneNumber));
		if (shortName == null) throw new ArgumentNullException(nameof(shortName));

		this.Address = address;
		this.EMail = eMail;
		this.FullName = fullName;
		this.Industry = industry;
		this.IsAudittoolUser = isAudittoolUser;
		this.IsSupervisor = isSupervisor;
		this.ParentId = parentId;
		this.PhoneNumber = phoneNumber;
		this.ShortName = shortName;
		this.UserGroupId = userGroupId;
		this.UserId = userId;
	}
}

public sealed class Visit
{
	public long Id { get; }
	public DateTime CreationDate { get; }
	public int IsClosed { get; }
	public string Origin { get; }
	public long OutletNumber { get; }
	public DateTime PlannedDate { get; }
	public DateTime PlannedTimein { get; }
	public int Sequence { get; }
	public long StatusCode { get; }
	public DateTime Timein { get; }
	public DateTime Timeout { get; }
	public long UserId { get; }
	public DateTime VisitDate { get; }
	public long StatusReasonListId { get; }
	public long ReasonListId { get; }
	public long SubReasonListId { get; }
	public string EquipmentNumber { get; }
	public long NotScannedReasonListId { get; }
	public DateTime ScannedTime { get; }
	public long StatusListId { get; }
	public DateTime ActualFrom { get; }
	public DateTime ActualTo { get; }
	public string Description { get; }

	public Visit(long id, DateTime creationDate, int isClosed, string origin, long outletNumber, DateTime plannedDate, DateTime plannedTimein, int sequence, long statusCode, DateTime timein, DateTime timeout, long userId, DateTime visitDate, long statusReasonListId, long reasonListId, long subReasonListId, string equipmentNumber, long notScannedReasonListId, DateTime scannedTime, long statusListId, DateTime actualFrom, DateTime actualTo, string description)
	{
		if (origin == null) throw new ArgumentNullException(nameof(origin));
		if (equipmentNumber == null) throw new ArgumentNullException(nameof(equipmentNumber));
		if (description == null) throw new ArgumentNullException(nameof(description));

		this.Id = id;
		this.CreationDate = creationDate;
		this.IsClosed = isClosed;
		this.Origin = origin;
		this.OutletNumber = outletNumber;
		this.PlannedDate = plannedDate;
		this.PlannedTimein = plannedTimein;
		this.Sequence = sequence;
		this.StatusCode = statusCode;
		this.Timein = timein;
		this.Timeout = timeout;
		this.UserId = userId;
		this.VisitDate = visitDate;
		this.StatusReasonListId = statusReasonListId;
		this.ReasonListId = reasonListId;
		this.SubReasonListId = subReasonListId;
		this.EquipmentNumber = equipmentNumber;
		this.NotScannedReasonListId = notScannedReasonListId;
		this.ScannedTime = scannedTime;
		this.StatusListId = statusListId;
		this.ActualFrom = actualFrom;
		this.ActualTo = actualTo;
		this.Description = description;
	}
}

public sealed class VisitComment
{
	public long ActivityId { get; }
	public DateTime CreatedOn { get; }
	public long Id { get; }
	public int IsByAdmin { get; }
	public string Message { get; }
	public long SequenceNum { get; }
	public string Username { get; }
	public long VisitId { get; }

	public VisitComment(long activityId, DateTime createdOn, long id, int isByAdmin, string message, long sequenceNum, string username, long visitId)
	{
		if (message == null) throw new ArgumentNullException(nameof(message));
		if (username == null) throw new ArgumentNullException(nameof(username));

		this.ActivityId = activityId;
		this.CreatedOn = createdOn;
		this.Id = id;
		this.IsByAdmin = isByAdmin;
		this.Message = message;
		this.SequenceNum = sequenceNum;
		this.Username = username;
		this.VisitId = visitId;
	}
}

public sealed class Wholesaler
{
	public string Address { get; }
	public string City { get; }
	public long DeliveryLocationCode { get; }
	public string EMail { get; }
	public string FaxNumber { get; }
	public string GridDescription { get; }
	public string GridNumber { get; }
	public string GridType { get; }
	public long Id { get; }
	public string Industry { get; }
	public int IsSuppressed { get; }
	public string Name1 { get; }
	public string Name2 { get; }
	public string PostalCode { get; }
	public string TelNumber { get; }
	public string BlockReason { get; }

	public Wholesaler(string address, string city, long deliveryLocationCode, string eMail, string faxNumber, string gridDescription, string gridNumber, string gridType, long id, string industry, int isSuppressed, string name1, string name2, string postalCode, string telNumber, string blockReason)
	{
		if (address == null) throw new ArgumentNullException(nameof(address));
		if (city == null) throw new ArgumentNullException(nameof(city));
		if (eMail == null) throw new ArgumentNullException(nameof(eMail));
		if (faxNumber == null) throw new ArgumentNullException(nameof(faxNumber));
		if (gridDescription == null) throw new ArgumentNullException(nameof(gridDescription));
		if (gridNumber == null) throw new ArgumentNullException(nameof(gridNumber));
		if (gridType == null) throw new ArgumentNullException(nameof(gridType));
		if (industry == null) throw new ArgumentNullException(nameof(industry));
		if (name1 == null) throw new ArgumentNullException(nameof(name1));
		if (name2 == null) throw new ArgumentNullException(nameof(name2));
		if (postalCode == null) throw new ArgumentNullException(nameof(postalCode));
		if (telNumber == null) throw new ArgumentNullException(nameof(telNumber));
		if (blockReason == null) throw new ArgumentNullException(nameof(blockReason));

		this.Address = address;
		this.City = city;
		this.DeliveryLocationCode = deliveryLocationCode;
		this.EMail = eMail;
		this.FaxNumber = faxNumber;
		this.GridDescription = gridDescription;
		this.GridNumber = gridNumber;
		this.GridType = gridType;
		this.Id = id;
		this.Industry = industry;
		this.IsSuppressed = isSuppressed;
		this.Name1 = name1;
		this.Name2 = name2;
		this.PostalCode = postalCode;
		this.TelNumber = telNumber;
		this.BlockReason = blockReason;
	}
}


}
