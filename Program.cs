using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!!!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Opção 3 - Transferir selecionada.");
            Console.Write("Entre com a conta a ser sacada: ");
            int contaSacada = int.Parse(Console.ReadLine());

            Console.Write("Entre com a conta a depositar: ");
            int contaDeposito = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[contaSacada].Transferir(valorTransferencia, listContas[contaDeposito]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Opção 5 - Depositar selecionada.");
            Console.Write("Digite a conta para depositar: ");
            int contaDeposito = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[contaDeposito].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Opção 4 - Sacar selecionada.");
            Console.Write("Digite a conta a ser sacada: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Difite o valor a ser sacado: ");
            double valorSacado = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSacado);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Opção 1 - Inserir nova conta selecionada.");
            Console.WriteLine("Escolha o tipo de conta:\n1 - Conta Pessoa Física\n2 - Pessoa Jurídica\n");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                saldo: entradaSaldo,
                                credito: entradaCredito,
                                nome: entradaNome);

            listContas.Add(novaConta);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Opção 2 - Listar contas selecionada.");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("#*$ DIO Bank Skynet Systems $*#");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas cadastradas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


    }
}
