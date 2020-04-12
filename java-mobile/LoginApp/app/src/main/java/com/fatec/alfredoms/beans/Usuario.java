package com.fatec.alfredoms.beans;
import java.io.Serializable;
/**
 * Created by Aluno on 02/09/2017.
 */

public class Usuario implements Serializable {

    private String nome;
    private String senha;

    public Usuario(){

    }

    public Usuario(String _nome, String _senha){
        this.setNome(_nome);
        this.setSenha(_senha);
    }

    public void setNome(String _nome){
        this.nome = _nome;
    }

    public void setSenha(String _senha){
        this.senha = _senha;
    }

    public String getNome(){
        return this.nome;
    }

    public String getSenha(){
        return this.senha;
    }

}
