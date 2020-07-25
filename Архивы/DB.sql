USE STO
CREATE DATABASE STO
DROP DATABASE STO

SELECT * FROM Cart
SELECT * FROM HashPasswrdTable
SELECT * FROM Orders
SELECT * FROM OrderLines
SELECT * FROM [Services]
SELECT * FROM StatusTable
SELECT * FROM UserLoginTable

DROP TABLE Cart
CREATE TABLE [Cart]
(
	[CartId] INT IDENTITY PRIMARY KEY,
	[SessionKey] VARCHAR(256) NOT NULL,
	[Price] DECIMAL(16,2) NOT NULL,
	[Service_ServiceId] INT NOT NULL,
	CONSTRAINT Cart_To_Service FOREIGN KEY(Service_ServiceId) REFERENCES [Services](ServiceId)
)

DROP TABLE HashPasswrdTable
CREATE TABLE HashPasswrdTable
(
	HashPasswrdTableID INT IDENTITY PRIMARY KEY NOT NULL,
	[Hash] NVARCHAR(32) NOT NULL
)

DROP TABLE Orders
CREATE TABLE Orders
(
	[OrderId] INT IDENTITY NOT NULL,
	[Name] NVARCHAR(MAX) NULL,
	[Line1] NVARCHAR(MAX) NULL,
	[Line2] NVARCHAR(MAX) NULL,
	[Line3] NVARCHAR(MAX) NULL,
	[City] NVARCHAR(MAX) NULL,
	[GiftWrap] BIT NOT NULL,
	[Dispatched] BIT NOT NULL,
	CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC)
)

DROP TABLE OrderLines
CREATE TABLE OrderLines
(
	[OrderLineId] INT IDENTITY NOT NULL,
	[Quantity] INT NOT NULL,
	[Service_ServiceId] INT NULL,
	[Order_OrderId] INT NULL,
	CONSTRAINT [PK_dbo.OrderLines] PRIMARY KEY CLUSTERED([OrderLineId] ASC),
	CONSTRAINT [FK_dbo.OrderLines_dbo.Service_ServiceId] FOREIGN KEY([Service_ServiceId]) REFERENCES [dbo].[Services] ([ServiceID]),
	CONSTRAINT [FK_dbo.OrderLines_dbo.Order_OrderId] FOREIGN KEY([Order_OrderId]) REFERENCES [dbo].[Orders] ([OrderId])
)

DROP TABLE [Services]
CREATE TABLE [Services]
(
    [ServiceID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(50) NOT NULL,
    [Category] NVARCHAR(50) NOT NULL,
    [Price] DECIMAL(16, 2) NOT NULL
)

DROP TABLE StatusTable
CREATE TABLE StatusTable
(
	StatusTableID INT IDENTITY PRIMARY KEY NOT NULL,
	StatusName NVARCHAR(24) NOT NULL
)

DROP TABLE UserLoginTable
CREATE TABLE UserLoginTable
(
	UserLoginTableID INT IDENTITY NOT NULL PRIMARY KEY ,
	UserLogin NVARCHAR(MAX) NULL,
	UserName NVARCHAR(MAX) NULL,
	UserSName NVARCHAR(MAX) NULL,
	UserTelephone NVARCHAR(13) NULL,
	UserMail NVARCHAR(MAX) NULL,
	StatusTableID INT NOT NULL,
	HashPasswordID INT NOT NULL,
	CONSTRAINT [FK_UserLoginTable_HashPasswrdTable] FOREIGN KEY(HashPasswordID) REFERENCES [dbo].HashPasswrdTable (HashPasswrdTableID),
	CONSTRAINT [FK_UserLoginTable_StatusTable] FOREIGN KEY(StatusTableID) REFERENCES [dbo].StatusTable (StatusTableID)
)