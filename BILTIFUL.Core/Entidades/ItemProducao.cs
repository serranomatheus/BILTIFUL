using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemProducao : EntidadeBase
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID Materia Prima
        public string MateriaPrima { get; set; }
        public string QuantidadeMateriaPrima { get; set; }

        public ItemProducao()
        {

        }

        public ItemProducao(double id, DateTime dataProducao, string materiaPrima, string quantidadeMateriaPrima)
        {
            Id = id;
            DataProducao = dataProducao;
            MateriaPrima = materiaPrima;
            QuantidadeMateriaPrima = quantidadeMateriaPrima;
        }

        //public ItemProducao(string id,string materiaPrima, string quantidadeMateriaPrima)
        //{
        //    Id = id;
        //    MateriaPrima = materiaPrima;
        //    QuantidadeMateriaPrima = quantidadeMateriaPrima;
        //}

        //public string ConverterParaEDI()
        //{
        //    return $"{Id.PadLeft(5, '0')}{DataProducao.ToString("dd/MM/yyyy")}{MateriaPrima}{QuantidadeMateriaPrima.ToString().PadLeft(5, '0')}";
        //}
        //public string DadosItemProducao()
        //{
        //    return $"-------------------------------------------\nMateria prima: {MateriaPrima}\nQuantidade de materia prima{QuantidadeMateriaPrima.Insert(3, ",")}\n-------------------------------------------";
        //}
    }
}
