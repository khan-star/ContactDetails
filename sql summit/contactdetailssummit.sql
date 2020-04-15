create database SummitAfrica

create table ContactDetails(SNo int primary key identity(1,1), FirstName varchar(30), LastName varchar(30), PhoneNumber varchar(10), Email varchar(50) )

insert into ContactDetails values ('Ibuyas','Khan','0724186373','ibuyas.khan77@gmail.com')
insert into ContactDetails values ('Salman','Asik','0653513112','asiksalman93@gmail.com')
insert into ContactDetails values ('Basheer','Ahmed','0724184353','Basheer80@gmail.com')

drop table ContactDetails

select * from ContactDetails