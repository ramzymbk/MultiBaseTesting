using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xpert.Common.Base.Helper
{
    public class XpertHelper
    {
        //
        //this.parameters = Parameters.GetInstance(base.Session);
        //public static Parameters GetInstance(DevExpress.Xpo.Session session)
        //{
        //    XPCollection<Parameters> parameters = new XPCollection<Parameters>(PersistentCriteriaEvaluationBehavior.InTransaction, session, null);
        //    Parameters parameter = null;
        //    if (parameters.Count != 0)
        //    {
        //        parameter = parameters.FirstOrDefault<Parameters>();
        //    }
        //    else
        //    {
        //        parameter = new Parameters(session);
        //        parameter.Save();
        //    }
        //    return parameter;
        //}
        public static bool IsNullOrEmpty(object value)
        {
            if (value is System.DBNull) return true;
            else if (value == null) return true;
            else if (value is IList)
            {
                return (value as IList).Count == 0;
            }
            else if (string.IsNullOrEmpty(value.ToString())) return true;
            return false;
        }
        public static bool IsNotNullAndNotEmpty(object value)
        {
            return !IsNullOrEmpty(value);
        }
        public static decimal GetValuePourcentage(decimal value, decimal p)
        {
            return value * p / 100;
        }
        public static decimal RoundMontant(decimal montant)
        {
            return Math.Round(montant, 2);
        }
        /// <summary>
        /// Méthode qui permet de retourner la valeur de la clé dans le fichiers Translations dans la langue en cours du systeme si un fichier de traduction existe dans cette langue.
        /// </summary>
        /// <param name="ressourceKey">La clé de la ressource</param>
        /// <returns>La valeur de la clé dans la langue du system si un fichiers de la langue en cours est déclaré</returns>
        public static string GetLocalizedMsg(string ressourceKey)
        {
            try
            {
                string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
                string racineTranslationsFileName = assemblyName + ".Language." + "Translations" + "_FR";
                ResourceManager rm = new ResourceManager(racineTranslationsFileName, Assembly.GetCallingAssembly());
                int languageCode = Thread.CurrentThread.CurrentCulture.LCID;
                return rm.GetString(ressourceKey, new CultureInfo(languageCode));
            }
            catch 
            {
                string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
                string msg = String.Format("La ressource {0} est introuvable dans l'assembly {1} ", ressourceKey, assemblyName);
                return "-";
            }
        }


        public static DateTime GetDate()
        {
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] == null)
            {
                return DateTime.Now;
            }
            return DateTime.Now;
            //    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //    IDataLayer DataLayer = XpoDefault.GetDataLayer(ConnectionString, AutoCreateOption.DatabaseAndSchema);
            //    using (UnitOfWork unitOfWork = new UnitOfWork(DataLayer)
            //    {

            //          try
            //            {


            //                DateTime date = (DateTime)unitOfWork.ExecuteScalar("SELECT GETDATE() AS Result");
            //                return date;
            //            }
            //            catch (Exception)
            //            {
            //                return DateTime.Now;
            //            }
            //}
        }

    }
}
