using System;

namespace bloks;

class Program
{
    static byte YourForwardSBoxComputation(byte input)
    {
        return (byte)((input * 5 + 7) % 256);
    }

    static byte YourPBoxComputation(byte input)
    {
        return (byte)((input ^ 0x5A) & 0xFF);
    }

    static void Main(string[] args)
    {
        byte[] block = new byte[8] { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8 };

        Console.WriteLine("Initial Block:");
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"{block[i]:X} ");
        }
        Console.WriteLine();

        for (int round = 1; round <= 16; round++)
        {
            Console.WriteLine($"Round {round}:");
            for (int i = 0; i < 8; i++)
            {
                block[i] = YourForwardSBoxComputation(block[i]);
                Console.Write($"{block[i]:X} ");
            }
            Console.WriteLine();

            // P-блок
            byte[] permutedBlock = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                permutedBlock[i] = YourPBoxComputation(block[i]);
            }

            // Замінюємо блок на змішаний блок
            for (int i = 0; i < 8; i++)
            {
                block[i] = permutedBlock[i];
            }
        }

        Console.WriteLine("Final Block:");
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"{block[i]:X} ");
        }
        Console.WriteLine();
    }
}
