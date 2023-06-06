using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogodavelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] array = new char[3,3] ;
            string vs;
            char player = 'X';
            int x = 0, y = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = '?';
                }
            }

            graphinitial(array);
            while (true)
            {
                if (winner(array) == '?' && !(isvelha(array,player)))
                {
                    Console.Write($"(insira a posição ex.: A1) VEZ DO {player}: ");
                    vs = Console.ReadLine().ToUpper();
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            switch (vs[i])
                            {
                                case 'A':
                                    y = 0;
                                    break;
                                case 'B':
                                    y = 1;
                                    break;
                                case 'C':
                                    y = 2;
                                    break;
                                default:
                                    Console.WriteLine("- formato inválido");
                                    break;
                            }
                        }
                        else
                        {
                            switch (vs[i])
                            {
                                case '1':
                                    x = 0;
                                    break;
                                case '2':
                                    x = 1;
                                    break;
                                case '3':
                                    x = 2;
                                    break;
                                default:
                                    Console.WriteLine("- formato inválido");
                                    break;
                            }
                        }
                    }
                    if (player == 'X')
                    {
                        if (array[x, y] == '?')
                        {
                            array[x, y] = 'X';
                            player = 'O';
                        }
                    }
                    else
                    {
                        if (array[x, y] == '?')
                        {
                            array[x, y] = 'O';
                            player = 'X';
                        }
                    }
                    graphinitial(array);
                }
                else 
                if(! (isvelha(array,player)) )
                {
                    graphinitial(array);
                    Console.WriteLine($"o vencedor é {winner(array)}");
                    Console.WriteLine("aperte qualquer botão para reiniciar");
                    Console.ReadKey();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            array[i, j] = '?';
                        }
                    }
                    graphinitial(array);
                }
                else
                {
                    Console.WriteLine("DEU VELHA!");
                    Console.ReadKey();
                    Console.WriteLine("aperte qualquer botão para reiniciar");
                    Console.ReadKey();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            array[i, j] = '?';
                        }
                    }
                    graphinitial(array);
                }
                
            }



            Console.ReadKey();
            
        }

        static void graphinitial(char[,] x )
        {
            
           Console.Clear();

            Console.WriteLine($"     A | B | C");
            Console.WriteLine("");
            Console.WriteLine($"1:   {x[0,0]} | {x[0, 1]} | {x[0, 2]} ");
            Console.WriteLine($"--  ---|---|---");
            Console.WriteLine($"2:   {x[1, 0]} | {x[1, 1]} | {x[1, 2]} ");
            Console.WriteLine($"--  ---|---|---");
            Console.WriteLine($"3:   {x[2, 0]} | {x[2, 1]} | {x[2, 2]} ");
             
        }

        static char winner(char[,] c)
        {
            char winner = '?';
            int  x = 0, y = 0;
            int[,] vet = new int[3, 2];
            char[] conv = {'A','B','C' };
            for ( ; x <= 2; x++)
            {
                if (c[x, y] == c[x, y + 1] && c[x, y] == c[x, y + 2])
                {
                    vet[0,0] = x;
                    vet[0,1] = y;
                    vet[1, 0] = x;
                    vet[1, 1] = y + 1;
                    vet[2, 0] = x;
                    vet[2, 1] = y + 2;

                    if (c[x, y] == 'X')
                        winner = 'x';
                    if (c[x, y] == 'O')
                        winner = 'o';


                }
            }
            x = 0;
            for (; y <= 2; y++)
            {
                if (c[x, y] == c[x+1, y ] && c[x, y] == c[x+2, y])
                {
                    vet[0, 0] = x;
                    vet[0, 1] = y;
                    vet[1, 0] = x+1;
                    vet[1, 1] = y;
                    vet[2, 0] = x+2;
                    vet[2, 1] = y;

                    if (c[x, y] == 'X')
                        winner = 'x';
                    if (c[x, y] == 'O')
                        winner = 'o';


                }
            }

            x = 0;
            y = 0;
            
            if(c[0, 0] == c[1,1] && c[0, 0] == c[2, 2])
            {
                vet[0, 0] = 0;
                vet[0, 1] = 0;
                vet[1, 0] = 1;
                vet[1, 1] = 1;
                vet[2, 0] = 2;
                vet[2, 1] = 2;

                if (c[x, y] == 'X')
                    winner = 'x';
                if (c[x, y] == 'O')
                    winner = 'o';
            }

            if (c[2, 0] == c[1, 1] && c[2, 0] == c[0, 2])
            {

                vet[0, 0] = 2;
                vet[0, 1] = 0;
                vet[1, 0] = 1;
                vet[1, 1] = 1;
                vet[2, 0] = 0;
                vet[2, 1] = 2;

                if (c[2, 0] == 'X')
                    winner = 'x';
                if (c[2, 0] == 'O')
                    winner = 'o';
            }

            if(winner != '?')
               Console.WriteLine($"FIM DE JOGO: ({conv[vet[0,1]]}{vet[0,0]+1}) | ({conv[vet[1, 1]]}{vet[1, 0]+1}) | ({conv[vet[2, 1]]}{vet[2, 0]+1})");




            return winner;


            

        }

        static Boolean isvelha(char[,] c, char player)
        {




            Boolean velha = false;




            
            int x = 0, y = 0;
            int qtd = 0;
            for (; x <= 2; x++)
            {
                if ((c[x, y] != c[x, y + 1] && c[x, y] != '?' && c[x, y + 1] != '?') || (c[x, y] != c[x, y + 2] && c[x, y] != '?' && c[x, y + 2] != '?'))
                {
                    qtd++;

                }
            }
            x = 0; y = 0;
            for (; y <= 2; y++)
            {
                if ((c[x, y] != c[x + 1, y] && c[x, y] != '?' && c[x+1, y ] != '?') || (c[x, y] != c[x + 2, y] && c[x, y] != '?' && c[x + 2, y] != '?'))
                {
                    qtd++;

                }
            }

            if ((c[0, 0] != c[1, 1] && c[0, 0] != '?' && c[1, 1] != '?') || (c[0, 0] != c[2, 2] && c[0, 0] != '?' && c[2, 2] != '?'))
            {
                qtd++;
            }

            if ((c[2, 0] != c[1, 1] && c[2, 0] != '?' && c[1, 1] != '?') || (c[2, 0] != c[0, 2] && c[2, 0] != '?' && c[0, 2] != '?'))
            {
                qtd++;
            }




            if (qtd == 8)
            {
                velha = true;
            }
             
            return velha;
        }





    }
    }
