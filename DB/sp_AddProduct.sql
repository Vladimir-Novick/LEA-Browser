USE [LEA]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].sp_AddProduct
	
	@InvestigationId int 
	
AS
BEGIN
    DECLARE @Id as INT;
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Product]
           ([InvestigationId])
     VALUES
           (@InvestigationId);
     SET @Id = SCOPE_IDENTITY();

   	  SELECT t1.*,t2.Name as Investigation from Product t1
      inner join [Investigation] t2 on t1.InvestigationId = t2.id
	   WHERE t1.Id = @Id;

END
GO


