//Atributos do sistema
using System;
using System.Runtime.InteropServices;
//Classe Principal
class Font {
    //Funções
    public static void Separador() {
        Console.WriteLine("------------------------------------------------------");
    }
    public static int Jogadado() {
        int dado;
        Random rdm = new Random();
        dado = rdm.Next(100);
        Console.WriteLine("[DADO LANCADO] -> " + dado);
        return dado;
    }
    //Função Principal
    public static void Main(string[] args) {
        //Variaveis - Player
        string player;
        int hp = 50, dan = 3, gold = 4, hpfin = 100, danfin;
        string orc = "Orc";
        int orchp = 15, orcdan = 10, orcgold = 7;
        string oclin = "Goblin";
        int goblinhp = 6, goblindan = 5, goblingold = 2;
        int espada = 5, adaga = 3, valoresp = 7, valoradag = 4;
        string acaoplayer, acao, compra, start;
        //Player - Nome
        Console.Write("Nome: ");
        player = Console.ReadLine();
        Console.WriteLine("Olá " + player);
        Separador();
        /* Inicio Do Jogo*/
        Console.Write("[1] - Loja\n[2] - Game\n->");
        acao = Console.ReadLine();
        //LOJA
        if (acao == "Loja")
        {
            Console.Write("[S] - Espada: 10 moedas\n[A] - Adaga: 4 moedas\n->");
            compra = Console.ReadLine();
            if (compra == "S")
            {
                if (gold >= 10)
                {
                    danfin = dan + espada;
                    gold = -10;
                }
                else
                {
                    Console.WriteLine("Ouro Insuficiente!");
                }
            }
            else
            {
                if (gold >= 4)
                {
                    gold = -4;
                    danfin = dan + adaga;
                }
                else
                {
                    Console.WriteLine("Ouro Insuficiente!");
                }
            }
        }
        Console.Write("Digite S para comecar ou continuar o jogo: ");
        start = Console.ReadLine();
        while (start == "S") {
            //GAME
            if (start == "S"){
                /*->Dado */
                int dado;
                dado = Jogadado();
                Separador();
                while (hpfin > 0){
                    if (dado < 50){
                        while ((hpfin > 0) || (orchp > 0))
                        {
                            //ATAQUE DO ORC
                            Console.WriteLine("Azar!\nUm Orc apareceu e irá ataca-lo!\nEsteja Preparado!");
                            hp = hp - orcdan;
                            Console.WriteLine("Voce ficou com: " + hp + " de vida!");
                            Separador();
                            //ACAO DO PLAYER
                            Console.Write("Jogar dado novamente?\n[1]-'S'\n[2]-'N'\n->");
                            acaoplayer = Console.ReadLine();
                            Console.WriteLine("Opcao selecionada: " + acaoplayer);
                            Separador();
                            if (acaoplayer == "S")
                            {
                                if (hp >= 0) {
                                    dado = Jogadado();
                                    Separador();
                                    if (dado < 50){
                                        Console.WriteLine("Orc ataca novamente!");
                                        hp = hp - orcdan;
                                        Console.WriteLine("Agora voce ficou com " + hp + " de vida!");
                                        Separador();
                                    }
                                    else {
                                        Console.WriteLine("Sorte, voce atacará ");
                                        orchp = orchp - dan;
                                        Console.WriteLine("Orc agora está com " + orchp + " de vida!");
                                        Separador();
                                    }
                                }
                                hpfin = hp;
                                orchp = orchp;

                                if (hpfin <= 0) {
                                    Console.WriteLine("Voce perdeu!");
                                    Separador();
                                } else { if (orchp <= 0) {
                                        Console.WriteLine("Voce Ganhou!");
                                        Separador();
                                    } 
                                }
                            }
                            else {
                                if (acaoplayer == "nao") {
                                    Console.WriteLine("Jogo Finalizado" + player + " Desistiu e perdeu!");
                                    Separador();
                                }
                            }
                        }
                    }
                    else{
                        Console.WriteLine("Atencao!\nUm Goblin apareceu e irá ataca-lo!\nEsteja Preparado!");
                        hp = hp - goblindan;
                        Console.WriteLine("Voce ficou com: " + hp + " de vida!");
                        Separador();
                        while ((hpfin > 0) || (goblinhp > 0)) {
                            //ACAO DO PLAYER
                            Console.Write("Jogar dado novamente?\n[S]-sim\n[N]-nao\n->");
                            acaoplayer = Console.ReadLine();
                            Console.WriteLine("Opcao selecionada: " + acaoplayer);
                            Separador();
                            if (acaoplayer == "S"){
                                dado = Jogadado();
                                Separador();
                                if (hp >= 0){
                                    if (dado < 50){
                                        Console.WriteLine("Goblin ataca novamente!");
                                        hp = hp - goblindan;
                                        Console.WriteLine("Agora voce ficou com " + hp + " de vida!");
                                        Separador();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorte, voce atacará ");
                                        goblinhp = goblinhp - dan;
                                        Console.WriteLine("Goblin agora está com " + goblinhp + " de vida!");
                                        Separador();
                                    }
                                }
                                hpfin = hp;
                                goblinhp = goblinhp;
                            }
                        }
                        if (hpfin <= 0)
                        {
                            Console.WriteLine("Voce perdeu!");
                            Separador();
                        }
                        else
                        {
                            if (goblinhp <= 0)
                            {
                                Console.WriteLine("Voce Ganhou!");
                                Separador();
                            }
                        }
                        hpfin = hpfin - hp;
                    }
                }
            }
            Console.Write("Continuar o jogo ? digite start para sim: ");
            start = Console.ReadLine();
        }
    }
};
