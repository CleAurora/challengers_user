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

select * from Usuarios
select * from Perfis
select * from Profissoes
select * from Habilidades

/*DML*/

insert into Profissoes(Nome)
values ('Desenvolvedor FrontEnt JS'), 
('Desenvolvedor BackEnd'), 
('Desenvolvedor iOS');

insert into Habilidades (Nome)
values ('Comunicação'), ('Liderança');

insert into Usuarios(Nome, Email, Senha, SitePessoal, Imagem, IdProfissao, IdPerfil)
values	('Erik', 'erik@gmail.com', '6ED5833CF35286EBF8662B7B5949F0D742BBEC3F', 'https://www.linkedin.com/in/erik-vitelli/', 'https://media-exp1.licdn.com/dms/image/C4D03AQGRui2aMUIQUA/profile-displayphoto-shrink_800_800/0?e=1590624000&v=beta&t=4K9qREMQVriic-QnXWPSdZjIVP4oHWyDCgGX0kyAAME', 3, 1 ),
		('Ryan', 'ryan@gmail.com', '6ED5833CF35286EBF8662B7B5949F0D742BBEC3F', 'https://www.linkedin.com/in/ryan-freitas-0227b3144/', 'https://media-exp1.licdn.com/dms/image/C4E03AQFtfq0MJgnbBQ/profile-displayphoto-shrink_800_800/0?e=1590624000&v=beta&t=dvtojZHgJfM-6liS7IvfCJ1NE6L1h-tjs2c_6YxXrfQ', 2, 2 );





