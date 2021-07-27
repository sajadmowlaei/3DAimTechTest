namespace Statistics
{
    public class StatisticsTrackerData
    {
        public int numOfHit;
        public int numOfCriticalHit;
        public int numOfMiss;
        public float score;
        public int targetsToKill;
        public int currentKill;
        public float accuracy;
        public float criticalAccuracy;

        public StatisticsTrackerData(int numOfHit, int numOfCriticalHit, int numOfMiss,float score, int targetsToKill, int currentKill,float accuracy, float criticalAccuracy)
        {
            this.numOfHit = numOfHit;
            this.numOfCriticalHit = numOfCriticalHit;
            this.numOfMiss = numOfMiss;
            this.score = score;
            this.targetsToKill = targetsToKill;
            this.currentKill = currentKill;
            this.accuracy = accuracy;
            this.criticalAccuracy = criticalAccuracy;

        }
    }
}
