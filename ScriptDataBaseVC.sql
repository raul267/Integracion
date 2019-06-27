
create database db_vcentral;

use db_vcentral;

drop table alumnomalla;
drop table alumno;
drop table malla;
drop table nota;
drop table ramo;
drop table carrera;

create table ramo(
codramo varchar(50),
nombre varchar(100),
primary key(codramo));

create table carrera(
codcarr varchar(50),
nombre varchar(100),
primary key(codcarr));

create table alumno(
id_alu bigint identity(1,1),
codalu varchar(50), 
paterno varchar(100), 
materno varchar(100), 
nombres varchar(100), 
codcarr varchar(50), 
primary key(id_alu),
foreign key(codcarr) references carrera(codcarr));

create table malla(
id_malla bigint identity(1,1),
codcarr varchar(50),
codramo varchar(50),
codsecc int,
nivel int,
orden int,
primary key(id_malla),
foreign key(codramo) references ramo(codramo),
foreign key(codcarr) references carrera(codcarr));

create table alumnomalla(
id_alu bigint,
id_malla bigint,
primary key(id_alu, id_malla),
foreign key(id_alu) references alumno(id_alu),
foreign key(id_malla) references malla(id_malla));

create table nota(
ano int,
per int,
codramo varchar(50),
codsecc varchar(50),
codalu varchar(50),
nf numeric(3,1),
estado varchar(1),
primary key(ano, per, codramo, codsecc, codalu),
foreign key(codramo) references ramo(codramo));

insert into ramo (codramo, nombre) values('mat01', 'Matemática');
insert into ramo (codramo, nombre) values('base01', 'Base de Datos');
insert into ramo (codramo, nombre) values('java01', 'Taller Java');

insert into carrera (codcarr, nombre)values ('ing01', 'Ingeniería informática');
insert into carrera (codcarr, nombre)values ('audi01', 'Auditoría');

insert into alumno (codalu, paterno, materno, nombres, codcarr)
values ('11944', 'Gozalez', 'Parra', 'Ximena', 'ing01');

insert into malla (codcarr, codramo, codsecc, nivel, orden)
select distinct c.codcarr, r.codramo, 1, 1, 1
from ramo as r, carrera as c where c.codcarr = 'ing01'

insert into alumnomalla 
select distinct a.id_alu, m.id_malla 
from alumno as a, malla as m 


insert into nota (ano, per, codramo, codsecc, codalu, nf, estado)
select distinct 2019, 1, m.codramo, 1, a.codalu, 5.6, 'A' 
from alumnomalla as am, malla as m, alumno as a
where a.id_alu = am.id_alu 
and am.id_malla = m.id_malla 







