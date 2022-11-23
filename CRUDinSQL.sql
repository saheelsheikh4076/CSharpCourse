--Variable declaration in SQL
Declare @StudentName varchar(20), @StudentId int
--Value assignment in variables
Set @StudentName = 'Tahir'
Print @StudentName
--Read Data
select top(2) * from StudentTable -- this will bring top two rows
select Id, Name, Gender from StudentTable -- selected columns will come
select Id as StudentId, Name as StudentName from StudentTable--customizing column names
select count(Id) as Total from StudentTable -- getting count of rows
select max(Id) as maximum from StudentTable --get max of Id column, min for minimum
--Get data into variables
Declare @StudentName varchar(20), @StudentId int
select Top(1) @StudentName =  Name, @StudentId = Id from StudentTable
Print 'Student Name is ' + @StudentName + ' and Id is '+ cast(@StudentId as varchar(20))
--Filtering data
select * from StudentTable where Gender = 7 --Filter by Integer
select * from StudentTable where Name like '[^b]b%'--[^b] escapes first char as not b, then b is compulsory second char as b, and % accepts all char
--Insert or Create Data to table
Insert into StudentTable (Age,Name) values (12,'ABCD')--Customized column sequence
Insert into StudentTable values ('Hello',12,7)--matching table defination is compulsory

--Update Data 
Update StudentTable Set Gender = 7, Name = 'PQRS' where id = 1 --DANGER without where

--Delete Data
Delete from StudentTable where Id = 3 --DANGER without where
select * from StudentTable
--Ids won't be recoverd unless we drop and recreate the table
Drop Table StudentTable
Create Table StudentTable
(
	Id int Not null Identity Primary Key,
	Name nvarchar(20) not null,
	Age int null,
	Gender int null
)