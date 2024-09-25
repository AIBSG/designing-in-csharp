namespace Incapsulation.Weights;

class Indexer
{
    //public double[] range;
    private int _start;
    private double[] originalMassive; 
    public int Length { get;}

    public Indexer( double[] list, int start, int length)
    {
        if (start + length > list.Length || start < 0 || length < 0) 
            throw new ArgumentException();
        else
        {
            Length = length;
            originalMassive = list;
            _start = start;
        }
    }

    public double this[int index]
    {
        get
        {
            if(index >= Length || index < 0)
                throw new IndexOutOfRangeException();
            else
                return originalMassive[_start+index];
        }
        set {
            if (index >= Length || index < 0)
                throw new IndexOutOfRangeException();
            else
                originalMassive[_start+index] = value;
        }
    }
}