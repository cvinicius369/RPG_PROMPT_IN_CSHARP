/*By:         Caio Vinicius
* Project:    RPG in C# (C-Sharp)
* Name Game:  A Sombra do Corvo
*E-mail:      vinicius182102@gmail.com

* Notas: Ultima atualização oficial em: 13/10/2024 - status: em andamento
            Foi implementada a persistencia de dados e correção de bugs, permitindo agora que o
                codigo use novos atributos como habilidades especiais e energia vital
        
* Atividades: 
            - Tornar o codigo limpo (clean code)
            - corrigir funções desnecessarias
            - reduzir redundancia
            - implementar mapa em pixel art
            - alterar itens de compra (para separar itens que podem ser comprados durante batalhas e
                itens que podem ser comprados foras das batalhas)
*/
//---| Abaixo são as bibliotecas e outras importações para que o jogo funcione corretamente.
using Battles;
using System;
using System.Collections.Generic;
using System.Data;
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
    public static void Starting(string name, Personagens sollis)//Método recebendo os atributos
    {
        int idUser = int.Parse(DataManagment.ObterValor(name, 0));  
        string nameUser = DataManagment.ObterValor(name, 1);
        string level = DataManagment.ObterValor(name, 2); 
        int hp = int.Parse(DataManagment.ObterValor(name, 3)); 
        int def = int.Parse(DataManagment.ObterValor(name, 4));
        int atk = int.Parse(DataManagment.ObterValor(name, 5));
        int doblons = int.Parse(DataManagment.ObterValor(name, 6)); 
        int xp = int.Parse(DataManagment.ObterValor(name, 7));
        int power = int.Parse(DataManagment.ObterValor(name, 8));
        Entity user = new Entity(idUser, nameUser, level, hp, def, atk, doblons, xp, power);


        Console.WriteLine("Jogo Iniciado");
        Console.WriteLine("Para apresentar seus atributos digite 1, 2 para iniciar o jogo ou 3 para sair");
        Principal.Separador();
        string? action = Console.ReadLine();
        if (action == "1") {
            Console.WriteLine("Nome: "          + user.getName());
            Console.WriteLine("Nivel: "         + user.getLevel());
            Console.WriteLine("Vida: "          + user.getHp());
            Console.WriteLine("Dano: "          + user.getAtk());
            Console.WriteLine("Defesa: "        + user.getDef());
            Console.WriteLine("Doblons: "       + user.getDoblons());
            Console.WriteLine("XP: " + user.getXp());
            Console.WriteLine("Poder Maximo: "  + user.getPower());
            Principal.Separador();
            Console.ReadKey();
            Inicio(user, sollis);                                       //lançando os atributos para a função Inicio()
        }
        else
        { if (action == "2") { Inicio(user, sollis); }                //lançando os atributos para a função Inicio()
          else { if (action == "3") { Console.WriteLine("Saindo . . ."); }
            else
            {
                Console.WriteLine("Comando não esperado!");
                Console.ReadKey();
                Starting(name, sollis);
            }
          }
        }
    }
    public static void Inicio(Entity user, Personagens sollis)            //Função inicio recebendo os atributos
    {
        Dialogo.poem1();
        Dialogo.presents1();

        Console.Write("Digite 1 para ir a casa da Ordem ou 2 para ir a batalha: ");
        string? newaction = Console.ReadLine();
        Principal.Separador();

        //Cada classe ou função recebendo os atributos para que os dados sejam reutilizados
        if (newaction == "1")
        {
            Taverna.Compras(user);
            BattleSollis1(user, sollis);
        }
        else
        { if (newaction == "2") { BattleSollis1(user, sollis); }
            else
            {
                Console.WriteLine("Acao Invalida!");
                Console.ReadKey();
                Console.Clear();
                Inicio(user, sollis);
            }
        }
    }
    public static void BattleSollis1(Entity user, Personagens sollis)
    {
        string? nome = user.getName();    
        string level = user.getLevel(); 
        int xp = user.getXp();
        sollis.ObterDadosSollis();                                   
        string nomesollis = sollis.AlteraNomeSollis("Mestre Sollis");

        int dado = Principal.Jogadado();

        while (user.getHp() > 0 && sollis.getVidaSollis() > 0) {
            int dado1 = Principal.Jogadado(); string? option1;
            if (dado1 > 50) {
                sollis.AlteraVidaSollis(sollis.getVidaSollis() - user.getAtk()); //Alterando a vida do oponente usando o dano do usuario
                Console.WriteLine("SORTE: Você ataca primneiro!");
                Console.WriteLine($"Oponente: {nomesollis} ficou com: {sollis.getVidaSollis()} de vida após o ataque de: {nome} que teve: {user.getAtk()} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            else {
                Console.WriteLine("Inimigo começa primeiro!");
                user.setHp(user.getHp() - (sollis.getDanoSollis() - user.getDef()));
                Console.WriteLine($"{nome} ficou com: {user.getHp()} De vida após o ataque de: {nomesollis} que teve: {sollis.getDanoSollis()} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            Console.WriteLine("Digite 1 para ir á loja ou qualquer tecla para continuar o jogo: ");
            option1 = Console.ReadLine();

            if (option1 == "1")
            { Principal.Separador(); Taverna.Compras(user);
            }
        }
        if (user.getHp() <= 0)
        {
            Console.WriteLine("Você perdeu! O oponente venceu.\nGanhaste 5 xp");
            xp = 5;
            DataManagment.UpdateData(user.getId().ToString(), 7, xp.ToString());
            if (xp > 100) { 
                user.setLevel("Abandonado");
                user.setAtk(user.getAtk() + 2);
                user.setDef(user.getDef() + 5);
                DataManagment.UpdateData(user.getId().ToString(), 2, user.getLevel());
             }
            Fase_1(user);
        }
        else if (sollis.getVidaSollis() <= 0)
        {
            Console.WriteLine("Parabéns! Você venceu o oponente.\nGanhaste 50 xp");
            xp = xp + 50;
            if (xp > 100) { 
                user.setAtk(user.getAtk() + 2);
                user.setDef(user.getDef() + 5);
                user.setLevel("Abandonado");
                DataManagment.UpdateData(user.getId().ToString(), 2, user.getLevel()); 
            }
            Fase_1(user);
        }
    }
    public static void Fase_1(Entity user)
    {
        /* 
         + Aqui será a primeira fase onde o player irá realmente jogar uma batalha e se vencer poderá ir para a proxima fase
         + Se perder, voltará para o inicio.
         + Esse bloco de código será o último neste namespace, as proximas fases serão em outro namespace
        */
        Dialogo2.Presents3();

        user.setHp(125); // reset da vida do usuario
        user.setDef(user.getDef() + 25);
        user.setDoblons(user.getDoblons() + 50);
        user.setAtk(user.getAtk() + 5);
        
        Console.WriteLine("Parabens! Voce ganhou +25 de vida, +25 de defesa, 5 de ataque e 50 doblons!");

        Battle_F1.Battle1(user); //Abrindo o namespace, em seguida a classe e só então a função
    }

}
class Taverna{
    public static void Compras(Entity user){
        Console.WriteLine("[1] - Elixir da Cura (+25 HP): 5 Doblons       | [2] - Espada Comum (+10 ATK): 20 Doblons");
        Console.WriteLine("[3] - Armadura de Couro (+10 DEF): 20 Doblons  | [0] - Voltar para a batalha");
        Console.Write("-> "); int compra = int.Parse(Console.ReadLine());
        
        if (compra == 0) { Console.WriteLine("Saindo da taverna"); }
        else if (compra == 1){
            if (user.getDoblons() >= 5){
                user.setDoblons(user.getDoblons() - 5);
                user.setHp(user.getHp() + 25);
                Console.WriteLine("Compra Realizada, você ganhou +25 HP");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else if (compra == 2){
            if (user.getDoblons() >= 20){
                user.setDoblons(user.getDoblons() - 20);
                user.setAtk(user.getAtk() + 10);
                Console.WriteLine("Compra Realizada, você ganhou +10 ATK");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else if (compra == 3){
            if (user.getDoblons() >= 20){
                user.setDoblons(user.getDoblons() - 20);
                user.setDef(user.getDef() + 10);
                Console.WriteLine("Compra Realizada, você ganhou +10 DEF");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else { Console.WriteLine("Valor invalido saindo da taverna"); }
    }
    public static void Vendas(Entity user){
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
            DataManagment.NewData(novoId.ToString(), nomeplayer, "Nenhum", "100", "0", "10", "25", "0", "0");
            Console.WriteLine($"Dado criado para {nomeplayer} com sucesso.");
        }
        DataManagment.ReadData(novoId.ToString());

        Console.Write("Digite 1 para iniciar o game: ");
        iniciogame = Console.ReadLine();

        //A estrutura condicional abaixo irá validar o dado que o usuário informou e se estiver correto o código irá para a classe game() onde o jogo de fato se inicia
        //Caso nao seja um dado válido, o usuário será informado, e após clicar em qualquer tecla (função ReadKey()), a tela será limpa através da função (Clear())
        //Em seguida a função Main() irá repetir, fazendo o usuário voltar ao inicio

        if (iniciogame == "1")
        { Game.Starting(nomeplayer, sollis);//lançando os dados do player para a classe Game.Starting
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
