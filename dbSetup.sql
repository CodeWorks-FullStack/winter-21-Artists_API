CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';



-- NOTE TABLE SETUP at initialization of app
-- PRIMARY KEY Is the unique value per row, used for the relationship
--  AUTO_INCREMENT means automatically counts (the id is sequential )
CREATE TABLE burgers (  
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Create Time',
    update_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Update Time',
    name TEXT COMMENT 'The burger name',
    price DECIMAL(4, 2) NOT NULL COMMENT 'Burger Price',
    description VARCHAR(255) DEFAULT 'No description provided' COMMENT 'Burger Description'
) DEFAULT CHARSET UTF8 COMMENT 'Burgers for BurgerShack';

CREATE TABLE artists (  
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Create Time',
    update_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Update Time',
    name TEXT COMMENT 'The artist name',
    yearOfBirth INT NOT NULL COMMENT 'Birth Year',
    yearOfDeath INT NOT NULL COMMENT 'Death Year',
    isDead TINYINT DEFAULT 0 COMMENT 'Is the Artist Dead'
) DEFAULT CHARSET UTF8 COMMENT 'Artists';


-- CREATE (post)
INSERT INTO burgers
(name, price, description)
VALUES
('Aloha Zach', 7.99, 'A Juicy Burger with Pineapple (aloha means hello and goodbye!)');

INSERT INTO burgers
(name, price, description)
VALUES
('Mark Deluxe', 5.99, 'Extra Cheesy with a side of dad jokes');

-- READ (get / get by id)
SELECT * FROM burgers;

SELECT * FROM burgers WHERE id = 3;


-- UPDATE (put)
UPDATE burgers
SET
  price = 6.99,
  description = 'Extra Cheesy with a side of d&d jokes'
WHERE id = 3;


-- DELETE (delete)
DELETE FROM burgers WHERE id = 3 LIMIT 1;









-- DANGER ZONE
-- REMOVES ALL CONTENT FROM TABLE
DELETE FROM burgers;

-- DELETE ENTIRE TABLE
DROP TABLE burgers;


-- DELETE ENTIRE DATABASE
DROP DATABASE DevDatabase;