USE DESAFIO_ROMAN;


-----Sessão DELETE:-----
DELETE FROM USUARIOS;
DBCC CHECKIDENT('USUARIOS', RESEED, 0)


INSERT INTO TIPOS_USUARIOS (NOME)
VALUES ('Professor')
		,('Admnistrador')

INSERT INTO EQUIPES (NOME)
VALUES ('Desenvolvimento')
		,('Redes')
		,('Multimidia')

INSERT INTO SITUACOES (NOME)
VALUES ('Ativa')
		,('Inativa')

INSERT INTO TEMAS (NOME, ID_SITUACAO)
VALUES ('Gestão', '1')
		,('HQs', '1')
		,('Meio Ambiente', '1')

INSERT INTO USUARIOS (NOME, EMAIL, SENHA, ID_TIPO_USUARIO)
VALUES ('Helena','helena@gmail.com','123456','1')
		,('Fernando','fernando@gmail.com','123456','1')
		,('Odirlei','odirlei@gmail.com','123456','2')
		,('Candida','candida@gmail.com','123456','2')

INSERT INTO PROJETOS (TITULO, ID_TEMA, DESCRICAO, ID_USUARIO)
VALUES ('Controle de Estoque','1','','1')
		,('Limpador de Praia','3','','2')
		,('Listagem de Personagem','2','','1')

INSERT INTO USUARIOS_EQUIPES (ID_USUARIO,ID_EQUIPE)
VALUES ('1','1')
		,('1','2')
		,('2','3')


SELECT * FROM TIPOS_USUARIOS;
SELECT * FROM EQUIPES;
SELECT * FROM SITUACOES;
SELECT * FROM TEMAS;
SELECT * FROM USUARIOS;
SELECT * FROM PROJETOS;
SELECT * FROM USUARIOS_EQUIPES;