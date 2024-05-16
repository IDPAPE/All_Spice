-- Active: 1715717093297@@127.0.0.1@3306@motivated_shaman_b691c0_db
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

DROP TABLE recipes;

CREATE TABLE recipes (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    title VARCHAR(255) NOT NULL,
    instructions VARCHAR(5000),
    img VARCHAR(1000),
    category ENUM(
        "breakfast",
        "lunch",
        "dinner",
        "snack",
        "dessert"
    ),
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

DROP TABLE ingredients;

CREATE TABLE ingredients (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255),
    quantity VARCHAR(255),
    recipeId INT NOT NULL
);

INSERT INTO
    recipes (
        title,
        instructions,
        imgUrl,
        category,
        creatorId
    )
VALUES (
        "TestTitle",
        "TestInstructions",
        "TestUrl",
        "lunch",
        "662817f2fd45638b4a31d74d"
    );

DROP TABLE favorites;

CREATE TABLE favorites (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    recipeId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)

SELECT recipes.*, accounts.*
FROM recipes
    JOIN accounts ON recipes.creatorId = accounts.id
WHERE
    recipes.id = LAST_INSERT_ID();

SELECT recipes.*, accounts.*
FROM recipes
    JOIN accounts ON accounts.id = recipes.creatorId
WHERE
    recipes.id = @recipeId;

UPDATE recipes
SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @category,
WHERE
    id = @id;

SELECT recipes.*, accounts.*
FROM recipes
    JOIN accounts ON accounts.id = recipes.creatorId
WHERE
    recipes.creatorId = @id;