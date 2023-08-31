create database PlayerManagement
use PlayerManagement

create table Players
(Id int primary key,
FirstName nvarchar(50) not null,
LastName nvarchar(50)not null,
JerseyNumber int not null,
Position nvarchar(50) not null,
Team nvarchar(50) not null)

insert into Players values (1,'King','Kholi',18,'One down batsman','India')
select * from Players