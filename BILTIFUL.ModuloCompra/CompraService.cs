using BILTIFUL.Core;
//using BILTIFUL.Core.Controles;
using BILTIFUL.Core.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BILTIFUL.Core.Controles;
using BILTIFUL.Core.Crud;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;


namespace BILTIFUL.ModuloCompra
{
    public class CompraService
    {
        CrudCompra crudCompra = new CrudCompra();
        CadastroService cadastroService = new CadastroService();


        string cnpj;
        public void SubMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t __________________________________________________");
            Console.WriteLine("\t\t\t\t\t|+++++++++++++++++++| COMPRAS |+++++++++++++++++++|");
            Console.WriteLine("\t\t\t\t\t|1| - CADASTRAR COMPRA                            |");
            Console.WriteLine("\t\t\t\t\t|2| - LOCALIZAR COMPRA                            |");
            Console.WriteLine("\t\t\t\t\t|3| - EXIBIR COMPRAS CADASTRADAS                  |");
            Console.WriteLine("\t\t\t\t\t|0| - SAIR                                        |");
            Console.Write("\t\t\t\t\t|_________________________________________________|\n" +
                          "\t\t\t\t\t|Opção: ");

            string opc = Console.ReadLine();
            switch (opc)
            {
                case "1":
                    CadastrarCompra();

                    break;
                case "2":
                    LocalizarCompra();
                    break;
                case "3":
                    //// if (cadastroService.cadastros.compras.Count() != 0)
                    //  //   new Registros(cadastroService.cadastros.compras, cadastroService.cadastros.itenscompra);
                    // else
                    //     Console.WriteLine("\t\t\t\t\tNenhum produto registrado");
                    break;
                case "0":
                    break;
                default:
                    break;
            }
        }

        public void LocalizarCompra()
        {
            string opc;
            do
            {

                Console.Clear();
                Console.WriteLine("\t\t\t\t\t________________________________________________");
                Console.WriteLine("\t\t\t\t\t|++++++++++++| MENU DE LOCALIZAÇÃO |+++++++++++|");                
                Console.WriteLine("\t\t\t\t\t|1| - LOCALIZAR POR FORNECEDOR                 |");
                Console.WriteLine("\t\t\t\t\t|2| - LOCALIZAR POR ID                         |");
                Console.WriteLine("\t\t\t\t\t|0| - voltar                                   |");
                Console.Write("\t\t\t\t\t|______________________________________________|\n" +
                              "\t\t\t\t\t|opção: ");
                opc = Console.ReadLine();
                bool encontrado = false;
                Console.Clear();
                switch (opc)
                {
                    

                    case "1":                       

                        Console.Write("\t\t\t\t\tdigite o cnpj do fornecedor que deseja localizar: ");

                        cnpj = Console.ReadLine().Trim().Replace(".", "").Replace("-", "").Replace("/", "");
                        
                        List<Compra> compras = new List<Compra>();

                        compras = crudCompra.LocalizarCompraCNPJ(cnpj);
                        if (compras != null)
                        {
                            encontrado = true;
                            foreach (Compra p in compras )
                            {
                                Console.WriteLine(p.DadosCompra());
                                Console.WriteLine("\t\t\t\t\titens: ");
                                foreach(ItemCompra i in p.itemcompra)
                                {
                                    Console.WriteLine(i.DadosItemCompra());
                                    
                                }
                                Console.WriteLine("\t\t\t\t\tPressione uma tecla para continuar impressao");
                                Console.ReadKey();
                            }
                            Console.WriteLine("\t\t\t\t\tFinal de impressao");
                            Console.WriteLine("\t\t\t\t\tPressione uma tecla para voltar");
                            Console.ReadKey();
                        }
                        Console.ReadKey();
                        if (encontrado != true)
                        {
                            Console.WriteLine("\t\t\t\t\tnenhuma compra encontrada");
                            Console.ReadKey();
                        }
                


                break;
                    case "2":
                        Console.Write("\t\t\t\t\tDigite o id da compra que deseja localizar: ");
                        if (double.TryParse(Console.ReadLine(), out double confirmar2))
                        {
                            double idcompra = confirmar2;
                            List<Compra> comprasId = new List<Compra>();
                            comprasId = crudCompra.LocalizarCompraID(idcompra);
                            if (comprasId != null)
                            {
                                encontrado = true;
                                foreach (Compra p in comprasId)
                                {
                                    Console.WriteLine(p.DadosCompra());
                                    Console.WriteLine("\t\t\t\t\titens: ");
                                    foreach (ItemCompra i in p.itemcompra)
                                    {
                                        Console.WriteLine(i.DadosItemCompra());
                                    }
                                }

                            }
                            Console.WriteLine("\t\t\t\t\tFinal de impressao");
                            Console.WriteLine("\t\t\t\t\tPressione uma tecla para voltar");
                            Console.ReadKey();
                            if (encontrado != true)
                            {
                                Console.WriteLine("\t\t\t\t\tnenhuma compra encontrada");
                                Console.ReadKey();
                            }
                        }
                        else
                        { Console.WriteLine("\t\t\t\t\tId invalido");
                            Console.ReadKey();
                        }


                        break;
                    case "0":
                        SubMenu();
                break;
                default:
                        Console.WriteLine("selecione uma opcao valida");
                        Console.ReadKey();
                        break;
            }

            } while (opc != "0");
        }




    public void CadastrarCompra()
    {

        bool fornecedorEncontrado = false;
        string opc = "a";

        Console.Clear();
        do
        {
            Console.WriteLine("\n\t\t\t\t\t------------CADASTRAR COMPRA------------");
            Console.Write("\t\t\t\t\tInforme o CNPJ do fornecedor : ");


            cnpj = Console.ReadLine().Trim().Replace(".", "").Replace("-", "").Replace("/", "");


            if (crudCompra.PesquisarBloqueado(cnpj) == true)
            {

                return;
            }
            fornecedorEncontrado = crudCompra.PesquisarCNPJ(cnpj);
            if (fornecedorEncontrado == true)
            {
                do
                {
                    Console.Write("\t\t\t\t\tConfirma dados do Fornecedor (S/N): ");
                    opc = Console.ReadLine().ToUpper();

                    if ((opc != "S" & opc != "N"))
                    {
                        Console.Write("\t\t\t\t\tEscolha uma opcao valida : ");

                    }
                } while (opc != "S" & opc != "N");
                if (opc == "N")
                {
                    Console.WriteLine("");
                    CadastrarCompra();
                }
            }
            else
            {
                Console.WriteLine("\t\t\t\t\tFornecedor nao encontrado");
                Console.WriteLine("\t\t\t\t\tPressione uma tecla para voltar");
                Console.ReadKey();
                CadastrarCompra();
            }

        } while (opc != "S");
        ItemCompra();


    }
    public void ItemCompra()
    {
        int cont = 0;
        string saida = "a";
        string opcp = "a";
        
        
        double[] valorQuantidade = new double[4];
        double[] quantidade = new double[4];
        double[] totalItem = new double[4];
        string[] idMPrima = new string[4];
        
        double valorTotal = 0;
        
        bool valorTotalMaior = false;
        string[] nomeMPrima = new string[4];


        do
        {
            opcp = "a";
           
            bool buscar = false;
            Console.Clear();
            do
            {
                Console.Write("\t\t\t\t\tInforme o nome da Materia-Prima : ");
                nomeMPrima[cont] = Console.ReadLine();
                if (crudCompra.PesquisarMPrima(nomeMPrima[cont]) == true)
                {
                    Console.Write("\t\t\t\t\tInforme o ID da Materia-Prima para confirmar : ");
                    idMPrima[cont] = Console.ReadLine().ToUpper();

                    if (crudCompra.PesquisarMPrimaID(idMPrima[cont]) == false)
                    {
                        Console.WriteLine("\t\t\t\t\tMateria-Prima nao encontrada.");
                        buscar = false;
                    }
                    else
                    {
                        buscar = true;
                    }
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\tMateria-Prima nao encontrada.");
                }



            } while (buscar != true);


            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t-----------------------------------------");
                Console.WriteLine("\t\t\t\t\tInforme o valor unitario da Materia-Prima");
                Console.Write("\t\t\t\t\tValor($$$,$$) (valor precisa ser menor que 1000.00): ");

                if (double.TryParse(Console.ReadLine(), out double confirmar2))
                {
                    valorQuantidade[cont] = confirmar2;
                    
                    
                    if ((valorQuantidade[cont] > 999.99) || (valorQuantidade[cont] <= 0))
                        Console.WriteLine("\t\t\t\t\tValor invalido!");

                }
                else
                {
                    Console.WriteLine("\t\t\t\t\tInforme um valor correto");
                    Console.WriteLine("\t\t\t\t\tPressione uma tecla para voltar");
                    Console.ReadKey();
                }
            } while ((valorQuantidade[cont] > 999.99) || (valorQuantidade[cont] <= 0));
            do
            {
                do
                {
                    do
                    {
                        Console.Write("\t\t\t\t\tInforme a quantidade: ");
                        if (double.TryParse(Console.ReadLine(), out double confirmar1))
                        {
                                quantidade[cont] = confirmar1;
                            
                            totalItem[cont] = (quantidade[cont] * valorQuantidade[cont]);
                            if ((quantidade[cont] > 999.99) || (quantidade[cont] <= 0))
                                Console.WriteLine("\t\t\t\t\tQuantidade incorreta!");
                        }
                        else
                        {
                            Console.WriteLine("\t\t\t\t\tInforme uma quantidade correta");
                            Console.WriteLine("\t\t\t\t\tPressione uma tecla para voltar");
                            Console.ReadKey();
                        }
                    } while ((quantidade[cont] > 999.99) || (quantidade[cont] <= 0));
                } while (TotalItem(valorQuantidade[cont], quantidade[cont]) != true);
                valorTotal = valorTotal + totalItem[cont];
                if (valorTotal > 99999.99)
                {
                    Console.WriteLine("\t\t\t\t\tValor total da compra maior que permitido favor inserir outra quantidade");
                    valorTotalMaior = true;
                }
            } while (valorTotalMaior != false);




            Console.WriteLine("\n\t\t\t\t\tMateria-Prima:\t{0}\n\t\t\t\t\tValor Unitario:\t{1}\n\t\t\t\t\tQuantidade:\t{2}\n\t\t\t\t\tTotal Item:\t{3}", idMPrima[cont], valorQuantidade[cont], quantidade[cont], totalItem[cont]);


            

            cont++;
            if (cont == 3)
            {
                Console.WriteLine("\t\t\t\t\tLimite de Materia-Prima atingido por compra");
                Console.ReadKey();
            }
            else
            {
                Console.Write("\n\t\t\t\t\tDeseja adicionar mais materia-prima (S/N): ");
                saida = Console.ReadLine().ToUpper();
            }

        } while ((saida != "N") & (cont != 3));
        for (int i = 0; i < cont; i++)
        {
            Console.WriteLine("\n\n\t\t\t\t\tMateria-Prima:\t{0}\n\t\t\t\t\tValor Unitario:\t{1}\n\t\t\t\t\tQuantidade:\t{2}\n\t\t\t\t\tTotal Item:\t{3}", idMPrima[i], valorQuantidade[i], quantidade[i], totalItem[i]);
        }
        Console.Write("\n\t\t\t\t\tConfirmar a compra (S/N): ");
        string confirmar = Console.ReadLine().ToUpper();
        if (confirmar == "S")
        {
            Compra compra = new Compra(cnpj, valorTotal);
            crudCompra.InserirCompra(compra);
            double cod = crudCompra.Count();
            for (int i = 0; i < cont; i++)
            {

                ItemCompra itemCompra = new ItemCompra(i, cod, idMPrima[i], quantidade[i], valorQuantidade[i], totalItem[i]);

                crudCompra.InserirItemCompra(itemCompra);
            }
        }
        else
        {
            SubMenu();
        }
        if(confirmar == "N") { SubMenu(); }
    }


    public bool TotalItem(double valor, double quantidade)
    {

        double totalCompra = valor * quantidade;
        if (totalCompra >= 10000)
        {
            Console.WriteLine("\t\t\t\t\tValor ultrapasssou o valor total permetido por compra");
            Console.WriteLine("\t\t\t\t\tFavor informar outra quantidade e outro valor de Materia-Prima");
            Console.WriteLine("\t\t\t\t\tQuantidade disponivel para compra: {0}", 9999 / valor);
            return false;
        }
        else
        { return true; }
    }



}
}

