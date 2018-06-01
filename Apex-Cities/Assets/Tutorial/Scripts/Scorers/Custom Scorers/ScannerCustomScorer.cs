using Apex.AI;
using Apex.Serialization;

public abstract class ScannerCustomScorer<T> : OptionScorerBase<T> {

    [ApexSerialization, FriendlyName("Score", "How much this scorer can score at maximum")]
    public float score = 0f;
}
