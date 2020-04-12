import sqlite3
from os.path import isfile
import exemplo_pyramid.config as config

def init_db():
	if (not isfile(config.DATABASE_NAME)):
		# cria conexao
		conexao = sqlite3.connect(config.DATABASE_NAME)

		# cria cursor com
		cursor = conexao.cursor()

		# cria tabela de usuarios
		cursor.execute("""
		CREATE TABLE usuarios (
				id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
				nome VARCHAR(255) NOT NULL,
				endereco VARCHAR(255) NULL,
				telefone VARCHAR(15) NULL
		);
		""")

		print('Tabela usuarios criada com sucesso!')
		
		# fecha a conexao
		conexao.close()
	else:
		print('A tabela usuarios já existe!')
