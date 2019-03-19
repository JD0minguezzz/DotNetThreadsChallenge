using System.Collections.Generic;

namespace ChallengeManager
{
    public abstract class DbOperation
    {
        public abstract void Operation(List<string[]> rows, bool useLog);
    }
}
