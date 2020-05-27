use the_cursach;
create table users
(
Id int  primary key not null auto_increment,
Login varchar(16) not null,
Password varchar(40) not null,
RoleId int not null,
foreign key (RoleId) references userRole(Id) on delete cascade
);

create table userRole
(
Id int  primary key not null auto_increment,
Role varchar(20) not null
);
create table playListSong
(
Id int primary key not null auto_increment,
SongId int not null,
PlayListId int not null,
foreign key (SongId) references songs(Id) on delete cascade,
foreign key (PlayListId) references playLists(Id) on delete cascade
);
create table playLists
(
Id int primary key not null auto_increment,
Name varchar(50) not null,
Description varchar(1000) not null,
UserId int not null,
foreign key (UserId) references users(Id) on delete cascade

);
create table songs
(
Id int primary key not null auto_increment,
LocationUrl varchar(100) not null,
Name varchar(50) not null,
Description varchar(50) not null,
Type varchar(50) not null,
AuthorName varchar(50) not null,
ReleaseDate date not null,
Album varchar(50) not null,
Duraction int not null,
NumberOfPlays int not null
);
create table messages
(
Id int primary key not null auto_increment,
Text varchar(200) not null,
SenderId int not null,
GetterId int not null,
Date date not null,
foreign key (SenderId) references users(Id) on delete cascade,
foreign key (GetterId) references users(Id) on delete cascade

);
create table comments
(
Id int primary key not null auto_increment,
Text varchar(200) not null,
Date date not null,
UserId int not null,
SongId int not null,
foreign key (UserId) references users(Id) on delete cascade,
foreign key (SongId) references songs(Id) on delete cascade
);

 