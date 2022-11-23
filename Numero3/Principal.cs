using System;

public class Principal
{
    public static void Main(String[] args)
    {
        Curso prc = new Curso("PRC Desenvolvedora");
        Turma a = new Turma();
        Aluno pierre = new Aluno("pierre", prc.gerarMatriculaAln());
        prc.criarTurma(a);
        prc.criarTurma(new Turma());
        prc.MatricularAluno(pierre);
        prc.MatricularAluno(new Aluno("emanuele", prc.gerarMatriculaAln()));
        prc.inserirAlunoTurma(a, pierre);
        prc.inserirAlunoTurma(prc.getTurmaEspecifica(2), prc.getAlnEspecifico(20220002));
        prc.mostrarTodasTurmas();
        prc.inserirAlunoTurma(a, pierre);
        prc.removerTurma(prc.getTurmaEspecifica(1));
        Aluno pedro = new Aluno("pedro", prc.gerarMatriculaAln());
        prc.removerAlunoTurma(a, pedro);
        prc.removerTurma(prc.getTurmaEspecifica(3));
        prc.removerAlunoTurma(a, pierre);
        prc.mostrarTodasTurmas();
        prc.inserirAlunoTurma(a, pierre);
        prc.mostrarTodasTurmas();
    }
}