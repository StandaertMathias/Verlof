using System;
using System.Collections.Generic;

namespace Verlof.Data
{
    public partial class Aanvragen
    {
        public int Id { get; set; }
        public string NaamAanvrager { get; set; }
        public DateTime Datum { get; set; }
        public string MotivatieAanvraag { get; set; }
        public string StatusAanvraag { get; set; }
        public string NaamManager { get; set; }
        public string MotivatieManager { get; set; }
    }
}
