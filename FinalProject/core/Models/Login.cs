//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace core.Models
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class Login
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string clientCNP { get; set; }
    }
}