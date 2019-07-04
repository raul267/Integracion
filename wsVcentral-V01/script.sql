USE [master]
GO
/****** Object:  Database [db_vcentral]    Script Date: 04-07-2019 10:30:37 ******/
CREATE DATABASE [db_vcentral]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_vcentral', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\db_vcentral.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_vcentral_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\db_vcentral_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_vcentral] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_vcentral].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_vcentral] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_vcentral] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_vcentral] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_vcentral] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_vcentral] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_vcentral] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_vcentral] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [db_vcentral] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_vcentral] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_vcentral] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_vcentral] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_vcentral] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_vcentral] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_vcentral] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_vcentral] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_vcentral] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_vcentral] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_vcentral] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_vcentral] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_vcentral] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_vcentral] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_vcentral] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_vcentral] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_vcentral] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_vcentral] SET  MULTI_USER 
GO
ALTER DATABASE [db_vcentral] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_vcentral] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_vcentral] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_vcentral] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_vcentral]
GO
/****** Object:  StoredProcedure [dbo].[pruebaa]    Script Date: 04-07-2019 10:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pruebaa]   
    @idCurso varchar(30), 
	@rutEstudiante varchar(30),
	@notaFinal varchar(30)   
AS   

    insert into prueba values(@idCurso,@rutEstudiante,@notaFinal);

GO
/****** Object:  StoredProcedure [dbo].[sp_carreras]    Script Date: 04-07-2019 10:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_carreras]
as
	select * from carrera

GO
/****** Object:  StoredProcedure [dbo].[sp_mallacarrera]    Script Date: 04-07-2019 10:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_mallacarrera]
@codcarr varchar(50)
as
	select 
	c.codcarr, c.nombre as nomcarrera, 
	r.codramo, r.nombre as nomramo, m.nivel
	from malla as m
	join carrera as c on m.codcarr = c.codcarr 
	join ramo as r on m.codramo = r.codramo 
	where m.codcarr = @codcarr or @codcarr = '' 

GO
/****** Object:  StoredProcedure [dbo].[sp_ramos]    Script Date: 04-07-2019 10:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ramos]  
  @id varchar(20)
AS   
	select * from ramo r join malla m on r.codramo = m.codramo join carrera c on m.codcarr = c.codcarr
	where c.codcarr = @id;    

GO
/****** Object:  StoredProcedure [dbo].[sp_rut]    Script Date: 04-07-2019 10:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_rut]
@rut varchar(40)
as
select * from alumno join carrera on alumno.codcarr = carrera.codcarr join malla on carrera.codcarr = malla.codcarr join ramo on malla.codramo = ramo.codramo
join nota on nota.codramo = nota.codramo where alumno.codalu = @rut;


GO
/****** Object:  StoredProcedure [dbo].[SPIngresarNota]    Script Date: 04-07-2019 10:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SPIngresarNota](
	@ano int, 
	@per int,
	@codramo varchar(50),
	@codalu varchar(50),
	@nf numeric(3,1))
as
Begin
	declare @Vcodramo varchar(50);
	declare @Vnf numeric(3,1);
	declare @Vestado varchar(1);
	
	--Si ya lo cursó--
	if (0 < (select COUNT(codramo)
			from nota 
			group by codalu, codramo
			having (codalu = @codalu) and 
				   (codramo = @codramo)))
		begin
			--Si lo aprobó--
			if (@nf >= 4)
				begin
					--Si lo aprobó en la ocación anterior--
					if ('A' = 
						(select top 1 estado
						from nota
						where (codramo = @codramo) and (codalu = @codalu)
						order by nf desc))
						begin
							--si la nota nueva es mayor--
							if (@nf > 
								(select top 1 nf 
								 from nota
								 where (codramo = @codramo) and (codalu = @codalu)
								 order by nf desc))
								begin
								   delete from nota where codramo = @codramo and codalu =  @codalu;
								   insert into nota values(@ano, @per, @codramo, @codalu,@nf,'A');
								end
							--Si la nota vieja es mayor, no pasa nada--
						end
					--si no lo aprobó en la ocación anterior--
					else
						begin
							insert into nota values(@ano, @per, @codramo, @codalu,@nf,'S');
						end
				end
			--Si no lo aprobó
			else
				begin
					insert into nota values(@ano, @per, @codramo, @codalu,@nf,'R');
				end
			end
	--Si no lo ha cursado
	else
		begin
			--Si lo aprobó--
			if (@nf >= 4)
				begin
					insert into nota values(@ano, @per, @codramo, @codalu,@nf,'A');
				end
			--Si no lo aprobó
			else
				begin
					insert into nota values(@ano, @per, @codramo, @codalu,@nf,'R');
				end
			
		end
end

GO
/****** Object:  Table [dbo].[alumno]    Script Date: 04-07-2019 10:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alumno](
	[id_alu] [bigint] IDENTITY(1,1) NOT NULL,
	[codalu] [varchar](50) NULL,
	[paterno] [varchar](100) NULL,
	[materno] [varchar](100) NULL,
	[nombres] [varchar](100) NULL,
	[codcarr] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_alu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[alumnomalla]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnomalla](
	[id_alu] [bigint] NOT NULL,
	[id_malla] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_alu] ASC,
	[id_malla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[asignacion]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[asignacion](
	[id_asignacion] [int] IDENTITY(1,1) NOT NULL,
	[id_curso_moodle] [varchar](50) NOT NULL,
	[id_carrera] [varchar](50) NOT NULL,
	[id_ramo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_asignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[asignacion_ramos]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacion_ramos](
	[id_asignacion] [int] NOT NULL,
	[id_curso_moodle] [int] NOT NULL,
	[id_carrera] [int] NOT NULL,
	[id_malla] [int] NOT NULL,
 CONSTRAINT [PK_asignacion_ramos] PRIMARY KEY CLUSTERED 
(
	[id_asignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[asignacionn]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacionn](
	[cod_cursoumas] [nvarchar](20) NOT NULL,
	[cod_carrera] [nvarchar](20) NOT NULL,
	[cod_cursomoodle] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[carrera]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[carrera](
	[codcarr] [varchar](50) NOT NULL,
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[codcarr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[malla]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[malla](
	[id_malla] [bigint] IDENTITY(1,1) NOT NULL,
	[codcarr] [varchar](50) NULL,
	[codramo] [varchar](50) NULL,
	[codsecc] [int] NULL,
	[nivel] [int] NULL,
	[orden] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_malla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nota]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nota](
	[ano] [int] NOT NULL,
	[per] [int] NOT NULL,
	[codramo] [varchar](50) NOT NULL,
	[codalu] [varchar](50) NOT NULL,
	[nf] [numeric](3, 1) NULL,
	[estado] [varchar](1) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[prueba]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prueba](
	[idCurso] [varchar](30) NULL,
	[rutEstudiante] [varchar](30) NULL,
	[notaFinal] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ramo]    Script Date: 04-07-2019 10:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ramo](
	[codramo] [varchar](50) NOT NULL,
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[codramo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[alumno]  WITH CHECK ADD FOREIGN KEY([codcarr])
REFERENCES [dbo].[carrera] ([codcarr])
GO
ALTER TABLE [dbo].[alumnomalla]  WITH CHECK ADD FOREIGN KEY([id_alu])
REFERENCES [dbo].[alumno] ([id_alu])
GO
ALTER TABLE [dbo].[alumnomalla]  WITH CHECK ADD FOREIGN KEY([id_malla])
REFERENCES [dbo].[malla] ([id_malla])
GO
ALTER TABLE [dbo].[malla]  WITH CHECK ADD FOREIGN KEY([codcarr])
REFERENCES [dbo].[carrera] ([codcarr])
GO
ALTER TABLE [dbo].[malla]  WITH CHECK ADD FOREIGN KEY([codramo])
REFERENCES [dbo].[ramo] ([codramo])
GO
USE [master]
GO
ALTER DATABASE [db_vcentral] SET  READ_WRITE 
GO
