--- pour supprimer la base de données si jamais elle existe déjà
drop database if exists HotelBooking;  
-- Instruction de creation de la base de donnees HotelBooking
create database HotelBooking;
-- J'accede à la base de donnees crée pour pouvoir créer mes tables et faire mes réquêtes 
use HotelBooking;


-- trois classes au depart( Client, Hotel et Chambre) avec le diagramme de cas
-- 4 tables au final ajout de la table reservation ( entre Client et Chambre ) 
-- Un hotel dois avoir au moins une chambre, une chambre dois appartenir a un et un seul hotel 
-- Un client peut resevefr plusieurs chambres, une chambre dois etre treserver par un seul client


create table Hotel 
( HotelId int auto_increment not null primary key, 
HotelName varchar(50) not null 
);

insert into Hotel values  (1, 'Times');
insert into Hotel values  (2, 'OTL Gouverneur');
insert into Hotel values (3, 'Spa des Sables'); 
insert into Hotel values (4, 'Estrimont Suites & Spa'); 


create table Bedroom   
( BedroomId int auto_increment not null primary key, 
Stage varchar(50) not null , -- etage 
Number int not null,
price float ,

HotelId integer not null, 
foreign key (HotelId) references Hotel(HotelId)
);



insert into Bedroom values  (1, '1er', 105, 200, 1);
insert into Bedroom values   (2, '2e', 207, 250, 4);
insert into Bedroom values  (3, '1er', 109, 200, 1);
insert into Bedroom values  (4, '3e', 302, 280, 2);


create table Client 
( ClientId int auto_increment not null primary key, 
Statut varchar(500),
Name varchar(50) not null,
Gender char(1) not null,
Email varchar(500) not null
);

 

insert into Client values  (1, 'In.png', 'Joel', 'M', 'joel@gmail.com');
insert into Client values  (2, 'Out.png', 'Samira', 'F', 'sami@gmail.com');
insert into Client values  (3, 'In.png', 'John', 'M', 'john@gmail.com');
insert into Client values  (4, 'Reserve.png', 'Victoire', 'F', 'victoire@gmail.com');


create table Booking   
(
BookingId integer not null, HotelId integer not null, BedroomId integer not null, primary key  (BookingId, HotelId, BedroomId),
foreign key (HotelId) references Hotel(HotelId),
foreign key (BedroomId) references Bedroom(BedroomId), 

CheckIn date,  
CheckOut date,

ClientId integer not null, 
foreign key (ClientId) references Client(ClientId)
);

insert into Booking values  (1, 1,2, '2021-12-25', '2021-12-29', 2);
insert into Booking values  (1, 2, 1, '2021-12-20', '2021-12-29', 1);
insert into Booking values  (3, 2,2, '2021-12-25', '2021-12-29', 3);
insert into Booking values  (2, 1,2, '2021-09-19', '2021-12-22', 1);




select * from Hotel;
select * from Bedroom;
select * from Client;
select * from Booking;