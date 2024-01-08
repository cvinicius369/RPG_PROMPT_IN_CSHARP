using System;

namespace Battles{

    class Battle_F1{
        public static void Battle1(Player jogador){
            Console.WriteLine("Hello World! \nWellcome to de battles namespace");
            Console.WriteLine($"{jogador.getName()}, abaixo seguem seus atributos atualizados:");
            Console.WriteLine($"Vida: {jogador.getHeath()}");
            Console.WriteLine($"Defesa: {jogador.getDefesa()}");
            Console.WriteLine($"Ataque: {jogador.getAtack()}");
            Console.WriteLine($"Doblons: {jogador.getDoblons()}");
            Principal.Separador();

            Console.WriteLine("Precione qualquer tecla para continuar.");
            Console.ReadKey();
            Principal.Separador();

        }
    }
}
