using Spell = ACETemplater.Spell;

//Load a ACE spells
var spellTable = @"spells.csv";

List<Spell> spellCollection;
using (var reader = new StreamReader(spellTable))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    spellCollection = csv.GetRecords<Spell>().ToList();
}

//Example of getting rid of non-player castable spells using the spelltable (copied over to Helpers)?  Could use another one for easily learnable spells
spellCollection.RemoveAll(x => !Helpers.PlayerSpellTable.Contains(x.Id));

//Set up using the collection of spells, used as candidates for a variant of a spell
var variants = new SpellVariants(spellCollection);
//First match of spells with those names (split on spaces) --> those spells plus similar spells of level 6, 7, 8 --> versions for each basic damage type
variants.ByNames("fire prot sel", "fire prot oth").ByLevel(6, 7, 8).ByDamageType(Spell.BASIC_TYPES);
//Print if you want to see the variants that were found
variants.Print();
//Clear the variant collection to start again
variants.Clear();
//Example of getting variants by category, Str self  --> melee / end
variants.ByIds(2).BySpellCategory(SpellCategory.MeleeDefenseRaising, SpellCategory.EnduranceRaising).ByLevel(1, 2, 3);
variants.Print();

//Get variants of Flame Bolt I for basic damage types then for each of those a variant for all levels
variants.Clear();
variants.ByIds(27).ByDamageType(Spell.BASIC_TYPES).ByLevel(1, 2, 3, 4, 5, 6, 7, 8);

//Get a weenie template you want to make variants of, some alchemy phial
var templatePath = @"C:\ACE\Content\json\weenies\81068 - Empowered Platinum Phial of Blade Vulnerability.json";
if (!Helpers.TryLoadTemplate(templatePath, out var template)) {
    Console.WriteLine($"Failed to load weenie from: {templatePath}");
    return;
}

//Loop through saving new weenies based on the spell variants
uint startId = 800000;
foreach (var variation in variants.Variants)
{
    //Grab the level from spell level to use for scaling other things
    var level = variation.Level;

    //WCID
    template.WeenieClassId = startId++; //Set to next ID

    //INTs
    template.PropertiesInt[PropertyInt.ItemSpellcraft] = 300 + 30 * level;
    template.PropertiesInt[PropertyInt.WieldDifficulty] = 300 + 30 * level;
    template.PropertiesInt[PropertyInt.Value] = 1000 * level;
    //Damage/Damage Type vs in spell?
    template.PropertiesInt[PropertyInt.Damage] = 5 * level;
    template.PropertiesInt[PropertyInt.DamageType] = (int)variation.DamageType; //Take the damage type from spell

    //DID
    template.PropertiesDID[PropertyDataId.ProcSpell] = variation.Id; //Set the spell
    //Not sure what would be a good way to set the icon?  Some bg based on the damage type?
    template.PropertiesDID[PropertyDataId.Icon] = variation.IconID;

    //STRING
    //Name -- Empowered Platinum Phial of Blade Vulnerability
    //LongDescription -- An Empowered Platinum Phial, filled with an alchemical mixture designed to temporarily weaken the slashing resistance of those coated in the fluid.
    //Plural Name -- Empowered Platinum Phials of Blade Vulnerability    
    var name = $"{variation.Name} in a Bottle";
    template.PropertiesString[PropertyString.Name] = name;
    template.PropertiesString[PropertyString.LongDesc] = $"The spell {variation.Name} trapped in a bottle with alchemy.";
    template.PropertiesString[PropertyString.PluralName] = $"Bottled {variation.Name}";

    var jsonPath = $"{template.WeenieClassId} - {name}.json";
    Console.WriteLine($"Creating weenie: {jsonPath}");
    Helpers.SaveWeenie(jsonPath, template);

    //Create a rending version? Quick enum hack
    template.WeenieClassId = startId++; //Set to next ID
    template.PropertiesInt[PropertyInt.ImbuedEffect] = (int)Helpers.ParseRend(variation.DamageType);

    name = $"Rending {variation.Name} in a Bottle";
    template.PropertiesString[PropertyString.Name] = name;
    template.PropertiesString[PropertyString.LongDesc] = $"The spell {variation.Name} trapped and empowered in a bottle with alchemy.";
    template.PropertiesString[PropertyString.PluralName] = $"Bottled Rending {variation.Name}";

    jsonPath = $"{template.WeenieClassId} - {name}.json";
    Console.WriteLine($"Creating weenie: {jsonPath}");
    Helpers.SaveWeenie(jsonPath, template);

    //Remove the rend before moving back to the non-rend version since you're not making a new copy of the template each time
    template.PropertiesInt.Remove(PropertyInt.ImbuedEffect);
}