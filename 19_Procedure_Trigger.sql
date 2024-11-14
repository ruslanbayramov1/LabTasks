CREATE DATABASE AB108
USE AB108

CREATE TABLE Doctors
(
	Id int identity PRIMARY KEY,
	FirstName nvarchar(16) NOT NULL,
	LastName varchar(16) NOT NULL,
	Email varchar(16) NOT NULL,
	PhoneNumber varchar(32) NOT NULL,
	IsDeleted bit DEFAULT 0,
	CreatedAt datetime DEFAULT GETDATE(),
	LastModifiedDate datetime DEFAULT GETDATE()
)

ALTER TABLE Doctors
ALTER COLUMN FirstName varchar(16) NOT NULL

CREATE PROCEDURE DoctorsInsertProcedure
@FirstName varchar(16), @LastName varchar(16), 
@Email varchar(16), @PhoneNumber varchar(32)
AS
BEGIN
	INSERT INTO Doctors(FirstName, LastName, Email, PhoneNumber) VALUES
	(@FirstName, @LastName, @Email, @PhoneNumber)

	SELECT * FROM Doctors
END

EXEC DoctorsInsertProcedure 'Sebuhii', 'Sultanli', '@sebuhisul@gmail.com', '+994xxxxxxxxx'
EXEC DoctorsInsertProcedure 'AAAA', 'BBBBB', '@AAABBBB@gmail.com', '+994yyyyyyyyy'

CREATE TRIGGER AfterUpdateDoctors
ON Doctors
AFTER UPDATE
AS
BEGIN
	IF(SELECT isDeleted FROM inserted == 1)

	UPDATE Doctors
	SET LastModifiedDate = GETDATE()
	WHERE Id = (SELECT Id FROM inserted)
END

UPDATE Doctors
SET FirstName = 'AAA'
WHERE FirstName = 'AAAA'

CREATE TRIGGER InsteadOfDeleteDoctors
ON Doctors
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Doctors
	SET IsDeleted = 1
	WHERE Id IN (SELECT Id from deleted)
END

DELETE FROM Doctors
WHERE Id = 3
