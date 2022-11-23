using System;

public class CertidaoNascimento
{
    private readonly DateTime dataEmissao;
    private readonly Pessoa pessoa;

    public CertidaoNascimento(DateTime dataEmissao, Pessoa pessoa)
    {
        this.dataEmissao = dataEmissao;
        this.pessoa = pessoa;
    }

    public DateTime DataEmissao
    {
        get { return dataEmissao; }
    }
    public Pessoa Pessoa
    {
        get { return pessoa; }
    }
}
