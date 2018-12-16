USE [LEA]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vladimir Novick
-- Create date: 11.12.2018
-- Description:	Modify Details Product Table
-- =============================================
CREATE TRIGGER [dbo].[tr_Product]
ON [dbo].[Product]
AFTER INSERT, UPDATE, DELETE
AS 
BEGIN
    SET NOCOUNT ON;
    DECLARE @Type as INT;
	 DECLARE @TypeOld as INT;
	 DECLARE @TypeNew as INT;
    DECLARE @ProductId as INT;
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
   

   IF @action = 'I' BEGIN
      select @Type = [Type], @ProductId = [Id] from inserted;
	  IF @Type = 2 BEGIN
	  INSERT INTO [dbo].[SmsMessage]
           ([ProductId],[Text]
           )
		   select id,'' from inserted;
	  END 
	  Else 
	  BEGIN
	  INSERT INTO [dbo].[VoiceCall]
           ([ProductId]
           ,[Path]
           ,[CallLengthInMs])
		     select id,'','' from inserted;
	  END
   END

   IF @action = 'D' BEGIN
         select @Type = [Type], @ProductId = [Id] from deleted;
	  IF @Type = 2 BEGIN
            DELETE FROM [dbo].[SmsMessage]
            WHERE [ProductId] = @ProductId;
	  END 
	  Else 
	  BEGIN
            DELETE FROM [dbo].[VoiceCall]
            WHERE [ProductId] = @ProductId;
	  END
   END

   IF @action = 'U' BEGIN
      select @TypeOld = [Type] from deleted;
	  select @TypeNew = [Type], @ProductId = [Id] from inserted;
	  if @TypeOld != @TypeNew BEGIN

	  IF @TypeOLD = 2 BEGIN
            DELETE FROM [dbo].[SmsMessage]
            WHERE [ProductId] = @ProductId;
	  END 
	  Else 
	  BEGIN
            DELETE FROM [dbo].[VoiceCall]
            WHERE [ProductId] = @ProductId;
	  END

	  IF @TypeNEW = 2 BEGIN
	  INSERT INTO [dbo].[SmsMessage]
           ([ProductId],[Text]
           )
		   select id,'' from inserted;
	  END 
	  Else 
	  BEGIN
	  INSERT INTO [dbo].[VoiceCall]
           ([ProductId]
           ,[Path]
           ,[CallLengthInMs])
		     select id,'','' from inserted;
	  END


	  END
   END

    END;
GO

ALTER TABLE [dbo].[Product] ENABLE TRIGGER [tr_Product]
GO


