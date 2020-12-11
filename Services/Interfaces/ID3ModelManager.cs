using PBLSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLSecurity.Services
{
    public interface ID3ModelManager
    {
        public string Get3DmodelBytes();
        public List<RoomStatusModel> GetRoomStatus(int userID);
    }
}
