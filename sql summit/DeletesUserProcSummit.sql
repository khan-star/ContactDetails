USE [SummitAfrica]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 4/14/2020 11:03:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteUser] (@SNo int=0)
AS
BEGIN
SET NOCOUNT ON;
if(@SNo = 0)
begin
delete from ContactDetails where @SNo=SNo
end
else
begin
delete from ContactDetails where @SNo=SNo
end

END

DeleteUser 4

select * from ContactDetails
