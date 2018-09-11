using System;
using System.Text;

namespace AppStudio.Clr
{
	public static class CrlCode
	{
		public static string GetAccessLevel(AccessLevel accessLevel)
		{
			switch (accessLevel)
			{
				case AccessLevel.Public:
					return @"public";
				case AccessLevel.Private:
					return @"private";
				case AccessLevel.Protected:
					return @"protected";
				default:
					throw new ArgumentOutOfRangeException(nameof(accessLevel), accessLevel, null);
			}
		}

		public static string GetReturnType(ClrMethod method)
		{
			if (method == null) throw new ArgumentNullException(nameof(method));

			return method.ReturnType == string.Empty ? @"void" : method.ReturnType;
		}

		public static string GetParameters(ClrMethod method)
		{
			if (method == null) throw new ArgumentNullException(nameof(method));

			var parameters = method.Parameters;
			if (parameters.Count > 0)
			{
				var buffer = new StringBuilder();

				foreach (var parameter in parameters)
				{
					if (buffer.Length > 0)
					{
						buffer.Append(',');
					}
					buffer.Append(parameter.Name);
					buffer.Append(' ');
					buffer.Append(parameter.Type);
				}

				return buffer.ToString();
			}

			return string.Empty;
		}

		public static string Generate(ClrEnum clrEnum)
		{
			if (clrEnum == null) throw new ArgumentNullException(nameof(clrEnum));

			var buffer = new StringBuilder();

			Generate(buffer, clrEnum);

			return buffer.ToString();
		}

		public static void Generate(StringBuilder buffer, ClrEnum clrEnum)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (clrEnum == null) throw new ArgumentNullException(nameof(clrEnum));

			buffer.Append(GetAccessLevel(clrEnum.AccessLevel));
			buffer.Append(' ');
			buffer.Append(@"enum");
			buffer.Append(' ');
			buffer.AppendLine(clrEnum.Name);
			buffer.AppendLine(@"{");

			foreach (var entry in clrEnum.Entries)
			{
				buffer.Append('\t');
				buffer.Append(entry.Name);
				buffer.Append(',');
				buffer.AppendLine();
			}

			buffer.Append(@"}");
		}

		public static string Generate(ClrInterface clrInterface)
		{
			if (clrInterface == null) throw new ArgumentNullException(nameof(clrInterface));

			var buffer = new StringBuilder();

			Generate(buffer, clrInterface);

			return buffer.ToString();
		}

		public static void Generate(StringBuilder buffer, ClrInterface clrInterface)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (clrInterface == null) throw new ArgumentNullException(nameof(clrInterface));

			buffer.Append(GetAccessLevel(clrInterface.AccessLevel));
			buffer.Append(' ');
			buffer.Append(@"interface");
			buffer.Append(' ');
			buffer.AppendLine(clrInterface.Name);
			buffer.AppendLine(@"{");

			foreach (var method in clrInterface.Methods)
			{
				buffer.Append('\t');
				buffer.Append(GetReturnType(method));
				buffer.Append(' ');
				buffer.Append(method.Name);
				buffer.Append('(');
				buffer.Append(GetParameters(method));
				buffer.Append(')');
				buffer.Append(';');
				buffer.AppendLine();
			}

			buffer.Append(@"}");
		}
	}
}