//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwcLmsMastery.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assignment
    {
        public Assignment()
        {
            this.RosterAssignments = new HashSet<RosterAssignment>();
        }
    
        public int AssignmentId { get; set; }
        public int CourseId { get; set; }
        public string AssignmentName { get; set; }
        public int PossiblePoints { get; set; }
        public System.DateTime DueDate { get; set; }
        public string AssignmentDescription { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual ICollection<RosterAssignment> RosterAssignments { get; set; }
    }
}
