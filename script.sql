/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Gym]    Script Date: 29/01/2018 17:07:14 ******/
CREATE DATABASE [Gym]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gym', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Gym.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gym_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Gym_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Gym] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gym].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gym] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gym] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gym] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gym] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gym] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gym] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gym] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gym] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gym] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gym] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gym] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gym] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gym] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gym] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gym] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gym] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gym] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gym] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gym] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gym] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gym] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gym] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gym] SET RECOVERY FULL 
GO
ALTER DATABASE [Gym] SET  MULTI_USER 
GO
ALTER DATABASE [Gym] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gym] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gym] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gym] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Gym] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Gym', N'ON'
GO
ALTER DATABASE [Gym] SET QUERY_STORE = OFF
GO
USE [Gym]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Gym]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sexo] [bit] NOT NULL,
	[LimiteCompra] [decimal](18, 0) NOT NULL,
	[CPF] [varchar](20) NOT NULL,
	[RG] [varchar](20) NOT NULL,
	[Pagamento] [bit] NOT NULL,
	[IdPagamento] [int] NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avaliacao]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avaliacao](
	[IdAvaliacao] [int] NOT NULL,
	[Peso] [float] NULL,
	[Altura] [float] NULL,
	[Idade] [int] NULL,
	[Cintura] [int] NULL,
	[Barriga] [int] NULL,
	[BustoTorax] [int] NULL,
	[IMC] [float] NULL,
	[GCoporal] [float] NULL,
	[Musculos] [float] NULL,
	[GorduraViceral] [float] NULL,
	[Metabolismo] [float] NULL,
	[IdadeCorpo] [int] NULL,
 CONSTRAINT [PK_Avaliacao] PRIMARY KEY CLUSTERED 
(
	[IdAvaliacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contatos]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contatos](
	[IdContatos] [int] NOT NULL,
	[Email] [varchar](255) NULL,
	[Telefone] [varchar](255) NULL,
	[Celular] [varchar](255) NULL,
	[IdFuncionario] [int] NOT NULL,
	[IdAluno] [int] NOT NULL,
 CONSTRAINT [PK_Contatos] PRIMARY KEY CLUSTERED 
(
	[IdContatos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataCadastro]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataCadastro](
	[IdCadastro] [int] NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[IdAluno] [int] NOT NULL,
	[IdFuncionario] [int] NOT NULL,
 CONSTRAINT [PK_DataCadastro] PRIMARY KEY CLUSTERED 
(
	[IdCadastro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[idEndereco] [int] IDENTITY(1,1) NOT NULL,
	[Cidade] [varchar](255) NOT NULL,
	[Estado] [varchar](255) NOT NULL,
	[Sigla] [varchar](10) NOT NULL,
	[CEP] [varchar](50) NOT NULL,
	[Logradouro] [varchar](255) NOT NULL,
	[Numero] [int] NOT NULL,
	[Bairro] [varchar](255) NOT NULL,
	[IdAluno] [int] NULL,
	[IdFuncionario] [int] NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[idEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[IdFuncionario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Login] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Perfil] [int] NOT NULL,
	[Situacao] [bit] NOT NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[IdFuncionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagamento]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagamento](
	[IdPagamento] [int] NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[IdAluno] [int] NOT NULL,
	[Valor] [float] NULL,
	[dataPagamento] [date] NULL,
	[dataRecebimento] [date] NULL,
	[TipoPagamento] [varchar](50) NULL,
 CONSTRAINT [PK_Pagamento] PRIMARY KEY CLUSTERED 
(
	[IdPagamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planos]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planos](
	[IdPlano] [int] NOT NULL,
	[TipoPlano] [varchar](50) NULL,
	[ValorPlano] [float] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_Avaliacao_tblAluno_old] FOREIGN KEY([IdAvaliacao])
REFERENCES [dbo].[Aluno] ([IdCliente])
GO
ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK_Avaliacao_tblAluno_old]
GO
ALTER TABLE [dbo].[Contatos]  WITH CHECK ADD  CONSTRAINT [FK_Contatos_Funcionario] FOREIGN KEY([IdFuncionario])
REFERENCES [dbo].[Funcionario] ([IdFuncionario])
GO
ALTER TABLE [dbo].[Contatos] CHECK CONSTRAINT [FK_Contatos_Funcionario]
GO
ALTER TABLE [dbo].[Contatos]  WITH CHECK ADD  CONSTRAINT [FK_Contatos_tblAluno] FOREIGN KEY([IdAluno])
REFERENCES [dbo].[Aluno] ([IdCliente])
GO
ALTER TABLE [dbo].[Contatos] CHECK CONSTRAINT [FK_Contatos_tblAluno]
GO
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Perfil] FOREIGN KEY([Perfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_Perfil]
GO
/****** Object:  StoredProcedure [dbo].[uspAvaliacaoAlterar]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAvaliacaoAlterar]
	  @IdAvaliacao int,
	@Peso float,
	@Altura float,
	@Idade int,
	@Cintura int,
	@Barriga int,
	@BustoTorax int,
	@IMC float,
	@GCoporal float,
	@Musculos float,
	@GorduraViceral float,
	@Metabolismo float,
	@IdadeCorpo int
AS
BEGIN
	UPDATE 
		Avaliacao
	SET	  
		IdAvaliacao		=	@IdAvaliacao	
		,Peso 			=	@Peso 			
		,Altura 		=	@Altura 		
		,Idade 			=	@Idade 			
		,Cintura 		=	@Cintura 		
		,Barriga 		=	@Barriga 		
		,BustoTorax 	=	@BustoTorax 	
		,IMC 			=	@IMC 			
		,GCoporal 		=	@GCoporal 		
		,Musculos 		=	@Musculos 		
		,GorduraViceral =	@GorduraViceral 
		,Metabolismo 	=	@Metabolismo 	
		,IdadeCorpo 	=	@IdadeCorpo         
	WHERE
		IdAvaliacao = @IdAvaliacao
		
	SELECT @IdAvaliacao AS Retorno		
END
GO
/****** Object:  StoredProcedure [dbo].[uspAvaliacaoConsultarPorId]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAvaliacaoConsultarPorId]
	@IdAvaliacao int
AS
BEGIN
	SELECT
			IdAvaliacao
           ,Peso
           ,Altura
           ,Idade
           ,Cintura
           ,Barriga
           ,BustoTorax
           ,IMC
           ,GCoporal
           ,Musculos
           ,GorduraViceral
           ,Metabolismo
           ,IdadeCorpo
	FROM
		Avaliacao
	WHERE
		IdAvaliacao = @IdAvaliacao		

END
GO
/****** Object:  StoredProcedure [dbo].[uspAvaliacaoExcluir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[uspAvaliacaoExcluir]
@IdAvaliacao int
AS
BEGIN
	DELETE FROM
		Avaliacao
	WHERE
		IdAvaliacao = @IdAvaliacao
		
	SELECT @IdAvaliacao AS Retorno
END
GO
/****** Object:  StoredProcedure [dbo].[uspAvaliacaoInserir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAvaliacaoInserir]	
	@IdAvaliacao int,
	@Peso float,
	@Altura float,
	@Idade int,
	@Cintura int,
	@Barriga int,
	@BustoTorax int,
	@IMC float,
	@GCoporal float,
	@Musculos float,
	@GorduraViceral float,
	@Metabolismo float,
	@IdadeCorpo int
AS
BEGIN
	INSERT INTO dbo.Avaliacao
           (IdAvaliacao
           ,Peso
           ,Altura
           ,Idade
           ,Cintura
           ,Barriga
           ,BustoTorax
           ,IMC
           ,GCoporal
           ,Musculos
           ,GorduraViceral
           ,Metabolismo
           ,IdadeCorpo)
	VALUES
	(
		@IdAvaliacao,
		@Peso,
		@Altura,
		@Idade,
		@Cintura,
		@Barriga,
		@BustoTorax,
		@IMC,
		@GCoporal,
		@Musculos,
		@GorduraViceral,
		@Metabolismo,
		@IdadeCorpo 		
	)
	
	SELECT @@IDENTITY AS Retorno
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteAlterar]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteAlterar]
	  @IdCliente int,	
      @Nome varchar(100),
      @DataNascimento datetime,
      @Sexo bit,
      @LimiteCompra decimal(18,2),
      @CPF varchar(20),
      @RG varchar(20),       
	  @Pagamento bit
AS
BEGIN
	UPDATE 
		Aluno
	SET	  
      Nome = @Nome
      ,DataNascimento = @DataNascimento
      ,Sexo = @Sexo
      ,LimiteCompra = @LimiteCompra
      ,CPF = @CPF
      ,RG = @RG
      ,Pagamento = @Pagamento         
	WHERE
		IdCliente = @IdCliente
		
	SELECT @IdCliente AS Retorno	
		
END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteConsultarPorId]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteConsultarPorId]
	@IdCliente int
AS
BEGIN
	SELECT
		IdCliente,
		Nome,
		DataNascimento,
		Sexo,
		LimiteCompra,
		CPF,
		RG,
		Pagamento
	FROM
		Aluno
	WHERE
		IdCliente = @IdCliente		

END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteConsultarPorNome]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteConsultarPorNome]
	@Nome varchar(100)		
AS
BEGIN
	SELECT
		IdCliente,
		Nome,
		DataNascimento,
		Sexo,
		LimiteCompra,
		CPF,
		RG,
		Pagamento
	FROM
		Aluno
	WHERE
		Nome LIKE '%' + @Nome + '%'		

END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteExcluir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteExcluir]
@IdCliente int
AS
BEGIN
	DELETE FROM
		Aluno
	WHERE
		IdCliente = @IdCliente
		
	SELECT @IdCliente AS Retorno
END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteInserir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteInserir]
	@Nome varchar(100),
	@DataNascimento datetime,
	@Sexo bit,
	@LimiteCompra decimal(18,2),
	@CPF varchar(20),
	@RG varchar(20),
	@Pagamento bit
AS
BEGIN
	INSERT INTO Aluno
	(
		Nome,
		DataNascimento,
		Sexo,
		LimiteCompra,
		CPF,
		RG,
		Pagamento
	)
	VALUES
	(
		@Nome,
		@DataNascimento,
		@Sexo,
		@LimiteCompra,
		@CPF,
		@RG,
		@Pagamento		
	)
	
	SELECT @@IDENTITY AS Retorno
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspContatosAlterar]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspContatosAlterar]
			@IdContatos int 
,@Email varchar(255) 
,@Telefone varchar(255) 
,@Celular varchar(255) 
,@IdFuncionario int 
,@IdAluno int 
AS
BEGIN
	UPDATE 
		Contatos
	SET	  
     Email = @Email  
	,Telefone = @Telefone 
	,Celular = @Celular  
	,IdFuncionario = @IdFuncionario  
	,IdAluno = @IdAluno         
	WHERE
		idContatos = @IdContatos
		
	SELECT @IdContatos AS Retorno	
		
END
GO
/****** Object:  StoredProcedure [dbo].[uspContatosExcluir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspContatosExcluir]
@IdContatos int
AS
BEGIN
	DELETE FROM
		Contatos
	WHERE
		IdContatos = @IdContatos
		
	SELECT @IdContatos AS Retorno
END
GO
/****** Object:  StoredProcedure [dbo].[uspContatosInserir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspContatosInserir]	
	@IdContatos int 
	,@Email varchar(255) 
	,@Telefone varchar(255) 
	,@Celular varchar(255) 
	,@IdFuncionario int 
	,@IdAluno int 
AS
BEGIN
	INSERT INTO dbo.Contatos
           (IdContatos
			,Email
			,Telefone
			,Celular
			,IdFuncionario
			,IdAluno)
	VALUES
	(
	 @IdContatos  
	,@Email  
	,@Telefone 
	,@Celular  
	,@IdFuncionario  
	,@IdAluno 		
	)
	
	SELECT @@IDENTITY AS Retorno
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspEnderecoAlterar]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspEnderecoAlterar]
			@idEndereco int,
			@Cidade varchar(255),
			@Estado varchar(255),
			@Sigla varchar(10),
			@CEP varchar(50),
			@Logradouro varchar(255),
			@Numero int,
			@Bairro varchar(255),
			@IdAluno int,
			@IdFuncionario int
AS
BEGIN
	UPDATE 
		Endereco
	SET	  
      Cidade = @Cidade			
           ,Estado = @Estado			
           ,Sigla = @Sigla			
           ,CEP = @CEP				
           ,Logradouro = @Logradouro		
           ,Numero = @Numero			
           ,Bairro = @Bairro			
           ,IdAluno = @IdAluno			
           ,IdFuncionario = @IdFuncionario         
	WHERE
		idEndereco = @idEndereco
		
	SELECT @idEndereco AS Retorno	
		
END
GO
/****** Object:  StoredProcedure [dbo].[uspEnderecoConsultarPorCep]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspEnderecoConsultarPorCep]
	@Nome varchar(100)		
AS
BEGIN
	SELECT
		idEndereco
           ,Cidade
           ,Estado
           ,Sigla
           ,CEP
           ,Logradouro
           ,Numero
           ,Bairro
           ,IdAluno
           ,IdFuncionario
	FROM
		Endereco
	WHERE
		CEP LIKE '%' + CEP + '%'		

END
GO
/****** Object:  StoredProcedure [dbo].[uspEnderecoConsultarPorLogradouro]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspEnderecoConsultarPorLogradouro]
	@IdEndereco int
AS
BEGIN
	SELECT
		idEndereco
           ,Cidade
           ,Estado
           ,Sigla
           ,CEP
           ,Logradouro
           ,Numero
           ,Bairro
           ,IdAluno
           ,IdFuncionario
	FROM
		Endereco
	WHERE
		IdEndereco = @IdEndereco		

END
GO
/****** Object:  StoredProcedure [dbo].[uspEnderecoExcluir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspEnderecoExcluir]
@IdEndereco int
AS
BEGIN
	DELETE FROM
		Endereco
	WHERE
		IdEndereco = @IdEndereco
		
	SELECT @IdEndereco AS Retorno
END
GO
/****** Object:  StoredProcedure [dbo].[uspEnderecoInserir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspEnderecoInserir]			
			@Cidade varchar(255),
			@Estado varchar(255),
			@Sigla varchar(10),
			@CEP varchar(50),
			@Logradouro varchar(255),
			@Numero int,
			@Bairro varchar(255),
			@IdAluno int,
			@IdFuncionario int
AS
BEGIN
INSERT INTO dbo.Endereco
           (Cidade
           ,Estado
           ,Sigla
           ,CEP
           ,Logradouro
           ,Numero
           ,Bairro
           ,IdAluno
           ,IdFuncionario)
     VALUES
           (		
            @Cidade			
           ,@Estado			
           ,@Sigla			
           ,@CEP				
           ,@Logradouro		
           ,@Numero			
           ,@Bairro			
           ,@IdAluno			
           ,@IdFuncionario)	
	
	SELECT @@IDENTITY AS Retorno
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspFuncionarioAlterar]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFuncionarioAlterar]
	  @IdFuncionario int,
	  @Nome varchar(100),
	  @Login varchar(100),
	  @Senha varchar(100),
	  @Perfil int,
	  @Situacao bit
AS
BEGIN
	UPDATE 
		Funcionario
	SET	        
	  Nome = @Nome,
	  Login = @Login,
	  Senha = @Senha,
	  Perfil = @Perfil,
	  Situacao = @Situacao       
	WHERE
		IdFuncionario = @IdFuncionario
		
	SELECT @IdFuncionario AS Retorno	
		
END
GO
/****** Object:  StoredProcedure [dbo].[uspFuncionarioConsultarPorId]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFuncionarioConsultarPorId]
	@IdFuncionario int
AS
BEGIN
	SELECT
		IdFuncionario
		,Nome 
		,Login 
		,Senha 
		,Perfil 
		,Situacao 
	FROM
		Funcionario
	WHERE
		IdFuncionario = @IdFuncionario		

END
GO
/****** Object:  StoredProcedure [dbo].[uspFuncionarioConsultarPorNome]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFuncionarioConsultarPorNome]
	@Nome varchar(100)		
AS
BEGIN
	SELECT
		IdFuncionario
		,Nome 
		,Login 
		,Senha 
		,Perfil 
		,Situacao 
	FROM
		Funcionario
	WHERE
		Nome LIKE '%' + @Nome + '%'		

END
GO
/****** Object:  StoredProcedure [dbo].[uspFuncionarioExcluir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFuncionarioExcluir]
@IdFuncionario int
AS
BEGIN
	DELETE FROM
		Funcionario
	WHERE
		IdFuncionario = @IdFuncionario
		
	SELECT @IdFuncionario AS Retorno
END
GO
/****** Object:  StoredProcedure [dbo].[uspFuncionarioInserir]    Script Date: 29/01/2018 17:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFuncionarioInserir]
	@IdFuncionario int,
	@Nome varchar(100),
	@Login varchar(100),
	@Senha varchar(100),
	@Perfil int,
	@Situacao bit
AS
BEGIN
	INSERT INTO Funcionario
	(
		Nome,
		Login,
		Senha,
		Perfil,
		Situacao
	)
	VALUES
	(   
	    @Nome,
		@Login,
		@Senha,
		@Perfil,
		@Situacao	
	)
	
	SELECT @@IDENTITY AS Retorno
	
END
GO
USE [master]
GO
ALTER DATABASE [Gym] SET  READ_WRITE 
GO
