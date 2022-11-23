using System;

public class Turma
{
    private static int globalCod = 0;
    private readonly int codigo;
    private List<Aluno> alunosT;

    public Turma()
    {
        globalCod++;
        codigo = globalCod;
        alunosT = new List<Aluno>();
    }

    public int Codigo
    {
        get { return codigo; }
    }
    public List<Aluno> AlunosT
    {
        get { return alunosT; }
    }
    public void MostrarAlunos()
    {
        List<Aluno> aux = alunosT.OrderBy(x => x.nome).ToList();
        foreach (Aluno aluno in aux)
        {
            Console.WriteLine("Aluno(a): " + aluno.nome);
        }
    }
    public void addAluno(Aluno aluno)
    {
        alunosT.Add(aluno);
    }
    public Boolean verificarAluno(Aluno aluno)
    {
        return alunosT.Contains(aluno);
    }
    //Sobrecarga do método verificarAluno mas como parametro a matricula de um aluno para verificar se ele está na turma especificada
    public Boolean verificarAluno(int matricula)
    {
        return alunosT.Any(x => x.Matricula == matricula);
    }
    public Aluno getAlunoEspecifico(int matricula)
    {
        if (alunosT.Any(aln => aln.Matricula == matricula))
        {
            return alunosT[alunosT.FindIndex(mat => mat.Matricula == matricula)];
        }
        return null;
    }
}
