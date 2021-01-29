using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace OAK.Models.Edited
{
    public class SectionEditedModel
    {
        public long? Id { get; set; } = null;

        public long? Parent { get; set; } = null;

        [Required(ErrorMessage = "Дайте название ветви!")]
        [MaxLength(32, ErrorMessage = "Не больше 32 символов!")]
        public string Name { get; set; } = "";


        public void FromSection(Section section)
        {
            Id = section.Id;
            Parent = section.Idparent;
            Name = section.Name;
        }

        public void ToSection(ref Section section, Section parent, Autor autor)
        {
            section.Name = Name;
            section.IdparentNavigation = parent;
            section.IdautorNavigation = autor;
        }

        static public bool HaveSection(Autor autor, Section section)
            => autor.Sections.Contains(section);

        public bool IsUnique(ICollection<Section> sections)
            => !sections.Any(s => s.Name == Name && s.Idparent == Parent);

        public bool IsCorrect(Section parent)
            => (Parent != Id && Name != parent?.Name) || Parent == null;
    }
}
