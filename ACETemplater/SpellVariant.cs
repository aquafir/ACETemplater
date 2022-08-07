using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACETemplater
{
    //Fluent variant
    public class SpellVariants
    {
        public List<Spell> Variants = new List<Spell>();
        private List<Spell> spellCollection = new List<Spell>();

        public SpellVariants(List<Spell> spellCollection)
        {
            this.spellCollection = spellCollection;
            Variants = new List<Spell>();
        }
        public void Clear()
        {
            Variants.Clear();
        }
        //Add by id if it exists
        public SpellVariants ByIds(params int[] spellIds)
        {
            foreach (var id in spellIds)
            {
                var spell = spellCollection.Where(s => s.Id == id).FirstOrDefault();
                if (spell is not null && !Variants.Contains(spell))
                    Variants.Add(spell);
                // else
                //     display($"Spell not found with ID: {id}");
            }
            return this;
        }
        //Add by name substring
        public SpellVariants ByNames(params string[] names)
        {
            foreach (var name in names)
            {
                //Split name version
                var split = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var spell = spellCollection.Where(s => split.Any(splitName => s.Name.Contains(splitName, StringComparison.InvariantCultureIgnoreCase))).FirstOrDefault();
                //var spell = spellCollection.Where(s => s.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (spell is not null && !Variants.Contains(spell))
                    Variants.Add(spell);
                // else
                //     display($"Spell not found with name: {name}");
            }
            return this;
        }
        //Find a variant for each damage type
        public SpellVariants ByDamageType(params DamageType[] types)
        {
            var candidates = new List<Spell>();
            foreach (var spell in Variants)
            {
                foreach (var type in types)
                {
                    var candidate = spellCollection.Where(
                        s => s.TypeByCategory != DamageType.Undef
                        && s.TypeByCategory == type
                        && s.IsBehaviorMatch(spell)).FirstOrDefault();
                    if (candidate is not null && !Variants.Contains(candidate))
                    {
                        candidates.Add(candidate);
                    }
                    // else 
                    //     display($"No variant found for {spell.Name} for type {type}");
                }
            }
            Variants.AddRange(candidates);

            return this;
        }
        //Find a variant for each SpellCat
        public SpellVariants BySpellCategory(params SpellCategory[] types)
        {
            var candidates = new List<Spell>();
            foreach (var spell in Variants)
            {
                foreach (var type in types)
                {
                    var candidate = spellCollection.Where(s => 
                        s.Category == type
                        && s.IsBehaviorMatch(spell)).FirstOrDefault();
                    if (candidate is not null && !Variants.Contains(candidate))
                    {
                        candidates.Add(candidate);
                    }
                     //else 
                     //    Console.WriteLine($"No variant found for {spell.Name} for type {type}");
                }
            }
            Variants.AddRange(candidates);

            return this;
        }

        //Find a variant for each level
        public SpellVariants ByLevel(params int[] levels)
        {
            var candidates = new List<Spell>();
            foreach (var spell in Variants)
            {
                foreach (var level in levels)
                {
                    var candidate = spellCollection.Where(
                        s => s.Level == level
                        && s.Category == spell.Category
                        && s.IsBehaviorMatch(spell)).FirstOrDefault();
                    if (candidate is not null && !Variants.Contains(candidate))
                        candidates.Add(candidate);
                    // else 
                    //     display($"No variant found for {spell.Name} for level {level}");
                }
            }
            Variants.AddRange(candidates);

            return this;
        }
        public void Print()
        {
            var sb = new StringBuilder();
            foreach (var spell in Variants.OrderBy(s => s.Level).ThenBy(s => s.Id))
            {
                sb.AppendLine($"{spell.Name,-50}{spell.Level,-4}{spell.Id,-6}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
