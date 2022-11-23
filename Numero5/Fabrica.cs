using System;

public class MesmoMotor : Exception
{
    public MesmoMotor(String message)
        : base(message) { }
}

public class Fabrica
{
    List<Carro> carros;

    public Fabrica()
    {
        carros = new List<Carro>();
    }

    public void addCarro(Carro carro)
    {
        if (carros.Any(car => car.Motor.Equals(carro.Motor)))
        {
            throw new MesmoMotor("O motor do carro " + carro.modelo + " já pertence a outro carro");
        }
        else
        {
            carros.Add(carro);
            Console.WriteLine("Carro adicionado com sucesso!");
        }
    }
    public void excluirCarro(Carro carro)
    {
        if (carros.Contains(carro))
        {
            carros.Add(carro);
            Console.WriteLine("Carro adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Carro não pertence a essa fábrica");
        }
    }
    public void trocarMotor(Motor motor, Carro carro)
    {
        if (carros.Contains(carro))
        {
            if (!carros.Any(moto => moto.Motor.Equals(motor) == true))
            {
                carros[carros.IndexOf(carro)].Motor = motor;
            }
            else
            {
                throw new MesmoMotor("Esse motor já pertence a um carro");
            }
        }
        else
        {
            Console.WriteLine("Carro " + carro.modelo + " de placa " + carro.Placa + " não localizado na fábrica.");
        }
    }
    public void showDados()
    {
        for (int i = 0; i < carros.Count; i++)
        {
            carros[i].showDado();
        }
    }
}
