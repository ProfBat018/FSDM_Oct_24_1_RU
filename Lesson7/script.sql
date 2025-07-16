use Auth_23;

go;

create procedure TestProcedure
as
   select * from Users

go;

exec TestProcedure;

go;

drop procedure TestProcedure;
go;

create procedure GetCountOfStudents(@count int output)
as
    set @count = (select count(Id) from Users)
go;


declare @res int;
exec GetCountOfStudents @res output;
select @res;

create procedure GetUserInfo(@id uniqueidentifier, @userName nvarchar(50) output, @email nvarchar(50) output )
as
    select @userName = userName, @email = email
from Users
where  Id = @id;

go;

declare @username nvarchar(50), @email nvarchar(50), @id uniqueidentifier = '40177DFD-5509-47A8-A155-2157907EDB5E';

exec GetUserInfo @id,  @username output , @email output;
select @username, @email

go;

create function  GetUserInfo2(@id uniqueidentifier)
returns table
as
    return(
        select userName, email
        from Users
        where Id = @id)


select * from GetUserInfo2('40177DFD-5509-47A8-A155-2157907EDB5E');

create table #tmpUserData(
    userName nvarchar(50),
    email nvarchar(50)
);

INSERT INTO #tmpUserData(userName, email)
SELECT userName, email
FROM GetUserInfo2('40177DFD-5509-47A8-A155-2157907EDB5E');


select * from #tmpUserData

create function UserCount()
returns int
as
    begin
    declare @res int;
    set @res = (select COUNT(Id) from Users);
    return @res;
    end

select dbo.UserCount();

