using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

Console.WriteLine("TcpServerTest");

TcpListener listener = new TcpListener(IPAddress.Any, 7);
listener.Start();
while (true)
{
    TcpClient socket = listener.AcceptTcpClient();
    IPEndPoint iPEndPoint = socket.Client.RemoteEndPoint as IPEndPoint;

    Console.WriteLine("client connected");




    Task.Run(() => HandleClient(socket));
}

listener.Stop();

void HandleClient(TcpClient socket)
{
    NetworkStream ns = socket.GetStream();
    StreamReader reader = new StreamReader(ns);
    StreamWriter writer = new StreamWriter(ns);

    while (socket.Connected)
    {
        string message = reader.ReadLine();
        Console.WriteLine(message);
        if (message == "Metoder")
        {
            writer.WriteLine("Hello World\n Serverens metoder er\n 1. Add\n 2. Subtract\n 3. Random\n 4. Stop");
            writer.Flush();
        }
        //Secret Method
        if (message == "Tak")
        {
            writer.WriteLine("Det var så lidt");
            writer.Flush();
        }
        if (message == "stop")
        {
            writer.WriteLine("Goodbye World");
            writer.Flush();
            socket.Close();
        }
        if (message == "Add")
        {
            writer.WriteLine("Input Numbers");
            writer.Flush();

            string numbersInput = reader.ReadLine();
            Console.WriteLine(numbersInput);

            var numbers = numbersInput.Split(new[] { ' ', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length == 2 && int.TryParse(numbers[0], out int num1) && int.TryParse(numbers[1], out int num2))
            {
                int result = num1 + num2;
                writer.WriteLine(result.ToString());
                writer.Flush();
            }
            else
            {
                writer.WriteLine("Invalid input. Please use the format <num1> <num2>");
                writer.Flush();
            }
        }
        if (message == "Subtract")
        {
            writer.WriteLine("Input Numbers");
            writer.Flush();

            string numbersInput = reader.ReadLine();
            Console.WriteLine(numbersInput);

            var numbers = numbersInput.Split(new[] { ' ', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length == 2 && int.TryParse(numbers[0], out int num1) && int.TryParse(numbers[1], out int num2))
            {
                int result = num1 - num2;
                writer.WriteLine(result.ToString());
                writer.Flush();
            }
            else
            {
                writer.WriteLine("Invalid input. Please use the format <num1> <num2>");
                writer.Flush();
            }
        }
        if (message == "Random")
        {
            writer.WriteLine("Input Numbers");
            writer.Flush();

            string numbersInput = reader.ReadLine();
            Console.WriteLine(numbersInput);

            var numbers = numbersInput.Split(new[] { ' ', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length == 2 && int.TryParse(numbers[0], out int num1) && int.TryParse(numbers[1], out int num2))
            {
                if (num1 > num2)
                {
                    writer.WriteLine("Invalid input. Please num1 has to be smaller than num2");
                    writer.Flush();
                }
                Random random = new Random();
                int result = random.Next(num1, num2);
                writer.WriteLine(result.ToString());
                writer.Flush();
            }
            else
            {
                writer.WriteLine("Invalid input. Please use the format <num1> <num2>");
                writer.Flush();
            }
        }

    }

}












