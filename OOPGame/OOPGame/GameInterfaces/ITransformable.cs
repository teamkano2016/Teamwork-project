using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public interface ITransformable
    {
        // Move current hero in random position of the field.
        void Teleport();
    }
}