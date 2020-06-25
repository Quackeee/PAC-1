using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Model
{
    static class Questionary
    {
        public static readonly Question[] Questions;

        public static readonly Question[] TableManners;
        public static readonly Question[] MotorSkills;
        public static readonly Question[] ToiletAndWashing;
        public static readonly Question[] DressingUp;
        public static readonly Question[] Language;
        public static readonly Question[] Differentiation;
        public static readonly Question[] NumbersAndSizes;
        public static readonly Question[] PencilAndPaperSkills;
        public static readonly Question[] Playing;
        public static readonly Question[] Housework;
        public static readonly Question[] ManualSkills;
        public static readonly Question[] Agility;

        public static readonly Dictionary<Question[], string> SubcathegoryName;

        static Questionary()
        {
            Questions = JsonConvert.DeserializeObject<Question[]>(File.ReadAllText(Properties.Resources.QuestionsSource));

            TableManners = Questions.AtIndexes(0, 1, 17, 19, 33, 50, 68, 91, 92, 108).ToArray();
            MotorSkills = Questions.AtIndexes(2, 3, 19, 34, 35, 51, 69, 70, 93, 109).ToArray();
            ToiletAndWashing = Questions.AtIndexes(4, 20, 21, 36, 37, 52, 53, 71, 84).ToArray();
            DressingUp = Questions.AtIndexes(5, 6, 22, 23, 38, 54, 72, 73, 95,111).ToArray();
            Language = Questions.AtIndexes(7, 8, 24, 25, 39, 55, 56, 74, 96, 112).ToArray();
            Differentiation = Questions.AtIndexes(9, 26, 40, 57, 58, 75, 76, 77, 97, 113).ToArray();
            NumbersAndSizes = Questions.AtIndexes(10, 27, 41, 42, 59, 78, 79, 80, 98,114).ToArray();
            PencilAndPaperSkills = Questions.AtIndexes(11, 28, 43, 60, 81, 82, 99, 100, 101, 115).ToArray();
            Playing = Questions.AtIndexes(12,29,44,45,61,62,63,83,102,116).ToArray();
            Housework = Questions.AtIndexes(13, 30, 46, 64, 84, 85, 86, 103, 104, 117).ToArray();
            ManualSkills = Questions.AtIndexes(14, 15, 31, 47, 48, 65, 66, 87, 105, 118).ToArray();
            Agility = Questions.AtIndexes(16, 32, 49, 67, 88, 89, 90, 106, 107, 119).ToArray();

            SubcathegoryName = new Dictionary<Question[], string>();

            SubcathegoryName.Add(TableManners, Properties.Resources.TableMannersSubcathegoryName);
            SubcathegoryName.Add(MotorSkills, Properties.Resources.MotorSkillsSubcathegoryName);
            SubcathegoryName.Add(ToiletAndWashing, Properties.Resources.MotorSkillsSubcathegoryName);
            SubcathegoryName.Add(DressingUp, Properties.Resources.DressingUpSubcathegoryName);
            SubcathegoryName.Add(Language, Properties.Resources.LanguageSubcathegoryName);
            SubcathegoryName.Add(Differentiation, Properties.Resources.DifferentiationSubcathegoryName);
            SubcathegoryName.Add(NumbersAndSizes, Properties.Resources.NumbersAndSizesSubcathegoryName);
            SubcathegoryName.Add(PencilAndPaperSkills, Properties.Resources.PencilAndPaperSkillsSubcathegoryName);
            SubcathegoryName.Add(Playing, Properties.Resources.PlayingSubcathegoryName);
            SubcathegoryName.Add(Housework, Properties.Resources.HouseworkSubcathegoryName);
            SubcathegoryName.Add(ManualSkills, Properties.Resources.ManualSkillsSubcathegoryName);
            SubcathegoryName.Add(Agility, Properties.Resources.AgilitySubcathegoryName);

        }

        
    }

    static class Extensions
    {
        public static IEnumerable<T> AtIndexes<T>(this IEnumerable<T> original, params int[] indexes)
        {
            T[] toReturn = new T[indexes.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                toReturn[i] = original.ElementAt(indexes[i]);
            }

            return toReturn;
        }
    }
}
