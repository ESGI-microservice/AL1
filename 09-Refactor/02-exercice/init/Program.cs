﻿using System;
using System.IO;
using System.Linq;
using Xunit;

namespace csharpcore
{
    public class Program
    {
        private static bool notAWinner;

        public static void Run(string[] args)
        {
            Game aGame = new Game();

            var consoleListener = new GameConsoleListener();
            aGame.Publish += consoleListener.Handle;

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            Random rand = new Random();

            do
            {
                var randomValue = next(5, rand);

                aGame.Roll(randomValue + 1);

                if (next(9, rand) == 7)
                {
                    notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    notAWinner = aGame.CorrectAnswer();
                }
                
                aGame.NextPlayer();

            } while (notAWinner);
        }

        [Fact]
        public void CheckNoRegression()
        {
            var seed = File.ReadLines("./seed.txt").Select(x => int.Parse(x)).ToList();
            var output = File.ReadLines("./output.txt").ToList();

            // Plutot que random envoyer le seed courant
            Random rand = new Random();

            var cpt = 0;
            for (var i = 0; i < 100; i++)
            {
                Game aGame = new Game();

                aGame.Add("Chet");
                aGame.Add("Pat");
                aGame.Add("Sue");

                do
                {
                    var randomValue = seed[cpt];
                    cpt += 1;
                    aGame.Roll(randomValue + 1);

                    randomValue = seed[cpt + 1];
                    cpt += 1;

                    if (randomValue == 7)
                    {
                        notAWinner = aGame.WrongAnswer();
                    }
                    else
                    {
                        notAWinner = aGame.CorrectAnswer();
                    }
                } while (notAWinner);
                
                
            }

            // for (int i = 0; i < output.Count; i++)
            // {
            //     Assert.Equal(output[i], Game.lines[i]);
            // }
        }


        private static int next(int max, Random rand)
        {
            return rand.Next(max);
            //
            // Stack<int> randomNumber = new Stack<int>(new [] {
            //
            //     1,2,
            //     1,4,
            //     2,5,
            //     5,6,
            //     3,7,
            //     2,8,
            //     1,2,
            //     4,2,
            //     1,2,
            //     4,5,
            //     3,7,
            //     4,7,
            //     5,7,
            //     1,7,
            //     5,6,
            //     2,1,
            //     0,0,
            //     2,9,
            //     2,2,
            //     3,9
            // });
            //
            // var number = randomNumber.Pop();
            //
            // return number;
        }

        // [Fact]
        // public void GenerateGoldenMaster()
        // {
        //     Random rand = new Random();
        //
        //     for (var i = 0; i < 100; i++)
        //     {
        //         Game aGame = new Game();
        //
        //         aGame.add("Chet");
        //         aGame.add("Pat");
        //         aGame.add("Sue");
        //
        //         do
        //         {
        //             var randomValue = next(5, rand);
        //             File.AppendAllLines("seed1.txt", new[] {randomValue.ToString()});
        //             aGame.roll(randomValue + 1);
        //
        //             randomValue = next(9, rand);
        //             File.AppendAllLines("/tmp/seed1.txt", new[] {randomValue.ToString()});
        //
        //             if (randomValue == 7)
        //             {
        //                 notAWinner = aGame.wrongAnswer();
        //             }
        //             else
        //             {
        //                 notAWinner = aGame.wasCorrectlyAnswered();
        //             }
        //         } while (notAWinner);
        //
        //         File.AppendAllLines("/tmp/output1.txt", Game.lines);
        //
        //     }
        }
    
}

