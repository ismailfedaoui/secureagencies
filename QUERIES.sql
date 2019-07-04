create database secureagencies_DB
go
use secureagencies_DB
go
create table agence(id_ag int identity primary key, nom_ag varchar(50), mdp varchar(50),date_creation date,date_inscription date default getdate() ,tel_ag varchar(15),email_age varchar(30),adresse varchar(200),ville_ag varchar(30),etat_compte varchar(30) default 'Unverified',code_activation varchar(60) ,etat_paiement varchar(30) default 'nouveau',date_exp date default dateadd(day,7,getdate()),photo_ag nvarchar(max) default 'null')
create table client(id_cl int identity primary key, full_name varchar(100), tel varchar(15),sexe varchar(30),dns date, adresse varchar(100), ville varchar(30), pays varchar(30),date_insc date default getdate())
create table agence_client(id_ag int not null foreign key references agence(id_ag) on delete cascade on update cascade,id_cl int not null foreign key references client(id_cl) on delete cascade on update cascade, constraint pk primary key(id_ag, id_cl))
create table dossier(num_dossier int identity primary key,date_creation date , description_dossier varchar(200),id_client int not null foreign key references client(id_cl) on delete cascade on update cascade)
create table document(id_document varchar(70) primary key,type_document varchar(30),date_exp date,description_document varchar(200),num_dossier int not null foreign key references dossier(num_dossier) on delete cascade on update cascade)
create table contrat (id_contrat varchar(70) primary key , type_contrat varchar(30), date_creation date,date_exp date,description_contrat varchar(200), num_dossier int not null foreign key references dossier(num_dossier)on delete cascade on update cascade)
create table rendezvous (id_rdv int identity primary key, date_rdv date, heure_rdv time,nom varchar(70) , tel varchar(15),id_ag int not null foreign key references agence(id_ag) on delete cascade on update cascade)
create table paiement (id_paiement int identity primary key, id_ag int not null foreign key references agence(id_ag) ,date_paiement date,montant decimal)
go
insert into agence values('al-wafae agency','P@ssw0rd1','25/1/2009',default,'06367200520','ismail@gmail.com','physical adress1','Rabat','Verified',null,default,default,'user.jpg')
insert into client values('ismail fedaoui','0636720520','Homme','25/10/1994','lot argana', 'ait melloul','maroc',default);
insert into agence_client values(1,1)
insert into dossier values('23/1/1993','dossier1',1)
insert into document values ('D1','CIN','25/10/1994','Description 1',1)
insert into contrat values ('C1','C. voiture','25/10/1994','25/10/1999','Description 2',1)
insert into rendezvous values ('2/2/2016','09:30','Ismail Fedaoui','0636720520',1)
insert into paiement values(1,getdate(),20)
go
