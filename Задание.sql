CREATE TABLE `Customer` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Name` VARCHAR(20);
);

CREATE TABLE `Orders` (
	`Id` INT,
	`CustomerId` INT(20);
);

/*
Тут бы связь сделать, но в задании не просили
*/

Select Name
from Customers
Where Id NOT IN (Select DISTINCT CustomerId 
		From Orders);