-- TennantRequests table
CREATE TABLE [dbo].[TennantRequests]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[FirstName]	NVARCHAR(20)		NOT NULL,
	[LastName]	NVARCHAR(20)		NOT NULL,
	[PhoneNumber]	NVARCHAR(12)		NOT NULL,
	[ApartmentName]	NVARCHAR(20)		NOT NULL,
	[UnitNumber]	INT		NOT NULL,
	[RequestDescription]	NVARCHAR(600)		NOT NULL,
	[RequestTimeStamp]		DateTime			NOT NULL,
	[AllowEnter]		BIT			NOT NULL,

	CONSTRAINT [PK_dbo.TennantRequests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[TennantRequests] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, RequestDescription, RequestTimeStamp,AllowEnter) VALUES
	('James','Jameson', '503-542-2345','Apartment A',4, 'Sink stopped working', '2017-01-22 11:05:44', 1),
	('Jose','Joseson', '971-111-1111','Apartment B',2, 'The Regrigerator isnt working anymore and is leaking water.', '2017-05-25 10:07:08', 1),
	('Jack','Jackson', '503-444-5555','Apartment C',10, 'There is a large hole in the wall. It was noticed this morning.', '2018-07-29 05:01:00', 0),
	('Michael','Jordan', '503-123-4567','Apartment A',2, 'There is a bee hive inside the my room. Please come immediately because this cannot wait.', '2018-08-22 00:36:05', 0),
	('Jim','Johnson', '503-543-2345','Apartment A',1, 'Neighbor tennant making too much noise at night.', '2018-08-22 00:51:10', 1),
	('Alexandriana','Darius', '503-777-2635','Apartment E',7, 'The sink has stopped working again.', '2018-08-25 03:02:01', 0)
GO