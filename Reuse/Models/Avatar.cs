using System.ComponentModel.DataAnnotations;

namespace Reuse.Models
{
    public class Avatar
    {
        public int avatarID { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int usuarioID { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}