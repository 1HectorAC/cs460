-- Users table

CREATE TABLE [dbo].[Users]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[LogDate]	DateTime		NOT NULL,
	[RequestedWord]	NVARCHAR(200)		NOT NULL,
	[RequestorsIPAddress]	NVARCHAR(20)		NOT NULL,
	[RequestorsBrowser]	NVARCHAR(30)		NOT NULL,


	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Users] (LogDate, RequestedWord, RequestorsIPAddress, RequestorsBrowser) VALUES
	('2017-01-22 11:05:44', 'apple','10.0.0.23','Chrome'),
	('2017-05-25 10:07:08', 'the','10.0.2.3','Safari')
GO