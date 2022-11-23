using System;
using System.IO;
using System.Text.RegularExpressions;

public class erroChave : Exception
{
    public erroChave(String message)
        : base(message) { }
}

public class Propriedades
{
    private string path;
    Regex rg;

    public Propriedades()
    {

    }

    public Propriedades(string path)
    {
        this.path = path;
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
        rg = new Regex(@"^\w+\s?\=\s?.+$");
    }

    public string Path
    {
        get { return path; }
        set
        {
            path = value;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
    }
    public string recuperarValorChave(string chave)
    {
        if (path.Equals(null))
        {
            Console.WriteLine("Diretório não definido.Primeiro defina um diretório válido para realizar a busca.");
        }
        else
        {
            string[] lines = File.ReadAllLines(path);

            if (verificarChave(chave))
            {
                int aux = Array.FindIndex(lines, val => val.Contains(chave));
                return lines[aux].Split('=')[1];
            }
            else
            {
                return null;
            }
        }
        return null;
    }
    public void alterarValorChave(string chave, string novoValor)
    {
        if (verificarChave(chave))
        {
            string[] lines = File.ReadAllLines(path);
            int aux = Array.FindIndex(lines, val => val.Contains(chave));
            lines[aux] = lines[aux].Replace(lines[aux].Split('=')[1], novoValor);
            File.WriteAllLines(path, lines);
            Console.WriteLine("Valor alterado com sucesso!");
        }
        else
        {
            throw new erroChave("Essa chave não existe no arquivo");
        }
    }
    //Verifica se o conjunto chave=valor existe
    public Boolean verificarChaveValor(string chaveValor)
    {
        string[] lines = File.ReadAllLines(path);
        if (lines.Contains(chaveValor))
        {
            return true;
        }
        return false;
    }
    //Verifica somente se a chave existe no arquivo
    public Boolean verificarChave(string chave)
    {
        string[] lines = File.ReadAllLines(path);
        if (lines.Any(chv => chv.Contains(chave)))
        {
            return true;
        }
        return false;
    }
    //Considerei que será feita a inserção do conjunto chave=valor, pois o txt é composto nesse formato.
    public void inserirChave(string chaveValor)
    {
        if (rg.IsMatch(chaveValor))
        {
            string[] lines = File.ReadAllLines(path);

            if (verificarChaveValor(chaveValor))
            {
                throw new erroChave("Essa chave já existe no arquivo");
            }
            else
            {
                if (path == null)
                {
                    Console.WriteLine("Diretório não definido.Primeiro defina um diretório válido para realizar a inserção.");
                }
                else
                {
                    StreamWriter sw = File.AppendText(path);
                    sw.WriteLine(chaveValor);
                    sw.Close();
                    Console.WriteLine("Conjunto chave=valor adicionado com sucesso!");
                }
            }
        }
        else
        {
            Console.WriteLine("São aceito somente valores na forma chave(string)=valor(string)");
        }

    }
}
