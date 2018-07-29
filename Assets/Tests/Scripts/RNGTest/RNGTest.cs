using System;

namespace RNGTest
{
    class RNGTest
    {

        public static string RollDouble(string spawnageDouble, Random random){
                double num = random.NextDouble();
                Console.WriteLine("The random double is " + num);
                print("Double");
                if (num <= 0.3){
                    print("gully");
                    spawnageDouble = "gully";
                }
                else if (num >= 0.3 && num <= 0.5){
                    print("Random Fire");
                    spawnageDouble = "Random Fire";
                }
                else if (num >= 0.5 && num <= 0.7){
                    print("Random Tall Object");
                    spawnageDouble = "Random Rall Object";
                }
                else if(num >0.7){
                    print("Enemy");
                    spawnageDouble = "Enemy";
                }

                return spawnageDouble;
        }

        public static string RollInt(int i, int min, int max,Random random, string spawnageInt){
                int num2 = random.Next(min,max);
                Console.WriteLine("The random integer is " + num2);

                print("Integer");
                if (num2 <= 30){
                    print("gully");
                    spawnageInt = "gully";
                }
                else if (num2 >= 30 && num2 <= 50){
                    print("Random Fire");
                    spawnageInt = "Random Fire";
                }
                else if (num2 >= 50 && num2 <= 70){
                    print("Random Tall Object");
                    spawnageInt = "Random Rall Object";
                }
                else if(num2 >=70 && num2 <= 80){
                    print("Enemy");
                    spawnageInt = "Enemy";
                }
                else if(num2 >= 80 && num2 <= 90){
                    print("Shooting enemy");
                    spawnageInt = "Shooting enemy";
                }    
                return spawnageInt;
        }
        static void Main()
        {
            int same = 0;
            int i = 0;
            int min = 0;
            int max = 100;
            Random random = new Random();

            string spawnageDouble = "";
            string spawnageInt = "";
            while(i<100){
                spawnageInt = RollInt(i,min,max,random,spawnageInt);
                spawnageDouble = RollDouble(spawnageDouble,random);
                i++;
                if (spawnageDouble == spawnageInt){
                    print("same");
                    same++;
                }    
                print("----------------------------");
                //System.Threading.Thread.Sleep(5000);
            }
            Console.WriteLine("Same:" + same);
        }

        static string print(string input){
            Console.WriteLine(input);
            return input;
        }
        static int print(int input){
            Console.WriteLine(input);
            return input;
        }
    }
}
