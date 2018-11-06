namespace JumpingJimmy2
{
    public class Solution
    {
        public static int JumpingJimmy2(int[] tower, int[] power, int[] poison, int jumpHeight)
        {
            int maxHeight = 0;
            int currentFloorIdx = 0;
            int nearestPowerFloorIdx = 0;
            int nearestPoisonFloorIdx = 0;

            while (CanJumpHigher(currentFloor: currentFloorIdx, jumpHeight: jumpHeight, towerFloors: tower))
            {
                (maxHeight, currentFloorIdx) = MakeJump(currentHeight: maxHeight, currentFloor: currentFloorIdx,
                    jumpHeight: jumpHeight, towerFloors: tower);

                nearestPowerFloorIdx = GetNearestPowerFloor(currentNearestPowerFloor: nearestPowerFloorIdx,
                    currentFloor: currentFloorIdx, towerPowerFloors: power);

                nearestPoisonFloorIdx = GetNearestPoisonFloor(currentNearestPoisonFloor: nearestPoisonFloorIdx,
                    currentFloor: currentFloorIdx, towerPoisonFloors: poison);

                jumpHeight = AdjustJumpStrength(jumpHeight: jumpHeight, currentFloor: currentFloorIdx,
                    towerPowerFloors: power, towerPoisonFloors: poison,
                    currentNearestPowerFloor: nearestPowerFloorIdx, currentNearestPoisonFloor: nearestPoisonFloorIdx);
            }

            return maxHeight;
        }

        private static int AdjustJumpStrength(int jumpHeight, int currentFloor, int[] towerPowerFloors, int[] towerPoisonFloors,
            int currentNearestPowerFloor, int currentNearestPoisonFloor)
        {
            if (currentNearestPowerFloor < towerPowerFloors.Length
                && currentFloor - 1 == towerPowerFloors[currentNearestPowerFloor])
            {
                jumpHeight += 1;
            }
            else if (currentNearestPoisonFloor < towerPoisonFloors.Length
                && currentFloor - 1 == towerPoisonFloors[currentNearestPoisonFloor])
            {
                jumpHeight -= 1;
            }

            return jumpHeight;
        }

        private static int GetNearestPowerFloor(int currentNearestPowerFloor, int currentFloor, int[] towerPowerFloors)
        {
            return GetNearestSpecialFloor(currentNearestSpecialFloor: currentNearestPowerFloor, currentFloor: currentFloor,
                towerSpecialFloors: towerPowerFloors);
        }

        private static int GetNearestPoisonFloor(int currentNearestPoisonFloor, int currentFloor, int[] towerPoisonFloors)
        {
            return GetNearestSpecialFloor(currentNearestSpecialFloor: currentNearestPoisonFloor, currentFloor: currentFloor,
                towerSpecialFloors: towerPoisonFloors);
        }

        private static int GetNearestSpecialFloor(int currentNearestSpecialFloor, int currentFloor, int[] towerSpecialFloors)
        {
            while (currentNearestSpecialFloor < towerSpecialFloors.Length
                && currentFloor - 1 > towerSpecialFloors[currentNearestSpecialFloor])
            {
                currentNearestSpecialFloor += 1;
            }

            return currentNearestSpecialFloor;
        }

        private static (int maxHeight, int currentFloorIdx) MakeJump(int currentHeight, int currentFloor, int jumpHeight, int[] towerFloors)
        {
            int jumpStrength = jumpHeight;
            int towerMaxFloor = towerFloors.Length;
            int nextFloor;
            while (currentFloor < towerMaxFloor && jumpStrength >= (nextFloor = towerFloors[currentFloor]))
            {
                jumpStrength -= nextFloor;
                currentHeight += nextFloor;
                currentFloor += 1;
            }

            return (currentHeight, currentFloor);
        }

        private static bool CanJumpHigher(int currentFloor, int jumpHeight, int[] towerFloors)
        {
            return currentFloor < towerFloors.Length && jumpHeight >= towerFloors[currentFloor];
        }
    }
}