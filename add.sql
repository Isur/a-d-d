-- --------------------------------------------------------
-- Host:                         eu-cdbr-west-02.cleardb.net
-- Wersja serwera:               5.6.38-log - MySQL Community Server (GPL)
-- Serwer OS:                    Linux
-- HeidiSQL Wersja:              9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Zrzut struktury bazy danych heroku_934d7a5f9255e50
DROP DATABASE IF EXISTS `heroku_934d7a5f9255e50`;
CREATE DATABASE IF NOT EXISTS `heroku_934d7a5f9255e50` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `heroku_934d7a5f9255e50`;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.colleges
DROP TABLE IF EXISTS `colleges`;
CREATE TABLE IF NOT EXISTS `colleges` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.colleges: ~0 rows (około)
DELETE FROM `colleges`;
/*!40000 ALTER TABLE `colleges` DISABLE KEYS */;
INSERT INTO `colleges` (`Id`, `Name`) VALUES
	(1, 'Politechnika Śląska w Gliwicach'),
	(21, 'Wyższa Szkoła Bankowa w Chorzowie'),
	(31, 'Akademia Górniczo Hutnicza w Krakowie'),
	(41, 'Uniwersytet Śląski w Katowicach');
/*!40000 ALTER TABLE `colleges` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.faculties
DROP TABLE IF EXISTS `faculties`;
CREATE TABLE IF NOT EXISTS `faculties` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  `College_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_College_Id` (`College_Id`) USING HASH,
  CONSTRAINT `FK_Faculties_Colleges_College_Id` FOREIGN KEY (`College_Id`) REFERENCES `colleges` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.faculties: ~0 rows (około)
DELETE FROM `faculties`;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
INSERT INTO `faculties` (`Id`, `Name`, `College_Id`) VALUES
	(1, 'Matematyka Stosowana', 1),
	(11, 'Geologia i Górnictwo', 1),
	(21, 'Logistyka', 21),
	(31, 'Transport', 21),
	(41, 'Matematyka', 31),
	(51, 'Astronomia', 31),
	(61, 'Materiałoznastwo', 41),
	(71, 'Prawo', 41);
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.lecturers
DROP TABLE IF EXISTS `lecturers`;
CREATE TABLE IF NOT EXISTS `lecturers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Surname` text,
  `EmailAddress` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.lecturers: ~0 rows (około)
DELETE FROM `lecturers`;
/*!40000 ALTER TABLE `lecturers` DISABLE KEYS */;
INSERT INTO `lecturers` (`Id`, `Name`, `Surname`, `EmailAddress`) VALUES
	(1, 'Adrian', 'Kapczyński', 'akapczynski@polsl.pl');
/*!40000 ALTER TABLE `lecturers` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.materials
DROP TABLE IF EXISTS `materials`;
CREATE TABLE IF NOT EXISTS `materials` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(40) DEFAULT NULL,
  `Content` text,
  `Subject_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Subject_Id` (`Subject_Id`) USING HASH,
  CONSTRAINT `FK_Materials_Subjects_Subject_Id` FOREIGN KEY (`Subject_Id`) REFERENCES `subjects` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=251 DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.materials: ~1 rows (około)
DELETE FROM `materials`;
/*!40000 ALTER TABLE `materials` DISABLE KEYS */;
INSERT INTO `materials` (`Id`, `Title`, `Content`, `Subject_Id`) VALUES
	(1, 'wprowadzenie', 'Wykład 1. Informatyka jest bardzo fajna.', 1),
	(11, 'Zajęcia nr 1', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 1),
	(21, 'Zajęcia nr 2', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 1),
	(31, 'Zajęcia nr 3', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 1),
	(41, 'Zajęcia nr 4', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 1),
	(51, 'Zajęcia nr 1', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 11),
	(61, 'Zajęcia nr 2', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 11),
	(71, 'Zajęcia nr 3', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 11),
	(81, 'Zajęcia nr 4', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 11),
	(91, 'Zajęcia nr 1', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 21),
	(101, 'Zajęcia nr 2', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 21),
	(111, 'Zajęcia nr 3', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 21),
	(121, 'Zajęcia nr 4', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 21),
	(131, 'Zajęcia nr 1', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 31),
	(141, 'Zajęcia nr 2', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 31),
	(151, 'Zajęcia nr 3', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 31),
	(161, 'Zajęcia nr 4', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 31),
	(171, 'Zajęcia nr 1', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 41),
	(181, 'Zajęcia nr 2', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 41),
	(191, 'Zajęcia nr 3', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 41),
	(201, 'Zajęcia nr 4', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 41),
	(211, 'Zajęcia nr 1', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 51),
	(221, 'Zajęcia nr 2', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 51),
	(231, 'Zajęcia nr 3', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 51),
	(241, 'Zajęcia nr 4', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 51);
/*!40000 ALTER TABLE `materials` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.specializations
DROP TABLE IF EXISTS `specializations`;
CREATE TABLE IF NOT EXISTS `specializations` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Faculty_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Faculty_Id` (`Faculty_Id`) USING HASH,
  CONSTRAINT `FK_Specializations_Faculties_Faculty_Id` FOREIGN KEY (`Faculty_Id`) REFERENCES `faculties` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=151 DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.specializations: ~0 rows (około)
DELETE FROM `specializations`;
/*!40000 ALTER TABLE `specializations` DISABLE KEYS */;
INSERT INTO `specializations` (`Id`, `Name`, `Faculty_Id`) VALUES
	(11, 'Informatyka', 1),
	(61, 'Matematyka', 1),
	(71, 'Górnictwo', 11),
	(81, 'Geologia', 11),
	(91, 'Logistyka przemysłowa', 21),
	(101, 'Logistyka domowa', 21),
	(111, 'Drogowy', 31),
	(121, 'Kolejowy', 31),
	(131, 'Algebra', 41),
	(141, 'Analiza', 41);
/*!40000 ALTER TABLE `specializations` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.subjects
DROP TABLE IF EXISTS `subjects`;
CREATE TABLE IF NOT EXISTS `subjects` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Semester` int(11) NOT NULL,
  `Lecturer_Id` int(11) DEFAULT NULL,
  `Specialization_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Lecturer_Id` (`Lecturer_Id`) USING HASH,
  KEY `IX_Specialization_Id` (`Specialization_Id`) USING HASH,
  CONSTRAINT `FK_Subjects_Lecturers_Lecturer_Id` FOREIGN KEY (`Lecturer_Id`) REFERENCES `lecturers` (`Id`),
  CONSTRAINT `FK_Subjects_Specializations_Specialization_Id` FOREIGN KEY (`Specialization_Id`) REFERENCES `specializations` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.subjects: ~0 rows (około)
DELETE FROM `subjects`;
/*!40000 ALTER TABLE `subjects` DISABLE KEYS */;
INSERT INTO `subjects` (`Id`, `Name`, `Semester`, `Lecturer_Id`, `Specialization_Id`) VALUES
	(1, 'Wprowadzenie do informatyki', 1, 1, 11),
	(11, 'Programowanie', 1, 1, 11),
	(21, 'Analiza Matematyczna', 1, 1, 61),
	(31, 'Algebra', 1, 1, 61),
	(41, 'Znajomość Węgla', 1, 1, 71),
	(51, 'Kopanie Tuneli', 1, 1, 71);
/*!40000 ALTER TABLE `subjects` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.users
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` text,
  `LastName` text,
  `PhoneNumber` text,
  `MailAddress` text,
  `Login` text,
  `Password` text,
  `AccountType` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=141 DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.users: ~1 rows (około)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`Id`, `FirstName`, `LastName`, `PhoneNumber`, `MailAddress`, `Login`, `Password`, `AccountType`) VALUES
	(61, 'Admin', 'Admin', '666666666', 'admin@admin.pl', 'admin', '?3?*?H??f?\n?5?M??', 1),
	(101, 'Artur', 'Testuje', '123123123', 'asda@asd.pl', 'Isur', '?J??????Ls?????/??', 0),
	(111, 'Dawid', 'Grajewski', '123456789', 'dawid@wp.pl', 'Dawid', '?J??????Ls?????/??', 0),
	(121, 'Testerk', 'Test', '123456789', 'mal@mal.pa', 'Isur', '?J??????Ls?????/??', 0),
	(131, 'Jan', 'Kowalski', '321564987', 'fdsljksf@sadfjslfsd.csdf', 'Jan', '??>6G?j?>%qxP?l????', 0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.userspecializations
DROP TABLE IF EXISTS `userspecializations`;
CREATE TABLE IF NOT EXISTS `userspecializations` (
  `User_Id` int(11) NOT NULL,
  `Specialization_Id` int(11) NOT NULL,
  PRIMARY KEY (`User_Id`,`Specialization_Id`),
  KEY `IX_User_Id` (`User_Id`) USING HASH,
  KEY `IX_Specialization_Id` (`Specialization_Id`) USING HASH,
  CONSTRAINT `FK_UserSpecializations_Specializations_Specialization_Id` FOREIGN KEY (`Specialization_Id`) REFERENCES `specializations` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_UserSpecializations_Users_User_Id` FOREIGN KEY (`User_Id`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.userspecializations: ~2 rows (około)
DELETE FROM `userspecializations`;
/*!40000 ALTER TABLE `userspecializations` DISABLE KEYS */;
INSERT INTO `userspecializations` (`User_Id`, `Specialization_Id`) VALUES
	(61, 11),
	(101, 11),
	(101, 61),
	(101, 81),
	(111, 11),
	(131, 11),
	(131, 81);
/*!40000 ALTER TABLE `userspecializations` ENABLE KEYS */;

-- Zrzut struktury tabela heroku_934d7a5f9255e50.__migrationhistory
DROP TABLE IF EXISTS `__migrationhistory`;
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Zrzucanie danych dla tabeli heroku_934d7a5f9255e50.__migrationhistory: ~0 rows (około)
DELETE FROM `__migrationhistory`;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
	('201804281449210_first', 'DAL.Migrations.Configuration', _binary 0x1F8B0800000000000400ED5ACD6EE33610BE17E83B083A2EB29693458B36B077E13A4961348E8338BBE86DC148B44394A254914AED167DB21EFA487D850EF54B91922DC976B0288A00814D911F673ECE8C6638FEE7AFBF471F363EB55E70C449C0C6F6F960685B98B98147D87A6CC762F5F63BFBC3FBAFBF1A5D7BFEC6FA94CF7B27E7C14AC6C7F6B310E1A5E370F719FB880F7CE246010F5662E006BE83BCC0B9180EBF77CECF1D0C10366059D6E8216682F838F9025FA7017371286244E7818729CFC6E1C93241B5EE908F79885C3CB6AF26B78364966D4D284120C012D3956D21C60281048877F991E3A58802B65E863080E8E336C4306F8528C799D897E5F4B61A0C2FA4064EB9308772632E02BF23E0F9BB8C12475FDE8B58BBA00C48BB0672C5566A9D10070C85D8051EC8EFD906FA9697531AC9E90ABB83EA9A330B9E9C1506007622FFCEAC694C451CE131C3B188103DB3EEE3274ADC9FF0F631F805B3318B29556503E9E059650086EEA320C491D83EE05526F1CCB32DA7BACED11716CB9435A9163326DE5DD8D61D6C8E9E282E8E5ED178298208FF88198E90C0DE3D1202474C62E0843C63776D2FF93FDF0D6C0DBCC5B6E668738BD95A3C8F6DF8685B376483BD7C2493E02323E05CB0484431DEB7C914661E799391531AC74E93011F8ADA198A9CF9BF7954F7BA211117AF6223B7E89536BA7F0E18BE8BFD27691727DE6B8E089D785E84393F3D81C19AB0D3B38738FF2D88BC936F3471DD005EAE7297622F783F0E2AE386E56B9877E885AC1347D0D0F517C903A6C927FE4CC26C23190E3EEBF36EA2C07F08681657B4C79F97411CB952DCA079CE238AD658F49594B71595EF9195B71196D74ADB1C7A635F09BC95839AF11B8AD665EED2261E2B00078565B03B0F47740B76AA86CD2AFF732C03422EFAD57C76675B9F108DE1DBD038ACCAE4F9E2EAFA61F2B87828169CEF5EF071795DCEBD30B94D595407279C07702C9228E5ADA61B6775CB6BE6592D2CB574ACF44539074649081CC2018FED378626BB6173735160750FAA6E301C0CCE7506146D3B93C0BBB0C0DBD2604AB91FBA33156F5AF2903A1F541A02115618D51512E809712CC7F146D4781848993919CF22B0AE8FC45D62D114784AAF6FD0C720A80A2869AA834919D7162BCA57118C90ACCCDC11B9F554AC9D7B142A14D23BDD80722B50800C5EF5FCAFAA7A3F5A784B5E783762F8D198E1C7A5267F27156E5156DE4E5A7AE725BAD350A38FE6280CE115A1D4ECD988B54C0BF6E9DB65F792D64F311C97D754B685B4C54E90ADA335D69EA60554928AE76E6E5B53CF37A6E941A0C11FF3DDEAFDDC3CC6DC5FF375F27316751AAA6C1DA424F306F4F3A1F64854C58D676F0224772888A2A8A61A9A0634F6595345B56B755A71A8EBD391F608696DAB22A42326C2C8D138D099760CAA35F3D74FB0D5F9A6EED9EF5493D0DCFD2CEB979DE604950A55055186DB639535A80A558EB647AA14992A58E5417BBC4A21A9E2551E74D0342D162B6AA6431D742C4AC18A82C5687BA44AA9A082551EBCBE47555F37A65B19B948930F1913DB788C7C816A44ED48314C725A399B0656E77B92A542907E326659434F193B0B05EF3F8F2485C28CCB2B82A2ECECA4B99E6E1CC344786B1BE1A691EC4F69F71F053FF02C12C8D358093FD0944F63260D0AEF370E2325D5A714D1AB484DB5147494A583FB7B49467E984EB12D50FD857832379C6F97BFD2817C3E483E4E29818059CE98234656988BF4E2C4FE66F0ADD697FA727A440EE71EEDD4287AF59B7922A9DD7BF7BEEFFA7247AF86066C9D16FA2548D7564C5F8CC225145D8DEB8619F3F0666CFF91ACB9B4663F7FCE969D598B08ECEDD21A5A7FEEDEB95B8FE7BF71C646C3A5EF21E9FD94BE3835ED92BE5035DD90DEDAA9CD8EDEAA69BD8CBE3835AD8AC4363A1E7D4D42D2CDC10C80C35DEDB09BE7BAF4B8E7B5B0719FD4E3EE1A1C1F47D22F118597321711BC968D92E13E22CC2521A2F53A98B9499BB022092E80F5275738C44CC60B55BB36FBB4CADD0B742DCEED23E394F7F0875EB8F7B6AB23D944EB133AD0127AD8DE8EFCFCE89650DF8930EF2ABBF4195AB419D2DC766C7B4F011C7D1AD1F6DD1CD7F5221A5B11751BD45E72BF6297A29EA5BAB270DF45BC7177FF657720F68A7B1C9A8ED35B300B36702FE52782E0E19CAC4B08598232EC561CAB983363AB2077704DA27C8A9E6061813CF0BA4924C80AB9021EBB906C253FD0C8FACDD790C87933B68845180B5019FB4FB4F22B20192776ED9F3450AA328F16617292C75001C424A0025EB01F6242BD42EE1B33836A82900128CBC8E5590A9999AFB705D21DE4B3ED8032FA8AB8F988FD9002185FB0257AC17D640303BEC56BE46EF3B2BB1964FF4154691F5D11B48E90CF338C723D7C051BF6FCCDFB7F0100D62371292B0000, '6.2.0-61023'),
	('201804281502298_ALL_I_HOPE', 'DAL.Migrations.Configuration', _binary 0x1F8B0800000000000400ED5D5B6FE3B8157E2FD0FF20E8B1C8DAC90C5AB481BD8B3497C2689C047166D1B780911847AD2EAE44CD262DFACBFAD09FD4BF50EA4652BC53961D77265860108BE4E1B97C3C3C3CBCEC7FFFFD9FD94FAF49EC7D85791165E9DC3F991CFB1E4C832C8CD2F5DC2FD1F30FBFF77FFAF1D7BF9A5D86C9ABF77357EF73550FB74C8BB9FF82D0E6743A2D82179880629244419E15D9339A045932056136FD747CFC87E9C9C91462123EA6E579B3FB32455102EB1FF8E779960670834A102FB310C645FB1D97AC6AAADE0D4860B101019CFB1767D793BA96EF9DC511C00CAC60FCEC7B204D33041066EFF44B015728CFD2F56A833F80F8E16D0371BD671017B065FB9456B795E0F85325C19436EC48056581B2C491E0C9E7562553BEF920C5FA446558699758B9E8AD92BA561CD6D00606580FD13FDA0EF82E4FCFE3BCAACE6877D26F73E4E1922302008C93EABF23EFBC8C5199C3790A4B9483F8C8BB2B9FE228F8337C7BC8FE06D3795AC631CB1BE60E97F53EE04F7779B681397ABB87CF2DC78BD0F7A6FD7653BE2169C6B469A458A4E8F327DFBBC19D83A71812D33312AF5096C33FC114E600C1F00E2004F3B4A2016BE509BD737D55FF76BD61ACE1D1E27B4BF07A0DD3357A99FBF84FDFBB8A5E61D87D6939F892467870E146282FA1D0C90DF81AAD6BFEB8EEAE4080158DB9BA87715D5EBC449B06F993B6ECB16FB002F79F67C97D16D3E67C95C70790AF21C27264FA7AABACCC03077657A8ACF45848F9C5A333D7312B2B173895567266B37CFA2B0C146CB6858FFCD8A18CCA6B08AC2AAAC9989D4DE9D0D50E6882079B91DC56FE18C2EF3A84CFB338866B28C55A5BF6D8582A82BDF120140A08136B388F047E388EEB673A764C7EA6136CD098200AB619136DE58F317100D35A8DF7ED47050F32F5B81904AF6AC6B1C35655F303589CA5A3BC40BB4117D7D335D85347772F590A6FCAE4A9C2C58EFB5A82283E0BC31C16C5EE1598ADA374F7DA0345F14B96873BEFE82C0832BCDAAC7A217D55DEA5F75D40FE9813E7A08097F766DAA87890436BE352CBD56053F9C3ADED63BEE43106135820EA655462D962F61A1B121B2BD72E7B682571C1D3950920152AC800AA636D89AD906384CB075257FA48A04B79E3CB842059A8B05D8C3CEE9A51A548C5D272D078A716B519F05DED8F11FF1E23BECCD37DF47399EC2CAEB08665372EED60D9D5FE80259F5D4811AEB9C7B51BF1C1DB3A6ADEF7293DB91DBCCA8401572FC85B14573158D38D001BBC3104B6821CD67208F3F80D5B8585445FD74B582D263AD62F968B1BDFFB19C425FE752C18A65779797B71797FF6707B4F1A9CE81B7C595DD2BA9F44DD365A643F9E154586E7A24A51FD840BB33EEF777899869E71B14E037292BF595675365885D8BE58F2C9449445479A4CFC94344997F649FF86979B91512FBA2A17A6E2D2981833F26A508331C34F3BE08393B174225DE6A8F8D5AF7928B34DD645CBA299EE1E952084CF2A46D5B134C364E73DEDE55746E00C591A089A20E620B8E0F2551CAAFD3FE590C604F692AB170046856E25B822E6371948B50018C5FAAA1D295BFC3B28A49986ABF0034429995E2E00024FA0807558F22ACB31E081DA4EB7451B79F04255745710A9122D74FE57882468A94F90C92A0BA4880F36D068271F1909329B1948540E4BD6BE717C86C6740353D446871E0389CE19C86850476120C22CDB0522742C73441840091A6573FE4C3DE5C6001FC0DB841E4408D68E53174ADDB86228317CF3CB85BEBC16BA506EB8891AB18A479C22121B999C221086A020D0D6AA92A758453D996314FB288511A81DC41AED68E3929DAA464CE8896AD1472D76710B2B04714B1A8D2823158610E39CB6D683B82615F5A00F62ECC218867DC62D6A14A10C5C2C34BA051EF8E9528D0A5D64E312DB0C4588229A1965D474790412C090B2D9B4397BD87E984D158714674BB0D9E0653D7368B1FDE2AD9A138BE73FACDCCFF4250D8D6950488EF6116E494F28CBC11A72A5D59C15C27AEBB50BC87CEF3C4C846A7CB8A698EDBBDEE4119968C82E12E8DA557FB7F1A1E298214F842AF30ACB97C014D5A242A5ED45025E758814C4209764E7F0945E26A92AC3A76BDDA481D9F6CD1791C26CCA49C0EB692A288A032FAF7F2BEBE862231BBB7421B0BB41942DBF534B90E0729821BA8584BB21942DBF53433451DA302BD4CB317713C89BED46FFCC111B9608F3D99E163D44C392A25FED29F54EC9B0C47A05F6F47A2761587ABD0207499BD32E3D319B4F0E3292B32C3D01C9577B4ABDFD0A9658AFE060461409E306CEFDF228DB66D257B57C6FD7A6A240CF70B054E8D78331295D720DB3A96A0969615475D383B56AB74FDF336AF7D19E4E7F1F9E25D62F391894D095ED309490A4A03B4AD44D778312B2B3CE92201FF76F91FE52561A6AB2D9534D48C956B30CE2ABD5B9FC5E839860153563659D8E9ECC4A956E48FF43586B73070359736609C3248CEABDA245511DFE20470FEC04E6F316CE78506690352B3EB1B2DB8A5B620743AE79A0353AAA2300C590BB3E28B8A8C5DE1A2EF22CBA6A3964064A55CB192CBA9CFB4043D4244780892E893F90352EB7E9C6E4D60617F70634613A53CB321C97A85095F51FA83E426604EBAA76360E6AF46B04DE1A0DE20E892E74A3B56C233489CE557B1F4347534B650434A8F6770E0A0D6A7947730DFC3691CE41F075B77713F2AD9FF7F0B52E6C1E24544CC29B1123EC95F155C8D287EC99717B63B3769FCAFCCA87B071D554F13DAC84AF51586D5A2DDF567F8F2755F9A4FEF33C8EEA2559576309D2E81916A83985EBFF76F23BEEC590C379BD635A1461CF5D1A9FF0E89B6E0F47D8A3B4F3F4BA43EAA63B499ACB147196AE9BB3629488CD1D06361E6658150E9C2DD210BECEFD7FD6CD4EBDC55F1E69CB23EF36C78839F58EBD7FE9FB777EA1E1C350FC6ADCDD50B4E50E0C25DD25FB8E0CE57601FEDBD092701B7D28A6F9CBE643E948EE920F2525B92A3E583AF626F860D1B88BDE43E948EE71D7D8D09ADEF932F4B781EF3120C9DF3A362B5B022076B5EAE6F399A6F64E5F228518F6BAF12110D8C114A4B82CF25DA3AF7F03762819D905D791A74579B6E3FFD678DC45D2E1F6A39909C701475AEE60A49932D2766653E793C5BA16EB6E93C549776E8A6C9BA9B4688586FDB94F87C97B849BA8235C3C2577849CEF996232181F30AF462888F1802B500E2271A3F82E8FD220DA8098E35DCC2BD978964A9F84225F72013730AD5C06279C4D57FA0D5B429903BD4903BBBF8C3BC2AD5B597274C805D3A1887031D39688309ED3167BD46FD0EE0118D65B89DC451DE30DE41321857D9B5EC01822E89D054D12F11C14010845075B2572757D6B20252BDE09AC14875D47C794797FD871FA7D3750C93626C6F013DF38D00618FF7D2067B575B407F0593F2FD0DFD177BEF8DF472FBB1DEC7A397D102E348748C79FD8948790C5AE0CC70DF60000EB67161C8C66303FBDC03DE88586618EC1C1285BDA5F731455E207B4070CF6E8006C5F9B183AF11C9C4BD8FF54E182C1F7991FB8ED78B21EE3EF7CF256D4BDAC61F1B046B3153FF7C3A70C03A059BE9B6EE0F29D92F596D01B299175A37E5E81EF802CEA850E4889AC03D54B10D2773B94CF76C8284BDF0850BDE8A17BD043AA7ED5FD709E3E0D01840E98E37D921ED457F1F92EE8D42074418B645D28AFCB4B956F84ADAC92CA3026F8EEF5AD12D9D324364F6F481EED109FB039CC67486C58D74E6CEAE3E9BB795C843C6A60F7C688E248989077E0AF8E9A9E14D1A84156BC1B55740F3258AA427E886F0CDBBEBB7A467E6B8577D6FD5B72164F67C8DEDC1841CC919F52716056B130911D3E1ECF9ABB78296514888F6365872750C4E39B387A65FE576E38862EA23525511D4D4D61D08B5B499D45FA9C759134C75157853FDA02110871507B96A3E81904081707B028EA976EDBA74C2F9327182ED2DB126D4A844586C953DC9B49AA305CD77FFDCE4B9FE7D9EDA6F65C638880D98CB008F036FD6319C521E1FB4AB2FDA52051C5F7ED866F654B546DFCAEDF08A59B2CB524D4AA8F2C4B1E60B28931B1E2365D81AF70086FD8AB5EC33508DEBA43B86A226643F4D53EBB88C03A0749D1D2A0EDF14F8CE13079FDF17FE394D2CED1700000, '6.2.0-61023');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
