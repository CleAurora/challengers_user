/*create database*/
create database Challenger_User

/*Using database*/
use Challenger_User

/*creating tables*/
create table Profissoes
(
	IdProfissao Int Identity not null primary key
	,Nome varchar(255) not null
);

create table Perfis 
(
	IdPerfil Int Identity not null primary key
	,Nome varchar(255) not null
);

create table Habilidades
(
	IdHabilidade Int Identity not null primary key
	,Nome varchar(255) not null
);

create table Usuarios
(
	IdUsuario Int Identity not null primary key
	,Nome varchar(255) not null
	,Email varchar(255) not null
	,Senha varchar(255) not null
	,SitePessoal varchar(255)
	,Imagem varchar(255)
	,IdProfissao int foreign key references Profissoes
	,IdPerfil int foreign key references Perfis
);

insert into Perfis(Nome)
values ('Administrador'), ('Cliente');

select * from Perfis
select * from Profissoes
select * from Habilidades
select * from Usuarios



