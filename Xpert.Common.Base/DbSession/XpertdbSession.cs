using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpert.Common.Base.DbSession
{
    public class XpertdbSession
    {
		public static Session CreateGeneratorSession(Session session)
		{
			Session parentSession = GetRealSession(session);
			Session generatorSession;
			if (parentSession.ObjectLayer != null)
			{
				generatorSession = new Session(parentSession.ObjectLayer);
			}
			else
			{
				generatorSession = new Session(parentSession.DataLayer);
			}
			return generatorSession;
		}
		private static Session GetRealSession(Session session)
		{
			Session realSession = session;
			if (session.ObjectLayer is SessionObjectLayer)
			{
				realSession = GetRealSession(((SessionObjectLayer)session.ObjectLayer).ParentSession);
			}
			return realSession;
		}
	}
}
