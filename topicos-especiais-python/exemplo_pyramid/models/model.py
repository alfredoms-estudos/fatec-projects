class Model(object):
    name = "Model"
    def fields(self):
        raise NotImplementedError("Método fields ainda não implementado")
    
    def tableName(self):
        raise NotImplementedError("Método tableName ainda não implementado")

    def tableValues(self):
        raise NotImplementedError("Método tableValues ainda não implementado")