-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE Userdetails (@User xml)
AS
BEGIN
SET NOCOUNT ON;
select t.c.query('SNo').value('.','int') as 'SN',
t.c.query('FirstName').value('.','varchar(30)') as 'FName',
t.c.query('LastName').value('.','varchar(30)') as 'LName',
t.c.query('PhoneNumber').value('.','varchar(10)') as 'PN',
t.c.query('Email').value('.','varchar(50)') as 'EM'
into #tmp from @User.nodes('/Userxml') as t(c)

declare @SNo int
select @SNo=SN from #tmp

if(@SNo=0)
begin
insert into ContactDetails(FirstName,LastName,PhoneNumber,Email)
select FName,LName,PN,EM from #tmp
end
else
begin 
update t2 set FirstName=FName,LastName=LName,PhoneNumber=PN,Email=EM from #tmp t1 join ContactDetails t2 on t1.SN=t2.SNo
end
END
GO
