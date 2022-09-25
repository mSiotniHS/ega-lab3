namespace ega_lab3;

public interface IFitnessCalculator<TPreimage, TImage>
{
	public TImage Calculate(TPreimage preimage);
}
