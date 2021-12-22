use db2192643;

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
NumChambre int not null,

HotelId integer not null, 
foreign key (HotelId) references Hotel(HotelId)
);

insert into Bedroom values  (1, 105, 1);
insert into Bedroom values   (2, 207, 4);
insert into Bedroom values  (3, 109, 1);
insert into Bedroom values  (4, 302, 2);


create table Client 
( ClientId int auto_increment not null primary key, 
Name varchar(50) not null,
Gender char(1) not null,
Email varchar(500) not null
);

insert into Client values  (1,  'Joel', 'M', 'joel@gmail.com');
insert into Client values  (2, 'Samira', 'F', 'sami@gmail.com');
insert into Client values  (3, 'John', 'M', 'john@gmail.com');
insert into Client values  (4, 'Victoire', 'F', 'victoire@gmail.com');

create table Booking   
(
BookingId integer not null, HotelId integer not null, BedroomId integer not null, primary key  (BookingId, HotelId, BedroomId),
foreign key (HotelId) references Hotel(HotelId),
foreign key (BedroomId) references Bedroom(BedroomId), 

Statut longblob not null,
prixParNuits double,  
nbreNuits int,

ClientId integer not null, 
foreign key (ClientId) references Client(ClientId)
);
describe Booking;
insert into Booking values  (1, 1, 2, load_file('/home/MYSQL/images2192643/Photos_Joel/Photos/IN.png'), 25, 3, 2);
insert into Booking values  (1, 2, 2, load_file('/home/MYSQL/images2192643/Photos_Joel/Photos/Out.jpg'), 40, 2, 2);
insert into Booking values  (2, 2, 2, load_file('/home/MYSQL/images2192643/Photos_Joel/Photos/reserve.jpg'), 20, 3, 3);
insert into Booking values  (3, 1, 3, load_file('/home/MYSQL/images2192643/Photos_Joel/Photos/IN.png'), 33, 1, 1);
insert into Booking values  (4, 3, 4, load_file('/home/MYSQL/images2192643/Photos_Joel/Photos/IN.png'), 55, 4, 4);

select * from Hotel;
select * from Bedroom;
select * from Client;
select * from Booking;


drop table Booking; 
drop table Client;
drop table Bedroom;
drop table Hotel;