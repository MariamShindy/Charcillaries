DO
$do$
DECLARE 
   db_name varchar(20) = 'charcillaries';
   db_user varchar(20) = 'charcillaries_user';
   db_password varchar(60) = 'irzeiSQcZEpkdMZzAutRMjEZcDJATHprVcwWIgIyWSdDjvpvKKlOfXuRrNNO';
BEGIN
  -- delete database and it's user
  IF EXISTS (SELECT 1 FROM pg_database WHERE datname=db_name) THEN
    DROP USER db_user;
    DROP DATABASE db_name;
  END IF;

  -- Create database and user for it
  IF Not EXISTS (SELECT 1 FROM pg_database WHERE datname=db_name) THEN
    CREATE DATABASE db_name;
    CREATE USER db_user WITH ENCRYPTED PASSWORD db_password;
    ALTER DATABASE db_name OWNER TO db_user
    -- add extension to db
    \c db_name
    CREATE EXTENSION postgis;
  END IF;
END
$do$