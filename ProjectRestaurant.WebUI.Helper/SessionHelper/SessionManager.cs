using ProjectRestaurant.Entity.DTO.LoginDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Helper.SessionHelper
{
    public class SessionManager
    {
        public static LoginDTOResponse? loginDTOResponse
        {
            get => AppHttpContext.Current.Session.GetObject<LoginDTOResponse>("LoginDTOResponse");
            set => AppHttpContext.Current.Session.SetObject("LoginDTOResponse", value);
        }
    }
}
