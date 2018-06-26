use [master]
go

/****** Object:  Database [TrainStationDB]    Script Date: 25/06/2018 09:49:10 ******/
create database [TrainStationDB]
 CONTAINMENT = NONE
 on  primary 
( NAME = N'TrainStationDB', FILENAME = N'C:\Users\corsista\Desktop\DataBases\TrainStationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG on 
( NAME = N'TrainStationDB_log', FILENAME = N'C:\Users\corsista\Desktop\DataBases\TrainStationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
go

alter database [TrainStationDB] set COMPATIBILITY_LEVEL = 140
go

if (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
    exec [TrainStationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
go

alter database [TrainStationDB] set ANSI_NULL_DEFAULT off 
go

alter database [TrainStationDB] set ANSI_NULLS off 
go

alter database [TrainStationDB] set ANSI_PADDING off 
go

alter database [TrainStationDB] set ANSI_WARNINGS off 
go

alter database [TrainStationDB] set ARITHABORT off 
go

alter database [TrainStationDB] set AUTO_CLOSE off 
go

alter database [TrainStationDB] set AUTO_SHRINK off 
go

alter database [TrainStationDB] set AUTO_UPDATE_STATISTICS on 
go

alter database [TrainStationDB] set CURSOR_CLOSE_ON_COMMIT off 
go

alter database [TrainStationDB] set CURSOR_DEFAULT  GLOBAL 
go

alter database [TrainStationDB] set CONCAT_NULL_YIELDS_NULL off 
go

alter database [TrainStationDB] set NUMERIC_ROUNDABORT off 
go

alter database [TrainStationDB] set QUOTED_IDENTIFIER off 
go

alter database [TrainStationDB] set RECURSIVE_TRIGGERS off 
go

alter database [TrainStationDB] set  DISABLE_BROKER 
go

alter database [TrainStationDB] set AUTO_UPDATE_STATISTICS_ASYNC off 
go

alter database [TrainStationDB] set DATE_CORRELATION_OPTIMIZATION off 
go

alter database [TrainStationDB] set TRUSTWORTHY off 
go

alter database [TrainStationDB] set ALLOW_SNAPSHOT_ISOLATION off 
go

alter database [TrainStationDB] set PARAMETERIZATION SIMPLE 
go

alter database [TrainStationDB] set READ_COMMITTED_SNAPSHOT off 
go

alter database [TrainStationDB] set HONOR_BROKER_PRIORITY off 
go

alter database [TrainStationDB] set RECOVERY SIMPLE 
go

alter database [TrainStationDB] set  MULTI_USER 
go

alter database [TrainStationDB] set PAGE_VERIFY CHECKSUM  
go

alter database [TrainStationDB] set DB_CHAINING off 
go

alter database [TrainStationDB] set FILESTREAM( NON_TRANSACTED_ACCESS = off ) 
go

alter database [TrainStationDB] set TARGET_RECOVERY_TIME = 60 SECONDS 
go

alter database [TrainStationDB] set DELAYED_DURABILITY = DISABLED 
go

alter database [TrainStationDB] set QUERY_STORE = off
go

use [TrainStationDB]
go

alter database SCOPED configuration set IDENTITY_CACHE = on;
go

alter database SCOPED configuration set LEGACY_CARDINALITY_ESTIMATION = off;
go

alter database SCOPED configuration for SECONDARY set LEGACY_CARDINALITY_ESTIMATION = primary;
go

alter database SCOPED configuration set MAXDOP = 0;
go

alter database SCOPED configuration for SECONDARY set MAXDOP = primary;
go

alter database SCOPED configuration set PARAMETER_SNIFFING = on;
go

alter database SCOPED configuration for SECONDARY set PARAMETER_SNIFFING = primary;
go

alter database SCOPED configuration set QUERY_OPTIMIZER_HOTFIXES = off;
go

alter database SCOPED configuration for SECONDARY set QUERY_OPTIMIZER_HOTFIXES = primary;
go

alter database [TrainStationDB] set  READ_WRITE 
go


