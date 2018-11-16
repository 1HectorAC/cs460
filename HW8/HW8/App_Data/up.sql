
CREATE TABLE [dbo].[Buyer](
	[BuyerID] INT IDENTITY (1,1),
	[Name] VARCHAR(30) NOT NULL,
	CONSTRAINT [PK_Buyer] PRIMARY KEY ([BuyerID])
);
CREATE TABLE [dbo].[Seller]	(
	[SellerID] INT IDENTITY (1,1),
	[Name] VARCHAR(30) NOT NULL,
	CONSTRAINT [PK_Seller] PRIMARY KEY ([SellerID])
);
CREATE TABLE [dbo].[Item] (
	[ItemID] INT IDENTITY (1001,1) NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	[Description] VARCHAR(500) NOT NULL,
	[SellerID] INT NOT NULL,
	CONSTRAINT [PK_Item] PRIMARY KEY ([ItemID]),
	CONSTRAINT [FK_SellerItem] FOREIGN KEY ([SellerID])
	REFERENCES Seller([SellerID])
);

CREATE TABLE Bid(
	[BidID] INT IDENTITY (1,1) NOT NULL,
	[ItemID] INT NOT NULL,
	[BuyerID] INT NOT NULL,
	[Price] DECIMAL NOT NULL,
	[TimeStamp] DATETIME NOT NULL,
	CONSTRAINT [PK_Bid] PRIMARY KEY ([BidID]),
	CONSTRAINT [FK_ItemBid] FOREIGN KEY ([ItemID])
	REFERENCES Item([ItemID]),
	CONSTRAINT [FK_BuyerBid] FOREIGN KEY ([BuyerID])
	REFERENCES Buyer([BuyerID])
);


INSERT INTO [dbo].[Buyer](Name) VALUES
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall')
GO
INSERT INTO [dbo].[Seller](Name) VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene')
GO
INSERT INTO [dbo].[Item](Name, Description, SellerID) VALUES
	('Abraham Lincoln Hammer','A bench mallet fashioned from a broken rail-
splitting maul in 1829 and owned by Abraham Lincoln',3),
	('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein 
in Germany, circa 1927',1),
	('Bob Dylan Love Poems','Five versions of an original unpublished, 
handwritten, love poem by Bob Dylan',2)
Go
INSERT INTO [dbo].[Bid](ItemID,BuyerID,Price,TimeStamp) VALUES
	(1001,3,250000,'12/04/2017 09:04:22'),
	(1003,1,95000 ,'12/04/2017 08:44:03')
GO

select * from Seller
select * from Buyer
select * from Item
select * from Bid