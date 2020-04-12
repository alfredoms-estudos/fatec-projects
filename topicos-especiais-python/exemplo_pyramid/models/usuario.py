from exemplo_pyramid.models.model import Model

class Usuario(Model):
    name = "usuarios"
    def __init__(self, nome, endereco, telefone):
        super().__init__()
        self.setNome(nome)
        self.setEndereco(endereco)
        self.setTelefone(telefone)

    def setNome(self, nome):
        self.nome = nome

    def getNome(self):
        return self.nome

    def setEndereco(self, endereco):
        self.endereco = endereco

    def getEndereco(self):
        return self.endereco

    def setTelefone(self, telefone):
        self.telefone = telefone

    def getTelefone(self):
        return self.telefone

    def fields(self):
        return "nome, endereco, telefone"

    def tableName(self):
        return Usuario.name

    def tableValues(self):
        return "'"+self.getNome() + "', '" + self.getEndereco() + "', '" + self.getTelefone() + "'"