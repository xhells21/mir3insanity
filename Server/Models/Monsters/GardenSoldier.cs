using System.Collections.Generic;
using Library;
using Server.Envir;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class GardenSoldier : MonsterObject
    {
        public int AttackRange = 7;

        protected override bool InAttackRange()
        {
            if (Target.CurrentMap != CurrentMap) return false;
            if (Target.CurrentLocation == CurrentLocation) return false;

            return Functions.InRange(CurrentLocation, Target.CurrentLocation, AttackRange);
        }

        public override void ProcessTarget()
        {
            if (Target == null) return;

            if (CurrentLocation == Target.CurrentLocation)
            {
                MirDirection direction = (MirDirection)SEnvir.Random.Next(8);
                int rotation = SEnvir.Random.Next(2) == 0 ? 1 : -1;

                for (int d = 0; d < 8; d++)
                {
                    if (Walk(direction)) break;

                    direction = Functions.ShiftDirection(direction, rotation);
                }
            }
            else if (!Functions.InRange(CurrentLocation, Target.CurrentLocation, 2))
                MoveTo(Target.CurrentLocation);

            if (InAttackRange() && CanAttack)
                Attack();
        }

        protected override void Attack()
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);
            UpdateAttackTime();

            if ( !Functions.InRange(Target.CurrentLocation, CurrentLocation, 2))
                RangeAttack();
            else
            {
                Broadcast(new S.ObjectAttack { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation }); //Animation ?

                for (int radius = 1; radius <= 2; radius++)
                {
                    for (int dis = -1; dis <= 1; dis++)
                    {
                        foreach (MapObject ob in GetTargets(CurrentMap, Functions.Move(CurrentLocation, Functions.ShiftDirection(Direction, dis)), radius))
                        {
                            ActionList.Add(new DelayedAction(
                                SEnvir.Now.AddMilliseconds(400),
                                ActionType.DelayAttack,
                                ob,
                                GetDC(),
                                AttackElement));
                        }
                    }
                }
            }            
        }

        private void RangeAttack()
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);

            Broadcast(new S.ObjectRangeAttack { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation, Targets = new List<uint> { Target.ObjectID } });
            ActionList.Add(new DelayedAction(
                        SEnvir.Now.AddMilliseconds(400),
                        ActionType.DelayAttack,
                        Target,
                        GetMC(),
                        AttackElement));
        }
    }
}
