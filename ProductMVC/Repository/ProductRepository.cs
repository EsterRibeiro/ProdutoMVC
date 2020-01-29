using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMVC.Repository
{
    public class ProductRepository
    {
        //string de conexão
        string stringconn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Product> GetProductsList()
        {
            //instância dos produtos
            List<Product> prods = new List<Product>();

            //usando a string de conexão para os seguintes procedimentos
            using (var connection = new SqlConnection(stringconn))
            {
                //query
                var commandText = "select * from Produtos";

                //ligando o comando da query a conexão
                SqlCommand selectCommand = new SqlCommand(commandText, connection);

                try
                {
                    //abrindo a conexão
                    connection.Open();

                    //lendo todas as informações do banco 
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        //enquanto tiver 
                        while (reader.Read())
                        {
                            var produto = new Product();

                            produto.Id = (int)reader["Id"];
                            produto.Nome = reader["Nome_Produto"].ToString();
                            produto.Fabricante = reader["Fabricante"].ToString();
                            produto.CodigoBarras = reader["CodigoBarras"].ToString();
                            produto.Preco = (decimal)reader["Preco"];
                            produto.Estoque = (int)reader["Estoque"];

                            //adicionando a lista do banco na variável do tipo lista
                            prods.Add(produto);
                        }

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

            }

            return prods;

        }

        /// <summary>
        /// Cria os produtos
        /// </summary>
        /// <param name="prod"></param>
        public void CreateProduct(Product prod)
        {


            //usando a string de conexão
            using (var connection = new SqlConnection(stringconn))
            {
                //nonquery
                var query = "insert into Produtos(Nome_Produto, Fabricante, CodigoBarras, Preco, Estoque)" +
                    " values(@Nome_Produto, @Fabricante, @CodigoBarras, @Preco, @Estoque)";

                //ligando a conexão com o comando
                SqlCommand command = new SqlCommand(query, connection);

                //adicionando os novos valores ao banco
                command.CommandType = new CommandType();

                command.Parameters.AddWithValue("@Nome_Produto", prod.Nome);
                command.Parameters.AddWithValue("@Fabricante", prod.Fabricante);
                command.Parameters.AddWithValue("@CodigoBarras", prod.CodigoBarras);
                command.Parameters.AddWithValue("@Preco", prod.Preco);
                command.Parameters.AddWithValue("@Estoque", prod.Estoque);



                try
                {
                    //abre a conexão e executa
                    connection.Open();
                    command.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //fecha a conexão
                    connection.Close();
                }


            }


        }

        /// <summary>
        /// Altera os produtos
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            using (var connection = new SqlConnection(stringconn))
            {
                string query = "UPDATE Produto " +
                    "set Nome_Produto = @Nome_Produto, Fabricante = @Fabricante, CodigoBarras = @CodigoBarras, Preco = @Preco, Estoque = @Estoque";

                SqlCommand command = new SqlCommand(query, connection);

                command.CommandType = new CommandType();

                command.Parameters.AddWithValue("@Nome_Produto", prod.Nome);
                command.Parameters.AddWithValue("@Fabricante", prod.Fabricante);
                command.Parameters.AddWithValue("@CodigoBarras", prod.Fabricante);
                command.Parameters.AddWithValue("@Preco", prod.Preco);
                command.Parameters.AddWithValue("@Estoque", prod.Estoque);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }


        }

        /// <summary>
        /// Deleta os produtos (Delete)
        /// </summary>
        /// <param name="prod"></param>
        public void DeleteProduct(Product prod)
        {
            using (var connection = new SqlConnection(stringconn))
            {
                string query = "DELETE FROM Produtos WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", prod.Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    connection.Close();
                }



            }
        }

        /// <summary>
        /// Detalhamento de produtos (details)
        /// </summary>
        /// <param name="prod"></param>
        public Product GetProductById(int id)
        {

            using (var connection = new SqlConnection(stringconn))
            {
                //@NomeCampoBanco - Sempre que invoca-lo, é preciso identificar nos parâmetros
                 string query = "SELECT Id, Nome_Produto, Fabricante, CodigoBarras, Preco, Estoque" +
                        " FROM Produtos WHERE Id=@Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                Product prod = null;

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            //Enquanto houver valores a serem lidos
                            if (reader.Read())
                            {
                                prod = new Product();
                                prod.Id = (int)reader["Id"];
                                prod.Nome = reader["Nome_Produto"].ToString();
                                prod.Fabricante = reader["Fabricante"].ToString();
                                prod.CodigoBarras = reader["CodigoBarras"].ToString();
                                prod.Preco = (decimal)reader["Preco"];
                                prod.Estoque = (int)reader["Estoque"];

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return prod;
            }


        }


    }

}
    




