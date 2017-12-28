USE Bank1

Select * FROM dbo.Autorization

Select * FROM dbo.Autorization WHERE Login = 'User'
Select * FROM Role 

Select * FROM Person 
Select * FROM OLD 


INSERT INTO OLD(Id_Person, First_name, Middle_name,Last_name,Date)
SELECT ID, [First Name], [Middle Name],[Last Name],GETDATE() FROM Person
Where ID = '7DD6ADD6-F3BB-457C-8418-604CDB47A5F8';

INSERT INTO (OLD.First_name , OLD.Middle_name , OLD.Last_name , OLD.Id_Person , OLD.Date )
SELECT Person.[First Name] , Person.[Middle Name], Person.[Last Name] , Person.ID , GETDATE() FROM Person


select Person.[First Name] , Person.[Middle Name] , Person.[Last Name] ,Bank_Account.Name , Payment.ID , Services.Name ,Connection_2.Data , Fillial.Name
from Person ,Connection ,Bank_Account,Payment ,Services , Connection_2 ,Fillial
Where Person.id = Connection.User_ID and Bank_Account.ID = Connection.Bank_ID and Connection.Payment_id = Payment.ID 
and Connection_2.Payment_id = Payment.ID and Services.Id=Connection_2.Service_id and Connection_2.Fillial_id = Fillial.ID



Select Person.[ID],Person.[First Name], Person.[Middle Name], Person.[Last Name], Bank_Account.Name, Bank_Account.ID, Payment_Type.Name,Payment.ID,Payment.Sum
FROM Person ,Connection,Payment,Payment_Type,Bank_Account
 WHERE Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID and Payment.Type_id = Payment_Type.id and Connection.Bank_ID=Bank_Account.ID

Select * FROM Payment_Type 

Select * FROM Payment
Select * FROM Connection_2

Select * FROM Connection
Select * FROM Services
Select * FROM Bank_Account 
Select * FROM Fillial 

Select Bank_Account.Name, Fillial.Name FROM Bank_Account, Connection_3, Fillial 
WHERE Bank_Account.ID = Connection_3.Bank_id and Fillial.ID = Connection_3.Fillial_id


SELECT Payment.ID , Person.ID FROM Person, Connection, Payment 
WHERE Person.ID='7dd6add6-f3bb-457c-8418-604cdb47a5f8' and Person.ID=Connection.User_ID and Connection.Payment_id = Payment.ID
--INSERT INTO Connection_3 VALUES('C40DECDE-4975-4FFB-B6CD-9AA78BD37F8C','EADBFD4F-3635-4785-AD9F-45F4D0AF6C69')
--INSERT INTO Connection_3 VALUES('C40DECDE-4975-4FFB-B6CD-9AA78BD37F8C','86AA4E9B-5359-41FF-8C01-4DBB4847AD4E')
--INSERT INTO Connection_3 VALUES('C40DECDE-4975-4FFB-B6CD-9AA78BD37F8C','1645CB31-1C74-41FB-9298-C35E8990E9A4')
--INSERT INTO Connection_3 VALUES('C40DECDE-4975-4FFB-B6CD-9AA78BD37F8C','AE135108-3DC1-4BA7-8878-FD38E1D50A76')


Select ID FROM Bank_Account  WHERE Name = 'ВТБ24'

Select Fillial.Name From Connection , Bank_Account, Connection_3,Fillial 
WHERE Connection.Payment_id = '938A3693-51F6-4370-9B15-B7EC3BC8C8F9' 
and Connection.Bank_ID=Bank_Account.ID 
and Bank_Account.ID = Connection_3.Bank_id 
and Connection_3.Fillial_id = Fillial.ID

Select Login,Password,Role FROM Role, Autorization WHERE Role.User_ID = Autorization.User_id

SELECT [User_id] FROM Autorization WHERE Login = 'User'
/*------------------------------------------------------------------------------------*/
INSERT INTO Connection_3 VALUES('CA1F0E01-5A7D-49BF-AC07-714709C1DB5D','93D05D73-36C3-47D7-B9EE-0BA27BEA5DA5')

INSERT INTO Fillial VALUES(NEWID(),'Вавилова')
INSERT INTO Services VALUES('Газ',NEWID(),700)
INSERT INTO Connection_3 VALUES(NEWID(),'Вавилова')

INSERT INTO Payment_Type VALUES(NEWID(),'Простой')


INSERT INTO Connection_2 VALUES('8B37FE78-FDFD-44D9-AEF6-069434C71E07','A6CFCE2B-0CB9-4F2A-AEA1-19F3C37D12BF','AC4B51A1-E9BD-4A01-966F-6EC371DE2ED7',GETDATE())


INSERT INTO Payment VALUES('Описание',NEWID(),'38F73295-6A41-46FC-9376-107DBE437C78',0)

INSERT INTO dbo.Bank_Account VALUES(NEWID(),'Альфа-Банк')

INSERT INTO Person VALUES ('Богдан','Купинский','Алексеевич',NEWID())

INSERT INTO Autorization VALUES ('User','User',NEWID())

INSERT INTO Connection VALUES ('7DD6ADD6-F3BB-457C-8418-604CDB47A5F8','938A3693-51F6-4370-9B15-B7EC3BC8C8F9','52F5DF38-7BDE-4CD4-BF09-01A92A9A5429')

INSERT INTO Person VALUES ('Вася','Пупкин','Петрович','7DD6ADD6-F3BB-457C-8418-604CDB47A5F8')			/* 7DD6ADD6-F3BB-457C-8418-604CDB47A5F8 */

INSERT INTO Role VALUES ('8BDF31CB-809E-4354-9799-6000E1E1B259' ,1)
/*----------------------------------------------------------------------------------------------------*/
DELETE FROM Autorization WHERE [Login] = '22'




DELETE FROM Connection_2 WHERE Payment_id = 'A6CFCE2B-0CB9-4F2A-AEA1-19F3C37D12BF' 
DELETE FROM Connection WHERE Payment_id = 'A6CFCE2B-0CB9-4F2A-AEA1-19F3C37D12BF'
Delete From Payment WHERE ID = 'A6CFCE2B-0CB9-4F2A-AEA1-19F3C37D12BF'


 Select * From Payment  --A6CFCE2B-0CB9-4F2A-AEA1-19F3C37D12BF
Select * From Connection_2


DELETE FROM Payment_Type WHERE Name = 'Простой' 

DELETE FROM Person WHERE [ID] = '7DD6ADD6-F3BB-457C-8418-604CDB47A5F8'

DELETE FROM Autorization WHERE [Login] = 'Admin'
/*---------------------------------------------------------------------*/
EXECUTE inserting '22','22'
 
EXECUTE selection

EXECUTE deletion '424EBD3E-981A-4532-A44F-45D7D725D281'

EXECUTE authorizationAdmin 'Admin','Admin'

EXECUTE selectuserinfo '7DD6ADD6-F3BB-457C-8418-604CDB47A5F8'

EXECUTE ServicesProce

EXECUTE changeinfo 'Вася','Пупкин','Петрович','7DD6ADD6-F3BB-457C-8418-604CDB47A5F8'
/*---------------------------------------------------------------------*/
DROP PROCEDURE authorizationAdmin

DROP PROCEDURE selectuserinfo 

DROP PROCEDURE ShowPayment

DROP PROCEDURE ServiceCost

DROP PROCEDURE Donate
/*-----------------------------------------------------------------*/
CREATE PROCEDURE selection
AS
BEGIN
Select * FROM Person 
END

CREATE PROCEDURE FindBankIdByName (@Name nvarchar(50)='',@ID UNIQUEIDENTIFIER=NEWID OUTPUT)
AS
BEGIN
SET @ID =  (Select ID FROM Bank_Account  WHERE Name = @Name)
END

CREATE PROCEDURE FindTypeIdByName (@Name nvarchar(50)='',@ID UNIQUEIDENTIFIER=NEWID OUTPUT)
AS
BEGIN
SET @ID =  (Select ID FROM Payment_Type  WHERE Name = @Name)
END

CREATE PROCEDURE CreatePayment 
(@Text nvarchar(50) = '', @Paymentid UNIQUEIDENTIFIER = NEWID,
 @Sum int = 0 ,@Userid UNIQUEIDENTIFIER = NEWID,@Bankid UNIQUEIDENTIFIER = NEWID)
AS
BEGIN
DECLARE @n UNIQUEIDENTIFIER 
SET @n = NEWID()
INSERT INTO Payment VALUES(@Text,@n,@Paymentid,@Sum)
INSERT INTO Connection VALUES (@Userid,@n,@Bankid)
END

CREATE PROCEDURE CreatePaymentConnection (@idUser UNIQUEIDENTIFIER = NEWID, @idBank UNIQUEIDENTIFIER = NEWID, @idPayment UNIQUEIDENTIFIER = NEWID )
AS
BEGIN
INSERT INTO Connection VALUES (@idUser,@idPayment,@idBank)
END



CREATE PROCEDURE selectuserinfo(@UserId UNIQUEIDENTIFIER = NEWID)
AS
BEGIN
Select * FROM Person WHERE ID = @UserId
END

CREATE PROCEDURE authorizationAdmin
(@Login nvarchar(50)='Admin',@Password nvarchar(50)='Admin',@Role int =-1 OUTPUT,@UserId UNIQUEIDENTIFIER= NEWID OUTPUT)
AS
BEGIN
SET @Role = (Select Role.Role FROM Autorization, Role WHERE Autorization.[Login] = @Login and Autorization.[Password] = @Password and Role.User_ID = Autorization.User_id)
SET @UserId = (Select Autorization.User_id FROM Autorization, Role WHERE Autorization.[Login] = @Login and Autorization.[Password] = @Password and Role.User_ID = Autorization.User_id)
END

CREATE PROCEDURE selection
AS
BEGIN
Select Autorization.Login,Autorization.Password,Autorization.User_id,Role.Role FROM Autorization ,Role WHERE Autorization.User_id=Role.User_ID
END

CREATE PROCEDURE inserting
(@Login nvarchar(50)='Admin',@Password nvarchar(50)='Admin')
AS
BEGIN
DECLARE @n uniqueidentifier 
SET  @n = NEWID();
INSERT INTO Autorization VALUES (@Login,@Password,@n)
INSERT INTO Role VALUES (@n,1)
END
-----------------------------------------------------------------------------------------------------------
DROP PROCEDURE deletion
CREATE PROCEDURE deletion (@id uniqueidentifier )
AS
BEGIN
DELETE FROM OLD WHERE [Id_Person] = @id
DELETE FROM Person WHERE [ID] = @id
DELETE FROM Role WHERE [User_ID] = @id
DELETE FROM Autorization WHERE [User_id] = @id
END
-------------------------------------------------------------------------------------------------------------------------------------------
/*Выбрать тип банка*/
CREATE PROCEDURE selectbanks 
AS
BEGIN
Select Name FROM Bank_Account 
END
/*Выбрать тип счета*/
CREATE PROCEDURE selectpaymenttips 
AS
BEGIN
Select Name FROM Payment_Type
END
 DROP PROCEDURE changeinfo
/*Сменить данные пользователя*/
CREATE PROCEDURE changeinfo (@Name nvarchar(50)='',@SerName nvarchar(50)='', @LastName nvarchar(50)='', @id uniqueidentifier = newid )
AS
BEGIN
If Exists (SELECT * FROM Person WHERE ID = @id )
UPDATE Person SET [First Name] = @Name, [Middle Name] = @SerName,[Last Name]= @LastName WHERE Person.ID=@id
ELSE
INSERT INTO Person VALUES (@Name,@SerName,@LastName,@id)
END
/*Показать счета пользователя*/
CREATE PROCEDURE ShowPayment (@id uniqueidentifier = newid )
AS
BEGIN
Select Person.[First Name], Person.[Middle Name], Person.[Last Name], Bank_Account.Name,Payment_Type.Name,Payment.Sum,Payment.ID
FROM Person ,Connection,Payment,Payment_Type,Bank_Account
 WHERE Person.ID=@id and Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID and Payment.Type_id = Payment_Type.id and Connection.Bank_ID=Bank_Account.ID
END

 /*Пополнение счета на определенную сумму*/
CREATE PROCEDURE Donate (@id uniqueidentifier = newid , @sum int = 0)
AS
BEGIN
IF Exists(Select * From Payment WHERE ID=@id)
UPDATE Payment SET Sum = Sum+@sum WHERE ID=@id
END

 /*Проверка счета на наличие денег*/
CREATE PROCEDURE HowMuchIHave (@id uniqueidentifier = newid,@sum int =0 OUTPUT)
AS
BEGIN
IF Exists(Select * From Payment WHERE ID=@id)
SET @sum =(Select Payment.sum FROM Payment WHERE ID=@id)
END


CREATE PROCEDURE FindFillial (@id uniqueidentifier = newid)
AS
BEGIN
Select Fillial.Name From Connection , Bank_Account, Connection_3,Fillial 
WHERE Connection.Payment_id = @id 
and Connection.Bank_ID=Bank_Account.ID 
and Bank_Account.ID = Connection_3.Bank_id 
and Connection_3.Fillial_id = Fillial.ID
END

CREATE PROCEDURE ServicesProce 
AS
BEGIN
Select Name From Services
END

CREATE PROCEDURE ServiceCost(@Name nvarchar(50) = '',@Sum int = 0 OUTPUT) 
AS
BEGIN
SET @SUM = (Select Sum From Services WHERE Name = @Name)
END


CREATE PROCEDURE Pay(@ServiceId uniqueidentifier = NEWID,@PaymentId uniqueidentifier = NEWID,@FillialId uniqueidentifier = NEWID) 
AS
BEGIN
INSERT INTO Connection_2 VALUES(@ServiceId,@PaymentId,@FillialId,GETDATE())
END

CREATE PROCEDURE FindServId (@name nvarchar(50) = '',@id uniqueidentifier = newid oUTPUT)
AS
BEGIN
SET @id = (Select id From Services 
WHERE Name = @name)
END

CREATE PROCEDURE FindFillialId (@name nvarchar(50) = '',@id uniqueidentifier = newid oUTPUT)
AS
BEGIN
SET @id = (Select ID From Fillial 
WHERE Name = @name)
END

CREATE PROCEDURE ShowMyServices (@id uniqueidentifier = newid)
AS
BEGIN
select Person.[First Name] , Person.[Middle Name] , Person.[Last Name] ,Bank_Account.Name , Payment.ID , Services.Name ,Connection_2.Data , Fillial.Name
from Person ,Connection ,Bank_Account,Payment ,Services , Connection_2 ,Fillial
Where Person.id = @id and Person.id = Connection.User_ID and Bank_Account.ID = Connection.Bank_ID and Connection.Payment_id = Payment.ID 
and Connection_2.Payment_id = Payment.ID and Services.Id=Connection_2.Service_id and Connection_2.Fillial_id = Fillial.ID
END


CREATE PROCEDURE ClosePayment (@id uniqueidentifier = newid)
AS
BEGIN
DELETE FROM Connection_2 WHERE Payment_id = @id 
DELETE FROM Connection WHERE Payment_id = @id
Delete From Payment WHERE ID = @id
END

DROP PROCEDURE Copy

CREATE PROCEDURE Copy (@id uniqueidentifier = newid)
AS
BEGIN
INSERT INTO OLD(Id_Person, First_name, Middle_name,Last_name,Date)
SELECT ID, [First Name], [Middle Name],[Last Name],GETDATE() FROM Person
Where ID = @id;
END

DROP PROCEDURE CheckUser
CREATE PROCEDURE CheckUser (@name nvarchar(50) = '')
AS
BEGIN
If Exists (
Select * FROM dbo.Autorization WHERE Login = @name)
return 0
Else return 1
end

CREATE PROCEDURE ReturnRole (@id uniqueidentifier = newid , @role int =0 OUTPUT)
AS
BEGIN
SET @role = (Select Role.Role From Role Where User_ID=@id)
END


CREATE PROCEDURE ShowUsersPaymentsToAdmin 
AS
BEGIN
Select Person.[ID],Person.[First Name], Person.[Middle Name], Person.[Last Name], Bank_Account.Name, Bank_Account.ID, Payment_Type.Name,Payment.ID,Payment.Sum
FROM Person ,Connection,Payment,Payment_Type,Bank_Account
 WHERE Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID and Payment.Type_id = Payment_Type.id and Connection.Bank_ID=Bank_Account.ID
 END

 CREATE PROCEDURE ShowUsersServicesToAdmin 
AS
BEGIN
 Select Person.[ID],Person.[First Name], Person.[Middle Name], Person.[Last Name],Payment.ID,Services.Name,Connection_2.Data ,Fillial.Name
FROM Person ,Connection,Payment,Connection_2,Services,Fillial
 WHERE Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID 
 and Connection_2.Payment_id = Payment.ID and Services.Id = Connection_2.Service_id and Fillial.ID = Connection_2.Fillial_id
 END

 Select Person.[ID],Person.[First Name], Person.[Middle Name], Person.[Last Name],Payment.ID,Services.Name,Connection_2.Data ,Fillial.Name
FROM Person ,Connection,Payment,Connection_2,Services,Fillial
 WHERE Person.ID =Connection.User_ID and Connection.Payment_id=Payment.ID 
 and Connection_2.Payment_id = Payment.ID and Services.Id = Connection_2.Service_id and Fillial.ID = Connection_2.Fillial_id

 CREATE PROCEDURE ShowLogs 
AS
BEGIN
 Select * FROM OLD
 END

