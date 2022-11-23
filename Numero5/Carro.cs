using System;

public class Carro
{
    private readonly string placa;
    public readonly string modelo;
    private Motor motor;

    public Carro(string placa, string modelo, Motor motor)
    {
        this.placa = placa;
        this.modelo = modelo;
        this.motor = motor;
    }

    public string Placa
    {
        get { return placa; }
    }
    public Motor Motor
    {
        get { return motor; }
        set { motor = value; }
    }
    public int calVelMax()
    {
        if (motor.Cilindradas <= 1.0)
        {
            return 140;
        }
        else if (motor.Cilindradas > 1.0 && motor.Cilindradas <= 1.6)
        {
            return 160;
        }
        else if (motor.Cilindradas > 1.6 && motor.Cilindradas <= 2.0)
        {
            return 180;
        }
        return 220;
    }
    public void showDado()
    {
        Console.WriteLine("Placa: " + placa + "\nModelo: " + modelo + "\nCilindradas: " + motor.Cilindradas);
    }
}
