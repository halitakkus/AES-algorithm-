
SET NAMES 'utf8';


USE app;


DROP TABLE IF EXISTS incomingvisitors;


DROP TABLE IF EXISTS operationclaims;

DROP TABLE IF EXISTS useroperationclaims;

DROP TABLE IF EXISTS users;


USE application;


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
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE useroperationclaims (
  Id int NOT NULL AUTO_INCREMENT,
  UserId int DEFAULT 0,
  OperationClaimId int DEFAULT 0,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE operationclaims (
  Id int NOT NULL AUTO_INCREMENT,
  Name varchar(255) DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE incomingvisitors (
  Id int NOT NULL AUTO_INCREMENT,
  IpAddress varchar(255) DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;


INSERT INTO users VALUES
(1, 'app', 'app', 'app@app.com', '202cb962ac59075b964b07152d234b70', '2021-02-03 13:15:37', '2021-02-03 13:15:37');


INSERT INTO useroperationclaims VALUES
(1, 1, 1, '2021-02-03 13:15:54', '2021-02-03 13:15:54');
INSERT INTO useroperationclaims VALUES
(2, 1, 2, '2021-02-03 13:15:58', '2021-02-03 13:15:58');


INSERT INTO operationclaims VALUES
(1, 'Admin', '2021-01-26 11:27:07', '2021-01-26 11:27:07');
INSERT INTO operationclaims VALUES
(2, 'User', '2021-01-26 11:27:13', '2021-01-26 11:27:13');


