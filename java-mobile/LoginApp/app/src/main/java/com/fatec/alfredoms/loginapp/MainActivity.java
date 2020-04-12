package com.fatec.alfredoms.loginapp;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.fatec.alfredoms.beans.Usuario;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Intent it = getIntent();
        Usuario user = (Usuario) it.getSerializableExtra("user");
    }
}
