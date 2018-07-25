using System;

namespace AppStudio
{
	public sealed class Article
{
	public long Id { get; }
	public string Name { get; }
	public Brand Brand { get; }
	public Flavour Flavour { get; }

	public Article(long id, string name, Brand brand, Flavour flavour)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (brand == null) throw new ArgumentNullException(nameof(brand));
		if (flavour == null) throw new ArgumentNullException(nameof(flavour));

		this.Id = id;
		this.Name = name;
		this.Brand = brand;
		this.Flavour = flavour;
	}
}

public sealed class Brandkind
{
	public long Id { get; }
	public string Name { get; }

	public Brandkind(long id, string name)
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
	public Brandkind Brandkind { get; }

	public Brand(long id, string name, Brandkind brandkind)
	{
		if (name == null) throw new ArgumentNullException(nameof(name));
		if (brandkind == null) throw new ArgumentNullException(nameof(brandkind));

		this.Id = id;
		this.Name = name;
		this.Brandkind = brandkind;
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
