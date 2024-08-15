using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entities
{
    //EF Supports 4 ways for mapping classes to database [tables/views]
    //الكلاس دا كدا اسمو poco class[Plain Old CLR Object] عشان معندهوش اي فانكشن فيه بروبيرتي بس 
    internal class Employee
    {
        #region 1- By Convention [Default Behaviour]
        //public int Id { get; set; }
        // public numeric (int-double-decimal) property named [Id , اسم الكلاس + Id] =>PK with identity (1,1)
        //public string? EmpName { get; set; }
        //reference type : allow null [optional] => .net 5.0
        //reference type : not allow null [required] => .net 6.0
        //nullable string : allow null [optional] => .net 6.0
        //كل دا بتحولو ل nvarchar(max)
        //public decimal Salary { get; set; }
        //value type : not allow null [required] عشان دي ديسيمال بتخليها decimal(18,2)=> بنستخدمها لل validation
        //public int? Age { get; set; }
        //nullable <int> : allow null[optional] هتخليها int
        #endregion
        #region 2- Data Annotation
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//(1,1)
        public int EmpId { get; set; }

        [Required]//frontend
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string? EmpName { get; set; }

        [Column(TypeName = "Money")]
        //[DataType(DataType.Currency)]//هي هي 
        public decimal Salary { get; set; }

        [Range(22, 50)]//frontend
        public int? Age { get; set; }

        [EmailAddress]//بتبان ف ال front
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Phone]//بتبان ف ال front
        public string Phone { get; set; }

        [DataType(DataType.Password)]//بتبان ف ال front
        public string Password { get; set; }

        #endregion
        #region 3- Fluent api


        #endregion
    }
}
