using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test._5.Models;

namespace Test._5.Repository
{
    public class SqlRepository : ISqlRepository
    {
        public async Task SaveAsync(PlayerModel player)
        {
            using (var context = new PlayerEntities())
            {
                var dbModelEntity = new Player
                {
                    Name = player.Name,
                    Surname = player.Surname,
                    Address = player.Address,
                    Age = player.Age
                };

                context.Players.Add(dbModelEntity);
                await context.SaveChangesAsync();
            }
        }
    }
}
