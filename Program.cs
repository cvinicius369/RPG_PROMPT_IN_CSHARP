//Atributos do sistema
using System;
using System.Runtime.InteropServices;

//Classes
//Classe Loja
class Loja
{
    public static int[] itens;
    public static int[] valores;
    //Função para criar loja
    public static int Negocios()
    {
        //Variaveis
        int espada = 20, adaga = 10, armadura = 100, peitocouro = 25, peitoferro = 50;
        itens = new int[] { espada, adaga, armadura, peitocouro, peitoferro };
        int espadav = 20, adagav = 5, peitocv = 5, peitofv = 15, armadurav = 50;
        valores = new int[] { espadav, adagav, peitocv, peitofv, armadurav };

        Console.WriteLine("ITENS DISPONÍVEIS");
        Principal.Separador();
        Console.WriteLine("Espada: " + itens[0] + " moedas| Dano: " + valores[0]);
        Console.WriteLine("Adaga: " + itens[1] + " moedas| Dano: " + valores[1]);
        Console.WriteLine("Armadura: " + itens[2] + " moedas| Defesa: " + valores[4]);
        Console.WriteLine("Peitoral de Couro: " + itens[3] + " moedas| Defesa: " + valores[2]);
        Console.WriteLine("Peitoral de Ferro: " + itens[4] + " moedas| Defesa: " + valores[3]);
        Principal.Separador();
        /*
        Length é uma propriedade em C# que pode ser usada para obter o número total de elementos em um array,
        string ou coleção que implementa a interface ICollection1.
        */
        return 0;
    }
};
//Classe Game
class Game
{
    //Função para o inicio do game
    public static int Starting()
    {
        Console.WriteLine("Jogo Iniciado");
        return 0;
    }
};
//Classe Player
class Player
{
    //Dados do player
    public static int[] atributos;
    public static int dadosplayer(string[] args)
    {
        int vida = 100, defesa = 0, dano = 5, stamina = 50, moeda = 0;
        atributos = new int[] { vida, defesa, dano, stamina, moeda };

        Principal.Separador();
        Console.WriteLine("DADOS DO PERSONAGEM");
        Principal.Separador();
        Console.WriteLine("Vida: " + atributos[0]);
        Console.WriteLine("Defesa: " + atributos[1]);
        Console.WriteLine("Dano: " + atributos[2]);
        Console.WriteLine("Stamina: " + atributos[3]);
        Console.WriteLine("Doblons: " + atributos[4]);
        Principal.Separador();
        return 0;
    }
};
//Classe Personagem
class Personagem
{
    //Função para criar personagens
    public static string Persons(string[] args)
    {
        string carta1 = "Vaelin Al Sorna";
        return carta1;
    }
    //Dados do Vaelin
    public static int[] atributos;
    public static int VaelinAlSorna(string[] args)
    {
        int vida = 150, defesa = 70, dano = 75, stamina = 250;
        atributos = new int[] { vida, defesa, dano, stamina };

        Principal.Separador();
        Console.WriteLine("DADOS DE " + Personagem.Persons(args));
        Principal.Separador();
        Console.WriteLine("Vida: " + atributos[0]);
        Console.WriteLine("Defesa: " + atributos[1]);
        Console.WriteLine("Dano: " + atributos[2]);
        Console.WriteLine("Stamina: " + atributos[3]);
        Principal.Separador();
        return 0;
    }
};
//Classe principal
class Principal
{
    //Função para criar uma linha separadora
    public static void Separador()
    {
        Console.WriteLine("------------------------------------------------------");
    }
    //Função para gerar um valor aleatorio
    public static int Jogadado()
    {
        int dado;
        Random rdm = new Random();
        dado = rdm.Next(100);
        Console.WriteLine("[DADO LANCADO] -> " + dado);
        return dado;
    }
    //Metodo para mostrar atributos
    public static void AmostraAtributos()
    {

    }
    //Função principal
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        Player.dadosplayer(args);
        Separador();
        Loja.Negocios();
        Separador();
        Personagem.VaelinAlSorna(args);
    }
};
