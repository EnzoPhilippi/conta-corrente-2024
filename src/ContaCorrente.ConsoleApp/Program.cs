namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta();
            Conta conta2 = new Conta();
            Cliente titular1 = new Cliente();
            Cliente titular2 = new Cliente();

            titular1.nome = "Enzo";
            titular1.sobrenome = "Philippi";
            titular1.cpf = "100.100.100-10";

            titular2.nome = "Jair";
            titular2.sobrenome = "Philippi";
            titular2.cpf = "200.200.200-20";

            conta1.CriarConta(1, 2000, 1000, false, titular1);
            conta2.CriarConta(2, 2000, 1000, false, titular2);

            conta1.VisualisarSaldo();
            conta1.Depositar(1000, false);
            conta1.Sacar(500, false);
            Console.WriteLine("Histórico");
            conta1.VisualizarExtrato();

            Console.WriteLine("------------------");

            conta2.VisualisarSaldo();
            conta2.Depositar(2000, false);
            conta2.Sacar(500, false);
            Console.WriteLine("Histórico");
            conta2.VisualizarExtrato();

            conta1.Transferir(100, conta2);

            Console.WriteLine("------------------");
            Console.WriteLine("Histórico");
            conta1.VisualizarExtrato();
            Console.WriteLine("------------------");
            Console.WriteLine("Histórico");
            conta2.VisualizarExtrato();
        }
    }
}
