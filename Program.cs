/*By:         Caio Vinicius & WhiteDragon3257
* Project:    RPG in C# (C-Sharp)
* Name Game:  A Sombra do Corvo
*E-mail:      vinicius182102@gmail.com
*/
//---| Abaixo são as bibliotecas e outras importações para que o jogo funcione corretamente.
using Battles;
using System;
/*
*---| A Classe Dialogo abaixo será responsável pelo dialogo no jogo, onde em alguns casos como conversas entre os personagens
*     os caracteres serão impressos um por um dando a impressão de dialogo real.
*/
class Dialogo
{
    //A classe dialogo foi feita exclusivamente para criar os primeiros dialogos ente o player e os personagens, cada função é uma fala diferente de um personagem diferente
    //O jogo começa com a primeira função da classe, poem1() que eh onde será impresso o poema do inicio do livro
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

        foreach (string texto in textos) { ImprimirComAtraso(texto, 50); }
        Console.Write("Digite seu nome: ");
        nome = Console.ReadLine();

        if (!string.IsNullOrEmpty(nome))
        {
            string textonome = $"Meu nome é {nome}\n";
            ImprimirComAtraso(textonome, 50);
            Console.ReadKey();
        } else { Console.WriteLine("Nao sabia que alguem teria o nome de Null ou Vazio nesse jogo ^^"); }

        Principal.Separador();
        string[] textos2 = new string[]
        {
           "- Voce foi encontrado na rua, inconsciente devido a uma surra que a gangue do caolho lhe deu, Frentis te trouxe para cá, a casa da Sexta Ordem!\n",
           "- Além disso, Mestre Sollis deseja que você vá até ele para se apresentar.\n",
           "Chegando ao local mestre Sollis não disse nada além de uma ordem para que voce levantasse a espada de madeira e o atacasse.\n"
        };
        foreach (string texto in textos2) { ImprimirComAtraso(texto, 50); }
    }
    //A função ImprimirComAtraso() serve para que o texto seja impresso com atraso dando a impressão que o personagem está falando realmente com o player, ao invés de algo robótico
    //Essa impressão com artaso ocorre a partir da estrutura de repetição foreach() que pegará a fala do personagem e imprimir um caractere por vez
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
        foreach (string texto in textos3) { ImprimirComAtraso(texto, 50); }
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
    + Nas classes acima são feitos os dialogos que criam a historia do game
    + Alem de que o player pode interagir com os personagens
*/
//------------------------------------------------------------------------------| Classe Game
class Game
{
    public static void Starting(Player jogador, Personagens sollis)//Método recebendo os atributos
    {

        Console.WriteLine("Jogo Iniciado");

        Console.WriteLine("Bem Vindo " + jogador.getName() + "\nPara apresentar seus atributos digite 1, 2 para iniciar o jogo ou 3 para sair");
        Principal.Separador();

        string? action = Console.ReadLine();

        if (action == "1")
        {
            Console.WriteLine("Nome: " + jogador.getName());
            Console.WriteLine("Nivel: " + jogador.getLevel());
            Console.WriteLine("Vida: " + jogador.getHeath());
            Console.WriteLine("Dano: " + jogador.getAtack());
            Console.WriteLine("Defesa: " + jogador.getDefesa());
            Console.WriteLine("Doblons: " + jogador.getDoblons());
            Console.WriteLine("Energia Vital: " + jogador.getVitalEnergy());
            Console.WriteLine("Experiencia: " + jogador.getXP());
            Principal.Separador();
            Console.ReadKey();
            Inicio(jogador, sollis);                                       //lançando os atributos para a função Inicio()
        }
        else
        { if (action == "2") { Inicio(jogador, sollis); }                //lançando os atributos para a função Inicio()
          else { if (action == "3") { Console.WriteLine("Saindo . . ."); }
            else
            {
                Console.WriteLine("Comando não esperado!");
                Console.ReadKey();
                Starting(jogador, sollis);
            }
          }
        }
    }
    public static void Inicio(Player jogador, Personagens sollis)            //Função inicio recebendo os atributos
    {
        Dialogo.poem1();
        Dialogo.presents1();

        Console.Write("Digite 1 para ir a casa da Ordem ou 2 para ir a batalha: ");
        string? newaction = Console.ReadLine();
        Principal.Separador();

        //Cada classe ou função recebendo os atributos para que os dados sejam reutilizados
        if (newaction == "1")
        {
            Compras.comprasplay(jogador);
            BattleSollis1(jogador, sollis);
        }
        else
        { if (newaction == "2") { BattleSollis1(jogador, sollis); }
            else
            {
                Console.WriteLine("Acao Invalida!");
                Console.ReadKey();
                Console.Clear();
                Inicio(jogador, sollis);
            }
        }
    }
    public static void BattleSollis1(Player jogador, Personagens sollis)
    {
        string? nome = jogador.getName();                                            //Instanciacao e atribuição de Player
        sollis.ObterDadosSollis();                                                   //Instanciacao e atribuição de Sollis
        string nomesollis = sollis.AlteraNomeSollis("Mestre Sollis");

        int dado = Principal.Jogadado();

        while (jogador.getHeath() > 0 && sollis.getVidaSollis() > 0)
        {
            int dado1 = Principal.Jogadado();
            string? option1;
            if (dado1 > 50)
            {
                sollis.AlteraVidaSollis(sollis.getVidaSollis() - jogador.getAtack()); //Alterando a vida do oponente usando o dano do usuario
                Console.WriteLine("SORTE: Você ataca primneiro!");
                Console.WriteLine($"Oponente: {nomesollis} ficou com: {sollis.getVidaSollis()} de vida após o ataque de: {nome} que teve: {jogador.getAtack()} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            else
            {
                Console.WriteLine("Inimigo começa primeiro!");
                jogador.AlteraVida(jogador.getHeath() - sollis.getDanoSollis());       //Alterando a vida do jogador usando o dano do oponente
                Console.WriteLine($"{nome} ficou com: {jogador.getHeath()} De vida após o ataque de: {nomesollis} que teve: {sollis.getDanoSollis()} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            Console.WriteLine("Digite 1 para ir á loja ou qualquer tecla para continuar o jogo: ");
            option1 = Console.ReadLine();

            if (option1 == "1")
            { Principal.Separador(); Compras.comprasplay(jogador);
            }
        }
        if (jogador.getHeath() <= 0)
        {
            Console.WriteLine("Você perdeu! O oponente venceu.\nGanhaste 25 xp");
            jogador.AlteraXP(jogador.getXP() + 25);
            if (jogador.getXP() > 100) { jogador.AlteraLevel(jogador.getLevel() + 1); }
            Fase_1(jogador);
        }
        else if (sollis.getVidaSollis() <= 0)
        {
            Console.WriteLine("Parabéns! Você venceu o oponente.\nGanhaste 50 xp");
            jogador.AlteraXP(jogador.getXP() + 50);
            if (jogador.getXP() > 100) { jogador.AlteraLevel(jogador.getLevel() + 1); }
            Fase_1(jogador);
        }
    }
    public static void Fase_1(Player jogador)
    {
        /* 
         + Aqui será a primeira fase onde o player irá realmente jogar uma batalha e se vencer poderá ir para a proxima fase
         + Se perder, voltará para o inicio.
         + Esse bloco de código será o último neste namespace, as proximas fases serão em outro namespace
        */
        Dialogo2.Presents3();

        jogador.AlteraDefesa(jogador.getDefesa() - jogador.getDefesa() + 25);
        jogador.AlteraVida(jogador.getHeath() - jogador.getHeath() + 125);
        jogador.AlteraDoblons(jogador.getDoblons() + 50);
        Console.WriteLine("Parabens! Voce ganhou +25 de vida, +25 de defesa e 50 doblons!");

        Battles.Battle_F1.Battle1(jogador); //Abrindo o namespace, em seguida a classe e só então a função
    }

}
class Player//-------------------------------------------------------------| Classe Player
{
    //Abaixo são os atributos do player
    private string? name { get; set; }
    private int doblons { get; set; }
    private int defesa { get; set; }
    private int atack { get; set; }
    private int heath { get; set; }
    private int energia_vital { get; set; }
    private int level { get; set; }
    private int xp { get; set; }

    //Abaixo estão os metodos para que sejam retornados os valores contidos nos atributos
    public void ObterDados(string nome)
    {
        this.name = nome;
        this.doblons = 20;
        this.defesa = 0;
        this.atack = 5;
        this.heath = 100;
        this.energia_vital = 100;
        this.level = 0;
        this.xp = 0;
    }
    public string? getName() { return this.name; }
    public int getDoblons() { return this.doblons; }
    public int getDefesa() { return this.defesa; }
    public int getAtack() { return this.atack; }
    public int getHeath() { return this.heath; }
    public int getVitalEnergy() { return this.energia_vital; }
    public int getLevel() { return this.level; }
    public int getXP() { return this.xp; }

    //Daqui para baixo são metodos para alterar os valores, defini como int e dei return para que os valores sejam salvos
    //caso contrario retornarei para void e retirarei os returns
    public int AlteraDoblons(int dob) { this.doblons = dob; return this.doblons; }
    public int AlteraVida(int hp) { this.heath = hp; return this.heath; }
    public int AlteraDano(int dn) { this.atack = dn; return this.atack; }
    public int AlteraDefesa(int def) { this.defesa = def; return this.defesa; }
    public int AlteraEnergiaVital(int vital) { this.energia_vital = vital; return this.energia_vital; }
    public string AlteraNomePlayer(string nmp) { this.name = nmp; return this.name; }
    public int AlteraLevel(int altera) { this.level = altera; return this.level; }
    public int AlteraXP(int altera) { this.xp = altera; return this.xp; }
}

class Compras : Player
{
    public static void comprasplay(Player jogador)
    {
        int doblons, vida, dano, defesa;
        Console.WriteLine("1. Espada\n2. Adaga\n3. Armadura Completa\n4. Peitoral de Couro\n5. Peitoral de Ferro\n6. Flor Rubra");
        Console.Write("Produto: ");

        if (int.TryParse(Console.ReadLine(), out int compra))
        { if (compra == 1)
            { if (jogador.getDoblons() >= 10)          // Verifica se há moedas suficientes
                {
                    doblons = jogador.getDoblons() - 10; // Subtrai as moedas gastas
                    dano = jogador.getAtack() + 20;      // Aumenta o dano
                    //Atualiza os valores
                    jogador.AlteraDoblons(jogador.getDoblons() - 10);
                    jogador.AlteraDano(jogador.getAtack() + 20);

                    Console.WriteLine($"Você comprou uma Espada, gastou {doblons} Doblons e aumentou seu dano para {dano}");
                } else { Console.WriteLine("Doblons Insuficientes"); }
            }
            else if (compra == 2)
            { if (jogador.getDoblons() >= 3)
                {
                    doblons = jogador.getDoblons() - 3; //Subtrai os doblons
                    dano = jogador.getAtack() + 10;     //Aumenta o dano
                    //Atualiza os valores
                    jogador.AlteraDoblons(jogador.getDoblons() - 3);
                    jogador.AlteraDano(jogador.getAtack() + 10);

                    Console.WriteLine($"Você comprou uma Adaga, gastou {doblons} Doblons e aumentou seu dano para {dano}");
                } else { Console.WriteLine("Doblons Insuficientes"); }
            }
            else if (compra == 3)
            { if (jogador.getDoblons() >= 25)
                {
                    doblons = jogador.getDoblons() - 25; //Subtrai os doblons
                    defesa = jogador.getDefesa() + 100;  //Aumenta a defesa
                    //Atualiza os valores
                    jogador.AlteraDoblons(jogador.getDoblons() - 25);
                    jogador.AlteraDefesa(jogador.getDefesa() + 100);

                    Console.WriteLine("Você comprou um set de Armadura, gastou 25 Doblons e aumentou sua defesa para " + defesa);
                } else { Console.WriteLine("Doblons Insuficientes"); }
            }
            else if (compra == 4)
            { if (jogador.getDoblons() >= 5)
                {
                    doblons = jogador.getDoblons() - 5; //Subtrai os doblons
                    defesa = jogador.getDefesa() + 25;  //Aumenta a defesa
                    //Atualiza os valores
                    jogador.AlteraDoblons(jogador.getDoblons() - 5);
                    jogador.AlteraDefesa(jogador.getDefesa() + 25);

                    Console.WriteLine($"Você comprou um peitoral de couro, gastou {doblons} Doblons e aumentou sua defesa para {defesa}");
                } else { Console.WriteLine("Doblons Insuficientes"); }
            }
            else if (compra == 5)
            { if (jogador.getDoblons() >= 10)
                {
                    doblons = jogador.getDoblons() - 10; //Subtrai os doblons
                    defesa = jogador.getDefesa() + 50;   //Aumenta a defesa
                    //Atualiza os valores
                    jogador.AlteraDoblons(jogador.getDoblons() - 10);
                    jogador.AlteraDefesa(jogador.getDefesa() + 50);

                    Console.WriteLine($"Você comprou um peitoral de ferro, gastou {doblons} Doblons e aumentou sua defesa para {defesa}");
                } else { Console.WriteLine("Doblons Insuficientes"); }
            }
            else if (compra == 6)
            { if (jogador.getDoblons() >= 5)
                {
                    doblons = jogador.getDoblons() - 5; //Subtrai os doblons
                    vida = jogador.getHeath() + 25;     //Aumenta a vida
                    //Atualiza os valores
                    jogador.AlteraDoblons(jogador.getDoblons() - 5);
                    jogador.AlteraVida(jogador.getHeath() + 25);

                    Console.WriteLine($"Você comprou uma flor rubra, gastou {doblons} Doblons e aumentou sua vida para {vida}");
                } else { Console.WriteLine("Doblons Insuficientes"); }
            }
        } else { Console.WriteLine("Entrada inválida. Por favor, insira um número válido."); }
        Principal.Separador();
    }
};
/*
    + Classe Compras : Player é hereditária e é focada somente para as compras que o usuário fizer durante o game
    + A mesma ainda está em desenvolvimento para que não seja necessário a repetição de codigos.
*/
//------------------------------------------------------------------------------| Classe de Personangens
/*
    + Nessa classe será criada os atributos dos personagens que farão parte da jornada do player
    + Mestre Sollis será o primeiro a entrar em combate com o personagem.
*/
class Personagens
{
    private string? sollis, vaelin;
    private int doblonssollis, danosollis, vidasollis, defesasollis, doblonsvaelin, vidavaelin, defesavaelin, danovaelin;
    public void ObterDadosSollis()
    {
        this.sollis = "Mestre Sollis";
        this.defesasollis = 10;
        this.doblonssollis = 10;
        this.vidasollis = 200;
        this.danosollis = 80;
    }
    public string? getNomeSollis() { return this.sollis; }
    public int getVidaSollis() { return this.vidasollis; }
    public int getDoblonsSollis() { return this.doblonssollis; }
    public int getDefesaSollis() { return this.defesasollis; }
    public int getDanoSollis() { return this.danosollis; }
    public int AlteraDanoSollis(int dnsol) { this.danosollis = dnsol; return this.danosollis; }
    public int AlteraVidaSollis(int vd) { this.vidasollis = vd; return this.vidasollis; }
    public int AlteraDefesaSollis(int defes) { this.defesasollis = defes; return this.defesasollis; }
    public int AlteraDoblonsSollis(int dob) { this.doblonssollis = dob; return this.doblonssollis; }
    public string AlteraNomeSollis(string nm) { this.sollis = nm; return this.sollis; }

    //---------------------------------------------------------------------------------------------------------------------//
    public void ObterDadosVaelin()
    {
        this.vaelin = "Vaelin Al Sorna";
        this.vidavaelin = 275;
        this.danovaelin = 80;
        this.doblonsvaelin = 100;
        this.defesavaelin = 100;
    }
    public string? getNomeVaelin() { return this.vaelin; }
    public int getVidaVaelin() { return this.vidavaelin; }
    public int getDefesaVaelin() { return this.defesavaelin; }
    public int getDanoVaelin() { return this.danovaelin; }
    public int getDoblonsVaelin() { return this.doblonsvaelin; }
    public int AlteraDanoVaelin(int altera) { this.danovaelin = altera; return this.danovaelin; }
    public int AlteraVidaVaelin(int altera) { this.vidavaelin = altera; return this.vidavaelin; }
    public int AlteraDefesaVaelin(int altera) { this.defesavaelin = altera; return this.defesavaelin; }
    public int AlteraDoblonsVaelin(int altera) { this.doblonsvaelin = altera; return this.doblonsvaelin; }
    public string AlteraNomeVaelin(string altera) { this.vaelin = altera; return this.vaelin; }
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

        //Criacao do objeto jogador para que os atributos sejam reutilizados nas classes futuras
        Player jogador = new Player();
        Personagens sollis = new Personagens();
        Console.Write("Digite seu nome: ");
        string? nomeplayer = Console.ReadLine();
        #pragma warning disable CS8604            // Possível argumento de referência nula.
        jogador.ObterDados(nomeplayer);           // Os argumentos acima e abaixo são uma solução para um aviso dado pelo Copilot
        #pragma warning restore CS8604            // Possível argumento de referência nula.

        Console.Write("Digite 1 para iniciar o game: ");
        iniciogame = Console.ReadLine();

        //A estrutura condicional abaixo irá validar o dado que o usuário informou e se estiver correto o código irá para a classe game() onde o jogo de fato se inicia
        //Caso nao seja um dado válido, o usuário será informado, e após clicar em qualquer tecla (função ReadKey()), a tela será limpa através da função (Clear())
        //Em seguida a função Main() irá repetir, fazendo o usuário voltar ao inicio

        if (iniciogame == "1")
        { Game.Starting(jogador, sollis);//lançando os dados do player para a classe Game.Starting
        }
        else
        {
            Console.WriteLine("Tecla não esperada!");
            Console.ReadKey();
            Console.Clear();
            Main(args);
        }
    }
};
