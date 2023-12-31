USE [OSCRP]
GO
/****** Object:  StoredProcedure [dbo].[spChangePassword]    Script Date: 17/4/2023 11:05:08 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Author,,Name
-- Create date: Create Date,,
-- Description:	Description,,
-- =============================================
CREATE Procedure [dbo].[spChangePassword]
(
	@varLoginID nvarchar(100) ,
	@nvrPassword nvarchar(30) ,
	@Result varchar(500) output)

AS
BEGIN
declare 
@strEncrypt NVARCHAR(30),
@strDecrypt NVARCHAR(30),
@strEmail NVARCHAR(100),
@TempResult NVARCHAR(4000);
BEGIN TRY
exec SPEncrypt @nvrPassword,@strEncrypt output;
update tblUser set nvrPassword = @strEncrypt where varLoginID=@varLoginID;
			SElect @Result ='Success';
				
	


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
