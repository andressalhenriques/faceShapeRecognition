using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics
{
    class UsuariosDAO
    {
        RostoDAO rostoDAO = new RostoDAO();

        public int Id_Usuario { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public int Id_Rosto;
        public int id_Rosto
        {
            set
            {
                Id_Rosto = rostoDAO.Id_Rosto;
            }
            get
            {
                return Id_Rosto;
            }
        }

        
    }
}
