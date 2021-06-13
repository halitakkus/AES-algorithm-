
SET NAMES 'utf8';

--
-- Varsayılan veritabanı
--
USE algorithm;

--
-- Drop table `users`
--
DROP TABLE IF EXISTS users;

--
-- Kullanıcı tablosu varsa silsin.
--
USE algorithm;

--
--  Yeni bir `users` tablosu oluştursun.
--
CREATE TABLE users (
  Id int NOT NULL AUTO_INCREMENT,
  FirstName varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  LastName varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Email varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Password varchar(255) DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4

