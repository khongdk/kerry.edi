//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kerry.K35Syn.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AIRROUTE
    {
        public int SNO { get; set; }
        public string TPTMODE { get; set; }
        public string ORIGINCITY { get; set; }
        public string ORIGINCTRY { get; set; }
        public string DESTCITY { get; set; }
        public string DESTCTRY { get; set; }
        public string CARRIERCODE { get; set; }
        public string FLTNO { get; set; }
        public Nullable<System.DateTime> ETDDATE { get; set; }
        public string ETDTIME { get; set; }
        public Nullable<System.DateTime> ETADATE { get; set; }
        public string ETATIME { get; set; }
        public Nullable<System.DateTime> ATDDATE { get; set; }
        public string ATDTIME { get; set; }
        public Nullable<System.DateTime> ATADATE { get; set; }
        public string ATATIME { get; set; }
        public string VESSELNAME { get; set; }
        public string VOYAGE { get; set; }
        public long JOB_UNID { get; set; }
        public Nullable<long> AIRFLTSCHEDULE_UNID { get; set; }
        public string SPACEALLOCCODE { get; set; }
        public string SCHEDCARRIERCODE { get; set; }
        public string SCHEDFLTNO { get; set; }
        public Nullable<System.DateTime> SCHEDFLTDATE { get; set; }
        public string SCHEDFLTTIME { get; set; }
        public string SCHEDDESTCTRY { get; set; }
        public string SCHEDDESTCITY { get; set; }
    
        public virtual JOB JOB { get; set; }
    }
}
