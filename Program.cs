/*By:         Caio Vinicius
* Project:    RPG in C# (C-Sharp)
* Name Game:  A Sombra do Corvo
*E-mail:      vinicius182102@gmail.com

* Notas: Ultima atualização oficial em: 29/9/2024 - status: em andamento
        Está sendo implementada a persistencia de dados usando um arquivo csv como base de dados
        
* Atividades: 
    - Criar objeto para manipular os valores antes de armazena-los na base de dados
    - Apos a manipulacao dos dados do objeto, a base de dados deve ser atualizada com os valores atuais do objeto
    - Resolver o bug da busca de dados (as funcoes nao estao conseguindo puxar os dados, "Dado naoencontrado")
*/
//---| Abaixo são as bibliotecas e outras importações para que o jogo funcione corretamente.
using Battles;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
/*
*---| A Classe Dialogo abaixo será responsável pelo dialogo no jogo, onde em alguns casos como conversas entre os personagens
*     os caracteres serão impressos um por um dando a impressão de dialogo real.
*/
public class DataManagment{
    const string localFile = "./dataGamer.csv";
    public static bool existData(string? name){
        var dados = LerArquivo();
        return dados.Any(d => d[1].Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    public static bool existID(string? id){
        var dados = LerArquivo();
        return dados.Any(d => d[0].Equals(id, StringComparison.OrdinalIgnoreCase));
    }
    public static string ObterValor(string? nome, int coluna) {
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[1].Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (dado != null) { int index = coluna; return index != -1 ? dado[index] : "Coluna inválida.";
        }
        return "Dado não encontrado.";
    }
    public static void ReadData(string id){
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[0] == id);
        if (dados != null){ Console.WriteLine(string.Join('\t', dado)); } 
        else { Console.WriteLine("Dado nao encontrado!"); }
    }
    public static void UpdateData(string id, int column, string newData){
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[0] == id);
        if (dado != null){
            if (column > -1){
                dado[column] = newData;
                WriteFile(dados);
                Console.WriteLine("Dado Alterado com sucesso");
            } else { Console.WriteLine("Coluna Invalida"); }
        } else { Console.WriteLine("Nenhum dado encontrado!"); }
    }
    public static void NewData(params string[] new_data){
        using (StreamWriter sw = new StreamWriter(localFile, true)){ sw.WriteLine(string.Join(";", new_data)); }
        Console.WriteLine("Novo player cadastrado!");
    }
    public static void DeleteData(string id){
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[0] == id);
        if(dado != null){
            dados.Remove(dado);
            WriteFile(dados);
            Console.WriteLine("Dado deletado com sucesso!");
        }
    }
    static List<string[]> LerArquivo(){
        var dados = new List<string[]>();
        if (File.Exists(localFile)){
            using (StreamReader sr = new StreamReader(localFile)){ string line;
                while ((line = sr.ReadLine()) != null){ dados.Add(line.Split(';')); }  
            } } return dados;
    }
    static void WriteFile(List<string[]> dados){
        using (StreamWriter sw = new StreamWriter(localFile)){ foreach(var dado in dados){ sw.WriteLine(string.Join(";", dado)); } }
    }
}
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
    public static void Starting(string id, Personagens sollis)//Método recebendo os atributos
    {
        Console.WriteLine("Jogo Iniciado");
        Console.WriteLine("Para apresentar seus atributos digite 1, 2 para iniciar o jogo ou 3 para sair");
        Principal.Separador();
        string? action = Console.ReadLine();
        if (action == "1") {
            Console.WriteLine("Nome: "          + DataManagment.ObterValor(id, 1));
            Console.WriteLine("Nivel: "         + DataManagment.ObterValor(id, 2));
            Console.WriteLine("Vida: "          + DataManagment.ObterValor(id, 3));
            Console.WriteLine("Dano: "          + DataManagment.ObterValor(id, 4));
            Console.WriteLine("Defesa: "        + DataManagment.ObterValor(id, 4));
            Console.WriteLine("Doblons: "       + DataManagment.ObterValor(id, 5));
            Console.WriteLine("Energia Vital: " + DataManagment.ObterValor(id, 6));
            Console.WriteLine("Experiencia: "   + DataManagment.ObterValor(id, 7));
            Principal.Separador();
            Console.ReadKey();
            Inicio(id, sollis);                                       //lançando os atributos para a função Inicio()
        }
        else
        { if (action == "2") { Inicio(id, sollis); }                //lançando os atributos para a função Inicio()
          else { if (action == "3") { Console.WriteLine("Saindo . . ."); }
            else
            {
                Console.WriteLine("Comando não esperado!");
                Console.ReadKey();
                Starting(id, sollis);
            }
          }
        }
    }
    public static void Inicio(string id, Personagens sollis)            //Função inicio recebendo os atributos
    {
        Dialogo.poem1();
        Dialogo.presents1();

        Console.Write("Digite 1 para ir a casa da Ordem ou 2 para ir a batalha: ");
        string? newaction = Console.ReadLine();
        Principal.Separador();

        //Cada classe ou função recebendo os atributos para que os dados sejam reutilizados
        if (newaction == "1")
        {
            Taverna.Compras(id);
            BattleSollis1(id, sollis);
        }
        else
        { if (newaction == "2") { BattleSollis1(id, sollis); }
            else
            {
                Console.WriteLine("Acao Invalida!");
                Console.ReadKey();
                Console.Clear();
                Inicio(id, sollis);
            }
        }
    }
    public static void BattleSollis1(String id, Personagens sollis)
    {
        string? nome = DataManagment.ObterValor(id, 1);    
        int level = int.Parse(DataManagment.ObterValor(id, 2)); 
        int hp = int.Parse(DataManagment.ObterValor(id, 3));                             
        sollis.ObterDadosSollis();                                   
        string nomesollis = sollis.AlteraNomeSollis("Mestre Sollis");

        int dado = Principal.Jogadado();

        while (int.Parse(DataManagment.ObterValor(id, 3)) > 0 && sollis.getVidaSollis() > 0) {
            int dado1 = Principal.Jogadado(); string? option1;
            if (dado1 > 50) {
                sollis.AlteraVidaSollis(sollis.getVidaSollis() - int.Parse(DataManagment.ObterValor(id, 5))); //Alterando a vida do oponente usando o dano do usuario
                Console.WriteLine("SORTE: Você ataca primneiro!");
                Console.WriteLine($"Oponente: {nomesollis} ficou com: {sollis.getVidaSollis()} de vida após o ataque de: {nome} que teve: {int.Parse(DataManagment.ObterValor(id, 5))} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            else {
                Console.WriteLine("Inimigo começa primeiro!");
                DataManagment.UpdateData(id, 3, (hp - sollis.getDanoSollis()).ToString());
                Console.WriteLine($"{nome} ficou com: {DataManagment.ObterValor(id, 3)} De vida após o ataque de: {nomesollis} que teve: {sollis.getDanoSollis()} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            Console.WriteLine("Digite 1 para ir á loja ou qualquer tecla para continuar o jogo: ");
            option1 = Console.ReadLine();

            if (option1 == "1")
            { Principal.Separador(); Taverna.Compras(id);
            }
        }
        if (int.Parse(DataManagment.ObterValor(id, 3)) <= 0)
        {
            Console.WriteLine("Você perdeu! O oponente venceu.\nGanhaste 5 xp");
            int xp = 5; int newLevel = level + 1;
            DataManagment.UpdateData(id, 7, xp.ToString());
            if (level > 100) { DataManagment.UpdateData(id, 2, newLevel.ToString()); }
            Fase_1(id);
        }
        else if (sollis.getVidaSollis() <= 0)
        {
            Console.WriteLine("Parabéns! Você venceu o oponente.\nGanhaste 50 xp");
            int newLevel = level + 50;
            if (level > 100) { DataManagment.UpdateData(id, 2, newLevel.ToString()); }
            Fase_1(id);
        }
    }
    public static void Fase_1(string id)
    {
        /* 
         + Aqui será a primeira fase onde o player irá realmente jogar uma batalha e se vencer poderá ir para a proxima fase
         + Se perder, voltará para o inicio.
         + Esse bloco de código será o último neste namespace, as proximas fases serão em outro namespace
        */
        Dialogo2.Presents3();

        DataManagment.UpdateData(id, 3, (int.Parse(DataManagment.ObterValor(id, 3)) + 25).ToString());
        DataManagment.UpdateData(id, 3, (int.Parse(DataManagment.ObterValor(id, 4)) + 25).ToString());
        DataManagment.UpdateData(id, 3, (int.Parse(DataManagment.ObterValor(id, 6)) + 50).ToString());
        Console.WriteLine("Parabens! Voce ganhou +25 de vida, +25 de defesa e 50 doblons!");

        Battles.Battle_F1.Battle1(id); //Abrindo o namespace, em seguida a classe e só então a função
    }

}
class Taverna{
    public static void Compras(String id){
        int doblons = int.Parse(DataManagment.ObterValor(id, 6));
        int hp      = int.Parse(DataManagment.ObterValor(id, 3));
        int atck    = int.Parse(DataManagment.ObterValor(id, 5));
        int def     = int.Parse(DataManagment.ObterValor(id, 4));
        int xp      = int.Parse(DataManagment.ObterValor(id, 7));
        int payment, newAtribute;
        Console.WriteLine("[1] - Elixir da Cura (+25 HP): 5 Doblons       | [2] - Espada Comum (+10 ATK): 20 Doblons");
        Console.WriteLine("[3] - Armadura de Couro (+10 DEF): 20 Doblons  | [0] - Voltar para a batalha");
        Console.Write("-> "); int compra = Console.Read();
        
        if (compra == 0) { Console.WriteLine("Saindo da taverna"); }
        else if (compra == 1){
            if (doblons >= 5){
                payment = doblons-5;
                newAtribute = hp + 25;
                DataManagment.UpdateData(id, 6, payment.ToString());
                DataManagment.UpdateData(id, 3, newAtribute.ToString());
                Console.WriteLine("Compra Realizada, você ganhou +25 HP");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else if (compra == 2){
            if (doblons >= 20){
                payment = doblons-20;
                newAtribute = atck + 10;
                DataManagment.UpdateData(id, 6, payment.ToString());
                DataManagment.UpdateData(id, 5, newAtribute.ToString());
                Console.WriteLine("Compra Realizada, você ganhou +10 ATK");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else if (compra == 3){
            if (doblons >= 20){
                payment = doblons-20;
                newAtribute = def + 10;
                DataManagment.UpdateData(id, 6, payment.ToString());
                DataManagment.UpdateData(id, 4, newAtribute.ToString());
                Console.WriteLine("Compra Realizada, você ganhou +10 DEF");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else { Console.WriteLine("Valor invalido saindo da taverna"); }
    }
    public static void Vendas(string id){
        Console.WriteLine("Ainda em desenvolvimento");
    }
}
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
        Personagens sollis = new Personagens();
        Console.Write("Digite seu nome: ");
        int novoId = 1;
        string? nomeplayer = Console.ReadLine();

        if (DataManagment.existData(nomeplayer)){  Console.WriteLine($"Bem vindo de volta Mestre {nomeplayer}"); } 
        else {
            while (DataManagment.existID(novoId.ToString())){ novoId += 1; }
            DataManagment.NewData(novoId.ToString(), nomeplayer, "A", "100", "50", "30", "200", "0", "100");
            Console.WriteLine($"Dado criado para {nomeplayer} com sucesso.");
        }
        DataManagment.ReadData(novoId.ToString());

        Console.Write("Digite 1 para iniciar o game: ");
        iniciogame = Console.ReadLine();

        //A estrutura condicional abaixo irá validar o dado que o usuário informou e se estiver correto o código irá para a classe game() onde o jogo de fato se inicia
        //Caso nao seja um dado válido, o usuário será informado, e após clicar em qualquer tecla (função ReadKey()), a tela será limpa através da função (Clear())
        //Em seguida a função Main() irá repetir, fazendo o usuário voltar ao inicio

        if (iniciogame == "1")
        { Game.Starting(novoId.ToString(), sollis);//lançando os dados do player para a classe Game.Starting
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
