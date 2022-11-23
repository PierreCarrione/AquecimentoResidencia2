using System;

public class Motor
{
    private readonly float cilindradas;
    public Motor(float cilindradas)
    {
        this.cilindradas = cilindradas;
    }
    public float Cilindradas
    {
        get { return cilindradas; }
    }
}
