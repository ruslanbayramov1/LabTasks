CREATE DATABASE Academy
USE Academy

CREATE TABLE Students
(
	Id int identity PRIMARY KEY,
	FirstName varchar(16) NOT NULL,
	LastName varchar(16) NOT NULL,
	DateOfBirth date,
	Username varchar(16) NOT NULL,
	[Password] varchar(16) NOT NULL,
	EnrollmentDate date,
)

CREATE TABLE Departments
(
	Id int identity PRIMARY KEY,
	DepartmentName varchar(28) UNIQUE NOT NULL,
)

CREATE TABLE Instructors
(
	Id int identity PRIMARY KEY,
	FirstName varchar(16) NOT NULL,
	LastName varchar(16) NOT NULL,
	HireDate date NOT NULL,
	DepartmentId int REFERENCES Departments(Id),
	Username varchar(16) NOT NULL,
	[Password] varchar(16) NOT NULL,
	PIN char(7) UNIQUE NOT NULL
)

CREATE TABLE Groups
(
	Id int identity PRIMARY KEY,
	GroupName varchar(16) UNIQUE NOT NULL,
	DepartmentId int REFERENCES Departments(Id),
	StartDate date,
	EndDate date
)

CREATE TABLE Enrollments
(
	Id int identity PRIMARY KEY,
	StudentId int REFERENCES Students(Id),
	GroupId int REFERENCES Groups(Id)
)

CREATE TABLE Classes
(
	Id int identity PRIMARY KEY,
	GroupId int REFERENCES Groups(Id),
	InstructorId int REFERENCES Instructors(Id),
	Schedule varchar(28) NOT NULL,
	RoomName varchar(28) NOT NULL
)

CREATE PROCEDURE CreateDepartment
@DepartmentName varchar(28)
AS
	INSERT INTO Departments(DepartmentName)
	VALUES(@DepartmentName)

EXEC CreateDepartment 'Web'
EXEC CreateDepartment 'IT'
EXEC CreateDepartment 'Cyber'
SELECT * FROM Departments

INSERT INTO Students (FirstName, LastName, DateOfBirth, Username, [Password], EnrollmentDate)
VALUES
('Alice', 'Johnson', '2000-05-15', 'alicej', 'password123', '2018-09-01'),
('Bob', 'Smith', '1999-10-20', 'bobsmith', 'secure456', '2017-08-15'),
('Charlie', 'Brown', '2001-02-05', 'charlieb', 'mypassword789', '2019-01-10');

INSERT INTO Instructors (FirstName, LastName, HireDate, DepartmentId, Username, [Password], PIN)
VALUES
('Dr. John', 'Doe', '2015-06-01', 1, 'johndoe', 'teacherpass1', '1234567'),
('Prof. Emily', 'Clark', '2012-08-22', 2, 'emilyclark', 'mathpass2', '2345678'),
('Dr. Mark', 'Taylor', '2017-03-14', 3, 'marktaylor', 'physicspass3', '3456789');

INSERT INTO Groups (GroupName, DepartmentId, StartDate, EndDate)
VALUES
('CS101', 1, '2023-01-10', '2023-05-20'),
('MATH202', 2, '2023-02-01', '2023-06-10'),
('PHYS303', 3, '2023-03-15', '2023-07-25');

INSERT INTO Classes (GroupId, InstructorId, Schedule, RoomName)
VALUES
(1, 1, 'MWF 9:00-10:00', 'Room 101'),
(2, 2, 'TTh 11:00-12:30', 'Room 202'),
(3, 3, 'MWF 1:00-2:00', 'Room 303'); 

INSERT INTO Enrollments (StudentId, GroupId)
VALUES
(1, 1),
(2, 2),
(3, 3); 

SELECT s.Id, FirstName, LastName, gr.GroupName, cl.Schedule, cl.RoomName FROM Students AS s
INNER JOIN Enrollments AS enr ON s.Id = enr.StudentId 
INNER JOIN Groups as gr ON enr.GroupId = gr.Id
INNER JOIN Classes as cl ON gr.Id = cl.GroupId
WHERE s.Id = 1

CREATE FUNCTION GetStudentById (@Id int)
RETURNS TABLE
AS
	RETURN
	(
		SELECT s.Id, FirstName, LastName, gr.GroupName, cl.Schedule, cl.RoomName FROM Students AS s
		INNER JOIN Enrollments AS enr ON s.Id = enr.StudentId 
		INNER JOIN Groups as gr ON enr.GroupId = gr.Id
		INNER JOIN Classes as cl ON gr.Id = cl.GroupId
		WHERE s.Id = @Id
	)

SELECT * FROM GetStudentById(1)