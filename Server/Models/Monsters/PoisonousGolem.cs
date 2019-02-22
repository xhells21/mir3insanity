using System;
using System.Collections.Generic;
using Library;
using Server.Envir;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class PoisonousGolem : MonsterObject
    {
        public int Cast;
        private DateTime CastTime;


        public override void ProcessTarget()
        {
            if (Target == null) return;

            if ((Cast <= 0 || SEnvir.Now > CastTime) && CanAttack && Functions.InRange(Target.CurrentLocation, CurrentLocation, 7))
            {
                Cast = 3;
                CastTime = SEnvir.Now.AddSeconds(5);
                PoisonRate = 2;
                LineAoE(10, -1, 1, MagicType.PoisonousGolemLineAoE, Element.None);
            }

            base.ProcessTarget();
        }

        protected override void Attack()
        {
            Cast--;
            PoisonRate = 5;

            base.Attack();
        }

    }
}
