IF DB_ID('AudioPlayerDb') IS NULL
CREATE DATABASE AudioPlayerDb
GO

USE HotelDB
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblUser')
DROP TABLE tblUser
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblSong')
DROP TABLE tblSong

CREATE TABLE tblUser(
Id INT PRIMARY KEY IDENTITY (1,1),
Username varchar(20),
Password varchar(20)
);

CREATE TABLE tblSong(
Id INT PRIMARY KEY IDENTITY (1,1),
Name varchar(30),
Author varchar(20),
SecondsLength int,
FKUser int
);

ALTER TABLE tblSong ADD FOREIGN KEY(FkUser) REFERENCES tblUser(Id);

