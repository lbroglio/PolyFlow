using System.Diagnostics;
using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace PolyFlow.Pages;

public partial class MainPage : ContentPage
{

	// Setup the canvas the user adds objects to 
	private void SetupCanvas(){
		// Set the size of the canvas to extend to the bottom of the screen

		// Get the total height of the window
		double screenHeight = DeviceDisplay.MainDisplayInfo.Height;

        double canvasHeight;
        if (FindByName("toolbar") is HorizontalStackLayout toolbar){
			canvasHeight = screenHeight - toolbar.Height;
		}
		else{
			canvasHeight = screenHeight;
		}

        // Calculate the height the canvas should be 
        if (FindByName("canvas") is GraphicsView canvas)
        {
            canvas.HeightRequest = canvasHeight;
        }
	}

	// Setup toolbar options
	private void SetupSelectButton(){
		if(FindByName("selectTool") is Button button){
			// Load image
			IImage image;
			Assembly assembly = GetType().GetTypeInfo().Assembly;
			using (Stream stream = assembly.GetManifestResourceStream("PolyFlow.Resources.Images.dotnet_bot.png"))
			{
				image = PlatformImage.FromStream(stream);
			}

			if(image != null){
				// Resize the image
				IImage resizedImage = image.Resize(100, 100, ResizeMode.Fit, true);
				button.ImageSource = (ImageSource) resizedImage;

			}
		}
	}




	public MainPage()
	{
		InitializeComponent();

		//Setup components
		SetupCanvas();				
    }

}

public class GraphicsDrawable : IDrawable
{

	public void Draw(ICanvas canvas, RectF dirtyRect)
	{


		// Set Canvas height and width 
		canvas.FontColor = Colors.Red;
		canvas.FontSize = 18;
		canvas.DrawString("Text is left aligned.", 0, 20, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
		canvas.DrawString("Text is centered.", 20, 60, 380, 100, HorizontalAlignment.Center, VerticalAlignment.Top);
		canvas.DrawString("Text is right aligned.", 20, 100, 380, 500, HorizontalAlignment.Right, VerticalAlignment.Bottom);
		canvas.FillColor = Colors.Yellow;
		canvas.StrokeColor = Colors.Yellow;
	}
}