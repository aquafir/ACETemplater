﻿namespace ACETemplater
{
    public static class Helpers
    {
        //This wasn't implemented in ACE yet.  Eventually will try to push it, but until then conversion from Entity weenies to DB weenies included here:
        public static ACE.Database.Models.World.Weenie ConvertFromEntityWeenie(ACE.Entity.Models.Weenie weenie)
        {
            var result = new ACE.Database.Models.World.Weenie();

            result.ClassId = weenie.WeenieClassId;
            result.ClassName = weenie.ClassName;
            result.Type = (int)weenie.WeenieType;

            if (weenie.PropertiesBool != null)
            {
                result.WeeniePropertiesBool = new List<WeeniePropertiesBool>();
                foreach (var value in weenie.PropertiesBool)
                {
                    result.WeeniePropertiesBool.Add(new WeeniePropertiesBool { Value = value.Value, Type = (ushort)value.Key });
                }
            }
            if (weenie.PropertiesDID != null)
            {
                result.WeeniePropertiesDID = new List<WeeniePropertiesDID>();
                foreach (var value in weenie.PropertiesDID)
                {

                    result.WeeniePropertiesDID.Add(new WeeniePropertiesDID { Value = Convert.ToUInt32(value.Value), Type = (ushort)value.Key });
                }
            }
            if (weenie.PropertiesFloat != null)
            {
                result.WeeniePropertiesFloat = new List<WeeniePropertiesFloat>();
                foreach (var value in weenie.PropertiesFloat)
                {

                    result.WeeniePropertiesFloat.Add(new WeeniePropertiesFloat { Value = value.Value, Type = (ushort)value.Key });
                }
            }
            if (weenie.PropertiesIID != null)
            {
                result.WeeniePropertiesIID = new List<WeeniePropertiesIID>();
                foreach (var value in weenie.PropertiesIID)
                {

                    result.WeeniePropertiesIID.Add(new WeeniePropertiesIID { Value = value.Value, Type = (ushort)value.Key });
                }
            }
            if (weenie.PropertiesInt != null)
            {
                result.WeeniePropertiesInt = new List<WeeniePropertiesInt>();
                foreach (var value in weenie.PropertiesInt)
                {

                    result.WeeniePropertiesInt.Add(new WeeniePropertiesInt { Value = value.Value, Type = (ushort)value.Key });
                }
            }
            if (weenie.PropertiesInt64 != null)
            {
                result.WeeniePropertiesInt64 = new List<WeeniePropertiesInt64>();
                foreach (var value in weenie.PropertiesInt64)
                {

                    result.WeeniePropertiesInt64.Add(new WeeniePropertiesInt64 { Value = value.Value, Type = (ushort)value.Key });
                }
            }
            if (weenie.PropertiesInt64 != null)
            {
                result.WeeniePropertiesInt64 = new List<WeeniePropertiesInt64>();
                foreach (var value in weenie.PropertiesInt64)
                {

                    result.WeeniePropertiesInt64.Add(new WeeniePropertiesInt64 { Value = value.Value, Type = (ushort)value.Key });
                }
            }
            if (weenie.PropertiesString != null)
            {
                result.WeeniePropertiesString = new List<WeeniePropertiesString>();
                foreach (var value in weenie.PropertiesString)
                {

                    result.WeeniePropertiesString.Add(new WeeniePropertiesString { Value = value.Value, Type = (ushort)value.Key });
                }
            }

            //TODO: Verify some of these less simple ones properties
            if (weenie.PropertiesPosition != null && weenie.PropertiesPosition.Count > 0)
            {
                result.WeeniePropertiesPosition = new List<WeeniePropertiesPosition>();
                foreach (var value in weenie.PropertiesPosition)
                {
                    result.WeeniePropertiesPosition.Add(
                        new WeeniePropertiesPosition
                        {
                            PositionType = (ushort)value.Key,
                            ObjCellId = value.Value.ObjCellId,
                            OriginX = value.Value.PositionX,
                            OriginY = value.Value.PositionY,
                            OriginZ = value.Value.PositionZ,
                            AnglesW = value.Value.RotationW,
                            AnglesX = value.Value.RotationX,
                            AnglesY = value.Value.RotationY,
                            AnglesZ = value.Value.RotationZ
                        }
                    );
                }
            }

            if (weenie.PropertiesSpellBook != null)
            {
                result.WeeniePropertiesSpellBook = new List<WeeniePropertiesSpellBook>();
                foreach (var value in weenie.PropertiesSpellBook)
                {
                    result.WeeniePropertiesSpellBook.Add(
                        new WeeniePropertiesSpellBook
                        {
                            Spell = value.Key,
                            Probability = value.Value
                        });
                }
            }

            if (weenie.PropertiesAnimPart != null)
            {
                result.WeeniePropertiesAnimPart = new List<WeeniePropertiesAnimPart>();
                foreach (var value in weenie.PropertiesAnimPart)
                {
                    result.WeeniePropertiesAnimPart.Add(
                        new WeeniePropertiesAnimPart
                        {
                            Index = value.Index,
                            AnimationId = value.AnimationId
                        });
                }
            }

            if (weenie.PropertiesPalette != null)
            {
                result.WeeniePropertiesPalette = new List<WeeniePropertiesPalette>();
                foreach (var value in weenie.PropertiesPalette)
                {
                    result.WeeniePropertiesPalette.Add(
                        new WeeniePropertiesPalette
                        {
                            SubPaletteId = value.SubPaletteId,
                            Offset = value.Offset,
                            Length = value.Length
                        });
                }
            }

            if (weenie.PropertiesTextureMap != null)
            {
                result.WeeniePropertiesTextureMap = new List<WeeniePropertiesTextureMap>();
                foreach (var value in weenie.PropertiesTextureMap)
                {
                    result.WeeniePropertiesTextureMap.Add(
                        new WeeniePropertiesTextureMap
                        {
                            Index = value.PartIndex,
                            OldId = value.OldTexture,
                            NewId = value.NewTexture
                        });
                }
            }

            // Properties for all world objects that typically aren't modified over the original weenie
            if (weenie.PropertiesCreateList != null)
            {
                result.WeeniePropertiesCreateList = new List<WeeniePropertiesCreateList>();
                foreach (var value in weenie.PropertiesCreateList)
                {
                    result.WeeniePropertiesCreateList.Add(
                        new WeeniePropertiesCreateList
                        {
                            DestinationType = (sbyte)value.DestinationType,
                            WeenieClassId = value.WeenieClassId,
                            StackSize = value.StackSize,
                            Palette = value.Palette,
                            Shade = value.Shade,
                            TryToBond = value.TryToBond
                        });
                }
            }

            if (weenie.PropertiesEmote != null)
            {
                result.WeeniePropertiesEmote = new List<WeeniePropertiesEmote>();
                foreach (var value in weenie.PropertiesEmote)
                {
                    var entity1 = new WeeniePropertiesEmote
                    {
                        Category = (uint)value.Category,
                        Probability = value.Probability,
                        WeenieClassId = value.WeenieClassId,
                        Style = (uint?)value.Style,
                        Substyle = (uint?)value.Substyle,
                        Quest = value.Quest,
                        VendorType = (int?)value.VendorType,
                        MinHealth = value.MinHealth,
                        MaxHealth = value.MaxHealth
                    };

                    //Assume correct order and keep count to preserve?
                    uint order = 0;
                    foreach (var record2 in value.PropertiesEmoteAction)
                    {
                        var entity2 = new WeeniePropertiesEmoteAction()
                        {
                            Order = order++,
                            Type = (uint)record2.Type,
                            Delay = record2.Delay,
                            Extent = record2.Extent,
                            Motion = (uint?)record2.Motion,
                            Message = record2.Message,
                            TestString = record2.TestString,
                            Min = record2.Min,
                            Max = record2.Max,
                            Min64 = record2.Min64,
                            Max64 = record2.Max64,
                            MinDbl = record2.MinDbl,
                            MaxDbl = record2.MaxDbl,
                            Stat = record2.Stat,
                            Display = record2.Display,
                            Amount = record2.Amount,
                            Amount64 = record2.Amount64,
                            HeroXP64 = record2.HeroXP64,
                            Percent = record2.Percent,
                            SpellId = record2.SpellId,
                            WealthRating = record2.WealthRating,
                            TreasureClass = record2.TreasureClass,
                            TreasureType = record2.TreasureType,
                            PScript = (int?)record2.PScript,
                            Sound = (int?)record2.Sound,
                            DestinationType = record2.DestinationType,
                            WeenieClassId = record2.WeenieClassId,
                            StackSize = record2.StackSize,
                            Palette = record2.Palette,
                            Shade = record2.Shade,
                            TryToBond = record2.TryToBond,
                            ObjCellId = record2.ObjCellId,
                            OriginX = record2.OriginX,
                            OriginY = record2.OriginY,
                            OriginZ = record2.OriginZ,
                            AnglesW = record2.AnglesW,
                            AnglesX = record2.AnglesX,
                            AnglesY = record2.AnglesY,
                            AnglesZ = record2.AnglesZ,
                        };
                        entity1.WeeniePropertiesEmoteAction.Add(entity2);
                    }

                    result.WeeniePropertiesEmote.Add(entity1);
                }
            }

            if (weenie.PropertiesEventFilter != null)
            {
                result.WeeniePropertiesEventFilter = new List<WeeniePropertiesEventFilter>();
                foreach (var value in weenie.PropertiesEventFilter)
                {
                    result.WeeniePropertiesEventFilter.Add(
                        new WeeniePropertiesEventFilter
                        {
                            Event = value
                        });
                }
            }

            if (weenie.PropertiesGenerator != null)
            {
                result.WeeniePropertiesGenerator = new List<WeeniePropertiesGenerator>();
                foreach (var value in weenie.PropertiesGenerator)
                {
                    result.WeeniePropertiesGenerator.Add(
                        new WeeniePropertiesGenerator
                        {
                            Probability = value.Probability,
                            WeenieClassId = value.WeenieClassId,
                            Delay = value.Delay,
                            InitCreate = value.InitCreate,
                            MaxCreate = value.MaxCreate,
                            WhenCreate = (uint)value.WhenCreate,
                            WhereCreate = (uint)value.WhereCreate,
                            StackSize = value.StackSize,
                            PaletteId = value.PaletteId,
                            Shade = value.Shade,
                            ObjCellId = value.ObjCellId,
                            OriginX = value.OriginX,
                            OriginY = value.OriginY,
                            OriginZ = value.OriginZ,
                            AnglesW = value.AnglesW,
                            AnglesX = value.AnglesX,
                            AnglesY = value.AnglesY,
                            AnglesZ = value.AnglesZ
                        });
                }
            }

            // Properties for creatures
            if (weenie.PropertiesAttribute != null)
            {
                result.WeeniePropertiesAttribute = new List<WeeniePropertiesAttribute>();
                foreach (var value in weenie.PropertiesAttribute)
                {
                    result.WeeniePropertiesAttribute.Add(
                        new WeeniePropertiesAttribute
                        {
                            Type = (ushort)value.Key,
                            InitLevel = value.Value.InitLevel,
                            LevelFromCP = value.Value.LevelFromCP,
                            CPSpent = value.Value.CPSpent
                        });
                }
            }

            if (weenie.PropertiesAttribute2nd != null)
            {
                result.WeeniePropertiesAttribute2nd = new List<WeeniePropertiesAttribute2nd>();
                foreach (var value in weenie.PropertiesAttribute2nd)
                {
                    result.WeeniePropertiesAttribute2nd.Add(
                        new WeeniePropertiesAttribute2nd
                        {
                            Type = (ushort)value.Key,
                            InitLevel = value.Value.InitLevel,
                            LevelFromCP = value.Value.LevelFromCP,
                            CPSpent = value.Value.CPSpent
                        });
                }
            }

            if (weenie.PropertiesBodyPart != null)
            {
                result.WeeniePropertiesBodyPart = new List<WeeniePropertiesBodyPart>();
                foreach (var value in weenie.PropertiesBodyPart)
                {
                    result.WeeniePropertiesBodyPart.Add(
                        new WeeniePropertiesBodyPart
                        {
                            DType = (ushort)value.Key,
                            DVal = value.Value.DVal,
                            DVar = value.Value.DVar,
                            BaseArmor = value.Value.BaseArmor,
                            ArmorVsSlash = value.Value.ArmorVsSlash,
                            ArmorVsPierce = value.Value.ArmorVsPierce,
                            ArmorVsBludgeon = value.Value.ArmorVsBludgeon,
                            ArmorVsCold = value.Value.ArmorVsCold,
                            ArmorVsFire = value.Value.ArmorVsFire,
                            ArmorVsAcid = value.Value.ArmorVsAcid,
                            ArmorVsElectric = value.Value.ArmorVsElectric,
                            ArmorVsNether = value.Value.ArmorVsNether,
                            BH = value.Value.BH,
                            HLF = value.Value.HLF,
                            MLF = value.Value.MLF,
                            LLF = value.Value.LLF,
                            HRF = value.Value.HRF,
                            MRF = value.Value.MRF,
                            LRF = value.Value.LRF,
                            HLB = value.Value.HLB,
                            MLB = value.Value.MLB,
                            LLB = value.Value.LLB,
                            HRB = value.Value.HRB,
                            MRB = value.Value.MRB,
                            LRB = value.Value.LRB
                        });
                }
            }

            if (weenie.PropertiesSkill != null)
            {
                result.WeeniePropertiesSkill = new List<WeeniePropertiesSkill>();
                foreach (var value in weenie.PropertiesSkill)
                {
                    result.WeeniePropertiesSkill.Add(
                        new WeeniePropertiesSkill
                        {
                            Type = (ushort)value.Key,
                            LevelFromPP = value.Value.LevelFromPP,
                            SAC = (uint)value.Value.SAC,
                            PP = value.Value.PP,
                            InitLevel = value.Value.InitLevel,
                            ResistanceAtLastCheck = value.Value.ResistanceAtLastCheck,
                            LastUsedTime = value.Value.LastUsedTime,
                        });
                }
            }

            // Properties for books
            if (weenie.PropertiesBook != null)
            {
                result.WeeniePropertiesBook = new WeeniePropertiesBook
                {
                    MaxNumCharsPerPage = weenie.PropertiesBook.MaxNumCharsPerPage,
                    MaxNumPages = weenie.PropertiesBook.MaxNumPages
                };
            }

            if (weenie.PropertiesBookPageData != null)
            {
                result.WeeniePropertiesBookPageData = new List<WeeniePropertiesBookPageData>();

                //TODO: Assume page ID is correct and starts at 0?
                uint pageId = 0;
                foreach (var value in weenie.PropertiesBookPageData)
                {
                    result.WeeniePropertiesBookPageData.Add(
                        new WeeniePropertiesBookPageData
                        {
                            PageId = pageId++,
                            AuthorId = value.AuthorId,
                            AuthorName = value.AuthorName,
                            AuthorAccount = value.AuthorAccount,
                            IgnoreAuthor = value.IgnoreAuthor,
                            PageText = value.PageText,
                        });
                }
            }

            return result;
        }

        public static bool TryLoadTemplate(string templatePath, out ACE.Entity.Models.Weenie template)
        {
            template = null;

            //Requires something different based on content type
            if (!LifestonedLoader.TryLoadWeenie(templatePath, out var lsWeenie))
            {
                Console.WriteLine("Error loading template from: " + templatePath);
                return false;
            }
            if (!LifestonedConverter.TryConvert(lsWeenie, out var dbWeenie))
            {
                Console.WriteLine("Error converting template");
                return false;
            }

            template = WeenieConverter.ConvertToEntityWeenie(dbWeenie);

            //Load a recipe
            // if(!LifestonedLoader.TryLoadRecipe(template, out var lsRecipeWeenie)) {
            //     Console.WriteLine("Error loading recipe template from: " + template);
            //     return;
            // }
            // if(!LifestonedConverter.TryConvert(lsRecipeWeenie, out var dbRecipeWeenie)) {
            //     Console.WriteLine("Error converting template");4
            //     return;
            // }
            // var recipeWeenie = WeenieConverter.ConvertToEntityWeenie(dbRecipeWeenie);

            return true;
        }

        ///Helpers
        //Saves a ACE.Database.Models.World.Weenie
        public static void SaveWeenie(string path, ACE.Entity.Models.Weenie weenie)
        {
            var dbWeenie = Helpers.ConvertFromEntityWeenie(weenie);

            if (!LifestonedConverter.TryConvertACEWeenieToLSDJSON(dbWeenie, out var json, out var json_weenie))
            {
                Console.WriteLine($"Failed to convert {dbWeenie.ClassId} - {dbWeenie.ClassName} to json");
                return;
            }

            File.WriteAllText(path, json);
        }

        public static ImbuedEffectType ParseRend(DamageType type) => type switch
        {
            DamageType.Acid => ImbuedEffectType.AcidRending,
            DamageType.Bludgeon => ImbuedEffectType.BludgeonRending,
            DamageType.Cold => ImbuedEffectType.ColdRending,
            DamageType.Electric => ImbuedEffectType.ElectricRending,
            DamageType.Fire => ImbuedEffectType.FireRending,
            DamageType.Pierce => ImbuedEffectType.PierceRending,
            DamageType.Slash => ImbuedEffectType.SlashRending,
            _ => throw new ArgumentException("Unable to convert damage type fo rend"),
        };


        public static uint[] PlayerSpellTable = {
            1,2,3,5,6,7,8,9,15,16,17,18,19,20,21,22,23,24,25,26,27,28,35,36,37,38,47,48,49,
            50,51,53,54,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,99,
            100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,
            150,151,152,153,154,157,158,159,160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,176,178,179,180,181,182,183,184,185,186,187,188,189,190,191,192,193,194,195,196,197,198,199,
            203,204,205,206,207,208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,227,228,229,230,231,232,233,234,235,236,237,238,239,240,241,242,243,244,245,246,247,248,249,
            250,251,252,253,254,255,256,257,258,259,260,261,262,263,264,265,266,267,268,269,270,271,272,273,274,275,276,277,278,279,280,281,282,283,284,285,290,291,292,293,294,295,296,297,298,299,
            300,301,302,303,304,305,306,307,308,309,310,315,316,317,318,319,320,321,322,323,324,325,326,327,328,329,330,331,332,333,337,339,340,341,342,343,344,345,346,347,348,349,
            350,351,352,353,354,355,356,357,364,365,366,367,368,369,370,371,372,373,374,375,376,377,378,379,380,381,388,389,390,391,392,393,394,395,396,397,398,399,
            400,401,402,403,404,405,412,413,414,415,416,417,418,419,420,421,422,423,424,425,426,427,428,429,433,436,437,438,439,440,441,442,443,444,445,446,447,448,449,
            450,451,452,453,454,461,462,463,464,465,466,467,468,469,470,471,472,473,474,475,476,477,478,479,482,483,484,485,486,487,488,489,490,491,492,493,494,495,496,497,498,499,
            500,501,502,509,510,511,512,513,514,515,516,517,518,519,520,521,522,523,524,525,526,527,528,529,530,531,532,533,534,535,536,537,538,539,540,541,542,543,544,545,546,547,548,549,
            550,557,558,559,560,561,562,563,564,565,566,567,568,569,570,571,572,573,574,577,578,580,581,582,583,584,585,586,587,588,589,590,591,592,593,594,595,596,597,598,
            604,605,606,607,608,609,610,611,612,613,614,615,616,622,623,624,625,626,627,628,629,630,631,632,633,634,635,636,637,638,639,640,646,647,648,649,
            650,651,652,653,654,655,656,657,658,659,660,661,662,663,664,671,672,673,674,675,676,677,678,679,680,681,682,683,684,685,686,687,688,689,691,692,694,695,696,697,698,699,
            700,701,702,703,704,705,706,707,708,709,710,711,712,713,719,720,721,722,723,724,725,726,727,728,729,730,731,732,733,734,735,736,737,743,744,745,746,747,748,749,
            750,751,752,753,754,755,756,757,758,759,760,761,767,768,769,770,771,772,773,774,775,776,777,778,779,780,781,782,783,784,785,791,792,793,794,795,796,797,798,799,
            800,801,802,803,804,805,806,807,808,809,810,811,812,813,814,815,816,817,818,819,820,821,822,824,825,826,827,828,829,830,831,832,833,834,835,836,842,843,844,845,846,847,848,849,
            850,851,852,853,854,855,856,857,858,859,860,861,867,868,869,870,871,872,873,874,875,876,877,878,879,880,881,882,883,884,885,891,892,893,894,895,896,897,898,899,
            900,901,902,903,904,905,906,907,908,909,910,914,915,916,917,918,919,920,921,922,923,924,925,926,927,928,929,930,931,932,933,939,940,941,942,943,944,945,946,947,948,949,
            950,951,952,953,954,955,956,957,958,962,963,964,965,966,967,968,969,970,971,972,973,974,975,976,977,978,979,980,981,982,983,984,985,986,987,988,989,990,991,992,993,998,999,
            1000,1001,1002,1003,1004,1005,1006,1007,1009,1011,1012,1013,1014,1015,1016,1017,1018,1019,1020,1021,1022,1023,1024,1025,1026,1027,1028,1029,1030,1031,1032,1033,1034,1035,1036,1037,1038,1039,1040,1041,1043,1044,1045,1046,1047,1048,1049,
            1050,1051,1052,1053,1055,1056,1057,1058,1059,1060,1061,1062,1063,1064,1065,1066,1067,1068,1069,1070,1071,1072,1073,1074,1075,1076,1077,1078,1079,1080,1081,1082,1083,1084,1085,1086,1087,1088,1089,1090,1091,1092,1093,1094,1095,1096,1097,
            1100,1101,1102,1104,1105,1106,1107,1108,1109,1110,1111,1112,1113,1114,1115,1116,1117,1118,1119,1120,1121,1122,1123,1124,1125,1126,1127,1128,1129,1130,1131,1132,1133,1134,1135,1136,1137,1138,1139,1140,1141,1142,1143,1144,1145,1146,1148,1149,
            1150,1151,1152,1153,1154,1155,1156,1157,1158,1159,1160,1161,1162,1163,1164,1165,1166,1167,1168,1169,1170,1171,1172,1173,1174,1175,1176,1177,1178,1179,1180,1181,1182,1183,1184,1185,1186,1187,1188,1189,1190,1191,1192,1193,1194,1195,1196,1197,1198,1199,
            1200,1201,1202,1203,1204,1205,1206,1207,1208,1209,1210,1211,1212,1213,1214,1215,1216,1217,1218,1219,1220,1221,1222,1223,1224,1225,1226,1227,1228,1229,1230,1237,1238,1239,1240,1241,1242,1243,1244,1245,1246,1247,1248,1249,
            1250,1251,1252,1253,1254,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1272,1273,1274,1275,1276,1277,1278,1279,1280,1290,1291,1292,1293,1294,1295,1296,1297,1298,1299,
            1300,1301,1308,1309,1310,1311,1312,1313,1314,1315,1316,1317,1318,1319,1320,1321,1322,1323,1324,1325,1326,1327,1328,1329,1330,1331,1332,1333,1334,1335,1336,1337,1339,1340,1341,1342,1343,1344,1345,1348,1349,
            1350,1351,1352,1353,1354,1355,1356,1357,1358,1359,1360,1362,1366,1367,1368,1369,1370,1371,1372,1373,1374,1375,1376,1377,1378,1379,1380,1381,1382,1383,1384,1385,1388,1389,1390,1391,1392,1393,1394,1395,1396,1397,1398,1399,
            1400,1401,1402,1403,1404,1405,1406,1407,1408,1411,1412,1413,1414,1415,1416,1417,1418,1419,1420,1421,1422,1423,1424,1425,1426,1427,1428,1429,1430,1431,1432,1437,1438,1439,1440,1441,1442,1443,1444,1445,1446,1447,1448,1449,
            1450,1451,1452,1453,1454,1455,1456,1458,1459,1461,1463,1464,1465,1466,1467,1468,1469,1470,1471,1472,1473,1474,1475,1476,1477,1478,1479,1480,1481,1482,1483,1484,1485,1486,1487,1488,1489,1490,1491,1492,1493,1494,1495,1496,1497,1498,1499,
            1500,1501,1502,1503,1504,1505,1506,1507,1508,1509,1510,1511,1512,1513,1514,1515,1516,1517,1518,1519,1520,1521,1522,1523,1524,1525,1526,1527,1528,1529,1530,1531,1532,1533,1534,1535,1536,1537,1538,1539,1540,1541,1542,1543,1544,1545,1546,1547,1548,1549,
            1550,1551,1552,1553,1554,1555,1556,1557,1558,1559,1560,1561,1562,1563,1564,1565,1566,1567,1568,1569,1570,1571,1572,1573,1574,1575,1576,1577,1578,1579,1580,1581,1582,1583,1584,1585,1586,1587,1588,1589,1590,1591,1592,1593,1594,1595,1596,1597,1598,1599,
            1601,1602,1603,1604,1605,1606,1607,1608,1609,1610,1611,1612,1613,1614,1615,1616,1617,1618,1619,1620,1621,1623,1624,1625,1626,1627,1629,1630,1631,1632,1633,1635,1636,1637,1639,1640,1643,1644,
            1664,1665,1666,1667,1668,1669,1676,1677,1678,1679,1680,1681,
            1702,1703,1704,1709,1710,1711,1712,1713,1714,1715,1716,1717,1718,1719,1720,1721,1722,1723,1724,1725,1726,1727,1730,1731,1732,1733,1734,1735,1736,1737,1738,1739,1740,1741,1742,1743,1744,1745,1746,1747,1748,1749,
            1750,1751,1756,1757,1758,1759,1760,1761,1762,1763,1764,1765,1766,1767,1768,1769,1770,1771,1772,1773,1774,1777,1778,1779,1780,1781,1782,1783,1784,1785,1786,1787,1788,1789,1790,1791,1792,1793,1794,1795,1796,1797,1798,1799,
            1800,1801,1802,1803,1804,1805,1806,1807,1808,1809,1810,1811,1812,1813,1814,1815,1816,1817,1818,1819,1820,1821,1822,1823,1824,1825,1826,1827,1828,1829,1830,1831,1832,1833,1834,1835,1836,1837,1838,1839,1840,1841,1842,1843,1844,1845,1846,
            1876,1882,1883,1884,1885,1886,1887,1888,1889,1890,1891,1892,1893,1894,1895,1896,1897,1898,1899,
            1900,1901,1902,1903,1904,1905,1906,1907,1908,1909,1910,1911,1912,1913,1914,1915,1916,1917,1918,1919,1920,1921,1922,1923,1924,1925,1926,1927,1928,1929,1930,1931,1932,1933,1934,1935,1936,1937,1938,1939,1940,1941,1942,1943,1944,1945,1946,1947,1948,1949,
            1950,1951,1952,1953,1954,1955,1956,1957,1958,1959,1960,1961,1962,1963,1964,1965,1966,1967,1968,1969,1970,1971,1972,1973,1974,1975,1976,1977,1978,1979,1980,1981,1982,1983,1984,1985,1986,1987,1988,1989,1990,1991,1997,1999,
            2001,2002,2003,2004,2005,2007,2008,2009,2011,2012,2013,2014,2015,2016,2023,2040,2041,
            2052,2053,2054,2056,2058,2059,2060,2061,2062,2064,2066,2067,2068,2070,2072,2073,2074,2075,2076,2077,2078,2080,2081,2082,2083,2084,2086,2087,2088,2090,2091,2092,2093,2094,2095,2096,2097,2098,2099,
            2100,2101,2102,2103,2104,2105,2106,2107,2108,2109,2110,2111,2112,2113,2114,2115,2116,2117,2118,2119,2120,2121,2122,2123,2124,2125,2126,2127,2128,2129,2130,2131,2132,2133,2134,2135,2136,2137,2138,2139,2140,2141,2142,2143,2144,2145,2146,2147,2148,2149,
            2150,2151,2152,2153,2154,2155,2156,2157,2158,2159,2160,2161,2162,2164,2166,2168,2170,2172,2174,2176,2177,2178,2179,2180,2182,2183,2184,2185,2186,2187,2188,2190,2191,2192,2194,2195,2196,2197,2198,
            2200,2202,2203,2204,2206,2207,2208,2210,2211,2212,2214,2215,2216,2218,2219,2220,2222,2223,2224,2226,2227,2228,2230,2232,2233,2234,2236,2237,2238,2240,2241,2242,2243,2244,2245,2246,2248,2249,
            2250,2251,2252,2254,2256,2257,2258,2259,2260,2262,2263,2264,2266,2267,2268,2270,2271,2272,2274,2275,2276,2277,2278,2280,2281,2282,2283,2284,2285,2286,2287,2288,2289,2290,2291,2292,2293,2294,2295,2296,2298,2299,
            2300,2301,2302,2304,2305,2306,2308,2309,2310,2312,2313,2314,2315,2316,2317,2318,2320,2322,2323,2324,2325,2326,2328,2329,2330,2332,2334,2335,2336,2337,2339,2341,2343,2345,2346,2347,2348,2349,
            2350,2351,2352,2353,2354,2355,2356,2358,2376,2377,2378,2379,2380,2381,2382,2383,2384,2385,2386,2387,2388,2389,2390,2391,2392,2393,2396,2397,2398,2399,
            2411,2415,2416,2417,2419,2421,2423,2426,2428,2432,2433,2434,2435,2436,2438,2439,2441,2442,2444,2445,2446,2447,2448,2449,
            2450,2451,2452,2453,2454,2456,2459,2460,2471,2472,2474,2475,2483,2486,2487,2488,
            2501,2502,2503,2504,2505,2506,2507,2508,2509,2510,2511,2512,2513,2514,2515,2516,2517,2518,2519,2520,2521,2522,2523,2524,2525,2526,2527,2528,2529,2530,2531,2532,2533,2534,2535,2536,2537,2538,2539,2540,2541,2542,2543,2544,2545,2546,2547,2548,2549,
            2550,2551,2552,2553,2554,2555,2556,2558,2559,2560,2561,2562,2563,2564,2565,2566,2567,2568,2569,2570,2571,2572,2573,2574,2575,2576,2577,2578,2579,2580,2581,2582,2583,2584,2585,2586,2587,2588,2589,2590,2591,2592,2593,2594,2595,2596,2597,2598,2599,
            2600,2601,2602,2603,2604,2605,2606,2607,2608,2609,2610,2611,2612,2613,2614,2615,2616,2617,2618,2619,2620,2621,2622,2623,2624,2625,2626,2627,2628,2629,2630,2637,2638,2639,2640,2642,2643,2644,2645,2646,2647,2648,2649,
            2650,2659,2660,2661,2662,2663,2664,2665,2666,2667,2668,2669,2671,2686,2687,2689,2691,2694,
            2711,2712,2713,2714,2715,2716,2717,2718,2719,2720,2721,2722,2723,2724,2725,2726,2727,2728,2729,2730,2731,2732,2733,2734,2735,2736,2737,2738,2739,2740,2741,2742,2743,2744,2745,2746,2747,2748,2749,
            2750,2751,2752,2753,2754,2755,2756,2757,2758,2759,2760,2761,2762,2763,2764,2765,2766,2767,2768,2769,2770,2771,2772,2773,2774,2775,2776,2777,2778,2779,2780,2781,2782,2783,2785,
            2809,2810,2811,2812,2813,2814,
            2928,2929,2930,2931,2932,2933,2934,2936,2937,2938,2941,2942,2943,2946,2948,2949,
            2950,2951,2959,2960,2961,2962,2969,2970,2975,2979,2980,2985,2986,2987,2999,
            3002,3008,3009,3010,3012,3013,3014,3015,3034,3035,3048,3049,
            3050,3052,3068,3071,3093,3094,
            3154,
            3155,3156,3157,3158,3159,3160,3161,3162,3163,3164,3165,3166,3167,3168,3169,3170,3171,3172,3173,3174,3175,3176,3177,3178,3179,3180,3184,3185,3186,3187,3188,3189,3190,3191,3192,3193,3194,3195,3196,3197,3198,3199,
            3200,3203,3204,3205,3206,3207,3208,3209,3223,3237,3238,3239,3240,3243,
            3250,3251,3253,3254,3255,3256,3257,3258,3259,3260,3261,3262,3263,3264,3265,3266,
            3308,3311,3312,3313,3320,3321,3322,3323,3324,3325,3326,3327,3328,3329,3330,3331,3332,3333,3334,3335,3336,3337,3338,3339,3340,3341,3342,3343,3344,3345,3346,3347,3348,3349,
            3350,3351,3352,3353,3354,3355,3356,3357,3358,3359,3361,3362,3363,3364,3365,3366,3367,3368,3369,3370,3371,3378,3384,3385,3386,3387,3388,3389,3390,3391,3392,3393,3394,3395,3396,3397,3398,3399,
            3400,3401,3402,3403,3404,3405,3411,3432,3434,3440,3441,3442,
            3470,3471,3472,3473,3474,3475,3476,3477,3478,3479,3480,3481,3499,
            3500,3501,3502,3503,3504,3505,3506,3507,3508,3509,3510,3511,3512,3513,3514,3515,3516,3517,3518,3519,3520,3521,3522,3523,3524,3525,3526,3530,3531,3533,
            3567,3568,3569,3571,3572,3573,3574,3576,3577,
            3637,3640,3641,3643,
            3653,3654,3655,3656,3657,3658,3659,3660,3661,3662,3663,3664,3665,3666,3667,3668,3669,3670,3671,3672,3673,3674,3675,3676,3677,3678,3680,3681,3682,3683,3684,3685,3687,3689,3691,3692,3693,3694,3695,3697,3698,
            3700,3701,3702,3703,3704,3705,3707,3711,3712,3713,3714,3715,3716,3717,3718,3719,3720,3722,3723,3724,3725,3726,3727,3728,3729,3733,3735,3736,3738,3740,3743,3744,3746,
            3761,
            3800,3801,3802,3803,3809,3810,3811,3817,3818,3819,3820,3821,3822,3823,3824,3827,3828,3833,3834,3848,3849,
            3860,3861,3862,3863,3864,3865,3866,3869,
            3902,3929,3930,
            3955,3963,3964,3965,3977,3978,3979,3981,3982,3983,
            4017,4018,4019,4020,4022,4024,4025,4026,4027,4028,
            4059,4060,4061,4062,4068,4069,4070,4071,4072,4073,4074,4075,4076,4077,4078,4084,4087,4089,4090,4093,4094,4095,4096,
            4128,4133,4139,4142,
            4170,4171,4172,4173,4174,4175,4189,4190,4191,4192,4198,4199,
            4201,4206,4208,4209,4210,4211,4212,4213,4214,4215,4216,4221,4226,4227,4231,4232,4247,
            4265,4280,4281,4290,4291,4292,4293,4294,4295,4296,4297,4298,4299,
            4300,4301,4302,4303,4304,4305,4306,4307,4308,4309,4310,4311,4312,4313,4314,4315,4316,4317,4318,4319,4320,4321,4322,4323,4324,4325,4326,4327,4328,4329,4330,4331,4332,4333,4334,4335,4336,4337,4338,4339,4340,4341,4342,4343,4344,4345,4346,4347,4348,4349,
            4350,4351,4352,4353,4354,4355,4356,4357,4358,4359,4360,4361,4362,4363,4364,4365,4366,4367,4368,4369,4370,4371,4372,4373,4374,4375,4376,4377,4378,4379,4380,4381,4382,4383,4384,4385,4386,4387,4388,4389,4390,4391,4392,4393,4394,4395,4396,4397,4398,4399,
            4400,4401,4402,4403,4404,4405,4406,4407,4408,4409,4410,4411,4412,4413,4414,4415,4416,4417,4418,4419,4420,4421,4422,4423,4424,4425,4426,4427,4428,4429,4430,4431,4432,4433,4434,4435,4436,4437,4438,4439,4440,4441,4442,4443,4444,4445,4446,4447,4448,4449,
            4450,4451,4452,4453,4454,4455,4456,4457,4458,4459,4460,4461,4462,4463,4464,4465,4466,4467,4468,4469,4470,4471,4472,4473,4474,4475,4476,4477,4478,4479,4480,4481,4482,4483,4484,4485,4486,4487,4488,4489,4490,4491,4492,4493,4494,4495,4496,4497,4498,4499,
            4500,4501,4502,4503,4504,4505,4506,4507,4508,4509,4510,4511,4512,4513,4514,4515,4516,4517,4518,4519,4520,4521,4522,4523,4524,4525,4526,4527,4528,4529,4530,4531,4532,4533,4534,4535,4536,4537,4538,4539,4540,4541,4542,4543,4544,4545,4546,4547,4548,4549,
            4550,4551,4552,4553,4554,4555,4556,4557,4558,4559,4560,4561,4562,4563,4564,4565,4566,4567,4568,4569,4570,4571,4572,4573,4574,4575,4576,4577,4578,4579,4580,4581,4582,4583,4584,4585,4586,4587,4588,4589,4590,4591,4592,4593,4594,4595,4596,4597,4598,4599,
            4600,4601,4602,4603,4604,4605,4606,4607,4608,4609,4610,4611,4612,4613,4614,4615,4616,4617,4618,4619,4620,4621,4622,4623,4624,4625,4626,4627,4628,4629,4630,4631,4632,4633,4634,4635,4636,4637,4638,4639,4640,4641,4642,4643,4644,4645,4647,4649,
            4650,4651,4652,4654,4656,4658,4660,4661,4662,4663,4664,4665,4666,4667,4668,4669,4670,4671,4672,4673,4674,4675,4676,4677,4678,4679,4680,4681,4682,4683,4684,4685,4686,4687,4688,4689,4690,4691,4692,4693,4694,4695,4696,4697,4698,4699,
            4700,4701,4702,4703,4704,4705,4706,4707,4708,4709,4710,4711,4712,4714,4715,
            4910,4911,4912,
            4967,4981,4986,
            5009,5026,5032,5033,5034,5037,5038,5039,5040,5041,5042,5043,5044,5045,5046,5047,5048,5049,
            5050,5051,5052,5053,5054,5055,5056,5057,5058,5059,5060,5061,5062,5063,5064,5065,5066,5067,5068,5069,5070,5071,5072,5074,5075,5076,5077,5078,5079,5080,5081,5082,5083,5084,5085,5086,5087,5088,5089,5090,5091,5092,5093,5094,5095,5096,5097,5098,5099,
            5100,5101,5102,5103,5104,5105,5120,5121,5122,5124,5125,5127,5129,5132,5134,5137,5138,5139,5140,5141,5142,5143,5144,5145,5146,5149,
            5150,5153,5154,5155,5156,5157,5158,5159,5175,5182,5183,5192,
            5204,5205,5206,5207,5208,
            5314,5330,5337,5338,5339,5340,5341,5342,5343,5344,5345,5346,5347,5348,5349,
            5350,5351,5352,5353,5354,5355,5356,5357,5358,5359,5360,5361,5362,5363,5364,5365,5366,5367,5368,5369,5370,5371,5372,5373,5374,5375,5376,5377,5378,5379,5380,5381,5382,5383,5384,5385,5386,5387,5388,5389,5390,5391,5392,5393,5394,5395,5396,5397,5398,5399,
            5400,5401,5402,5403,5404,5405,5406,5407,5408,5409,5410,5411,5412,5413,5414,5415,5416,5417,5418,5419,5420,5421,5422,5423,5424,5425,5426,5427,5428,5429,5430,5435,5436,5437,5439,5440,5442,5444,5446,5449,
            5450,5451,
            5522,5530,5531,5541,5544,5545,5546,5547,5548,5549,
            5550,5551,
            5753,5754,5755,5756,5763,5764,5765,5766,5767,5768,5769,5770,5771,5772,5773,5774,5775,5776,5777,5778,5779,5780,5781,5782,5783,5784,5785,5786,5787,5788,5789,5790,5791,5792,5793,5794,5795,5796,5797,5798,5799,
            5800,5801,5802,5803,5804,5805,5806,5807,5808,5809,5810,5811,5812,5813,5814,5815,5816,5817,5818,5819,5820,5821,5822,5823,5824,5825,5826,5827,5828,5829,5830,5831,5832,5833,5834,5835,5836,5837,5838,5839,5840,5841,5842,5843,5844,5845,5846,5847,5848,5849,
            5850,5851,5852,5853,5854,5855,5856,5857,5858,5859,5860,5861,5862,5863,5864,5865,5866,5867,5868,5869,5870,5871,5872,5873,5874,5875,5876,5877,5878,5879,5880,5881,5882,5883,5884,5885,5886,5887,5888,5889,5890,5891,5892,5893,5894,5895,5896,5897,
            5903,5905,5907,5909,5911,
            5978,5982,5983,5984,5985,5986,5987,5988,5989,5990,5991,5992,5993,5994,5995,5996,5997,5998,5999,
            6000,6001,6002,6003,6004,6005,6006,6007,6008,6009,6010,6011,6012,6013,6014,6015,6016,6017,6018,6019,6020,6021,6022,6023,6024,6025,6026,6027,6028,6029,6030,6031,6035,6039,6040,6041,6042,6043,6044,6045,6046,6047,6048,6049,
            6050,6051,6052,6053,6054,6055,6056,6057,6058,6059,6060,6061,6062,6063,6064,6065,6066,6067,6068,6069,6070,6071,6072,6073,6074,6075,6079,6080,6081,6082,6083,6084,6085,6086,6087,6088,6089,6090,6091,6092,6093,6094,6095,6096,6097,6098,6099,
            6100,6101,6102,6103,6104,6105,6106,6107,6108,6109,6110,6111,6112,6113,6114,6115,6116,6117,6118,6119,6120,6121,6122,6123,6124,6125,6126,6127,6129,6130,6131,6132,6133,6134,6135,6136,
            6150,6151,6153,6170,6171,6172,6189,6190,6191,6192,6193,6194,6195,6196,6197,6198,6199,
            6320,6321,6322,6326,6327
        };

    }
}
