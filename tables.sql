CREATE TABLE [dbo].[Contract] (
    [ContractID]  INT  IDENTITY (1, 1) NOT NULL,
    [ResidentID]  INT  NOT NULL,
    [ApartmentID] INT  NOT NULL,
    [MoveInDate]  DATE NOT NULL,
    [MoveOutDate] DATE NULL,
    PRIMARY KEY CLUSTERED ([ContractID] ASC),
    FOREIGN KEY ([ResidentID]) REFERENCES [dbo].[Resident] ([ResidentID]),
    FOREIGN KEY ([ApartmentID]) REFERENCES [dbo].[Apartment] ([ApartmentID])
);
create table Account(
AccountID int identity(1,1) not null,
ResidentID int not null,
Password int not null,
);
CREATE TABLE [dbo].[Problem] (
    [ProblemID]   INT           IDENTITY (1, 1) NOT NULL,
    [ApartmentID] INT           NOT NULL,
    [Header]      VARCHAR (30)  NOT NULL,
    [Description] VARCHAR (140) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProblemID] ASC),
    FOREIGN KEY ([ApartmentID]) REFERENCES [dbo].[Apartment] ([ApartmentID])
);
create table Downpipe(
DownpipeID int identity(1,1) not null,
Condition varchar(100) not null,
LastChecked Date not null,
Picture varchar(200) null,
PRIMARY KEY CLUSTERED ([DownpipeID] ASC),
);
create table Window(
WindowID int identity(1,1) not null,
Condition varchar(100) not null,
LastChecked Date not null,
Picture varchar(200) null,
PRIMARY KEY CLUSTERED ([WindowID] ASC),
);
drop table Downpipe;
drop table Window;
CREATE TABLE [dbo].[Apartment] (
    [ApartmentID]   INT           IDENTITY (1, 1) NOT NULL,
	[DownpipeID]	int			not null,
	[WindowID]		int			not null,
    [Address]       VARCHAR (50)  NOT NULL,
    [Size]          INT           NOT NULL,
    [NumberOfRooms] INT           NOT NULL,
    [MonthlyRent]   MONEY         NOT NULL,
    [Condition]     VARCHAR (250) NOT NULL,
    [IsRented]      BIT           NOT NULL,
    [LastCheck]     DATE          NOT NULL,
    CONSTRAINT [dbo.Apartment] PRIMARY KEY CLUSTERED ([ApartmentID] ASC),
    FOREIGN KEY ([DownpipeID]) REFERENCES [dbo].[Downpipe] ([DownpipeID]),
	FOREIGN KEY ([WindowID]) REFERENCES [dbo].[Window] ([WindowID]),
	);
	drop table Apartment;
	drop table Contract;
	drop table Problem;