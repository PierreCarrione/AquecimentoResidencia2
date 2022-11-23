using System;

public class Principal
{
    public static void Main(String[] args)
    {
        Fabrica fab = new Fabrica();
        Motor mot = new Motor(1.4F);
        Motor mot1 = new Motor(1.6F);
        Carro prisma = new Carro("klp1g24", "prisma", mot);
        Carro onix = new Carro("klp1g25", "onix", mot);
        fab.showDados();

        try
        {
            fab.addCarro(prisma);
            fab.addCarro(onix);
            fab.trocarMotor(mot, prisma);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
        fab.showDados();
    }
}