using CSharpTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpTest.DAL
{
    public class VeiculosDAL : IVeiculosDAL
    {
        public VeiculosDAL() { }
        private readonly AppDbContext db;
        public VeiculosDAL(AppDbContext context)
        {
            db = context;
        }

        public IEnumerable<Veiculo> GetAllVeiculos()
        {
            try
            {
                return db.Veiculos.ToList();
            }
            catch { throw; }
        }

        public IEnumerable<Veiculo> GetFiltraVeiculo(string chassi)
        {
            List<Veiculo> veic = new List<Veiculo>();
            try
            {
                veic = GetAllVeiculos().ToList();
                return veic.Where(x => x.Chassi.IndexOf(chassi, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch { throw; }
        }

        public void AddVeiculo(Veiculo veiculo)
        {
            try
            {
                db.Veiculos.Add(veiculo);
                db.SaveChanges();
            }
            catch { throw; }
        }

        public int UpdateVeiculo(Veiculo veiculo)
        {
            try
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch { throw; }
        }

        public Veiculo GetVeiculo(int id)
        {
            try
            {
                Veiculo veiculo = db.Veiculos.Find(id);
                return veiculo;
            }
            catch { throw; }
        }

        public void DeleteVeiculo(int id)
        {
            try
            {
                Veiculo veic = db.Veiculos.Find(id);
                db.Veiculos.Remove(veic);
                db.SaveChanges();
            }
            catch { throw; }
        }
    }
}
