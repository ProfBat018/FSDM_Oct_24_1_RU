-- DECLARE @personID int = (
-- select PersonId from Teachers
-- where Email = 'teacher1@example.com');
--
-- select * from People
-- where Id = @personID;
--
-- select P.Name, p.Surname
-- from Teachers as T
-- inner join People as P on P.Id = T.PersonId
-- where Email = 'teacher1@example.com'
--
--
-- select P.Name, p.Surname
-- from Teachers as T
-- left join People as P on P.Id = T.PersonId
--
-- select P.Name, P.Surname
-- from Teachers as T
-- right join People as P on P.Id = T.PersonId
-- where PersonId is null
--
-- select *
-- from Teachers as T
-- full join dbo.People P on P.Id = T.PersonId
-- where T.PersonId is null
--

update Teachers
set Email = N'aloha@gmail.com'
where PersonId = 2

select *
from Teachers;

Truncate table Schedule

select * from Schedule;

alter table People
add [Age] int default(18) not null check( [Age] > 16 and [Age] < 65)

UPDATE dbo.People
SET Age = FLOOR(RAND(CHECKSUM(NEWID())) * (64 - 17 + 1)) + 17;

select * from People

-- select AVG(P.Age) as AvgAge, COUNT(P.Age) as AgeCount
-- from People as P
-- full join dbo.Students S on P.Id = S.PersonId
-- full join dbo.Teachers T on P.Id = T.PersonId
-- group by Age

select AVG(P.Age) as AvgAge, COUNT(P.Age) as AgeCount
from People as P
full join dbo.Students S on P.Id = S.PersonId
full join dbo.Teachers T on P.Id = T.PersonId
group by Age
having Age > 50
