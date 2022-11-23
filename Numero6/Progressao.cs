using System;

public abstract class Progressao
{
    private int primeiro;
    private int razao;

    public Progressao(int primeiro, int razao)
    {
        this.primeiro = primeiro;
        this.razao = razao;
    }

    public abstract int ProximoValor
    {
        get;
    }
    public int Primeiro
    {
        get { return primeiro; }
        set { primeiro = value; }
    }
    public int Razao
    {
        get { return razao; }
        set { razao = value; }
    }
    public abstract int TermoAt(int posicao);
    public abstract void Reinicializar();
}
