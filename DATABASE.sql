-- Installatiescript

-- Delete allen!
DROP TABLE [RouteSequence];
DROP TABLE [POI];
DROP TABLE [Preferences];
DROP TABLE [Route];
DROP TABLE [User];

-- Create User table
CREATE TABLE [dbo].[User](
[Id] INT IDENTITY (1, 1),
[Name] NVARCHAR(100) NOT NULL,
[Username] NVARCHAR(100) NOT NULL,
[Password] NVARCHAR(100) NOT NULL,
CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

-- Fill User table
INSERT INTO [User] SELECT 'Justin', 'Justintje', 'abc';
INSERT INTO [User] SELECT 'Roy', 'Roytje', 'def';
INSERT INTO [User] SELECT 'Typ', 'Typ', 'ghi';

-- Create Preferences table
CREATE TABLE [dbo].[Preferences](
[Id] INT IDENTITY (1, 1),
[OwnerId] INT NOT NULL,
[Length] DECIMAL(9,6) NOT NULL,
[HillType] INT NOT NULL,
[Marshiness] BIT NOT NULL,
[ForestDensity] INT NOT NULL,
[RouteFlatness] INT NOT NULL,
[RouteAsphalted] BIT NOT NULL,
[Roadsigns] INT NOT NULL,
CONSTRAINT [PK_Preferences] PRIMARY KEY ([Id]),
CONSTRAINT [FK_Preferences] FOREIGN KEY ([OwnerId]) REFERENCES [User] ([Id])
);

-- Fill Preferences table
INSERT INTO [Preferences] SELECT 1, 1, 0, 0, 0, 0, 0, 0;
INSERT INTO [Preferences] SELECT 2, 2, 1, 1, 1, 1, 1, 1;

-- Create Route table
CREATE TABLE [dbo].[Route](
[Id] INT IDENTITY (1, 1),
[OwnerId] INT NOT NULL,
[Difficulty] FLOAT NOT NULL,
[Name] NVARCHAR(100) NOT NULL,
[Length] DECIMAL(9,6) NOT NULL,
[StartLong] DECIMAL(9,6) NOT NULL,
[StartLat] DECIMAL(9,6) NOT NULL,
[EndLong] DECIMAL(9,6) NOT NULL,
[EndLat] DECIMAL(9,6) NOT NULL,
[Marshiness] BIT NOT NULL,
[RouteAsphalted] BIT NOT NULL,
[HillType] INT NOT NULL,
[ForestDensity] INT NOT NULL,
[RouteFlatness] INT NOT NULL,
[RoadSigns] INT NOT NULL,
CONSTRAINT [PK_Route] PRIMARY KEY ([Id]),
CONSTRAINT [FK_Route] FOREIGN KEY ([OwnerId]) REFERENCES [User] ([Id])
);

-- Fill Route table
INSERT INTO [Route] SELECT 1, 3, 'Makkelijke route door de 123-laan', 3, 5.979499, 50.888174, 5.931160, 50.879153,		0, 1, 2, 1, 1, 1;
INSERT INTO [Route] SELECT 2, 5, 'Middelmatige route door het abc-pad', 7.5, 4.979499, 60.888174, 4.931160, 60.879153,	0, 2, 2, 2, 1, 1;
INSERT INTO [Route] SELECT 3, 7, 'Moeilijke route door de !@#-straat', 11.75, 3.979499, 70.888174, 4.931160, 70.879153, 1, 2, 2, 2, 1, 2;

-- Create POI table
CREATE TABLE [dbo].[POI](
[Id] INT IDENTITY(1,1),
[RouteId] INT NOT NULL,
[Name] NVARCHAR(100) NOT NULL,
[Description] NVARCHAR(300) NOT NULL,
[Long] DECIMAL(9,6) NOT NULL,
[Lat] DECIMAL(9,6) NOT NULL,
CONSTRAINT [PK_POI] PRIMARY KEY ([Id]),
CONSTRAINT [FK_POI] FOREIGN KEY ([RouteId]) REFERENCES [Route] ([Id])
);

-- Fill POI table
INSERT INTO [POI] SELECT 1, 'POI van Makkelijke route door de 123-laan', 'Dit is een heel mooie steen.', 5.976499, 50.999174;

-- Create RouteSequence table
CREATE TABLE [dbo].[RouteSequence](
[Id] INT IDENTITY(1,1),
[RouteId] INT NOT NULL,
[Number] INT NOT NULL,
[Long] DECIMAL(9,6) NOT NULL,
[Lat] DECIMAL(9,6) NOT NULL,
CONSTRAINT [PK_RouteSequence] PRIMARY KEY ([Id]),
CONSTRAINT [FK_RouteSequence] FOREIGN KEY ([RouteId]) REFERENCES [Route] ([Id])
);

-- Fill RouteSequence Table
INSERT INTO [RouteSequence] SELECT 1, 1, 5.976499, 50.999174;
INSERT INTO [RouteSequence] SELECT 1, 2, 5.986499, 51.0;
INSERT INTO [RouteSequence] SELECT 1, 3, 5.996499, 51.1;