
namespace JumpingJimmy2
{
    public class Solution
    {
        public static int jumpingJimmy2(int[] tower, int[] power, int[] poison, int jumpHeight)
        {
            int maxHeight = 0;
            int currentFloorIdx = 0;
            int nearestPowerFloorIdx = 0;
            int nearestPoisonFloorIdx = 0;

            int towerMaxFloor = tower.Length;
            int powerFloorConut = power.Length;
            int poisonFloorCount = poison.Length;

            int jumpStrength;

            while (currentFloorIdx < towerMaxFloor && jumpHeight >= tower[currentFloorIdx])
            {
                jumpStrength = jumpHeight;
                while (currentFloorIdx < towerMaxFloor && jumpStrength >= tower[currentFloorIdx])
                {
                    jumpStrength -= tower[currentFloorIdx];
                    maxHeight += tower[currentFloorIdx];
                    currentFloorIdx += 1;
                }


                while (nearestPowerFloorIdx < powerFloorConut && currentFloorIdx - 1 > power[nearestPowerFloorIdx])
                {
                    nearestPowerFloorIdx += 1;
                }
                while (nearestPoisonFloorIdx < poisonFloorCount && currentFloorIdx - 1 > poison[nearestPoisonFloorIdx])
                {
                    nearestPoisonFloorIdx += 1;
                }

                if (nearestPowerFloorIdx < powerFloorConut && currentFloorIdx - 1 == power[nearestPowerFloorIdx])
                {
                    jumpHeight += 1;
                } else if (nearestPoisonFloorIdx < poisonFloorCount && currentFloorIdx - 1 == poison[nearestPoisonFloorIdx])
                {
                    jumpHeight -= 1;
                }
            }

            return maxHeight;
        }
    }
}