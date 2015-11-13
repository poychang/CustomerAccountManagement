using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerAccountManagement.Models.Attribute
{
    public class EmailAttribute : DataTypeAttribute
    {
        public EmailAttribute()
            : base(DataType.Text)
        {
            this.ErrorMessage = "電子郵件重複2";
        }
        public override bool IsValid(object value)
        {
            //可以用，但是還要用ADO去連、再查、做驗證，太慢了...
            var connectionString = "Data Source=(localdb)\v11.0;Initial Catalog=客戶資料;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var queryString = "select * from dbo.客戶聯絡人 where email=@email";
            using (var conn = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.Parameters.AddWithValue("@email", value);
                int count = 0;
                try
                {
                    conn.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                        if (count > 1) { return false; }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                }
                return false;
            }

        }
    }
}