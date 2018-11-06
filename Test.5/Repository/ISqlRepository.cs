using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test._5.Models;

namespace Test._5.Repository
{
    public interface ISqlRepository
    {
        Task SaveAsync(PlayerModel player);
    }
}
