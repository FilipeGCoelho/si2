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
    
    public partial class Aluguer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aluguer()
        {
            this.Aluguer_Equipamento = new HashSet<Aluguer_Equipamento>();
            this.Aluguer_Promocao = new HashSet<Aluguer_Promocao>();
        }
    
        public int nSerie { get; set; }
        public System.DateTime dataInicio { get; set; }
        public Nullable<System.DateTime> dataFim { get; set; }
        public int tipo { get; set; }
        public decimal preco { get; set; }
        public Nullable<int> nEmpregado { get; set; }
        public Nullable<int> nCliente { get; set; }
        public bool hidden { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Empregado Empregado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aluguer_Equipamento> Aluguer_Equipamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aluguer_Promocao> Aluguer_Promocao { get; set; }
    }
}