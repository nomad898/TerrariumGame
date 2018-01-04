using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Infrastructure
{
    static class Config
    {
        /// <summary>
        ///     MapManipulator config
        /// </summary>
        public const int MIN_OBJECT_AMOUNT = 4;
        public const int MAX_OBJECT_AMOUNT = 12;
        public const int BEGIN_OBJECT_ID = 1;
        public const int END_OBJECT_ID = 6;

        /// <summary>
        ///     Map config
        /// </summary>
        public const int MAP_WIDTH = 10;
        public const int MAP_HEIGHT = 10;
    }
}
