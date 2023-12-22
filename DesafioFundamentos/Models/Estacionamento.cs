using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();        
            bool placaValida = VerificarPlacaValida(placa);
            if (!placaValida) 
            {
                Console.WriteLine("A placa não é válida. Por favor, insira uma placa válida.");                
            }

            bool veiculoExiste = ProcurarVeiculo(placa);
            if (veiculoExiste)
            {
                throw new ArgumentException("Já existe veículo cadastrado no sistema com essa placa.");                    
            }
            veiculos.Add(placa);            
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();
            bool veiculoExiste = ProcurarVeiculo(placa);
            if (veiculoExiste)
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int.TryParse(Console.ReadLine(), out var horas);
            
                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    decimal valorTotal = precoPorHora * horas + precoInicial;
                    bool veiculoRemovido = veiculos.Remove(placa);
                    if (veiculoRemovido)
                    {
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:C}");
                    }
                    else
                    {
                        throw new ArgumentException($"Ocorreu um erro ao remover o veículo.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                int contador = 0;
                foreach (string veiculo in veiculos) {
                    Console.WriteLine($"Veículo {contador + 1} - {veiculo}");
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool VerificarPlacaValida(string placa)
        {
            bool placaNulaOuVazia = string.IsNullOrWhiteSpace(placa);
            bool placaPossuiTamanhoMenorQueZero = placa.Length < 0;
            if (placaNulaOuVazia || placaPossuiTamanhoMenorQueZero)
            {
                return false;
            }

            placa = placa.Replace("-", "").Trim();
            // Adicionando o padrão Mercosul: segue a seguinte ordem: 3 letras, 1 número, 1 letra e 2 números.
            var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");           
            return padraoMercosul.IsMatch(placa);            
        }

        private bool ProcurarVeiculo(string veiculo)
        {
            bool veiculoExisteNaLista = veiculos.Contains(veiculo);            
            return veiculoExisteNaLista;
        }
    }
}
