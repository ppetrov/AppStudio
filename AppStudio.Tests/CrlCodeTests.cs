using System.Collections.Generic;
using AppStudio.Clr;
using Xunit;

namespace AppStudio.Tests
{
	public class CrlCodeTests
	{
		[Fact]
		public void Enum_Generation_Test()
		{
			var entries = new List<EnumEntry>
			{
				new EnumEntry(@"Small"),
				new EnumEntry(@"Big"),
			};
			var e = new ClrEnum(@"Level", entries);
			var code = CrlCode.Generate(e);
			Assert.Equal(@"public enum Level
{
	Small,
	Big,
}", code);
		}

		[Fact]
		public void Enum_Generation_TestAccessLevel()
		{
			var entries = new List<EnumEntry>
			{
				new EnumEntry(@"Small"),
				new EnumEntry(@"Big"),
			};
			var e = new ClrEnum(@"Level", entries, AccessLevel.Private);
			var code = CrlCode.Generate(e);
			Assert.Equal(@"private enum Level
{
	Small,
	Big,
}", code);
		}

		[Fact]
		public void GetAccessLevel_Test()
		{
			Assert.Equal(@"private", CrlCode.GetAccessLevel(AccessLevel.Private));
			Assert.Equal(@"protected", CrlCode.GetAccessLevel(AccessLevel.Protected));
			Assert.Equal(@"public", CrlCode.GetAccessLevel(AccessLevel.Public));
		}

		[Fact]
		public void Generate_Interface_Test()
		{
			var methods = new List<ClrMethod>()
			{
				new ClrMethod(@"GetValue", new List<ClrParameter> {new ClrParameter(@"string", @"key")}, @"string")
			};
			var e = new ClrInterface(@"ILocalization", methods: methods);
			var code = CrlCode.Generate(e);
			Assert.Equal(@"public interface ILocalization
{
	string GetValue(string key);
}", code);
		}

	}
}
