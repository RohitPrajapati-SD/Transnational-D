using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Common
{
    public class CommonFuns
    {
        public Object SafeDbObject(Object input)
        {
            if (input == null)
            {
                return DBNull.Value;
            }
            else
            {
                return input;
            }
        }


        public string setDbName()
        {
            //return "Teamwork-SG-v2UAT";
            return "Teamwork_CRM_UAT";
        }
    }
}