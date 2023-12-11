using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut 
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => swallowType switch
        {
            SwallowType.African => new African(),
            SwallowType.European => new European(),
            _ => throw new ArgumentOutOfRangeException(nameof(swallowType), swallowType, "-What do you mean, an African or a European swallow? -I...I don't know that... AAARRGH")
        };
    }

    public sealed class African : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 22,
                SwallowLoad.Coconut => 18,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public sealed class European : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 20,
                SwallowLoad.Coconut => 16,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public abstract class Swallow
    {
        public SwallowLoad Load { get; private set; }
        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }
}