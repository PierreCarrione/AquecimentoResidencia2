using System;

public class Aluno
{
    public string nome;
    private readonly int matricula;
    private Turma turma;

    public Aluno(string nome, int matricula)
    {
        this.nome = nome;
        this.matricula = matricula;
    }

    public int Matricula
    {
        get { return matricula; }
    }
    public Turma Turma
    {
        get { return turma; }
        set { turma = value; }
    }
}
