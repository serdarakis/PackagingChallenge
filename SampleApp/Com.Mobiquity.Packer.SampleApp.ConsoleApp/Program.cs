using System;
using System.IO;

namespace Com.Mobiquity.Packer.SampleApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Packer.Pack("Resources/example_input").Split(Environment.NewLine);

            var fileLines = File.ReadAllLines("Resources/example_output");

            for(int i = 0; i < result.Length; i++)
            {
                if(result[i] != fileLines[i])
                {
                    Console.WriteLine("Packing Failed");
                    return;
                }
            }
            
            Console.WriteLine("Packing Successfull");    
        }
    }
}
