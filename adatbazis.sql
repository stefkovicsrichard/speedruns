create database speedrunok;
use speedrunok;

create table speedrun(
	runnerid int primary key AUTO_INCREMENT,
	runner varchar(255),
	place int,
	ido float,
	category varchar(255)
);