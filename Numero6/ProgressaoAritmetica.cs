using System;

public class ProgressaoAritmetica : Progressao
{
    int qtdTermos;
    int flag = 1;
    int count = 0;

    public ProgressaoAritmetica(int primeiro, int razao, int qtdTermos)
        : base(primeiro, razao)
    {
        this.qtdTermos = qtdTermos;
    }

    public void auxProxValor()
    {
        count = count + Razao;
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
            return Primeiro + count;
        }
    }
    public override void Reinicializar()
    {
        flag = 1;
        count = 0;
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
    public void showPA()
    {
        for (int i = 1; i <= qtdTermos; i++)
        {
            Console.WriteLine(TermoAt(i));
        }
    }
    public static void Main(String[] args)
    {
        ProgressaoAritmetica pa = new ProgressaoAritmetica(3, 4, 10);
        pa.showPA();
        pa.Primeiro = 4;
        pa.Razao = 2;
        pa.qtdTermos = 10;
        pa.Reinicializar();
        pa.showPA();
    }
}
