//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.Base.Common.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SYS_Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Organization()
        {
            this.SYS_ModuleParam = new HashSet<SYS_ModuleParam>();
            this.SYS_Organization1 = new HashSet<SYS_Organization>();
            this.SYS_OrgMerger = new HashSet<SYS_OrgMerger>();
            this.SYS_OrgMember = new HashSet<SYS_OrgMember>();
            this.SYS_OrgMerger1 = new HashSet<SYS_OrgMerger>();
            this.SYS_Role_Title = new HashSet<SYS_Role_Title>();
            this.SYS_RolePerm_DataAbs = new HashSet<SYS_RolePerm_DataAbs>();
            this.SYS_Allot_Record = new HashSet<SYS_Allot_Record>();
            this.SYS_Code_Allot = new HashSet<SYS_Code_Allot>();
            this.SYS_Code_Scheme = new HashSet<SYS_Code_Scheme>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public int NodeType { get; set; }
        public int Index { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string FullName { get; set; }
        public Nullable<System.Guid> PositionId { get; set; }
        public bool Validity { get; set; }
        public System.Guid CreatorUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_ModuleParam> SYS_ModuleParam { get; set; }
        public virtual SYS_User SYS_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Organization> SYS_Organization1 { get; set; }
        public virtual SYS_Organization SYS_Organization2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_OrgMerger> SYS_OrgMerger { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_OrgMember> SYS_OrgMember { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_OrgMerger> SYS_OrgMerger1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Role_Title> SYS_Role_Title { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_RolePerm_DataAbs> SYS_RolePerm_DataAbs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Allot_Record> SYS_Allot_Record { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Code_Allot> SYS_Code_Allot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Code_Scheme> SYS_Code_Scheme { get; set; }
    }
}
