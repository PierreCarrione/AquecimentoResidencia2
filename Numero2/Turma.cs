using System;

public class Turma
{
    private List<Aluno> alunos;
    int genMat = 0;

    public int gerarMatriculaAln()
    {
        string mat = DateTime.Now.Year.ToString();

        if (genMat < 1000)
        {
            genMat++;
            return int.Parse(mat + "000" + genMat.ToString());
        }
        else if (genMat > 1000 && genMat < 10000)
        {
            genMat++;
            return int.Parse(mat + "00" + genMat.ToString());
        }
        else if (genMat > 10000 && genMat < 100000)
        {
            genMat++;
            return int.Parse(mat + "0" + genMat.ToString());
        }
        genMat++;
        return int.Parse(mat + genMat.ToString());
    }
    public void addAluno(Aluno aluno)
    {
        if (alunos == null)
        {
            alunos = new List<Aluno>();
            alunos.Add(aluno);
        }
        else if (alunos.Contains(aluno))
        {
            Console.WriteLine("Aluno(a) " + aluno.nome + " já está matriculado(a) nessa turma");
        }
        else
        {
            alunos.Add(aluno);
        }
    }
    public void removeAluno(Aluno aluno)
    {
        if (alunos == null)
        {
            Console.WriteLine("Essa turma não possui alunos para remover");
        }
        else if (!alunos.Contains(aluno))
        {
            Console.WriteLine("Aluno(a) " + aluno.nome + " não pertence a essa turma");
        }
        else
        {
            alunos.Remove(aluno);
        }
    }
    public Boolean verificarAluno(int matricula)
    {
        if (alunos.Any(mat => mat.Matricula == matricula))
        {
            return true;
        }
        return false;
    }
    public Boolean verificarAluno(Aluno aluno)
    {
        if (alunos.Contains(aluno))
        {
            return true;
        }
        return false;
    }
    public Aluno getAluno(int matricula)
    {
        if (verificarAluno(matricula))
        {
            return alunos[alunos.FindIndex(mat => mat.Matricula == matricula)];
        }
        return null;
    }
    public void lancarP1(int matricula, float p1)
    {
        if (verificarAluno(matricula))
        {
            alunos[alunos.FindIndex(mat => mat.Matricula == matricula)].P1 = p1;
        }
        else
        {
            Console.WriteLine("Matricula " + matricula + " não encontrada");
        }
    }
    public void lancarP1(Aluno aluno, float p1)
    {
        if (alunos.Contains(aluno))
        {
            alunos[alunos.FindIndex(al => al.Equals(aluno))].P1 = p1;
        }
        else
        {
            Console.WriteLine("Aluno(a) " + aluno.nome + " não encontrado(a)");
        }
    }
    public void lancarP2(int matricula, float p2)
    {
        if (verificarAluno(matricula))
        {
            alunos[alunos.FindIndex(mat => mat.Matricula == matricula)].P2 = p2;
        }
        else
        {
            Console.WriteLine("Matricula " + matricula + " não encontrada");
        }
    }
    public void lancarP2(Aluno aluno, float p2)
    {
        if (alunos.Contains(aluno))
        {
            alunos[alunos.FindIndex(al => al.Equals(aluno))].P2 = p2;
        }
        else
        {
            Console.WriteLine("Aluno(a) " + aluno.nome + " não encontrado(a)");
        }
    }
    public void showAlunos()
    {
        alunos = alunos.OrderBy(x => x.nome).ToList();
        for (int i = 0; i < alunos.Count; i++)
        {
            Console.WriteLine("Mat " + alunos[i].Matricula);
            Console.WriteLine("Aluno(a): " + alunos[i].nome + "\nMédia Final: " + (alunos[i].P1 + alunos[i].P2) / 2);
        }
    }
    public void estatisticasTurma()
    {
        float maiorMF = 0;
        int indiceMaiorMF = 0;
        float mediaP1 = 0;
        float mediaP2 = 0;
        float mediaMF = 0;

        for (int i = 0; i < alunos.Count; i++)
        {
            mediaMF += (alunos[i].P1 + alunos[i].P2) / 2;
            mediaP1 += alunos[i].P1;
            mediaP2 += alunos[i].P2;
            if (maiorMF < (alunos[i].P1 + alunos[i].P2) / 2)
            {
                maiorMF = (alunos[i].P1 + alunos[i].P2) / 2;
                indiceMaiorMF = i;
            }
        }
        mediaP1 = mediaP1 / alunos.Count;
        mediaP2 = mediaP2 / alunos.Count;
        mediaMF = mediaMF / alunos.Count;
        Console.WriteLine("Média p1: " + mediaP1 + "\nMédia p2: " + mediaP2 + "\nMédia da turma: " + mediaMF + "\nMaior média final: " + maiorMF + " - Aluno: " +
            alunos[indiceMaiorMF].nome + "\n\t\t\t Matrícula: " + alunos[indiceMaiorMF].Matricula);
    }
}