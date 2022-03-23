using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemCompra : EntidadeBase
    {
        public DateTime DataCompra { get; set; } = DateTime.Now;
        //ID materia prima
        public string MateriaPrima { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double TotalItem { get; set; }
        public int ItemCompraID { get; set; }

        public ItemCompra()
        {
        }

        public ItemCompra(int itemCOmpraID, double id,string materiaPrima, double quantidade, double valorUnitario, double totalitem)
        {
            ItemCompraID = itemCOmpraID;
            Id = id;
            MateriaPrima = materiaPrima;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalitem;
        }

        //public ItemCompra(string id, DateTime dataCompra, string materiaPrima, string quantidade, string valorUnitario, string totalItem)
        //{
        //    Id = id;
        //    DataCompra = dataCompra;
        //    MateriaPrima = materiaPrima;
        //    Quantidade = quantidade;
        //    ValorUnitario = valorUnitario;
        //    TotalItem = totalItem;
        //}

        //public string ConverterParaEDI()
        //{
        //    return $"{Id}{DataCompra.ToString("dd/MM/yyyy")}{MateriaPrima}{Quantidade}{ValorUnitario}{TotalItem}";
        //}
        public string DadosItemCompra()
        {
            return $"\n\t\t\t\t\t-------------------------------------------\n\t\t\t\t\tMateria prima: {MateriaPrima}\n\t\t\t\t\tQuantidade: {Quantidade}\n\t\t\t\t\tValor unitario: {ValorUnitario}\n\t\t\t\t\tTotal: {TotalItem}\n\t\t\t\t\t-------------------------------------------";
         }
    }
}
