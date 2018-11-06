using System.Collections.Generic;
using System.Linq;
using Web.App.Test.Models;

namespace Web.App.Test.Repository.SQL
{
    public class Player : IPlayer
    {
        public IReadOnlyCollection<PlayerModel> Get()
        {
            using (var context = new PlayerContext())
            {
                return context.Player.ToList();
            }
        }
    }
}
