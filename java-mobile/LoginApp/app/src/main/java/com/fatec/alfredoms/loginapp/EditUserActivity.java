package com.fatec.alfredoms.loginapp;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.fatec.alfredoms.beans.Usuario;
import com.fatec.alfredoms.database.UsuarioDAO;

import java.util.ArrayList;

public class EditUserActivity extends AppCompatActivity {
    private ArrayList<Usuario> userList;
    private UsuarioDAO dao;
    private String selectedUser;

    private void loadList(){
        this.userList = this.dao.recuperarTodos();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_user);

        Button btnUpdate = (Button) findViewById(R.id.btn_update);
        Button btnVoltar= (Button) findViewById(R.id.btn_voltar);

        btnUpdate.setOnClickListener(verifyClick);
        btnVoltar.setOnClickListener(verifyClick);
    }

    @Override
    protected void onResume() {
        super.onResume();
        this.loadList();
        this.update();
    }

    private void clean(){
        EditText txtNome = (EditText) findViewById(R.id.editText);
        EditText txtSenha = (EditText) findViewById(R.id.senha);
        txtNome.setText("");
        txtSenha.setText("");
    }

    private void update(){
        this.clean();
        Intent it = getIntent();
        selectedUser = (String) it.getSerializableExtra("nome");
        if (selectedUser.equals("")){
            Button btnUpdate = (Button) findViewById(R.id.btn_update);
            btnUpdate.setText("Inserir");
        } else {
            EditText txtNome = (EditText) findViewById(R.id.editText);
            txtNome.setText(selectedUser);
        }
    }

    @Override
    public void onStart() {
        super.onStart();
        dao = new UsuarioDAO(getApplicationContext());
        this.loadList();
        this.update();
    }

    private View.OnClickListener verifyClick = new View.OnClickListener() {
        public void onClick(View v) {
            EditText txtNome = (EditText) findViewById(R.id.editText);
            EditText txtSenha = (EditText) findViewById(R.id.senha);

                switch (v.getId()) {
                    case R.id.btn_update:
                        if (txtNome.getText().toString().equals("") || txtSenha.getText().toString().equals("")) {
                            Toast.makeText(getApplicationContext(), "Preencha os campos de usuário e senha!", Toast.LENGTH_SHORT).show();
                        } else {

                            if (selectedUser.equals("")) {
                                boolean user_exists = false;
                                for (Usuario user : userList) {
                                    if (txtNome.getText().toString().equals(user.getNome())) {
                                        user_exists = true;
                                    }
                                }

                                if (!user_exists) {
                                    Usuario usuario = new Usuario();
                                    usuario.setNome(txtNome.getText().toString());
                                    usuario.setSenha(txtSenha.getText().toString());
                                    dao.inserir(usuario);
                                    Toast.makeText(getApplicationContext(), "Usuário incluído com sucesso!", Toast.LENGTH_SHORT).show();
                                    finish();
                                } else {
                                    Toast.makeText(getApplicationContext(), "Esse usuário já existe! Escolha outro login.", Toast.LENGTH_SHORT).show();
                                }
                            } else {
                                boolean user_exists = false;
                                for (Usuario user : userList) {
                                    if (txtNome.getText().toString().equals(user.getNome()) && !selectedUser.equals(txtNome.getText().toString())) {
                                        user_exists = true;
                                    }
                                }

                                if (!user_exists) {
                                    Usuario usuario = new Usuario();
                                    usuario.setNome(txtNome.getText().toString());
                                    usuario.setSenha(txtSenha.getText().toString());
                                    dao.atualizar(usuario, selectedUser);
                                    Toast.makeText(getApplicationContext(), "Usuário atualizado com sucesso!", Toast.LENGTH_SHORT).show();
                                    finish();
                                } else {
                                    Toast.makeText(getApplicationContext(), "Esse usuário já existe! Escolha outro login para atualizar.", Toast.LENGTH_SHORT).show();
                                }
                            }
                        }
                        break;
                    case R.id.btn_voltar:
                        finish();
                        break;
                    default:
                        Toast.makeText(getApplicationContext(), "Erro ao tentar selecionar opção.", Toast.LENGTH_SHORT).show();
                }

        }
    };
}
