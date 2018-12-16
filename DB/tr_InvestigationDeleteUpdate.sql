USE [LEA]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vladimir Novick
-- Create date: 10.12.2018
-- Description:	Modify Details Product Table
-- =============================================
CREATE TRIGGER [dbo].[tr_InvestigationDeleteUpdate]
ON [dbo].[Investigation]
AFTER INSERT, UPDATE, DELETE
AS 
BEGIN
    SET NOCOUNT ON;
    DECLARE @Id as INT;
	DECLARE @Id_old as INT;
    DECLARE @action as char(1);

    SET @action = 'I'; -- Set Action to Insert by default.
    IF EXISTS(SELECT * FROM DELETED)
    BEGIN
        SET @action = 
            CASE
                WHEN EXISTS(SELECT * FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
    END
 



   IF @action = 'D' BEGIN
     Select @Id = id from DELETED;

	 DELETE FROM [dbo].[Product]
      WHERE InvestigationId = @Id;

   END

   IF @action = 'U' BEGIN
        Select @Id = id from INSERTED;
	    Select @Id_old = id from DELETED;
         UPDATE [dbo].[Product]
             SET [InvestigationId] = @Id
            WHERE [InvestigationId] = @Id_old;
   END

    END;
GO

ALTER TABLE [dbo].[Investigation] ENABLE TRIGGER [tr_InvestigationDeleteUpdate]
GO


