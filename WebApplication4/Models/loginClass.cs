using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace amabisca.modelsAux
{   
    public class loginClass
    {
        //[Required]
        public string Contrasenia { get; set; }
        //[Required]
        public string CorreoElectronico { get; set; }
        //[Required]
        public int CodUsuario { get; set; }
        //[Required]
        public string PrimerNombre { get; set; }
        //[Required]
        public string PrimerApellido { get; set; }
        //[Required]
        public string Telefono { get; set; }
       // [Required]
        public string Direccion { get; set; }
       // [Required]
        public int? CodGeneo { get; set; }
        }
}
