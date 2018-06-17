using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using M101N.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.IO;

namespace M101N
{
    public class Test
    {
        public Database Db { get; set; }

        private List<string> CodigosUsados { get; set; } = new List<string>();

        public Test(Database db = null, Log log = null)
        {
            Db = db;
        }

        public async Task PrimeiraBateria()
        {
            await Inserir();
            await Find();
            await Update();
            await Delete();
            ExportLogJson();
        }

        private void ExportLogJson()
        {
            var col = Db.Log.GetCollection<BsonDocument>("DotNet");
            var logs = col.Find("{}").ToList();

            using (StreamWriter file = File.CreateText(@".\log.csv"))
            {
                file.WriteLine("Start;End;TimeDifference;Msg;Operation");
                foreach (var log in logs)
                {
                    var start = log.GetValue("Start").ToString();
                    var end = log.GetValue("End").ToString();
                    var timeDifference = log.GetValue("TimeDifference").ToDouble();
                    var msg = log.GetValue("Msg").ToString();
                    var operation = log.GetValue("Operation").ToString();
                    file.WriteLine($"{start};{end};{timeDifference};{msg};{operation}");
                }
          
            }
        }

        public async Task Inserir()
        {
            for (int i = 0; i < 1000; i++)
            {
                // Preparando dado
                var registro = new Registro
                {
                    Codigo = Guid.NewGuid().ToString(),
                    Nome = "Ancalagon",
                    CodigoFiscal = "3356985258"
                };

                CodigosUsados.Add(registro.Codigo);

                var col = Db.Application.GetCollection<Registro>("Registro");
                var inicio = DateTime.Now;

                col.InsertOne(registro);

                var fim = DateTime.Now;

                await Db.RegistrarLog(inicio, fim, $"{i}", "Insert");
            }

        }

        public async Task Find()
        {
            foreach (var codigo in CodigosUsados)
            {
                var col = Db.Application.GetCollection<Registro>("Registro");
                var inicio = DateTime.Now;

                var registro = col.FindSync(e => e.Codigo == codigo).First();

                var fim = DateTime.Now;

                await Db.RegistrarLog(inicio, fim, $"{registro.Codigo}", "Find");
            }

        }
        public async Task Update()
        {
            foreach (var codigo in CodigosUsados)
            {
                var col = Db.Application.GetCollection<Registro>("Registro");
                var inicio = DateTime.Now;

                // var filtro = new BsonDocument("Codigo", codigo);
                // var registro = col.FindSync(e => e.Codigo == codigo).First();
                var registro = col.FindOneAndUpdate(Builders<Registro>.Filter.Eq("Codigo", codigo), Builders<Registro>.Update.Set("Nome", "Alterado"));

                var fim = DateTime.Now;

                await Db.RegistrarLog(inicio, fim, $"{registro.Codigo}", "Update");
            }
        }

        public async Task Delete()
        {
            foreach (var codigo in CodigosUsados)
            {
                var col = Db.Application.GetCollection<Registro>("Registro");
                var inicio = DateTime.Now;

                var registro = col.FindOneAndDelete(e => e.Codigo == codigo);

                var fim = DateTime.Now;

                await Db.RegistrarLog(inicio, fim, $"{registro.Codigo}", "Delete");
            }
        }

    }
}