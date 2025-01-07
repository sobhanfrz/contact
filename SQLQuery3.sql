create database contacts
go

use contacts 
go 

create table dbo.[user]
(
id int not null identity(1000,1) primary key,
username varchar(32) not null unique, --email
password binary(16) not null,
fullname varchar(32)not null,
avatar varchar(32)
)

create table dbo.contact
(
id int not null identity(1000,1) primary key,
userid int not null foreign key references dbo.[user](id) ,
 fullname varchar(60) not null,
 email varchar(90),
 avatar varchar(32)
)
create table dbo.phonetype(
id tinyint not null primary key,
title varchar(32) not null
)
insert into dbo.phonetype 
values (1,'home'),
(2,'work'),
(3,'mobile')



create table dbo.phone
(
id int not null identity(1000,1) primary key,
contactid int not null foreign key references dbo.contact(id) ,
number varchar(32) not null,
phonetypeid tinyint not null foreign key references dbo.phonetype(id)
)

create table dbo.favorite(

contactid int primary key not null foreign key references dbo.contact(id) 
)
