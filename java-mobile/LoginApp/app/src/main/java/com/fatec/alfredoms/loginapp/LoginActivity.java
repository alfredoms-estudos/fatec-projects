package com.fatec.alfredoms.loginapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.util.ArrayList;

import com.fatec.alfredoms.beans.Usuario;
import com.fatec.alfredoms.database.UsuarioDAO;
import com.google.gson.Gson;

public class LoginActivity extends AppCompatActivity {

    private ArrayList<Usuario> userList = new ArrayList<Usuario>();
    private UsuarioDAO dao;

    @Override
    public void onStart() {
        super.onStart();
        dao = new UsuarioDAO(getApplicationContext());
        this.loadList();
    }

    private void loadList(){
        this.userList = this.dao.recuperarTodos();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        // cria usuário padrão
//        userList.add(new Usuario("admin", "admin"));

        Button btnEntrar = (Button) findViewById(R.id.entrar);
        Button btnInserir = (Button) findViewById(R.id.inserir);

        btnEntrar.setOnClickListener(verifyClick);
        btnInserir.setOnClickListener(verifyClick);
    }

    @Override
    protected void onResume() {
        super.onResume();
        this.loadList();
    }

    private View.OnClickListener verifyClick = new View.OnClickListener(){
        public void onClick(View v){
            switch (v.getId()) {
                case R.id.entrar:
                    EditText txtNome = (EditText) findViewById(R.id.name);
                    EditText txtSenha = (EditText) findViewById(R.id.password);

                    Usuario selectedUser = null;
                    for (Usuario user: userList) {
                        if(txtNome.getText().toString().equals(user.getNome()) && txtSenha.getText().toString().equals(user.getSenha())){
                            selectedUser = user;
                        }
                    }
                    if (selectedUser != null){
                        Intent it = new Intent(LoginActivity.this, MainActivity.class);
                        it.putExtra("user", selectedUser);
                        startActivity(it);
                    } else {
                        Toast.makeText(getApplicationContext(), "Login incorreto.", Toast.LENGTH_SHORT).show();
                    }
                    break;
                case R.id.inserir:
                    //Gson gson = new Gson();
                    Intent it = new Intent(LoginActivity.this, UserActivity.class);
                    //it.putExtra("userList", gson.toJson(userList));
                    startActivity(it);
                    break;
                default:
                    Toast.makeText(getApplicationContext(), "Erro ao tentar selecionar opção.", Toast.LENGTH_SHORT).show();
            }

        }
    };

}
