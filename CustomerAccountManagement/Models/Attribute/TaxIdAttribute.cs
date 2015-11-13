using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerAccountManagement.Models
{
    public class TaxIdAttribute : DataTypeAttribute
    {
        public TaxIdAttribute()
            : base(DataType.Text)
        {
            this.ErrorMessage = "請檢查統一編號";
        }
        public override bool IsValid(object value)
        {
            return CheckTaxId(Convert.ToString(value));
        }

        /// <summary>
        /// 檢查統一編號
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        private Boolean CheckTaxId(string CompanyId)
        {
            int CompanyNo;
            if (CompanyId == null || CompanyId.Trim().Length != 8)
                return false;
            if (!int.TryParse(CompanyId, out CompanyNo))
                return false;
            int[] Logic = new int[] { 1, 2, 1, 2, 1, 2, 4, 1 };
            int addition, sum = 0, j = 0, x;
            for (x = 0; x < Logic.Length; x++)
            {
                int no = Convert.ToInt32(CompanyId.Substring(x, 1));
                j = no * Logic[x];
                addition = ((j / 10) + (j % 10));
                sum += addition;
            }
            if (sum % 10 == 0)
            {
                return true;
            }
            if (CompanyId.Substring(6, 1) == "7")
            {
                if (sum % 10 == 9)
                {
                    return true;
                }
            }
            return false;
        } 

    }
}