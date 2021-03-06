USE [C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL12.MSSQLSERVERRRR\MSSQL\DATA\REAL_ESTATE_AGENCY.MDF]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Otchet1]
	@DATE1 date, @DATE2 date
AS
BEGIN
	SELECT  D.Id_Deal, D.Deal_Date,P.Pr_Address, C.Client_Name, A.Agent_Name, (D.Deal_Total_Cost - P.Pr_Cost) AS 'Agency_salary'
	FROM Deal D INNER JOIN Property P ON P.Id_Property = D.Deal_Property_FK
	INNER JOIN Agent A ON A.Id_Agent = D.Deal_Agent_FK
    INNER JOIN Client C ON C.Id_Client = D.Deal_Seller_FK

	WHERE D.Deal_Date >= @DATE1
	AND D.Deal_Date <= @DATE2
END
GO
