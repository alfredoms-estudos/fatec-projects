package com.fatec.alfredoms.loginapp;

import android.content.Context;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.ListViewCompat;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;


import com.fatec.alfredoms.beans.Usuario;
import com.fatec.alfredoms.database.UsuarioDAO;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.util.ArrayList;
import java.util.List;



public class UserActivity extends AppCompatActivity {

    private ArrayList<Usuario> userList;
    private ArrayAdapter<String> adapter;
    private ListView list;
    private String selectedItem;
    private int selectedItemID;
    private UsuarioDAO dao;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user);

        Button btnInserir = (Button) findViewById(R.id.inserir);
        Button btnVoltar= (Button) findViewById(R.id.voltar);
        Button btnRemover = (Button) findViewById(R.id.remover);
        Button btnEditar = (Button) findViewById(R.id.editar);
        list = (ListView) findViewById(R.id.lista);

        btnVoltar.setOnClickListener(verifyClick);
        btnInserir.setOnClickListener(verifyClick);
        btnRemover.setOnClickListener(verifyClick);
        btnEditar.setOnClickListener(verifyClick);
        list.setOnItemClickListener(verifyItemClick);
    }

    private void loadList(){
        this.userList = this.dao.recuperarTodos();
    }

    @Override
    public void onPause(){
        super.onPause();

    }

    @Override
    public void onResume(){
        super.onResume();
        this.loadList();
    }

    @Override
    public void onStart() {
        super.onStart();
        dao = new UsuarioDAO(getApplicationContext());
        this.loadList();
        this.clearSelected();
//        Intent it = getIntent();
//        String userString = (String) it.getSerializableExtra("userList");
//        Gson gson = new Gson();
//        userList = gson.fromJson(userString, new TypeToken<List<Usuario>>(){}.getType());
        final ArrayList<String> stringList = new ArrayList<String>();
        for (int i = 0; i < userList.size(); i++) {
            stringList.add(userList.get(i).getNome());
        }

        adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_activated_1, stringList);
        list.setAdapter(adapter);
        list.setChoiceMode(ListView.CHOICE_MODE_SINGLE);
    }

    private void clearSelected(){
        this.selectedItem = "";
        this.selectedItemID = -1;
    }

    private void removeItem(String item){
        Usuario itemToRemove = null;
        for (Usuario user: userList) {
            if(item.equals(user.getNome())){
                itemToRemove = user;
                userList.remove(item);
            }
        }

        if (selectedItemID != -1 && !selectedItem.equals("") && itemToRemove != null) {
            this.dao.remover(itemToRemove);
            adapter.remove(selectedItem);
            adapter.notifyDataSetChanged();

            Toast.makeText(getApplicationContext(), "Item " + selectedItem + " removido com sucesso!", Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(getApplicationContext(), "Selecione um usuário para remover!", Toast.LENGTH_SHORT).show();
        }

        this.clearSelected();
    }

    private View.OnClickListener verifyClick = new View.OnClickListener() {
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.inserir:
                    Intent it = new Intent(UserActivity.this, EditUserActivity.class);
                    it.putExtra("nome", "");
                    startActivity(it);
                    break;
                case R.id.voltar:
                    finish();
                    break;
                case R.id.remover:
                    removeItem(selectedItem);
                    break;
                case R.id.editar:
                    Intent it_edit = new Intent(UserActivity.this, EditUserActivity.class);
                    if (!selectedItem.equals("") && selectedItemID != -1) {
                        it_edit.putExtra("nome", selectedItem);
                        startActivity(it_edit);
                    }else {
                        Toast.makeText(getApplicationContext(), "Selecione um usuário para editar!", Toast.LENGTH_SHORT).show();
                    }
                    break;
                case R.id.lista:
                    selectedItem = list.getSelectedItem().toString();
                    break;
                default:
                    Toast.makeText(getApplicationContext(), "Erro ao tentar selecionar opção.", Toast.LENGTH_SHORT).show();
            }
        }
    };

    private ListView.OnItemClickListener verifyItemClick = new ListView.OnItemClickListener() {
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            selectedItem = list.getItemAtPosition(position).toString();
            list.setItemChecked(position, true);
            selectedItemID= position;
            adapter.notifyDataSetChanged();
            Toast.makeText(getApplicationContext(), selectedItem, Toast.LENGTH_SHORT).show();
        }
    };



}
