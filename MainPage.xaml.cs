namespace MauiApp1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		try
		{
			// simulate downloading a file to AppDataDirectory
			using var stream = await FileSystem.OpenAppPackageFileAsync("my_file.png");
			using var reader = new BinaryReader(stream);
			{
				byte[] buffer=new byte[5826];
				reader.Read(buffer, 0, buffer.Length);
				File.WriteAllBytes(Path.Combine(FileSystem.AppDataDirectory, "my_file.png"), buffer);
			}

			// open the file using Launcher.OpenAsync
			// works on Android and Windows but not on IOS
			await Launcher.OpenAsync(new OpenFileRequest("My File", new ReadOnlyFile(Path.Combine(FileSystem.AppDataDirectory, "my_file.png"))));
		}
		catch (Exception ex)
		{
		}
	}
}

