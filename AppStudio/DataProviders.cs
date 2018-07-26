using System;
using System.Collections.Generic;
using AppStudio.Data;

namespace AppStudio
{
	public static class DataProviders
	{
		
public static Dictionary<long, Article> GetArticles(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new Dictionary<long, Article>();
	
var brands = cache.GetData<Brand>(dbContext);
var flavours = cache.GetData<Flavour>(dbContext);

	var query = new Query<Article>(@"SELECT Id, Name, Brand_Id, Flavor_Id, Valid_From, Valid_To FROM Articles", r =>
	{
	var id = Query.GetLong(r, 0);
var name = Query.GetString(r, 1);
var brand = brands[Query.GetLong(r, 2)];
var flavour = flavours[Query.GetLong(r, 3)];
var validFrom = Query.GetDateTime(r, 4) ?? DateTime.MinValue;
var validTo = Query.GetDateTime(r, 5) ?? DateTime.MaxValue;

return new Article(id, name, brand, flavour, validFrom, validTo);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item.Id, item);
	}

	return items;
}

public static Dictionary<long, BrandKind> GetBrandKinds(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new Dictionary<long, BrandKind>();
	
	var query = new Query<BrandKind>(@"SELECT Id, Name FROM Brand_Kinds", r =>
	{
	var id = Query.GetLong(r, 0);
var name = Query.GetString(r, 1);

return new BrandKind(id, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item.Id, item);
	}

	return items;
}

public static Dictionary<long, Brand> GetBrands(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new Dictionary<long, Brand>();
	
var brandKinds = cache.GetData<BrandKind>(dbContext);

	var query = new Query<Brand>(@"SELECT Id, Name, BrandKind_Id FROM Brands", r =>
	{
	var id = Query.GetLong(r, 0);
var name = Query.GetString(r, 1);
var brandKind = brandKinds[Query.GetLong(r, 2)];

return new Brand(id, name, brandKind);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item.Id, item);
	}

	return items;
}

public static Dictionary<long, Flavour> GetFlavours(IDbContext dbContext, DataCache cache)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new Dictionary<long, Flavour>();
	
	var query = new Query<Flavour>(@"SELECT Id, Name FROM Flavours", r =>
	{
	var id = Query.GetLong(r, 0);
var name = Query.GetString(r, 1);

return new Flavour(id, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item.Id, item);
	}

	return items;
}

	}
}
