﻿CREATE VIEW [dbo].[vw客戶聯絡人及帳戶數量]
AS
SELECT id
	,客戶資料.客戶名稱
	,ISNULL(客戶銀行資訊.銀行帳戶數量, 0) AS 銀行帳戶數量
	,ISNULL(客戶聯絡人.聯絡人數量, 0) AS 聯絡人數量
FROM 客戶資料
LEFT JOIN (
	SELECT 客戶Id
		,count(*) AS 銀行帳戶數量
	FROM 客戶銀行資訊
	WHERE ISNULL(客戶銀行資訊.是否已刪除, 0) = 0
	GROUP BY 客戶Id
	) AS 客戶銀行資訊 ON 客戶資料.Id = 客戶銀行資訊.客戶Id
LEFT JOIN (
	SELECT 客戶Id
		,count(*) AS 聯絡人數量
	FROM 客戶聯絡人
	WHERE ISNULL(客戶聯絡人.是否已刪除, 0) = 0
	GROUP BY 客戶Id
	) AS 客戶聯絡人 ON 客戶資料.Id = 客戶聯絡人.客戶Id
WHERE ISNULL(客戶資料.是否已刪除, 0) = 0