using System;

namespace AppStudio
{
	public sealed class Article
{
	public long Id { get; }
	public string Name { get; }
	public long BrandId { get; }
	public long FlavorId { get; }

	public Article(long id, string name, long brandId, long flavorId)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Id = id;
		this.Name = name;
		this.BrandId = brandId;
		this.FlavorId = flavorId;
	}
}

public sealed class Brand
{
	public long Id { get; }
	public string Name { get; }

	public Brand(long id, string name)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Id = id;
		this.Name = name;
	}
}

public sealed class Flavour
{
	public long Id { get; }
	public string Name { get; }

	public Flavour(long id, string name)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Id = id;
		this.Name = name;
	}
}


}
