using Gamificacao3;
using Gamificacao3.Interfaces;

namespace Gamificacao3
{
    public class Menu
    {

        private readonly string connectionString;

        public Menu(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void CriarNovoPedido(GerenciamentoDePedidos gerenciamentoDePedidos)
        {
            Console.WriteLine("===== CRIAR NOVO PEDIDO =====");
            Console.Write("Data do pedido: ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Console.Write("Cliente: ");
            var cliente = new Cliente(Console.ReadLine());
            Console.Write("Status do pedido: ");
            string ?status = Console.ReadLine();

            gerenciamentoDePedidos.CriarPedido(data, cliente, status);

            Console.WriteLine("Pedido criado com sucesso!");
        }

        public void AdicionarItensAoPedido(GerenciamentoDePedidos gerenciamentoDePedidos)
        {
            Console.WriteLine("===== ADICIONAR ITENS AO PEDIDO =====");
            Console.Write("ID do pedido: ");
            int pedidoId = int.Parse(Console.ReadLine());
            Console.Write("ID do produto: ");
            int produtoId = int.Parse(Console.ReadLine());
            var produtoRepository = new ProdutoRepository(connectionString);
            var produto = produtoRepository.GetById(produtoId);
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            gerenciamentoDePedidos.AdicionarItemPedido(pedidoId, produtoId, quantidade, produto.Preco);
            //var itemPedidoRepository = new ItemPedidoRepository(connectionString);
            //var pedidoRepository = new PedidoRepository(connectionString);
            //public ItemPedido(int id, Produto? produto, int quantidade, decimal precoUnitario, Pedido? pedido);
            //var pedido = pedidoRepository.GetById(pedidoId);
            //var itemPedido = new ItemPedido(0, produto, quantidade, produto.Preco, pedido);
            //pedidoRepository.AdicionarItem(pedidoId, itemPedido);
            Console.WriteLine("Item adicionado ao pedido com sucesso!");

        }

        public void AtualizarStatusPedido(GerenciamentoDePedidos gerenciamentoDePedidos)
        {
            Console.WriteLine("===== ATUALIZAR STATUS DO PEDIDO =====");
            Console.Write("ID do pedido: ");
            int pedidoId = int.Parse(Console.ReadLine());
            Console.Write("Novo status: ");
            string novoStatus = Console.ReadLine();

            gerenciamentoDePedidos.AtualizarStatusPedido(pedidoId, novoStatus);

            Console.WriteLine("Status do pedido atualizado com sucesso!");
        }

        public void RemoverPedido(GerenciamentoDePedidos gerenciamentoDePedidos)
        {
            Console.WriteLine("===== REMOVER PEDIDO =====");
            Console.Write("ID do pedido: ");
            int pedidoId = int.Parse(Console.ReadLine());

            gerenciamentoDePedidos.RemoverPedido(pedidoId);

            Console.WriteLine("Pedido removido com sucesso!");
        }

        public void ListarPedidos(GerenciamentoDePedidos gerenciamentoDePedidos)
        {
            Console.WriteLine("===== LISTAR PEDIDOS =====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Listar por cliente");
            Console.WriteLine("2. Listar por status");
            Console.WriteLine("3. Listar por data");
            Console.WriteLine("4. Voltar");

            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Cliente: ");
                    var cliente = new Cliente(Console.ReadLine());
                    var pedidosPorCliente = gerenciamentoDePedidos.ListarPedidosPorCliente(cliente);
                    Console.WriteLine("Pedidos encontrados:");
                    foreach (var pedido in pedidosPorCliente)
                    {
                        Console.WriteLine("Cliente: " + pedido?.Cliente?.Nome + "; Data: " + pedido?.Data + "; Status: " + pedido?.Status);
                    }
                    break;
                case "2":
                    Console.Write("Status: ");
                    string status = Console.ReadLine();
                    var pedidosPorStatus = gerenciamentoDePedidos.ListarPedidosPorStatus(status);
                    Console.WriteLine("Pedidos encontrados:");
                    foreach (var pedido in pedidosPorStatus)
                    {
                        Console.WriteLine("Cliente: " + pedido.Cliente.Nome + "; Data: " + pedido.Data + "; Status: " + pedido.Status);
                    }
                    break;
                case "3":
                    Console.Write("Digite a data formato (DD/MM/AAAA): ");
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    var pedidosPorData = gerenciamentoDePedidos.ListarPedidosPorData(data);
                    Console.WriteLine("Pedidos encontrados:");
                    foreach (var pedido in pedidosPorData)
                    {
                        Console.WriteLine("Cliente: " + pedido.Cliente.Nome + "; Data: " + pedido.Data + "; Status: " + pedido.Status);
                    }
                    break;
                case "4":
                    // Voltar
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }

        public void CalcularValorTotalPedido(GerenciamentoDePedidos gerenciamentoDePedidos)
        {
            Console.WriteLine("===== CALCULAR VALOR TOTAL DO PEDIDO =====");
            Console.Write("ID do pedido: ");
            int pedidoId = int.Parse(Console.ReadLine());

            decimal valorTotal = gerenciamentoDePedidos.CalcularValorTotalPedido(pedidoId);

            Console.WriteLine($"Valor total do pedido: R${valorTotal:F2}");
        }

        public void AcessoAdministrador(GerenciamentoDePedidos gerenciamentoDePedidos, ProdutoRepository produtoRepository)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("===== ACESSO ADMINISTRADOR =====");
                Console.WriteLine("1. Criar novo produto");
                Console.WriteLine("2. Atualizar produto");
                Console.WriteLine("3. Remover produto");
                Console.WriteLine("4. Listar todos os produtos");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("===============================");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        // Criar novo produto
                        CriarNovoProduto(produtoRepository);
                        break;
                    case "2":
                        // Atualizar produto
                        AtualizarProduto(produtoRepository);
                        break;
                    case "3":
                        // Remover produto
                        RemoverProduto(produtoRepository);
                        break;
                    case "4":
                        // Listar todos os produtos
                        ListarTodosProdutos(produtoRepository);
                        break;
                    case "0":
                        // Voltar
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public void CriarNovoProduto(ProdutoRepository produtoRepository)
        {
            Console.WriteLine("===== CRIAR NOVO PRODUTO =====");
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Descrição do produto: ");
            string descricao = Console.ReadLine();
            Console.Write("Preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.Write("Quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = new Produto(0, nome, descricao, preco, quantidade);
            produtoRepository.Create(produto);

            Console.WriteLine("Produto criado com sucesso!");
        }

        public void AtualizarProduto(ProdutoRepository produtoRepository)
        {
            Console.WriteLine("===== ATUALIZAR PRODUTO =====");
            Console.Write("ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            Produto produto = produtoRepository.GetById(id);
            if (produto != null)
            {
                Console.Write("Novo nome do produto: ");
                string nome = Console.ReadLine();
                Console.Write("Nova descrição do produto: ");
                string descricao = Console.ReadLine();
                Console.Write("Novo preço do produto: ");
                decimal preco = decimal.Parse(Console.ReadLine());
                Console.Write("Nova quantidade em estoque: ");
                int quantidade = int.Parse(Console.ReadLine());

                produto.Nome = nome;
                produto.Descricao = descricao;
                produto.Preco = preco;
                produto.QuantidadeEmEstoque = quantidade;

                produtoRepository.Update(produto);

                Console.WriteLine("Produto atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }

        public void RemoverProduto(ProdutoRepository produtoRepository)
        {
            Console.WriteLine("===== REMOVER PRODUTO =====");
            Console.Write("ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            produtoRepository.Delete(id);

            Console.WriteLine("Produto removido com sucesso!");
        }

        public void ListarTodosProdutos(ProdutoRepository produtoRepository)
        {
            Console.WriteLine("===== LISTAR TODOS OS PRODUTOS =====");
            var produtos = produtoRepository.ListAll();

            if (produtos.Any())
            {
                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto);
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado!");
            }
        }
    }
}