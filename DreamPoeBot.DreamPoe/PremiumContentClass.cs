using System.ComponentModel;

namespace DreamPoeBot.DreamPoe;

public class PremiumContentClass : INotifyPropertyChanged
{
	private string id;

	private string name;

	private bool enabled;

	public string Id
	{
		get
		{
			return id;
		}
		set
		{
			id = value;
			RaisePropertyChanged("Id");
		}
	}

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
			RaisePropertyChanged("Name");
		}
	}

	public bool Enabled
	{
		get
		{
			return enabled;
		}
		set
		{
			enabled = value;
			RaisePropertyChanged("Enabled");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
