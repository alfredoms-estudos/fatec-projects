package com.fatec.alfredoms.database;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;

import com.fatec.alfredoms.beans.Usuario;

import java.util.ArrayList;

import static com.fatec.alfredoms.database.DataBaseHelper.*;

/**
 * Created by alfma on 21/09/2017.
 */

public class UsuarioDAO {

    protected SQLiteDatabase dataBase = null;

    public UsuarioDAO(Context context) {
        DataBaseHelper persistenceHelper = getInstance(context);
        dataBase = persistenceHelper.getWritableDatabase();
    }

    public void inserir(Usuario usuario) {
        ContentValues values = entidadeParacontentValues(usuario);
        dataBase.insert("usuarios", null, values);
    }

    public void remover(Usuario usuario) {

        String[] valoresParaSubstituir = {
                usuario.getNome()
        };

        dataBase.delete("usuarios", "nome =  ?", valoresParaSubstituir);
    }

    public void removerTodos() {
        dataBase.execSQL("DELETE FROM usuarios");
    }

    public void atualizar(Usuario usuario, String anterior) {
        ContentValues valores = entidadeParacontentValues(usuario);

        String[] valoresParaSubstituir = {
                anterior
        };

        dataBase.update("usuarios", valores, "nome = ?", valoresParaSubstituir);
    }

    public ArrayList<Usuario> recuperarTodos() {
        String queryReturnAll = "SELECT * FROM usuarios";
        ArrayList<Usuario> result = recuperarPorQuery(queryReturnAll);

        return result;

    }

    public ArrayList<Usuario> recuperarPorQuery(String query) {

        Cursor cursor = dataBase.rawQuery(query, null);

        ArrayList<Usuario> result = new ArrayList<Usuario>();
        if (cursor.moveToFirst()) {
            do {
                ContentValues contentValues = new ContentValues();
                DatabaseUtils.cursorRowToContentValues(cursor, contentValues);
                Usuario t = contentValuesParaEntidade(contentValues);
                result.add(t);
            } while (cursor.moveToNext());
        }
        return result;

    }

    public ContentValues entidadeParacontentValues(Usuario usuario) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("nome", usuario.getNome());
        contentValues.put("senha", usuario.getSenha());
        return contentValues;
    }

    public Usuario contentValuesParaEntidade(ContentValues contentValues) {
        Usuario usuario = new Usuario();
        usuario.setNome(contentValues.getAsString("nome"));
        usuario.setSenha(contentValues.getAsString("senha"));
        return usuario;
    }

    public void fecharConexao() {
        if(dataBase != null && dataBase.isOpen())
            dataBase.close();
    }

}