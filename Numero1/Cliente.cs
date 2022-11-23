using System;
using System.Text.RegularExpressions;

public class Cliente
{
    public string nome;
    private long cpf;
    private DateTime dataNasc;
    private float rendaMensal;
    private char estCivil;
    private int dependentes;

    public long Cpf
    {
        get => cpf;
        set => cpf = value;
    }
    public DateTime DataNasc
    {
        get => dataNasc;
        set => dataNasc = value;
    }
    public float RendaMensal
    {
        get => rendaMensal;
        set => rendaMensal = value;
    }
    public char EstCivil
    {
        get => estCivil;
        set => estCivil = value;
    }
    public int Dependentes
    {
        get => dependentes;
        set => dependentes = value;
    }
    public void imprimiDados()
    {
        Console.WriteLine("Nome : " + (nome) + "\nCpf : " + (cpf) + "\nData de Nascimento : " + (dataNasc) + "\nRenda Mensal : " + (rendaMensal) +
                "\nEstado Civil : " + (estCivil) + "\nDependentes : " + (dependentes));
    }
}