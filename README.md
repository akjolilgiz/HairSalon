# _Hair Salon_

#### _Hair Salon, September 21, 2018_

###### By _**Akjol Jaenbai**_

## Description

_Create a page that lets user to pick a hair stylist and sign up._

## Setup/Installation Requirements

* Clone the repository.
* Open file in terminal.

## Known Bugs

_None._

## Support and contact details
* akjolilgiz@gmail.com
* https://github.com/akjolilgiz/HairSalon

## Specs
|#|Spec Description|Input|Expected Output|
|-------|-------|------|------|
|1|The program opens homepage when user navigates to localhost:5000|http://localhost:5000 |"Stylist", "Client"|
|2|The program allows user to register as stylist or client|
|3|The program displays the list of hair stylists to the user |open page|"list of hair stylists"|
|4|The program lets user pick any stylist they want|click a dropdown button |"List of hair stylists"|
|5|The program lets user enter their name and assigns it to specific stylist|
|6|The program lets user see the list of clients for each stylist|

## Specs
* Instructions to create database and tables with MySql commands:
|#|Instructions|
|-------|-------|
|1|>CREATE DATABASE akjol_jaenbai;
|2|>Use akjol_jaenbai;
|3|>CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAT(255));
|4|>CREATE TABLE clients (id serial PRIMARY KEY, clientName VARCHAR(255), stylist_id INT);
* Instructions to select a database:
|1|>SHOW DATABASES;
|2|>USE akjol_jaenbai;
* Instructions to insert data inside the tables:
|1| INSERT INTO stylists (name)  VALUES ("Name of the stylist");
|2|INSERT INTO clients (name) VALUES ("Name of the client")





## Technologies Used

* Mono
* GitHub
* Atom
* Csharp
* MySql

### License

*This is licensed under MIT.*

Copyright (c) 2018 **_Akjol Jaenbai_**
