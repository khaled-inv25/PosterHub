SELECT * FROM Categories;

SELECT * FROM AspNetUsers;

SELECT * FROM AspNetUserRoles

SELECT * FROM AspNetRoles;

SELECT * FROM AspNetUserClaims

SELECT * FROM AspNetUserTokens

--TRUNCATE TABLE Categories;

--Delete FROM AspNetUsers;

SELECT Id, COUNT(*) AS 'Count' FROM Categories GROUP BY Id;
