using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PAC_1.Model
{
    class Question
    {
        public enum Difficulty
        { A, B, C, D, E, F, G }

        public int ID;
        public string Summary;
        public string Description;
        public Difficulty DifficultyLevel;

    }
}
