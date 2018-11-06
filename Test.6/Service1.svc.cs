using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Test._6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<PlayerModel> GetPlayerData()
        {
           using (var context = new Test._5.Repository.PlayerEntities())
            {
                var dbPlayers = context.Players.ToList();

                if (dbPlayers.Any())
                {
                    var playerModelList = new List<PlayerModel>();

                    dbPlayers.ForEach(x =>
                    {
                        playerModelList.Add(new PlayerModel
                        {
                            Name = x.Name,
                            Surname = x.Surname,
                            Address = x.Address,
                            Age = x.Age
                        });
                    });

                    return playerModelList;
                }

                return null;
            }
        }
    }
}
