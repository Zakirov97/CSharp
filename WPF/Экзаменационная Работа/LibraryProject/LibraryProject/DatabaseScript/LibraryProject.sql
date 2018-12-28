CREATE DATABASE LibraryProgrammv
GO
USE LibraryProgramm
GO
CREATE TABLE Library_staff(
Id INT PRIMARY KEY IDENTITY NOT NULL,
WorkerName NVARCHAR(200) NOT NULL,
WorkerAddress NVARCHAR(200) NOT NULL,
WorkerIdentificationNumber INT NOT NULL,
WorkerYearOfBirth DATE NOT NULL,
)

GO

CREATE TABLE Library_Registered_Accounts(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AccountName NVARCHAR(200) NOT NULL,
AccountPassword NVARCHAR(200) NOT NULL,
AccountLastPassword NVARCHAR(200) NULL,
AccountRole BIT NOT NULL
)
GO

CREATE TABLE Library_Users(
Id INT PRIMARY KEY IDENTITY NOT NULL,
UserName NVARCHAR(200) NOT NULL,
UserAddress NVARCHAR(200) NOT NULL,
UserIdentificationNumber INT NOT NULL,
UserYearOfBirth DATE NOT NULL,
)

GO

CREATE TABLE Books(
Id INT PRIMARY KEY IDENTITY NOT NULL,
BookName NVARCHAR(200) NOT NULL,
BookPrice INT NOT NULL,
BookAuthor NVARCHAR(200) NOT NULL,
BookPublishName NVARCHAR(200) NOT NULL,
BookYearOfPublication DATE NOT NULL,
BookQuantity INT NOT NULL
) 

GO

CREATE TABLE AssignBooks (
Id INT PRIMARY KEY IDENTITY NOT NULL,
BookId INT NOT NULL,
UserId INT NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
Penality INT NOT NULL,
[Status] BIT NOT NULL,
CONSTRAINT FK_AssignBooks_BookId FOREIGN KEY (BookId) 
REFERENCES Books(Id),
CONSTRAINT FK_AssignBooks_UserId FOREIGN KEY (UserId) 
REFERENCES Library_Users(Id),
)

GO

INSERT INTO Library_Registered_Accounts(AccountName,AccountPassword,AccountRole) VALUES('admin','admin','1')
SELECT * FROM Library_Registered_Accounts

insert into Library_Users VALUES('Petya','Vokzal2','322',GETDATE())
select * from Library_Users
