package com.fatec.alfredoms.database;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

/**
 * Created by alfma on 21/09/2017.
 */

public class DataBaseHelper extends SQLiteOpenHelper {
    private static final String _dataBaseName = "cadastro_usuarios";
    private static final int _version  = 1;

    private static DataBaseHelper instance;

    public static DataBaseHelper getInstance(Context context) {
        if(instance == null)
            instance = new DataBaseHelper(context);

        return instance;
    }

    public DataBaseHelper(Context context) {
        super(context, _dataBaseName, null, _version);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE IF NOT EXISTS usuarios ("
                + "nome varchar PRIMARY KEY, senha varchar NOT NULL)");
        Log.i("DATABASE", "CRIANDO TABELA");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        Log.i("DATABASE", "ATUALIZANDO TABELA");
        db.execSQL("DROP TABLE IF EXISTS usuarios");
        onCreate(db);
    }

}