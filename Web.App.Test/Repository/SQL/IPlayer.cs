using System.Collections.Generic;
using Web.App.Test.Models;

namespace Web.App.Test.Repository.SQL
{
    public interface IPlayer
    {
        IReadOnlyCollection<PlayerModel> Get();
    }
}
