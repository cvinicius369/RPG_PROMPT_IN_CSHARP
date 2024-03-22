using System;

public class Mapa
{
    private int[,] mapa;

    public Mapa(int largura, int altura)
    {
        mapa = new int[largura, altura];
    }

    public void GerarMapa()
    {
        for (int i = 0; i < mapa.GetLength(0); i++)
        {
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                if (mapa[i, j] == mapa[i=2, j=2]){
                    mapa[i, j] = 1;
                } else { mapa[i, j] = 0; }
            }
        }
    }

    public void ImprimirMapa()
    {
        for (int i = 0; i < mapa.GetLength(0); i++)
        {
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                Console.Write(mapa[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Mapa meuMapa = new Mapa(10, 10);    
        meuMapa.GerarMapa();
        meuMapa.ImprimirMapa();
    }
}
