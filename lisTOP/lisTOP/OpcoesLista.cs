using System;
using System.Collections.Generic;
using System.Text;

namespace lisTOP
{
    class OpcoesLista
    {
        public Boolean cafe { get; set; }
        public Boolean almoco { get; set; }
        public Boolean janta { get; set; }
        public Int32 homens { get; set; }
        public Int32 mulheres { get; set; }
        public Int32 criancas { get; set; }

        public Int32 periodo { get; set; }
        public Boolean listaPreDef { get; set; }

        public Lista GerarLista(String nome)
        {
            Lista lista = new Lista();
            lista.nomeLista = nome;
            lista.dataCriacao = DateTime.Now;
            if (listaPreDef)
            {
                lista.compras = new List<Item>();
                Dictionary<Int32, Double> compras = new Dictionary<Int32, Double>();
                foreach(Usuario u in Gambs.usuariosLista)
                {
                    if (cafe)
                    {
                        List<Alimento> alimentos = App.DAUtil.GetAllAlimentosCafe();
                        List<Alimento> alimentosAux = new List<Alimento>();
                        for (int i = 0; i < alimentos.Count; i++)
                        {
                            if (checkRestricoesAlimento(alimentos[i], u) && CheckCategoriaAlimento(alimentos[i], u))
                            {
                                alimentosAux.Add(alimentos[i]);
                            }
                                
                        }

                        if ((u.Mulher && !u.Atleta && u.FaixaEtaria == 3) || (u.FaixaEtaria == 4)){
                            //Bebida 1
                            for(int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Leite"))
                                {
                                    double quant = alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Bebida 2
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Café") || alimentosAux[i].Nome.Contains("Chá") || alimentosAux[i].Nome.Contains("Achocolatado"))
                                {
                                    double quant = 2 * alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Acucar
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Açúcar"))
                                {
                                    double quant = alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Cereais Matinais
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Pães") || alimentosAux[i].Classe.Contains("Bolacha") || alimentosAux[i].Classe.Contains("Cereais Matinais") || alimentosAux[i].Classe.Contains("Bolos"))
                                {
                                    double quant = alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Passa no pão
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Frios") || alimentosAux[i].Nome.Contains("Geleia") || alimentosAux[i].Nome.Contains("Margarina") || alimentosAux[i].Nome.Contains("Manteiga") || alimentosAux[i].Nome.Contains("Requeijão"))
                                {
                                    double quant = alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Fruta
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Frutas") || alimentosAux[i].Nome.Contains("Suco"))
                                {
                                    double quant = 2 * alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                        } else if((u.FaixaEtaria == 1) || (u.Mulher && (u.FaixaEtaria == 2 || (u.FaixaEtaria == 3 && u.Atleta))) || (!u.Mulher && u.FaixaEtaria == 3 && !u.Atleta))
                        {
                            //Bebida 1
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Leite"))
                                {
                                    double quant = alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Bebida 2
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Café") || alimentosAux[i].Nome.Contains("Chá") || alimentosAux[i].Nome.Contains("Achocolatado"))
                                {
                                    double quant = 2 * alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Acucar
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Açúcar"))
                                {
                                    double quant = alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Cereais Matinais
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Pães") || alimentosAux[i].Classe.Contains("Bolacha") || alimentosAux[i].Classe.Contains("Cereais Matinais") || alimentosAux[i].Classe.Contains("Bolos"))
                                {
                                    double quant = alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Passa no pão
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Frios") || alimentosAux[i].Nome.Contains("Geleia") || alimentosAux[i].Nome.Contains("Margarina") || alimentosAux[i].Nome.Contains("Manteiga") || alimentosAux[i].Nome.Contains("Requeijão"))
                                {
                                    double quant = alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Fruta
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Frutas") || alimentosAux[i].Nome.Contains("Suco"))
                                {
                                    double quant = 2 * alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //Bebida 1
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Leite"))
                                {
                                    double quant = alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Bebida 2
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Café") || alimentosAux[i].Nome.Contains("Chá") || alimentosAux[i].Nome.Contains("Achocolatado"))
                                {
                                    double quant = 2 * alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Acucar
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Açúcar"))
                                {
                                    double quant = alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Cereais Matinais
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Pães") || alimentosAux[i].Classe.Contains("Bolacha") || alimentosAux[i].Classe.Contains("Cereais Matinais") || alimentosAux[i].Classe.Contains("Bolos"))
                                {
                                    double quant = alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Passa no pão
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Frios") || alimentosAux[i].Nome.Contains("Geleia") || alimentosAux[i].Nome.Contains("Margarina") || alimentosAux[i].Nome.Contains("Manteiga") || alimentosAux[i].Nome.Contains("Requeijão"))
                                {
                                    double quant = alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Fruta
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Frutas") || alimentosAux[i].Nome.Contains("Suco"))
                                {
                                    double quant = 2 * alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                        }
                    }if(almoco || janta)
                    {
                        int count = (almoco ? 1 : 0) + (janta ? 1 : 0);

                        List<Alimento> alimentos = App.DAUtil.GetAllAlimentosAlmocoJanta();
                        List<Alimento> alimentosAux = new List<Alimento>();
                        for (int i = 0; i < alimentos.Count; i++)
                        {
                            if (checkRestricoesAlimento(alimentos[i], u) && CheckCategoriaAlimento(alimentos[i], u))
                            {
                                alimentosAux.Add(alimentos[i]);
                            }

                        }

                        if ((u.Mulher && !u.Atleta && u.FaixaEtaria == 3) || (u.FaixaEtaria == 4))
                        {
                            bool massas = false;
                            //Principal
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Arroz") || alimentosAux[i].Classe.Contains("Massas"))
                                {
                                    if (alimentosAux[i].Classe.Contains("Massas"))
                                        massas = true;
                                    double quant = count * alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Secundario
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Feijão") || alimentosAux[i].Nome.Contains("Ervilha") || alimentosAux[i].Nome.Contains("Grão de Bico") || alimentosAux[i].Nome.Contains("Lentilha") || (massas && alimentosAux[i].Nome.Contains("Queijo Ralado")))
                                {
                                    double quant = count * alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Oleo
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Óleo") || alimentosAux[i].Nome.Contains("Azeite"))
                                {
                                    double quant = count * alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Verde Almoco
                            if (almoco)
                            {
                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("hortaliças") || alimentosAux[i].Classe.Contains("Legumes"))
                                    {
                                        double quant = count * alimentosAux[i].Quantidade1600;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        break;
                                    }
                                }
                            }
                            //verde jantar
                            if (janta)
                            {
                                int c = 0;
                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("hortaliças"))
                                    {
                                        double quant = alimentosAux[i].Quantidade1600;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        c++;
                                        if(c>=2)
                                            break;
                                    }
                                }

                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("Legumes"))
                                    {
                                        double quant = alimentosAux[i].Quantidade1600;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        break;
                                    }
                                }
                            }
                            //Mistura
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Peixes") || alimentosAux[i].Nome.Contains("PVT") || alimentosAux[i].Classe.Contains("embutidos") || alimentosAux[i].Classe.Contains("aves") || alimentosAux[i].Classe.Contains("ovos") || alimentosAux[i].Classe.Contains("Frutos do Mar") || alimentosAux[i].Classe.Contains("carne"))
                                {
                                    double quant = count * alimentosAux[i].Quantidade1600;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                        }
                        else if ((u.FaixaEtaria == 1) || (u.Mulher && (u.FaixaEtaria == 2 || (u.FaixaEtaria == 3 && u.Atleta))) || (!u.Mulher && u.FaixaEtaria == 3 && !u.Atleta))
                        {
                            bool massas = false;
                            //Principal
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Arroz") || alimentosAux[i].Classe.Contains("Massas"))
                                {
                                    if (alimentosAux[i].Classe.Contains("Massas"))
                                        massas = true;
                                    double quant = count * alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Secundario
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Feijão") || alimentosAux[i].Nome.Contains("Ervilha") || alimentosAux[i].Nome.Contains("Grão de Bico") || alimentosAux[i].Nome.Contains("Lentilha") || (massas && alimentosAux[i].Nome.Contains("Queijo Ralado")))
                                {
                                    double quant = count * alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Oleo
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Óleo") || alimentosAux[i].Nome.Contains("Azeite"))
                                {
                                    double quant = count * alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Verde Almoco
                            if (almoco)
                            {
                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("hortaliças") || alimentosAux[i].Classe.Contains("Legumes"))
                                    {
                                        double quant = count * alimentosAux[i].Quantidade2200;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        break;
                                    }
                                }
                            }
                            //verde jantar
                            if (janta)
                            {
                                int c = 0;
                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("hortaliças"))
                                    {
                                        double quant = alimentosAux[i].Quantidade2200;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        c++;
                                        if (c >= 2)
                                            break;
                                    }
                                }

                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("Legumes"))
                                    {
                                        double quant = alimentosAux[i].Quantidade2200;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        break;
                                    }
                                }
                            }
                            //Mistura
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Peixes") || alimentosAux[i].Nome.Contains("PVT") || alimentosAux[i].Classe.Contains("embutidos") || alimentosAux[i].Classe.Contains("aves") || alimentosAux[i].Classe.Contains("ovos") || alimentosAux[i].Classe.Contains("Frutos do Mar") || alimentosAux[i].Classe.Contains("carne"))
                                {
                                    double quant = count * alimentosAux[i].Quantidade2200;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            bool massas = false;
                            //Principal
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Arroz") || alimentosAux[i].Classe.Contains("Massas"))
                                {
                                    if (alimentosAux[i].Classe.Contains("Massas"))
                                        massas = true;
                                    double quant = count * alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Secundario
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Feijão") || alimentosAux[i].Nome.Contains("Ervilha") || alimentosAux[i].Nome.Contains("Grão de Bico") || alimentosAux[i].Nome.Contains("Lentilha") || (massas && alimentosAux[i].Nome.Contains("Queijo Ralado")))
                                {
                                    double quant = count * alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Oleo
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Nome.Contains("Óleo") || alimentosAux[i].Nome.Contains("Azeite"))
                                {
                                    double quant = count * alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                            //Verde Almoco
                            if (almoco)
                            {
                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("hortaliças") || alimentosAux[i].Classe.Contains("Legumes"))
                                    {
                                        double quant = count * alimentosAux[i].Quantidade2800;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        break;
                                    }
                                }
                            }
                            //verde jantar
                            if (janta)
                            {
                                int c = 0;
                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("hortaliças"))
                                    {
                                        double quant = alimentosAux[i].Quantidade2800;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        c++;
                                        if (c >= 2)
                                            break;
                                    }
                                }

                                for (int i = 0; i < alimentosAux.Count; i++)
                                {
                                    if (alimentosAux[i].Classe.Contains("Legumes"))
                                    {
                                        double quant = alimentosAux[i].Quantidade2800;
                                        if (compras.ContainsKey(alimentosAux[i].Id))
                                        {
                                            compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                        }
                                        else
                                        {
                                            compras.Add(alimentosAux[i].Id, quant);
                                        }
                                        break;
                                    }
                                }
                            }
                            //Mistura
                            for (int i = 0; i < alimentosAux.Count; i++)
                            {
                                if (alimentosAux[i].Classe.Contains("Peixes") || alimentosAux[i].Nome.Contains("PVT") || alimentosAux[i].Classe.Contains("embutidos") || alimentosAux[i].Classe.Contains("aves") || alimentosAux[i].Classe.Contains("ovos") || alimentosAux[i].Classe.Contains("Frutos do Mar") || alimentosAux[i].Classe.Contains("carne"))
                                {
                                    double quant = count * alimentosAux[i].Quantidade2800;
                                    if (compras.ContainsKey(alimentosAux[i].Id))
                                    {
                                        compras[alimentosAux[i].Id] = compras[alimentosAux[i].Id] + quant;
                                    }
                                    else
                                    {
                                        compras.Add(alimentosAux[i].Id, quant);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                foreach(Int32 key in compras.Keys)
                {
                    Alimento a = App.DAUtil.GetAllAlimentos(key)[0];
                    double quant = compras[key];
                    int contador = (int)(quant / a.QuantidadeMinima);
                    quant = (quant > (double)(a.QuantidadeMinima * contador)) ? a.QuantidadeMinima * contador + 1 : quant;

                    Item i = new Item(a.Nome, quant, a.UnidadeMedida, a.Classe, a.Id);
                    lista.compras.Add(i);
                }

            }
            else
            {
                lista.compras = new List<Item>();
            }

            return lista;
        }

        public bool checkRestricoesAlimento(Alimento a, Usuario u)
        {
            if (u.Amendoim && a.Amendoim)
                return false;
            if (u.Carboidrato && a.Carboidrato)
                return false;
            if (u.Glutem && a.Gluten)
                return false;
            if (u.Lactose && a.Lactose)
                return false;
            if (u.Ovo && a.Ovo)
                return false;
            if (u.Proteina && a.Proteina)
                return false;
            if (u.Soja && a.Soja)
                return false;
            if (u.Vegano && !a.Vegana)
                return false;
            if (u.Vegetariano && !a.Vegetariana)
                return false;


            return true;
        }

        public bool CheckCategoriaAlimento(Alimento a, Usuario u)
        {
            if (!u.Achocolatado && a.Classe.Equals("Achocolatado", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Aves && a.Classe.Equals("aves", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Bolos && a.Classe.Equals("Bolos", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Cafe && a.Classe.Equals("Café", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.CarneBovina && a.Classe.Equals("carne bovina", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.CarneSuina && a.Classe.Equals("carne suína", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Cereais && a.Classe.Equals("Cereais", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.CereaisMatinais && a.Classe.Equals("Cereais Matinais", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Chas && a.Classe.Equals("Chás", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Embutidos && a.Classe.Equals("embutidos", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Especiarias && a.Classe.Equals("Especiarias", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Frios && a.Classe.Equals("Frios", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Frutas && a.Classe.Equals("Frutas", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.FrutosDoMar && a.Classe.Equals("Frutos do Mar", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Graos && a.Classe.Equals("Grãos", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Guloseimas && a.Classe.Equals("Guloseimas", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Hortalica && a.Classe.Equals("hortaliças", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Iogurte && a.Nome.Equals("Iogurte", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Legumes && a.Classe.Equals("Legumes", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Leite && a.Nome.Contains("Leite"))
                return false;
            if (!u.Massas && a.Classe.Equals("Massas", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Ovo && a.Classe.Equals("ovos", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Paes && a.Classe.Equals("Pães", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Peixes && a.Classe.Equals("Peixes", StringComparison.CurrentCultureIgnoreCase))
                return false;
            if (!u.Suco && a.Nome.Contains("Suco"))
                return false;

            return true;
        }
    }
}
