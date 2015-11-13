using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomerAccountManagement.Models
{
    public class MobileAttribute : DataTypeAttribute
    {
        public MobileAttribute()
            : base(DataType.Text)
        {
            this.ErrorMessage = "手機格式必須為xxxx-xxxxxx";
        }
        public override bool IsValid(object value)
        {
            string input = Convert.ToString(value);
            string pattern = @"\d{4}-\d{6}";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.Match(input).Success)
            {
                Console.WriteLine(regex.Match(input).Success);
                return true;
            }
            else
            {
                Console.WriteLine("false");
                return false;
            }
        }
    }
}