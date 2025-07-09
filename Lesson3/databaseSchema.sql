create database Academy;

create table People (
    [Id] int primary key identity(1, 1),
    [Name] nvarchar(30) not null,
    [Surname] nvarchar(30) not null
);

create table Students(
    [Id] int primary key identity(1, 1),
    [Email] nvarchar(max) not null,
    [PersonId] int foreign key references People(Id)
);

create table Teachers(
    [Id] int primary key identity(1, 1),
    [Email] nvarchar(max) not null,
    [PersonId] int foreign key references People(Id)
);

create table Faculties(
    [Id] int primary key identity(1, 1),
    [Name] nvarchar(30) not null,
    [FacultyDeanId] int foreign key references People(Id)
);


create table Groups(
    [Id] int primary key identity(1,1),
    [Name] nvarchar(10) not null unique,
    [FacultyId] int foreign key references Faculties(Id)
)

alter table Students
add [GroupId] int foreign key references Groups(Id);

create table Subjects(
    [Id] int primary key identity(1, 1),
    [Name] nvarchar(30) not null unique,
    [CreditCount] int not null default(15)
);

create table Auditorium(
    [Name] nvarchar(10) primary key,
    [MaxPersonCount] int check([MaxPersonCount] >= 5 and [MaxPersonCount] <= 100)
);

create table Schedule(
    [SubjectId] int foreign key references Subjects(Id),
    [TeacherId] int foreign key references Teachers(Id),
    [GroupId] int foreign key references Groups(Id),
    [Auditorium] nvarchar(10) foreign key references Auditorium(Name),
    [Date] datetime2,
    [Duration] int
);

--
--
-- insert into People values(N'Elvin', N'Azimov'); -- 1
-- insert into People values(N'Elvin', N'Azimov'); -- 2
--
-- insert into Students values(N'elvin.azim@outlook.com', 1);
-- insert into Students values(N'second@outlook.com', 2);
--
-- insert into Teachers values(N'azimov_e@itstep.org', 1);
-- insert into Teachers values(N'azimov_e2@itstep.org', 2);
--
--

-- create table Students(
--     [Id] int primary key identity(1, 1)
--     [Email] nvarchar(max) not null
--     [Name] nvarchar(30) not null
--     [Surname] nvarchar(30) not null
--     [PIN] nvarchar(7) not null unique
-- )
--
-- create table Teachers(
--     [Id] int primary key identity(1, 1)
--     [Email] nvarchar(max) not null
--     [Name] nvarchar(30) not null
--     [Surname] nvarchar(30) not null
--     [PIN] nvarchar(7) not null unique
-- )
--
-- insert into Students(Email, Name, Surname) values(N'test@gmail.com', N'Elvin', N'Azimov', N'744H06U')
-- insert into Students(Email, Name, Surname) values(N'test2@gmail.com', N'Elvin', N'Azimov', N'2D236V6')
--
-- insert into Teacher(Email, Name, Surname) values(N'test@itstep.org', N'Elvin', N'Azimov', N'744H06U')
-- insert into Teacher(Email, Name, Surname) values(N'test2@itstep.org', N'Elvin', N'Azimov', N'2D236V6')



