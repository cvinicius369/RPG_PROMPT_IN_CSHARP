using RPG2;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

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

        public static void Battle1(string id)                    //funcao main que irá organizar cronologicamente os eventos do jogo
        {
            BancoDialogos conversas = new BancoDialogos();            //instanciando as conversas
            Narrativa narrativa = new Narrativa();                    //instanciando as narrativas
            SherinTalks sherinfalas = new SherinTalks();              //instanciando as falas da personagem sherin
            VaelinTalks vaelinfalas = new VaelinTalks();              //instanciando as falas do personagem vaelin
            Personagens vaelin = new Personagens();                   //instanciando o objeto vaelin
            vaelin.ObterDadosVaelin();                                //obtendo os dados do personagem vaelin
            Puzzles corrida = new Puzzles();                          //isntanciando ss puzzles que terão no jogo
            string name = DataManagment.ObterValor(id, 1);
            int level   = int.Parse(DataManagment.ObterValor(id, 2));
            int hp      = int.Parse(DataManagment.ObterValor(id, 3));
            int def     = int.Parse(DataManagment.ObterValor(id, 4));
            int atk     = int.Parse(DataManagment.ObterValor(id, 5));
            int doblons = int.Parse(DataManagment.ObterValor(id, 6));
            int xp      = int.Parse(DataManagment.ObterValor(id, 7));
            int power   = int.Parse(DataManagment.ObterValor(id, 8));

            //Imprimindo atributos atualizados
            Console.WriteLine($"{name}, abaixo seguem seus atributos atualizados:");
            Console.WriteLine($"Nivel:   {level}"); Console.WriteLine($"Experiencia: {xp}");
            Console.WriteLine($"Vida:    {hp}");    Console.WriteLine($"Defesa:      {def}");
            Console.WriteLine($"Ataque:  {atk}");   Console.WriteLine($"Poder:       {power}");
            Console.WriteLine($"Doblons: {doblons}");
            Principal.Separador();

            //inicio da faze
            Console.WriteLine("Precione qualquer tecla para continuar.");
            Console.ReadKey(); Console.Clear(); Principal.Separador();
            narrativa.dialogo1(); sherinfalas.dialogo1(id); narrativa.dialogo2(); vaelinfalas.dialogo1(id); Principal.Separador();
            Treinamento(id, vaelin);        }

        public static void Treinamento(string id, Personagens vaelin)     //Funcao que é responsavel por fazer o treinamento do player
        {
            Puzzles puzz = new Puzzles();                  //Instanciando funcao de puzzles para que seja impresso o mapa
            Impressoes print = new Impressoes();           //Instanciando função de impressão para que as palavras sejam impressas com atraso para dar impressao de escrita humanizada
            int decisao;                                   //Ação que o jogador toma durante as batalhas
            string? destino;

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
                vaelin.AlteraVidaVaelin(vaelin.getVidaVaelin() - int.Parse(DataManagment.ObterValor(id, 5)));
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
                    int vida = int.Parse(DataManagment.ObterValor(id, 3));
                    int defesa = int.Parse(DataManagment.ObterValor(id, 4));
                    DataManagment.UpdateData(id, 3, (vida - (vaelin.getDanoVaelin() - defesa)).ToString());
                    Console.WriteLine($"--| Defesa mal sucedida, você perdeu {vaelin.getDanoVaelin() - defesa} de vida e ficou com {int.Parse(DataManagment.ObterValor(id, 3))} de vida.");
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
                Taverna.Compras(id);
            } else { Console.WriteLine("Comando invalido!\nTente novamente."); goto tournament1; }

            foreach (string letra in texto5 ) { print.ImprimirTextoComAtraso(letra, 50); }
            mapa1:                                                                            // Marcacao onde caso o usuario erre o destino retorne para este local em vez de reiniciar o jogo
            puzz.ImprimirMapa1();                                                             // Imprieme uma especie primitiva do mapa local
            Console.Write("Digite a letra correspondente ao destino: ");
            destino = Console.ReadLine();                                                     // Faz a leitura do destino escolhido

            if ((destino == "E") || (destino == "e"))
            {
                // Executa a continuação do codigo
            } else { Console.WriteLine($"Vaelin: Irmão {DataManagment.ObterValor(id, 1)}, este é o caminho errado!"); goto mapa1; }
        }
    }

    class BatteActions
    {
        //Aqui será feita as batalhas gerais do player contra seus respectivos oponentes
    }
    class Puzzles
    {
       //Aqui é onde haverá puzzles para que o jogo nao vique muito monotono
       public void ImprimirMapa1()
        {
            Impressoes print = new Impressoes();
            string[] mapa1 = new string[]
            {
                "[______<A>-Confins do Norte_____________________________________________]\n",
                "[_______________________________________________________________________]\n",
                "[____________________________________________________<D>-Cidade Caida___]\n",
                "[<B>-Torre Norte_______<c>-Grande Floresta do Norte_____________________]\n",
                "[_______________________________________________________________________]\n",
                "[_______________________________________________________________________]\n",
                "[_________________________________________________<E>-Urlish Forest_____]\n",
                "[______________________________________________________(Frentis)________]\n",
                "[_______________________________________________________________________]\n",
                "[_________________________________________________________<F>-Varinshold]\n",
                "[________________________________________________________________(Você)_]\n",
                "[_______________________________________________________________________]\n"
            };
            foreach (string mapa in mapa1) { print.ImprimirTextoComAtraso(mapa, 0); }
        }
    }
}
