use Academy;

create trigger [InsertTrigger]
    on People
    after insert
    as
    begin
        print N'Triggered 😤😤😤'
    end

    go;

create trigger [InsertTrigger2]
    on People
    instead of insert
    as
    begin
        print N'Triggered instead of insert 😤😤😤'
    end

    go;

insert into People(Name, Surname) values (N'Tony', N'Start');

select * from People
where Name = 'Tony'


select COUNT(Id)
from People;