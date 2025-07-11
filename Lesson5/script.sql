use Auth_23;

select * from Users;

select * from Roles;

select * from UserRoles;

select U.userName, (select top 1 R.roleName
 from UserRoles as UR
 join Roles as R on UR.roleNameRef = R.roleName
 where UR.userRef = U.Id) as roleName
from Users as U

select U.userName, R.roleName from Users as U
inner join dbo.UserRoles UR on U.Id = UR.userRef
inner join dbo.Roles R on R.roleName = UR.roleNameRef


select * from Users
where Id = (select MAX(UR.userRef) from UserRoles as UR)


create table #TempUserRoles
(
    userRef uniqueidentifier,
    roleNameRef nvarchar(50)
);


insert into #TempUserRoles (userRef, roleNameRef)
select userRef, roleNameRef
from UserRoles
where userRef = (select MAX(userRef) from UserRoles);


select * from #TempUserRoles;


create view UserRoleView as
select U.userName, R.roleName
from Users as U
inner join UserRoles as UR on U.Id = UR.userRef
inner join Roles as R on UR.roleNameRef = R.roleName;

select URV.roleName from UserRoleView as URV;

