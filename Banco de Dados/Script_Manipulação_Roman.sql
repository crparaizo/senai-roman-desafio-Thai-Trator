USE DESAFIO_ROMAN;


-----Sessão DELETE:-----
DELETE FROM USUARIOS;
DBCC CHECKIDENT('USUARIOS', RESEED, 0)


GO

CREATE PROCEDURE INSERIR_CLINICA
AS
BEGIN
bulk insert CLINICA
from 'C:\db\spmedgroup_clinica.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO


EXEC INSERIR_CLINICA