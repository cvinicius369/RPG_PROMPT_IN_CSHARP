//------------------------------------------------------------------------------| Atributos do sistema
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
//------------------------------------------------------------------------------| Caixas de dialogos
class Dialogo
{
    public static string nome;
    public static void poem1()
    {
        Console.WriteLine(" A sombra do corvo cobre meu coração, Cessa o jorro de minhas lagrimas");
        Console.WriteLine("                                  - Poema Seordah, autor desconhecido.");
        Principal.Separador();
    }
    public static void presents1()
    {
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
    public static void presents2()
    {
        string texto = "- Voce foi encontrado na rua, inconsciente devido a uma surra que a gangue do caolho lhe deu, Frentis te trouxe para cá, a casa da Sexta Ordem!";
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(40); // Atraso de 40 milissegundos entre cada caractere
        }
        Console.ReadKey();
        string texto2 = "- Mestre Sollis ordena que você vá até ele se apresentar!";
        string texto3 = "Chegando ao local mestre Sollis não disse nada além de uma ordem para que voce levantasse a espada de madeira e o atacasse.";
        foreach (char c in texto2)
        {
            Console.Write(c);
            Thread.Sleep(40); // Atraso de 40 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto3)
        {
            Console.Write(c);
            Thread.Sleep(40); // Atraso de 40 milissegundos entre cada caractere
        }
        Console.ReadKey();
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
        int espada = 20, adaga = 10, armadura = 100, peitocouro = 25, peitoferro = 50, florrubra = 25;
        itens = new int[] { espada, adaga, armadura, peitocouro, peitoferro, florrubra };
        int espadav = 20, adagav = 5, peitocv = 5, peitofv = 15, armadurav = 50, florrubrav = 5;
        valores = new int[] { espadav, adagav, peitocv, peitofv, armadurav, florrubrav };

        Console.WriteLine("ITENS DISPONÍVEIS");
        Principal.Separador();
        Console.WriteLine("1 - Espada: " + itens[0] + " moedas| Dano: " + valores[0]);
        Console.WriteLine("2 - Adaga: " + itens[1] + " moedas| Dano: " + valores[1]);
        Console.WriteLine("3 - Armadura: " + itens[2] + " moedas| Defesa: " + valores[4]);
        Console.WriteLine("4 - Peitoral de Couro: " + itens[3] + " moedas| Defesa: " + valores[2]);
        Console.WriteLine("5 - Peitoral de Ferro: " + itens[4] + " moedas| Defesa: " + valores[3]);
        Console.WriteLine("6 - Flor Rubra: " + itens[5] + " moedas| Regeneração: +" + valores[5]);
        Principal.Separador();

        return itens.Length;
    }
};
//------------------------------------------------------------------------------| Classe Game
class Game
{
    public static string[] cartas { get; set; }//Transferi os dados da classe Personagem.Persons para que
                                                //Fosse possivel utilizar os dados delas.
    //Funções para o inicio do game
    public static int Starting()
    {
        Player player = new Player(); // Cria uma instância de Player
        Console.WriteLine("Jogo Iniciado");
        Dialogo.poem1();
        Dialogo.presents1();
        Dialogo.presents2();
        Player.dadosplayer();
        Battle();
        return 0;
    }
    public static void Battle()
    {
        Player player = new Player();
        Principal principal = new Principal();
        Personagem personagem = new Personagem();
        Dialogo dialogo = new Dialogo();
        int dado = Principal.Jogadado();
        string nome = Dialogo.nome;
        int vidaplayer = Player.vida, defesaplayer = Player.defesa, danoplayer = Player.dano;
        int vidasollis = Personagem.vidaSollis, defesasollis = Personagem.defesaSollis, danosollis = Personagem.danoSollis;
        string carta0 = "Nenhuma", carta1 = Personagem.PersonsVAS(), carta2 = Personagem.PersonsMSo();
        cartas = new string[] { carta0, carta1, carta2 };

        while (vidaplayer > 0 && vidasollis > 0)
        {
            int dado1 = Principal.Jogadado();
            if (dado1 > 50)
            {
                Console.WriteLine("SORTE: Você ataca primneiro!");
                vidasollis -= danoplayer;
                Console.WriteLine("Oponente: " + carta2 + " ficou com: " + vidasollis + " De vida após o ataque de: " + nome);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Inimigo começa primeiro!");
                vidaplayer -= danosollis;
                Console.WriteLine(nome + " ficou com: " + vidaplayer + " De vida após o ataque de: " + carta2);
                Console.ReadKey();
            }
        }
        if (vidaplayer <= 0)
        {
            Console.WriteLine("Você perdeu! O oponente venceu.");
        }
        else if (vidasollis <= 0)
        {
            Console.WriteLine("Parabéns! Você venceu o oponente.");
        }
    }
};

//------------------------------------------------------------------------------| Classe Player
class Player
{
    //Dados do player
    public static int[] atributos { get; set; }
    public static int vida = 100, defesa = 0, dano = 5, stamina = 50, moeda = 20;
    public static string[] cartas { get; set; }
    public static void dadosplayer()
    {
        Personagem personagem = new Personagem();
        int vida = 100, defesa = 0, dano = 5, stamina = 50, moeda = 20;
        atributos = new int[] { vida, defesa, dano, stamina, moeda};
        string carta0 = "Nenhuma", carta1 = Personagem.PersonsVAS(), carta2 = Personagem.PersonsMSo();
        cartas = new string[] { carta0, carta1, carta2};
        Dialogo dialogo = new Dialogo();

        //int action;

        Principal.Separador();
        Console.WriteLine("DADOS DE " + Dialogo.nome);
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
        Console.WriteLine("1. Espada\n2. Adaga\n3. Armadura Completa\n4. Peitoral de Couro\n5. Peitoral de Ferro\n6. Flor Rubra");
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
    public static string PersonsMSo()
    {
        string carta2 = "Mestre Sollis";
        return carta2;
    }
    //Dados do Vaelin
    public static int[] atributosVaelin { get; set; }
    public static int vidaVaelin = 150, defesaVaelin = 70, danoVaelin = 75, staminaVaelin = 250; 
    public static int[] atributosMSo  { get; set; }
    public static int vidaSollis = 200, defesaSollis = 80, danoSollis = 85, staminaSollis = 250;
    //Repeti essas linhas de codigo para que fosse possível usa-las em outras classes
    public static int VaelinAlSorna(string[] args)
    {
        int vida = 150, defesa = 70, dano = 75, stamina = 250;
        atributosVaelin = new int[] { vida, defesa, dano, stamina };

        Principal.Separador();
        Console.WriteLine("DADOS DE " + Personagem.PersonsVAS());
        Principal.Separador();
        Console.WriteLine("Vida: " + atributosVaelin[0]);
        Console.WriteLine("Defesa: " + atributosVaelin[1]);
        Console.WriteLine("Dano: " + atributosVaelin[2]);
        Console.WriteLine("Stamina: " + atributosVaelin[3]);
        Principal.Separador();
        return 0;
    }
    //Dados do Mestre Sollis
    public static int MestreSollis()
    {
        int vida = 200, defesa = 80, dano = 85, stamina = 250;
        atributosMSo = new int[] { vida, defesa, dano, stamina };
        return 0;
    }
};
//------------------------------------------------------------------------------| Classe principal
class Principal
{
    //Função para criar uma linha separadora
    public static void Separador()
    {
        Console.WriteLine("-------------------------------------------------------------------------------");
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
        string iniciogame;
        Console.WriteLine("        A    S O M B R A    D O    C O R V O          ");
        Separador();
        Console.WriteLine("Digite 1 para iniciar o game: ");
        iniciogame = Console.ReadLine();

        if (iniciogame == "1")
        {
            Game.Starting();
        }
    }
};
