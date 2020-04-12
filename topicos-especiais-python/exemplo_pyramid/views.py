from pyramid.response import Response
from pyramid.view import view_config
from pyramid.renderers import render
from exemplo_pyramid.models.usuario import Usuario
from exemplo_pyramid.database.database import Database

@view_config(route_name='home', renderer='templates/mytemplate.jinja2')
def home(request):
    return {'project': 'Projeto de Tópicos Especiais'}

@view_config(route_name='create', renderer='templates/create.jinja2')
def my_view(request):
    return {'project': 'Exemplo Pyramid'}

@view_config(route_name='insert')
def insert(request):
    # pega dados da url
    nome = request.params.get('nome')
    endereco = request.params.get('endereco')
    telefone = request.params.get('telefone')

    if (nome.strip() == "" or endereco.strip() == "" or telefone.strip() == ""):
        message = "Não foi possível registrar o usuário: deve-se preencher todos os campos!"
    else:
        # cria objeto, conexao, e cadastra
        db = Database()
        usuario = Usuario(nome, endereco, telefone)
        db.insert(usuario)
        message = "Usuário registrado com sucesso!"
    
    template = "templates/success.jinja2"
    context = dict(message=message)
    body = render(template, context, request=request)

    return Response(body)

@view_config(route_name='list_users')
def list_users(request):
    # cria objeto, conexao, e retorna
    usuario = Usuario(None, None, None)
    db = Database()
    users = db.queryAll(usuario)
    print(users)

    template = "templates/list.jinja2"
    context = dict(users=users)
    body = render(template, context, request=request)

    return Response(body)

@view_config(route_name='remove')
def remove(request):
    id = request.params.get('id')

    # cria objeto, conexao, e retorna
    usuario = Usuario(None, None, None)
    db = Database()
    db.delete(usuario, id)

    template = "templates/remove.jinja2"
    context = dict()
    body = render(template, context, request=request)

    return Response(body)
