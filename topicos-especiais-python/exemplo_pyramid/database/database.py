import sqlite3
import exemplo_pyramid.config as config
from exemplo_pyramid.models.model import Model

class Database(object):
    def __init__(self):
        # abre uma nova conexao
        self.connection = sqlite3.connect(config.DATABASE_NAME)

    def __del__(self):
        # fecha a conexao no destrutor
        self.connection.close()

    def insert(self, model: Model):
        # cria cursor
        cursor = self.connection.cursor()

        # define dados a serem inseridos (com polimorfismo)
        data = "INSERT INTO " + model.tableName() + " (" + model.fields() +")"
        data = data + " VALUES (" + model.tableValues() + ")"; 

        # insere os dados
        cursor.execute(data)

        # salva (commit) as alterações
        self.connection.commit()

    def queryAll(self, model: Model):
        # cria cursor
        cursor = self.connection.cursor()

        # define select
        select = "SELECT id, " + model.fields() + " FROM " + model.tableName()

        # obtendo o schema da tabela
        cursor.execute(select)

        return cursor.fetchall()

    def delete(self, model: Model, id: int):
        # cria cursor
        cursor = self.connection.cursor()

        # define dados a serem inseridos (com polimorfismo)
        data = "DELETE FROM " + model.tableName() + " WHERE id= " + id

        # insere os dados
        cursor.execute(data)

        # salva (commit) as alterações
        self.connection.commit()