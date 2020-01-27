using ProdutoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ProdutoMVC.Repository
{
    public class ProdutoRepository
    {

        string stringconn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Produto> GetProductsList()
        {
            List<Produto> prods = new List<Produto>();

            using (var connection = new SqlConnection(stringconn))
            {
                var commandText = "select * from Produto";

                SqlCommand selectCommand = new SqlCommand(commandText, connection);

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var produto = new Produto();

                            produto.Id = (int)reader["Id"];
                            produto.Nome = reader["Nome_Produto"].ToString();
                            produto.Fabricante = reader["Fabricante"].ToString();
                            produto.CodigoBarras = reader["CodigoBarras"].ToString();
                            produto.Preco = (decimal)reader["Preco"];
                            produto.Estoque = (int)reader["Estoque"];

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


        public void CreateProduct(int Id,
          string NomeProduto, 
          string Fabricante,
	      string CodigoBarras,
          decimal Preco,
          int Estoque)
        {

            
            
        
        }

        public void UpdateProduct(int id) { }

        public void DeleteProduct(int id) { }

        public void GetProductById(int id) { }
    }
}
