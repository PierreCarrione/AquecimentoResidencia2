using System;

public class Principal
{
    public static void Main(String[] args)
    {
        Turma residencia = new Turma();
        Aluno pierre = new Aluno("pierre", residencia.gerarMatriculaAln());
        residencia.addAluno(pierre);
        residencia.addAluno(new Aluno("emanuele", residencia.gerarMatriculaAln()));
        Console.WriteLine(residencia.verificarAluno(20220002));
        residencia.lancarP1(pierre, 9);
        residencia.lancarP2(pierre, 10);
        residencia.lancarP1(residencia.getAluno(20220002), 7);
        residencia.lancarP2(residencia.getAluno(20220002), 8);
        residencia.showAlunos();
        Console.WriteLine();
        residencia.estatisticasTurma();
    }
}