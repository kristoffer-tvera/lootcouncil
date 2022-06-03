CREATE TABLE `Council` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`GuildId` INT(11) NOT NULL,
	`GuildName` VARCHAR(50) NOT NULL COLLATE 'utf8_unicode_ci',
	`GuildRealm` VARCHAR(50) NOT NULL COLLATE 'utf8_unicode_ci',
	`GuildRegion` VARCHAR(50) NOT NULL COLLATE 'utf8_unicode_ci',
	`InstanceId` INT(11) NOT NULL,
	PRIMARY KEY (`Id`)
);

CREATE TABLE `CouncilMember` (
	`CouncilId` INT(11) NOT NULL AUTO_INCREMENT,
	`Name` VARCHAR(20) NOT NULL COLLATE 'utf8_unicode_ci',
	`Realm` VARCHAR(50) NOT NULL COLLATE 'utf8_unicode_ci',
	PRIMARY KEY (`CouncilId`, `Name`, `Realm`),
    FOREIGN KEY (`CouncilId`) REFERENCES Council(`Id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE `Entry` (
	`CouncilId` INT(11) NOT NULL,
	`ItemId` INT(11) NOT NULL,
	`Option` INT(11) NOT NULL,
	`EncounterId` INT(11) NOT NULL,
	`Name` VARCHAR(20) NOT NULL COLLATE 'utf8_unicode_ci',
	`Realm` VARCHAR(50) NOT NULL COLLATE 'utf8_unicode_ci',
	PRIMARY KEY (`CouncilId`, `ItemId`, `Name`, `Realm`),
    FOREIGN KEY (`CouncilId`) REFERENCES Council(`Id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);