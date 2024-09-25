using System;
using System.ComponentModel.DataAnnotations;

namespace Incapsulation.Failures;

public class ReportMaker
{
	/// <summary>
	/// </summary>
	/// <param name="day"></param>
	/// <param name="failureTypes">
	/// 0 for unexpected shutdown, 
	/// 1 for short non-responding, 
	/// 2 for hardware failures, 
	/// 3 for connection problems
	/// </param>
	/// <param name="deviceId"></param>
	/// <param name="times"></param>
	/// <param name="devices"></param>
	/// <returns></returns>
	public static List<string> FindDevicesFailedBeforeDateObsolete(
		int day,
		int month,
		int year,
		int[] failureTypes, 
		int[] deviceId, 
		object[][] times,
		List<Dictionary<string, object>> devices)
	{
		var targetDate = new DateTime(year, month, day);
		var deviceList = new List<Device>();

        for (int i = 0; i < failureTypes.Length; i++)
		{
			var nowFailure = new Failure(
				failureTypes[i], 
				new DateTime((int)times[i][2], (int)times[i][1], (int)times[i][0]));
			var nowDevice = new Device(
				deviceId[i], 
				(string)devices[i]["Name"], 
				nowFailure);
			deviceList.Add(nowDevice);
		}

		var result = FindDevicesFailedBeforeDate(targetDate, deviceList);
		return result;
    }

    public static List<string> FindDevicesFailedBeforeDate(DateTime targetDate, List<Device> devices)
	{
		var resultDeviceNames = new List<string>();
		foreach (var device in devices)
		{
			if(device.Failure.Date < targetDate && device.Failure.IsFailureSerious) 
				resultDeviceNames.Add(device.Name);
		}
		return resultDeviceNames;
    }

}

public class Device
{
    public int Id { get; private set; }
    public string Name { get; private set;}
    public Failure Failure { get; private set; }

    public Device (int id, string name, Failure failure)
	{
		Id = id ; Name = name; Failure = failure;
	}
}

public class Failure
{
	public FailureType Type{ get; private set; }
	public DateTime Date { get; private set; }
	public bool IsFailureSerious { get; private set; }


    public Failure (int typeId, DateTime date)
	{
        Type = (FailureType)typeId ; Date = date; IsFailureSerious = typeId % 2 == 0;
	}
}

public enum FailureType
{
    Type1 = 1,
    Type2 = 2,
    Type3 = 3,
    Type4 = 4,
    Type5 = 5,
}