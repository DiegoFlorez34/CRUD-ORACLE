using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Models
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Edad { get; set; }

        public string Correo { get; set; }
        public int TipoPersonaId { get; set; }
        public string TipoPersonaNombre { get; set; }
        public int TipoDocumentoId { get; set; }
        public string TipoDocumentoNombre { get; set; }
        public string NumeroDocumento { get; set; }


    }
}