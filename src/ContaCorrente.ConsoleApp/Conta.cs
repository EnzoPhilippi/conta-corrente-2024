using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Conta
    {
        private int numero;
        private double saldo, limite;
        private bool ehEspecial;
        private string[] historico = new string[10];
        private Cliente titular;

        private void RegistrarMovimentacao(double valor, string tipo)
        {
            for (int i = 0; i < historico.Length; i++)
            {
                if (historico[i] is null)
                {
                    historico[i] = $"Numero da Conta: {this.numero}\nValor da movimentação: {valor}" +
                        $"\nTipo da Movimentação: {tipo}\nSaldo AtuaL: {saldo}\n";
                    break;
                }
            }
        }
        public void CriarConta(int conta, double saldo, double limite, bool ehEspecial, Cliente titular)
        {
            this.numero = conta;
            this.saldo = saldo;
            this.limite = limite;
            this.ehEspecial = ehEspecial;
            this.titular = titular;

        }
        public void Sacar(double valor, bool ehTransferencia)
        {
            if (ehTransferencia)
            {
                if (valor < (this.limite + this.saldo))
                {
                    this.saldo -= valor;
                    RegistrarMovimentacao(valor, "Transferencia");
                }
            }
            else
            {
                if (valor < (this.limite + this.saldo))
                {
                    this.saldo -= valor;
                    RegistrarMovimentacao(valor, "Saque");
                }
            }
        }
        public void Depositar(double valor, bool ehTransferencia)
        {
            if (ehTransferencia)
            {
                this.saldo += valor;
                RegistrarMovimentacao(valor, "Transferencia");
            }
            else
            {
                this.saldo += valor;
                RegistrarMovimentacao(valor, "Deposito");
            }

        }
        public void VisualisarSaldo()
        {
            Console.WriteLine($"Titular da conta: {titular.nome} {titular.sobrenome}\nCPF: {titular.cpf}\n");
            Console.WriteLine($"Conta Especial: {ehEspecial}");
            Console.WriteLine($"Saldo da conta do {titular.nome}: {this.saldo}\n");
        }
        public void VisualizarExtrato()
        {
            Console.WriteLine($"Titular da conta: {titular.nome} {titular.sobrenome}\nCPF: {titular.cpf}\n");
            for (int i = 0; i < historico.Length; i++)
            {

                if (historico[i] != null)
                    Console.WriteLine(historico[i]);
            }
        }
        public void Transferir(double valor, Conta conta)
        {
            Depositar(valor, true);
            conta.Sacar(valor, true);
        }
    }
}
