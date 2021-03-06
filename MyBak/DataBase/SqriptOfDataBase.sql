USE [master]
GO
/****** Object:  Database [Bank1]    Script Date: 28.12.2017 18:42:16 ******/
CREATE DATABASE [Bank1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bank1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Bank1.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bank1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Bank1_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bank1] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bank1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bank1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bank1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bank1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bank1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bank1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bank1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bank1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bank1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bank1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bank1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bank1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bank1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bank1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bank1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bank1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bank1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bank1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bank1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bank1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bank1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bank1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bank1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bank1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bank1] SET  MULTI_USER 
GO
ALTER DATABASE [Bank1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bank1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bank1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bank1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Bank1] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Bank1]
GO
/****** Object:  Table [dbo].[Autorization]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autorization](
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[User_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Autorization] PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bank_Account]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank_Account](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bank_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Connection]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connection](
	[User_ID] [uniqueidentifier] NOT NULL,
	[Payment_id] [uniqueidentifier] NOT NULL,
	[Bank_ID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Connection_2]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connection_2](
	[Service_id] [uniqueidentifier] NOT NULL,
	[Payment_id] [uniqueidentifier] NOT NULL,
	[Fillial_id] [uniqueidentifier] NOT NULL,
	[Data] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Connection_3]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connection_3](
	[Fillial_id] [uniqueidentifier] NOT NULL,
	[Bank_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fillial]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fillial](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Fillial] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OLD]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLD](
	[Id_Person] [uniqueidentifier] NOT NULL,
	[First_name] [nvarchar](50) NOT NULL,
	[Middle_name] [nvarchar](50) NOT NULL,
	[Last_name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Description] [nvarchar](50) NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[Type_id] [uniqueidentifier] NOT NULL,
	[Sum] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment_Type]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Type](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Payment_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[First Name] [nvarchar](50) NOT NULL,
	[Middle Name] [nvarchar](50) NOT NULL,
	[Last Name] [nvarchar](50) NOT NULL,
	[ID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 28.12.2017 18:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[User_ID] [uniqueidentifier] NOT NULL,
	[Role] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Name] [nvarchar](50) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Sum] [int] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Connection]  WITH CHECK ADD  CONSTRAINT [FK_Connection_Autorization] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Autorization] ([User_id])
GO
ALTER TABLE [dbo].[Connection] CHECK CONSTRAINT [FK_Connection_Autorization]
GO
ALTER TABLE [dbo].[Connection]  WITH CHECK ADD  CONSTRAINT [FK_Connection_Bank_Account] FOREIGN KEY([Bank_ID])
REFERENCES [dbo].[Bank_Account] ([ID])
GO
ALTER TABLE [dbo].[Connection] CHECK CONSTRAINT [FK_Connection_Bank_Account]
GO
ALTER TABLE [dbo].[Connection]  WITH CHECK ADD  CONSTRAINT [FK_Connection_Payment] FOREIGN KEY([Payment_id])
REFERENCES [dbo].[Payment] ([ID])
GO
ALTER TABLE [dbo].[Connection] CHECK CONSTRAINT [FK_Connection_Payment]
GO
ALTER TABLE [dbo].[Connection_2]  WITH CHECK ADD  CONSTRAINT [FK_Connection_2_Fillial] FOREIGN KEY([Fillial_id])
REFERENCES [dbo].[Fillial] ([ID])
GO
ALTER TABLE [dbo].[Connection_2] CHECK CONSTRAINT [FK_Connection_2_Fillial]
GO
ALTER TABLE [dbo].[Connection_2]  WITH CHECK ADD  CONSTRAINT [FK_Connection_2_Payment] FOREIGN KEY([Payment_id])
REFERENCES [dbo].[Payment] ([ID])
GO
ALTER TABLE [dbo].[Connection_2] CHECK CONSTRAINT [FK_Connection_2_Payment]
GO
ALTER TABLE [dbo].[Connection_2]  WITH CHECK ADD  CONSTRAINT [FK_Connection_2_Services] FOREIGN KEY([Service_id])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[Connection_2] CHECK CONSTRAINT [FK_Connection_2_Services]
GO
ALTER TABLE [dbo].[Connection_3]  WITH CHECK ADD  CONSTRAINT [FK_Connection_3_Bank_Account] FOREIGN KEY([Bank_id])
REFERENCES [dbo].[Bank_Account] ([ID])
GO
ALTER TABLE [dbo].[Connection_3] CHECK CONSTRAINT [FK_Connection_3_Bank_Account]
GO
ALTER TABLE [dbo].[Connection_3]  WITH CHECK ADD  CONSTRAINT [FK_Connection_3_Fillial] FOREIGN KEY([Fillial_id])
REFERENCES [dbo].[Fillial] ([ID])
GO
ALTER TABLE [dbo].[Connection_3] CHECK CONSTRAINT [FK_Connection_3_Fillial]
GO
ALTER TABLE [dbo].[OLD]  WITH CHECK ADD  CONSTRAINT [FK_OLD_Autorization] FOREIGN KEY([Id_Person])
REFERENCES [dbo].[Autorization] ([User_id])
GO
ALTER TABLE [dbo].[OLD] CHECK CONSTRAINT [FK_OLD_Autorization]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Payment_Type] FOREIGN KEY([Type_id])
REFERENCES [dbo].[Payment_Type] ([Id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Payment_Type]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Autorization] FOREIGN KEY([ID])
REFERENCES [dbo].[Autorization] ([User_id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Autorization]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Autorization] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Autorization] ([User_id])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_Autorization]
GO
/****** Object:  StoredProcedure [dbo].[authorizationAdmin]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[authorizationAdmin]
(@Login nvarchar(50)='Admin',@Password nvarchar(50)='Admin',@Role int =-1 OUTPUT,@UserId UNIQUEIDENTIFIER= NEWID OUTPUT)
AS
BEGIN
SET @Role = (Select Role.Role FROM Autorization, Role WHERE Autorization.[Login] = @Login and Autorization.[Password] = @Password and Role.User_ID = Autorization.User_id)
SET @UserId = (Select Autorization.User_id FROM Autorization, Role WHERE Autorization.[Login] = @Login and Autorization.[Password] = @Password and Role.User_ID = Autorization.User_id)
END
GO
/****** Object:  StoredProcedure [dbo].[changeinfo]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[changeinfo] (@Name nvarchar(50)='',@SerName nvarchar(50)='', @LastName nvarchar(50)='', @id uniqueidentifier = newid )
AS
BEGIN
If Exists (SELECT * FROM Person WHERE ID = @id )
UPDATE Person SET [First Name] = @Name, [Middle Name] = @SerName,[Last Name]= @LastName WHERE Person.ID=@id
ELSE
INSERT INTO Person VALUES (@Name,@SerName,@LastName,@id)
END
GO
/****** Object:  StoredProcedure [dbo].[CheckUser]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckUser] (@name nvarchar(50) = '')
AS
BEGIN
If Exists (
Select * FROM dbo.Autorization WHERE Login = @name)
return 0
Else return 1
end
GO
/****** Object:  StoredProcedure [dbo].[ClosePayment]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ClosePayment] (@id uniqueidentifier = newid)
AS
BEGIN
DELETE FROM Connection_2 WHERE Payment_id = @id 
DELETE FROM Connection WHERE Payment_id = @id
Delete From Payment WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Copy]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Copy] (@id uniqueidentifier = newid)
AS
BEGIN
INSERT INTO OLD(Id_Person, First_name, Middle_name,Last_name,Date)
SELECT ID, [First Name], [Middle Name],[Last Name],GETDATE() FROM Person
Where ID = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[CreatePayment]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreatePayment] 
(@Text nvarchar(50) = '', @Paymentid UNIQUEIDENTIFIER = NEWID,
 @Sum int = 0 ,@Userid UNIQUEIDENTIFIER = NEWID,@Bankid UNIQUEIDENTIFIER = NEWID)
AS
BEGIN
DECLARE @n UNIQUEIDENTIFIER 
SET @n = NEWID()
INSERT INTO Payment VALUES(@Text,@n,@Paymentid,@Sum)
INSERT INTO Connection VALUES (@Userid,@n,@Bankid)
END
GO
/****** Object:  StoredProcedure [dbo].[CreatePaymentConnection]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreatePaymentConnection] (@idUser UNIQUEIDENTIFIER = NEWID, @idBank UNIQUEIDENTIFIER = NEWID, @idPayment UNIQUEIDENTIFIER = NEWID )
AS
BEGIN
INSERT INTO Connection VALUES (@idUser,@idPayment,@idBank)
END
GO
/****** Object:  StoredProcedure [dbo].[deletion]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deletion] (@id uniqueidentifier )
AS
BEGIN
DELETE FROM OLD WHERE [Id_Person] = @id
DELETE FROM Person WHERE [ID] = @id
DELETE FROM Role WHERE [User_ID] = @id
DELETE FROM Autorization WHERE [User_id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Donate]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Donate] (@id uniqueidentifier = newid , @sum int = 0)
AS
BEGIN
IF Exists(Select * From Payment WHERE ID=@id)
UPDATE Payment SET Sum = Sum+@sum WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[FindBankIdByName]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindBankIdByName] (@Name nvarchar(50)='',@ID UNIQUEIDENTIFIER=NEWID OUTPUT)
AS
BEGIN
SET @ID =  (Select ID FROM Bank_Account  WHERE Name = @Name)
END
GO
/****** Object:  StoredProcedure [dbo].[FindFillial]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindFillial] (@id uniqueidentifier = newid)
AS
BEGIN
Select Fillial.Name From Connection , Bank_Account, Connection_3,Fillial 
WHERE Connection.Payment_id = @id 
and Connection.Bank_ID=Bank_Account.ID 
and Bank_Account.ID = Connection_3.Bank_id 
and Connection_3.Fillial_id = Fillial.ID
END
GO
/****** Object:  StoredProcedure [dbo].[FindFillialId]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindFillialId] (@name nvarchar(50) = '',@id uniqueidentifier = newid oUTPUT)
AS
BEGIN
SET @id = (Select ID From Fillial 
WHERE Name = @name)
END
GO
/****** Object:  StoredProcedure [dbo].[FindServId]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindServId] (@name nvarchar(50) = '',@id uniqueidentifier = newid oUTPUT)
AS
BEGIN
SET @id = (Select id From Services 
WHERE Name = @name)
END
GO
/****** Object:  StoredProcedure [dbo].[FindTypeIdByName]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindTypeIdByName] (@Name nvarchar(50)='',@ID UNIQUEIDENTIFIER=NEWID OUTPUT)
AS
BEGIN
SET @ID =  (Select ID FROM Payment_Type  WHERE Name = @Name)
END
GO
/****** Object:  StoredProcedure [dbo].[HowMuchIHave]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HowMuchIHave] (@id uniqueidentifier = newid,@sum int =0 OUTPUT)
AS
BEGIN
IF Exists(Select * From Payment WHERE ID=@id)
SET @sum =(Select Payment.sum FROM Payment WHERE ID=@id)
END
GO
/****** Object:  StoredProcedure [dbo].[inserting]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[inserting]
(@Login nvarchar(50)='Admin',@Password nvarchar(50)='Admin')
AS
BEGIN
DECLARE @n uniqueidentifier 
SET  @n = NEWID();
INSERT INTO Autorization VALUES (@Login,@Password,@n)
INSERT INTO Role VALUES (@n,1)
END
GO
/****** Object:  StoredProcedure [dbo].[Pay]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pay](@ServiceId uniqueidentifier = NEWID,@PaymentId uniqueidentifier = NEWID,@FillialId uniqueidentifier = NEWID) 
AS
BEGIN
INSERT INTO Connection_2 VALUES(@ServiceId,@PaymentId,@FillialId,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[ReturnRole]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReturnRole] (@id uniqueidentifier = newid , @role int =0 OUTPUT)
AS
BEGIN
SET @role = (Select Role.Role From Role Where User_ID=@id)
END
GO
/****** Object:  StoredProcedure [dbo].[selectbanks]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selectbanks] 
AS
BEGIN
Select Name FROM Bank_Account 
END
GO
/****** Object:  StoredProcedure [dbo].[selection]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selection]
AS
BEGIN
Select Autorization.Login,Autorization.Password,Autorization.User_id,Role.Role FROM Autorization ,Role WHERE Autorization.User_id=Role.User_ID
END
GO
/****** Object:  StoredProcedure [dbo].[selectpaymenttips]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selectpaymenttips] 
AS
BEGIN
Select Name FROM Payment_Type
END
GO
/****** Object:  StoredProcedure [dbo].[selectuserinfo]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[selectuserinfo](@UserId UNIQUEIDENTIFIER = NEWID)
AS
BEGIN
Select * FROM Person WHERE ID = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[ServiceCost]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ServiceCost](@Name nvarchar(50) = '',@Sum int = 0 OUTPUT) 
AS
BEGIN
SET @SUM = (Select Sum From Services WHERE Name = @Name)
END
GO
/****** Object:  StoredProcedure [dbo].[ServicesProce]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ServicesProce] 
AS
BEGIN
Select Name From Services
END
GO
/****** Object:  StoredProcedure [dbo].[ShowLogs]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ShowLogs] 
AS
BEGIN
 Select * FROM OLD
 END
GO
/****** Object:  StoredProcedure [dbo].[ShowMyServices]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowMyServices] (@id uniqueidentifier = newid)
AS
BEGIN
select Person.[First Name] , Person.[Middle Name] , Person.[Last Name] ,Bank_Account.Name , Payment.ID , Services.Name ,Connection_2.Data , Fillial.Name
from Person ,Connection ,Bank_Account,Payment ,Services , Connection_2 ,Fillial
Where Person.id = @id and Person.id = Connection.User_ID and Bank_Account.ID = Connection.Bank_ID and Connection.Payment_id = Payment.ID 
and Connection_2.Payment_id = Payment.ID and Services.Id=Connection_2.Service_id and Connection_2.Fillial_id = Fillial.ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowPayment]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowPayment] (@id uniqueidentifier = newid )
AS
BEGIN
Select Person.[First Name], Person.[Middle Name], Person.[Last Name], Bank_Account.Name,Payment_Type.Name,Payment.Sum,Payment.ID
FROM Person ,Connection,Payment,Payment_Type,Bank_Account
 WHERE Person.ID=@id and Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID and Payment.Type_id = Payment_Type.id and Connection.Bank_ID=Bank_Account.ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowUsersPaymentsToAdmin]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowUsersPaymentsToAdmin] 
AS
BEGIN
Select Person.[ID],Person.[First Name], Person.[Middle Name], Person.[Last Name], Bank_Account.Name, Bank_Account.ID, Payment_Type.Name,Payment.ID,Payment.Sum
FROM Person ,Connection,Payment,Payment_Type,Bank_Account
 WHERE Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID and Payment.Type_id = Payment_Type.id and Connection.Bank_ID=Bank_Account.ID
 END
GO
/****** Object:  StoredProcedure [dbo].[ShowUsersServicesToAdmin]    Script Date: 28.12.2017 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ShowUsersServicesToAdmin] 
AS
BEGIN
 Select Person.[ID],Person.[First Name], Person.[Middle Name], Person.[Last Name],Payment.ID,Services.Name,Connection_2.Data ,Fillial.Name
FROM Person ,Connection,Payment,Connection_2,Services,Fillial
 WHERE Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID 
 and Connection_2.Payment_id = Payment.ID and Services.Id = Connection_2.Service_id and Fillial.ID = Connection_2.Fillial_id
 END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Connection_3', @level2type=N'CONSTRAINT',@level2name=N'FK_Connection_3_Fillial'
GO
USE [master]
GO
ALTER DATABASE [Bank1] SET  READ_WRITE 
GO
