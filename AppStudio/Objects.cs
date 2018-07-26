using System;

namespace AppStudio
{
	public sealed class Article
{
	public long Id { get; }
	public string Name { get; }
	public Brand Brand { get; }
	public Flavour Flavour { get; }
	public DateTime ValidFrom { get; }
	public DateTime ValidTo { get; }

	public Article(long id, string name, Brand brand, Flavour flavour, DateTime validFrom, DateTime validTo)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (brand == null) throw new ArgumentNullException(nameof(brand));
		if (flavour == null) throw new ArgumentNullException(nameof(flavour));

		this.Id = id;
		this.Name = name;
		this.Brand = brand;
		this.Flavour = flavour;
		this.ValidFrom = validFrom;
		this.ValidTo = validTo;
	}
}

public sealed class BrandKind
{
	public long Id { get; }
	public string Name { get; }

	public BrandKind(long id, string name)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));

		this.Id = id;
		this.Name = name;
	}
}

public sealed class Brand
{
	public long Id { get; }
	public string Name { get; }
	public BrandKind BrandKind { get; }

	public Brand(long id, string name, BrandKind brandKind)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (brandKind == null) throw new ArgumentNullException(nameof(brandKind));

		this.Id = id;
		this.Name = name;
		this.BrandKind = brandKind;
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
