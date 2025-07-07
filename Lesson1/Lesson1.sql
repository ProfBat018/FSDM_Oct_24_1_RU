use Showroom;

-- DDL
CREATE TABLE Cars
(
    [Id] INT PRIMARY KEY IDENTITY (1, 1),
    [Make] NVARCHAR(30),
    [Model] NVARCHAR(30),
    [Year] INT CHECK([Year] >= 1885 AND [Year] <= Year(GETUTCDATE()))
);

alter table Cars
add VIN NVARCHAR(17) NULL;

alter table Cars
alter column VIN NVARCHAR(17) NOT NULL;

create unique index IX_Cars_VIN on Cars(VIN);

-- DML
-- INSERT INTO Cars(Id, Make, Model) VALUES(1, N'Mercedes-Benz', N'S63 AMG');
-- INSERT INTO Cars(Id, M```ake) VALUES(1, N'Mercedes-Benz');
-- INSERT INTO Cars VALUES(1, N'Mercedes-Benz', N'S63 AMG');

-- INSERT INTO Cars( Make, Model) VALUES( N'Mercedes-Benz', N'S63 AMG');
-- INSERT INTO Cars( Make, Model) VALUES( N'Mercedes-Benz', N'E63 AMG');


INSERT INTO Cars(Make, Model, Year) VALUES(N'Mercedes-Benz', N'E63 AMG', 2008);
INSERT INTO Cars(Make, Model, Year) VALUES(N'Mercedes-Benz', N'E63 AMG', 2026);

select * from Cars;


select * from Cars
where Make = 'toyota'


select * from Cars
where Make LIKE 'toyota'

select * from Cars
where Make LIKE 'm%'

select * from Cars
where Make LIKE '[A-C]%'

