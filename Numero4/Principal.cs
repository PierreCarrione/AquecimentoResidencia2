using System;

public class Principal
{
    public static void Main(String[] args)
    {
        Pessoa pierre = new Pessoa("Pierre");
        Pessoa pedro = new Pessoa("pedro");
        CertidaoNascimento cert = new CertidaoNascimento(DateTime.Now, pierre);
        CertidaoNascimento certi = new CertidaoNascimento(DateTime.Now, pedro);
        pierre.Certidao = cert;
        pedro.Certidao = certi;
        pierre.showDados();
        pedro.showDados();
        pierre.Certidao = certi;
    }
}
