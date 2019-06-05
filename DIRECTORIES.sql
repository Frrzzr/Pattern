CREATE DATABASE PhoneDirectory;
USE PhoneDirectory

DROP TABLE DETAILS_ABOUT_USERS
CREATE TABLE DETAILS_ABOUT_USERS (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Nickname VARCHAR(100) NOT NULL,
	PhoneNumber VARCHAR(100) NOT NULL,
	MobileNumber VARCHAR(100) NOT NULL,
	EmailAddress VARCHAR(100) NOT NULL,
	HomeAddress VARCHAR(100) NOT NULL,
	Company VARCHAR(100) NOT NULL,
	Position VARCHAR(100) NOT NULL,
	GroupName VARCHAR(100) NOT NULL,
	Website VARCHAR(100) NOT NULL,
	FacebookAccount VARCHAR(100) NOT NULL,
	Remarks VARCHAR(100) NOT NULL
)

DROP TABLE USERS;
CREATE TABLE USERS (
	USERNAME VARCHAR(90) NOT NULL PRIMARY KEY,
	PASS VARCHAR(60) NOT NULL
)
DROP TABLE Developers;
DROP TRIGGER NO_MORE_INSERT
CREATE TRIGGER NO_MORE_INSERT ON Developers
FOR INSERT AS
BEGIN
	RAISERROR ('KDJFHFJKDHJKFD', 16,1)
	ROLLBACK TRANSACTION
END
DROP TRIGGER NO_MORE_UPDATE
CREATE TRIGGER NO_MORE_UPDATE ON Developers
FOR UPDATE AS
BEGIN
	RAISERROR ('KDJFHFJKDHJKFD', 16,1)
	ROLLBACK TRANSACTION
END

CREATE TABLE Developers (
	ID VARCHAR(11) NOT NULL PRIMARY KEY,
	NAME VARCHAR(50) NOT NULL,
	DEPARTMENT VARCHAR(90) NOT NULL DEFAULT 'INFORMATION SYSTEM',
	PHONE INT DEFAULT NULL,
	COURSE VARCHAR(100) NOT NULL DEFAULT 'EVENT DRIVEN PROGRAMMING',
	DUE_DATE DATE DEFAULT NULL,
	PROJECT_NAME VARCHAR(100) DEFAULT 'DIGITAL MULTI-USER PHONE DIRECTORY SYSTEM',
	EMAIL VARCHAR(100) DEFAULT NULL
)

--ALTER TABLE USERS ADD PK_USERNAME VARCHAR(89) PRIMARY KEY
ALTER TABLE DETAILS_ABOUT_USERS ADD FK_USERNAME VARCHAR(90) NOT NULL FOREIGN KEY REFERENCES USERS(USERNAME)
ALTER TABLE USERS ADD EMAIL VARCHAR(90) DEFAULT NULL


INSERT INTO USERS(USERNAME, PASS)
			VALUES ('PROJECT', 'EDEN'),
				   ('FROZEN', 'CLOUD'),
				   ('ADMIN', 'ADMIN'),
				   ('DEFAULT', 'DEFAULT')
				   
				   
INSERT INTO DETAILS_ABOUT_USERS (Id,  Name,                 Nickname,      PhoneNumber,   MobileNumber,  EmailAddress,                 HomeAddress,   Company,          Position,       GroupName,   Website,                    FacebookAccount,   Remarks,   FK_USERNAME) 
            VALUES
								(1,   'Asegid belew',       'reta',        '224-1234',    '09486013158', '',                           '',           'Gordon College', 'Student',      'Family',    'www.w3school.com',          '',                'Deleted', 'PROJECT'),
								(2,   'Mulualem Gelaw',     'merek',       '224-4321',    '09194298959', 'mulerwello@gmail.com',       '',           'Gordon College', 'Student',      'Family',    'www.ubuntu.com',            '',                '',        'PROJECT'),
								(3,   'Fentaw Hailu',       'kewus',       '2248-154',    '09279816975', 'fentaw.hailu@gmail.com.com', '',           'Gordon College', 'Student',      'Family',    'www.stackoverflow.com',     '',                '',        'PROJECT'),
								(4,   'Frezer Yirga',       'Awtulgn',     '224-1211',    '09995463721', 'frazieryirka@gmail.com',     '',           'Gordon College', 'Student',      'Classmate', 'www.godaddy.com',           '',                '',        'PROJECT'),
								(5,   'Ntsuh Sme',          'ntsi',        '556-777-009', '09498528089', '',                           '',           'MWSI',           'Board Leader', 'Student',   'www.thehiddenwiki.com',     '',                '',        'PROJECT'),
								(6,   'Minilik Demle',      'M',           '777-008-666', '09638838384', '',                           '',           'MWSI',           'Board Leader', 'Student',   'www.torproject.org',        '',                '',        'PROJECT'),
								(7,   'Mandefro Weret',     'manda',       '888-543-123', '09123456782', '',                           '',           'RTW',            'Manager',      'Classmate', 'www.wikihow.com',           '',                '',        'PROJECT'),
								(8,   'Yaregal Bante',      'kewus2',      '123-345-897', '09563893782', '',                           '',           'RTW',            'President',    'Family',    'www.wikileaks.com',         '',                '',        'PROJECT'),
								(9,   'Abdu Gerema',        'Ebdu',        '556-577-444', '09364633738', '',                           '',           'MWSI',           'Manager',      'Family',    'www.thehackersnews.com',    '',                '',        'FROZEN'),
								(10,  'Milion Desalegn',    'serifam',     '556-444-890', '09343434343', '',                           '',           'MC',             'Teacher',      'Family',    'www.hackersonlineclub.com', '',                '',        'FROZEN'),
								(11,  'Mikiyas Eshetu',     'tlanian',     '122-898-566', '09987653321', '',                           '',           'MWSI',           'Manager',      'Family',    'www.github.com',            '',                '',        'FROZEN'),
								(12,  'Abdulaziz Ahmed',    'knche',       '030-777-778', '09345633461', '',                           '',           'RTW',            'Manager',      'Student',   'www.softonic.com',          '',                '',        'FROZEN'),
								(13,  'Usman Seid',         'capitain',    '568-333-999', '09373773733', '',                           '',           'RTW',            'Manager',      'Family',    'www.bluehost.com',          '',                '',        'FROZEN'),
								(14,  'Adem Kebede',        'alex',        '888-544-098', '09303030494', '',                           '',           'MWSI',           'Teacher',      'Classmate', 'www.digitalocean.com',      '',                '',        'FROZEN'),
								(15,  'Alemayehu Mulugeta', 'Kiko',        '743-344-466', '09236464747', '',                           '',           'RTW',            'Manager',      'Family',    'www.archlinux.org',         '',                '',        'FROZEN'),
								(16,  'Eden Alive',         'edu',         '443-775-544', '09373222227', '',                           '',           'MWSI',           'President',    'Family',    'www.wordpress.com',         '',                '',        'FROZEN'),
								(17,  'Heaven Here',        'hevi',        '003-344-005', '09444449223', '',                           '',           'RTW',            'President',    'Classmate', 'www.quircky.com',           '',                '',        'FROZEN'),
								(19,  'Markan Markon',      'mar',         '000-000-000', '32904823906', '',                           '',           'KKK',            'President',    'Classmate', 'www.yenepay.com',           '',                '',        'FROZEN');
								
								
								
	
CREATE PROCEDURE dbo.uspAddUser
    @pLogin NVARCHAR(50), 
    @pPassword NVARCHAR(50), 
    @pFirstName NVARCHAR(40) = NULL, 
    @pLastName NVARCHAR(40) = NULL,
    @responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY

        INSERT INTO dbo.[User] (LoginName, PasswordHash, FirstName, LastName)
        VALUES(@pLogin, HASHBYTES('SHA2_512', @pPassword), @pFirstName, @pLastName)

        SET @responseMessage='Success'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END




DECLARE @responseMessage NVARCHAR(250)

EXEC dbo.uspAddUser
          @pLogin = N'Admin',
          @pPassword = N'123',
          @pFirstName = N'Admin',
          @pLastName = N'Administrator',
          @responseMessage=@responseMessage OUTPUT

SELECT *
FROM [dbo].[User]



ALTER TABLE dbo.[User] ADD Salt UNIQUEIDENTIFIER 
GO

ALTER PROCEDURE dbo.uspAddUser
    @pLogin NVARCHAR(50), 
    @pPassword NVARCHAR(50),
    @pFirstName NVARCHAR(40) = NULL, 
    @pLastName NVARCHAR(40) = NULL,
    @responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @salt UNIQUEIDENTIFIER=NEWID()
    BEGIN TRY

        INSERT INTO dbo.[User] (LoginName, PasswordHash, Salt, FirstName, LastName)
        VALUES(@pLogin, HASHBYTES('SHA2_512', @pPassword+CAST(@salt AS NVARCHAR(36))), @salt, @pFirstName, @pLastName)

       SET @responseMessage='Success'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END


TRUNCATE TABLE [dbo].[User]

DECLARE @responseMessage NVARCHAR(250)

EXEC dbo.uspAddUser
          @pLogin = N'Admin',
          @pPassword = N'123',
          @pFirstName = N'Admin',
          @pLastName = N'Administrator',
          @responseMessage=@responseMessage OUTPUT

SELECT UserID, LoginName, PasswordHash, Salt, FirstName, LastName
FROM [dbo].[User]

CREATE PROCEDURE dbo.uspLogin
    @pLoginName NVARCHAR(254),
    @pPassword NVARCHAR(50),
    @responseMessage NVARCHAR(250)='' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @userID INT

    IF EXISTS (SELECT TOP 1 UserID FROM [dbo].[User] WHERE LoginName=@pLoginName)
    BEGIN
        SET @userID=(SELECT UserID FROM [dbo].[User] WHERE LoginName=@pLoginName AND PasswordHash=HASHBYTES('SHA2_512', @pPassword+CAST(Salt AS NVARCHAR(36))))

       IF(@userID IS NULL)
           SET @responseMessage='Incorrect password'
       ELSE 
           SET @responseMessage='User successfully logged in'
    END
    ELSE
       SET @responseMessage='Invalid login'

END


DECLARE	@responseMessage nvarchar(250)

--Correct login and password
EXEC	dbo.uspLogin
		@pLoginName = N'Admin',
		@pPassword = N'123',
		@responseMessage = @responseMessage OUTPUT

SELECT	@responseMessage as N'@responseMessage'

--Incorrect login
EXEC	dbo.uspLogin
		@pLoginName = N'Admin1', 
		@pPassword = N'123',
		@responseMessage = @responseMessage OUTPUT

SELECT	@responseMessage as N'@responseMessage'

--Incorrect password
EXEC	dbo.uspLogin
		@pLoginName = N'Admin', 
		@pPassword = N'1234',
		@responseMessage = @responseMessage OUTPUT

SELECT	@responseMessage as N'@responseMessage'