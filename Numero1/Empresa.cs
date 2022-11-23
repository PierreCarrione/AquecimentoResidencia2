using System;

public class Empresa
{
    private List<Cliente> clientes;
    private string nome;
    Cadastro cadastrar;
    public Empresa(string nome)
    {
        clientes = new List<Cliente>();
        this.nome = nome;
        cadastrar = new Cadastro();
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public void addCliente()
    {
        clientes.Add(cadastrar.cadastrarCliente());
    }

    public void showClientes()
    {
        for (int i = 0; i < clientes.Count; i++)
        {
            clientes[i].imprimiDados();
        }
    }
}
