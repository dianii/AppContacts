using System;
using System.Collections.Generic;
using System.Text;

namespace AppContacts.Model
{
    using SQLite;
    public class Contact
    {
        #region Propiedad
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Notas { get; set; }
        #endregion
    }
}
