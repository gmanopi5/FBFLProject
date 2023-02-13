IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'FBFL_db')
BEGIN
	DROP DATABASE FBFL_db
	print '' print '*** dropping database FBFL_db'
END
GO

print '' print '*** creating database FBFL_db'
GO
CREATE DATABASE FBFL_db
GO
USE FBFL_db
GO

/* Member table */
print '' print '*** creating Member table'
GO
CREATE TABLE [dbo].[Member] 
(
	[MemberID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[Name]			[nvarchar](100)				NOT NULL,
	[Phone]			[nvarchar](13)				NOT NULL,
	[Email]			[nvarchar](100)				NOT NULL,
	[PasswordHash]	[nvarchar](100)				NOT NULL DEFAULT 
		'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	CONSTRAINT 		[pk_MemberID] PRIMARY KEY ([MemberID]),
	CONSTRAINT		[ak_Email] UNIQUE ([Email])
)
GO

/* Member test records */
print '' print '*** creating Member test records'
GO
INSERT INTO [dbo].[Member]
		([Name], [Phone], [Email])
	VALUES
		('Ray Smith', '3195551111', 'ray@fbfl.com'),
		('Ryan Jones', '3195552222', 'ryan@fbfl.com')
GO

/* Role table */
print '' print '*** creating Role table'
GO
CREATE TABLE [dbo].[Role] 
(
	[RoleID]			[nvarchar](50)				NOT NULL,
	[Description]		[nvarchar](250)				NOT NULL,
	CONSTRAINT 			[pk_RoleID] PRIMARY KEY ([RoleID])
)
GO

/* create sample role records */
print '' print '*** creating sample role records'
GO
INSERT INTO [dbo].[Role]
		([RoleID], [Description])
	VALUES
		('Commissioner', 'Decides the type of fantasy league they are running and to set rules regarding scoring and trades ahead of the start of each season.'),
		('Manager', 'Manages a league team')
GO

/* MemberRole table */
print '' print '*** creating MemberRole join table'
GO
CREATE TABLE [dbo].[MemberRole] 
(
	[MemberID]		[int] 						NOT NULL,
	[RoleID]			[nvarchar](50)				NOT NULL,
	CONSTRAINT 			[fk_MemberRole_MemberID] 
		FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Member]([MemberID]),
	CONSTRAINT 			[fk_MemberRole_RoleID] 
		FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role]([RoleID]),
	CONSTRAINT			[pk_MemberRole]
		PRIMARY KEY ([MemberID], [RoleID])
)
GO

/* create sample MemberRole records */
print '' print '*** creating sample MemberRole records'
GO
INSERT INTO [dbo].[MemberRole]
		([MemberID], [RoleID])
	VALUES
		(100000, 'Commissioner'),
		(100001, 'Manager')
GO

/* login-related stored procedure */
print '' print '*** creating sp_authenticate_user'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
(
	@Email 				[nvarchar](100),
	@PasswordHash		[nvarchar](100)
)
AS
	BEGIN
		SELECT 	COUNT([MemberID]) as 'Authenticated'
		FROM	[Member]
		WHERE	@Email = [Email]
		  AND	@PasswordHash = [PasswordHash]
	END
GO

print '' print '*** creating sp_select_user_by_email'
GO
CREATE PROCEDURE [dbo].[sp_select_user_by_email]
(
	@Email		[nvarchar](100)
)
AS
	BEGIN
		SELECT 	[MemberID], [Name], [Phone], [Email]
		FROM	[Member]
		WHERE	@Email = [Email]
	END
GO

print '' print '*** creating sp_select_roles_by_memberid'
GO
CREATE PROCEDURE [dbo].[sp_select_roles_by_memberid]
(
	@MemberID		[int]
)
AS
	BEGIN
		SELECT 	[RoleID]
		FROM	[MemberRole]
		WHERE	@MemberID = [MemberID]
	END
GO

print '' print '*** creating sp_update_passwordHash'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordHash]
(
	@MemberID				[int],
	@PasswordHash			[nvarchar](100),
	@OldPasswordHash		[nvarchar](100)
)
AS
	BEGIN
		UPDATE 	[Member]
		  SET 	[PasswordHash] = 	@PasswordHash
		WHERE	@MemberID = 		[MemberID]
		  AND	@OldPasswordHash = 	[PasswordHash]
		  
		RETURN 	@@ROWCOUNT
	END
GO

/* QB table */
print '' print '*** creating QB table'
GO
CREATE TABLE [dbo].[QB] 
(
	[QuarterBackID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[QBName]			[nvarchar](100)				NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL,
	[Status]			[nvarchar](100)				NOT NULL,
	[PlayerExp]			[nvarchar](2)				NOT NULL,
	[College]			[nvarchar](50)				NOT NULL,
	
	CONSTRAINT 		[pk_QuarterBackID] PRIMARY KEY ([QuarterBackID])
)
GO

/* QB test records */
print '' print '*** creating QB test records'
GO
INSERT INTO [dbo].[QB]
		([QBName], [Team], [Status], [PlayerExp], [College])
	VALUES
		('Joe Shmoe', 'Potatoes', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Sharks', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Chickens', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monkeys', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monty Pyton Rabbits', 'Active', 'R', 'UNI')
GO

print '' print '*** creating sp_select_all_quarterbacks'
GO
CREATE PROCEDURE [dbo].[sp_select_all_quarterbacks]
AS
	BEGIN
		SELECT [QuarterBackID],[QBName],[Team],[Status],[PlayerExp],[College]
		FROM   [dbo].[QB]
	END
GO

/* RB table */
print '' print '*** creating RB table'
GO
CREATE TABLE [dbo].[RB] 
(
	[RunningBackID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[RBName]			[nvarchar](100)				NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL,
	[Status]			[nvarchar](100)				NOT NULL,
	[PlayerExp]			[nvarchar](2)				NOT NULL,
	[College]			[nvarchar](50)				NOT NULL,
	
	CONSTRAINT 		[pk_RunningBackID] PRIMARY KEY ([RunningBackID])
)
GO

/* RB test records */
print '' print '*** creating RB test records'
GO
INSERT INTO [dbo].[RB]
		([RBName], [Team], [Status], [PlayerExp], [College])
	VALUES
		('Joe Shmoe', 'Potatoes', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Sharks', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Chickens', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monkeys', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monty Pyton Rabbits', 'Active', 'R', 'UNI')
GO

print '' print '*** creating sp_select_all_runningbacks'
GO
CREATE PROCEDURE [dbo].[sp_select_all_runningbacks]
AS
	BEGIN
		SELECT [RunningBackID],[RBName],[Team],[Status],[PlayerExp],[College]
		FROM   [dbo].[RB]
	END
GO

/* WR table */
print '' print '*** creating WR table'
GO
CREATE TABLE [dbo].[WR] 
(
	[WideReceiverID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[WRName]			[nvarchar](100)				NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL,
	[Status]			[nvarchar](100)				NOT NULL,
	[PlayerExp]			[nvarchar](2)				NOT NULL,
	[College]			[nvarchar](50)				NOT NULL,
	
	CONSTRAINT 		[pk_WideReceiverID] PRIMARY KEY ([WideReceiverID])
)
GO

/* WR test records */
print '' print '*** creating WR test records'
GO
INSERT INTO [dbo].[WR]
		([WRName], [Team], [Status], [PlayerExp], [College])
	VALUES
		('Joe Shmoe', 'Potatoes', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Sharks', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Chickens', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monkeys', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monty Pyton Rabbits', 'Active', 'R', 'UNI')
GO

print '' print '*** creating sp_select_all_widereceivers'
GO
CREATE PROCEDURE [dbo].[sp_select_all_widereceivers]
AS
	BEGIN
		SELECT [WideReceiverID],[WRName],[Team],[Status],[PlayerExp],[College]
		FROM   [dbo].[WR]
	END
GO

/* TE table */
print '' print '*** creating TE table'
GO
CREATE TABLE [dbo].[TE] 
(
	[TideEndID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[TEName]			[nvarchar](100)				NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL,
	[Status]			[nvarchar](100)				NOT NULL,
	[PlayerExp]			[nvarchar](2)				NOT NULL,
	[College]			[nvarchar](50)				NOT NULL,
	
	CONSTRAINT 		[pk_TideEndID] PRIMARY KEY ([TideEndID])
)
GO

/* TE test records */
print '' print '*** creating TE test records'
GO
INSERT INTO [dbo].[TE]
		([TEName], [Team], [Status], [PlayerExp], [College])
	VALUES
		('Joe Shmoe', 'Potatoes', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Sharks', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Chickens', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monkeys', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monty Pyton Rabbits', 'Active', 'R', 'UNI')
GO

print '' print '*** creating sp_select_all_tideends'
GO
CREATE PROCEDURE [dbo].[sp_select_all_tideends]
AS
	BEGIN
		SELECT [TideEndID],[TEName],[Team],[Status],[PlayerExp],[College]
		FROM   [dbo].[TE]
	END
GO

/* K table */
print '' print '*** creating K table'
GO
CREATE TABLE [dbo].[K] 
(
	[KickerID]			[int] IDENTITY(100000, 1)	NOT NULL,
	[KName]				[nvarchar](100)				NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL,
	[Status]			[nvarchar](100)				NOT NULL,
	[PlayerExp]			[nvarchar](2)				NOT NULL,
	[College]			[nvarchar](50)				NOT NULL,
	
	CONSTRAINT 		[pk_KickerID] PRIMARY KEY ([KickerID])
)
GO

/* K test records */
print '' print '*** creating K test records'
GO
INSERT INTO [dbo].[K]
		([KName], [Team], [Status], [PlayerExp], [College])
	VALUES
		('Joe Shmoe', 'Potatoes', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Sharks', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Chickens', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monkeys', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monty Pyton Rabbits', 'Active', 'R', 'UNI')
GO

print '' print '*** creating sp_select_all_kickers'
GO
CREATE PROCEDURE [dbo].[sp_select_all_kickers]
AS
	BEGIN
		SELECT [KickerID],[KName],[Team],[Status],[PlayerExp],[College]
		FROM   [dbo].[K]
	END
GO

/* DL table */
print '' print '*** creating DL table'
GO
CREATE TABLE [dbo].[DL] 
(
	[DefensiveLinemenID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[DLName]			[nvarchar](100)				NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL,
	[Status]			[nvarchar](100)				NOT NULL,
	[PlayerExp]			[nvarchar](2)				NOT NULL,
	[College]			[nvarchar](50)				NOT NULL,
	
	CONSTRAINT 		[pk_DefensiveLinemenID] PRIMARY KEY ([DefensiveLinemenID])
)
GO

/* DL test records */
print '' print '*** creating DL test records'
GO
INSERT INTO [dbo].[DL]
		([DLName], [Team], [Status], [PlayerExp], [College])
	VALUES
		('Joe Shmoe', 'Potatoes', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Sharks', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Chickens', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monkeys', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monty Pyton Rabbits', 'Active', 'R', 'UNI')
GO

print '' print '*** creating sp_select_all_defensivelinemen'
GO
CREATE PROCEDURE [dbo].[sp_select_all_defensivelinemen]
AS
	BEGIN
		SELECT [DefensiveLinemenID],[DLName],[Team],[Status],[PlayerExp],[College]
		FROM   [dbo].[DL]
	END
GO

/* LB table */
print '' print '*** creating LB table'
GO
CREATE TABLE [dbo].[LB] 
(
	[LinebackerID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[LBName]			[nvarchar](100)				NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL,
	[Status]			[nvarchar](100)				NOT NULL,
	[PlayerExp]			[nvarchar](2)				NOT NULL,
	[College]			[nvarchar](50)				NOT NULL,
	
	CONSTRAINT 		[pk_LinebackerID] PRIMARY KEY ([LinebackerID])
)
GO

/* LB test records */
print '' print '*** creating LB test records'
GO
INSERT INTO [dbo].[LB]
		([LBName], [Team], [Status], [PlayerExp], [College])
	VALUES
		('Joe Shmoe', 'Potatoes', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Sharks', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Chickens', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monkeys', 'Active', 'R', 'UNI'),
		('Joe Shmoe', 'Monty Pyton Rabbits', 'Active', 'R', 'UNI')
GO

print '' print '*** creating sp_select_all_linebackers'
GO
CREATE PROCEDURE [dbo].[sp_select_all_linebackers]
AS
	BEGIN
		SELECT [LinebackerID],[LBName],[Team],[Status],[PlayerExp],[College]
		FROM   [dbo].[LB]
	END
GO

/* DE table */
print '' print '*** creating DE table'
GO
CREATE TABLE [dbo].[DE] 
(
	[DefenseID]			[int] IDENTITY(100000, 1)	NOT NULL,
	[Team]				[nvarchar](100)				NOT NULL
	
	CONSTRAINT 		[pk_DefenseID] PRIMARY KEY ([DefenseID])
)
GO

/* DE test records */
print '' print '*** creating DE test records'
GO
INSERT INTO [dbo].[DE]
		([Team])
	VALUES
		('Potatoes'),
		('Sharks'),
		('Chickens'),
		('Monkeys'),
		('Monty Pyton Rabbits')
GO

print '' print '*** creating sp_select_all_defenseteams'
GO
CREATE PROCEDURE [dbo].[sp_select_all_defenseteams]
AS
	BEGIN
		SELECT [DefenseID], [Team]
		FROM   [dbo].[DE]
	END
GO

/*TeamRoster Table*/
/*print '' print '*** creating TeamRoster Table'
GO
CREATE TABLE [dbo].[TeamRoster] 
(
	[MemberID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[Position]		[nvarchar](100)				NOT NULL,
	[Name]			[nvarchar](100)				NOT NULL,
	
	CONSTRAINT [pk_MemberID] PRIMARY KEY([memberID]),
	CONSTRAINT [fk_Member] FOREIGN KEY([Member]) REFERENCES [Member]([MemberID]),
)

print '' print '*** creating TeamRoster test records'
GO
INSERT INTO [dbo].[TeamRoster]
		([MemberID], [Position], [QBName])
	VALUES
		("1000", 'Quarterback', 'Joe Shmoe')
GO*/