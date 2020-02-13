create database SignIn
go
use SignIn
go
create table LoinTable(
ID int primary key identity(1,1),
Mobile varchar(16) not null unique,
Name nvarchar(16) not null,
Pwd varchar(32) not null
)
go
create table CardTable(
Id int primary key identity(1,1),
C_Name nvarchar(16) not null,
C_AddTime datetime default(getdate()),
C_EndTime datetime default(getdate()),
C_Task varchar(128),
C_Evaluate varchar(32)
)
go
select * from CardTable where C_Name='¿Ó¥œ' and C_AddTime='2020-01-11 11:33:52'

insert LoinTable values('15617204722','¿Ó¥œ','1')