using System;
using Library;
using Server.Envir;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class GardenDefender : MonsterObject
    {
        protected override void Attack()
        {

            if (CurrentHP <= Stats[Stat.Health] / 2 && SEnvir.Random.Next(4) > 0)
                Defend();
            else
                base.Attack();         
        }

        private void Defend()
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);
            UpdateAttackTime();

            Broadcast(new S.ObjectRangeAttack { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation });

            foreach (MapObject ob in GetTargets(CurrentMap, CurrentLocation, 1))
            {
                Stats buffStats = new Stats
                {
                    [Stat.MinAC] = ob.Stats[Stat.MaxAC] / 2,
                    [Stat.MaxAC] = ob.Stats[Stat.MaxAC] / 2,
                    [Stat.PhysicalResistance] = 1,
                };

                ob.BuffAdd(BuffType.Resilience, TimeSpan.FromSeconds(6), buffStats, true, false, TimeSpan.Zero);
            }        
        }
    }
}
