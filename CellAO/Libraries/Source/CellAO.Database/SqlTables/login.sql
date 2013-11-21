﻿CREATE TABLE `login` (
	`ID` INT(32) NOT NULL AUTO_INCREMENT,
	`CreationDate` DATETIME NOT NULL,
	`Email` VARCHAR(64) NOT NULL,
	`FirstName` VARCHAR(32) NOT NULL,
	`LastName` VARCHAR(32) NOT NULL,
	`Username` VARCHAR(32) NOT NULL,
	`Password` VARCHAR(37) NOT NULL,
	`Allowed_Characters` INT(32) NOT NULL DEFAULT '6' COMMENT 'You can change this to whatever you want 0 is disabled.. no characters allowed',
	`Flags` INT(32) NOT NULL DEFAULT '0',
	`AccountFlags` INT(32) NOT NULL DEFAULT '0',
	`Expansions` INT(11) NOT NULL DEFAULT '127',
	`GM` INT(32) NOT NULL DEFAULT '0',
	PRIMARY KEY (`ID`),
	UNIQUE INDEX `Username` (`Username`)
)
ENGINE=InnoDB DEFAULT CHARSET=latin1;
