from pyramid.config import Configurator

import exemplo_pyramid.database.init_db as database

def main(global_config, **settings):
    """ This function returns a Pyramid WSGI application.
    """
    database.init_db()
    config = Configurator(settings=settings)
    config.include('pyramid_jinja2')
    config.add_jinja2_search_path('exemplo_pyramid:templates', name='.jinja2', prepend=True)
    config.add_static_view('static', 'static', cache_max_age=3600)
    config.add_route('home', '/')
    config.add_route('create', '/create')
    config.add_route('insert', '/insert')
    config.add_route('list_users', '/list_users')
    config.add_route('remove', '/remove')
    config.scan()
    return config.make_wsgi_app()
