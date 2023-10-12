//By: Caio Vinicius
//Project: RPG in C# (C-Sharp)
//Name Game: A Sombra do Corvo
//E-mail: vinicius182102@gmail.com
//------------------------------------------------------------------------------| Atributos do sistema
using System;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
//------------------------------------------------------------------------------| Classe Dialogo
class Dialogo
{
    public static string? nome;
    public static void poem1()
    {
        Console.WriteLine("              A sombra do corvo cobre meu coração, Cessa o jorro de minhas lagrimas");
        Console.WriteLine("                                 - Poema Seordah, autor desconhecido.");
        Principal.Separador();
    }

    public static void presents1()
    {
        Console.ReadKey();
        string[] textos = new string[]
        {
            "- Do que você se recorda? - Voz misteriosa\n",
            "- Ruas...Uma gangue de garotos...um caolho...\n",
            "- Você tem um nome? \n",
            "- Meu nome...\n"
        };

        foreach (string texto in textos)
        {
            ImprimirComAtraso(texto, 50);
        }
        Console.Write("Digite seu nome: ");
        nome = Console.ReadLine();

        if (!string.IsNullOrEmpty(nome))
        {
            string textonome = $"Meu nome é {nome}\n";
            ImprimirComAtraso(textonome, 50);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Nao sabia que alguem teria o nome de Null ou Vazio nesse jogo ^^");
        }

        Principal.Separador();
        string[] textos2 = new string[]
        {
           "- Voce foi encontrado na rua, inconsciente devido a uma surra que a gangue do caolho lhe deu, Frentis te trouxe para cá, a casa da Sexta Ordem!\n",
           "- Além disso, Mestre Sollis deseja que você vá até ele para se apresentar.\n",
           "Chegando ao local mestre Sollis não disse nada além de uma ordem para que voce levantasse a espada de madeira e o atacasse.\n"
        };
        foreach (string texto in textos2)
        {
            ImprimirComAtraso(texto, 50);
        }
    }

    private static void ImprimirComAtraso(string texto, int atraso)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(atraso); // Atraso entre cada caractere
        }
        Console.ReadKey();
    }
}
class Dialogo2 : Dialogo
{
    public static void Presents3()
    {
        string[] textos3 = new string[]
        {
            "- Mestre Sollis te massacrou! - Comentou o rapaz ruivo enquanto lhe entregava bandagens - Tome, vai te ajudar a se curar.\n",
            "O rapaz entregou um frasco de flor rubra e um traje de couro\n"
        };
        foreach (string texto in textos3)
        {
            ImprimirComAtraso(texto, 50);
        }
        Console.ReadKey();
        Principal.Separador();
    }
    private static void ImprimirComAtraso(string texto, int atraso)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(atraso); // Atraso entre cada caractere
        }
        Console.ReadKey();
    }
};
/*
    //Nas classes acima são feitos os dialogos que criam a historia do game
    //Alem de que o player pode interagir com os personagens
*/
//------------------------------------------------------------------------------| Classe Game
class Game
{
    public static void Starting(Player jogador)
    {

        Console.WriteLine("Jogo Iniciado");

        Console.WriteLine("Bem Vindo " + jogador.getName() + "\nPara apresentar seus atributos digite 1, 2 para iniciar o jogo ou 3 para sair");
        Principal.Separador();
    menu:
        string action = Console.ReadLine();

        if (action == "1")
        {
            Console.WriteLine("Nome: " + jogador.getName());
            Console.WriteLine("Vida: " + jogador.getHeath());
            Console.WriteLine("Dano: " + jogador.getAtack());
            Console.WriteLine("Defesa: " + jogador.getDefesa());
            Console.WriteLine("Doblons: " + jogador.getDoblons());
            Principal.Separador();
            Console.ReadKey();
            Inicio(jogador);
        }
        else
        {
            if (action == "2")
            {
                Inicio(jogador);
            }
            else
            {
                if (action == "3")
                {
                    Console.WriteLine("Saindo . . .");
                }
                else
                {
                    Console.WriteLine("Comando não esperado!");
                    goto menu;
                }
            }
        }
    }
    public static void Inicio(Player jogador)
    {
        Dialogo.poem1();
        Dialogo.presents1();
        Console.Write("Digite 1 para ir a casa da Ordem ou 2 para ir a batalha: ");
        string newaction = Console.ReadLine();
        Principal.Separador();

        if (newaction == "1")
        {
            Compras.comprasplay(jogador);
            BattleSollis1(jogador);
        }
        else
        {
            if (newaction == "2")
            {
                BattleSollis1(jogador);
            }
            else
            {
                Console.WriteLine("Acao Invalida!");
            }
        }
    }
    public static void BattleSollis1(Player jogador)
    {
        //Instanciacao e atribuição de Player
        string nome = jogador.getName();
        int vidaplayer = jogador.getHeath(), danoplayer = jogador.getAtack(), defesaplayer = jogador.getDefesa(), doblonsplayer = jogador.getDoblons();

        //Instanciacao e atribuição de Sollis
        Personagens sollis = new Personagens();
        string nomesollis = sollis.AlteraNomeSollis("Mestre Sollis");
        int vidasollis = sollis.AlteraVidaSollis(200), defesasollis = sollis.AlteraDefesaSollis(10), danosollis = sollis.AlteraDanoSollis(80), doblonssollis = sollis.AlteraDoblonsSollis(10);

        int dado = Principal.Jogadado();

        while (vidaplayer > 0 && vidasollis > 0)
        {
            int dado1 = Principal.Jogadado();
            string? option1;
            if (dado1 > 50)
            {
                Console.WriteLine("SORTE: Você ataca primneiro!");
                vidasollis -= jogador.getAtack() - defesasollis;
                Console.WriteLine($"Oponente: {nomesollis} ficou com: {vidasollis} de vida após o ataque de: {nome} que teve: {jogador.getAtack()} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            else
            {
                Console.WriteLine("Inimigo começa primeiro!");
                vidaplayer -= danosollis - jogador.getDefesa();
                jogador.AlteraVida(vidaplayer);
                Console.WriteLine($"{nome} ficou com: {jogador.getHeath()} De vida após o ataque de: {nomesollis} que teve: {danosollis} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            Console.WriteLine("Digite 1 para ir á loja ou qualquer tecla para continuar o jogo: ");
            option1 = Console.ReadLine();

            if (option1 == "1")
            {
                Principal.Separador();
                Loja.Negocios();
                Compras.comprasplay(jogador);
            }
        }
        if (jogador.getHeath() <= 0)
        {
            Console.WriteLine("Você perdeu! O oponente venceu.");
        }
        else if (vidasollis <= 0)
        {
            Console.WriteLine("Parabéns! Você venceu o oponente.");
        }
    }

}
//------------------------------------------------------------------------------| Classe Player
class Player
{
    //Abaixo são os atributos do player
    private string name { get; set; }
    private int doblons { get; set; }
    private int defesa { get; set; }
    private int atack { get; set; }
    private int heath { get; set; }

    //Abaixo estão os metodos para que sejam retornados os valores contidos nos atributos
    public void ObterDados(string nome)
    {
        this.name = nome;
        this.doblons = 20;
        this.defesa = 0;
        this.atack = 5;
        this.heath = 100;
    }
    public string getName()
    {
        return this.name;
    }
    public int getDoblons()
    {
        return this.doblons;
    }
    public int getDefesa()
    {
        return this.defesa;
    }
    public int getAtack()
    {
        return this.atack;
    }
    public int getHeath()
    {
        return this.heath;
    }

    //Daqui para baixo são metodos para alterar os valores, defini como int e dei return para que os valores sejam salvos
    //caso contrario retornarei para void e retirarei os returns
    public int AlteraDoblons(int dob)
    {
        this.doblons = dob;
        return this.doblons;
    }
    public int AlteraVida(int hp)
    {
        this.heath = hp;
        return this.heath;
    }
    public int AlteraDano(int dn)
    {
        this.atack = dn;
        return this.atack;
    }
    public int AlteraDefesa(int def)
    {
        this.defesa = def;
        return this.defesa;
    }
    public string AlteraNomePlayer(string nmp)
    {
        this.name = nmp;
        return this.name;
    }
}

class Compras : Player
{
    public static void comprasplay(Player jogador)
    {
        int doblons, vida, dano, defesa;
        Loja.Negocios();
        Console.WriteLine("1. Espada\n2. Adaga\n3. Armadura Completa\n4. Peitoral de Couro\n5. Peitoral de Ferro\n6. Flor Rubra");
        Console.Write("Produto: ");

        if (int.TryParse(Console.ReadLine(), out int compra))
        {
            if (compra == 1)
            {
                if (jogador.getDoblons() >= 10) // Verifica se há moedas suficientes
                {
                    doblons = -10; // Subtrai as moedas gastas
                    dano = +20; // Aumenta o dano
                    //Atualiza os valores
                    jogador.AlteraDoblons(doblons);
                    jogador.AlteraDano(dano);

                    Console.WriteLine("Você comprou uma Espada, gastou 20 Doblons e aumentou seu dano para " + dano);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 2)
            {
                if (jogador.getDoblons() >= 3)
                {
                    doblons = -3; //Subtrai os doblons
                    dano = +10; //Aumenta o dano
                    //Atualiza os valores
                    jogador.AlteraDoblons(doblons);
                    jogador.AlteraDano(dano);

                    Console.WriteLine("Você comprou uma Adaga, gastou 5 Doblons e aumentou seu dano para " + dano);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 3)
            {
                if (jogador.getDoblons() >= 25)
                {
                    doblons = -25; //Subtrai os doblons
                    defesa = +100; //Aumenta a defesa
                    //Atualiza os valores
                    jogador.AlteraDoblons(doblons);
                    jogador.AlteraDefesa(defesa);

                    Console.WriteLine("Você comprou um set de Armadura, gastou 25 Doblons e aumentou sua defesa para " + defesa);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 4)
            {
                if (jogador.getDoblons() >= 5)
                {
                    doblons = -5; //Subtrai os doblons
                    defesa = +25; //Aumenta a defesa
                    //Atualiza os valores
                    jogador.AlteraDoblons(doblons);
                    jogador.AlteraDefesa(defesa);

                    Console.WriteLine("Você comprou um peitoral de couro, gastou 5 Doblons e aumentou sua defesa para " + defesa);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 5)
            {
                if (jogador.getDoblons() >= 10)
                {
                    doblons = -10; //Subtrai os doblons
                    defesa = +50; //Aumenta a defesa
                    //Atualiza os valores
                    jogador.AlteraDoblons(doblons);
                    jogador.AlteraDefesa(defesa);

                    Console.WriteLine("Você comprou um peitoral de ferro, gastou 10 Doblons e aumentou sua defesa para " + defesa);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 6)
            {
                if (jogador.getDoblons() >= 5)
                {
                    doblons = -5; //Subtrai os doblons
                    vida = +25; //Aumenta a vida
                    //Atualiza os valores
                    jogador.AlteraDoblons(doblons);
                    jogador.AlteraDefesa(vida);

                    Console.WriteLine("Você comprou uma flor rubra, gastou 5 Doblons e aumentou sua vida para " + vida);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
        }
        Principal.Separador();
    }
};
/*
    //Classe Compras : Player é hereditária e é focada somente para as compras que o usuário fizer durante o game
    //A mesma ainda está em desenvolvimento para que não seja necessário a repetição de codigos.
*/
//------------------------------------------------------------------------------| Classe de Personangens
/*
    Nessa classe será criada os atributos dos personagens que farão parte da jornada do player
    Mestre Sollis será o primeiro a entrar em combate com o personagem.
*/
class Personagens
{
    private string sollis;
    private int doblonssollis, danosollis, vidasollis, defesasollis;
    public void ObterDadosPersons()
    {
        this.sollis = "Mestre Sollis";
        this.defesasollis = 10;
        this.doblonssollis = 10;
        this.vidasollis = 200;
        this.danosollis = 80;
    }
    public string getNomeSollis()
    {
        return this.sollis;
    }
    public int getVidaSollis()
    {
        return this.vidasollis;
    }
    public int getDoblonsSollis()
    {
        return this.doblonssollis;
    }
    public int getDefesaSollis()
    {
        return this.defesasollis;
    }
    public int getDanoSollis()
    {
        return this.danosollis;
    }
    public int AlteraDanoSollis(int dnsol)
    {
        this.danosollis = dnsol;
        return this.danosollis;
    }
    public int AlteraVidaSollis(int vd)
    {
        this.vidasollis = vd;
        return this.vidasollis;
    }
    public int AlteraDefesaSollis(int defes)
    {
        this.defesasollis = defes;
        return this.defesasollis;
    }
    public int AlteraDoblonsSollis(int dob)
    {
        this.doblonssollis = dob;
        return this.doblonssollis;
    }
    public string AlteraNomeSollis(string nm)
    {
        this.sollis = nm;
        return this.sollis;
    }
}
//------------------------------------------------------------------------------| Classe Loja
class Loja
{
    public static void Negocios()
    {
        string[] item1 = { "Espada", "Dano: 20", "Doblons: -10" };
        string[] item2 = { "Adaga", "Dano: 10", "Doblons: -3" };
        string[] item3 = { "Set de Armadura", "Defessa: 100", "Doblons: -25" };
        string[] item4 = { "Peitoral de Couro", "Defesa: 25", "Doblons: -5" };
        string[] item5 = { "Peitoral de Ferro", "Defesa: 50", "Doblons: -10" };
        string[] item6 = { "Flor Rubra", "Vida: +25", "Doblons: -5" };

        Console.WriteLine("Abaixo está a tabela dos itens disponíveis: ");

        Console.WriteLine(item1[0], item1[1], item1[2]);
        Console.WriteLine(item2[0], item2[1], item2[2]);
        Console.WriteLine(item3[0], item3[1], item3[2]);
        Console.WriteLine(item4[0], item4[1], item4[2]);
        Console.WriteLine(item5[0], item5[1], item5[2]);
        Console.WriteLine(item6[0], item6[1], item6[2]);

        Principal.Separador();
    }
}
//------------------------------------------------------------------------------| Classe principal
class Principal
{
    //Função para criar uma linha separadora
    public static void Separador()
    {
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
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
    //Função principal
    public static void Main(string[] args)
    {
        string? iniciogame;
        Console.WriteLine("                              A    S O M B R A    D O    C O R V O");
        Separador();

    inicio1: //Bloco criado para que quando o usuário informar uma tecla não esperada ele tente novamente

        Player jogador = new Player();
        Console.Write("Digite seu nome: ");
        string nomeplayer = Console.ReadLine();
        jogador.ObterDados(nomeplayer);

        Console.Write("Digite 1 para iniciar o game: ");
        iniciogame = Console.ReadLine();

        if (iniciogame == "1")
        {
            Game.Starting(jogador);
        }
        else
        {
            Console.WriteLine("Tecla não esperada!");
            goto inicio1;
        }
    }
};
/*
    //Classe principal, onde será feito o Menu, e toda a apresentação do game
    //A partir dela o usuario decide se inicia o game ou se analisa os atributos antes do inicio do game
    //Ainda está em desenvolvimento.
*/
