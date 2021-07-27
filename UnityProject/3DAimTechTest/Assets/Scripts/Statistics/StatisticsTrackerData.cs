namespace Statistics
{
    public class StatisticsTrackerData
    {
        public int numOfHit;

        public int numOfMiss;
        public float score;

        public StatisticsTrackerData(int numOfHit, int numOfMiss,float score)
        {
            this.numOfHit = numOfHit;
            this.numOfMiss = numOfMiss;
            this.score = score;

        }
    }
}
