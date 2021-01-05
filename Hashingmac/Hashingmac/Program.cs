using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashingmac
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Text to be hashed: ");
                string input = Console.ReadLine();
                Console.WriteLine("Select type of hasing");
                Console.WriteLine("1.Sha1");
                Console.WriteLine("2.Sha256");
                Console.WriteLine("3.Sha512");
                Console.WriteLine("4.hMd5");
                Console.WriteLine("5.Hmacsha1");
                Console.WriteLine("6.Hmacsha256");
                Console.WriteLine("7.Hmacsha512");
                Console.WriteLine("8.Hmacmd5");
                int select = int.Parse(Console.ReadLine());
                byte[] bytes = Encoding.ASCII.GetBytes(input);
                string output = "";
                string keyword = "";
                byte[] bytekey;
                string hex = "";
                switch (select)//Selecting between all of the metods
                {
                    case 1:
                        output = Convert.ToBase64String(Hasher.ComputeHashSha1(bytes));//Converts to readable string
                        hex = BitConverter.ToString(Hasher.ComputeHashSha1(bytes));//converts to hex
                        break;
                    case 2:
                        output = Convert.ToBase64String(Hasher.ComputeHashSha256(bytes));
                        hex = BitConverter.ToString(Hasher.ComputeHashSha256(bytes));
                        break;
                    case 3:
                        output = Convert.ToBase64String(Hasher.ComputeHashSha512(bytes));
                        hex = BitConverter.ToString(Hasher.ComputeHashSha512(bytes));
                        break;
                    case 4:
                        output = Convert.ToBase64String(Hasher.ComputeHashMd5(bytes));
                        hex = BitConverter.ToString(Hasher.ComputeHashMd5(bytes));
                        break;
                    case 5:
                        Console.WriteLine("Enter a key");
                        keyword = Console.ReadLine();
                        bytekey = Encoding.ASCII.GetBytes(keyword);
                        output = Convert.ToBase64String(HMAC.ComputeHmacsha1(bytes, bytekey));
                        hex = BitConverter.ToString(HMAC.ComputeHmacsha1(bytes, bytekey));
                        break;
                    case 6:
                        Console.WriteLine("Enter a key");
                        keyword = Console.ReadLine();
                        bytekey = Encoding.ASCII.GetBytes(keyword);
                        output = Convert.ToBase64String(HMAC.ComputeHmacsha256(bytes, bytekey));
                        hex = BitConverter.ToString(HMAC.ComputeHmacsha256(bytes, bytekey));
                        break;
                    case 7:
                        Console.WriteLine("Enter a key");
                        keyword = Console.ReadLine();
                        bytekey = Encoding.ASCII.GetBytes(keyword);
                        output = Convert.ToBase64String(HMAC.ComputeHmacsha512(bytes, bytekey));
                        hex = BitConverter.ToString(HMAC.ComputeHmacsha512(bytes, bytekey));
                        break;
                    case 8:
                        Console.WriteLine("Enter a key");
                        keyword = Console.ReadLine();
                        bytekey = Encoding.ASCII.GetBytes(keyword);
                        output = Convert.ToBase64String(HMAC.ComputeHmacmd5(bytes, bytekey));
                        hex = BitConverter.ToString(HMAC.ComputeHmacmd5(bytes, bytekey));
                        break;
                    default:
                        break;
                }
                Console.WriteLine(output);
                Console.WriteLine(hex);
                Console.WriteLine("PRESS ENTER TO RESTART..");
                Console.ReadKey();
                Console.Clear();
            }
            
        }
    }
}
