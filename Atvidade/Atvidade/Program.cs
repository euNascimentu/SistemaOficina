using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    // Variáveis
    static string[] produtos = new string[100];
    static int[] estoque = new int[100];
    static int contador = 0;

    static void Main()
    {
        // Inicio do sistema
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Novo Produto");
            Console.WriteLine("2. Listar Produto");
            Console.WriteLine("3. Remover Produto");
            Console.WriteLine("4. Entrada do Estoque");
            Console.WriteLine("5. Saída do Estoque");
            Console.WriteLine("0. Sair");
            Console.Write("Digite o numero da opção desejada: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarProduto();
                    break;
                case 2:
                    ListarProdutos();
                    break;
                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    EntradaEstoque();
                    break;
                case 5:
                    SaidaEstoque();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inexistente!");
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

        } while (opcao != 0);
    }

    // Parte de saida
    static void SaidaEstoque()
    {
        ListarProdutos();
        Console.Write("Digite o numero do produto para remover estoque: ");
        int indice = int.Parse(Console.ReadLine());
        Console.Write("Digite a quantidade que deseja remover: ");
        int quantidade = int.Parse(Console.ReadLine());

        if (indice >= 0 && indice < contador)
        {
            if (estoque[indice] >= quantidade)
            {
                estoque[indice] -= quantidade;
                Console.WriteLine("Estoque atualizado com !");
            }
            else
            {
                Console.WriteLine("A quantidade exedeu o limite!");
            }
        }
        else
        {
            Console.WriteLine("Índice inexistente!");
        }
    }

    // Parte de estoque
    static void EntradaEstoque()
    {
        ListarProdutos();
        Console.Write("Digite o numero do produto para adicionar estoque: ");
        int indice = int.Parse(Console.ReadLine());
        Console.Write("Digite a quantidade que deseja adicionar: ");
        int quantidade = int.Parse(Console.ReadLine());

        if (indice >= 0 && indice < contador)
        {
            estoque[indice] += quantidade;
            Console.WriteLine("Estoque atualizado com êxito!");
        }
        else
        {
            Console.WriteLine("Índice inexistente!");
        }
    }

    // Parte de adicionar produto
    static void AdicionarProduto()
    {
        if (contador >= produtos.Length)
        {
            Console.WriteLine("Limite de produtos atingido.");
            return;
        }

        Console.Write("Digite o nome do produto: ");
        produtos[contador] = Console.ReadLine();
        estoque[contador] = 0;
        contador++;
        Console.WriteLine("Produto adicionado com êxito!");
    }


    // Parte de remoção dos produtos
    static void RemoverProduto()
    {
        ListarProdutos();
        Console.Write("Digite o numero do produto que deseja remover: ");
        int indice = int.Parse(Console.ReadLine());

        if (indice >= 0 && indice < contador)
        {
            for (int i = indice; i < contador - 1; i++)
            {
                produtos[i] = produtos[i + 1];
                estoque[i] = estoque[i + 1];
            }
            produtos[contador - 1] = null; // Limpa o último item
            estoque[contador - 1] = 0; // Limpa o estoque
            contador--;
            Console.WriteLine("Produto removido com êxito!");
        }
        else
        {
            Console.WriteLine("Índice inexistente!");
        }
    }

    // Parte de listagem
    static void ListarProdutos()
    {
        Console.WriteLine("Lista de Produtos:");
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine($"[{i}] {produtos[i]} - Estoque: {estoque[i]}");
        }
    }
}