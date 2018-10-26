-- Users table
CREATE TABLE [dbo].[TennantRequests]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[FirstName]	NVARCHAR(64)		NOT NULL,
	[LastName]	NVARCHAR(128)		NOT NULL,
	[PhoneNumber]	NVARCHAR(64)		NOT NULL,
	[ApartmentName]	NVARCHAR(128)		NOT NULL,
	[UnitNumber]	INT		NOT NULL,
	[RequestDescription]	NVARCHAR(100)		NOT NULL,
	[RequestTimeStamp]		DateTime			NOT NULL,
	[AllowEnter]		BIT			NOT NULL,

	CONSTRAINT [PK_dbo.TennantRequests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[TennantRequests] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, RequestDescription, RequestTimeStamp,AllowEnter) VALUES
	('James','Jameson', '5035422345','Apartment A',4, 'Sink stopped working', '2018-07-22 11:05:44', 1),
	('Jose','Joseson', '9711111111','Apartment B',2, 'The Regrigerator isnt working anymore and is leaking water.', '2018-07-25 10:07:08', 1),
	('Jack','Jackson', '5034445555','Apartment C',10, 'There is a large hole in the wall. It was noticed this morning.', '2018-07-29 05:01:00', 0),
	('Michael','Jordan', '5031234567','Apartment A',2, 'There is a bee hive inside the my room. Please come immediately because this cannot wait.', '2018-08-22 00:36:05', 0),
	('Jim','Johnson', '5035432345','Apartment A',1, 'Neighbor tennant making too much noise at night.', '2018-08-22 00:51:10', 1),
	('Alexandriana','Darius', '5037772635','Apartment E',7, 'The sink has stopped working again.', '2018-08-25 03:02:01', 0)
GO