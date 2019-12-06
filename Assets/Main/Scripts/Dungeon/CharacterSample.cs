using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts
{
    public class CharacterSample
    {
        #region Variables
        public string Name;


        #endregion

        #region public sprite
        public Sprite Portrait;
        public Sprite Torso;

        #endregion

        public CharacterSample(string name, Sprite portrait)
        {
            Name = name;
            Portrait = portrait;
        }
    }
}
