//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AtividadePW2_Relacionamento1_N.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLivro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLivro()
        {
            this.tblEmprestimo = new HashSet<tblEmprestimo>();
        }
    
        public int Id_Livro { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Ano_Publicacao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmprestimo> tblEmprestimo { get; set; }
    }
}