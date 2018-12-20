USE [LEA]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SelectProduct]
	
	@InvestigationId int 
	
AS
BEGIN
	SET NOCOUNT ON;

   IF @InvestigationId > 0 
   BEGIN 
	  SELECT t1.*,t2.Name as Investigation from Product t1
      left join Investigation t2 on t1.InvestigationId = t2.id
	   where t1.InvestigationId = @InvestigationId
	   order by t1.CreationDate;

   END
   ELSE 
   BEGIN
   	  SELECT t1.*,t2.Name as Investigation from Product t1
      left join [Investigation] t2 on t1.InvestigationId = t2.id
	   order by t1.CreationDate;
   END
END
GO


