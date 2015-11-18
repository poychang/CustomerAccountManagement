using System;
using System.Linq;
using System.Collections.Generic;
	
namespace CustomerAccountManagement.Models
{   
	public  class vw客戶聯絡人及帳戶數量Repository : EFRepository<vw客戶聯絡人及帳戶數量>, Ivw客戶聯絡人及帳戶數量Repository
	{

	}

	public  interface Ivw客戶聯絡人及帳戶數量Repository : IRepository<vw客戶聯絡人及帳戶數量>
	{

	}
}