//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjCMS.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class cAdmin
    {
        public int cId { get; set; }

        [DisplayName("User ID")]
        [Required]
        public string cUserId { get; set; }

        [DisplayName("Password")]
        [Required]
        public string cPwd { get; set; }

        [DisplayName("User Name")]
        [Required]
        public string cName { get; set; }
    }
}
