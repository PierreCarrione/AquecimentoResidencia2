using System;

public class Principal
{
    public static void Main(String[] args)
    {
        Propriedades prop = new Propriedades("C:\\Users\\Pierre\\Documents\\VisualStudio\\Lista2\\Numero7\\propriedades.txt");
        try
        {
            //prop.inserirChave("url=http://empresa.com.br/app");
            //prop.inserirChave("porta = 8080");
            //prop.inserirChave("endereco = 192.161.35.101");
            //prop.inserirChave("email = admin@gmai.com");
            Console.WriteLine(prop.recuperarValorChave("url"));
            prop.alterarValorChave("email", "admin@hotmail.com");
            Console.WriteLine(prop.verificarChave("email"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}