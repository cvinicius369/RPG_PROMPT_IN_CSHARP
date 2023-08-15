//------------------------------------------------------------------------------| Atributos do sistema
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
//------------------------------------------------------------------------------| Caixas de dialogos
class Dialogo
{
    public static void poem1()
    {
        Console.WriteLine(" A sombra do corvo cobre meu coração, Cessa o jorro de minhas lagrimas");
        Console.WriteLine("                                  - Poema Seordah, autor desconhecido.");
        Principal.Separador();
    }
    public static void presents1()
    {
        string nome;
        Console.ReadKey();
        string texto1 = "- Do que você se recorda? - Voz misteriosa\n", texto2 = "- Ruas...Uma gangue de garotos...um caolho...\n";
        string texto3 = "- Você tem um nome? \n", texto4 = "- Meu nome...\n->";
        foreach (char c in texto1)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto2)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto3)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto4)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        nome = Console.ReadLine();
        if ((nome != "") || (nome != null))
        {
            string textonome = $"Meu nome é {nome}";
            foreach (char c in textonome)
            {
                Console.Write(c);
                Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
            }
            Console.ReadKey();
        } else
        {
            Console.WriteLine("Nao sabia que alguem teria o nome de Null ou Vazio nesse jogo ^^");
        }
        Principal.Separador();
    }
}
//------------------------------------------------------------------------------| Classe Loja
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
        Console.WriteLine("1 - Espada: " + itens[0] + " moedas| Dano: " + valores[0]);
        Console.WriteLine("2 - Adaga: " + itens[1] + " moedas| Dano: " + valores[1]);
        Console.WriteLine("3 - Armadura: " + itens[2] + " moedas| Defesa: " + valores[4]);
        Console.WriteLine("4 - Peitoral de Couro: " + itens[3] + " moedas| Defesa: " + valores[2]);
        Console.WriteLine("5 - Peitoral de Ferro: " + itens[4] + " moedas| Defesa: " + valores[3]);
        Principal.Separador();

        return itens.Length;
    }
};
//------------------------------------------------------------------------------| Classe Game
class Game
{
    //Funções para o inicio do game
    public static int Starting()
    {
        Player player = new Player(); // Crie uma instância de Player
        Player.dadosplayer(); // Chame o método DadosPlayer da instância
        Console.WriteLine("Jogo Iniciado");
        Dialogo.poem1();
        return 0;
    }
};

//------------------------------------------------------------------------------| Classe Player
class Player
{
    //Dados do player
    public static int[] atributos { get; set; }
    public static string[] cartas { get; set; }
    public static void dadosplayer()
    {
        Personagem personagem = new Personagem();
        int vida = 100, defesa = 0, dano = 5, stamina = 50, moeda = 20;
        atributos = new int[] { vida, defesa, dano, stamina, moeda};
        string carta0 = "Nenhuma", carta1 = Personagem.PersonsVAS();
        cartas = new string[] { carta0, carta1 };

        //int action;

        Principal.Separador();
        Console.WriteLine("DADOS DO PERSONAGEM");
        Principal.Separador();
        Console.WriteLine("Vida: " + atributos[0]);
        Console.WriteLine("Defesa: " + atributos[1]);
        Console.WriteLine("Dano: " + atributos[2]);
        Console.WriteLine("Stamina: " + atributos[3]);
        Console.WriteLine("Doblons: " + atributos[4]);
        Console.WriteLine("Carta: " + cartas[1]);
        Principal.Separador();

        Console.WriteLine("Digite 1 para compras");
        string action = Console.ReadLine();
        if (action == "1")
        {
            Compras.comprasplay();
        }
        else
        {
            Console.WriteLine("Nao entendi sua solicitação...Jogo iniciando");
        }
    }
};
//------------------------------------------------------------------------------| Classe player-Compras
class Compras : Player
{
    public static void comprasplay()
    {
        Loja.Negocios();
        Console.WriteLine("1. Espada\n2. Adaga\n3. Armadura Completa\n4. Peitoral de Couro\n5. Peitoral de Ferro");
        Console.Write("Produto: ");

        if (int.TryParse(Console.ReadLine(), out int compra))
        {
            if (compra == 1)
            {
                if (atributos[4] >= 20) // Verifica se há moedas suficientes
                {
                    atributos[4] -= 20; // Subtrai as moedas gastas
                    atributos[2] += 20; // Aumenta o dano

                    Console.WriteLine("Você comprou uma Espada, gastou 20 Doblons e aumentou seu dano para " + atributos[2]);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 2)
            {
                if (atributos[4] >= 5)
                {
                    atributos[4] -= 5; //Subtrai os doblons
                    atributos[2] += 10; //Aumenta o dano

                    Console.WriteLine("Você comprou uma Espada, gastou 5 Doblons e aumentou seu dano para " + atributos[2]);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else
            {
                Console.WriteLine("EM DESENVOLVIMENTO");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
        }
    }
};
//------------------------------------------------------------------------------| Classe Personagem
class Personagem
{
    //Função para criar personagens
    public static string PersonsVAS()
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
        Console.WriteLine("DADOS DE " + Personagem.PersonsVAS());
        Principal.Separador();
        Console.WriteLine("Vida: " + atributos[0]);
        Console.WriteLine("Defesa: " + atributos[1]);
        Console.WriteLine("Dano: " + atributos[2]);
        Console.WriteLine("Stamina: " + atributos[3]);
        Principal.Separador();
        return 0;
    }
};
//------------------------------------------------------------------------------| Classe principal
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
        Dialogo.poem1();
        Dialogo.presents1();
        /*
        Console.WriteLine("Hello World");
        Separador();
        Loja.Negocios();
        Separador();
        Personagem.VaelinAlSorna(args);
        Player.dadosplayer(args);*/
        Game.Starting();
    }
};
