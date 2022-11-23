using System;

public class Aluno
{
    public string nome;
    private int matricula;
    float p1, p2;

    public int Matricula
    {
        get => matricula;
    }

    public float P1
    {
        get => p1;
        set => p1 = value;
    }
    public float P2
    {
        get => p2;
        set => p2 = value;
    }
    public Aluno(string nome, int matricula)
    {
        this.nome = nome;
        this.matricula = matricula;
    }
}