using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            Id = section.ID;
            Parent = section.ParentID;
            Name = section.Name;
        }

        public void ToSection(ref Section section, Section parent, Autor autor)
        {
            section.Name = Name;
            section.Parent = parent;
            section.Autor = autor;
        }

        static public bool HaveSection(Autor autor, Section section)
            => autor.Sections.Contains(section);

        public bool IsUnique(ICollection<Section> sections)
            => !sections.Any(s => s.Name == Name && s.ParentID == Parent);

        public bool IsCorrect(Section parent)
            => (Parent != Id && Name != parent?.Name) || Parent == null;

        public void RemoveChildren(List<Section> sections)
        {
            sections.RemoveAll(s => s.ID == Id);

            Section[] gCurr;
            List<Section> gNext = sections.Where(s => s.ParentID == Id).ToList();

            while (gNext.Count != 0)
            {
                gCurr = gNext.ToArray();
                gNext.Clear();
                for (int i = 0; i < gCurr.Length; i++)
                {
                    sections.Remove(gCurr[i]);
                    gNext.AddRange(sections.Where(s => s.ParentID == gCurr[i].ID));
                }
            }
        }
    }
}