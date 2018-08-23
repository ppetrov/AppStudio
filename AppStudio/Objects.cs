using System;
using AppCore.ViewModels;

namespace AppStudio
{
	public sealed class Article
{
public long Id { get; }
public string Name { get; }
public Brand Brand { get; }
public Flavor Flavor { get; }
public DateTime ValidFrom { get; }
public DateTime ValidTo { get; }

public Article(long id, string name, Brand brand, Flavor flavor, DateTime validFrom, DateTime validTo)
{
if (name == null) throw new ArgumentNullException(nameof(name));
if (brand == null) throw new ArgumentNullException(nameof(brand));
if (flavor == null) throw new ArgumentNullException(nameof(flavor));

this.Id = id;
this.Name = name;
this.Brand = brand;
this.Flavor = flavor;
this.ValidFrom = validFrom;
this.ValidTo = validTo;
}
}

public sealed class ArticleCaptions
{
public string Name { get; }
public string Brand { get; }
public string Flavor { get; }
public string ValidFrom { get; }
public string ValidTo { get; }

public ArticleCaptions(string name, string brand, string flavor, string validFrom, string validTo)
{
if (name == null) throw new ArgumentNullException(nameof(name));
if (brand == null) throw new ArgumentNullException(nameof(brand));
if (flavor == null) throw new ArgumentNullException(nameof(flavor));
if (validFrom == null) throw new ArgumentNullException(nameof(validFrom));
if (validTo == null) throw new ArgumentNullException(nameof(validTo));

this.Name = name;
this.Brand = brand;
this.Flavor = flavor;
this.ValidFrom = validFrom;
this.ValidTo = validTo;
}
}

public sealed class ArticleViewModel : ViewModel
{
public Article Article { get; }
public string Name { get; }
public string NameCaption { get; }
public string Brand { get; }
public string BrandCaption { get; }
public string Flavor { get; }
public string FlavorCaption { get; }
public string ValidFrom { get; }
public string ValidFromCaption { get; }
public string ValidTo { get; }
public string ValidToCaption { get; }

public ArticleViewModel(Article article, ArticleCaptions captions)
{
if (article == null) throw new ArgumentNullException(nameof(article));
if (captions == null) throw new ArgumentNullException(nameof(captions));

this.Article = article;
this.Name = article.Name;
this.NameCaption = captions.Name;
this.Brand = article.Brand.ToString();
this.BrandCaption = captions.Brand;
this.Flavor = article.Flavor.ToString();
this.FlavorCaption = captions.Flavor;
this.ValidFrom = article.ValidFrom.ToString(@"dd MMM yyyy");
this.ValidFromCaption = captions.ValidFrom;
this.ValidTo = article.ValidTo.ToString(@"dd MMM yyyy");
this.ValidToCaption = captions.ValidTo;
}
}

public enum ArticleProperty
{
Name,
Brand,
Flavor,
ValidFrom,
ValidTo,
}
public sealed class ArticleParameters
{

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

public sealed class BrandKindCaptions
{
public string Name { get; }

public BrandKindCaptions(string name)
{
if (name == null) throw new ArgumentNullException(nameof(name));

this.Name = name;
}
}

public sealed class BrandKindViewModel : ViewModel
{
public BrandKind BrandKind { get; }
public string Name { get; }
public string NameCaption { get; }

public BrandKindViewModel(BrandKind brandKind, BrandKindCaptions captions)
{
if (brandKind == null) throw new ArgumentNullException(nameof(brandKind));
if (captions == null) throw new ArgumentNullException(nameof(captions));

this.BrandKind = brandKind;
this.Name = brandKind.Name;
this.NameCaption = captions.Name;
}
}

public enum BrandKindProperty
{
Name,
}
public sealed class BrandKindParameters
{

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

public sealed class BrandCaptions
{
public string Name { get; }
public string BrandKind { get; }

public BrandCaptions(string name, string brandKind)
{
if (name == null) throw new ArgumentNullException(nameof(name));
if (brandKind == null) throw new ArgumentNullException(nameof(brandKind));

this.Name = name;
this.BrandKind = brandKind;
}
}

public sealed class BrandViewModel : ViewModel
{
public Brand Brand { get; }
public string Name { get; }
public string NameCaption { get; }
public string BrandKind { get; }
public string BrandKindCaption { get; }

public BrandViewModel(Brand brand, BrandCaptions captions)
{
if (brand == null) throw new ArgumentNullException(nameof(brand));
if (captions == null) throw new ArgumentNullException(nameof(captions));

this.Brand = brand;
this.Name = brand.Name;
this.NameCaption = captions.Name;
this.BrandKind = brand.BrandKind.ToString();
this.BrandKindCaption = captions.BrandKind;
}
}

public enum BrandProperty
{
Name,
BrandKind,
}
public sealed class BrandParameters
{

}

public sealed class Flavor
{
public long Id { get; }
public string Name { get; }

public Flavor(long id, string name)
{
if (name == null) throw new ArgumentNullException(nameof(name));

this.Id = id;
this.Name = name;
}
}

public sealed class FlavorCaptions
{
public string Name { get; }

public FlavorCaptions(string name)
{
if (name == null) throw new ArgumentNullException(nameof(name));

this.Name = name;
}
}

public sealed class FlavorViewModel : ViewModel
{
public Flavor Flavor { get; }
public string Name { get; }
public string NameCaption { get; }

public FlavorViewModel(Flavor flavor, FlavorCaptions captions)
{
if (flavor == null) throw new ArgumentNullException(nameof(flavor));
if (captions == null) throw new ArgumentNullException(nameof(captions));

this.Flavor = flavor;
this.Name = flavor.Name;
this.NameCaption = captions.Name;
}
}

public enum FlavorProperty
{
Name,
}
public sealed class FlavorParameters
{

}


}
