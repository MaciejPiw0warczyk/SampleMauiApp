using System.Text;
using CommunityToolkit.Maui.Storage;

namespace SampleApp.Services;

public class SampleDataService
{
    private readonly string SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.csv");

    public async Task<IEnumerable<SampleItem>> GetItems()
	{
		await Task.Delay(1000); // Artifical delay to give the impression of work

		var random = new Random().Next();

		var result = new List<SampleItem>();

		for (var i = 0; i < 40; i++)
		{
			result.Add(new SampleItem
			{
				Title = $"Item {random}-{i}",
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Magna etiam tempor orci eu. Proin libero nunc consequat interdum varius. Vitae congue mauris rhoncus aenean vel elit. Ipsum dolor sit amet consectetur adipiscing elit pellentesque. Pellentesque habitant morbi tristique senectus et netus. Tempus quam pellentesque nec nam aliquam sem et. Mollis nunc sed id semper risus in hendrerit gravida rutrum. Leo vel orci porta non. Interdum velit laoreet id donec ultrices. Nulla facilisi cras fermentum odio. Nulla at volutpat diam ut. Aenean vel elit scelerisque mauris pellentesque pulvinar pellentesque. Consectetur lorem donec massa sapien faucibus et molestie ac feugiat. Mauris nunc congue nisi vitae. Consequat id porta nibh venenatis cras. Malesuada fames ac turpis egestas integer eget. Pharetra sit amet aliquam id diam maecenas ultricies.\r\n\r\nHendrerit dolor magna eget est lorem ipsum dolor sit amet. Et pharetra pharetra massa massa ultricies mi quis. Felis bibendum ut tristique et egestas quis ipsum suspendisse. Enim sed faucibus turpis in eu mi bibendum neque. Eget nulla facilisi etiam dignissim diam quis enim. Nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Id aliquet lectus proin nibh nisl condimentum id. Et molestie ac feugiat sed. Fermentum posuere urna nec tincidunt. Eget felis eget nunc lobortis. Ut lectus arcu bibendum at varius vel. In cursus turpis massa tincidunt dui. Aliquam etiam erat velit scelerisque in dictum non consectetur a. Condimentum mattis pellentesque id nibh. Ridiculus mus mauris vitae ultricies leo. Et malesuada fames ac turpis egestas integer eget. Vitae tortor condimentum lacinia quis vel eros donec ac. Aenean euismod elementum nisi quis eleifend quam adipiscing vitae. Sed turpis tincidunt id aliquet risus feugiat in ante."
			});
		}

		return result;
	}

    public async Task<IEnumerable<SampleItem>> GetTasks()
    {
        await Task.Delay(1000);

        List<SampleItem> result = [];

        if (!Path.Exists(SavePath))
        {

            result.Add(new SampleItem
            {
                Title = "Zapisz Jakieś Dane",
                Description = "Te zadania to tylko test, możesz zapisać własne!"                 
            });

            result.Add(new SampleItem
            {
                Title ="Stwórz własną aplikację",
                Description = "Lub edytuj tą, możesz wykożystać stronę blank do testowania nowych rzeczy",
            });

            SaveTasks(result);

            return result;

        }

        using(StreamReader sr = new StreamReader(SavePath))
        {
            var line = string.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                var task =line.Split(',');
                result.Add(new SampleItem(task[0], task[1]));
            }
        }

        return result;
    }

    public async Task<bool> SaveTasks(IEnumerable<SampleItem> tasks)
    {
        string serializedTasks = string.Empty;

        foreach (var task in tasks)
        {
            serializedTasks += task.Title + ",";
            serializedTasks += task.Description + "\n";
        }

        try
        {
            using (StreamWriter sw = new(SavePath, false, Encoding.UTF8)) 
            {
                await sw.WriteAsync(serializedTasks);
            }
        }
        catch { return false; }

        return true;
    }
}
