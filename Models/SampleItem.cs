namespace SampleApp.Models;

public class SampleItem
{
	public string Title { get; set; }

	public string Description { get; set; }

    public SampleItem(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public SampleItem()
    {
        Title = string.Empty;
        Description = string.Empty;
    }
}
