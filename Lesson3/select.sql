use Academy;
go;

select * from People;

select * from Teachers;

select * from People
inner join Teachers as T on People.Id = T.PersonId

select * from People
inner join dbo.Students S on People.Id = S.PersonId

select G.Name as [GroupName], F.Name as FacultyName from Schedule
inner join dbo.Groups G on G.Id = Schedule.GroupId
inner join dbo.Faculties F on F.Id = G.FacultyId
where Auditorium = 'Aud09'