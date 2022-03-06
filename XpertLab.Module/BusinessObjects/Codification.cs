using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xpert.Common.Base.DbSession;
using Xpert.Common.Base.Persistent;

namespace XpertLab.Module.BusinessObjects
{
	[DefaultClassOptions]
	[XafDisplayName("Numérotation Auto")]
	[Persistent("Codification")]
	[ImageName("ListNumbers_RightToLeft")]
	public class Codification : XPBaseObject
	{
		Pack pack;
		private Guid id;
		private string type;
		private string prefix;
		private int oid;
		public Codification(Session session) : base(session) { }


		[Persistent("ID"), Key(true)]
		public Guid ID
		{
			get { return id; }
			set { SetPropertyValue(nameof(ID), ref id, value); }
		}
		[XafDisplayName("Numéro")]
		public int Oid
		{
			get { return oid; }
			set { SetPropertyValue(nameof(Oid), ref oid, value); }
		}
		[Size(254)]
		public string Type
		{
			get { return type; }
			set { SetPropertyValue(nameof(Type), ref type, value); }
		}

		[XafDisplayName("Prefix")]
		public string Prefix
		{
			get { return prefix; }
			set { SetPropertyValue(nameof(Prefix), ref prefix, value); }
		}

		[XafDisplayName("Nom pack")]
		public Pack Pack
		{
			get => pack;
			set => SetPropertyValue(nameof(Pack), ref pack, value);
		}

	}
	public static class XpertGeneratorHelperID
	{
		public const int MaxIdGenerationAttemptsCounter = 7;
		public static int Generate(IDataLayer idGeneratorDataLayer, string seqType, string serverPrefix)
		{
			for (int attempt = 1; ; ++attempt)
			{
				try
				{
					using (Session generatorSession = new Session(idGeneratorDataLayer))
					{
						return GetOid(seqType, serverPrefix, generatorSession);
					}
				}
				catch (LockingException)
				{
					if (attempt >= MaxIdGenerationAttemptsCounter)
						throw;
				}
			}
		}
		public static int Generate(IDataLayer idGeneratorDataLayer, string seqType)
		{
			return Generate(idGeneratorDataLayer, seqType, null);
		}
		public static int Generate(Session session, string seqType, string serverPrefix)
		{
			for (int attempt = 1; ; ++attempt)
			{
				try
				{
					using (Session generatorSession = XpertdbSession.CreateGeneratorSession(session))
					{
						return GetOid(seqType, serverPrefix, generatorSession);
					}
				}
				catch (LockingException)
				{
					if (attempt >= MaxIdGenerationAttemptsCounter)
						throw;
				}
			}
		}
		private static int GetOid(string seqType, string serverPrefix, Session generatorSession)
		{
			CriteriaOperator serverPrefixCriteria;
			if (serverPrefix == null)
			{
				serverPrefixCriteria = new NullOperator("Prefix");
			}
			else
			{
				serverPrefixCriteria = new BinaryOperator("Prefix", serverPrefix);
			}
			Codification generator = generatorSession.FindObject<Codification>(
				new GroupOperator(new BinaryOperator("Type", seqType), serverPrefixCriteria));
			if (generator == null)
			{
				generator = new Codification(generatorSession);
				generator.Type = seqType;
				generator.Prefix = serverPrefix;
			}
			generator.Oid++;
			generator.Save();
			return generator.Oid;
		}

	}
}