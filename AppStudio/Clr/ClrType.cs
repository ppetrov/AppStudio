using System;

namespace AppStudio.Clr
{
	public sealed class ClrType
	{
		public static readonly ClrType Int = new ClrType(BuiltinType.Int);
		public static readonly ClrType Long = new ClrType(BuiltinType.Long);
		public static readonly ClrType Decimal = new ClrType(BuiltinType.Decimal);
		public static readonly ClrType DateTime = new ClrType(BuiltinType.DateTime);
		public static readonly ClrType String = new ClrType(BuiltinType.String);
		public static readonly ClrType ByteArray = new ClrType(BuiltinType.ByteArray);

		public BuiltinType Type { get; }
		public string UserType { get; }
		public ClrCollectionType? CollectionType { get; }

		private ClrType(BuiltinType type)
		{
			this.Type = type;
		}

		public ClrType(BuiltinType type, ClrCollectionType collectionType)
		{
			this.Type = type;
			this.CollectionType = collectionType;
		}

		public ClrType(string userType, ClrCollectionType? collectionType = null)
		{
			if (userType == null) throw new ArgumentNullException(nameof(userType));

			this.UserType = userType;
			this.CollectionType = collectionType;
		}
	}
}