create database AddressBook_Service

use AddressBook_Service

create table AddressBook
(
  SNR int identity primary key,
  FirstName varchar(20),
  LastName varchar (20),
  Address varchar (100),
  City varchar (20),
  State varchar (20),
  ZipCode varchar (6),
  PhoneNumber varchar (10),
  EmailId varchar (30),
);
create procedure SpAddContacts
(
	@FirstName varchar(100),
	@LastName varchar(100),
	@Address varchar(100),
	@City varchar(100),
	@State varchar(100),
	@ZipCode varchar(6),
	@PhoneNumber varchar(10),
	@EmailId varchar(30),
	@Action varchar(100)
)
as begin
if @Action = 'Insert' insert into AddressBook values
(@FirstName,@LastName,@Address,@City,@State,@ZipCode,@PhoneNumber,@EmailId)

if @Action = 'Update' Update AddressBook set
FirstName = @FirstName,
LastName=@LastName,
Address=@Address,
City=@City,
State=@State,
ZipCode=@ZipCode,
PhoneNumber=@PhoneNumber,
EmailId=@EmailId where FirstName=@FirstName

if @Action = 'Delete' Delete from  AddressBook where FirstName=@FirstName
end

select * from AddressBook

