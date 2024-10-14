/*By:         Caio Vinicius
* Project:    RPG in C# (C-Sharp)
* Name Game:  A Sombra do Corvo
*E-mail:      vinicius182102@gmail.com

* Notas: Ultima atualização oficial em: 14/10/2024 - status: em andamento
            Foram feitas correções e implementação das praticas clean code, além de implementa
                ção de novas funções deixando o jogo mais rico em detalhes.
        
* Atividades: 
            - implementar mapa em pixel art
            - implementar compras de atributos fora das batalhas
*/
using Battles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
/* [ GERENCIAMENTO DE DADOS ] */
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
    public static void saveData(Entity user){
        string name = user.getName(); string level = user.getLevel();
        string skill = user.getSkill(); string ultimate = user.getUltimate();
        string typeUser = user.getTypeUser(); 
        string progress = Convert.ToString(user.getProgress());
        string hp = Convert.ToString(user.getHp()); 
        string def = Convert.ToString(user.getDef()); 
        string atk = Convert.ToString(user.getAtk());
        string doblons = Convert.ToString(user.getDoblons()); 
        string xp = Convert.ToString(user.getXp());
        string power = Convert.ToString(user.getPower()); 
        string vitalEnergy = Convert.ToString(user.getVitalEnergy());
        string idUser = Convert.ToString(user.getId());
        UpdateData(idUser, 2, level);     UpdateData(idUser, 3, hp);
        UpdateData(idUser, 4, def);       UpdateData(idUser, 5, atk);
        UpdateData(idUser, 6, doblons);   UpdateData(idUser, 7, xp);
        UpdateData(idUser, 8, power);     UpdateData(idUser, 9, vitalEnergy);
        UpdateData(idUser, 10, skill);    UpdateData(idUser, 11, ultimate);
        UpdateData(idUser, 12, typeUser); UpdateData(idUser, 13, progress);
        Console.WriteLine("Dados Salvos com Sucesso.");
    }
    public static void ElevateLevel(Entity user){
        if (user.getXp() > 100){ user.setLevel("Abandonado"); }
        else if (user.getXp() > 150){ user.setLevel("Irmao Novico"); }
        else if (user.getXp() > 200){ user.setLevel("Irmao Veterano"); }
        else if (user.getXp() > 250){ user.setLevel("Irmao Mercenario"); }
        else if (user.getXp() > 300){ user.setLevel("Soldado do Reindo"); }
        else if (user.getXp() > 350){ user.setLevel("Lider de Batalhao"); }
        else if (user.getXp() > 400){ user.setLevel("Caçador de Dotados"); }
        else if (user.getXp() > 450){ user.setLevel("Assassino Imperial"); }
        else if (user.getXp() > 500){ user.setLevel("Espada do Rei"); }
        else if (user.getXp() > 550){ user.setLevel("Novo Rei"); }
    }
}
/* [ PRINCIPAIS DIALOGOS ] */
class Dialogo{
    public static string? nome;
    public static void poem1(){
        Console.WriteLine("              A sombra do corvo cobre meu coração, Cessa o jorro de minhas lagrimas");
        Console.WriteLine("                                 - Poema Seordah, autor desconhecido.");
        Principal.Separador();
    }

    public static void presents1(){
        Console.ReadKey();
        string[] textos = new string[]{
            "- Do que você se recorda? - Voz misteriosa\n",
            "- Ruas...Uma gangue de garotos...um caolho...\n",
            "- Você tem um nome? \n",
            "- Meu nome...\n"
        };
        foreach (string texto in textos) { ImprimirComAtraso(texto, 50); }
        Console.Write("Digite seu nome: ");
        nome = Console.ReadLine();
        if (!string.IsNullOrEmpty(nome)){ string textonome = $"Meu nome é {nome}\n"; ImprimirComAtraso(textonome, 50); Console.ReadKey(); } 
        else { Console.WriteLine("Nao sabia que alguem teria o nome de Null ou Vazio nesse jogo ^^"); }
        Principal.Separador();
        string[] textos2 = new string[]{
           "- Voce foi encontrado na rua, inconsciente devido a uma surra que a gangue do caolho lhe deu, Frentis te trouxe para cá, a casa da Sexta Ordem!\n",
           "- Além disso, Mestre Sollis deseja que você vá até ele para se apresentar.\n",
           "Chegando ao local mestre Sollis não disse nada além de uma ordem para que voce levantasse a espada de madeira e o atacasse.\n"
        };
        foreach (string texto in textos2) { ImprimirComAtraso(texto, 50); }
    }
    private static void ImprimirComAtraso(string texto, int atraso){
        foreach (char c in texto){ Console.Write(c); Thread.Sleep(atraso); }
        Console.ReadKey();
    }
}
class Dialogo2 : Dialogo{
    public static void Presents3() {
        string[] textos3 = new string[] {
            "- Mestre Sollis te massacrou! - Comentou o rapaz ruivo enquanto lhe entregava bandagens - Tome, vai te ajudar a se curar.\n",
            "O rapaz entregou um frasco de flor rubra e um traje de couro\n"
        };
        foreach (string texto in textos3) { ImprimirComAtraso(texto, 50); }
        Console.ReadKey(); Principal.Separador();
    }
    private static void ImprimirComAtraso(string texto, int atraso) {
        foreach (char c in texto) { Console.Write(c); Thread.Sleep(atraso); }
        Console.ReadKey();
    }
};
/* [ INICIO DO GAME ] */
class Game{
    public static void Starting(Entity user){
        Entity sollis = new Entity(0, "Sollis", "Mestre da 4a Ordem", 200, 10, 80, 20, 1000, 10000, "Super Agilidade", "Super Forca", 10000, "Comum", 0);
        if (int.Parse(DataManagment.ObterValor(user.getName(), 13)) == 1){ Arcos.ConhecendoPersnagens(user);}

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
            Console.WriteLine("XP: "            + user.getXp());
            Console.WriteLine("Poder Maximo: "  + user.getPower());
            Console.WriteLine("Energia Vital: " + user.getVitalEnergy());
            Console.WriteLine("Skill: "         + user.getSkill());
            Console.WriteLine("Ultimate: "      + user.getUltimate());
            Principal.Separador();
            Console.ReadKey();
            Dialogo.poem1();
            Dialogo.presents1();
            PrincipalsBattles.Battle_Initial(user, sollis);
        }
        else{ 
            if (action == "2") { 
                Dialogo.poem1();
                Dialogo.presents1();
                Console.Write("Digite 1 para ir a casa da Ordem ou 2 para ir a batalha: ");
                string? newaction = Console.ReadLine(); Principal.Separador();
                if (newaction == "1") { Taverna.ComprasInBattle(user); PrincipalsBattles.Battle_Initial(user, sollis); }
                else{ 
                    if (newaction == "2") { PrincipalsBattles.Battle_Initial(user, sollis); }
                    else { Console.WriteLine("Acao Invalida!"); Console.ReadKey(); Console.Clear(); Starting(user); }
               }
            } else { 
                if (action == "3") { Console.WriteLine("Saindo . . ."); }
                else { Console.WriteLine("Comando não esperado!"); Console.ReadKey(); Starting(user); }
            }
        }
    }
}
class Taverna{
    public static void ComprasInBattle(Entity user){
        Console.WriteLine("[1] - Elixir da Cura (+25 HP): 5 Doblons       | [2] - Anel de Sangue (+10 ATK): 20 Doblons");
        Console.WriteLine("[3] - Colar Obscuro (+10 DEF): 25 Doblons      | [4] - Alma de Dotado (+10 VEN): 15 Doblons");
        Console.WriteLine("[0] - Sair");
        Console.Write("-> "); string? compra = Console.ReadLine();
        
        if (compra == "0") { Console.WriteLine("Saindo da taverna"); }
        else if (compra == "1"){ compraHp(user, 25, 5);           Console.WriteLine("Compra Realizada, você ganhou +25 HP"); } 
        else if (compra == "2"){ compraAtk(user, 10, 20);         Console.WriteLine("Compra Realizada, você ganhou +10 ATK"); } 
        else if (compra == "3"){ compraDef(user, 10, 25);         Console.WriteLine("Compra Realizada, você ganhou +10 DEF"); }
        else if (compra == "4"){ compraVitalEnergy(user, 10, 15); Console.WriteLine("Compra Realizada, você ganhou +10 Energia Vital"); }
        else { Console.WriteLine("Valor invalido saindo da taverna"); }
    }
    public static void CompraOutsideBattle(Entity user){
        Console.WriteLine("Ainda em desenvolvimento");
        Console.WriteLine("[1] - Rubi de sangue (+25 HP): 15 Doblons            | [2] - Anel de Dragão (+10 ATK): 20 Doblons");
        Console.WriteLine("[3] - Armadura de ferro velho (+10 DEF): 25 Doblons  | [4] - Elixir da Vitalidade (+10 VEN): 15 Doblons");
        Console.WriteLine("[0] - Sair");
        Console.Write("-> "); string? compra = Console.ReadLine();

        if (compra == "1"){ compraHp(user, 25, 15); Console.WriteLine($"Agora você tem {user.getHp()} de vida."); }
        else if(compra == "2"){ compraAtk(user, 10, 20); Console.WriteLine($"Agora voce tem {user.getAtk()} de vida"); }
        else if(compra == "3"){ compraDef(user, 10, 25); Console.WriteLine($"Agora voce tem {user.getDef()} de defesa"); }
        else if(compra == "4"){ compraVitalEnergy(user, 10, 15); Console.WriteLine($"Agora voce tem {user.getVitalEnergy()} de energia vital"); }
        else { Console.WriteLine("Valor invalido saindo da taverna"); }
    }
    public static void compraAtk(Entity user, int aumento, int preco){ 
        if(user.getDoblons() >= preco){ user.setAtk(user.getAtk() + aumento); user.setDoblons(user.getDoblons() - preco); }
        else{ Console.WriteLine("Doblons insuficientes"); }
    }
    public static void compraHp(Entity user, int aumento, int preco){
        if(user.getDoblons() >= preco){ user.setHp(user.getHp() + aumento); user.setDoblons(user.getDoblons() - preco); }
        else{ Console.WriteLine("Doblons insuficientes"); }
    }
    public static void compraDef(Entity user, int aumento, int preco){
        if(user.getDoblons() >= preco){ user.setDef(user.getDef() + aumento); user.setDoblons(user.getDoblons() - preco); }
        else{ Console.WriteLine("Doblons insuficientes"); }
    }
    public static void compraVitalEnergy(Entity user, int aumento, int preco){
        if(user.getVitalEnergy() >= preco){ user.setVitalEnergy(user.getVitalEnergy() + aumento); user.setDoblons(user.getDoblons() - preco); }
        else{ Console.WriteLine("Doblons insuficientes"); }
    }
}
class Principal{
    public static void Separador() { Console.WriteLine("----------------------------------------------------------------------------------------------------------------------"); }
    public static int Jogadado(){
        int dado; Random rdm = new Random();
        dado = rdm.Next(100); Console.WriteLine("[DADO LANCADO] -> " + dado);
        return dado;
    }
    public static void Main(string[] args){
        string? iniciogame;
        Console.WriteLine("                              A    S O M B R A    D O    C O R V O");
        Separador();

        Console.Write("Digite seu nome: ");
        int novoId = 1;
        string? nomeplayer = Console.ReadLine();

        // Caso o usuario seja novo no jogo, o mesmo pode escolher uma classe de player
        if (DataManagment.existData(nomeplayer)){  Console.WriteLine($"Bem vindo de volta Mestre {nomeplayer}"); } 
        else {
            while (DataManagment.existID(novoId.ToString())){ novoId += 1; }
            Console.WriteLine("Escolha seu dom: ");
            Console.WriteLine("[1] - Canção do Sangue  | [2] - Conexão com Animais  | [3] - Manipulação do Fogo");
            Console.WriteLine("[4] - Projeção Astral   | [5] - Super Força          | [6] - Controle Corporal");
            int dote = int.Parse(Console.ReadLine());
            if (dote == 1) { DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "100", "sexto sentido", "Danca Sangrenta", "Sangue", "0"); }
            else if (dote == 2){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "100", "Reforco Animal", "Controle Animal", "Animal", "0"); }
            else if(dote == 3){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "100", "Lanca Chamas", "Firestorm", "Fogo", "0"); }
            else if (dote == 4){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "100", "Analise Astral", "Morte Astral", "Alma", "0"); }
            else if (dote == 5){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "100", "Estrangulamento", "Martelo da Morte", "Forca", "0"); }
            else if (dote == 6){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "100", "Paralisacao", "Auto Destruicao", "Controle", "0"); }
            else { DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "100", "Furia de Soldado", "Comum", "0"); }
            Console.WriteLine("Novo player cadastrado!");
            Console.WriteLine($"Dado criado para {nomeplayer} com sucesso.");
        }
        // Criação do objeto user para manipular os dados antes de salva-lo garantindo que eles sejam salvos APÓS o processamento deles
        int idUser      = int.Parse(DataManagment.ObterValor(nomeplayer, 0));  
        string nameUser = DataManagment.ObterValor(nomeplayer, 1);
        string level    = DataManagment.ObterValor(nomeplayer, 2); 
        int hp          = int.Parse(DataManagment.ObterValor(nomeplayer, 3)); 
        int def         = int.Parse(DataManagment.ObterValor(nomeplayer, 4));
        int atk         = int.Parse(DataManagment.ObterValor(nomeplayer, 5));
        int doblons     = int.Parse(DataManagment.ObterValor(nomeplayer, 6)); 
        int xp          = int.Parse(DataManagment.ObterValor(nomeplayer, 7));
        int power       = int.Parse(DataManagment.ObterValor(nomeplayer, 8));
        int vitalEnergy = int.Parse(DataManagment.ObterValor(nomeplayer, 9));
        string skill    = DataManagment.ObterValor(nomeplayer, 10);
        string ultimate = DataManagment.ObterValor(nomeplayer, 11);
        string typeUser = DataManagment.ObterValor(nomeplayer, 12);

        Entity user = new Entity(idUser, nameUser, level, hp, def, atk, doblons, xp, power, skill, ultimate, vitalEnergy, typeUser, 0);
        DataManagment.ReadData(novoId.ToString());

        Console.Write("[0] - Taverna  | [1] - Iniciar Game \n-> ");
        iniciogame = Console.ReadLine();

        if (iniciogame == "1") { Game.Starting(user); } 
        else if(iniciogame == "2"){ Taverna.CompraOutsideBattle(user); }
        else { Console.WriteLine("Tecla não esperada!"); Console.ReadKey(); Console.Clear(); Main(args); }
    }
};
