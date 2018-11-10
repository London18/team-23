DROP DATABASE if exists spreadsheet;
CREATE DATABASE spreadsheet;
USE spreadsheet;
CREATE table department (
	id int not null,
	name varchar(40),
	email varchar(255),
	ext int,
	PRIMARY KEY (id)
);
CREATE table members (
	name varchar(100),
	work_email varchar(255),
	role varchar(255),
	ext varchar(15),
	department int,
	location varchar(30),
	workphone varchar(15),
	additional_phone varchar (15),
	vehicle_registration varchar(20),
	vehicle_make varchar(40),
	vehicle_model varchar(40),
	vehicle_color varchar(20),
	FOREIGN KEY (department) REFERENCES department(id)
);
