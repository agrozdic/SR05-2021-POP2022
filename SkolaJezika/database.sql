BEGIN TRANSACTION;

CREATE TABLE Administrator(
	JMBG VARCHAR(13) PRIMARY KEY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Gender VARCHAR(10) NOT NULL,
	Address INT NOT NULL,
	Email VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	UserType VARCHAR(10) NOT NULL,
	is_Active BIT NOT NULL
);

CREATE TABLE Student(
	JMBG VARCHAR(13) PRIMARY KEY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Gender VARCHAR(10) NOT NULL,
	Address INT NOT NULL,
	Email VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	UserType VARCHAR(10) NOT NULL,
	is_Active BIT NOT NULL
);

CREATE TABLE Teacher(
	JMBG VARCHAR(13) PRIMARY KEY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Gender VARCHAR(10) NOT NULL,
	Address INT NOT NULL,
	Email VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	UserType VARCHAR(10) NOT NULL,
	is_Active BIT NOT NULL,
	WorkingSchool INT NOT NULL
);

CREATE TABLE Address(
	Id INT PRIMARY KEY NOT NULL,
	Street VARCHAR(50) NOT NULL,
	StNumber INT NOT NULL,
	City VARCHAR(30) NOT NULL,
	Country VARCHAR(30) NOT NULL,
	is_Active BIT NOT NULL
);

ALTER TABLE Administrator ADD CONSTRAINT AAFK FOREIGN KEY (Address) REFERENCES Address(Id);

ALTER TABLE Student ADD CONSTRAINT SAFK FOREIGN KEY (Address) REFERENCES Address(Id);

ALTER TABLE Teacher ADD CONSTRAINT TAFK FOREIGN KEY (Address) REFERENCES Address(Id);

CREATE TABLE School(
	Id INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Address INT NOT NULL,
	is_Active BIT NOT NULL
);

ALTER TABLE Teacher ADD CONSTRAINT TSFK FOREIGN KEY (WorkingSchool) REFERENCES School(Id);

ALTER TABLE School ADD CONSTRAINT SAFK2 FOREIGN KEY (Address) REFERENCES Address(Id);

CREATE TABLE Language(
	Id INT PRIMARY KEY NOT NULL,
	Name VARCHAR(20) NOT NULL,
	is_Active BIT NOT NULL
);

CREATE TABLE Sessions(
	Id INT PRIMARY KEY NOT NULL,
	Teacher VARCHAR(13) NOT NULL,
	ResDate DATE NOT NULL,
	StartTime TIME NOT NULL,
	Duration INT NOT NULL,
	Status VARCHAR(10) NOT NULL,
	Student VARCHAR(13),
	is_Active BIT NOT NULL
);

ALTER TABLE Sessions ADD CONSTRAINT CTFK FOREIGN KEY (Teacher) REFERENCES Teacher(JMBG);

ALTER TABLE Sessions ADD CONSTRAINT CSFK FOREIGN KEY (Student) REFERENCES Student(JMBG);


CREATE TABLE HasLanguage(
	School_Id INT NOT NULL,
	Language_Id INT NOT NULL,
	is_Active BIT NOT NULL	
);

ALTER TABLE HasLanguage ADD CONSTRAINT HSFK FOREIGN KEY (School_Id) REFERENCES School(Id);

ALTER TABLE HasLanguage ADD CONSTRAINT HLFK FOREIGN KEY (Language_Id) REFERENCES Language(Id);

ALTER TABLE HasLanguage ADD CONSTRAINT HPK PRIMARY KEY (Language_Id, School_Id);

CREATE TABLE Teaches(
	Teacher_Id VARCHAR(13) NOT NULL,
	Language_Id INT NOT NULL,
	is_Active BIT NOT NULL	
);

ALTER TABLE Teaches ADD CONSTRAINT TTFK FOREIGN KEY (Teacher_Id) REFERENCES Teacher(JMBG);

ALTER TABLE Teaches ADD CONSTRAINT TLFK FOREIGN KEY (Language_Id) REFERENCES Language(Id);

ALTER TABLE Teaches ADD CONSTRAINT HPK1 PRIMARY KEY (Language_Id, Teacher_Id);


INSERT INTO Address VALUES (1, 'Ulica Lipa', 1, 'Novi Sad', 'Srbija', 1);
INSERT INTO Address VALUES (2, 'Ulica Kestenova', 2, 'Beograd', 'Srbija', 1);
INSERT INTO Address VALUES (3, 'Ulica Ruza', 3, 'Nis', 'Srbija', 1);
INSERT INTO Address VALUES (4, 'Ulica Borova', 4, 'Pancevo', 'Srbija', 1);
INSERT INTO Address VALUES (5, 'Ulica Ljubicica', 5, 'Njujork', 'SAD', 1);
INSERT INTO Address VALUES (6, 'Ulica Krusaka', 6, 'Pariz', 'Francuska', 1);
INSERT INTO Address VALUES (7, 'Ulica Jabuka', 7, 'Los Andjeles', 'SAD', 1);
INSERT INTO Address VALUES (8, 'Ulica Visanja', 8, 'Minhen', 'Nemacka', 1);
INSERT INTO Address VALUES (9, 'Ulica Tresanja', 9, 'Zagreb', 'Hrvatska', 1);
INSERT INTO Address VALUES (10, 'Ulica Sljiva', 10, 'Sarajevo', 'BIH', 1);

INSERT INTO Administrator VALUES ('1234567890001', 'Admin', 'Adminovic', 'Male', 10, 'admin@mail.com', 'admin123', 'Admin', 1);

INSERT INTO Student VALUES ('1234567890002', 'Ana', 'Anic', 'Female', 1, 'ana@mail.com', 'ana123', 'Student', 1);
INSERT INTO Student VALUES ('1234567890003', 'Bojan', 'Bojanic', 'Male', 2, 'bojan@mail.com', 'bojan123', 'Student', 1);

INSERT INTO School VALUES (1, 'Skola 1', 3, 1);
INSERT INTO School VALUES (2, 'Skola 2', 4, 1);

INSERT INTO Teacher VALUES ('1234567890004', 'Sanja', 'Sanjic', 'Female', 5, 'sanja@mail.com', 'sanja123', 'Teacher', 1, 1);
INSERT INTO Teacher VALUES ('1234567890005', 'Tihomir', 'Tihomiric', 'Male', 6, 'tihomir@mail.com', 'tihomir123', 'Teacher', 1, 2);

INSERT INTO Language VALUES (1, 'srpski', 1);
INSERT INTO Language VALUES (2, 'engleski', 1);
INSERT INTO Language VALUES (3, 'spanski', 1);

INSERT INTO HasLanguage VALUES (1, 1, 1);
INSERT INTO HasLanguage VALUES (2, 2, 1);

INSERT INTO Teaches VALUES ('1234567890004', 1, 1);
INSERT INTO Teaches VALUES ('1234567890005', 2, 1);


CREATE TABLE Reserved2(
	Session_Id INT NOT NULL,
	Student_Id VARCHAR(13) NOT NULL
);

ALTER TABLE Reserved2 ADD CONSTRAINT SRFK15 FOREIGN KEY (Session_Id) REFERENCES Sessions(Id);

ALTER TABLE Reserved2 ADD CONSTRAINT SRFK16 FOREIGN KEY (Student_Id) REFERENCES Student(JMBG);

ALTER TABLE Reserved2 ADD CONSTRAINT SRPK16 PRIMARY KEY (Session_Id, Student_Id);


	
INSERT INTO Sessions (Id, Teacher, ResDate, StartTime, Duration, Status, is_Active) VALUES (1, '1234567890004', '05/09/2023', '15:00', 45, 'AVAILABLE', 1);
INSERT INTO Sessions (Id, Teacher, ResDate, StartTime, Duration, Status, is_Active) VALUES (2, '1234567890004', '05/09/2023', '16:00', 45, 'AVAILABLE', 1);
INSERT INTO Sessions (Id, Teacher, ResDate, StartTime, Duration, Status, is_Active) VALUES (3, '1234567890004', '05/09/2023', '17:00', 45, 'AVAILABLE', 1);

INSERT INTO Sessions (Id, Teacher, ResDate, StartTime, Duration, Status, is_Active) VALUES (4, '1234567890005', '05/09/2023', '15:00', 45, 'AVAILABLE', 1);
INSERT INTO Sessions (Id, Teacher, ResDate, StartTime, Duration, Status, is_Active) VALUES (5, '1234567890005', '05/09/2023', '16:00', 45, 'AVAILABLE', 1);
INSERT INTO Sessions (Id, Teacher, ResDate, StartTime, Duration, Status, is_Active) VALUES (6, '1234567890005', '05/09/2023', '17:00', 45, 'AVAILABLE', 1);


COMMIT TRANSACTION;