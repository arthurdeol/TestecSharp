using CSharpTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpTest.DAL
{
    public interface IVeiculosDAL
    {
        IEnumerable<Veiculo> GetAllVeiculos();
        IEnumerable<Veiculo> GetFiltraVeiculo(string chassi);
        void AddVeiculo(Veiculo veiculo);
        int UpdateVeiculo(Veiculo veiculo);
        Veiculo GetVeiculo(int id);
        void DeleteVeiculo(int id);
    }
}
