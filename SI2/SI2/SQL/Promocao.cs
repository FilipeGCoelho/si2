//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SI2.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promocao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promocao()
        {
            this.Aluguer_Promocao = new HashSet<Aluguer_Promocao>();
        }
    
        public int id { get; set; }
        public System.DateTime dataInicio { get; set; }
        public System.DateTime dataFim { get; set; }
        public string descricao { get; set; }
        public string tipo { get; set; }
        public bool hidden { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aluguer_Promocao> Aluguer_Promocao { get; set; }
    }
}