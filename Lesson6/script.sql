SELECT
    UPPER('hello world') AS upper_case,
    LOWER('HELLO WORLD') AS lower_case,
    TRIM('   hello world   ') AS trimmed_string,
    SUBSTRING('hello world', 1, 5) AS substring,
    CONCAT('hello', ' ', 'world') AS concatenated_string,
    REPLACE('hello world', 'world', 'SQL') AS replaced_string,
    LEFT('hello world', 5) AS left_part,
    RIGHT('hello world', 5) AS right_part,
    LEN('hello world') AS string_length,
    CHARINDEX('world', 'hello world') AS position_of_world;


go;

DECLARE @date DATETIME = '2023-10-01';

SELECT
    DATEADD(DAY, 5, '2023-10-01') AS date_after_5_days,
    DATEDIFF(DAY, '2023-10-01', '2023-10-10') AS days_difference,
    FORMAT(16112001, '##-##-####') AS formatted_date,
    FORMAT(@date, 'd', 'en-US') AS formatted_date,
    FORMAT(@date, 'MMMM dd, yyyy') AS long_date_format,
    FORMAT(@date, 'MM/dd/yyyy') AS short_date_format,
    FORMAT(@date, 'yyyy-MM-dd') AS iso_date_format,
    DATEPART(YEAR, '2023-10-01') AS year_part,
    DATENAME(MONTH, '2023-10-01') AS month_name,
    GETDATE() AS current_datetime,
    DATENAME(dw, GETDATE()) as day_of_week,
    YEAR('2023-10-01') AS year_from_date,
    MONTH('2023-10-01') AS month_from_date,
    DAY('2023-10-01') AS day_from_date,
    DATEFROMPARTS(2023, 10, 1) AS constructed_date;

go;


DECLARE @name NVARCHAR(50) = 'John Doe';

SELECT
    CASE
    WHEN @name = 'John Doe' THEN 'Hello, John!'
    WHEN @name = 'Jane Doe' THEN 'Hello, Jane!'
    ELSE 'Hello, Guest!'
END

go;

IF EXISTS(SELECT * FROM sys.databases
                   WHERE name = 'Auth_23')
BEGIN
    SELECT 'Database Auth_23 exists.' AS Message;
    print 'Database Auth_23 already exists.';
END
ELSE
BEGIN
 CREATE DATABASE Auth_23;
END

GO;

DECLARE @number INT = 10;
SELECT IIF (@number > 5, 'Number is greater than 5', 'Number is low than 5') AS result;

go;

select COALESCE((select name from sys.databases where name = 'Auth_23'), null, (select name from sys.databases where name = 'Auth_8')) as result;

go;

select NULLIF(1, 2)

go;

select Age
from Employees
where Age BETWEEN 20 AND 30;

go;

select Age
from Employees
where Age in (20, 25, 30);

go;

begin transaction
select * from Users;

update Users
set userName = 'UpdatedUser2'
where email = 'Sigmund58@yahoo.com'

rollback transaction;

commit transaction;

go;

begin transaction TEST;
select * from Users;

update Users
set userName = 'UpdatedUser4'
where email = 'Glen89@yahoo.com'

insert into Roles (roleName)
values ('NewRole2');


-- rollback transaction TEST
commit transaction TEST;
