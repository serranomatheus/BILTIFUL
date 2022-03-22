using BILTIFUL.Core.Entidades.Base;
using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class MPrima : EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime UltimaCompra { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public Situacao Situacao { get; set; } = Situacao.Ativo;

        public MPrima()
        {
        }

        public MPrima(string idcod,string nome)
        {
            this.Id = double.Parse(idcod);
            this.Nome = nome;
        }

        public MPrima(double id, string nome, DateTime ucompra, DateTime dcadastro, Situacao situacao)
        {
            this.Id = id;
            this.Nome = nome;
            this.UltimaCompra = ucompra;
            this.DataCadastro = dcadastro;
            this.Situacao = situacao;
        }



        public string ConverterParaEDI()
        {
            return $"{Id}{Nome.PadRight(20).Substring(0, 20)}{UltimaCompra.ToString("dd/MM/yyyy")}{DataCadastro.ToString("dd/MM/yyyy")}{(char)Situacao}";
        }
        public string DadosMateriaPrima()
        {
            return "\t\t\t\t\t-------------------------------------------\n\t\t\t\t\tId: " + Id + "\n\t\t\t\t\tNome: " + Nome + "\n\t\t\t\t\tData de ultima compra: " + UltimaCompra.ToString("dd/MM/yyyy") + "\n\t\t\t\t\tData de cadastro: " + DataCadastro.ToString("dd/MM/yyyy") + "\n\t\t\t\t\tSituação: " + Situacao;

        }
    }
}
