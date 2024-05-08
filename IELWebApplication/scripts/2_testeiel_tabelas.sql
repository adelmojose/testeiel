USE [IEL]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--========================================================================
--INSTITUI��O 

CREATE TABLE [dbo].[InstituicaoEnsino](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeInstituicao] [varchar](100) NULL,
 CONSTRAINT [PK_InstituicaoEnsino] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--========================================================================
--ESTADO 
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeEstado] [varchar](100) NOT NULL,
	[Sigla] [varchar](2) NULL,
	[Regiao] [varchar](20) NULL,
	[Capital] [varchar](20) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--========================================================================
--CIDADE 


CREATE TABLE [dbo].[Cidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCidade] [varchar](100) NULL,
	[IdEstado] [int] NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_Cidade_Estado]
GO

--========================================================================
--ESTUDANTE 

CREATE TABLE [dbo].[Estudante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeEstudante] [varchar](100) NULL,
	[NumeroCPF] [varchar](11) NULL,
	[Endereco] [varchar](100) NULL,
	[NomeCurso] [varchar](100) NULL,
	[IdCidadade] [int] NULL,
	[IdInstituicaoEnsino] [int] NULL,
	[DataConclusao] [smalldatetime] NOT NULL,
	[Status] [bit] NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_Estudante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Estudante]  WITH CHECK ADD  CONSTRAINT [FK_Estudante_Cidade] FOREIGN KEY([IdCidadade])
REFERENCES [dbo].[Cidade] ([Id])
GO

ALTER TABLE [dbo].[Estudante] CHECK CONSTRAINT [FK_Estudante_Cidade]
GO

ALTER TABLE [dbo].[Estudante]  WITH CHECK ADD  CONSTRAINT [FK_Estudante_InstituicaoEnsino] FOREIGN KEY([IdInstituicaoEnsino])
REFERENCES [dbo].[InstituicaoEnsino] ([Id])
GO

ALTER TABLE [dbo].[Estudante] CHECK CONSTRAINT [FK_Estudante_InstituicaoEnsino]
GO


--===================================================
--INSERT INSTITUI��O

insert into [dbo].[InstituicaoEnsino] (instituicao) values ('UNIFACS')
insert into [dbo].[InstituicaoEnsino] (instituicao) values ('Est�cio FIB')
insert into [dbo].[InstituicaoEnsino] (instituicao) values ('UNIJORGE')
insert into [dbo].[InstituicaoEnsino] (instituicao) values ('UCSAL')
insert into [dbo].[InstituicaoEnsino] (instituicao) values ('FTC')

GO

--===================================================
--INSERT ESTADO

INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Acre', 'AC', 'Norte', 'Rio Branco')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Alagoas', 'AL', 'Nordeste', 'Macei�')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Amap�', 'AP', 'Norte', 'Macap�')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Amazonas', 'AM', 'Norte', 'Manaus')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Bahia', 'BA', 'Nordeste', 'Salvador')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Cear�', 'CE', 'Nordeste', 'Fortaleza')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Distrito Federal', 'DF', 'Centro-Oeste', 'Bras�lia')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Esp�rito Santo', 'ES', 'Sudeste', 'Vit�ria')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Goi�s', 'GO', 'Centro-Oeste', 'Goi�nia')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Maranh�o', 'MA', 'Nordeste', 'S�o Lu�s')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Mato Grosso', 'MT', 'Centro-Oeste', 'Cuiab�')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Mato Grosso do Sul', 'MS', 'Centro-Oeste', 'Campo Grande')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Minas Gerais', 'MG', 'Sudeste', 'Belo Horizonte')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Par�', 'PA', 'Norte', 'Bel�m')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Para�ba', 'PB', 'Nordeste', 'Jo�o Pessoa')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Paran�', 'PR', 'Sul', 'Curitiba')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Pernambuco', 'PE', 'Nordeste', 'Recife')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Piau�', 'PI', 'Nordeste', 'Teresina')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Rio de Janeiro', 'RJ', 'Sudeste', 'Rio de Janeiro')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Rio Grande do Norte', 'RN', 'Nordeste', 'Natal')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Rio Grande do Sul', 'RS', 'Sul', 'Porto Alegre')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Rond�nia', 'RO', 'Norte', 'Porto Velho')
 INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES  ('Roraima', 'RR', 'Norte', 'Boa Vista')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Santa Catarina', 'SC', 'Sul', 'Florian�polis')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('S�o Paulo', 'SP', 'Sudeste', 'S�o Paulo')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Sergipe', 'SE', 'Nordeste', 'Aracaju')
INSERT INTO Estado ([NomeEstado], [Sigla], [Regiao], [Capital]) VALUES   ('Tocantins', 'TO', 'Norte', 'Palmas')

GO

--===================================================
--INSERT CIDADE 

insert into [dbo].[Cidade] (NomeCidade, IdEstado) values ('Salvador', 5)
insert into [dbo].[Cidade] (NomeCidade, IdEstado)values ('Lauro de Freitas', 5)
insert into [dbo].[Cidade](NomeCidade, IdEstado) values ('Cama�ari', 5)
insert into [dbo].[Cidade](NomeCidade, IdEstado) values ('Candeias', 5)
insert into [dbo].[Cidade](NomeCidade, IdEstado) values ('Sim�es Filho', 5)
insert into [dbo].[Cidade](NomeCidade, IdEstado) values ('Feira de Santana', 5)
insert into [dbo].[Cidade](NomeCidade, IdEstado) values ('Dias Davila', 5)

GO
