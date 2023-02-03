using LABB34;

using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;

using LABB34.Data;
using LABB34.Models;

namespace LABB34
{
    public class Program
    {
        static void Main(string[] args)
        {
            Navi navi = new Navi();
            //navi.Show();
            navi.Start();

            using Labb4Context db = new Labb4Context();

            Console.WriteLine("Hello, World!");
        }
    }
}