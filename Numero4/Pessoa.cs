using System;

public class Pessoa
{
    private string nome;
    private CertidaoNascimento certidao;
    private int check;

    public Pessoa(string nome)
    {
        this.nome = nome;
    }

    public string Nome
    {
        get { return nome; }
    }
    public CertidaoNascimento Certidao
    {
        get { return certidao; }
        set
        {
            if (check == 0)
            {
                certidao = value;
                check++;
            }
            else
            {
                Console.WriteLine("Não é possível alterar a certidão de uma pessoa");
            }
        }
    }
    public void showDados()
    {
        Console.WriteLine("Nome: " + nome);
        if (certidao != null)
        {
            Console.WriteLine("Data de emissão: " + certidao.DataEmissao);
        }
    }
}
