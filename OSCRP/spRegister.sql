USE [OSCRP]
GO
/****** Object:  StoredProcedure [dbo].[SPRegister]    Script Date: 17/4/2023 11:05:51 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Author,,Name
-- Create date: Create Date,,
-- Description: Description,,
-- =============================================
ALTER Procedure [dbo].[SPRegister]
( @varLoginID nvarchar(100) ,
@varFirstName nvarchar(100) ,
@nvrLastName nvarchar(100) ,
@nvrEmail nvarchar(100) ,
@txtAddress nvarchar(4000) ,
@nvrPinCode nvarchar(10) ,
@nvrPhone nvarchar(50) ,
@nvrWhatsAPP nvarchar(50) ,
@nvrPassword nvarchar(30) ,
@Role nvarchar(50) = 'User' ,
@intActive int =1,
@intIsDeleted int =0 ,
@nvrCommand nvarchar(30),
@Result varchar(500) output)
AS
BEGIN
	declare
	@strEncrypt NVARCHAR(30);
	BEGIN TRY

	exec SPEncrypt @nvrPassword,@strEncrypt output;
	if @nvrCommand = 'INSERT'
	BEGIN
		IF EXISTS (   SELECT *
                          FROM   [dbo].[tblUser]
                          WHERE  varLoginID = @varLoginID
                      )
		Begin
			select @Result='User already exist'
			return
		end
		else
		begin
			INSERT INTO [dbo].[tblUser]
           ([varLoginID]
			,[varFirstName]
           ,[nvrLastName]
           ,[nvrEmail]
           ,[txtAddress]
           ,[nvrPinCode]
           ,[nvrPhone]
           ,[nvrWhatsAPP]
           ,[nvrPassword]
		   ,[Role]
		   ,[intActive]
		   ,[intIsDeleted]
		   )
			VALUES
           (@varLoginID
			,@varFirstName
           ,@nvrLastName
           ,@nvrEmail
           ,@txtAddress
           ,@nvrPinCode
           ,@nvrPhone
           ,@nvrWhatsAPP
           ,@strEncrypt
		   ,@Role
		   ,@intActive
		   ,@intIsDeleted);
			select @Result='Success';
			return
		END;
	end

	if @nvrCommand = 'UPDATE'
	BEGIN
		UPDATE [dbo].[tblUser] SET [varFirstName] =@varFirstName
		,[nvrLastName]=@nvrLastName
           ,[nvrEmail]=@nvrEmail
           ,[txtAddress]=@txtAddress
           ,[nvrPinCode]=@nvrPinCode
           ,[nvrPhone]=@nvrPhone
           ,[nvrWhatsAPP]=@nvrWhatsAPP
           WHERE [varLoginID] = @varLoginID;
		select @Result='Success';
		return
	END;


	END TRY
	BEGIN CATCH
    select @Result = ERROR_NUMBER() + ' |' +
    ERROR_STATE() + ' |' +
    ERROR_SEVERITY() + ' |' +
    ERROR_PROCEDURE() + ' |' +
    ERROR_LINE() + ' |' +
    ERROR_MESSAGE() + ' |' ;
	END CATCH
	print @Result
END