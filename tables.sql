Create table Contract(
[ContractID] int identity(1,1) not null,
[ResidentID] int not null,
[ApartmentID] int not null,
[MoveInDate] Date not null,
[MoveOutDate] date null
);
create table Account(
AccountID int identity(1,1) not null,
ResidentID int not null,
Password int not null,
);
create table Problem(
ProblemID int identity(1,1) not null,
ApartmentID int not null,
Header varchar(30) not null,
Description varchar(140) not null,
);