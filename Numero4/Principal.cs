using System;

public class Principal
{
    public static void Main(String[] args)
    {
        Pessoa pierre = new Pessoa("Pierre");
        CertidaoNascimento cert = new CertidaoNascimento(DateTime.Now, pierre);
        CertidaoNascimento certi = new CertidaoNascimento(DateTime.Now, pierre);
        pierre.Certidao = cert;
        pierre.showDados();
        pierre.Certidao = certi;
    }
}