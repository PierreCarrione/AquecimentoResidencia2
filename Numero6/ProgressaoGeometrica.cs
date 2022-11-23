using System;

public class ProgressaoGeometrica : Progressao
{
    int qtdTermos;
    int flag = 1;
    int count = 1;

    public ProgressaoGeometrica(int primeiro, int razao, int qtdTermos)
        : base(primeiro, razao)
    {
        this.qtdTermos = qtdTermos;
    }

    public void auxProxValor()
    {
        count = count * Razao;
    }
    public override int ProximoValor
    {
        get
        {
            if (flag == 1)
            {
                flag = 0;
                return Primeiro;
            }
            auxProxValor();
            return Primeiro * count;
        }
    }
    public override void Reinicializar()
    {
        flag = 1;
        count = 1;
    }
    public override int TermoAt(int posicao)
    {
        if (posicao > 1 && posicao <= qtdTermos)
        {
            return ProximoValor;
        }
        flag = 0;
        return Primeiro;
    }
    public void showPG()
    {
        for (int i = 1; i <= qtdTermos; i++)
        {
            Console.WriteLine(TermoAt(i));
        }
    }
    public static void Main(String[] args)
    {
        ProgressaoGeometrica pg = new ProgressaoGeometrica(3, 4, 10);
        pg.showPG();
        pg.Primeiro = 4;
        pg.Razao = 2;
        pg.qtdTermos = 10;
        pg.Reinicializar();
        pg.showPG();
    }
}
