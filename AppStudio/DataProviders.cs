using System;
using System.Collections.Generic;
using AppStudio.Data;

namespace AppStudio
{
	public static class DataProviders
	{
		
public static List<Article> GetArticles(IDbContext dbContext)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

	var items = new List<Article>();

	var query = new Query<Article>(@"SELECT Id, Name, Brand_Id, Flavor_Id FROM Articles", r =>
	{
		var id = Query.GetLong(r, 0);
		var name = Query.GetString(r, 1);
		var brandId = Query.GetLong(r, 2);
		var flavorId = Query.GetLong(r, 3);
		return new Article(id, name, brandId, flavorId);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Brand> GetBrands(IDbContext dbContext)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

	var items = new List<Brand>();

	var query = new Query<Brand>(@"SELECT Id, Name FROM Brands", r =>
	{
		var id = Query.GetLong(r, 0);
		var name = Query.GetString(r, 1);
		return new Brand(id, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

public static List<Flavour> GetFlavours(IDbContext dbContext)
{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

	var items = new List<Flavour>();

	var query = new Query<Flavour>(@"SELECT Id, Name FROM Flavours", r =>
	{
		var id = Query.GetLong(r, 0);
		var name = Query.GetString(r, 1);
		return new Flavour(id, name);
	});
	foreach (var item in dbContext.Execute(query))
	{
		items.Add(item);
	}

	return items;
}

	}
}
