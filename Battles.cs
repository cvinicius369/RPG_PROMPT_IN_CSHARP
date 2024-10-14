using RPG2;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace Battles{
    class PrincipalsBattles{
        public static void Battle_Initial(Entity user, Entity oponent){
            int dado = Principal.Jogadado();

            while (user.getHp() > 0 && oponent.getHp() > 0) {
                int dado1 = Principal.Jogadado(); string? option1;
                if (dado1 > 50) {
                    oponent.setHp(oponent.getHp() - (user.getAtk() - (oponent.getDef() * user.getAtk() / 100)));
                    Console.WriteLine("SORTE: Você ataca primneiro!");
                    Console.WriteLine($"Oponente: {oponent.getName()} ficou com: {oponent.getHp()} de vida após o ataque de: {user.getName()} que teve: {user.getAtk()} de dano");
                    Console.ReadKey();
                    Principal.Separador();
                }
                else {
                    Console.WriteLine("Inimigo começa primeiro!");
                    user.setHp(user.getHp() - (oponent.getAtk() - (user.getDef() * oponent.getAtk() / 100)));
                    Console.WriteLine($"{user.getName()} ficou com: {user.getHp()} De vida após o ataque de: {oponent.getName()} que teve: {oponent.getAtk()} de dano");
                    Console.ReadKey();
                    Principal.Separador();
                }
                Console.Write("[0] - Continuar Batalha  | [1] - Taverna\n-> ");
                option1 = Console.ReadLine();
                if (option1 == "1") { Principal.Separador(); Taverna.ComprasInBattle(user); }
            }
            if (user.getHp() <= 0) {
                Console.WriteLine("Você perdeu! O oponente venceu.\nGanhaste 5 xp");
                user.setXP(user.getXp() + 5);
                if (user.getXp() > 100) { 
                    DataManagment.ElevateLevel(user);
                    user.setAtk(user.getAtk() + 2);
                    user.setDef(user.getDef() + 5);
                    DataManagment.UpdateData(user.getId().ToString(), 2, user.getLevel());
                }
            }
            else if (oponent.getHp() <= 0) {
                Console.WriteLine("Parabéns! Você venceu o oponente.\nGanhaste 50 xp");
                user.setXP(user.getXp() + 50);
                if (user.getXp() > 100) { 
                    DataManagment.ElevateLevel(user);
                    user.setAtk(user.getAtk() + 2);
                    user.setDef(user.getDef() + 5);
                    DataManagment.UpdateData(user.getId().ToString(), 2, user.getLevel()); 
                    DataManagment.UpdateData(user.getId().ToString(), 8, (user.getPower() + 10).ToString());
                }
            }

            Dialogo2.Presents3();

            // reset de dados pre-batalha
            user.setHp(125);
            user.setDef(int.Parse(DataManagment.ObterValor(user.getName(), 4)) + 25);
            user.setDoblons(user.getDoblons() + 50);
            user.setAtk(int.Parse(DataManagment.ObterValor(user.getName(), 5)) + 5);
            user.setVitalEnergy(int.Parse(DataManagment.ObterValor(user.getName(), 9)));
            user.setProgress(1);
            DataManagment.saveData(user);
            
            Console.WriteLine("Parabens! Voce ganhou +25 de vida, +25 de defesa, 5 de ataque e 50 doblons!");
            Arcos.ConhecendoPersnagens(user);
        }
        public static void GenericBattles(Entity user, Entity oponent){
            while(user.getHp() > 0 && oponent.getHp() > 0) {
                int dado = Principal.Jogadado();
                int decisao;
                if (dado > 50) {
                    Console.WriteLine("Sua vez!");
                    Console.WriteLine("[1]-Atacar |[2]-Defender |[3]-Skill |[4]-Ultimate |[5]-Taverna"); 
                    int.TryParse(Console.ReadLine(), out decisao);
                    if (decisao == 1) { Attack(user, oponent); }
                    else if (decisao == 2){ Deffend(oponent, user); }
                    else if (decisao == 3){ SkillUser(user, oponent); }
                    else if (decisao == 4){ UltimateUser(user, oponent); }
                    else if (decisao == 5){ Principal.Separador(); Taverna.ComprasInBattle(user);} // taverna
                    Console.ReadKey(); Principal.Separador();
                } else {
                    Console.WriteLine("Inimigo começa primeiro!");
                    AttackOponent(oponent, user); Console.ReadKey(); Principal.Separador();
                }
                Console.Write("[0] - Continuar Batalha  | [1] - Taverna\n-> ");
                string? option1 = Console.ReadLine();
                if (option1 == "1") { Principal.Separador(); Taverna.ComprasInBattle(user); }
            }
            if (user.getHp() <= 0) {
                Console.WriteLine("Você perdeu! O oponente venceu.\nGanhaste 5 xp");
                user.setXP(user.getXp() + 5);
                if (user.getXp() > 100) { 
                    DataManagment.ElevateLevel(user);
                    user.setAtk(user.getAtk() + 2); user.setDef(user.getDef() + 5);
                    DataManagment.UpdateData(user.getId().ToString(), 2, user.getLevel());
                }
            }
            else if (oponent.getHp() <= 0) {
                Console.WriteLine("Parabéns! Você venceu o oponente.\nGanhaste 50 xp");
                user.setXP(user.getXp() + 50);
                if (user.getXp() > 100) { 
                    DataManagment.ElevateLevel(user);
                    user.setAtk(user.getAtk() + 2); user.setDef(user.getDef() + 5);
                    DataManagment.UpdateData(user.getId().ToString(), 2, user.getLevel()); 
                    DataManagment.UpdateData(user.getId().ToString(), 8, (user.getPower() + 10.ToString()));
                }
            }
        }
        public static void Attack(Entity atacante, Entity defensor){
            Principal.Separador(); int esquiva = Principal.Jogadado();
            if(esquiva > 50) { Console.WriteLine($"{defensor.getName()} esquivou! "); } 
            else {
                defensor.setHp(defensor.getHp() - (atacante.getAtk() - (defensor.getDef() * atacante.getAtk() / 100)));
                Console.WriteLine($"{defensor.getName()} ficou com: {defensor.getHp()} de vida após o ataque de: {atacante.getName()} que teve: {atacante.getAtk()} de dano");
            }
        }
        public static void Deffend(Entity atacante, Entity defensor){
            Principal.Separador(); int quebraDefesa = Principal.Jogadado();
            if(quebraDefesa > 50){
                defensor.setHp(defensor.getHp() - (atacante.getAtk() - (defensor.getDef() * atacante.getAtk() / 100)));
                Console.WriteLine($"Defesa de {defensor.getName()} foi quebrada pelo {atacante.getName()}");
                Console.WriteLine($"{defensor.getName()} ficou com: {defensor.getHp()} De vida após o ataque de: {atacante.getName()} que teve: {atacante.getAtk()} de dano");
            } else { Console.WriteLine($"{defensor.getName()} conseguiu defender!"); }
        }
        public static void SkillUser(Entity atacante, Entity defensor){
            Principal.Separador(); Console.WriteLine($"Ativada a skill: {atacante.getSkill()}");
            Principal.Separador(); atacante.useSkill();
            defensor.setHp(defensor.getHp() - (atacante.getAtk() - (defensor.getDef() * atacante.getAtk() / 100)));
            Console.WriteLine($"{defensor.getName()} ficou com: {defensor.getHp()} de vida após o ataque de: {atacante.getName()} que teve: {atacante.getAtk()} de dano");
        }
        public static void UltimateUser(Entity atacante, Entity defensor){
            Principal.Separador(); Console.WriteLine($"Ativada a Ultimate: {atacante.getUltimate()}");
            Principal.Separador(); atacante.useUltimate();
            defensor.setHp(defensor.getHp() - (atacante.getAtk() - (defensor.getDef() * atacante.getAtk() / 100)));
            Console.WriteLine($"{defensor.getName()} ficou com: {defensor.getHp()} de vida após o ataque de: {atacante.getName()} que teve: {atacante.getAtk()} de dano");
        }
        public static void AttackOponent(Entity oponent, Entity user){
            int escolhaAtaque = Principal.Jogadado();
            if (escolhaAtaque <= 25){ Deffend(user, oponent); }
            else if(escolhaAtaque > 25 && escolhaAtaque <= 50){ Attack(oponent, user); }
            else if(escolhaAtaque > 50 && escolhaAtaque <= 75){ SkillUser(oponent, user); }
            else { UltimateUser(oponent, user); }
        }
    }
    class Arcos{
        public static void ConhecendoPersnagens(Entity user){
            BancoDialogos conversas = new BancoDialogos();          
            Narrativa narrativa = new Narrativa();                   
            SherinTalks sherinfalas = new SherinTalks();            
            VaelinTalks vaelinfalas = new VaelinTalks();            

            Console.WriteLine($"{user.getName()}, abaixo seguem seus atributos atualizados:");
            Console.WriteLine($"Nivel:   {user.getLevel()}"); Console.WriteLine($"Experiencia: {user.getXp()}");
            Console.WriteLine($"Vida:    {user.getHp()}");    Console.WriteLine($"Defesa:      {user.getDef()}");
            Console.WriteLine($"Ataque:  {user.getAtk()}");   Console.WriteLine($"Poder:       {user.getPower()}");
            Console.WriteLine($"Doblons: {user.getDoblons()}");
            Principal.Separador();

            Console.WriteLine("Precione qualquer tecla para continuar.");
            Console.ReadKey(); Console.Clear(); Principal.Separador();
            narrativa.dialogo1(); sherinfalas.dialogo1(user); narrativa.dialogo2(); vaelinfalas.dialogo1(user); Principal.Separador();
            Entity vaelin = new Entity(0, "Vaelin", "Espada do rei", 275, 100, 80, 20, 1000, 10000, "sexto sentido", "Danca Sangrenta", 10000, "Sangue", 0);
            Treinamento(user, vaelin); 
        }
        public static void Treinamento(Entity user, Entity vaelin)  {
            Impressoes print = new Impressoes();           
            string[] texto1 = new string[]
            {
                "Vaelin: Vamos do básico, você deve ter alguma habilidade mas você só vai descobrir com mais experiencia em batalha, até lá vamos começar com as atividades basicas.\n",
                "Vaelin: Durante a Batalha, você pode defender, atacar ou usar uma habilidade especial, mas cuidado ao usar a habilidade especial, você possui 100 pontos de energia vital\n",
                "Vaelin: As habilidades consomem 75 pontos de energia vital, se você estiver abaixo de 75 pontos de energia vital, você perde sangue e ficará fraco para a batalha então cuidado ao usa-la\n",
                "Vaelin: Agora que você ja sabe o basico, vamos praticar, me ataque!\n"
            };
            string[] texto2 = new string[] { "Isso mesmo seu ataque foi muito bom. Melhore sua postura durante o ataque, poderá ajudar e muito.\n" };
            string[] texto3 = new string[] { "Vaelin: Agora vamos trabalhar sua defesa, quando voce escolhe defender, há 50% de chance de sua defesa ser quebrada pelo oponente. Vamos lá, defenda meu ataque" };
            string[] texto4 = new string[] { "Vaelin: Fique atento aos meus movimentos\n." };
            string[] texto5 = new string[] { "Vaelin: Melhore sua defesa e conseguirá anular ou quase anular o dano do oponente.\n"};
            string[] texto6 = new string[] { "Vaelin: Agora vamos trabalhar sua Skill, sua skill te proporciona um aumento permanente de atributos, mas com um custo em hp e energia vital.\n"};
            string[] texto7 = new string[] { "Vaelin: Note agora que seus atributos aumentaram mas em compensacao, sua energia vital reduziu.\n"};
            string[] texto8 = new string[] { "Vaelin: Vamos partir agora para as ultimates, a funcionalidade delas é a mesma das skills, porém o aumento dos atributos é significativamente maior e o custo também.\n"};
            string[] texto9 = new string[] { "Vaelin: Otimo, mas lembre-se, se sua energia vital acabar, tanto as skills quanto as ultimates irao consumir seu HP\n" };
            string[] texto10 = new string[] { "Vaelin: Agora você está pronto para a iniciar sua aventura como novo irmão da ordem. vá até Frentis para que ele lhe apresente sua primeira missao.\n" };
            string[] texto11 = new string[] { "Vaelin: Vamos para uma batalha real agora! "};
            foreach (string texto in texto1) { print.ImprimirTextoComAtraso(texto, 50); }

            Console.WriteLine("[Qualquer Tecla]-Atacar"); Console.ReadKey(); 
            Console.WriteLine($"--| Você atacou {vaelin.getName()}");
            vaelin.setHp(vaelin.getHp() - user.getAtk());
            Console.WriteLine($"--| {vaelin.getName()} ficou com {vaelin.getHp()} de vida.");
            foreach (string texto in texto2) { print.ImprimirTextoComAtraso(texto, 50); };

            foreach (string texto in texto3) { print.ImprimirTextoComAtraso(texto, 50); }
            Console.WriteLine("[Qualquer Tecla]-Defender"); Console.ReadKey();
            int dado = Principal.Jogadado();
            Console.WriteLine($"--| {vaelin.getName()} te atacou.");
            if (dado > 50){
                Console.WriteLine("Defesa bem sucedida, voce nao perdeu vida!");
                foreach (string texto in texto4) { print.ImprimirTextoComAtraso(texto, 50); }
            }
            else{
                int vida = user.getHp();
                int defesa = user.getDef();
                user.setHp(vida - (vaelin.getAtk() - defesa));
                Console.WriteLine($"--| Defesa mal sucedida, você perdeu {vaelin.getAtk() - defesa} de vida e ficou com {user.getHp()} de vida.");
                foreach (string texto in texto5) { print.ImprimirTextoComAtraso(texto, 50); }
            }

            foreach (string texto in texto6) { print.ImprimirTextoComAtraso(texto, 50); }
            Console.WriteLine("[Qualquer Tecla]-Usar Skill");
            PrincipalsBattles.SkillUser(user, vaelin);
            foreach (string texto in texto7) { print.ImprimirTextoComAtraso(texto, 50); }

            foreach (string texto in texto8) { print.ImprimirTextoComAtraso(texto, 50); }
            Console.WriteLine("[Qualquer Tecla]-Usar Ultimate");
            PrincipalsBattles.UltimateUser(user, vaelin);
            foreach (string texto in texto9) { print.ImprimirTextoComAtraso(texto, 50); }

            foreach (string letra in texto10) { print.ImprimirTextoComAtraso(letra, 50); }
            foreach (string letra in texto11) { print.ImprimirTextoComAtraso(letra, 50); }
            user.setProgress(2);
            DataManagment.saveData(user); 
            PrincipalsBattles.GenericBattles(user, vaelin);
        }
    }
}