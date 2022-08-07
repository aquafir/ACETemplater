using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACETemplater
{
    public class Spell
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Power { get; set; }
        public int BaseIntensity { get; set; }
        public int Variance { get; set; }
        public int BaseMana { get; set; }
        public float BaseRangeConstant { get; set; }
        public float BaseRangeMod { get; set; }
        public int Boost { get; set; }
        public int BoostVariance { get; set; }
        public int MaxBoost { get; set; }
        public SpellCategory Category { get; set; }
        public float ComponentLoss { get; set; }
        public double CritFrequency { get; set; }
        public double CritMultiplier { get; set; }
        public float DamageRatio { get; set; }
        public DamageType DamageType { get; set; }
        public PropertyAttribute2nd Destination { get; set; }
        public double DotDuration { get; set; }
        public double Duration { get; set; }
        public double ElementalModifier { get; set; }
        public float GetDamagePerTick { get; set; }
        public int GetNumTicks { get; set; }
        public uint IconID { get; set; }
        public bool IsBeneficial { get; set; }
        public bool IsFellowshipSpell { get; set; }
        public bool IsHarmful { get; set; }
        public bool IsImpenBaneType { get; set; }
        public bool IsNegativeRedirectable { get; set; }
        public bool IsOtherNegativeRedirectable { get; set; }
        public bool IsPortalSpell { get; set; }
        public bool IsProjectile { get; set; }
        public bool IsResistable { get; set; }
        public bool IsSelfTargeted { get; set; }
        public bool IsTracking { get; set; }
        public float LossPercent { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public MagicSchool DispelSchool { get; set; }
        public int Number { get; set; }
        public float NumberVariance { get; set; }
        public int MinPower { get; set; }
        public int MaxPower { get; set; }
        public float PowerVariance { get; set; }
        public SpellType MetaSpellType { get; set; }
        public ItemType NonComponentTargetType { get; set; }
        public bool NotFound { get; set; }
        public int NumProjectiles { get; set; }
        public int NumProjectilesVariance { get; set; }
        public double PortalLifetime { get; set; }
        public string Position { get; set; }    //public Position Position {get; set;}
        public int PowerMod { get; set; }
        public float Proportion { get; set; }
        public float RecoveryAmount { get; set; }
        public double RecoveryInterval { get; set; }
        public MagicSchool School { get; set; }
        public CreatureType SlayerCreatureType { get; set; }
        public float SlayerDamageBonus { get; set; }
        public PropertyAttribute2nd Source { get; set; }
        public int SourceLoss { get; set; }
        public float SpellEconomyMod { get; set; }
        public float SpreadAngle { get; set; }
        public int StatModKey { get; set; }
        public EnchantmentTypeFlags StatModType { get; set; }
        public float StatModVal { get; set; }
        public PlayScript TargetEffect { get; set; }
        public PlayScript FizzleEffect { get; set; }
        public PlayScript CasterEffect { get; set; }
        public int TransferCap { get; set; }
        public TransferFlags TransferFlags { get; set; }
        public List<PropertyAttribute2nd> UpdatesMaxVitals { get; set; }
        public bool UpdatesRunRate { get; set; }
        public DamageType VitalDamageType { get; set; }
        //public string Wcid {get; set;}
        public int WeenieClassId { get; set; }

        //Helpers
        public static DamageType[] BASIC_TYPES = {
        DamageType.Acid,
        DamageType.Bludgeon,
        DamageType.Cold,
        DamageType.Electric,
        DamageType.Fire,
        DamageType.Pierce,
        DamageType.Slash,
        };
        public bool IsBasicDamage { get => BASIC_TYPES.Contains(this.DamageType); }
        //Infer the buff or damaging element by the category name?
        public DamageType TypeByCategory
        {
            get
            {
                if (School == MagicSchool.CreatureEnchantment || School == MagicSchool.None) return DamageType.Undef;
                var categoryString = Category.ToString();
                if (categoryString.StartsWith("Acid")) return DamageType.Acid;
                if (categoryString.StartsWith("Cold") || categoryString.StartsWith("Frost")) return DamageType.Cold;
                if (categoryString.StartsWith("Fire") || categoryString.StartsWith("Flame")) return DamageType.Fire;
                if (categoryString.StartsWith("Electric") || categoryString.StartsWith("Lightning")) return DamageType.Electric;
                if (categoryString.StartsWith("Bludgeon")) return DamageType.Bludgeon;
                if (categoryString.StartsWith("Slash")) return DamageType.Slash;
                if (categoryString.StartsWith("Pierc") || categoryString.StartsWith("Force")) return DamageType.Pierce;
                if (categoryString.StartsWith("Nether")) return DamageType.Nether;
                if (categoryString.StartsWith("Acid")) return DamageType.Acid;
                if (categoryString.StartsWith("Acid")) return DamageType.Acid;
                if (categoryString.StartsWith("Heal")) return DamageType.Health;
                if (categoryString.StartsWith("Mana")) return DamageType.Mana;
                if (categoryString.StartsWith("Stamina")) return DamageType.Stamina;
                return DamageType.Undef;
            }
        }

        //Todo: come up with a better heuristic for if a spell is "like" another spell
        //EnchantmentTypeFlags is a flag for things like mult vs additive, int vs float
        //Excessive check that the templates line up?
        public bool IsBehaviorMatch(Spell spell) =>
        !spell.IsPortalSpell &&
        spell.NumProjectiles == this.NumProjectiles &&
        spell.IsFellowshipSpell == this.IsFellowshipSpell &&
        spell.IsResistable == this.IsResistable &&
        spell.IsSelfTargeted == this.IsSelfTargeted &&
        spell.IsHarmful == this.IsHarmful &&
        spell.IsImpenBaneType == this.IsImpenBaneType &&
        spell.IsNegativeRedirectable == this.IsNegativeRedirectable &&
        spell.IsProjectile == this.IsProjectile &&
        spell.IsBeneficial == this.IsBeneficial &&
        spell.IsTracking == this.IsTracking &&
        spell.MetaSpellType == this.MetaSpellType;
    }
}
