using Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var client = new RestClient(baseUrl: "http://localhost:5000/api");
            var requisicao = new RestRequest(resource: "values", Method.POST);

            var carteira = new CarteiraDeClientes();
            carteira.CarteiraId = "1234567890";
            carteira.Clientes = new List<Pessoa> 
            {
                new Juridica 
                { 
                    Id = 1, 
                    Cnpj = "12345678901", 
                    InscricaoEstadual = "123",
                    Address = "Endereço da Empresa",
                    InscricaoMunicipal = "123654",
                    Name = "Empresa Teste"
                },
                new Fisica 
                { 
                    Id = 2, 
                    Cpf = "12345678901", 
                    Rg = "123",
                    Name = "Teste",
                    Address = "Rua do Teste"
                }
            };

            var carteiraJson = JsonConvert.SerializeObject(carteira, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            requisicao.AddJsonBody(carteiraJson);

            var resposta = client.Execute(requisicao);

            Console.WriteLine(resposta.StatusCode);


        }

        private static void Abstracao()
        {
            var a1 = new A1 { Id = 1, Size = 2m };
            var a2 = new A2 { Id = 2, Height = 3m };

            var abs1 = new Abstrata { Object = new List<A> { a1, a2 } };

            var objToJson = JsonConvert.SerializeObject(abs1, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            Console.WriteLine(objToJson);

            var jsonToObj = JsonConvert.DeserializeObject<Abstrata>(objToJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            Console.WriteLine(jsonToObj.Object.ElementAt(1).GetType().Name);
        }

        //public static class IEnumerableExtension
        //{
        //    public static IEnumerable<T> Safe<T>(this IEnumerable<T> source)
        //    {
        //        if (source == null)
        //        {
        //            yield break;
        //        }

        //        foreach (var item in source)
        //        {
        //            yield return item;
        //        }
        //    }
        //}


        class Abstrata
        {
            public IList<A> Object { get; set; }
        }

        abstract class A 
        {
            public int Id { get; set; }
        }
        sealed class A1 : A 
        {
            public decimal Size { get; set; }
        }
        sealed class A2 : A 
        {
            public decimal Height { get; set; }
        }

    }




}
