using System;

public class Curso
{
    public string nome;
    private List<Aluno> alunos;
    private List<Turma> turmas;
    private int genMat = 0;

    public Curso(string nome)
    {
        this.nome = nome;
        alunos = new List<Aluno>();
        turmas = new List<Turma>();
    }

    //Função que deverá ser passada quando um aluno for criado
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
    public void MatricularAluno(Aluno aluno)
    {
        if (alunos.Contains(aluno))
        {
            Console.WriteLine("Aluno(a) " + aluno.nome + " já está matriculado(a) nesse curso");
        }
        else
        {
            alunos.Add(aluno);
        }
    }
    public void removerAluno(Aluno aluno)
    {
        if (alunos.Count == 0)
        {
            Console.WriteLine("Não há alunos cadastrados");
        }
        else if (!alunos.Contains(aluno))
        {
            Console.WriteLine("Aluno(a) " + aluno.nome + " não encontrado(a)");
        }
        else if (turmas.Any(aln => aln.verificarAluno(aluno) == true))
        {
            Console.WriteLine("Aluno(a) " + aluno.nome + " está vinculado a uma turma e não pode ser removido(a)");
        }
        else
        {
            alunos.Remove(aluno);
            Console.WriteLine("Aluno(a) " + aluno.nome + " removido(a) com sucesso!");
        }
    }
    //Sobrecarga do método removeAluno mas como parâmetro a matricula de um aluno para ser feita sua remoção
    public void removerAluno(int matricula)
    {
        if (alunos.Count == 0)
        {
            Console.WriteLine("Não há alunos cadastrados a serem removidos");
        }
        else if (!alunos.Any(al => al.Matricula == matricula))
        {
            Console.WriteLine("Aluno(a) " + alunos[alunos.FindIndex(mat => mat.Matricula == matricula)].nome + " não encontrado(a)");
        }
        else if (turmas.Any(aln => aln.verificarAluno(matricula)))
        {
            Console.WriteLine("Aluno(a) " + alunos[alunos.FindIndex(mat => mat.Matricula == matricula)].nome + " está vinculado a uma turma e não pode ser removido(a)");
        }
        else
        {
            alunos.Remove(alunos[alunos.FindIndex(mat => mat.Matricula == matricula)]);
            Console.WriteLine("Aluno(a) " + alunos[alunos.FindIndex(mat => mat.Matricula == matricula)].nome + " removido(a) com sucesso!");
        }
    }
    public void criarTurma(Turma turma)
    {
        if (turmas.Contains(turma))
        {
            Console.WriteLine("A turma de código " + turma.Codigo + " já existe, crie uma turma diferente ou adicione alunos a essa turma.");
        }
        else
        {
            turmas.Add(turma);
        }
    }
    public void removerTurma(Turma turma)
    {
        if (turmas.Contains(turma))
        {
            if (turmas[turmas.IndexOf(turma)].AlunosT.Count == 0)
            {
                turmas.Remove(turma);
                Console.WriteLine("Turma de código " + turma.Codigo + " removida com sucesso!");
            }
            else
            {
                Console.WriteLine("A turma de código " + turma.Codigo + " contém alunos e por isso não pode ser removida.Remova os alunos da turma para poder excluí-la.");
            }
        }
        else
        {
            Console.WriteLine("Turma não criada");
        }
    }
    public void inserirAlunoTurma(Turma turma, Aluno aluno)
    {
        if (turmas.Contains(turma))//Verifica se essa turma já foi criada no curso
        {
            List<Turma> aux = turmas.FindAll(turmas => turmas.verificarAluno(aluno));//Irá retornar a quantas turmas esse aluno pertence
                                                                                     //O aluno só pode pertencer a uma turma, então se aux.count for igual a 1 o aluno já pertence a uma turma. Com isso, não será adicionado novamente 
                                                                                     //Na mesma turma nem em outra

            if (aux.Count == 0)
            {
                if (alunos.Contains(aluno))
                {
                    turmas[turmas.IndexOf(turma)].addAluno(aluno);
                }
                else
                {
                    Console.WriteLine("Aluno(a) " + aluno.nome + " não matriculado(a) nesse curso");
                }
            }
            else
            {
                Console.WriteLine("Aluno(a) " + aluno.nome + " já pertence a uma turma. Só é permitido um aluno pertencer a uma turma por vez.");
            }
        }
        else
        {
            Console.WriteLine("Turma " + turma.Codigo + " não encontrada, crie essa turma para poder adicionar/remover alunos");
        }
    }
    public Boolean removerAlunoTurma(Turma turma, Aluno aluno)
    {
        if (turmas.Contains(turma))
        {
            if (turmas[turmas.IndexOf(turma)].verificarAluno(aluno))
            {
                turmas[turmas.IndexOf(turma)].AlunosT.Remove(aluno);
                Console.WriteLine("Aluno(a) " + aluno.nome + " removido(a) da turma " + turma.Codigo + " com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Aluno(a) " + aluno.nome + " não está cadatrado(a) na turma " + turma.Codigo);
                return false;

            }
        }
        Console.WriteLine("Turma " + turma.Codigo + " não encontrada, crie essa turma para poder adicionar/remover alunos");
        return false;
    }
    public void mostrarAlunosTurma(Turma turma)
    {
        if (turmas.Contains(turma))
        {
            turmas[turmas.IndexOf(turma)].MostrarAlunos();
        }
    }
    public void mostrarTodasTurmas()
    {
        for (int i = 0; i < turmas.Count; i++)
        {
            Console.WriteLine("Turma : " + turmas[i].Codigo);
            turmas[i].MostrarAlunos();
        }
    }
    public Turma getTurmaEspecifica(int codigo)
    {
        if (turmas.Any(cod => cod.Codigo == codigo))
        {
            return turmas[turmas.FindIndex(cod => cod.Codigo == codigo)];
        }
        return null;
    }
    public Aluno getAlnEspecifico(int matricula)
    {
        if (alunos.Any(mat => mat.Matricula == matricula))
        {
            return alunos[alunos.FindIndex(mat => mat.Matricula == matricula)];
        }
        return null;
    }
}
