using RPG2;

namespace Battles
{
    /*
            Informações do Jogo

        -> O jogador pode decidir entre atacar, defender e usar a habilidade especial, entretanto a mesma consome energia vital então deve-se esperar o momento certo para usar
            -> Pode realizar o ataque apenas uma vez por rodada
            -> Defesa: Pode usar apenas uma vez por rodada
            -> Energia Vital: Começa com 50 pontos de energia vital e vai até 100, a habilidade consome 75 de energia vital.
            -> Detalhe: Se  o jogador estiver com a energia vital abaixo de 75 pontos e mesmo assim usar a habilidade, ele perde 5 de vida

     */

    class Battle_F1 //Classe que´principal que será responsavel pela execução de outras funções
    {

        public static void Battle1(Player jogador)                    //funcao main que irá organizar cronologicamente os eventos do jogo
        {
            BancoDialogos conversas = new BancoDialogos();            //instanciando as conversas
            Narrativa narrativa = new Narrativa();                    //instanciando as narrativas
            SherinTalks sherinfalas = new SherinTalks();              //instanciando as falas da personagem sherin
            VaelinTalks vaelinfalas = new VaelinTalks();              //instanciando as falas do personagem vaelin
            Personagens vaelin = new Personagens();                   //instanciando o objeto vaelin
            vaelin.ObterDadosVaelin();                                //obtendo os dados do personagem vaelin
            Puzzles corrida = new Puzzles();                          //isntanciando ss puzzles que terão no jogo

            //Imprimindo atributos atualizados
            Console.WriteLine($"{jogador.getName()}, abaixo seguem seus atributos atualizados:");
            Console.WriteLine($"Nivel: {jogador.getLevel()}"); Console.WriteLine($"Experiencia: {jogador.getXP()}");
            Console.WriteLine($"Vida: {jogador.getHeath()}"); Console.WriteLine($"Defesa: {jogador.getDefesa()}");
            Console.WriteLine($"Ataque: {jogador.getAtack()}"); Console.WriteLine($"Energia Vital: {jogador.getVitalEnergy()}");
            Console.WriteLine($"Doblons: {jogador.getDoblons()}");
            Principal.Separador();

            //inicio da faze
            Console.WriteLine("Precione qualquer tecla para continuar.");
            Console.ReadKey(); Console.Clear(); Principal.Separador();
            narrativa.dialogo1(); sherinfalas.dialogo1(jogador); narrativa.dialogo2(); vaelinfalas.dialogo1(); Principal.Separador();
            Treinamento(jogador, vaelin);        }

        public static void Treinamento(Player jogador, Personagens vaelin)     //Funcao que é responsavel por fazer o treinamento do player
        {
            Impressoes print = new Impressoes();           //Instanciando função de impressão para que as palavras sejam impressas com atraso para dar impressao de escrita humanizada
            int decisao;                                   //Ação que o jogador toma durante as batalhas

            string[] texto1 = new string[]
            {
                "Vaelin: Vamos do básico, você deve ter alguma habilidade mas você só vai descobrir com mais experiencia em batalha, até lá vamos começar com as atividades basicas.\n",
                "Vaelin: Durante a Batalha, você pode defender, atacar ou usar uma habilidade especial, mas cuidado ao usar a habilidade especial, você possui 100 pontos de energia vital\n",
                "Vaelin: As habilidades consomem 75 pontos de energia vital, se você estiver abaixo de 75 pontos de energia vital, você perde sangue e ficará fraco para a batalha então cuidado ao usa-la\n",
                "Vaelin: Agora que você ja sabe o basico, vamos praticar, me ataque!\n"
            };
            string[] texto5 = new string[]
            {
                "Vaelin: Agora você está pronto para a iniciar sua aventura como novo irmão da ordem. vá até Frentis para que ele lhe apresente sua primeira missao. "
            };

            foreach (string texto in texto1) { print.ImprimirTextoComAtraso(texto, 50); }

            tournament1:

            Console.WriteLine("[1]-Atacar |[2]-Defender |[3]-Especial |[4]-Loja"); int.TryParse(Console.ReadLine(), out decisao); //Decisoes do jogador

            if (decisao == 1)                             //Caso a decisao seja 1 (atacar) ira executar uma determinada ação que irá tirar o dano do oponente
            {
                string[] texto2 = new string[] {
                    "Isso mesmo seu ataque foi muito bom. Melhore sua postura durante o ataque, poderá ajudar e muito.\n"
                };

                Console.WriteLine($"--| Você atacou {vaelin.getNomeVaelin()}");
                vaelin.AlteraVidaVaelin(vaelin.getVidaVaelin() - (jogador.getAtack()));
                Console.WriteLine($"--| {vaelin.getNomeVaelin()} ficou com {vaelin.getVidaVaelin()} de vida.");
                foreach (string texto in texto2) { print.ImprimirTextoComAtraso(texto, 50); }

            }
            else if (decisao == 2)                     //Caso a decisao seja 2 (Defender) ira ter 50% de chance de executar uma defesa que anula o dano do oponente
            {
                int dado = Principal.Jogadado();
                string[] texto3 = new string[] { "Vaelin: Fique atento aos meus movimentos\n." };
                string[] texto4 = new string[] { "Vaelin: Melhore sua defesa e conseguirá anular ou quase anular o dano do oponente.\n" };

                Console.WriteLine($"--| {vaelin.getNomeVaelin()} te atacou.");

                if (dado > 50)
                {
                    Console.WriteLine("Defesa bem sucedida, voce nao perdeu vida!");
                    foreach (string texto in texto3) { print.ImprimirTextoComAtraso(texto, 50); }
                }
                else
                {
                    jogador.AlteraVida(jogador.getHeath() - (vaelin.getDanoVaelin() - jogador.getDefesa()));
                    Console.WriteLine($"--| Defesa mal sucedida, você perdeu {vaelin.getDanoVaelin() - jogador.getDefesa()} de vida e ficou com {jogador.getHeath()} de vida.");
                    foreach (string texto in texto4) { print.ImprimirTextoComAtraso(texto, 50); }
                }
            }
            else if (decisao == 3)
            {
                Console.WriteLine("Voce ainda não descobriu sua habilidade especial"); //Quando o player tiver nivel suficiente ele podera escolher uma habilidade especial para usa-la na batalha
            }
            else if (decisao == 4)
            {
                Principal.Separador();
                Compras.comprasplay(jogador);
            } else { Console.WriteLine("Comando invalido!\nTente novamente."); goto tournament1; }

            foreach (string letra in texto5 ) { print.ImprimirTextoComAtraso(letra, 50); }

        }
    }

    class BatteActions
    {
        //Aqui será feita as batalhas gerais do player contra seus respectivos oponentes
    }
    class Puzzles
    {
       //Aqui é onde haverá puzzles para que o jogo nao vique muito monotono
    }
}
