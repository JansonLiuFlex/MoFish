using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoFish.Core.Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity : ViewModelBase
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
