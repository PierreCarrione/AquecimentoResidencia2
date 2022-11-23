using System;
using System.Text.RegularExpressions;
using System.Linq;


public class Cadastro
{
    Cliente cliente;

    //Lê os dados do console
    public void lerDados()
    {
        cliente.nome = Console.ReadLine();
        cliente.Cpf = long.Parse(Console.ReadLine());
        cliente.DataNasc = DateTime.Parse(Console.ReadLine());
        cliente.RendaMensal = float.Parse(Console.ReadLine());
        cliente.EstCivil = char.Parse(Console.ReadLine());
        cliente.Dependentes = int.Parse(Console.ReadLine());
    }

    //Função que verifica se o cpf é válido
    public Boolean verificaCpf()
    {
        string auxCpf = cliente.Cpf.ToString();
        int freq = auxCpf.Count(f => (f == auxCpf[0]));
        int dvJ = int.Parse(auxCpf[0].ToString()) * 10 + int.Parse(auxCpf[1].ToString()) * 9 +
            int.Parse(auxCpf[2].ToString()) * 8 + int.Parse(auxCpf[3].ToString()) * 7 +
            int.Parse(auxCpf[4].ToString()) * 6 + int.Parse(auxCpf[5].ToString()) * 5 +
            int.Parse(auxCpf[6].ToString()) * 4 + int.Parse(auxCpf[7].ToString()) * 3 + int.Parse(auxCpf[8].ToString()) * 2;
        int dvK = int.Parse(auxCpf[0].ToString()) * 11 + int.Parse(auxCpf[1].ToString()) * 10 +
            int.Parse(auxCpf[2].ToString()) * 9 + int.Parse(auxCpf[3].ToString()) * 8 +
            int.Parse(auxCpf[4].ToString()) * 7 + int.Parse(auxCpf[5].ToString()) * 6 +
            int.Parse(auxCpf[6].ToString()) * 5 + int.Parse(auxCpf[7].ToString()) * 4 +
            int.Parse(auxCpf[8].ToString()) * 3 + int.Parse(auxCpf[9].ToString()) * 2;

        //Se cpf for com todos os numeros iguais ou de tamanho diferente de 11
        if (cliente.Cpf.ToString().Length != 11 || freq == 11)
        {
            return false;
        }
        //Verifica se o digito J ou K para o resto da divisão entre 0 e 1 é diferente de 0.
        if (((dvJ % 11 == 0 || dvJ % 11 == 1) && int.Parse(auxCpf[9].ToString()) != 0) || ((dvK % 11 == 0 || dvK % 11 == 1) && int.Parse(auxCpf[10].ToString()) != 0))
        {
            return false;
        }
        //Verifica se o resto da divisão está entre 2 a 10 e se o valor J ou K é igual a 11-resto
        if ((dvJ % 11 > 10 || dvJ % 11 < 0) || (dvK % 11 > 10 || dvK % 11 < 0) || (11 - dvJ % 11 != int.Parse(auxCpf[9].ToString())) || (11 - dvK % 11 != int.Parse(auxCpf[10].ToString())))
        {
            return false;
        }

        return true;
    }
    //Função que irá fazer a leitura dos dados que ainda estão errados
    public void lerDadosErrados()
    {
        if (!Regex.IsMatch(cliente.nome, @"^\w{5,}$"))
        {
            Console.WriteLine("Digite novamente seu nome");
            cliente.nome = Console.ReadLine();
        }
        if (!verificaCpf())
        {
            Console.WriteLine("Digite novamente seu cpf");
            cliente.Cpf = long.Parse(Console.ReadLine());
        }
        if (((DateTime.Now - cliente.DataNasc).Days / 365 < 18))
        {
            Console.WriteLine("Digite novamente sua data de nascimento");
            cliente.DataNasc = DateTime.Parse(Console.ReadLine());
        }
        if (!Regex.IsMatch(cliente.RendaMensal.ToString(), @"^\d{2}\.\d$"))
        {
            Console.WriteLine("Digite novamente sua renda mensal");
            cliente.RendaMensal = float.Parse(Console.ReadLine());
        }
        if (!Regex.IsMatch(cliente.EstCivil.ToString(), @"[s]|[v]|[d]|[c]", RegexOptions.IgnoreCase))
        {
            Console.WriteLine("Digite novamente seu estado civil");
            cliente.EstCivil = char.Parse(Console.ReadLine());
        }
        if (cliente.Dependentes > 10 || cliente.Dependentes < 0)
        {
            Console.WriteLine("Digite novamente seu número de dependentes");
            cliente.Dependentes = int.Parse(Console.ReadLine());
        }
    }
    //Função que irá printar os campos que não estão conforme as especificações
    public void showListaErros()
    {
        if (!Regex.IsMatch(cliente.nome, @"^\w{5,}$"))
        {
            Console.WriteLine("Campo nome \"" + cliente.nome + "\" não atende ao requisito de ter pelo menos 5 caracteres");
        }
        if (!verificaCpf())
        {
            Console.WriteLine("Campo cpf \"" + cliente.nome + "\" não é válido");
        }
        if (((DateTime.Now - cliente.DataNasc).Days / 365 < 18))
        {
            Console.WriteLine("Campo data \"" + cliente.DataNasc + "\" não atende ao requisito de ter pelo menos 18 anos na data atual");
        }
        if (!Regex.IsMatch(cliente.RendaMensal.ToString(), @"^\d{2}\.\d$"))
        {
            Console.WriteLine("Campo renda mensal \"" + cliente.RendaMensal + "\" não atende ao requisito de ter duas casas decimais e vírgula decimal");
        }
        if (!Regex.IsMatch(cliente.EstCivil.ToString(), @"[s]|[v]|[d]|[c]", RegexOptions.IgnoreCase))
        {
            Console.WriteLine("Campo estado civil \"" + cliente.EstCivil + "\" é aceito somente as letras: C, S, V ou D(Maiúsculo ou Minúsculo)");
        }
        if (cliente.Dependentes > 10 || cliente.Dependentes < 0)
        {
            Console.WriteLine("Campo dependentes \"" + cliente.Dependentes + "\" não atende ao requisito de ter somente valores de 0 a 10");
        }
    }
    //Função que irá validar se todos os dados estão corretos,caso algum não esteja sera mostrado na tela e solicitado sua leitura novamente
    public void validaDados()
    {
        Boolean aux = Regex.IsMatch(cliente.nome, @"^\w{5,}$") && ((DateTime.Now - cliente.DataNasc).Days / 365 > 18) && Regex.IsMatch(cliente.RendaMensal.ToString(), @"^\d{2}\.\d$") &&
            Regex.IsMatch(cliente.EstCivil.ToString(), @"[s]|[v]|[d]|[c]", RegexOptions.IgnoreCase) && (cliente.Dependentes <= 10 && cliente.Dependentes >= 0) && verificaCpf();

        if (aux)
        {
            cliente.imprimiDados();
        }
        else
        {
            while (!aux)
            {
                showListaErros();
                lerDadosErrados();
                aux = Regex.IsMatch(cliente.nome, @"^\w{5,}$") && ((DateTime.Now - cliente.DataNasc).Days / 365 > 18) && Regex.IsMatch(cliente.RendaMensal.ToString(), @"^\d{2}\.\d$") &&
                        Regex.IsMatch(cliente.EstCivil.ToString(), @"[s]|[v]|[d]|[c]", RegexOptions.IgnoreCase) && (cliente.Dependentes <= 10 && cliente.Dependentes >= 0) && verificaCpf();
            }
            cliente.imprimiDados();
        }
    }
    public Cliente cadastrarCliente()
    {
        cliente = new Cliente();
        lerDados();
        validaDados();
        return cliente;
    }
}