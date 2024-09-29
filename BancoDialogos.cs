using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    //Namespace que é responsável pelos dialogosntre os personagens durante o jogo
    //O mesmo terá dois tipos de dialogos os com atraso na escrita e os que imprimem imediatamente
    //O uso dos dialogos é da seguinte forma:
        1- Cada personagem tem uma classe que tem varios dialogos diferentes para situações diferentes, como um chat bot
        2- Dependendo da resposta do usuário o personagem age diferente
 */
namespace RPG2
{
    internal class BancoDialogos{ };
    class Narrativa 
    {
        Impressoes print = new Impressoes();

        public void dialogo1()
        {
            string[] textos1 = new string[]
            {
                "- Venha, vou te apresentar para a nossa curandeira.\n",
                "Seguindo o rapaz ruivo você se encontra com uma moça cuidado de feridos, ela olha para você e se apresenta.\n"
            };
            foreach (string texto in textos1) { print.ImprimirTextoComAtraso(texto, 50); }
        }
        public void dialogo2()
        {
            string[] textos = new string[]
            {
                "Após conduzido a um salão estava um homem de cabelos negros e compridos, era Vaelin Al Sorna, parecia tenso até ver Sherin e Frentis\n",
                "Frentis: Este é Vaelin Al Sorna nosso lider de batalhão.\n",
                "Vaelin lhe fez um aceno com a cabeça e então contou o motivo de estar tenso.\n"
            };
            foreach (string texto in textos) { print.ImprimirTextoComAtraso(texto, 50); };
        }
    }

    class SherinTalks    //Uma das personagens que interage com o player
    {
        Impressoes print = new Impressoes();
        public void dialogo1(string id)
        {
            string[] textos1 = new string[] {
                "Sherin: Prazer me chamo Sherin, qual seu nome? \n",
                $"- O nome dele é {DataManagment.ObterValor(id, 1)}!\n",
                "Sherin: Frentis, eu acredito que nosso(a) visitante não seja mudo. Além disso, sinto que você nem se apresentou para ele(a), não é mesmo?\n",
                "Frentis: Agora ele(a) sabe, continuando... Onde está Vaelin ?\n",
                ". . . . .\n",
            };
            foreach (string texto in textos1) { print.ImprimirTextoComAtraso(texto, 50); }
        }
    }
    class VaelinTalks
    {
        Impressoes print = new Impressoes();

        public void dialogo1(string id)
        {
            string[] textos = new string[]
            {
                "Vaelin: Eu conversei com o rei ontem a noite...Nós vamos para uma batalha.\n",
                "Frentis: Mas isso já é nosso costume irmão, e você não se abala com esse tipo de coisa\n.",
                "Vaelin: A batalha será contra os alpiranos.\n",
                "Frentis: . . . Irmão Sollis não comentou nada sobre isso?\n",
                "Vaelin: Não, por isso nosso irmão noviço teve sua batalha diretamente com Sollis ao invés de um treinamento mais básico, ele quer preparar o maximo de soldados possiveis para aumentar nossas chances.\n",
                "Sherin: Eu tenho mais trabalho a fazer, Vaelin, depois venha me visitar, preciso conversar com você....\n",
                "Vaelin acenou com a cabeça e Sherin saiu\n",
                $"Vaelin: É hora de começar seu treinamento irmã(o) {DataManagment.ObterValor(id, 1)}\n",
                ". . . . .\n"
            };
            foreach (string texto in textos) { print.ImprimirTextoComAtraso(texto, 50); }
        }
    }

    public class Impressoes
    {
        public void ImprimirTextoComAtraso(string texto, int atraso)
        {
            foreach (char c in texto)
            {
                Console.Write(c);
                Thread.Sleep(atraso); // Atraso entre cada caractere
            }
            Console.ReadKey();
        }
    }
}
