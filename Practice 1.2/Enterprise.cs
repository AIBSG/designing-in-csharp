namespace Incapsulation.EnterpriseTask;

public class Enterprise
{
	public readonly Guid Guid;

    public Enterprise(Guid guidb)
	{
		Guid = guidb;
	}

	string Name { get; set; }

	/*public string Name
	{
		get { return name; }
	}*/

	string inn;
 

    public string Inn
	{
		get { return inn; }

		set 
		{
            if (value.Length != 10 || !value.All(z => char.IsDigit(z)))
                throw new ArgumentException();
			inn = value;
		}
	}


	DateTime EstablishDate { get ; set; }

	public TimeSpan ActiveTimeSpan { get => DateTime.Now - EstablishDate; }
    
	public double GetTotalTransactionsAmount()
	{
		DataBase.OpenConnection();
		var amount = 0.0;
		foreach (Transaction t in DataBase.Transactions().Where(z => z.EnterpriseGuid == Guid))
			amount += t.Amount;
		return amount;
	}
}