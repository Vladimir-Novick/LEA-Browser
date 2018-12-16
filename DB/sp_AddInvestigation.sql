USE [LEA]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].sp_AddInvestigation

	
AS
BEGIN
    DECLARE @Id as INT;
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Investigation]
           ([Name])
     VALUES
           ('');
     SET @Id = SCOPE_IDENTITY();

	 SELECT *
       FROM [dbo].[Investigation]
	   WHERE id = @Id;

END
GO


