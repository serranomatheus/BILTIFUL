using BILTIFUL.Core.Crud;
using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Compra : EntidadeBase
    {
        CrudCompra compraCrud = new CrudCompra();
        public DateTime DataCompra { get; set; } = DateTime.Now;
        //CNPJ
        public string Fornecedor { get; set; }
        public double ValorTotal { get; set; }
        public Compra()
        {

        }

        public Compra(string fornecedor, double valorTotal)//criação
        {
            
            Fornecedor = fornecedor;
            ValorTotal = valorTotal;
        }

        public Compra(double id,DateTime dataCompra, string fornecedor, double valorTotal)//leitura
        {
            Id = id;
            DataCompra = dataCompra;
            Fornecedor = fornecedor;
            ValorTotal = valorTotal;
        }

        public string ConverterParaEDI()
        {
            return $"{Id}{DataCompra.ToString("dd/MM/yyyy")}{Fornecedor}{ValorTotal}";
        }
        //public string DadosCompra()
        //{
        //    return "\t\t\t\t\t-------------------------------------------\n\t\t\t\t\tId: " + Id + "\n\t\t\t\t\tData de compra: " + DataCompra.ToString("dd/MM/yyyy") + "\n\t\t\t\t\tFornecedor: " + Fornecedor + "\n\t\t\t\t\tValor da compra: " + float.Parse(ValorTotal.Insert(5, ","));
        //}
    }
}
