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
    
    public partial class Aluguer_Equipamento
    {
        public int nSerieAluguer { get; set; }
        public int codigoEquipamento { get; set; }
        public bool hidden { get; set; }
    
        public virtual Aluguer Aluguer { get; set; }
        public virtual Equipamento Equipamento { get; set; }
    }
}
