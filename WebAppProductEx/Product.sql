create database ProductsDb
use ProductsDb

create table Product
(Id int primary key,
Name nvarchar(50) not null,
Price Float not null)

insert into Product values (1,'Earphones',2500.20)
select * from Product