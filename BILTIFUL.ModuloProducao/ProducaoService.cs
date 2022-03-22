﻿using BILTIFUL.Core;
using BILTIFUL.Core.Controles;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BILTIFUL.ModuloProducao
{
    public class ProducaoService
    {

        CadastroService cadastroService = new CadastroService();

        public void SubMenu()
        {
            string opcao = "";

           
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t __________________________________________________");
            Console.WriteLine("\t\t\t\t\t|+++++++++++++++++++| PRODUÇÃO |+++++++++++++++++++|");
            Console.WriteLine("\t\t\t\t\t|1| - ADICIONAR PRODUÇÃO                           |");
            Console.WriteLine("\t\t\t\t\t|2| - LOCALIZAR PRODUÇÃO                           |");
            Console.WriteLine("\t\t\t\t\t|3| - EXIBIR PRODUÇÃO CADASTRADAS                  |");        
            Console.WriteLine("\t\t\t\t\t|0| - SAIR                                         |");
            Console.Write("\t\t\t\t\t|__________________________________________________|\n" +
                          "\t\t\t\t\t|Opção: ");
          

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    break;

                case "1":
                    Console.Clear();
                   if (!MateriaPrimaVazia()) EntradaDadosProducao(new Producao());
                    break;

                case "2":
                    Console.Clear();
                    if (!ProducaoVazia()) Localizar();
                    break;

                case "3":
                    Console.Clear();
                    if (!ProducaoVazia()) ImpressaoDoRegistro();
                    break;
                default:
                    Console.WriteLine("\t\t\t\t\tOpção inválida! ");
                    Console.ReadKey();
                    SubMenu();
                    break;
            }

        }

        public void BackMenu()
        {
            Console.Write("\n\t\t\t Pressione qualquer tecla para voltar ao menu de Produção...");
            Console.ReadKey();
            Console.Clear();
            SubMenu();
        }

        public bool ProducaoVazia()
        {
            if (cadastroService.cadastros.producao.Count == 0)
            {
                Console.WriteLine("\n\t\t\tNenhuma produção cadastrada no sistema.");
                BackMenu();
                return true;
            }

            return false;
        }

        public bool MateriaPrimaVazia()
        {
            if (cadastroService.cadastros.materiasprimas.Count == 0)
            {
                Console.WriteLine("\n\t\t\tNenhuma Materia Prima cadastrada no sistema.");
                BackMenu();
                return true;
            }

            return false;
        }

        void EntradaDadosProducao(Producao producao)
        {           

            List<ItemProducao> itemProducoes = new List<ItemProducao>();
            Produto produto = new Produto();

            if (cadastroService.cadastros.produtos.Count == 0) Console.WriteLine("\n\t\t\tNenhum produto cadastrado");

            Console.Write("\n\t\t\tDeseja cadastrar um novo produto para Produção (S/N): ");
            string existe = Console.ReadLine().ToUpper();
            if (existe == "S")
            {
                produto = cadastroService.CadastroProduto();
                if (produto != null) producao.Produto = produto.CodigoBarras;
            }
            else if (existe == "N")
            {
                do
                {
                    Console.Write("\n\t\t\tInsira o nome do produto a ser localizado: ");
                    string nome = Console.ReadLine();

                    produto = cadastroService.cadastros.produtos.Find(c => c.Nome == nome && c.Situacao == Situacao.Ativo);

                    if (produto != null)
                    {
                        producao.Produto = produto.CodigoBarras;
                        Console.WriteLine(produto.DadosProduto());
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t\tProduto não localizado");
                    }

                } while (produto == null);

            }
            else EntradaDadosProducao(new Producao());

            if (producao.Quantidade == null)
            {
                Console.Write("\n\t\t\tQuantidade de produtos: ");
                if (Int32.TryParse(Console.ReadLine(), out int quantidade))
                    producao.Quantidade = quantidade.ToString();
                else
                {
                    Console.WriteLine("\n\t\t\tQuantidade inválida");
                    EntradaDadosProducao(producao);
                }
            }

            bool materiaprima;
            do
            {
                itemProducoes.Add(EntradaDadosItemProducao(new ItemProducao()));
                Console.Write("\n\t\t\tDeseja adicionar mais alguma materia prima? (S/N): ");
                string confirmar = Console.ReadLine().ToUpper();
                materiaprima = confirmar == "S";

            } while (materiaprima);

            DadosProducao(producao);

            Console.Write("\n\t\t\tDeseja cadastrar a produção (S/N): ");
            string confirma = Console.ReadLine().ToUpper();

            if (confirma == "S")
            {
                Cadastro(producao, itemProducoes);
            }
            BackMenu();

        }


        ItemProducao EntradaDadosItemProducao(ItemProducao itemProducao)
        {

            int posicao = 0;

            int materiasprimas = 0;

            Console.WriteLine("\n\t\t\tQuais as materias primas utilizadas?");
            cadastroService.cadastros.materiasprimas.ForEach(c => Console.WriteLine("\t\t\t" + ++posicao + "- " + c.Nome));
            do
            {
                Console.Write("\n\t\t\tOpção: ");
                itemProducao.MateriaPrima = Console.ReadLine();
                if (!int.TryParse(itemProducao.MateriaPrima, out materiasprimas) || materiasprimas > cadastroService.cadastros.materiasprimas.Count || materiasprimas == 0)
                    Console.WriteLine("\n\t\t\tItem invalido!");
            } while (!int.TryParse(itemProducao.MateriaPrima, out materiasprimas) || materiasprimas > cadastroService.cadastros.materiasprimas.Count || materiasprimas == 0);

            itemProducao.MateriaPrima = cadastroService.cadastros.materiasprimas[materiasprimas - 1].Id;


            if (itemProducao.QuantidadeMateriaPrima == null)
            {
                Console.Write("\n\t\t\tQuantidade Materia prima: ");
                if (Int32.TryParse(Console.ReadLine(), out int quantidade))
                    itemProducao.QuantidadeMateriaPrima = quantidade.ToString();
                else
                {
                    Console.WriteLine("\n\t\t\tQuantidade inválida");
                    EntradaDadosItemProducao(itemProducao);
                }
            }

            /*Console.WriteLine("Quantidade Materia prima");
            while (!double.TryParse(Console.ReadLine(), out double quantidadeMateriaPrima))
            {
                Console.WriteLine("Quantos produtos serão produzidos");
                itemProducao.QuantidadeMateriaPrima = quantidadeMateriaPrima.ToString();
            }*/

            return itemProducao;

        }

        void Cadastro(Producao producao, List<ItemProducao> itemProducaos)
        {
            producao.Id = (++cadastroService.cadastros.codigos[4]).ToString();
            cadastroService.SalvarCodigos();

            cadastroService.cadastros.producao.Add(producao);
            new Controle(producao);

            cadastroService.cadastros.itensproducao.AddRange(itemProducaos);
            itemProducaos.ForEach(c => { c.Id = producao.Id; new Controle(c); });

        }


        void DadosProducao(Producao producao)
        {
            Console.WriteLine(producao.Dados());
            Console.Write("\n\t\t\tProduto: ");
            Console.WriteLine((cadastroService.cadastros.produtos.Find(c => c.CodigoBarras == producao.Produto)).DadosProduto());

            List<ItemProducao> itens = cadastroService.cadastros.itensproducao.FindAll(c => c.Id == producao.Id);


            foreach (var itemProducao in itens)
            {
                Console.WriteLine("\n\t\t\tQuantidade Materia prima: " + itemProducao.QuantidadeMateriaPrima);
                Console.WriteLine((cadastroService.cadastros.materiasprimas.Find(c => c.Id == itemProducao.MateriaPrima)).DadosMateriaPrima());
            }
        }

        void ImpressaoDoRegistro()
        {

            int i = 0;
            string opc = "-1";
            while (opc != "0")
            {
                Console.Clear();
                DadosProducao(cadastroService.cadastros.producao[i]);
                Console.WriteLine();
                if (i > 0)
                {
                    Console.WriteLine("1-primeiro");
                    Console.WriteLine("2-anterior");
                }
                if (i < cadastroService.cadastros.producao.Count() - 1)
                {
                    Console.WriteLine("3-proximo");
                    Console.WriteLine("4-ultimo");
                }
                Console.WriteLine("0-Sair");
                Console.Write("Opção: ");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        i = 0;
                        break; ;
                    case "2":
                        if (i - 1 >= 0)
                            i--;
                        else
                            Console.WriteLine("Não existe registro antes deste");
                        break;
                    case "3":
                        if (i + 1 <= cadastroService.cadastros.producao.Count() - 1)
                            i++;
                        else
                            Console.WriteLine("Não existe registro depois deste");
                        break;
                    case "4":
                        i = cadastroService.cadastros.producao.Count() - 1;
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }

            }

        }

        void Localizar()
        {

            Console.Write("Digite o nome ou código de barras do produto para localizar a produção: ");
            string busca = Console.ReadLine();

            Produto produto = cadastroService.cadastros.produtos.FirstOrDefault(c => c.Nome == busca || c.CodigoBarras == busca);
            Producao producao = produto != null ? producao = cadastroService.cadastros.producao.Find(c => c.Produto == produto.CodigoBarras) : null;

            if (producao != null) DadosProducao(cadastroService.cadastros.producao.Find(c => c.Produto == produto.CodigoBarras));
            else Console.WriteLine("Nenhuma produção encontrada para esse produto\n\n" + (produto != null ? produto.DadosProduto() : string.Empty));

            BackMenu();
        }

    }
}
